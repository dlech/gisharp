// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class DialogTests
    {
        [Test]
        public void DialogFlagsGType()
        {
            var gtype = typeof(DialogFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkDialogFlags"));
        }

        [Test]
        public void ResponseTypeGType()
        {
            var gtype = typeof(ResponseType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkResponseType"));
        }
    }
}
