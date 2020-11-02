using System.Linq;
using GISharp.Lib.Gio;
using NUnit.Framework;

namespace GISharp.Test.Gio
{
    public class ThemedIconTests : Tests
    {
        [Test]
        public void TestNew()
        {
            using (var icon = new ThemedIcon("name")) {
                Assert.That<string>(icon.Names.First(), Is.EqualTo("name"));
                Assert.That(icon.UseDefaultFallbacks, Is.False);
            }
        }

        [Test]
        public void TestNewFromNames()
        {
            Assert.That(() => new ThemedIcon(), Throws.ArgumentException);
            using (var icon = new ThemedIcon("name1", "name2")) {
                Assert.That<string>(icon.Names.First(), Is.EqualTo("name1"));
                Assert.That<string>(icon.Names.Last(), Is.EqualTo("name2").Or.EqualTo("name2-symbolic"));
                Assert.That(icon.UseDefaultFallbacks, Is.False);
            }
        }

        [Test]
        public void TestNewWithDefaultFallbacks()
        {
            using (var icon = new ThemedIcon("name-one-two", true)) {
                Assert.That<string>(icon.Names.First(), Is.EqualTo("name-one-two"));
                Assert.That<string>(icon.Names.Last(), Is.EqualTo("name").Or.EqualTo("name-symbolic"));
                Assert.That(icon.UseDefaultFallbacks, Is.True);
            }
        }
    }
}
