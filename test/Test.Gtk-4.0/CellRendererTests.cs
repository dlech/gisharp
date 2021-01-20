// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class CellRendererTests : Tests
    {
        [Test]
        public void CellRendererStateGType()
        {
            var gtype = GType.Of<CellRendererState>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkCellRendererState"));
        }

        [Test]
        public void CellRendererModeGType()
        {
            var gtype = GType.Of<CellRendererMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkCellRendererMode"));
        }
    }
}
