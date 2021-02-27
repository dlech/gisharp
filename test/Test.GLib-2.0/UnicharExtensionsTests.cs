// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class UnicharExtensionsTests : Tests
    {
        [Test]
        public void TestValidate()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.Validate(), Is.True);
            c = new Unichar(-1); // invalid
            Assert.That(c.Validate(), Is.False);
        }

        [Test]
        public void TestIsAlNum()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsAlphaNumeric(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsAlphaNumeric(), Is.True);
        }

        [Test]
        public void TestIsAlpha()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsAlpha(), Is.True);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsAlpha(), Is.False);
        }

        [Test]
        public void TestIsCntrl()
        {
            var c = new Unichar(0x000A); // line feed
            Assert.That(c.IsControl(), Is.True);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsControl(), Is.False);
        }

        [Test]
        public void TestIsDefined()
        {
            var c = new Unichar(-1); // invalid
            Assert.That(c.IsDefined(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsDefined(), Is.True);
        }

        [Test]
        public void TestIsDigit()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsDigit(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsDigit(), Is.True);
        }

        [Test]
        public void TestIsGraph()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsGraph(), Is.False);
            c = new Unichar(0x0030); // 0
            Assert.That(c.IsGraph(), Is.True);
        }

        [Test]
        public void TestIsLower()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsLower(), Is.False);
            c = new Unichar(0x0061); // a
            Assert.That(c.IsLower(), Is.True);
        }

        [Test]
        public void TestIsMark()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.IsMark(), Is.False);
            c = new Unichar(0x0300); // `
            Assert.That(c.IsMark(), Is.True);
        }

        [Test]
        public void TestIsPrint()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsPrintable(), Is.True);
            c = new Unichar(0x000A); // line feed
            Assert.That(c.IsPrintable(), Is.False);
        }

        [Test]
        public void TestIsPunct()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsPunctuation(), Is.False);
            c = new Unichar(0x0021); // !
            Assert.That(c.IsPunctuation(), Is.True);
        }

        [Test]
        public void TestIsSpace()
        {
            var c = new Unichar(0x0020); // space
            Assert.That(c.IsSpace(), Is.True);
            c = new Unichar(0x0021); // !
            Assert.That(c.IsSpace(), Is.False);
        }

        [Test]
        public void TestIsTitle()
        {
            var c = new Unichar(0x001C5); // ǅ
            Assert.That(c.IsTitle(), Is.True);
            c = new Unichar(0x0041); // A
            Assert.That(c.IsTitle(), Is.False);
        }

        [Test]
        public void TestIsUpper()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsUpper(), Is.False);
            c = new Unichar(0x0041); // A
            Assert.That(c.IsUpper(), Is.True);
        }

        [Test]
        public void TestIsXDigit()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsHexDigit(), Is.True);
            c = new Unichar(0x0067); // g
            Assert.That(c.IsHexDigit(), Is.False);
        }

        [Test]
        public void TestIsWide()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsWide(), Is.False);
            c = new Unichar(0x1100); // ᄀ
            Assert.That(c.IsWide(), Is.True);
        }

        [Test]
        public void TestIsWideCjk()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsWideCjk(), Is.False);
            c = new Unichar(0x1100); // ᄀ
            Assert.That(c.IsWideCjk(), Is.True);
        }

        [Test]
        public void TestIsZeroWidth()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.IsZeroWidth(), Is.False);
            c = new Unichar(0x0300); // `
            Assert.That(c.IsZeroWidth(), Is.True);
        }

        [Test]
        public void TestToUpper()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.ToUpper(), Is.EqualTo(new Unichar(0x0041))); // A
        }

        [Test]
        public void TestToLower()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.ToLower(), Is.EqualTo(new Unichar(0x0061))); // a
        }

        [Test]
        public void TestToTitle()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.ToTitle(), Is.EqualTo(new Unichar(0x0041))); // A
        }

        [Test]
        public void TestDigitValue()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.DigitValue(), Is.EqualTo(-1));
            c = new Unichar(0x0039); // 9
            Assert.That(c.DigitValue(), Is.EqualTo(9));
        }

        [Test]
        public void TestXDigitValue()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.HexDigitValue(), Is.EqualTo(0x000A));
            c = new Unichar(0x0067); // g
            Assert.That(c.HexDigitValue(), Is.EqualTo(-1));
        }

        [Test]
        public void TestCompose()
        {
            var a = new Unichar(0x0061); // a
            var b = new Unichar(0x0300); // `
            Assert.That(a.TryCompose(b, out var c), Is.True);
            Assert.That(c, Is.EqualTo(new Unichar(0x00E0))); // à
        }

        [Test]
        public void TestDecompose()
        {
            var c = new Unichar(0x00E0); // à
            Assert.That(c.TryDecompose(out var a, out var b), Is.True);
            Assert.That(a, Is.EqualTo(new Unichar(0x0061))); // a
            Assert.That(b, Is.EqualTo(new Unichar(0x0300))); // `
        }

        [Test]
        public void TestFullyDecompose()
        {
            var a = new Unichar(0x0061); // a
            var b = new Unichar(0x0300); // `
            var c = new Unichar(0x00E0); // à
            Assert.That(c.FullyDecompose().ToArray(),
                Is.EquivalentTo(new Unichar[] { a, b }));
        }

        [Test]
        public void TestType()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.Type(), Is.EqualTo(UnicodeType.LowercaseLetter));
        }

        [Test]
        public void TestBreakType()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.BreakType(), Is.EqualTo(UnicodeBreakType.Alphabetic));
        }

        [Test]
        public void TestCombineingClass()
        {
            var c = new Unichar(0x0300); // `
            Assert.That(c.CombiningClass(), Is.EqualTo(230));
        }

        [Test]
        public void TestGetMirrorChar()
        {
            var c = new Unichar(0x0028); // (
            Assert.That(c.TryGetMirrorChar(out var m), Is.True);
            Assert.That(m, Is.EqualTo(new Unichar(0x0029))); // )
        }

        [Test]
        public void TestGetScript()
        {
            var c = new Unichar(0x0061); // a
            Assert.That(c.GetScript(), Is.EqualTo(UnicodeScript.Latin));
        }

        [Test]
        public void TestToUtf8()
        {
            var c = new Unichar(0x0061); // a
            Assert.That<string>(c.ToUtf8(), Is.EqualTo("a"));
        }
    }
}
