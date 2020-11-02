using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Core.Runtime
{
    public class CLongTests : Tests
    {
        [Test]
        public void TestMinValue()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || IntPtr.Size == 4) {
                Assert.That(CLong.MinValue, Is.EqualTo(int.MinValue));
            }
            else {
                Assert.That(CLong.MinValue, Is.EqualTo(long.MinValue));
            }
        }

        [Test]
        public void TestMaxValue()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || IntPtr.Size == 4) {
                Assert.That(CLong.MaxValue, Is.EqualTo(int.MaxValue));
            }
            else {
                Assert.That(CLong.MaxValue, Is.EqualTo(long.MaxValue));
            }
        }
    }
}
