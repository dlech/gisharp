// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>


using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class OptionContextTests : Tests
    {
        [Test]
        public void TestSummary()
        {
            using var oc = new OptionContext();
            var expected = "summary";
            oc.Summary = expected;
            Assert.That<string?>(oc.Summary, Is.EqualTo(expected));
            oc.Summary = Utf8.Null;
            Assert.That<string?>(oc.Summary, Is.EqualTo(Utf8.Null));
        }

        [Test]
        public void TestDescription()
        {
            using var oc = new OptionContext();
            var expected = "description";
            oc.Description = expected;
            Assert.That<string?>(oc.Description, Is.EqualTo(expected));
            oc.Description = Utf8.Null;
            Assert.That<string?>(oc.Description, Is.EqualTo(Utf8.Null));
        }

        [Test]
        public void TestSetTranslateFunc()
        {
            using var oc = new OptionContext();
            var translate = new TranslateFunc(x => x.ToString().Normalize());
            oc.SetTranslateFunc(translate);
            oc.SetTranslateFunc(null);
        }

        [Test]
        public void TestSetTranslationDomain()
        {
            using var oc = new OptionContext();
            oc.SetTranslationDomain("domain");
        }

        [Test]
        public void TestHelpEnabled()
        {
            using var oc = new OptionContext();
            var expected = true;
            oc.HelpEnabled = expected;
            Assert.That(oc.HelpEnabled, Is.EqualTo(expected));
        }

        [Test]
        public void TestIgnoreUnknownOptions()
        {
            using var oc = new OptionContext();
            var expected = true;
            oc.IgnoreUnknownOptions = expected;
            Assert.That(oc.IgnoreUnknownOptions, Is.EqualTo(expected));
        }

        [Test]
        public void TestStrictPosix()
        {
            using var oc = new OptionContext();
            var expected = true;
            oc.StrictPosix = expected;
            Assert.That(oc.StrictPosix, Is.EqualTo(expected));
        }

        [Test]
        public void TestAddGroup()
        {
            using var og = new OptionGroup("name", "desc", "help");
            using var oc = new OptionContext();
            oc.AddGroup(og);
            Assert.That(() => og.UnsafeHandle, Throws.Nothing);
        }

        [Test]
        public void TestMainGroup()
        {
            using var og = new OptionGroup("name", "desc", "help");
            using var oc = new OptionContext();
            oc.MainGroup = og;
            Assert.That(oc.MainGroup.UnsafeHandle, Is.EqualTo(og.UnsafeHandle));
        }
    }
}
