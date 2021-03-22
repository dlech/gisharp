// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ComboBoxTests
    {
        [Test]
        public void SensitivityTypeGType()
        {
            var gtype = typeof(SensitivityType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSensitivityType"));
        }
    }
}
