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
            using (var tz = new TimeZone(null)) {
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewLocal()
        {
            using (var tz = TimeZone.NewLocal()) {
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewUtc()
        {
            using (var tz = TimeZone.NewUtc()) {
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestFindInterval()
        {
            using (var tz = new TimeZone(null)) {
                Assert.That(tz.FindInterval(TimeType.Universal, 1), Is.GreaterThan(0));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestAdjustTime()
        {
            using (var tz = new TimeZone(null)) {
                Assert.That(tz.AdjustTime(TimeType.Universal, 1), Is.GreaterThan(0));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetAbbreviation()
        {
            using (var tz = new TimeZone(null)) {
                Assert.That(tz.GetAbbreviation(1), Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetOffset()
        {
            using (var tz = TimeZone.NewUtc()) {
                Assert.That(tz.GetOffset(0), Is.Zero);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGIsDst()
        {
            using (var tz = TimeZone.NewUtc()) {
                Assert.That(tz.IsDst(0), Is.False);
            }
            AssertNoGLibLog();
        }
    }
}