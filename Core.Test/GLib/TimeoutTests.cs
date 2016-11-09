using NUnit.Framework;
using System.Threading.Tasks;
using System;

namespace GISharp.GLib.Test
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
        }

        [Test]
        public void TestCreateSource ()
        {
            var timeoutInvoked = false;
            var source = Timeout.CreateSource (0);
            Assert.That (source, Is.Not.Null);

            var context = new MainContext ();
            var mainLoop = new MainLoop (context);

            source.SetCallback (() => {
                mainLoop.Quit ();
                timeoutInvoked = true;
                return Source.Remove_;
            });

            source.Attach (context);
            Task.Run (() => {
                context.PushThreadDefault ();
                mainLoop.Run ();
                context.PopThreadDefault ();
            }).Wait (100);
            source.Destroy ();

            Assert.That (timeoutInvoked, Is.True);
        }

        [Test]
        public void TestCreateSourceSeconds ()
        {
            var timeoutInvoked = false;
            var source = Timeout.CreateSourceSeconds (0);
            Assert.That (source, Is.Not.Null);

            var context = new MainContext ();
            var mainLoop = new MainLoop (context);

            source.SetCallback (() => {
                mainLoop.Quit ();
                timeoutInvoked = true;
                return Source.Remove_;
            });

            source.Attach (context);
            Task.Run (() => {
                context.PushThreadDefault ();
                mainLoop.Run ();
                context.PopThreadDefault ();
            }).Wait (2000);
            source.Destroy ();

            Assert.That (timeoutInvoked, Is.True);
        }
    }
}
