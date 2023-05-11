// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class IconThemeTests
    {
        [Test]
        public void IconLookupFlagsGType()
        {
            var gtype = typeof(IconLookupFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkIconLookupFlags"));
        }

        [Test]
        public void IconThemeErrorGType()
        {
            var gtype = typeof(IconThemeError).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkIconThemeError"));
        }

        [Test]
        public void IconThemeErrorQuark()
        {
            Assert.That(
                IconThemeError.NotFound.GetGErrorDomain(),
                Is.EqualTo(IconThemeErrorDomain.Quark)
            );
        }
    }
}
