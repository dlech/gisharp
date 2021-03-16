// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

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
            var gtype = typeof(PropagationPhase).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPropagationPhase"));
        }

        [Test]
        public void PropagationLimitGType()
        {
            var gtype = typeof(PropagationLimit).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPropagationLimit"));
        }
    }
}
