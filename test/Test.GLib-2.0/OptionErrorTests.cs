using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    [TestOf(typeof(OptionError))]
    public class OptionErrorTests : Tests
    {
        [Test]
        public void TestQuark()
        {
            Assert.That(default(OptionError).GetGErrorDomain(), Is.EqualTo(OptionErrorDomain.Quark));
        }
    }
}
