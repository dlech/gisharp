using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ShortcutActionTests : Tests
    {
        [Test]
        public void ShortcutActionFlagsGType()
        {
            var gtype = GType.Of<ShortcutActionFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkShortcutActionFlags"));
        }
    }
}