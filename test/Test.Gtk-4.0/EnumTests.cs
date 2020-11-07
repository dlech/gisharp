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
            var gtype = GType.Of<BaselinePosition>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkBaselinePosition"));
        }

        [Test]
        public void DeleteTypeGType()
        {
            var gtype = GType.Of<DeleteType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkDeleteType"));
        }

        [Test]
        public void DirectionTypeGType()
        {
            var gtype = GType.Of<DirectionType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkDirectionType"));
        }

        [Test]
        public void JustificationGType()
        {
            var gtype = GType.Of<Justification>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkJustification"));
        }

        [Test]
        public void MovementStepGType()
        {
            var gtype = GType.Of<MovementStep>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkMovementStep"));
        }

        [Test]
        public void OrderingGType()
        {
            var gtype = GType.Of<Ordering>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkOrdering"));
        }

        [Test]
        public void OrientationGType()
        {
            var gtype = GType.Of<Orientation>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkOrientation"));
        }

        [Test]
        public void PackTypeGType()
        {
            var gtype = GType.Of<PackType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPackType"));
        }

        [Test]
        public void PositionTypeGType()
        {
            var gtype = GType.Of<PositionType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPositionType"));
        }

        [Test]
        public void ScrollStepGType()
        {
            var gtype = GType.Of<ScrollStep>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkScrollStep"));
        }

        [Test]
        public void ScrollTypeGType()
        {
            var gtype = GType.Of<ScrollType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkScrollType"));
        }

        [Test]
        public void SelectionModeGType()
        {
            var gtype = GType.Of<SelectionMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSelectionMode"));
        }

        [Test]
        public void StateFlagsGType()
        {
            var gtype = GType.Of<StateFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkStateFlags"));
        }

        [Test]
        public void SortTypeGType()
        {
            var gtype = GType.Of<SortType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSortType"));
        }

        [Test]
        public void IconSizeGType()
        {
            var gtype = GType.Of<IconSize>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkIconSize"));
        }
    }
}
