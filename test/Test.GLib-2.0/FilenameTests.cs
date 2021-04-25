// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

using System;
using System.IO;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;
using static GISharp.TestHelpers;

namespace GISharp.Test.GLib
{
    public class FilenameTests
    {
        [Test]
        public void TestDisplayBasename()
        {
            var fullPath = Path.GetFullPath("test");
            using var f = (Filename)fullPath;
            using var baseName = f.DisplayBasename();
            Assert.That<string>(baseName, Is.EqualTo(Path.GetFileName(fullPath)));
        }

        [Test]
        public void TestDisplayName()
        {
            var fullPath = Path.GetFullPath("test");
            using var f = (Filename)fullPath;
            using var displayName = f.DisplayName();
            Assert.That<string>(displayName, Is.EqualTo(fullPath));
        }

        [Test]
        public void TestFromUri()
        {
            Assert.That(() => FilenameExtensions.FromUri("test"),
                ThrowsGErrorException(ConvertError.BadUri));

            var uri = new Uri(Path.GetFullPath("test"));
            using (var f = FilenameExtensions.FromUri(uri.ToString())) {
                Assert.That(f.ToString(), Is.EqualTo(uri.LocalPath));
            }

            using (var f = FilenameExtensions.FromUri(uri.ToString(), out var hostname)) {
                Assert.That(f.ToString(), Is.EqualTo(uri.LocalPath));
                Assert.That(hostname, Is.Null);
            }
        }

        [Test]
        public void TestToUri()
        {
            using (var f = (Filename)"test") {
                Assert.That(() => f.ToUri(),
                    ThrowsGErrorException(ConvertError.NotAbsolutePath));
            }

            var fullPath = Path.GetFullPath("test");
            using (var f = (Filename)fullPath) {
                using var uri = f.ToUri();
                Assert.That<string>(uri, Is.EqualTo(new Uri(fullPath)));
            }
        }
    }
}
