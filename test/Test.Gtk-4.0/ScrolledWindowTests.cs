// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ScrolledWindowTests : Tests
    {
        [Test]
        public void PolicyTypeGType()
        {
            var gtype = GType.Of<PolicyType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPolicyType"));
        }

        [Test]
        public void CornerTypeGType()
        {
            var gtype = GType.Of<CornerType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkCornerType"));
        }
    }
}
