// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

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
            var gtype = typeof(BorderStyle).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkBorderStyle"));
        }

        [Test]
        public void StyleContextPrintFlagsGType()
        {
            var gtype = typeof(StyleContextPrintFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkStyleContextPrintFlags"));
        }
    }
}
