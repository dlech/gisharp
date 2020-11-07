using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class CellRendererAccelTests : Tests
    {
        [Test]
        public void CellRendererAccelModeGType()
        {
            var gtype = GType.Of<CellRendererAccelMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkCellRendererAccelMode"));
        }
    }
}
