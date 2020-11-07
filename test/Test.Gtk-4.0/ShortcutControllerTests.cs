using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ShortcutControllerTests : Tests
    {
        [Test]
        public void ShortcutScopeGType()
        {
            var gtype = GType.Of<ShortcutScope>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkShortcutScope"));
        }
    }
}
