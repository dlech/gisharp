using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core
{
    [TestFixture]
    public class UnicharExtensionsTests
    {
        [Test]
        public void TestValidate()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.Validate(), Is.True);
            c = new Unichar(-1); // invalid
            Assert.That(c.Validate(), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsAlNum()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsAlphaNumeric(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsAlphaNumeric(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsAlpha()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsAlpha(), Is.True);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsAlpha(), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsCntrl()
        {
            var c = new Unichar(0x000A); // line feed
            Assert.That(c.IsControl(), Is.True);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsControl(), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsDefined()
        {
            var c = new Unichar(-1); // invalid
            Assert.That(c.IsDefined(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsDefined(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsDigit()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsDigit(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsDigit(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsGraph()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsGraph(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsGraph(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsLower()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsLower(), Is.False);
            c = new Unichar(0x0061); // a
            Assert.That(c.IsLower(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsMark()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsMark(), Is.False);
            c = new Unichar(0x0300); // `
            Assert.That(c.IsMark(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsPrint()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsPrintable(), Is.True);
            c = new Unichar(0x000A); // line feed
            Assert.That(c.IsPrintable(), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsPunct()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsPunctuation(), Is.False);
            c = new Unichar(0x0021); // !
            Assert.That(c.IsPunctuation(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsSpace()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsSpace(), Is.True);
            c = new Unichar(0x0021); // !
            Assert.That(c.IsSpace(), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsTitle()
        {
            var c = new Unichar(0x001C5); // ǅ
            Assert.That(c.IsTitle(), Is.True);
            c = new Unichar(0x0041); // A
            Assert.That(c.IsTitle(), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsUpper()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsUpper(), Is.False);
            c = new Unichar(0x0041); // A
            Assert.That(c.IsUpper(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsXDigit()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsHexDigit(), Is.True);
            c = new Unichar(0x0067); // g
            Assert.That(c.IsHexDigit(), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsWide()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsWide(), Is.False);
            c = new Unichar(0x1100); // ᄀ
            Assert.That(c.IsWide(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsWideCjk()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsWideCjk(), Is.False);
            c = new Unichar(0x1100); // ᄀ
            Assert.That(c.IsWideCjk(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestIsZeroWidth()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsZeroWidth(), Is.False);
            c = new Unichar(0x0300); // `
            Assert.That(c.IsZeroWidth(), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestToUpper()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.ToUpper(), Is.EqualTo(new Unichar(0x0041))); // A
            AssertNoGLibLog();
        }

        [Test]
        public void TestToLower()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.ToLower(), Is.EqualTo(new Unichar(0x0061))); // a
            AssertNoGLibLog();
        }

        [Test]
        public void TestToTitle()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.ToTitle(), Is.EqualTo(new Unichar(0x0041))); // A
            AssertNoGLibLog();
        }

        [Test]
        public void TestDigitValue()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.DigitValue(), Is.EqualTo(-1));
            c = new Unichar(0x0039); // 9
            Assert.That(c.DigitValue(), Is.EqualTo(9));
            AssertNoGLibLog();
        }

        [Test]
        public void TestXDigitValue()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.HexDigitValue(), Is.EqualTo(0x000A));
            c = new Unichar(0x0067); // g
            Assert.That(c.HexDigitValue(), Is.EqualTo(-1));
            AssertNoGLibLog();
        }

        [Test]
        public void TestCompose()
        {
            var a = new Unichar(0x0061); // a
            var b = new Unichar(0x0300); // `
            Assert.That(a.TryCompose(b, out var c), Is.True);
            Assert.That(c, Is.EqualTo(new Unichar(0x00E0))); // à
            AssertNoGLibLog();
        }

        [Test]
        public void TestDecompose()
        {
            var c = new Unichar(0x00E0); // à
            Assert.That(c.TryDecompose(out var a, out var b), Is.True);
            Assert.That(a, Is.EqualTo(new Unichar(0x0061))); // a
            Assert.That(b, Is.EqualTo(new Unichar(0x0300))); // `
            AssertNoGLibLog();
        }

        [Test]
        public void TestFullyDecompose()
        {
            var a = new Unichar(0x0061); // a
            var b = new Unichar(0x0300); // `
            var c = new Unichar(0x00E0); // à
            Assert.That(c.FullyDecompose().ToArray(),
                Is.EquivalentTo(new Unichar[] { a, b }));
            AssertNoGLibLog();
        }

        [Test]
        public void TestType()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.Type(), Is.EqualTo(UnicodeType.LowercaseLetter));
            AssertNoGLibLog();
        }

        [Test]
        public void TestBreakType()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.BreakType(), Is.EqualTo(UnicodeBreakType.Alphabetic));
            AssertNoGLibLog();
        }

        [Test]
        public void TestCombineingClass()
        {
            var c = new Unichar(0x0300); // `
            Assert.That(c.CombiningClass(), Is.EqualTo(230));
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetMirrorChar()
        {
            var c = new Unichar(0x0028); // (
            Assert.That(c.TryGetMirrorChar(out var m), Is.True);
            Assert.That(m, Is.EqualTo(new Unichar(0x0029))); // )
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetScript()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.GetScript(), Is.EqualTo(UnicodeScript.Latin));
            AssertNoGLibLog();
        }

        [Test]
        public void TestToUtf8()
        {
            var c = new Unichar(0x0061); // a
            Assert.That<string>(c.ToUtf8(), Is.EqualTo("a"));
            AssertNoGLibLog();
        }
    }
}
