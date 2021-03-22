// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System.Collections.Generic;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;
using static GISharp.Test.GLib.Helpers;

namespace GISharp.Test.GLib
{
    public class LogWriterTests
    {
        [Test]
        public void TestFormatFields()
        {
            // support for structured logs was added in v2.50
            AssertIgnoreWhenVersionIsLessThan(GLibVersion, "2.50");

            var message = new Dictionary<Utf8, Utf8> {
                { "MESSAGE", "Test message." },
                { "MESSAGE_ID", "47bfe69d2c27ef0b4e06d4df59e6c246" },
                { "CODE_FILE", "LogWriterTest.cs" },
                { "CODE_LINE", "20" },
                { "CODE_FUNC", "TestFormatFields" }
            };

            const string expected = @"^\*\* \(GISharp\.Test:\d+\): DEBUG: \d\d:\d\d:\d\d\.\d\d\d: Test message\.$";
            var actual = LogWriter.FormatFields(LogLevelFlags.Debug, message);
            Assert.That<string>(actual, Does.Match(expected));

            const string expectedColor = @"^\*\* \(GISharp\.Test:\d+\): \e\[1;32mDEBUG\e\[0m: \e\[34m\d\d:\d\d:\d\d\.\d\d\d\e\[0m: Test message\.$";
            var actualColor = LogWriter.FormatFields(LogLevelFlags.Debug, message, useColor: true);
            Assert.That<string>(actualColor, Does.Match(expectedColor));
        }
    }
}
