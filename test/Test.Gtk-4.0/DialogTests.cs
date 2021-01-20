// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class DialogTests : Tests
    {
        [Test]
        public void DialogFlagsGType()
        {
            var gtype = GType.Of<DialogFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkDialogFlags"));
        }

        [Test]
        public void ResponseTypeGType()
        {
            var gtype = GType.Of<ResponseType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkResponseType"));
        }
    }
}
