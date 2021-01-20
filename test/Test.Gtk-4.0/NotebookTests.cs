// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class NotebookTests : Tests
    {
        [Test]
        public void NotebookTabGType()
        {
            var gtype = GType.Of<NotebookTab>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkNotebookTab"));
        }
    }
}
