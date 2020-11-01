using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core
{
    [TestFixture]
    public class UnicharTests
    {
        [Test]
        public void TestSizeOf()
        {
            // it is important that we don't add any extra fields so that
            // Unichar exactly matches gunichar.
            Assert.That(Marshal.SizeOf<Unichar>(), Is.EqualTo(sizeof(uint)));
            AssertNoGLibLog();
        }

        [Test]
        public void TestToString()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.ToString(), Is.EqualTo("U+0041"));
            AssertNoGLibLog();
        }
    }
}
