// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ConstraintTests
    {
        [Test]
        public void ConstraintAttributeGType()
        {
            var gtype = typeof(ConstraintAttribute).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkConstraintAttribute"));
        }

        [Test]
        public void ConstraintRelationGType()
        {
            var gtype = typeof(ConstraintRelation).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkConstraintRelation"));
        }

        [Test]
        public void ConstraintStrengthGType()
        {
            var gtype = typeof(ConstraintStrength).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkConstraintStrength"));
        }
    }
}
