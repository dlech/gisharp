// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class StringFilterTests
    {
        [Test]
        public void StringFilterMatchModeGType()
        {
            var gtype = typeof(StringFilterMatchMode).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkStringFilterMatchMode"));
        }
    }
}
