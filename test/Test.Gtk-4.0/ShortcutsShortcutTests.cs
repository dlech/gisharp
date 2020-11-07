using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ShortcutsShortcutTests : Tests
    {
        [Test]
        public void ShortcutTypeGType()
        {
            var gtype = GType.Of<ShortcutType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkShortcutType"));
        }
    }
}
