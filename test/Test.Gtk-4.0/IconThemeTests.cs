using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class IconThemeTests : Tests
    {
        [Test]
        public void IconLookupFlagsGType()
        {
            var gtype = GType.Of<IconLookupFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkIconLookupFlags"));
        }

        [Test]
        public void IconThemeErrorGType()
        {
            var gtype = GType.Of<IconThemeError>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkIconThemeError"));
        }

        [Test]
        public void IconThemeErrorQuark()
        {
            Assert.That(IconThemeError.NotFound.GetGErrorDomain(),
                Is.EqualTo(IconThemeErrorDomain.Quark));
        }
    }
}
