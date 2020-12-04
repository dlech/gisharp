using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ScrolledWindowTests : Tests
    {
        [Test]
        public void PolicyTypeGType()
        {
            var gtype = GType.Of<PolicyType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPolicyType"));
        }

        [Test]
        public void CornerTypeGType()
        {
            var gtype = GType.Of<CornerType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkCornerType"));
        }
    }
}