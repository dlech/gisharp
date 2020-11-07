using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class FontChooserTests : Tests
    {
        [Test]
        public void FontChooserLevelGType()
        {
            var gtype = GType.Of<FontChooserLevel>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkFontChooserLevel"));
        }
    }
}
