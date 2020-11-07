using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class TreeViewTests : Tests
    {
        [Test]
        public void TreeViewDropPositionGType()
        {
            var gtype = GType.Of<TreeViewDropPosition>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTreeViewDropPosition"));
        }

        [Test]
        public void TreeViewGridLinesGType()
        {
            var gtype = GType.Of<TreeViewGridLines>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkTreeViewGridLines"));
        }
    }
}
