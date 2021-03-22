// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class TextViewTests
    {
        [Test]
        public void TextViewLayerGType()
        {
            var gtype = typeof(TextViewLayer).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkTextViewLayer"));
        }

        [Test]
        public void TextWindowTypeGType()
        {
            var gtype = typeof(TextWindowType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkTextWindowType"));
        }

        [Test]
        public void TextExtendSelectionGType()
        {
            var gtype = typeof(TextExtendSelection).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkTextExtendSelection"));
        }

        [Test]
        public void WrapModeGType()
        {
            var gtype = typeof(WrapMode).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkWrapMode"));
        }
    }
}
