// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class GeneralTests
    {
        [Test]
        public void DebugFlagsGType()
        {
            var gtype = typeof(DebugFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkDebugFlags"));
        }
    }
}
