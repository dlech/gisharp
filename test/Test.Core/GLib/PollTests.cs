using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.Core.GLib
{
    public class PollTests : Tests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(PollFD).GetGType();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GPollFD"));
        }
    }
}
