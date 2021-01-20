// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class TreeViewColumnTests : Tests
    {
        [Test]
        public void TreeViewColumnSizingGType()
        {
            var gtype = GType.Of<TreeViewColumnSizing>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTreeViewColumnSizing"));
        }
    }
}
