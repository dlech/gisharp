using NUnit.Framework;
using System;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture ()]
    public class VariantTests
    {
        [Test]
        public void TestEquals ()
        {
            var trueVariant1 = new Variant (true);
            var trueVariant2 = new Variant (true);
            var falseVariant = new Variant (false);

            Assert.That (trueVariant1, Is.EqualTo (trueVariant2));
            Assert.That (trueVariant1, Is.Not.EqualTo (falseVariant));
            Assert.That (trueVariant1 == trueVariant2, Is.True);
            Assert.That (trueVariant1 != trueVariant2, Is.False);
            Assert.That (trueVariant1 == falseVariant, Is.False);
            Assert.That (trueVariant1 != falseVariant, Is.True);

            Assert.That (trueVariant1, Is.Not.EqualTo ((Variant)null));
            Assert.That ((Variant)null, Is.Not.EqualTo (trueVariant1));
            Assert.That ((Variant)null, Is.EqualTo ((Variant)null));
            Assert.That (trueVariant1 == null, Is.False);
            Assert.That (trueVariant1 != null, Is.True);
            Assert.That (null == trueVariant1, Is.False);
            Assert.That (null != trueVariant1, Is.True);
        }

        [Test]
        public void TestCompareTo ()
        {
            var one = new Variant (1);
            var otherOne = new Variant ((short)1);
            var two = new Variant (2);

            Assert.That (one, Is.Not.LessThan (one));
            Assert.That (one, Is.LessThan (two));
            Assert.That (one, Is.LessThanOrEqualTo (one));
            Assert.That (one, Is.LessThanOrEqualTo (two));
            Assert.That (one, Is.Not.GreaterThan (one));
            Assert.That (one, Is.Not.GreaterThan (two));
            Assert.That (one, Is.GreaterThanOrEqualTo (one));
            Assert.That (one, Is.Not.GreaterThanOrEqualTo (two));

            Assert.That (one < otherOne, Is.False);
            Assert.That (one <= otherOne, Is.True);
            Assert.That (one > otherOne, Is.False);
            Assert.That (one >= otherOne, Is.True);

            Assert.That (one < two, Is.True);
            Assert.That (one <= two, Is.True);
            Assert.That (one > two, Is.False);
            Assert.That (one >= two, Is.False);
        }

        [Test]
        public void TestCastBoolean ()
        {
            var expected = true;
            var variant = (Variant)expected;
            var actual = (bool)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastByte ()
        {
            var expected = byte.MaxValue;
            var variant = (Variant)expected;
            var actual = (byte)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastInt16 ()
        {
            var expected = short.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.Int16));
            var actual = (short)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastUInt16 ()
        {
            var expected = ushort.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.UInt16));
            var actual = (ushort)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastInt32 ()
        {
            var expected = int.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.Int32));
            var actual = (int)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastUInt32 ()
        {
            var expected = uint.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.UInt32));
            var actual = (uint)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastInt64 ()
        {
            var expected = long.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.Int64));
            var actual = (long)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastUInt64 ()
        {
            var expected = ulong.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.UInt64));
            var actual = (ulong)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastHandle ()
        {
            var expected = new DBusHandle (int.MaxValue);
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.DBusHandle));
            var actual = (DBusHandle)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastDouble ()
        {
            var expected = double.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.Double));
            var actual = (double)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastString ()
        {
            var expected = "string";
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.String));
            var actual = (string)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastObjectPath ()
        {
            var expected = new DBusObjectPath ("/");
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.ObjectPath));
            var actual = (DBusObjectPath)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCastSignature ()
        {
            var expected = new DBusSignature ("i");
            var variant = (Variant)expected;
            Assert.That (variant.VariantType, Is.EqualTo (VariantType.DBusSignature));
            var actual = (DBusSignature)variant;
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestCase ()
        {
            var v = new Variant (true);
            Assert.That (v.VariantType, Is.EqualTo (VariantType.Boolean));
        }
    }
}
