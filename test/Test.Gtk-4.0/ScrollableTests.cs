using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ScrollableTests : Tests
    {
        [Test]
        public void ScrollablePolicyGType()
        {
            var gtype = GType.Of<ScrollablePolicy>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkScrollablePolicy"));
        }
    }
}
