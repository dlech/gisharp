using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class MessageDialogTests : Tests
    {
        [Test]
        public void MessageTypeGType()
        {
            var gtype = GType.Of<MessageType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkMessageType"));
        }

        [Test]
        public void ButtonsTypeGType()
        {
            var gtype = GType.Of<ButtonsType>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkButtonsType"));
        }
    }
}
