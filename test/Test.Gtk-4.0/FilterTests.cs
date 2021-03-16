// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class FilterTests : Tests
    {
        [Test]
        public void FilterMatchGType()
        {
            var gtype = typeof(FilterMatch).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkFilterMatch"));
        }

        [Test]
        public void FilterChangeGType()
        {
            var gtype = typeof(FilterChange).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkFilterChange"));
        }
    }
}
