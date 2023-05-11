// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class Utf8ExtensionsTests
    {
        [Test]
        public void TestCaseFold()
        {
            using var utf8 = new Utf8("Test");
            using var actual = utf8.CaseFold();
            Assert.That(actual, Is.EqualTo("test"));
        }

        [Test]
        public void TestCaseSubstring()
        {
            using var utf8 = new Utf8("Test");
            using var s1 = utf8.Substring(0, 4);
            Assert.That(s1, Is.EqualTo("Test"));
            using var s2 = utf8.Substring(1, 3);
            Assert.That(s2, Is.EqualTo("es"));

            Assert.That(
                () => utf8.Substring(-1, 4),
                Throws
                    .TypeOf<ArgumentOutOfRangeException>()
                    .With.Property("ParamName")
                    .EqualTo("startPos")
            );
            Assert.That(
                () => utf8.Substring(5, 4),
                Throws
                    .TypeOf<ArgumentOutOfRangeException>()
                    .With.Property("ParamName")
                    .EqualTo("startPos")
            );
            Assert.That(
                () => utf8.Substring(0, -1),
                Throws
                    .TypeOf<ArgumentOutOfRangeException>()
                    .With.Property("ParamName")
                    .EqualTo("endPos")
            );
            Assert.That(
                () => utf8.Substring(0, 5),
                Throws
                    .TypeOf<ArgumentOutOfRangeException>()
                    .With.Property("ParamName")
                    .EqualTo("endPos")
            );
            Assert.That(() => utf8.Substring(3, 2), Throws.ArgumentException);
        }
    }
}
