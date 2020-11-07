using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class GeneralTests : Tests
    {
        [Test]
        public void DebugFlagsGType()
        {
            var gtype = GType.Of<DebugFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkDebugFlags"));
        }
    }
}
