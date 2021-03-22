// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class AccessibleTests
    {
        [Test]
        public void AccessibleAutocompleteGType()
        {
            var gtype = typeof(AccessibleAutocomplete).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleAutocomplete"));
        }

        [Test]
        public void AccessibleInvalidStateGType()
        {
            var gtype = typeof(AccessibleInvalidState).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleInvalidState"));
        }

        [Test]
        public void AccessiblePropertyGType()
        {
            var gtype = typeof(AccessibleProperty).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleProperty"));
        }

        [Test]
        public void AccessibleRelationGType()
        {
            var gtype = typeof(AccessibleRelation).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleRelation"));
        }

        [Test]
        public void AccessibleRoleGType()
        {
            var gtype = typeof(AccessibleRole).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleRole"));
        }

        [Test]
        public void AccessibleSortGType()
        {
            var gtype = typeof(AccessibleSort).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleSort"));
        }

        [Test]
        public void AccessibleStateGType()
        {
            var gtype = typeof(AccessibleState).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleState"));
        }

        [Test]
        public void AccessibleTristateGType()
        {
            var gtype = typeof(AccessibleTristate).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAccessibleTristate"));
        }
    }
}
