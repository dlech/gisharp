// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

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
            var gtype = GType.Of<PageOrientation>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPageOrientation"));
        }

        [Test]
        public void PrintDuplexGType()
        {
            var gtype = GType.Of<PrintDuplex>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPrintDuplex"));
        }

        [Test]
        public void PrintQualityGType()
        {
            var gtype = GType.Of<PrintQuality>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPrintQuality"));
        }

        [Test]
        public void NumberUpLayoutGType()
        {
            var gtype = GType.Of<NumberUpLayout>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkNumberUpLayout"));
        }

        [Test]
        public void PrintPagesGType()
        {
            var gtype = GType.Of<PrintPages>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPrintPages"));
        }

        [Test]
        public void PageSetGType()
        {
            var gtype = GType.Of<PageSet>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPageSet"));
        }
    }
}
