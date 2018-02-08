using System;
using System.Threading.Tasks;
using NUnit.Framework;
using GISharp.GLib;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class SourceTests
    {
        [Test]
        public void TestCurrent ()
        {
            lock (MainContextTests.MainContextLock) {
                // there is no main loop running, so there should be no current source
                Assert.That (Source.Current, Is.Null);

                // if we are in a callback, there should be a source.
                var callbackInvoked = false;
                Task.Run (() => {
                    var context = new MainContext ();
                    context.PushThreadDefault ();
                    var mainLoop = new MainLoop (context);
                    var source = Idle.CreateSource ();
                    source.SetCallback (() => {
                        try {
                            Assert.That (Source.Current.Handle, Is.EqualTo (source.Handle));
                            callbackInvoked = true;
                            return Source.Remove_;
                        } finally {
                            mainLoop.Quit ();
                        }
                    });
                    source.Attach (context);
                    mainLoop.Run ();
                    context.PopThreadDefault ();
                }).Wait (1000);
                Assert.That (callbackInvoked, Is.True);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRemove ()
        {
            lock (MainContextTests.MainContextLock) {
                var id = Idle.Add (() => Source.Remove_);
                Assume.That (MainContext.Default.FindSourceById (id), Is.Not.Null);
                Source.Remove (id);
                Assert.That (MainContext.Default.FindSourceById (id), Is.Null);
            }

            AssertNoGLibLog();
        }
    }
}
