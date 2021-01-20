// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class RevealerTests : Tests
    {
        [Test]
        public void RevealerTransitionTypeGType()
        {
            var gtype = GType.Of<RevealerTransitionType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkRevealerTransitionType"));
        }
    }
}
