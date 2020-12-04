using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ApplicationTests : Tests
    {
        [Test]
        public void ApplicationInhibitFlagsGType()
        {
            var gtype = GType.Of<ApplicationInhibitFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkApplicationInhibitFlags"));
        }
    }
}