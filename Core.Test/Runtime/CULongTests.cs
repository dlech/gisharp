using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Core.Runtime
{
    [TestFixture]
    public class CULongTests
    {
        [Test]
        public void TestMinValue()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || IntPtr.Size == 4) {
                Assert.That(CLong.MinValue, Is.EqualTo(uint.MinValue));
            }
            else {
                Assert.That(CULong.MinValue, Is.EqualTo(ulong.MinValue));
            }
        }

        [Test]
        public void TestMaxValue()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || IntPtr.Size == 4) {
                Assert.That(CULong.MaxValue, Is.EqualTo(uint.MaxValue));
            }
            else {
                Assert.That(CULong.MaxValue, Is.EqualTo(ulong.MaxValue));
            }
        }
    }
}