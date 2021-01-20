// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class WidgetTests : Tests
    {
        [Test]
        public void TextDirectionGType()
        {
            var gtype = GType.Of<TextDirection>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTextDirection"));
        }

        [Test]
        public void PickFlagsGType()
        {
            var gtype = GType.Of<PickFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPickFlags"));
        }

        [Test]
        public void OverflowGType()
        {
            var gtype = GType.Of<Overflow>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkOverflow"));
        }

        [Test]
        public void SizeRequestModeGType()
        {
            var gtype = GType.Of<SizeRequestMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSizeRequestMode"));
        }

        [Test]
        public void AlignGType()
        {
            var gtype = GType.Of<Align>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAlign"));
        }
    }
}
