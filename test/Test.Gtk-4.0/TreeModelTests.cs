using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class TreeModelTests : Tests
    {
        [Test]
        public void TreeModelFlagsGType()
        {
            var gtype = GType.Of<TreeModelFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTreeModelFlags"));
        }
    }
}
