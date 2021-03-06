// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class QuarkTests
    {
        const string testQuarkPrefix = "gisharp-glib-test-quark-";

        [Test]
        public void TestExplicitUintOperator()
        {
            uint expected = 1;
            var quark = (Quark)expected;
            var actual = (uint)quark;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestFromString()
        {
            Quark actual;

            // null always returns 0
            actual = Quark.FromString(Utf8.Null);
            Assert.That(actual, Is.EqualTo(default(Quark)));

            // this creates a new quark if it does not exist
            actual = Quark.FromString(testQuarkPrefix + "test-from-string");
            Assert.That(actual, Is.Not.EqualTo(default(Quark)));
        }

        [Test]
        public void TestToString()
        {
            string? actual;

            // null always returns 0
            actual = default(Quark).ToString();
            Assert.That(actual, Is.Null);

            // undefined quark creates new
            var quarkString = testQuarkPrefix + "test-to-string";
            Assume.That(Quark.TryString(quarkString), Is.EqualTo(default(Quark)));
            var quark = Quark.FromString(quarkString);
            Assume.That(quark, Is.Not.EqualTo(default(Quark)));
            actual = quark.ToString();
            Assert.That(actual, Is.EqualTo(quarkString));
        }

        [Test]
        public void TestTryString()
        {
            Quark actual;
            var quarkString = testQuarkPrefix + "test-try-string";

            // null always returns 0
            actual = Quark.TryString(Utf8.Null);
            Assert.That(actual, Is.EqualTo(default(Quark)));

            // undefined quark returns 0
            actual = Quark.TryString(quarkString);
            Assert.That(actual, Is.EqualTo(default(Quark)));

            // defined quark returns value
            var quark = Quark.FromString(quarkString);
            actual = Quark.TryString(quarkString);
            Assert.That(actual, Is.EqualTo(quark));
        }

        [Test]
        public void TestExplicitStringOperator()
        {
            const string str = "test-explicit-operator-quark";
            Assert.That(() => (Quark)str, Throws.TypeOf<InvalidCastException>());

            Assert.That((Quark)null, Is.EqualTo(Quark.Zero));
        }
    }
}
