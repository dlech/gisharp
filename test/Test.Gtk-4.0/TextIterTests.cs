using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class TextIterTests : Tests
    {
        [Test]
        public void TextSearchFlagsGType()
        {
            var gtype = GType.Of<TextSearchFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTextSearchFlags"));
        }
    }
}
