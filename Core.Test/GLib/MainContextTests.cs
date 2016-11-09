using System;
using System.Threading.Tasks;

using NUnit.Framework;

namespace GISharp.GLib.Test
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
        }

        [Test]
        public void TestThreadDefault ()
        {
            Assert.That (MainContext.ThreadDefault, Is.Not.Null);
        }

        [Test]
        public void TestDepth ()
        {
            Assert.That (MainContext.Depth, Is.EqualTo (0));
        }

        [Test]
        public void TestPoll ()
        {
            Assert.That (() => MainContext.Poll (null, 0),
                Throws.TypeOf<ArgumentNullException> ());
            var ret = MainContext.Poll (new PollFD[0], 0);
            Assert.That (ret, Is.EqualTo (0));
        }

        [Test]
        public void TestAquire ()
        {
            var context = new MainContext ();
            var ret = context.Acquire ();
            Assert.That (ret, Is.True);

            var threadAquiredContext = false;
            Task.Run (() => {
                threadAquiredContext = context.Acquire ();
            }).Wait ();
            Assert.That (threadAquiredContext, Is.False);
        }

        [Test]
        public void TestFindSourceById ()
        {
            var context = new MainContext ();
            var source = Idle.CreateSource ();
            var id = source.Attach (context);
            var foundSource = context.FindSourceById (id);
            Assert.That (foundSource, Is.EqualTo (source));
        }

        [Test]
        public void TestInvoke ()
        {
            var context = new MainContext ();
            var mainLoop = new MainLoop (context);
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

        [Test]
        public void TestIsOwner ()
        {
            var context = new MainContext ();

            Assert.That (context.IsOwner, Is.False);

            context.Acquire ();

            Assert.That (context.IsOwner, Is.True);
        }

        [Test]
        public void TestCheckPending ()
        {
            var context = new MainContext ();
            var pending = context.CheckPending ();
            Assert.That (pending, Is.False);
        }

        [Test]
        public void TestRelease ()
        {
            var context = new MainContext ();
            Assume.That (context.IsOwner, Is.False);
            var ret = context.Acquire ();
            Assume.That (ret, Is.True);
            Assume.That (context.IsOwner, Is.True);

            context.Release ();
            Assert.That (context.IsOwner, Is.False);
        }

        [Test]
        public void TestWakeup ()
        {
            var context = new MainContext ();
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
    }
}
