using System;
using System.Threading.Tasks;
using GISharp.GLib;
using NUnit.Framework;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class IdleTests
    {
        [Test]
        public void TestAdd ()
        {
            // null function is not allowed
            Assert.That (() => Idle.Add (null),
                Throws.InstanceOf<ArgumentNullException> ());

            // Idle.Add() can only attach sources to the global main context,
            // so we need to use a lock to ensure exclusive use of the main
            // context.
            lock (MainContextTests.MainContextLock) {
                var idleInvoked = false;

                using (var mainLoop = new MainLoop ()) {
                    var id = Idle.Add (() => {
                        mainLoop.Quit ();
                        idleInvoked = true;
                        return Source.Remove_;
                    });

                    Assert.That (id, Is.Not.EqualTo (0));

                    var source = MainContext.Default.FindSourceById (id);
                    Task.Run (() => {
                        mainLoop.Run ();
                    }).Wait (100);
                    source.Destroy ();
                }

                Assert.That (idleInvoked, Is.True);
            }
        }

        [Test]
        public void TestCreateSource ()
        {
            var idleInvoked = false;
            using (var source = Idle.CreateSource ()) {
                Assert.That (source, Is.Not.Null);


                using (var context = new MainContext ())
                using (var mainLoop = new MainLoop (context)) {
                    source.SetCallback (() => {
                        mainLoop.Quit ();
                        idleInvoked = true;
                        return Source.Remove_;
                    });
                    source.Attach (context);

                    Task.Run (() => {
                        context.PushThreadDefault ();
                        mainLoop.Run ();
                        context.PopThreadDefault ();
                    }).Wait (100);
                }

                source.Destroy ();
            }

            Assert.That (idleInvoked, Is.True);
        }
    }
}
