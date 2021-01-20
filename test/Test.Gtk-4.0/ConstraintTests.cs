// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ConstraintTests : Tests
    {
        [Test]
        public void ConstraintAttributeGType()
        {
            var gtype = GType.Of<ConstraintAttribute>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkConstraintAttribute"));
        }

        [Test]
        public void ConstraintRelationGType()
        {
            var gtype = GType.Of<ConstraintRelation>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkConstraintRelation"));
        }

        [Test]
        public void ConstraintStrengthGType()
        {
            var gtype = GType.Of<ConstraintStrength>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkConstraintStrength"));
        }
    }
}
