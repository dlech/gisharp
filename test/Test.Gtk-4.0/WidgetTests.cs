// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

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
            var gtype = typeof(TextDirection).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkTextDirection"));
        }

        [Test]
        public void PickFlagsGType()
        {
            var gtype = typeof(PickFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPickFlags"));
        }

        [Test]
        public void OverflowGType()
        {
            var gtype = typeof(Overflow).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkOverflow"));
        }

        [Test]
        public void SizeRequestModeGType()
        {
            var gtype = typeof(SizeRequestMode).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSizeRequestMode"));
        }

        [Test]
        public void AlignGType()
        {
            var gtype = typeof(Align).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAlign"));
        }
    }
}
