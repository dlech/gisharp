// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class PadControllerTests : Tests
    {
        [Test]
        public void PadActionTypeGType()
        {
            var gtype = GType.Of<PadActionType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPadActionType"));
        }
    }
}
