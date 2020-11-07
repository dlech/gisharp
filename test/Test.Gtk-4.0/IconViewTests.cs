using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class IconViewTests : Tests
    {
        [Test]
        public void IconViewDropPositionGType()
        {
            var gtype = GType.Of<IconViewDropPosition>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkIconViewDropPosition"));
        }
    }
}
