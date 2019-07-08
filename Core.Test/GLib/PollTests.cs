using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class PollTests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(PollFD).GetGType();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GPollFD"));

            AssertNoGLibLog();
        }
    }
}
