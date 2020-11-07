using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class SorterTests : Tests
    {
        [Test]
        public void SorterOrderGType()
        {
            var gtype = GType.Of<SorterOrder>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSorterOrder"));
        }

        [Test]
        public void SorterChangeGType()
        {
            var gtype = GType.Of<SorterChange>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSorterChange"));
        }
    }
}
