using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ComboBoxTests : Tests
    {
        [Test]
        public void SensitivityTypeGType()
        {
            var gtype = GType.Of<SensitivityType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSensitivityType"));
        }
    }
}
