using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Core.Runtime
{
    [TestFixture]
    public class VoidTests
    {
        [Test]
        public void TestEquals()
        {
            Assert.That(Void.Default.Equals(Void.Default));
            Assert.That(Void.Default, Is.EqualTo(Void.Default));
            Assert.That(Void.Default, Is.EqualTo(default(Void)));
            Assert.That(Equals(Void.Default, Void.Default));
            Assert.That(Void.Default, Is.Not.EqualTo(null));
        }

        [Test]
        public void TestEqualityOperator()
        {
            Assert.That(Void.Default == Void.Default, Is.True);
            Assert.That(Void.Default == null, Is.False);
        }

        [Test]
        public void TestInequalityOperator()
        {
            Assert.That(Void.Default != Void.Default, Is.False);
            Assert.That(Void.Default != null, Is.True);
        }
    }
}