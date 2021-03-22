// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class SpinButtonTests
    {
        [Test]
        public void SpinButtonUpdatePolicyGType()
        {
            var gtype = typeof(SpinButtonUpdatePolicy).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSpinButtonUpdatePolicy"));
        }

        [Test]
        public void SpinTypeGType()
        {
            var gtype = typeof(SpinType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSpinType"));
        }
    }
}
