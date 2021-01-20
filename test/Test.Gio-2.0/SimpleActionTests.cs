// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using GISharp.Lib.Gio;
using NUnit.Framework;

namespace GISharp.Test.Gio
{
    public class SimpleActionTests : Tests
    {
        [Test]
        public void TestNew()
        {
            using (var sa = new SimpleAction("test-action", null)) {
                Assert.That<string>(sa.Name!, Is.EqualTo("test-action"));
                Assert.That(sa.ParameterType, Is.Null);
                Assert.That(sa.State, Is.Null);
                Assert.That(sa.StateType, Is.Null);
            }

            using (var sa = new SimpleAction("test-action", VariantType.Boolean)) {
                Assert.That<string>(sa.Name!, Is.EqualTo("test-action"));
                Assert.That(sa.ParameterType, Is.EqualTo(VariantType.Boolean));
                Assert.That(sa.State, Is.Null);
                Assert.That(sa.StateType, Is.Null);
            }
        }

        [Test]
        public void TestNewStateful()
        {
            using (var sa = new SimpleAction("test-action", null, (Variant)0)) {
                Assert.That<string>(sa.Name!, Is.EqualTo("test-action"));
                Assert.That(sa.ParameterType, Is.Null);
                Assert.That((int)sa.State!, Is.Zero);
                Assert.That(sa.StateType, Is.EqualTo(VariantType.Int32));
            }

            using (var sa = new SimpleAction("test-action", VariantType.Boolean, (Variant)0)) {
                Assert.That<string>(sa.Name!, Is.EqualTo("test-action"));
                Assert.That(sa.ParameterType, Is.EqualTo(VariantType.Boolean));
                Assert.That((int)sa.State!, Is.Zero);
                Assert.That(sa.StateType, Is.EqualTo(VariantType.Int32));
            }
        }

        [Test]
        public void TestSetEnabled()
        {
            using var sa = new SimpleAction("test-action", VariantType.Boolean);
            Assume.That(sa.Enabled, Is.True);
            sa.SetEnabled(false);
            Assert.That(sa.Enabled, Is.False);
        }

        [Test]
        public void TestSetState()
        {
            using var sa = new SimpleAction("test-action", VariantType.Boolean, (Variant)false);
            Assume.That((bool)sa.State!, Is.False);
            sa.SetState((Variant)true);
            Assert.That((bool)sa.State!, Is.True);
        }

        [Test]
        public void TestSetStateHint()
        {
            using var sa = new SimpleAction("test-action", VariantType.Boolean, (Variant)false);
            Assume.That(sa.GetStateHint(), Is.Null);
            sa.SetStateHint((Variant)true);
            Assert.That((bool)sa.GetStateHint()!, Is.True);
        }

        [Test]
        public void TestActivateSignal()
        {
            using var sa = new SimpleAction("test-action", VariantType.Boolean);
            var parameter = default(Variant);
            sa.ActivateSignal += (a, p) => parameter = p;
            sa.Activate((Variant)true);
            Assert.That(parameter, Is.Not.Null, "Event was not called");
            Assert.That((bool)parameter!, Is.True);
        }

        [Test]
        public void TestChangeStateSignal()
        {
            using var sa = new SimpleAction("test-action", null, (Variant)5);
            var value = default(Variant)!;
            sa.ChangeStateSignal += (a, v) => value = v;
            sa.ChangeState((Variant)10);
            Assert.That(value, Is.Not.Null, "Event was not called");
            Assert.That((int)value, Is.EqualTo(10));
        }
    }
}
