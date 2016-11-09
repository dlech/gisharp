using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture]
    public class MainLoopTests
    {
        /// <summary>
        /// The main loop lock.
        /// </summary>
        /// <remarks>
        /// Tests that use the main loop all use the same default context, so
        /// we need a lock to make sure these tests don't run at the same time.
        /// </remarks>
        public static object MainLoopLock = new object ();

        [Test]
        public void TestGetContext ()
        {
            var mainLoop = new MainLoop ();
            var context = mainLoop.Context;
            Assert.That (context, Is.EqualTo (MainContext.Default));
        }

        [Test]
        public void TestIsRunning ()
        {
            MainLoop mainLoop;

            mainLoop = new MainLoop (null, false);
            Assert.That (mainLoop.IsRunning, Is.False);

            mainLoop = new MainLoop (null, true);
            Assert.That (mainLoop.IsRunning, Is.True);
        }

        [Test]
        public void TestRunQuit ()
        {
            lock (MainLoopLock) {
                var mainLoop = new MainLoop ();
                Assume.That (!mainLoop.IsRunning);
                var runTask = Task.Run (() => mainLoop.Run ());
                Task.Delay (100).Wait ();
                Assume.That (mainLoop.IsRunning);
                Assert.That (runTask.IsCompleted, Is.False);
                mainLoop.Quit ();
                Task.Delay (100).Wait ();
                Assume.That (!mainLoop.IsRunning);
                Assert.That (runTask.IsCompleted, Is.True);
            }
        }

        [Test]
        public void TestSyncronizationContextPost ()
        {
            lock (MainLoopTests.MainLoopLock) {
                var invokedOnMainThread = false;

                // start background task to run main loop
                var task = Task.Run (() => {
                    var mainLoop = new MainLoop ();
                    // use Idle.Add to run stuff on the same thread as the main loop
                    // after mainLoop.Run has been called.
                    Idle.Add (() => {
                        // this gets the MainLoopSyncronizationContext that was set
                        // when mainLoop.Run was called. If it wasn't set, this
                        // will throw an exception.
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
                    mainLoop.Run ();
                });
                task.ConfigureAwait (false);
                task.Wait (100);

                Assert.That (invokedOnMainThread, Is.True);
            }
        }
    }
}
