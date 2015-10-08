using NUnit.Framework;
using System;
using System.Threading.Tasks;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture]
    public class IdleTests
    {
        [Test]
        public void TestAdd ()
        {
            lock (MainLoopTests.MainLoopLock) {
                var idleInvoked = false;

                // null function is not allowed
                Assert.That (() => Idle.Add (null),
                    Throws.InstanceOf<ArgumentNullException> ());

                // make sure method actually works as intended
                Task.Run (() => {
                    var mainLoop = new MainLoop ();
                    Idle.Add (() => {
                        mainLoop.Quit ();
                        idleInvoked = true;
                        return Source.Remove;
                    });
                    mainLoop.Run ();
                }).Wait (100);

                Assert.That (idleInvoked, Is.True);
            }
        }

        [Test]
        public void TestRemove ()
        {
            var handle = Idle.Add (() => Source.Continue);

            // make sure removing works
            var actual = Idle.Remove (handle);
            Assert.That (actual, Is.True);

            // and try to remove again.
            actual = Idle.Remove (handle);
            Assert.That (actual, Is.False);
        }

        [Test]
        public void TestCreateSource ()
        {
            var source = Idle.CreateSource ();
            Assert.That (source, Is.Not.Null);
        }
    }
}
