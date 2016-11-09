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
            lock (MainContextTests.MainContextLock) {
                var idleInvoked = false;

                // null function is not allowed
                Assert.That (() => Idle.Add (null),
                    Throws.InstanceOf<ArgumentNullException> ());

                // make sure method actually works as intended
                Task.Run (() => {
                    var mainLoop = new MainLoop ();
                    var id = Idle.Add (() => {
                        mainLoop.Quit ();
                        idleInvoked = true;
                        return Source.Remove_;
                    });
                    mainLoop.Run ();
                    Assert.That (id, Is.Not.EqualTo (0));
                }).Wait (100);

                Assert.That (idleInvoked, Is.True);
            }
        }

        [Test]
        public void TestCreateSource ()
        {
            var source = Idle.CreateSource ();
            Assert.That (source, Is.Not.Null);
        }
    }
}
