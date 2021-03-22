// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class SorterTests
    {
        [Test]
        public void SorterOrderGType()
        {
            var gtype = typeof(SorterOrder).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSorterOrder"));
        }

        [Test]
        public void SorterChangeGType()
        {
            var gtype = typeof(SorterChange).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSorterChange"));
        }
    }
}
