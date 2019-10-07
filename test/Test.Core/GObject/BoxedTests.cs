
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GObject
{
    [TestFixture]
    public class BoxedTests
    {
        [Test]
        public void TestBoxingManagedType()
        {
            var expected = new object();
            using (var b = new Boxed<object>(expected)) {
                Assert.That(b.Value, Is.EqualTo(expected));
            }
            using (var b = new Boxed<object?>(null)) {
                Assert.That(b.Value, Is.Null);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestGType()
        {
            var gtype = GType.TypeOf<Boxed>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GBoxed"));

            gtype = GType.TypeOf<Boxed<object>>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GISharp-Lib-GObject-Boxed--of--1System-Object"));

            AssertNoGLibLog();
        }
    }
}
