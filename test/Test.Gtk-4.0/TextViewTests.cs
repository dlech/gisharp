// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class TextViewTests : Tests
    {
        [Test]
        public void TextViewLayerGType()
        {
            var gtype = GType.Of<TextViewLayer>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTextViewLayer"));
        }

        [Test]
        public void TextWindowTypeGType()
        {
            var gtype = GType.Of<TextWindowType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTextWindowType"));
        }

        [Test]
        public void TextExtendSelectionGType()
        {
            var gtype = GType.Of<TextExtendSelection>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTextExtendSelection"));
        }

        [Test]
        public void WrapModeGType()
        {
            var gtype = GType.Of<WrapMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkWrapMode"));
        }
    }
}
