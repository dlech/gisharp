using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    [TestFixture]
    [TestOf(typeof(KeyFileError))]
    public class KeyFileErrorTests
    {
        [Test]
        public void TestQuark()
        {
            Assert.That(default(KeyFileError).GetGErrorDomain(), Is.EqualTo(KeyFileErrorDomain.Quark));
        }
    }
}