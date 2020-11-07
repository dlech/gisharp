using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class FileChooserTests : Tests
    {
        [Test]
        public void FileChooserActionGType()
        {
            var gtype = GType.Of<FileChooserAction>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkFileChooserAction"));
        }

        [Test]
        public void FileChooserErrorGType()
        {
            var gtype = GType.Of<FileChooserError>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkFileChooserError"));
        }

        [Test]
        public void BuilderErrorQuark()
        {
            Assert.That(FileChooserError.Nonexistent.GetGErrorDomain(),
                Is.EqualTo(FileChooserErrorDomain.Quark));
        }
    }
}
