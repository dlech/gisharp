// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class MessageDialogTests
    {
        [Test]
        public void MessageTypeGType()
        {
            var gtype = typeof(MessageType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkMessageType"));
        }

        [Test]
        public void ButtonsTypeGType()
        {
            var gtype = typeof(ButtonsType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkButtonsType"));
        }
    }
}
