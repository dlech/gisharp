using System;

using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

using static GISharp.TestHelpers;

using DateTime = GISharp.Lib.GLib.DateTime;
using TimeZone = GISharp.Lib.GLib.TimeZone;

namespace GISharp.Test.GLib
{
    [TestFixture]
    [TestOf(typeof(DateTime))]
    public class DateTimeTests
    {
        [Test]
        public void TestNewNow()
        {
            using (var dt = DateTime.GetNow(TimeZone.Utc)) {
                Assert.That(dt, Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewNowLocal()
        {
            using (var dt = DateTime.NowLocal) {
                Assert.That(dt, Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewNowUtc()
        {
            using (var dt = DateTime.NowUtc) {
                Assert.That(dt, Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewFromUnixLocal()
        {
            using (var dt = DateTime.FromUnixLocal(0)) {
                Assert.That(dt, Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewFromUnixUtc()
        {
            using (var dt = DateTime.FromUnixUtc(0)) {
                Assert.That(dt, Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewFromTimeValLocal()
        {
            using (var dt = DateTime.FromTimevalLocal(new TimeVal())) {
                Assert.That(dt, Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewFromTimeValUtc()
        {
            using (var dt = DateTime.FromTimevalUtc(new TimeVal())) {
                Assert.That(dt, Is.Not.Null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewFromIso8601()
        {
            using (var dt = DateTime.FromIso8601("2018-03-27T21:43:57Z", null)) {
                Assert.That(dt, Is.Not.Null);
            }
            
            Assert.That(() => DateTime.FromIso8601(Utf8.Null, null),
                Throws.ArgumentNullException);

            AssertNoGLibLog();
        }

        [Test]
        public void TestNew()
        {
            using (var dt = new DateTime(TimeZone.Utc, 1, 1, 1, 0, 0, 0)) {
                Assert.That(dt, Is.Not.Null);
            }
            
            Assert.That(() => new DateTime(null, 1, 1, 1, 0, 0, 0),
                Throws.ArgumentNullException);

            Assert.That(() => new DateTime(TimeZone.Utc, 0, 0, 0, 0, 0, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestNewLocal()
        {
            using (var dt = DateTime.GetLocal(1, 1, 1, 0, 0, 0)) {
                Assert.That(dt, Is.Not.Null);
            }
            
            Assert.That(() => DateTime.GetLocal(0, 0, 0, 0, 0, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestNewUtc()
        {
            using (var dt = DateTime.GetUtc(1, 1, 1, 0, 0, 0)) {
                Assert.That(dt, Is.Not.Null);
            }
            
            Assert.That(() => DateTime.GetUtc(0, 0, 0, 0, 0, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            AssertNoGLibLog();
        }
    }
}
