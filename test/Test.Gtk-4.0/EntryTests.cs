// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class EntryTests : Tests
    {
        [Test]
        public void EntryIconPositionGType()
        {
            var gtype = GType.Of<EntryIconPosition>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkEntryIconPosition"));
        }

        [Test]
        public void InputPurposeGType()
        {
            var gtype = GType.Of<InputPurpose>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkInputPurpose"));
        }

        [Test]
        public void InputHintsGType()
        {
            var gtype = GType.Of<InputHints>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkInputHints"));
        }
    }
}
