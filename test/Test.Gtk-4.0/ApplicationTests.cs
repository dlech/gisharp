// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ApplicationTests
    {
        [Test]
        public void ApplicationInhibitFlagsGType()
        {
            var gtype = typeof(ApplicationInhibitFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkApplicationInhibitFlags"));
        }
    }
}
