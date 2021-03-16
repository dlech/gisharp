// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class VersionTests : Tests
    {
        [Test]
        public void TestVersion()
        {
            Assert.That(Version.RunTimeVersion, Is.EqualTo(Version.CompileTimeVersion));
        }

        [Test]
        public void TestBinaryAge()
        {
            Assert.That(Version.RunTimeBinaryAge, Is.EqualTo(Version.CompileTimeBinaryAge));
        }

        [Test]
        public void TestInterfaceAge()
        {
            Assert.That(Version.RunTimeInterfaceAge, Is.EqualTo(Version.CompileTimeInterfaceAge));
        }

        [Test]
        public void TestCheck()
        {
            Assert.That<string?>(Version.Check(5, 0, 0), Is.EqualTo("GTK version too old (major mismatch)"));
        }
    }
}
