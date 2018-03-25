using System.Linq;
using GISharp.Lib.Gio;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class ThemedIconTests
    {
        [Test]
        public void TestNew()
        {
            using (var icon = new ThemedIcon("name")) {
                Assert.That(icon.Names.Single(), IsEqualToUtf8("name"));
                Assert.That(icon.UseDefaultFallbacks, Is.False);
            }
        }

        [Test]
        public void TestNewFromNames()
        {
            Assert.That(() => new ThemedIcon((string[])null), Throws.ArgumentNullException);
            Assert.That(() => new ThemedIcon(), Throws.ArgumentException);
            using (var icon = new ThemedIcon("name1", "name2")) {
                Assert.That(icon.Names.First(), IsEqualToUtf8("name1"));
                Assert.That(icon.Names.Last(), IsEqualToUtf8("name2"));
                Assert.That(icon.UseDefaultFallbacks, Is.False);
            }
        }

        [Test]
        public void TestNewWithDefaultFallbacks()
        {
            using (var icon = new ThemedIcon("name-one-two", true)) {
                Assert.That(icon.Names.First(), IsEqualToUtf8("name-one-two"));
                Assert.That(icon.Names.Last(), IsEqualToUtf8("name"));
                Assert.That(icon.UseDefaultFallbacks, Is.True);
            }
        }
    }
}
