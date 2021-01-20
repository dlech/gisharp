// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class AccessibleTests : Tests
    {
        [Test]
        public void AccessibleAutocompleteGType()
        {
            var gtype = GType.Of<AccessibleAutocomplete>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleAutocomplete"));
        }

        [Test]
        public void AccessibleInvalidStateGType()
        {
            var gtype = GType.Of<AccessibleInvalidState>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleInvalidState"));
        }

        [Test]
        public void AccessiblePropertyGType()
        {
            var gtype = GType.Of<AccessibleProperty>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleProperty"));
        }

        [Test]
        public void AccessibleRelationGType()
        {
            var gtype = GType.Of<AccessibleRelation>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleRelation"));
        }

        [Test]
        public void AccessibleRoleGType()
        {
            var gtype = GType.Of<AccessibleRole>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleRole"));
        }

        [Test]
        public void AccessibleSortGType()
        {
            var gtype = GType.Of<AccessibleSort>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleSort"));
        }

        [Test]
        public void AccessibleStateGType()
        {
            var gtype = GType.Of<AccessibleState>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleState"));
        }

        [Test]
        public void AccessibleTristateGType()
        {
            var gtype = GType.Of<AccessibleTristate>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAccessibleTristate"));
        }
    }
}
