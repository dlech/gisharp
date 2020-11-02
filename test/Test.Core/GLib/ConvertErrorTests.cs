using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.Core.GLib
{
    [TestOf(typeof(ConvertError))]
    public class ConvertErrorTests : Tests
    {
        [Test]
        public void TestQuark()
        {
            Assert.That(default(ConvertError).GetGErrorDomain(),
                Is.EqualTo(ConvertErrorDomain.Quark));
        }
    }
}
