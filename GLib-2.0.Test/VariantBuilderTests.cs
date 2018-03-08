using System;
using System.Collections.Generic;
using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

using static GISharp.TestHelpers;

namespace GISharp.Test.GLib
{
    [TestFixture]
    [TestOf(typeof(VariantBuilder))]
    public class VariantBuilderTests
    {
        [Test]
        public void TestNew()
        {
            var vb = new VariantBuilder(VariantType.BoxedVariant);
            vb.Dispose();

            Assert.That(() => new VariantBuilder(VariantType.Boolean), Throws.ArgumentException);
            Assert.That(() => new VariantBuilder(null), Throws.ArgumentNullException);

            AssertNoGLibLog();
        }

        [Test]
        public void TestAddValue()
        {
            using (var vb = new VariantBuilder(VariantType.BoxedVariant))
            using (var value = new Variant(0)) {
                vb.Add(value);

                Assert.That(() => vb.Add(null), Throws.ArgumentNullException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestEnd()
        {
            using (var vb = new VariantBuilder(VariantType.BoxedVariant))
            using (var value = new Variant(0)) {
                // it is an error to call End() with an improperly constructed variant
                // so whe have to add a value first
                vb.Add(value);

                Assert.That(vb.End().Type, Is.EqualTo(VariantType.BoxedVariant));
            }
            AssertNoGLibLog();
        }
    }
}
