// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class PrintSettingsTests : Tests
    {
        [Test]
        public void PageOrientationGType()
        {
            var gtype = typeof(PageOrientation).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPageOrientation"));
        }

        [Test]
        public void PrintDuplexGType()
        {
            var gtype = typeof(PrintDuplex).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintDuplex"));
        }

        [Test]
        public void PrintQualityGType()
        {
            var gtype = typeof(PrintQuality).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintQuality"));
        }

        [Test]
        public void NumberUpLayoutGType()
        {
            var gtype = typeof(NumberUpLayout).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkNumberUpLayout"));
        }

        [Test]
        public void PrintPagesGType()
        {
            var gtype = typeof(PrintPages).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintPages"));
        }

        [Test]
        public void PageSetGType()
        {
            var gtype = typeof(PageSet).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPageSet"));
        }
    }
}
