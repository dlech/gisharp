// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.CompilerServices;
using System.Text;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class UnicharTests
    {
        [Test]
        public unsafe void TestValidate()
        {
            var c = new Rune(' ');
            Assert.That(c.Validate(), Is.True);

            // fun way to get an invalid Rune since the constructor does the
            // same validation we are tying to check
            Unsafe.Write(Unsafe.AsPointer(ref c), -1); // c = new Rune(-1)
            Assert.That(c.Validate(), Is.False);
        }

        [Test]
        public void TestIsAlNum()
        {
            var c = new Rune(' ');
            Assert.That(c.IsAlphaNumeric(), Is.False);
            c = new Rune('0');
            Assert.That(c.IsAlphaNumeric(), Is.True);
        }

        [Test]
        public void TestIsAlpha()
        {
            var c = new Rune('A');
            Assert.That(c.IsAlpha(), Is.True);
            c = new Rune('0');
            Assert.That(c.IsAlpha(), Is.False);
        }

        [Test]
        public void TestIsCntrl()
        {
            var c = new Rune(0x000A); // line feed
            Assert.That(c.IsControl(), Is.True);
            c = new Rune('0');
            Assert.That(c.IsControl(), Is.False);
        }

        [Test]
        public void TestIsDefined()
        {
            var c = new Rune(0x70000); // plane 7 is unassigned
            Assert.That(c.IsDefined(), Is.False);
            c = new Rune('0');
            Assert.That(c.IsDefined(), Is.True);
        }

        [Test]
        public void TestIsDigit()
        {
            var c = new Rune('A');
            Assert.That(c.IsDigit(), Is.False);
            c = new Rune('0');
            Assert.That(c.IsDigit(), Is.True);
        }

        [Test]
        public void TestIsGraph()
        {
            var c = new Rune(' ');
            Assert.That(c.IsGraph(), Is.False);
            c = new Rune('0');
            Assert.That(c.IsGraph(), Is.True);
        }

        [Test]
        public void TestIsLower()
        {
            var c = new Rune('A');
            Assert.That(c.IsLower(), Is.False);
            c = new Rune('a');
            Assert.That(c.IsLower(), Is.True);
        }

        [Test]
        public void TestIsMark()
        {
            var c = new Rune('A');
            Assert.That(c.IsMark(), Is.False);
            c = new Rune(0x0300); // COMBINING GRAVE ACCENT
            Assert.That(c.IsMark(), Is.True);
        }

        [Test]
        public void TestIsPrint()
        {
            var c = new Rune(' ');
            Assert.That(c.IsPrintable(), Is.True);
            c = new Rune(0x000A); // line feed
            Assert.That(c.IsPrintable(), Is.False);
        }

        [Test]
        public void TestIsPunct()
        {
            var c = new Rune(' ');
            Assert.That(c.IsPunctuation(), Is.False);
            c = new Rune('!');
            Assert.That(c.IsPunctuation(), Is.True);
        }

        [Test]
        public void TestIsSpace()
        {
            var c = new Rune(' ');
            Assert.That(c.IsSpace(), Is.True);
            c = new Rune('!');
            Assert.That(c.IsSpace(), Is.False);
        }

        [Test]
        public void TestIsTitle()
        {
            var c = new Rune('ǅ');
            Assert.That(c.IsTitle(), Is.True);
            c = new Rune('A');
            Assert.That(c.IsTitle(), Is.False);
        }

        [Test]
        public void TestIsUpper()
        {
            var c = new Rune('a');
            Assert.That(c.IsUpper(), Is.False);
            c = new Rune('A');
            Assert.That(c.IsUpper(), Is.True);
        }

        [Test]
        public void TestIsXDigit()
        {
            var c = new Rune('a');
            Assert.That(c.IsHexDigit(), Is.True);
            c = new Rune('g');
            Assert.That(c.IsHexDigit(), Is.False);
        }

        [Test]
        public void TestIsWide()
        {
            var c = new Rune('a');
            Assert.That(c.IsWide(), Is.False);
            c = new Rune('ᄀ');
            Assert.That(c.IsWide(), Is.True);
        }

        [Test]
        public void TestIsWideCjk()
        {
            var c = new Rune('a');
            Assert.That(c.IsWideCjk(), Is.False);
            c = new Rune('ᄀ');
            Assert.That(c.IsWideCjk(), Is.True);
        }

        [Test]
        public void TestIsZeroWidth()
        {
            var c = new Rune('a');
            Assert.That(c.IsZeroWidth(), Is.False);
            c = new Rune(0x0300); // COMBINING GRAVE ACCENT
            Assert.That(c.IsZeroWidth(), Is.True);
        }

        [Test]
        public void TestToUpper()
        {
            var c = new Rune('a');
            Assert.That(c.ToUpper(), Is.EqualTo(new Rune('A')));
        }

        [Test]
        public void TestToLower()
        {
            var c = new Rune('A');
            Assert.That(c.ToLower(), Is.EqualTo(new Rune('a')));
        }

        [Test]
        public void TestToTitle()
        {
            var c = new Rune('a');
            Assert.That(c.ToTitle(), Is.EqualTo(new Rune('A')));
        }

        [Test]
        public void TestDigitValue()
        {
            var c = new Rune('a');
            Assert.That(c.DigitValue(), Is.EqualTo(-1));
            c = new Rune('9');
            Assert.That(c.DigitValue(), Is.EqualTo(9));
        }

        [Test]
        public void TestXDigitValue()
        {
            var c = new Rune('a');
            Assert.That(c.HexDigitValue(), Is.EqualTo(0x000A));
            c = new Rune('g');
            Assert.That(c.HexDigitValue(), Is.EqualTo(-1));
        }

        [Test]
        public void TestCompose()
        {
            var a = new Rune('a');
            var b = new Rune(0x0300); // COMBINING GRAVE ACCENT
            Assert.That(a.TryCompose(b, out var c), Is.True);
            Assert.That(c, Is.EqualTo(new Rune('à')));
        }

        [Test]
        public void TestDecompose()
        {
            var c = new Rune('à');
            Assert.That(c.TryDecompose(out var a, out var b), Is.True);
            Assert.That(a, Is.EqualTo(new Rune('a')));
            Assert.That(b, Is.EqualTo(new Rune(0x0300))); // COMBINING GRAVE ACCENT
        }

        [Test]
        public void TestFullyDecompose()
        {
            var a = new Rune('a');
            var b = new Rune(0x0300); // COMBINING GRAVE ACCENT
            var c = new Rune('à');
            Assert.That(c.FullyDecompose().ToArray(),
                Is.EquivalentTo(new Rune[] { a, b }));
        }

        [Test]
        public void TestType()
        {
            var c = new Rune('a');
            Assert.That(c.Type(), Is.EqualTo(UnicodeType.LowercaseLetter));
        }

        [Test]
        public void TestBreakType()
        {
            var c = new Rune('a');
            Assert.That(c.BreakType(), Is.EqualTo(UnicodeBreakType.Alphabetic));
        }

        [Test]
        public void TestCombineingClass()
        {
            var c = new Rune(0x0300); // COMBINING GRAVE ACCENT
            Assert.That(c.CombiningClass(), Is.EqualTo(230));
        }

        [Test]
        public void TestGetMirrorChar()
        {
            var c = new Rune('(');
            Assert.That(c.TryGetMirrorChar(out var m), Is.True);
            Assert.That(m, Is.EqualTo(new Rune(')')));
        }

        [Test]
        public void TestGetScript()
        {
            var c = new Rune('a');
            Assert.That(c.GetScript(), Is.EqualTo(UnicodeScript.Latin));
        }

        [Test]
        public void TestToUtf8()
        {
            var c = new Rune('a');
            Assert.That<string>(c.ToUtf8(), Is.EqualTo("a"));
        }
    }
}
