using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class EventControllerScrollTests : Tests
    {
        [Test]
        public void EventControllerScrollFlagsGType()
        {
            var gtype = GType.Of<EventControllerScrollFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkEventControllerScrollFlags"));
        }
    }
}
