// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class TimeValTests
    {
        [Test]
        [Obsolete("TryFromIso8601 is deprecated upstream")]
        public void TestFromIso6801()
        {
            Assert.That(TimeVal.TryFromIso8601("1970-01-01T00:00:00Z", out var tv), Is.True);
            Assert.That(tv.Seconds, Is.EqualTo(new CLong(0)));
            Assert.That(tv.Microseconds, Is.EqualTo(new CLong(0)));
        }

        [Test]
        [Obsolete("Add is deprecated upstream")]
        public void TestAdd()
        {
            var tv = default(TimeVal);
            tv.Add(new(1234567890));
            Assert.That(tv.Seconds, Is.EqualTo(new CLong(1234)));
            Assert.That(tv.Microseconds, Is.EqualTo(new CLong(567890)));
        }

        [Test]
        [Obsolete("ToIso8601 is deprecated upstream")]
        public void TestToIso8601()
        {
            var tv = default(TimeVal);
            using var iso8601 = tv.ToIso8601();
            Assert.That<string?>(iso8601!, Is.EqualTo("1970-01-01T00:00:00Z"));
        }
    }
}
