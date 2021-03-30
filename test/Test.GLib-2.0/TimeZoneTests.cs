// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using NUnit.Framework;

using TimeZone = GISharp.Lib.GLib.TimeZone;

namespace GISharp.Test.GLib
{
    public class TimeZoneTests
    {
        [Test]
        [Obsolete("g_time_zone_new() is deprecated upstream")]
        public void TestNew()
        {
            using var tz = new TimeZone(Utf8.Null);
        }

        [Test]
        public void TestNewOffset()
        {
            using var tz = new TimeZone(0);
        }

        [Test]
        public void TestGetLocal()
        {
            using var tz = TimeZone.Local;
        }

        [Test]
        public void TestGetUtc()
        {
            using var tz = TimeZone.Utc;
        }

        [Test]
        [Obsolete("g_time_zone_new() is deprecated upstream")]
        public void TestGetIdentifier()
        {
            using (var tz = new TimeZone(null)) {
                Assert.That<string>(tz.Identifier, Is.Not.Null);
            }
            using (var tz = new TimeZone("Z")) {
                Assert.That<string>(tz.Identifier, Is.EqualTo("Z"));
            }
        }

        [Test]
        [Obsolete("g_time_zone_new() is deprecated upstream")]
        public void TestFindInterval()
        {
            using var tz = new TimeZone(Utf8.Null);
            Assert.That(tz.FindInterval(TimeType.Universal, 1), Is.GreaterThan(0));
        }

        [Test]
        [Obsolete("g_time_zone_new() is deprecated upstream")]
        public void TestAdjustTime()
        {
            using var tz = new TimeZone(Utf8.Null);
            long time = 1;
            Assert.That(tz.AdjustTime(TimeType.Universal, ref time), Is.GreaterThan(0));
        }

        [Test]
        [Obsolete("g_time_zone_new() is deprecated upstream")]
        public void TestGetAbbreviation()
        {
            using var tz = new TimeZone(Utf8.Null);
            Assert.That<string>(tz.GetAbbreviation(1), Is.Not.Null);
        }

        [Test]
        public void TestGetOffset()
        {
            using var tz = TimeZone.Utc;
            Assert.That(tz.GetOffset(0), Is.Zero);
        }

        [Test]
        public void TestGIsDst()
        {
            using var tz = TimeZone.Utc;
            Assert.That(tz.IsDst(0), Is.False);
        }
    }
}
