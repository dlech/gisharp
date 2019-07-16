using System;
using System.IO;
using NUnit.Framework;
using GISharp.Lib.GLib;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class FilenameTests
    {
        [Test]
        public void TestDisplayBasename()
        {
            var fullPath = Path.GetFullPath("test");
            using (var f = new Filename(fullPath)) {
                using var baseName = f.DisplayBasename;
                Assert.That<string>(baseName, Is.EqualTo(Path.GetFileName(fullPath)));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestDisplayName()
        {
            var fullPath = Path.GetFullPath("test");
            using (var f = new Filename(fullPath)) {
                using var displayName = f.DisplayName;
                Assert.That<string>(displayName, Is.EqualTo(fullPath));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestFromUri()
        {
            Assert.That(() => Filename.FromUri("test"),
                ThrowsGErrorException(ConvertError.BadUri));

            var uri = new Uri(Path.GetFullPath("test"));
            using (var f = Filename.FromUri(uri.ToString())) {
                Assert.That<string>(f, Is.EqualTo(uri.LocalPath));
            }

            using (var f = Filename.FromUri(uri.ToString(), out var hostname)) {
                Assert.That<string>(f, Is.EqualTo(uri.LocalPath));
                Assert.That(hostname, Is.Null);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestToUri()
        {
            using (var f = new Filename("test")) {
                Assert.That(() => f.ToUri(),
                    ThrowsGErrorException(ConvertError.NotAbsolutePath));
            }

            var fullPath = Path.GetFullPath("test");
            using (var f = new Filename(fullPath)) {
                using var uri = f.ToUri();
                Assert.That<string>(uri, Is.EqualTo(new Uri(fullPath)));
            }

            AssertNoGLibLog();
        }
    }
}