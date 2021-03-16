// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

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
            var gtype = typeof(PolicyType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPolicyType"));
        }

        [Test]
        public void CornerTypeGType()
        {
            var gtype = typeof(CornerType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkCornerType"));
        }
    }
}
