using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.GLib
{
    [TestFixture]
    public class TimeZoneTests
    {
        [Test]
        public void TestNew()
        {
            using (var tz = new TimeZone(Utf8.Null)) {
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewOffset()
        {
            using (var tz = new TimeZone(0)) {
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetLocal()
        {
            using (var tz = TimeZone.Local) {
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetUtc()
        {
            using (var tz = TimeZone.Utc) {
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetIdentifier()
        {
            using (var tz = new TimeZone(null)) {
                Assert.That<string>(tz.Identifier, Is.Not.Null);
            }
            using (var tz = new TimeZone("Z")) {
                Assert.That<string>(tz.Identifier, Is.EqualTo("Z"));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestFindInterval()
        {
            using (var tz = new TimeZone(Utf8.Null)) {
                Assert.That(tz.FindInterval(TimeType.Universal, 1), Is.GreaterThan(0));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestAdjustTime()
        {
            using (var tz = new TimeZone(Utf8.Null)) {
                Assert.That(tz.AdjustTime(TimeType.Universal, 1), Is.GreaterThan(0));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetAbbreviation()
        {
            using (var tz = new TimeZone(Utf8.Null)) {
                Assert.That<string>(tz.GetAbbreviation(1), Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetOffset()
        {
            using (var tz = TimeZone.Utc) {
                Assert.That(tz.GetOffset(0), Is.Zero);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGIsDst()
        {
            using (var tz = TimeZone.Utc) {
                Assert.That(tz.IsDst(0), Is.False);
            }
            AssertNoGLibLog();
        }
    }
}