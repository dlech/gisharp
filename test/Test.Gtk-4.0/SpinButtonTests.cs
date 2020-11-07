using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class SpinButtonTests : Tests
    {
        [Test]
        public void SpinButtonUpdatePolicyGType()
        {
            var gtype = GType.Of<SpinButtonUpdatePolicy>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSpinButtonUpdatePolicy"));
        }

        [Test]
        public void SpinTypeGType()
        {
            var gtype = GType.Of<SpinType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkSpinType"));
        }
    }
}
