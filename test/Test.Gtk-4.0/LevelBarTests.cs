using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class LevelBarTests : Tests
    {
        [Test]
        public void LevelBarModeGType()
        {
            var gtype = GType.Of<LevelBarMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkLevelBarMode"));
        }
    }
}