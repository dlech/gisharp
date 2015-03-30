using NUnit.Framework;
using System;
using System.Threading.Tasks;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture ()]
    public class MainLoopTests
    {
        [Test ()]
        public void TestGetContext ()
        {
            var mainLoop = new MainLoop ();
            var context = mainLoop.Context;
            Assert.That (context, Is.EqualTo (MainContext.Default));
        }

        [Test ()]
        public void TestIsRunning ()
        {
            MainLoop mainLoop;

            mainLoop = new MainLoop (null, false);
            Assert.That (mainLoop.IsRunning, Is.EqualTo (false));

            mainLoop = new MainLoop (null, true);
            Assert.That (mainLoop.IsRunning, Is.EqualTo (true));
        }

        [Test ()]
        public void TestRunQuit ()
        {
            var mainLoop = new MainLoop ();
            Assume.That (!mainLoop.IsRunning);
            var runTask = Task.Run (() => mainLoop.Run ());
            Task.Delay (100).Wait ();
            Assume.That (mainLoop.IsRunning);
            Assert.That (runTask.IsCompleted, Is.EqualTo (false));
            mainLoop.Quit ();
            Task.Delay (100).Wait ();
            Assume.That (!mainLoop.IsRunning);
            Assert.That (runTask.IsCompleted, Is.EqualTo (true));
        }
    }
}
