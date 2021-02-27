// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>


using System;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using NUnit.Framework;

using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Test.GObject
{
    public class SignalTests : Tests
    {
        [Test]
        public void TestValidateName()
        {
            Assert.That(() => Signal.ValidateName("4"), Throws.ArgumentException,
                "Name must start with a letter");
            Assert.That(() => Signal.ValidateName("s$"), Throws.ArgumentException,
                "$ is not allowed");
            Assert.That(() => Signal.ValidateName("s-s_s"), Throws.ArgumentException,
                "can't have both - and _");

            Assert.That(() => Signal.ValidateName("s"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("S"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("s1"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("s-s"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("s_s"), Throws.Nothing);
        }

        [Test]
        public void TestParseName()
        {
            var id = Signal.TryLookup("notify", GType.Object);
            Assume.That(id, Is.Not.Zero);

            uint signalId;
            Quark detail;

            // try a real signal name
            if (Signal.TryParseName("notify", GType.Object, out signalId, out detail)) {
                Assert.That(signalId, Is.EqualTo(id));
                Assert.That(detail, Is.EqualTo(Quark.Zero));
            }
            else {
                Assert.Fail("Should have returned true");
            }

            // again with the exception throwing version
            (signalId, detail) = Signal.ParseName("notify", GType.Object);
            Assert.That(signalId, Is.EqualTo(id));
            Assert.That(detail, Is.EqualTo(Quark.Zero));

            // A bad signal name returns false
            if (Signal.TryParseName("does-not-exist", GType.Object, out signalId, out detail)) {
                Assert.Fail("Should have returned false");
            }

            // again with the exception throwing version
            Assert.That(() => Signal.ParseName("does-not-exist", GType.Object), Throws.ArgumentException);
        }

        [Test]
        public void TestStopEmission()
        {
            bool stopEmission = false;
            int handler1Count = 0;
            int handler2Count = 0;

            using var pspec = new ParamSpecBoolean("test-param", "test-param", "test-param",
                false, ParamFlags.Readwrite | ParamFlags.StaticStrings);
            using var obj = new Object();
            var id = Signal.TryLookup("notify", GType.Object);
            Assume.That(id, Is.Not.EqualTo(0));

            Object.NotifySignalHandler handler1 = (o, p) => {
                handler1Count++;
                if (stopEmission) {
                    obj.StopEmission(id);
                }
            };

            Object.NotifySignalHandler handler2 = (o, p) => handler2Count++;

            obj.NotifySignal += handler1;
            obj.NotifySignal += handler2;

            // make sure our callbacks are working
            obj.Emit(id, 0, pspec);
            Assume.That(handler1Count, Is.EqualTo(1));
            Assume.That(handler2Count, Is.EqualTo(1));

            // now try to stop the emission
            stopEmission = true;
            obj.Emit(id, 0, pspec);

            Assert.That(handler1Count, Is.EqualTo(2));
            Assert.That(handler2Count, Is.EqualTo(1));
        }

        [Test]
        public void TestStopEmissionByName()
        {
            bool stopEmission = false;
            int handler1Count = 0;
            int handler2Count = 0;

            using var pspec = new ParamSpecBoolean("test-param", "test-param", "test-param",
                false, ParamFlags.Readwrite | ParamFlags.StaticStrings);
            using var obj = new Object();
            Object.NotifySignalHandler handler1 = (o, p) => {
                handler1Count++;
                if (stopEmission) {
                    obj.StopEmissionByName("notify::test-param");
                }
            };

            Object.NotifySignalHandler handler2 = (o, p) => handler2Count++;

            obj.NotifySignal += handler1;
            obj.NotifySignal += handler2;

            // make sure our callbacks are working
            obj.Notify(pspec);
            Assume.That(handler1Count, Is.EqualTo(1));
            Assume.That(handler2Count, Is.EqualTo(1));

            // now try to stop the emission
            stopEmission = true;
            obj.Notify(pspec);

            Assert.That(handler1Count, Is.EqualTo(2));
            Assert.That(handler2Count, Is.EqualTo(1));
        }

        [Test]
        public void TestEmissionHook()
        {
            var signalId = Signal.TryLookup<TestNetworkMonitor>("network-changed");
            Assume.That(signalId, Is.Not.Zero);
            var callbackCount = 0;
            var hookId = Signal.AddEmissionHook(signalId, Quark.Zero,
                (in SignalInvocationHint ihint, Span<Value> paramValues) => {
                    Assert.That(ihint.SignalId, Is.EqualTo(signalId));
                    Assert.That(paramValues[0].ValueGType, Is.EqualTo(GType.Of<TestNetworkMonitor>()));
                    Assert.That((bool)paramValues[1], Is.True);
                    callbackCount++;
                    return true;
                });

            using var monitor = TestNetworkMonitor.New();
            monitor.Emit(signalId, Quark.Zero, true);
            Assert.That(callbackCount, Is.EqualTo(1));
            monitor.Emit(signalId, Quark.Zero, true);
            Assert.That(callbackCount, Is.EqualTo(2));

            Signal.RemoveEmissionHook(signalId, hookId);
            monitor.Emit(signalId, Quark.Zero, true);
            Assert.That(callbackCount, Is.EqualTo(2));
        }
    }
}
