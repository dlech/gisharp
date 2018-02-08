﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using GISharp.GLib;
using GISharp.Runtime;
using System.Runtime.InteropServices;
using System.Reflection;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class VariantTests : IListTests<PtrArray<Variant>, Variant>
    {
        public VariantTests() : base(getItemAt, (Variant)0, (Variant)1, (Variant)2, (Variant)3, (Variant)4)
        {
        }

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
        public void TestCtor()
        {
            // make sure we got the floating reference thing right
            using (var v = new Variant(false)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((byte)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((short)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((ushort)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((int)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((uint)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((long)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((ulong)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant(new DBusHandle())) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((double)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((Utf8)"")) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant("")) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant(new DBusObjectPath("/"))) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant(new DBusSignature("i"))) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant((Variant)0)) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant(new Strv(""))) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant(new DBusObjectPath[0])) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant(new byte[0])) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
            using (var v = new Variant(new byte[0][])) {
                Assert.That(GetIsFloating(v), Is.False);
                Assert.That(GetRefCount(v), Is.EqualTo(1));
            }
        }

        [Test]
        public void TestEquals ()
        {
            using (var trueVariant1 = new Variant (true))
            using (var trueVariant2 = new Variant (true))
            using (var falseVariant = new Variant (false)) {
                Assert.That(trueVariant1, Is.EqualTo(trueVariant2));
                Assert.That(trueVariant1, Is.Not.EqualTo(falseVariant));
                Assert.That(trueVariant1 == trueVariant2, Is.True);
                Assert.That(trueVariant1 != trueVariant2, Is.False);
                Assert.That(trueVariant1 == falseVariant, Is.False);
                Assert.That(trueVariant1 != falseVariant, Is.True);

                Assert.That(trueVariant1, Is.Not.EqualTo((Variant)null));
                Assert.That((Variant)null, Is.Not.EqualTo(trueVariant1));
                Assert.That((Variant)null, Is.EqualTo((Variant)null));
                Assert.That(trueVariant1 == null, Is.False);
                Assert.That(trueVariant1 != null, Is.True);
                Assert.That(null == trueVariant1, Is.False);
                Assert.That(null != trueVariant1, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCompareTo ()
        {
            using (var one = new Variant (1))
            using (var two = new Variant (2))
            using (var otherOne = new Variant ((short)1)) {
                Assert.That(one, Is.Not.LessThan(one));
                Assert.That(one, Is.LessThan(two));
                Assert.That(one, Is.LessThanOrEqualTo(one));
                Assert.That(one, Is.LessThanOrEqualTo(two));
                Assert.That(one, Is.Not.GreaterThan(one));
                Assert.That(one, Is.Not.GreaterThan(two));
                Assert.That(one, Is.GreaterThanOrEqualTo(one));
                Assert.That(one, Is.Not.GreaterThanOrEqualTo(two));

                Assert.That(one < two, Is.True);
                Assert.That(one <= two, Is.True);
                Assert.That(one > two, Is.False);
                Assert.That(one >= two, Is.False);

                // types must match
                Assert.That (() => one.CompareTo(otherOne),
                    Throws.InvalidOperationException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastBoolean ()
        {
            var expected = true;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.Boolean));
                var actual = (bool)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastByte ()
        {
            var expected = byte.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.Byte));
                var actual = (byte)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastInt16 ()
        {
            var expected = short.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.Int16));
                var actual = (short)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastUInt16 ()
        {
            var expected = ushort.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.UInt16));
                var actual = (ushort)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastInt32 ()
        {
            var expected = int.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.Int32));
                var actual = (int)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastUInt32 ()
        {
            var expected = uint.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.UInt32));
                var actual = (uint)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastInt64 ()
        {
            var expected = long.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.Int64));
                var actual = (long)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastUInt64 ()
        {
            var expected = ulong.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.UInt64));
                var actual = (ulong)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastHandle ()
        {
            var expected = new DBusHandle (int.MaxValue);
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.DBusHandle));
                var actual = (DBusHandle)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastDouble ()
        {
            var expected = double.MaxValue;
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.Double));
                var actual = (double)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastString ()
        {
            var expected = "string";
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.String));
                var actual = (string)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastStringArray ()
        {
            var expected = new[] { "string" };
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.StringArray));
                var actual = (string[])variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastObjectPath ()
        {
            var expected = new DBusObjectPath ("/");
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.DBusObjectPath));
                var actual = (DBusObjectPath)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastObjectPathArray ()
        {
            var expected = new[] { new DBusObjectPath ("/") };
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.DBusObjectPathArray));
                var actual = (DBusObjectPath[])variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastSignature ()
        {
            var expected = new DBusSignature ("i");
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.DBusSignature));
                var actual = (DBusSignature)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastBytestring ()
        {
            var expected = Encoding.ASCII.GetBytes ("bytestring");
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.ByteString));
                var actual = (byte[])variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastBytestringArray ()
        {
            var expected = new[] { Encoding.ASCII.GetBytes ("bytestring") };
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type, Is.EqualTo(VariantType.ByteStringArray));
                var actual = (byte[][])variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastArray ()
        {
            using (var badArray = new PtrArray<Variant> { new Variant(false), new Variant(0) }) {
                Assert.That(() => new Variant(null, badArray), Throws.ArgumentException);
            }
            using (var badArray = new PtrArray<Variant>()) {
                Assert.That(() => new Variant(null, badArray), Throws.ArgumentException);
            }
            using (var badArray = default(PtrArray<Variant>)) {
                Assert.That(() => new Variant(null, badArray), Throws.ArgumentException);
                Assert.That(() => new Variant(VariantType.Boolean, badArray), Throws.Nothing);
            }

            using (var expected = new PtrArray<Variant> { new Variant(false) })
            using (var variant = new Variant(null, expected)) {
                Assert.That(variant.Type.IsArray, Is.True);
                using (var actual = (PtrArray<Variant>)variant) {
                    Assert.That(actual, Is.EqualTo(expected));
                }
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCastTuple ()
        {
            using (var badTuple = default(PtrArray<Variant>)) {
                Assert.That(() => (Variant)badTuple, Throws.TypeOf<ArgumentNullException>());
            }

            using (var expected = new PtrArray<Variant> { new Variant(false), new Variant(0) })
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type.IsTuple, Is.True);
                var actual = (PtrArray<Variant>)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
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
            using (var variant = (Variant)expected) {
                Assert.That(variant.Type.IsDictionaryEntry, Is.True);
                var actual = (KeyValuePair<Variant, Variant>)variant;
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestPtrArrayVariantRefCount()
        {
            using (var array = new PtrArray<Variant>())
            using (var item = new Variant(false)) {
                // The only reference belongs to the managed proxy
                Assume.That(GetRefCount(item), Is.EqualTo(1));

                // The PtrArray<Variant> takes a reference to the Variant when it is
                /// added to the array
                array.Add(item);
                Assert.That(GetRefCount(item), Is.EqualTo(2));

                // And releases the reference when the Variant is removed
                array.Remove(item);
                Assert.That(GetRefCount(item), Is.EqualTo(1));
            }
        }

        static Variant getItemAt(PtrArray<Variant> array, int index) {
            var ptr = Marshal.ReadIntPtr(array.Data, IntPtr.Size * index);
            return Opaque.GetInstance<Variant>(ptr, Transfer.None);
        }

        static int GetRefCount(Variant variant)
        {
            // WARNING: GVariant is a private structure, so this could break!
            return Marshal.ReadInt32(variant.Handle, IntPtr.Size * 4 + sizeof(int));
        }

        static PropertyInfo isFloatingProp = typeof(Variant).GetProperty("IsFloating", BindingFlags.Instance | BindingFlags.NonPublic);

        static bool GetIsFloating(Variant variant)
        {
            return (bool)isFloatingProp.GetValue(variant);
        }
    }
}
