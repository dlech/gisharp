using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class SettingsTests : Tests
    {
        [Test]
        public void SystemSettingGType()
        {
            var gtype = GType.Of<SystemSetting>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSystemSetting"));
        }
    }
}