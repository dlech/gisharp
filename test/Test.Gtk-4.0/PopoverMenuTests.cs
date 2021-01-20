// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class PopoverMenuTests : Tests
    {
        [Test]
        public void PopoverMenuFlagsGType()
        {
            var gtype = GType.Of<PopoverMenuFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPopoverMenuFlags"));
        }
    }
}
