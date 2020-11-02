using NUnit.Framework;

using GISharp.Lib.GLib;

namespace GISharp.Test.GLib
{
    [TestOf(typeof(VariantBuilder))]
    public class VariantBuilderTests : Tests
    {
        [Test]
        public void TestNew()
        {
            var vb = new VariantBuilder(VariantType.Variant);
            vb.Dispose();

            Assert.That(() => new VariantBuilder(VariantType.Boolean), Throws.ArgumentException);
        }

        [Test]
        public void TestAddValue()
        {
            using (var vb = new VariantBuilder(VariantType.Variant))
            using (var value = new Variant(0)) {
                vb.Add(value);
            }
        }

        [Test]
        public void TestEnd()
        {
            using (var vb = new VariantBuilder(VariantType.Variant))
            using (var value = new Variant(0)) {
                // it is an error to call End() with an improperly constructed variant
                // so whe have to add a value first
                vb.Add(value);

                Assert.That(vb.End().Type, Is.EqualTo(VariantType.Variant));
            }
        }
    }
}
