// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class StringFilterTests : Tests
    {
        [Test]
        public void StringFilterMatchModeGType()
        {
            var gtype = GType.Of<StringFilterMatchMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkStringFilterMatchMode"));
        }
    }
}
