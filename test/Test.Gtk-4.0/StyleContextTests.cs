// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class StyleContextTests : Tests
    {
        [Test]
        public void BorderStyleGType()
        {
            var gtype = GType.Of<BorderStyle>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkBorderStyle"));
        }

        [Test]
        public void StyleContextPrintFlagsGType()
        {
            var gtype = GType.Of<StyleContextPrintFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkStyleContextPrintFlags"));
        }
    }
}
