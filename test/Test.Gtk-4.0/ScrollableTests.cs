// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ScrollableTests
    {
        [Test]
        public void ScrollablePolicyGType()
        {
            var gtype = typeof(ScrollablePolicy).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkScrollablePolicy"));
        }
    }
}
