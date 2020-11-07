using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class GestureTests : Tests
    {
        [Test]
        public void EventSequenceStateGType()
        {
            var gtype = GType.Of<EventSequenceState>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkEventSequenceState"));
        }
    }
}
