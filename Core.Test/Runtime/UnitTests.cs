using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Core.Runtime
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void TestEquals()
        {
            Assert.That(Unit.Default.Equals(Unit.Default));
            Assert.That(Unit.Default, Is.EqualTo(Unit.Default));
            Assert.That(Unit.Default, Is.EqualTo(default(Unit)));
            Assert.That((object)Unit.Default, Is.EqualTo(Unit.Default));
            Assert.That(Unit.Default, Is.Not.EqualTo(null));
        }

        [Test]
        public void TestEqualityOperator()
        {
            Assert.That(Unit.Default == Unit.Default, Is.True);
            Assert.That(Unit.Default == null, Is.False);
        }

        [Test]
        public void TestInequalityOperator()
        {
            Assert.That(Unit.Default != Unit.Default, Is.False);
            Assert.That(Unit.Default != null, Is.True);
        }
    }
}