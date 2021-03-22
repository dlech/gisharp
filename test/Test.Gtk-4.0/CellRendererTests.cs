// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class CellRendererTests
    {
        [Test]
        public void CellRendererStateGType()
        {
            var gtype = typeof(CellRendererState).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkCellRendererState"));
        }

        [Test]
        public void CellRendererModeGType()
        {
            var gtype = typeof(CellRendererMode).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkCellRendererMode"));
        }
    }
}
