// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class EventControllerTests : Tests
    {
        [Test]
        public void PropagationPhaseGType()
        {
            var gtype = GType.Of<PropagationPhase>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPropagationPhase"));
        }

        [Test]
        public void PropagationLimitGType()
        {
            var gtype = GType.Of<PropagationLimit>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPropagationLimit"));
        }
    }
}
