using NUnit.Framework;
using System;
using System.Threading.Tasks;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture]
    public class MainContextTests
    {
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
