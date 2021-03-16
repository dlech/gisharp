// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

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
            var gtype = typeof(EntryIconPosition).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkEntryIconPosition"));
        }

        [Test]
        public void InputPurposeGType()
        {
            var gtype = typeof(InputPurpose).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkInputPurpose"));
        }

        [Test]
        public void InputHintsGType()
        {
            var gtype = typeof(InputHints).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkInputHints"));
        }
    }
}
