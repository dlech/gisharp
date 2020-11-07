using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class StringFilterTests : Tests
    {
        [Test]
        public void StringFilterMatchModeGType()
        {
            var gtype = GType.Of<StringFilterMatchMode>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkStringFilterMatchMode"));
        }
    }
}
