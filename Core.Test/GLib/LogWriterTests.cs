using System.Collections.Generic;
using GISharp.GLib;
using NUnit.Framework;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class LogWriterTests
    {
        [Test]
        public void TestFormatFields ()
        {
            var message = new Dictionary<string, string> {
                { "MESSAGE", "Test message." },
                { "MESSAGE_ID", "47bfe69d2c27ef0b4e06d4df59e6c246" },
                { "CODE_FILE", "LogWriterTest.cs" },
                { "CODE_LINE", "20" },
                { "CODE_FUNC", "TestFormatFields" }
            };

            const string expected = @"^\*\* \(Core\.Test:\d+\): DEBUG: Test message\.$";
            var actual = LogWriter.FormatFields (LogLevelFlags.Debug, message);
            Assert.That (actual, Is.StringMatching (expected));

            const string expectedColor = @"^\*\* \(Core\.Test:\d+\): \e\[1;32mDEBUG\e\[0m: Test message\.$";
            var actualColor = LogWriter.FormatFields (LogLevelFlags.Debug, message, true);
            Assert.That (actualColor, Is.StringMatching (expectedColor));
        }
    }
}
