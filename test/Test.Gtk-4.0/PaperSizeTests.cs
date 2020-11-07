using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class PaperSizeTests : Tests
    {
        [Test]
        public void UnitGType()
        {
            var gtype = GType.Of<Unit>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkUnit"));
        }
    }
}
