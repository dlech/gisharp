using NUnit.Framework;
using System;
using System.Threading.Tasks;

using GISharp.GLib;

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
    }
}
