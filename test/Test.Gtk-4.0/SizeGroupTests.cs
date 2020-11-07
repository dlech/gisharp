using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class SizeGroupTests : Tests
    {
        [Test]
        public void SizeGroupModeGType()
        {
            var gtype = GType.Of<SizeGroupMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSizeGroupMode"));
        }
    }
}
