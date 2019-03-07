using System;
using System.Collections.Generic;
using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

using static GISharp.TestHelpers;

namespace GISharp.Test.GLib
{
    [TestFixture]
    [TestOf(typeof(VariantDict))]
    public class VariantDictTests
    {
        [Test]
        public void TestNew()
        {
            var vd = new VariantDict();
            vd.Dispose();

            using (var badValue = new Variant(0)) {
                Assert.That(() => new VariantDict(badValue), Throws.ArgumentException);
            }

            using (var goodValue = Variant.Parse(VariantType.VariantDictionary, "{'key': <'value'>}")) {
                new VariantDict(goodValue).Dispose();
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestContains()
        {
            using (var init = Variant.Parse(VariantType.VariantDictionary, "{'key': <'value'>}"))
            using (var vd = new VariantDict(init)) {
                Assert.That(vd.Contains("key"), Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestLookupValue()
        {
            using (var init = Variant.Parse(VariantType.VariantDictionary, "{'key': <'value'>}"))
            using (var vd = new VariantDict(init)) {
                // first ChildValues gets first (only) key/value pair in dict
                // second ChildValues gets value from key/value pair
                // third ChildValues unpacks VariantType.Variant to VariantType.String
                var expected = init.ChildValues[0].ChildValues[1].ChildValues[0];
                Assert.That(vd.Lookup("key"), Is.EqualTo(expected));
                Assert.That(vd.Lookup("key", VariantType.String), Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestInsertValue()
        {
            using (var vd = new VariantDict())
            using (var value = new Variant("value")) {
                vd.Insert("key", value);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestRemove()
        {
            using (var init = Variant.Parse(VariantType.VariantDictionary, "{'key': <'value'>}"))
            using (var vd = new VariantDict(init)) {
                Assert.That(vd.Remove("key"), Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestEnd()
        {
            using (var expected = Variant.Parse(VariantType.VariantDictionary, "{'key': <'value'>}"))
            using (var vd = new VariantDict(expected)) {
                var actual = vd.End();
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }
    }
}
