﻿using System.Threading.Tasks;
using GISharp.GLib;
using NUnit.Framework;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class MainLoopTests
    {
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
            lock (MainContextTests.MainContextLock) {
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
    }
}