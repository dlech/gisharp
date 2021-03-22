// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class Utf8Tests
    {
        const string testString = "test-string-with-ůŋįçøđê-😀";
        readonly byte[] testStringBytes = Encoding.UTF8.GetBytes(testString);
        readonly Rune[] testStringCodePoints = GetCodePoints(testString).ToArray();
        readonly Utf8 testUtf8 = new(testString);

        static IEnumerable<Rune> GetCodePoints(string str)
        {
            for (var i = 0; i < str.Length; i += char.IsSurrogatePair(str, i) ? 2 : 1) {
                yield return new Rune(char.ConvertToUtf32(str, i));
            }
        }

        [Test]
        public void TestString()
        {
            {
                var utf8 = new UnownedUtf8(testUtf8.UnsafeHandle, -1);
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
                var utf8 = new NullableUnownedUtf8(testUtf8.UnsafeHandle, -1);
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
        }

        [Test]
        public void TestBytes()
        {
            using var utf8 = new Utf8(testString);
            Assert.That(utf8.Bytes, Is.EquivalentTo(testStringBytes));
        }

        [Test]
        public void TestUnichars()
        {
            using var utf8 = new Utf8(testString);
            Assert.That(utf8.Characters, Is.EquivalentTo(testStringCodePoints));
        }

        [Test]
        public void TestGType()
        {
            var gtype = typeof(Utf8).ToGType();
            Assert.That(gtype, Is.EqualTo(GType.String));
            Assert.That(gtype.Name, Is.EqualTo("gchararray"));
        }
    }
}
