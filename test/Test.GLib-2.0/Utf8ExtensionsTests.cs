using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.GLib
{
    [TestFixture]
    public class Utf8ExtensionsTests
    {
        [Test]
        public void TestCaseFold()
        {
            using (var utf8 = new Utf8("Test")) {
                using var actual = utf8.CaseFold();
                Assert.That(actual, Is.EqualTo("test"));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCaseSubstring()
        {
            using (var utf8 = new Utf8("Test")) {
                using var s1 = utf8.Substring(1, 3);
                Assert.That(s1, Is.EqualTo("es"));

                // TODO: test out of  range indexes
            }
            AssertNoGLibLog();
        }
    }
}
