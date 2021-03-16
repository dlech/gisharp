// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class EventControllerScrollTests : Tests
    {
        [Test]
        public void EventControllerScrollFlagsGType()
        {
            var gtype = typeof(EventControllerScrollFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkEventControllerScrollFlags"));
        }
    }
}
