// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class EnumTests : Tests
    {
        [Test]
        public void BaselinePositionGType()
        {
            var gtype = typeof(BaselinePosition).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkBaselinePosition"));
        }

        [Test]
        public void DeleteTypeGType()
        {
            var gtype = typeof(DeleteType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkDeleteType"));
        }

        [Test]
        public void DirectionTypeGType()
        {
            var gtype = typeof(DirectionType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkDirectionType"));
        }

        [Test]
        public void JustificationGType()
        {
            var gtype = typeof(Justification).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkJustification"));
        }

        [Test]
        public void MovementStepGType()
        {
            var gtype = typeof(MovementStep).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkMovementStep"));
        }

        [Test]
        public void OrderingGType()
        {
            var gtype = typeof(Ordering).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkOrdering"));
        }

        [Test]
        public void OrientationGType()
        {
            var gtype = typeof(Orientation).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkOrientation"));
        }

        [Test]
        public void PackTypeGType()
        {
            var gtype = typeof(PackType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPackType"));
        }

        [Test]
        public void PositionTypeGType()
        {
            var gtype = typeof(PositionType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPositionType"));
        }

        [Test]
        public void ScrollStepGType()
        {
            var gtype = typeof(ScrollStep).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkScrollStep"));
        }

        [Test]
        public void ScrollTypeGType()
        {
            var gtype = typeof(ScrollType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkScrollType"));
        }

        [Test]
        public void SelectionModeGType()
        {
            var gtype = typeof(SelectionMode).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSelectionMode"));
        }

        [Test]
        public void StateFlagsGType()
        {
            var gtype = typeof(StateFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkStateFlags"));
        }

        [Test]
        public void SortTypeGType()
        {
            var gtype = typeof(SortType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkSortType"));
        }

        [Test]
        public void IconSizeGType()
        {
            var gtype = typeof(IconSize).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkIconSize"));
        }
    }
}
