using System;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core
{
    [TestFixture]
    public class Utf8Tests
    {
        const string testString = "test-string-with-ůŋįçøđê-😀";
        readonly Utf8String testUtf8String = new Utf8String(testString);
        readonly Utf8 testUtf8 = new Utf8(testString);

        [Test]
        public void TestString()
        {
            {
                var utf8 = new UnownedUtf8(testUtf8.Handle, -1);
                Assert.That(utf8.ToString(), Is.EqualTo(testString));
                Assert.That((string)utf8, Is.EqualTo(testString));
                Assert.That(utf8 == testString, Is.True);
                Assert.That(utf8 == default(string?), Is.False);
                Assert.That(utf8 != testString, Is.False);
                Assert.That(utf8 != default(string?), Is.True);
                Assert.That(testString == utf8, Is.True);
                Assert.That(default(string?) == utf8, Is.False);
                Assert.That(testString != utf8, Is.False);
                Assert.That(default(string?) != utf8, Is.True);
            }
            {
                var utf8 = new NullableUnownedUtf8(testUtf8.Handle, -1);
                Assert.That(utf8.ToString(), Is.EqualTo(testString));
                Assert.That((string?)utf8, Is.EqualTo(testString));
                Assert.That(utf8 == testString, Is.True);
                Assert.That(utf8 == default(string?), Is.False);
                Assert.That(utf8 != testString, Is.False);
                Assert.That(utf8 != default(string?), Is.True);
                Assert.That(testString == utf8, Is.True);
                Assert.That(default(string?) == utf8, Is.False);
                Assert.That(testString != utf8, Is.False);
                Assert.That(default(string?) != utf8, Is.True);
            }
            {
                var utf8 = new NullableUnownedUtf8(IntPtr.Zero, 0);
                Assert.That(utf8.ToString(), Is.EqualTo(string.Empty));
                Assert.That((string?)utf8, Is.Null);
                Assert.That(utf8 == testString, Is.False);
                Assert.That(utf8 == default(string?), Is.True);
                Assert.That(utf8 != testString, Is.True);
                Assert.That(utf8 != default(string?), Is.False);
                Assert.That(testString == utf8, Is.False);
                Assert.That(default(string?) == utf8, Is.True);
                Assert.That(testString != utf8, Is.True);
                Assert.That(default(string?) != utf8, Is.False);
            }
            using (var utf8 = new Utf8(testString)) {
                Assert.That(utf8.ToString(), Is.EqualTo(testString));
                Assert.That((string)utf8, Is.EqualTo(testString));
                Assert.That(utf8, Is.EqualTo(testString));
                Assert.That(utf8 == testString, Is.True);
                Assert.That(utf8 == default(string?), Is.False);
                Assert.That(utf8 != testString, Is.False);
                Assert.That(utf8 != default(string?), Is.True);
                Assert.That(testString == utf8, Is.True);
                Assert.That(default(string?) == utf8, Is.False);
                Assert.That(testString != utf8, Is.False);
                Assert.That(default(string?) != utf8, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestUtf8String()
        {
            {
                var utf8 = new UnownedUtf8(testUtf8.Handle, -1);
                Assert.That(utf8.ToUtf8String(), Is.EqualTo(testUtf8String));
                Assert.That((Utf8String)utf8, Is.EqualTo(testUtf8String));
                Assert.That(utf8 == testUtf8String, Is.True);
                Assert.That(utf8 == default(Utf8String?), Is.False);
                Assert.That(utf8 != testUtf8String, Is.False);
                Assert.That(utf8 != default(Utf8String?), Is.True);
                Assert.That(testUtf8String == utf8, Is.True);
                Assert.That(default(Utf8String?) == utf8, Is.False);
                Assert.That(testUtf8String != utf8, Is.False);
                Assert.That(default(Utf8String?) != utf8, Is.True);
            }
            {
                var utf8 = new NullableUnownedUtf8(testUtf8.Handle, -1);
                Assert.That(utf8.ToUtf8String(), Is.EqualTo(testUtf8String));
                Assert.That((Utf8String?)utf8, Is.EqualTo(testUtf8String));
                Assert.That(utf8 == testUtf8String, Is.True);
                Assert.That(utf8 == default(Utf8String?), Is.False);
                Assert.That(utf8 != testUtf8String, Is.False);
                Assert.That(utf8 != default(Utf8String?), Is.True);
                Assert.That(testUtf8String == utf8, Is.True);
                Assert.That(default(Utf8String?) == utf8, Is.False);
                Assert.That(testUtf8String != utf8, Is.False);
                Assert.That(default(Utf8String?) != utf8, Is.True);
            }
            {
                var utf8 = new NullableUnownedUtf8(IntPtr.Zero, 0);
                Assert.That(utf8.ToUtf8String(), Is.EqualTo(Utf8String.Empty));
                Assert.That((Utf8String?)utf8, Is.Null);
                Assert.That(utf8 == testUtf8String, Is.False);
                Assert.That(utf8 == default(Utf8String?), Is.True);
                Assert.That(utf8 != testUtf8String, Is.True);
                Assert.That(utf8 != default(Utf8String?), Is.False);
                Assert.That(testUtf8String == utf8, Is.False);
                Assert.That(default(Utf8String?) == utf8, Is.True);
                Assert.That(testUtf8String != utf8, Is.True);
                Assert.That(default(Utf8String?) != utf8, Is.False);
            }
            using (var utf8 = new Utf8(testUtf8String)) {
                Assert.That(utf8.Length, Is.EqualTo(testUtf8String.Length));
                Assert.That(utf8.ToUtf8String(), Is.EqualTo(testUtf8String));
                Assert.That(utf8 == testUtf8String, Is.True);
                Assert.That(utf8 == default(Utf8String?), Is.False);
                Assert.That(utf8 != testUtf8String, Is.False);
                Assert.That(utf8 != default(Utf8String?), Is.True);
                Assert.That(testUtf8String == utf8, Is.True);
                Assert.That(default(Utf8String?) == utf8, Is.False);
                Assert.That(testUtf8String != utf8, Is.False);
                Assert.That(default(Utf8String?) != utf8, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestBytes()
        {
             using (var utf8 = new Utf8(testString)) {
                Assert.That(utf8.Bytes, Is.EquivalentTo(testUtf8String.Bytes));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestUnichars()
        {
             using (var utf8 = new Utf8(testString)) {
                Assert.That(utf8.Unichars, Is.EquivalentTo(testUtf8String.Runes));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<Utf8>();
            Assert.That(gtype, Is.EqualTo(GType.String));
            AssertNoGLibLog();
        }
    }
}
