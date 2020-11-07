using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class PanGestureTests : Tests
    {
        [Test]
        public void PanDirectionGType()
        {
            var gtype = GType.Of<PanDirection>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPanDirection"));
        }
    }
}
