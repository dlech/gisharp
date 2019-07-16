using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    [TestFixture]
    [TestOf(typeof(OptionError))]
    public class OptionErrorTests
    {
        [Test]
        public void TestQuark()
        {
            Assert.That(default(OptionError).GetGErrorDomain(), Is.EqualTo(OptionErrorDomain.Quark));
        }
    }
}