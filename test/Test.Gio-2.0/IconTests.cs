
using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class IconTests
    {
        [Test]
        public void TestEverything()
        {
            using (var expected = Icon.NewForString("file"))
            using (var serialized = expected.Serialize())
            using (var actual = Icon.Deserialize(serialized)) {
                Assert.That(expected, Is.EqualTo(actual));
            }

            AssertNoGLibLog();
        }
    }
}
