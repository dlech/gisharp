using System;

using NUnit.Framework;
using GISharp.GLib;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class PtrArrayTests
    {
        [Test]
        public void TestConstructor ()
        {
            var array = new PtrArray<TestOpaque> ();
        }

        [Test]
        public void TestAdd ()
        {
            var array = new PtrArray<TestOpaque> ();
            array.Add (new TestOpaque (0));
        }
    }
}
