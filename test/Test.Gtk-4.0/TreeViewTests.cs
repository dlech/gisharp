// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class TreeViewTests
    {
        [Test]
        public void TreeViewDropPositionGType()
        {
            var gtype = typeof(TreeViewDropPosition).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkTreeViewDropPosition"));
        }

        [Test]
        public void TreeViewGridLinesGType()
        {
            var gtype = typeof(TreeViewGridLines).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkTreeViewGridLines"));
        }
    }
}
