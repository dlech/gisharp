using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using GISharp.GLib;
using GISharp.Runtime;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class VariantTests
    {
        [SetUp]
        public void SetUp ()
        {
            // Work around NUnit bug/feature.
            // NUnit tries to enumerate any IEnumerable for informational
            // purposes (NUnit.Framework.Constraints.MsgUtils), but Variant
            // will throw an exception if it is not a container. This causes
            // tests to fail unexpectedly. So, we add a value formatter for
            // Variant so that it does not try to use the built-in IEnumerable.
            TestContext.AddFormatter<Variant> (v => ((Variant)v).Print (true));
        }

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

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCompareTo ()
        {
            var one = new Variant (1);
            var two = new Variant (2);
            var otherOne = new Variant ((short)1);

            Assert.That (one, Is.Not.LessThan (one));
            Assert.That (one, Is.LessThan (two));
            Assert.That (one, Is.LessThanOrEqualTo (one));
            Assert.That (one, Is.LessThanOrEqualTo (two));
            Assert.That (one, Is.Not.GreaterThan (one));
            Assert.That (one, Is.Not.GreaterThan (two));
            Assert.That (one, Is.GreaterThanOrEqualTo (one));
            Assert.That (one, Is.Not.GreaterThanOrEqualTo (two));

            Assert.That (one < two, Is.True);
            Assert.That (one <= two, Is.True);
            Assert.That (one > two, Is.False);
            Assert.That (one >= two, Is.False);

            // types must match
            Assert.That (() => one.CompareTo (otherOne),
                Throws.InvalidOperationException);

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastBoolean ()
        {
            var expected = true;
            var variant = (Variant)expected;
            var actual = (bool)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastByte ()
        {
            var expected = byte.MaxValue;
            var variant = (Variant)expected;
            var actual = (byte)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastInt16 ()
        {
            var expected = short.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.Int16));
            var actual = (short)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastUInt16 ()
        {
            var expected = ushort.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.UInt16));
            var actual = (ushort)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastInt32 ()
        {
            var expected = int.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.Int32));
            var actual = (int)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastUInt32 ()
        {
            var expected = uint.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.UInt32));
            var actual = (uint)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastInt64 ()
        {
            var expected = long.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.Int64));
            var actual = (long)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastUInt64 ()
        {
            var expected = ulong.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.UInt64));
            var actual = (ulong)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastHandle ()
        {
            var expected = new DBusHandle (int.MaxValue);
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.DBusHandle));
            var actual = (DBusHandle)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastDouble ()
        {
            var expected = double.MaxValue;
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.Double));
            var actual = (double)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastString ()
        {
            var expected = "string";
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.String));
            var actual = (string)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastStringArray ()
        {
            var expected = new[] { "string" };
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.StringArray));
            var actual = (string[])variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastObjectPath ()
        {
            var expected = new DBusObjectPath ("/");
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.DBusObjectPath));
            var actual = (DBusObjectPath)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastObjectPathArray ()
        {
            var expected = new[] { new DBusObjectPath ("/") };
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.DBusObjectPathArray));
            var actual = (DBusObjectPath[])variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastSignature ()
        {
            var expected = new DBusSignature ("i");
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.DBusSignature));
            var actual = (DBusSignature)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastBytestring ()
        {
            var expected = Encoding.ASCII.GetBytes ("bytestring");
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.ByteString));
            var actual = (byte[])variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastBytestringArray ()
        {
            var expected = new[] { Encoding.ASCII.GetBytes ("bytestring") };
            var variant = (Variant)expected;
            Assert.That (variant.Type, Is.EqualTo (VariantType.ByteStringArray));
            var actual = (byte[][])variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastArray ()
        {
            var badArray = new[] { new Variant (false), null };
            Assert.That (() => new Variant (null, badArray), Throws.ArgumentException);
            badArray = new[] { new Variant (false), new Variant (0) };
            Assert.That (() => new Variant (null, badArray), Throws.ArgumentException);
            badArray = new Variant[0];
            Assert.That (() => new Variant (null, badArray), Throws.ArgumentException);
            badArray = null;
            Assert.That (() => new Variant (null, badArray), Throws.ArgumentException);
            Assert.That (() => new Variant (VariantType.Boolean, badArray), Throws.Nothing);

            var expected = new[] { new Variant (false) };
            var variant = new Variant (null, expected);
            Assert.That (variant.Type.IsArray, Is.True);
            var actual = (Variant[])variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastTuple ()
        {
            var badTuple = new[] { new Variant (false), null };
            Assert.That (() => (Variant)badTuple, Throws.ArgumentException);
            badTuple = null;
            Assert.That (() => (Variant)badTuple, Throws.TypeOf<ArgumentNullException> ());

            var expected = new[] { new Variant (false), new Variant (0) };
            var variant = (Variant)expected;
            Assert.That (variant.Type.IsTuple, Is.True);
            var actual = (Variant[])variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCastDictEntry ()
        {
            // null key is not allowed
            var badKey = new KeyValuePair<Variant, Variant> (null, new Variant ("string"));
            Assert.That (() => (Variant)badKey, Throws.TypeOf<ArgumentNullException> ());

            // null value is not allowed
            badKey = new KeyValuePair<Variant, Variant> (new Variant ("string"), null);
            Assert.That (() => (Variant)badKey, Throws.TypeOf<ArgumentNullException> ());

            // only basic variant types are allowed as key
            badKey = new KeyValuePair<Variant, Variant>(new Variant(new Strv("string")), new Variant("string"));
            Assert.That (() => (Variant)badKey, Throws.ArgumentException);

            // make sure we get back what we put in
            var expected = new KeyValuePair<Variant, Variant> (new Variant ("key"), new Variant ("value"));
            var variant = (Variant)expected;
            Assert.That (variant.Type.IsDictionaryEntry, Is.True);
            var actual = (KeyValuePair<Variant, Variant>)variant;
            Assert.That (actual, Is.EqualTo (expected));

            Utility.AssertNoGLibLog();
        }
    }
}
