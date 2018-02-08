﻿using System.Threading.Tasks;
using GISharp.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class MainLoopTests
    {
        [Test]
        public void TestGetContext ()
        {
            using (var mainLoop = new MainLoop ()) {
                var context = mainLoop.Context;
                Assert.That (context.Handle, Is.EqualTo (MainContext.Default.Handle));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestIsRunning ()
        {
            using (var mainLoop = new MainLoop (null, false)) {
                Assert.That (mainLoop.IsRunning, Is.False);
            }

            using (var mainLoop = new MainLoop (null, true)) {
                Assert.That (mainLoop.IsRunning, Is.True);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRunQuit ()
        {
            lock (MainContextTests.MainContextLock) {
                using (var mainLoop = new MainLoop ()) {
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

            AssertNoGLibLog();
        }
    }
}
