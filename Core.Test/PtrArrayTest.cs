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
            var array = new PtrArray<TestWrappedNative> ();
        }

        [Test]
        public void TestAdd ()
        {
            var array = new PtrArray<TestWrappedNative> ();
            array.Add (new TestWrappedNative (0));
        }
    }
}
