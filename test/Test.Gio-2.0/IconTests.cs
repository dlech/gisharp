
using GISharp.Lib.Gio;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class IconTests
    {
        [Test]
        public void TestEverything()
        {
            using (var expected = IIcon.NewForString("file"))
            using (var serialized = expected.Serialize())
            using (var actual = IIcon.Deserialize(serialized)) {
                Assert.That(expected, Is.EqualTo(actual));
            }

            AssertNoGLibLog();
        }
    }
}
