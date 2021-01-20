// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class EditableTests : Tests
    {
        [Test]
        public void EditablePropertiesGType()
        {
            var gtype = GType.Of<EditableProperties>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkEditableProperties"));
        }
    }
}
