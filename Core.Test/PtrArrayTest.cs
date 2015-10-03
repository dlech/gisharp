using System;

using NUnit.Framework;
using GISharp.Core;

namespace Core.Test
{
    [TestFixture]
    public class PtrArrayTest
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
