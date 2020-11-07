using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class MenuButtonTests : Tests
    {
        [Test]
        public void ArrowTypeGType()
        {
            var gtype = GType.Of<ArrowType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkArrowType"));
        }
    }
}
