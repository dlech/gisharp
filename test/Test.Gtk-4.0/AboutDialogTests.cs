using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class AboutDialogTests : Tests
    {
        [Test]
        public void LicenseGType()
        {
            var gtype = GType.Of<License>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkLicense"));
        }
    }
}
