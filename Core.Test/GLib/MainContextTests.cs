using System;
using System.Threading;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class MainContextTests
    {
        /// <summary>
        /// The main context lock.
        /// </summary>
        /// <remarks>
        /// Tests that use the main context will have have strange interactions
        /// because they can be run concurrently. So, we need a lock object to
        /// enusre that only one test at at time uses the main context.
        /// </remarks>
        public static object MainContextLock = new object ();

        [Test]
        public void TestDefault ()
        {
            Assert.That (MainContext.Default, Is.Not.Null);

            AssertNoGLibLog();
        }

        [Test]
        public void TestThreadDefault ()
        {
            Assert.That (MainContext.ThreadDefault, Is.Not.Null);

            AssertNoGLibLog();
        }

        [Test]
        public void TestDepth ()
        {
            Assert.That (MainContext.Depth, Is.EqualTo (0));

            AssertNoGLibLog();
        }

        [Test]
        public void TestPoll ()
        {
            Assert.That (() => MainContext.Poll (null, 0),
                Throws.TypeOf<ArgumentNullException> ());
            var ret = MainContext.Poll (new PollFD[0], 0);
            Assert.That (ret, Is.EqualTo (0));

            AssertNoGLibLog();
        }

        [Test]
        public void TestAquire ()
        {
            using (var context = new MainContext ()) {
                var ret = context.Acquire ();
                Assert.That (ret, Is.True);

                var threadAquiredContext = false;
                Task.Run (() => {
                    threadAquiredContext = context.Acquire ();
                }).Wait ();
                Assert.That (threadAquiredContext, Is.False);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestFindSourceById ()
        {
            using (var context = new MainContext ()) {
                var source = new IdleSource();
                var id = source.Attach (context);
                var foundSource = context.FindSourceById (id);
                Assert.That (foundSource.Handle, Is.EqualTo (source.Handle));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestInvoke ()
        {
            using (var context = new MainContext ())
            using (var mainLoop = new MainLoop (context)) {
                var invoked = false;
                context.Invoke (() => {
                    mainLoop.Quit ();
                    invoked = true;
                    return Source.Remove_;
                });

                Assert.That (invoked, Is.False);

                Task.Run (() => {
                    context.PushThreadDefault ();
                    mainLoop.Run ();
                    context.PopThreadDefault ();
                }).Wait (100);

                Assert.That (invoked, Is.True);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestIsOwner ()
        {
            using (var context = new MainContext ()) {
                Assert.That (context.IsOwner, Is.False);
                context.Acquire ();
                Assert.That (context.IsOwner, Is.True);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestCheckPending ()
        {
            using (var context = new MainContext ()) {
                var pending = context.CheckPending ();
                Assert.That (pending, Is.False);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRelease ()
        {
            using (var context = new MainContext ()) {
                Assume.That (context.IsOwner, Is.False);
                var ret = context.Acquire ();
                Assume.That (ret, Is.True);
                Assume.That (context.IsOwner, Is.True);

                context.Release ();
                Assert.That (context.IsOwner, Is.False);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestWakeup ()
        {
            using (var context = new MainContext ()) {
                var awake = false;
                var task = Task.Run (() => {
                    context.PushThreadDefault ();
                    context.Iteration (true);
                    awake = true;
                    context.PopThreadDefault ();
                });
                context.Wakeup ();
                task.Wait (100);
                Assert.That (awake, Is.True);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestSyncronizationContextPost ()
        {
            var invokedOnMainThread = false;

            var context = new MainContext ();
            var mainLoop = new MainLoop (context);
            // use IdleSource to run stuff on the same thread as
            // the main loop after mainLoop.Run has been called.
            var source = new IdleSource();
            source.SetCallback (() => {
                // this gets the MainLoopSyncronizationContext that was
                // set when mainLoop.Run was called. If it wasn't set, this
                // will throw an exception.
                var x2 = SynchronizationContext.Current;
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext ();

                var mainLoopThread = Thread.CurrentThread;

                // start another background thread to that we can try calling back
                // to the mainLoop thread using the scheduler.
                // This implicitly calls MainLoopSyncronzationContext.Post()
                Task.Run (() => {
                    Assume.That (mainLoopThread, Is.Not.EqualTo (Thread.CurrentThread));
                    Task.Factory.StartNew (() => {
                        mainLoop.Quit ();
                        // NUnit does not catch the error here since it is on another thread.
                        // But this is OK, we just check invokedOnMainThread later.
                        Assert.That (mainLoopThread, Is.EqualTo (Thread.CurrentThread));
                        invokedOnMainThread = true;
                    },
                        CancellationToken.None,
                        TaskCreationOptions.None,
                        scheduler);
                });
                return Source.Remove_;
            });
            source.Attach (context);

            var task = Task.Run (() => {
                context.PushThreadDefault ();
                mainLoop.Run ();
                context.PopThreadDefault ();
            });
            task.ConfigureAwait (false);
            var x = SynchronizationContext.Current;
            task.Wait (100);
            source.Destroy ();

            Assert.That (invokedOnMainThread, Is.True);

            AssertNoGLibLog();
        }
    }
}
