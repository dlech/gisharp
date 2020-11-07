using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class FilterTests : Tests
    {
        [Test]
        public void FilterMatchGType()
        {
            var gtype = GType.Of<FilterMatch>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkFilterMatch"));
        }

        [Test]
        public void FilterChangeGType()
        {
            var gtype = GType.Of<FilterChange>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkFilterChange"));
        }
    }
}
