using System;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class TimeoutTests
    {
        [Test]
        public void TestAdd ()
        {
            // null function is not allowed
            Assert.That (() => Timeout.Add (0, null),
                Throws.InstanceOf<ArgumentNullException> ());

            // Timeout.Add() can only attach sources to the global main context,
            // so we need lock to ensure we have exclusive use.
            lock (MainContextTests.MainContextLock) {
                var timeoutInvoked = false;
                var mainLoop = new MainLoop ();

                var id = Timeout.Add (0, () => {
                    mainLoop.Quit ();
                    timeoutInvoked = true;
                    return Source.Remove_;
                });

                Assert.That (id, Is.Not.EqualTo (0));

                var source = MainContext.Default.FindSourceById (id);
                Task.Run (() => {
                    mainLoop.Run ();
                }).Wait (100);
                source.Destroy ();

                Assert.That (timeoutInvoked, Is.True);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestAddSeconds ()
        {
            // null function is not allowed
            Assert.That (() => Timeout.AddSeconds (0, null),
                Throws.InstanceOf<ArgumentNullException> ());
            
            // Timeout.AddSeconds() can only attach sources to the global main
            // context, so we need lock to ensure we have exclusive use.
            lock (MainContextTests.MainContextLock) {
                var timeoutInvoked = false;
                var mainLoop = new MainLoop ();

                var id = Timeout.AddSeconds (0, () => {
                    mainLoop.Quit ();
                    timeoutInvoked = true;
                    return Source.Remove_;
                });

                Assert.That (id, Is.Not.EqualTo (0));

                var source = MainContext.Default.FindSourceById (id);
                Task.Run (() => {
                    mainLoop.Run ();
                }).Wait (2000);
                source.Destroy ();

                Assert.That (timeoutInvoked, Is.True);
            }

            AssertNoGLibLog();
        }
    }
}
