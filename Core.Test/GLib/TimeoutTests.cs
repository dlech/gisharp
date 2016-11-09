using NUnit.Framework;
using System;
using System.Threading.Tasks;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture]
    public class TimeoutTests
    {
        [Test]
        public void TestAdd ()
        {
            lock (MainLoopTests.MainLoopLock) {
                var timeoutInvoked = false;

                Task.Run (() => {
                    var mainLoop = new MainLoop ();
                    var id = Timeout.Add (0, () => {
                        mainLoop.Quit ();
                        timeoutInvoked = true;
                        return Source.Remove_;
                    });
                    Assert.That (id, Is.Not.EqualTo (0));
                    mainLoop.Run ();
                }).Wait (100);

                Assert.That (timeoutInvoked, Is.True);
            }
        }

        [Test]
        public void TestAddSeconds ()
        {
            lock (MainLoopTests.MainLoopLock) {
                var timeoutInvoked = false;

                Task.Run (() => {
                    var mainLoop = new MainLoop ();
                    var id = Timeout.AddSeconds (0, () => {
                        mainLoop.Quit ();
                        timeoutInvoked = true;
                        return Source.Remove_;
                    });
                    Assert.That (id, Is.Not.EqualTo (0));
                    mainLoop.Run ();
                }).Wait (2000);

                Assert.That (timeoutInvoked, Is.True);
            }
        }

        [Test]
        public void TestCreateSource ()
        {
            var source = Timeout.CreateSource (0);
            Assert.That (source, Is.Not.Null);
        }

        [Test]
        public void TestCreateSourceSeconds ()
        {
            var source = Timeout.CreateSourceSeconds (0);
            Assert.That (source, Is.Not.Null);
        }
    }
}
