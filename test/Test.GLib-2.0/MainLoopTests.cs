// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class MainLoopTests
    {
        [Test]
        public void TestGetContext()
        {
            using var mainLoop = new MainLoop();
            var context = mainLoop.Context;
            Assert.That(context.UnsafeHandle, Is.EqualTo(MainContext.Default.UnsafeHandle));
        }

        [Test]
        public void TestIsRunning()
        {
            using (var mainLoop = new MainLoop(null, false))
            {
                Assert.That(mainLoop.IsRunning, Is.False);
            }

            using (var mainLoop = new MainLoop(null, true))
            {
                Assert.That(mainLoop.IsRunning, Is.True);
            }
        }

        [Test]
        public void TestRunQuit()
        {
            lock (MainContextTests.MainContextLock)
            {
                using var mainLoop = new MainLoop();
                Assume.That(!mainLoop.IsRunning);
                var runTask = Task.Run(() => mainLoop.Run());
                Task.Delay(100).Wait();
                Assume.That(mainLoop.IsRunning);
                Assert.That(runTask.IsCompleted, Is.False);
                mainLoop.Quit();
                Task.Delay(100).Wait();
                Assume.That(!mainLoop.IsRunning);
                Assert.That(runTask.IsCompleted, Is.True);
            }
        }
    }
}
