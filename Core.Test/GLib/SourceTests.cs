using System;
using System.Threading.Tasks;

using NUnit.Framework;
using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture]
    public class SourceTests
    {
        [Test]
        public void TestCurrent ()
        {
            lock (MainLoopTests.MainLoopLock) {
                // there is no main loop running, so there should be no curent source
                Assert.That (Source.Current, Is.Null);

                // if we are in a callback, there should be a source.
                var callbackInvoked = false;
                Task.Run (() => {
                    var mainLoop = new MainLoop ();
                    Source source = null;
                    var id = Idle.Add (() => {
                        try {
                            Assert.That (Source.Current, Is.EqualTo (source));
                            callbackInvoked = true;
                            return Source.Remove_;
                        } finally {
                            mainLoop.Quit ();
                        }
                    });
                    source = MainContext.Default.FindSourceById (id);
                    mainLoop.Run ();
                }).Wait (1000);
                Assert.That (callbackInvoked, Is.True);
            }
        }

        [Test]
        public void TestRemove ()
        {
            lock (MainLoopTests.MainLoopLock) {
                var id = Idle.Add (() => Source.Remove_);
                Assume.That (MainContext.Default.FindSourceById (id), Is.Not.Null);
                Source.Remove (id);
                Assert.That (MainContext.Default.FindSourceById (id), Is.Null);
            }
        }
    }
}
