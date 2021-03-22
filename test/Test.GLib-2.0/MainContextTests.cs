// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System.Threading;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class MainContextTests : Tests
    {
        /// <summary>
        /// The main context lock.
        /// </summary>
        /// <remarks>
        /// Tests that use the main context will have have strange interactions
        /// because they can be run concurrently. So, we need a lock object to
        /// ensure that only one test at at time uses the main context.
        /// </remarks>
        public static readonly object MainContextLock = new();

        [Test]
        public void TestDefault()
        {
            Assert.That(MainContext.Default, Is.Not.Null);
        }

        [Test]
        public void TestThreadDefault()
        {
            Assert.That(MainContext.ThreadDefault, Is.Not.Null);
        }

        [Test]
        public void TestDepth()
        {
            Assert.That(MainContext.Depth, Is.Zero);
        }

        [Test]
        public void TestPoll()
        {
            var ret = MainContext.Poll(System.Array.Empty<PollFD>(), 0);
            Assert.That(ret, Is.Zero);
        }

        [Test]
        public void TestAquire()
        {
            using var context = new MainContext();
            var ret = context.Acquire();
            Assert.That(ret, Is.True);

            var threadAcquiredContext = false;
            Task.Run(() => {
                threadAcquiredContext = context.Acquire();
            }).Wait();
            Assert.That(threadAcquiredContext, Is.False);
        }

        [Test]
        public void TestFindSourceById()
        {
            using var context = new MainContext();
            using var source = IdleSource.New();
            var id = source.Attach(context);
            var foundSource = context.FindSourceById(id);
            Assert.That(foundSource.UnsafeHandle, Is.EqualTo(source.UnsafeHandle));
        }

        [Test]
        public void TestInvoke()
        {
            using var context = new MainContext();
            using var mainLoop = new MainLoop(context);
            var invoked = false;
            context.Invoke(() => {
                mainLoop.Quit();
                invoked = true;
                return Source.Remove;
            });

            Assert.That(invoked, Is.False);

            Task.Run(() => {
                context.PushThreadDefault();
                mainLoop.Run();
                context.PopThreadDefault();
            }).Wait(100);

            Assert.That(invoked, Is.True);
        }

        [Test]
        public void TestIsOwner()
        {
            using var context = new MainContext();
            Assert.That(context.IsOwner, Is.False);
            context.Acquire();
            Assert.That(context.IsOwner, Is.True);
        }

        [Test]
        public void TestPending()
        {
            using var context = new MainContext();
            var pending = context.IsPending;
            Assert.That(pending, Is.False);
        }

        [Test]
        public void TestRelease()
        {
            using var context = new MainContext();
            Assume.That(context.IsOwner, Is.False);
            var ret = context.Acquire();
            Assume.That(ret, Is.True);
            Assume.That(context.IsOwner, Is.True);

            context.Release();
            Assert.That(context.IsOwner, Is.False);
        }

        [Test]
        public void TestWakeUp()
        {
            using var context = new MainContext();
            var awake = false;
            var task = Task.Run(() => {
                context.PushThreadDefault();
                context.Iteration(true);
                awake = true;
                context.PopThreadDefault();
            });
            context.WakeUp();
            task.Wait(100);
            Assert.That(awake, Is.True);
        }

        [Test]
        public void TestSynchronizationContextPost()
        {
            var invokedOnMainThread = false;

            using (var context = new MainContext()) {
                using var mainLoop = new MainLoop(context);
                // use IdleSource to run stuff on the same thread as
                // the main loop after mainLoop.Run has been called.
                using var source = IdleSource.New();
                source.SetCallback(() => {
                    // this gets the MainLoopSynchronizationContext that was
                    // set when mainLoop.Run was called. If it wasn't set, this
                    // will throw an exception.
                    var x2 = SynchronizationContext.Current;
                    var scheduler = TaskScheduler.FromCurrentSynchronizationContext();

                    var mainLoopThread = Thread.CurrentThread;

                    // start another background thread to that we can try calling back
                    // to the mainLoop thread using the scheduler.
                    // This implicitly calls MainLoopSynchronizationContext.Post()
                    Task.Run(() => {
                        Assume.That(mainLoopThread, Is.Not.EqualTo(Thread.CurrentThread));
                        Task.Factory.StartNew(() => {
                            mainLoop.Quit();
                            // NUnit does not catch the error here since it is on another thread.
                            // But this is OK, we just check invokedOnMainThread later.
                            Assert.That(mainLoopThread, Is.EqualTo(Thread.CurrentThread));
                            invokedOnMainThread = true;
                        },
                            CancellationToken.None,
                            TaskCreationOptions.None,
                            scheduler);
                    });
                    return Source.Remove;
                });
                source.Attach(context);

                var task = Task.Run(() => {
                    context.PushThreadDefault();
                    mainLoop.Run();
                    context.PopThreadDefault();
                });
                task.ConfigureAwait(false);
                var x = SynchronizationContext.Current;
                task.Wait(100);
                source.Destroy();
            }

            Assert.That(invokedOnMainThread, Is.True);
        }

        static PollFD testPollFD = default;

        [Test]
        public void TestPollFD()
        {
            using var mc = new MainContext();
            mc.AddPoll(ref testPollFD);
            mc.RemovePoll(ref testPollFD);
        }
    }
}
