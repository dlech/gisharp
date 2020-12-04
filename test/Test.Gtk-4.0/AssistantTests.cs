using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class AssistantTests : Tests
    {
        [Test]
        public void AssistantPageTypeGtype()
        {
            var gtype = GType.Of<AssistantPageType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkAssistantPageType"));
        }
    }
}