// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class StackTests : Tests
    {
        [Test]
        public void StackTransitionTypeGType()
        {
            var gtype = GType.Of<StackTransitionType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkStackTransitionType"));
        }
    }
}
