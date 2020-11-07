using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ImageTests : Tests
    {
        [Test]
        public void ImageTypeGType()
        {
            var gtype = GType.Of<ImageType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkImageType"));
        }
    }
}
