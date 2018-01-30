
using System;
using GISharp.GLib;
using GISharp.GObject;
using NUnit.Framework;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class SignalTests
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
        public void TestStopEmissionByName()
        {
            bool stopEmission = false;
            int handler1Count = 0;
            int handler2Count = 0;

            using (var pspec = new ParamSpecBoolean("test-param", "test-param", "test-param",
                false, ParamFlags.Readwrite | ParamFlags.StaticStrings))
            using (var obj = new GISharp.GObject.Object()) {
                Action handler1 = () => {
                    handler1Count++;
                    if (stopEmission) {
                        obj.StopEmissionByName("notify");
                    }
                };

                Action handler2 = () => handler2Count++;

                Signal.Connect(obj, "notify", handler1);
                Signal.Connect(obj, "notify", handler2);

                var id = Signal.TryLookup("notify", GType.Object);
                Assume.That(id, Is.Not.EqualTo(0));

                // make sure our callbacks are working
                Signal.Emit(obj, id, 0, pspec);
                Assume.That(handler1Count, Is.EqualTo(1));
                Assume.That(handler2Count, Is.EqualTo(1));

                // now try to stop the emission
                stopEmission = true;
                Signal.Emit(obj, id, 0, pspec);

                Assert.That(handler1Count, Is.EqualTo(2));
                Assert.That(handler2Count, Is.EqualTo(1));

                // try an invalid name
                obj.StopEmissionByName("there-is-no-way-there-is-a-signal-with-this-name");
            }
        }
    }
}
