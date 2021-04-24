// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class VariantTests : IListTests<PtrArray<Variant>, Variant>
    {
        public VariantTests() : base(GetItemAt, (Variant)0, (Variant)1, (Variant)2, (Variant)3, (Variant)4)
        {
        }

        [Test]
        public void TestNewBoolean()
        {
            // make sure we got the floating reference thing right
            using var v = new Variant(false);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewByte()
        {
            using var v = new Variant((byte)0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewInt16()
        {
            using var v = new Variant((short)0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestUInt16()
        {
            using var v = new Variant((ushort)0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewInt32()
        {
            using var v = new Variant(0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestUInt32()
        {
            using var v = new Variant((uint)0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestInt64()
        {
            using var v = new Variant((long)0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewUint64()
        {
            using var v = new Variant((ulong)0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewHandle()
        {
            using var v = new Variant(new DBusHandle());
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewDouble()
        {
            using var v = new Variant((double)0);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewString()
        {
            using var utf8 = (Utf8)"";
            using var v = new Variant(utf8.AsUnownedUtf8());
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewTakeString()
        {
            using var v = new Variant("");
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewObjectPath()
        {
            using var v = new Variant(new DBusObjectPath("/"));
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewSignature()
        {
            using var v = new Variant(new DBusSignature("i"));
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewVariant()
        {
            using var child = new Variant(0);
            using var v = new Variant(child);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewStrv()
        {
            using var strv = new Strv<Utf8>("");
            using var v = new Variant(strv);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewObjv()
        {
            using var path1 = new DBusObjectPath("/one");
            using var path2 = new DBusObjectPath("/two");
            using var objv = new[] { path1, path2 }.ToWeakCPtrArray();
            using var v = new Variant(objv);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewBytestring()
        {
            using var bytestring = new ByteString(System.Array.Empty<byte>());
            using var v = new Variant(bytestring);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewBytestringArray()
        {
            using var empty = new Strv<ByteString>(System.Array.Empty<byte[]>());
            using var v = new Variant(empty);
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));
        }

        [Test]
        public void TestNewTuple()
        {
            using var v = new Variant(default(ValueTuple));
            Assert.That(GetIsFloating(v), Is.False);
            Assert.That(GetRefCount(v), Is.EqualTo(1));

            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var v2 = new Variant((item1, item2));
            Assert.That(GetIsFloating(v2), Is.False);
            Assert.That(GetRefCount(v2), Is.EqualTo(1));
        }

        [Test]
        public void TestEquals()
        {
            using var trueVariant1 = new Variant(true);
            using var trueVariant2 = new Variant(true);
            using var falseVariant = new Variant(false);

            Assert.That(trueVariant1, Is.EqualTo(trueVariant2));
            Assert.That(trueVariant1, Is.Not.EqualTo(falseVariant));
            Assert.That(trueVariant1 == trueVariant2, Is.True);
            Assert.That(trueVariant1 != trueVariant2, Is.False);
            Assert.That(trueVariant1 == falseVariant, Is.False);
            Assert.That(trueVariant1 != falseVariant, Is.True);

            Assert.That(trueVariant1 == null, Is.False);
            Assert.That(trueVariant1 != null, Is.True);
            Assert.That(null == trueVariant1, Is.False);
            Assert.That(null != trueVariant1, Is.True);
        }

        [Test]
        public void TestCompareTo()
        {
            using var one = new Variant(1);
            using var two = new Variant(2);
            using var otherOne = new Variant((short)1);

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
            Assert.That(() => one.CompareTo(otherOne),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestCastBoolean()
        {
            var expected = true;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.Boolean));
            var actual = (bool)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastByte()
        {
            var expected = byte.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.Byte));
            var actual = (byte)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastInt16()
        {
            var expected = short.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.Int16));
            var actual = (short)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastUInt16()
        {
            var expected = ushort.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.UInt16));
            var actual = (ushort)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastInt32()
        {
            var expected = int.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.Int32));
            var actual = (int)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastUInt32()
        {
            var expected = uint.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.UInt32));
            var actual = (uint)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastInt64()
        {
            var expected = long.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.Int64));
            var actual = (long)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastUInt64()
        {
            var expected = ulong.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.UInt64));
            var actual = (ulong)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastHandle()
        {
            var expected = new DBusHandle(int.MaxValue);
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.DBusHandle));
            var actual = (DBusHandle)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastDouble()
        {
            var expected = double.MaxValue;
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.Double));
            var actual = (double)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastString()
        {
            var expected = "string";
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.String));
            var actual = (string)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastStringArray()
        {
            using var expected = new Strv<Utf8>("string");
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.StringArray));
            using var actual = (Strv<Utf8>?)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastObjectPath()
        {
            var expected = new DBusObjectPath("/");
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.DBusObjectPath));
            var actual = (DBusObjectPath)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastObjectPathArray()
        {
            using var expected = new[] { new DBusObjectPath("/") }.ToWeakCPtrArray();
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.DBusObjectPathArray));
            var actual = (WeakZeroTerminatedCPtrArray<DBusObjectPath>)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastSignature()
        {
            var expected = new DBusSignature("i");
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.DBusSignature));
            var actual = (DBusSignature)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastBytestring()
        {
            using var expected = new ByteString(Encoding.Latin1.GetBytes("bytestring"));
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.ByteString));
            using var actual = (ByteString)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastBytestringArray()
        {
            var expected = new Strv<ByteString>(new[] { Encoding.Latin1.GetBytes("bytestring") });
            using var variant = (Variant)expected;
            Assert.That(variant.Type, Is.EqualTo(VariantType.ByteStringArray));
            using var actual1 = (Strv<ByteString>?)variant;
            Assert.That(actual1, Is.EqualTo(expected));
            using var actual2 = (WeakZeroTerminatedCPtrArray<ByteString>?)variant;
            Assert.That(actual2, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastArray()
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

            using var expected = new PtrArray<Variant> { new Variant(false) };
            using var variant = new Variant(null, expected);
            Assert.That(variant.Type.IsArray, Is.True);
            using var actual = variant.ToPtrArray();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastTuple()
        {
            var expected = default(ValueTuple);
            using var variant = (Variant)expected;
            Assert.That(variant.Type.IsTuple, Is.True);
            var actual = (ValueTuple)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestCastDictEntry()
        {
            // only basic variant types are allowed as key
            var badKey = new KeyValuePair<Variant, Variant>(new Variant(new Strv<Utf8>("string")), new Variant("string"));
            Assert.That(() => (Variant)badKey, Throws.ArgumentException);

            // make sure we get back what we put in
            var expected = new KeyValuePair<Variant, Variant>(new Variant("key"), new Variant("value"));
            using var variant = (Variant)expected;
            Assert.That(variant.Type.IsDictEntry, Is.True);
            var actual = (KeyValuePair<Variant, Variant>)variant;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPtrArrayVariantRefCount()
        {
            using var array = new PtrArray<Variant>();
            using var item = new Variant(false);

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

        [Test]
        public void TestStore()
        {
            using var v = new Variant("test");
            Span<byte> data = stackalloc byte[v.Size];
            v.Store(data);
            Assert.That(data.ToArray(), Is.EqualTo(new byte[] { 116, 101, 115, 116, 0 }));
            Assert.That(() => v.Store(Span<byte>.Empty), Throws.ArgumentException);
        }

        [Test]
        public void TestDeconstruct2()
        {
            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var v = new Variant((item1, item2));

            var (actual1, actual2) = v;
            Assert.That(actual1, Is.EqualTo(item1));
            Assert.That(actual2, Is.EqualTo(item2));
        }

        [Test]
        public void TestDeconstruct3()
        {
            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var item3 = new Variant(3);
            using var v = new Variant((item1, item2, item3));

            var (actual1, actual2, actual3) = v;
            Assert.That(actual1, Is.EqualTo(item1));
            Assert.That(actual2, Is.EqualTo(item2));
            Assert.That(actual3, Is.EqualTo(item3));
        }

        [Test]
        public void TestDeconstruct4()
        {
            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var item3 = new Variant(3);
            using var item4 = new Variant(4);
            using var v = new Variant((item1, item2, item3, item4));

            var (actual1, actual2, actual3, actual4) = v;
            Assert.That(actual1, Is.EqualTo(item1));
            Assert.That(actual2, Is.EqualTo(item2));
            Assert.That(actual3, Is.EqualTo(item3));
            Assert.That(actual4, Is.EqualTo(item4));
        }

        [Test]
        public void TestDeconstruct5()
        {
            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var item3 = new Variant(3);
            using var item4 = new Variant(4);
            using var item5 = new Variant(5);
            using var v = new Variant((item1, item2, item3, item4, item5));

            var (actual1, actual2, actual3, actual4, actual5) = v;
            Assert.That(actual1, Is.EqualTo(item1));
            Assert.That(actual2, Is.EqualTo(item2));
            Assert.That(actual3, Is.EqualTo(item3));
            Assert.That(actual4, Is.EqualTo(item4));
            Assert.That(actual5, Is.EqualTo(item5));
        }

        [Test]
        public void TestDeconstruct6()
        {
            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var item3 = new Variant(3);
            using var item4 = new Variant(4);
            using var item5 = new Variant(5);
            using var item6 = new Variant(6);
            using var v = new Variant((item1, item2, item3, item4, item5, item6));

            var (actual1, actual2, actual3, actual4, actual5, actual6) = v;
            Assert.That(actual1, Is.EqualTo(item1));
            Assert.That(actual2, Is.EqualTo(item2));
            Assert.That(actual3, Is.EqualTo(item3));
            Assert.That(actual4, Is.EqualTo(item4));
            Assert.That(actual5, Is.EqualTo(item5));
            Assert.That(actual6, Is.EqualTo(item6));
        }

        [Test]
        public void TestDeconstruct7()
        {
            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var item3 = new Variant(3);
            using var item4 = new Variant(4);
            using var item5 = new Variant(5);
            using var item6 = new Variant(6);
            using var item7 = new Variant(7);
            using var v = new Variant((item1, item2, item3, item4, item5, item6, item7));

            var (actual1, actual2, actual3, actual4, actual5, actual6, actual7) = v;
            Assert.That(actual1, Is.EqualTo(item1));
            Assert.That(actual2, Is.EqualTo(item2));
            Assert.That(actual3, Is.EqualTo(item3));
            Assert.That(actual4, Is.EqualTo(item4));
            Assert.That(actual5, Is.EqualTo(item5));
            Assert.That(actual6, Is.EqualTo(item6));
            Assert.That(actual7, Is.EqualTo(item7));
        }

        [Test]
        public void TestDeconstruct8()
        {
            using var item1 = new Variant(0);
            using var item2 = new Variant(1);
            using var item3 = new Variant(3);
            using var item4 = new Variant(4);
            using var item5 = new Variant(5);
            using var item6 = new Variant(6);
            using var item7 = new Variant(7);
            using var item8 = new Variant(8);
            using var v = new Variant((item1, item2, item3, item4, item5, item6, item7, item8));

            var (actual1, actual2, actual3, actual4, actual5, actual6, actual7, actual8) = v;
            Assert.That(actual1, Is.EqualTo(item1));
            Assert.That(actual2, Is.EqualTo(item2));
            Assert.That(actual3, Is.EqualTo(item3));
            Assert.That(actual4, Is.EqualTo(item4));
            Assert.That(actual5, Is.EqualTo(item5));
            Assert.That(actual6, Is.EqualTo(item6));
            Assert.That(actual7, Is.EqualTo(item7));
            Assert.That(actual8, Is.EqualTo(item8));
        }

        static Variant GetItemAt(PtrArray<Variant> array, int index)
        {
            var data_ = Marshal.ReadIntPtr(array.UnsafeHandle);
            var ptr = Marshal.ReadIntPtr(data_, IntPtr.Size * index);
            return Opaque.GetInstance<Variant>(ptr, Transfer.None);
        }

        static int GetRefCount(Variant variant)
        {
            // WARNING: GVariant is a private structure, so this could break!
            return Marshal.ReadInt32(variant.UnsafeHandle, IntPtr.Size * 4 + sizeof(int));
        }

        static readonly PropertyInfo isFloatingProp =
            typeof(Variant).GetProperty("IsFloating", BindingFlags.Instance | BindingFlags.NonPublic)!;

        static bool GetIsFloating(Variant variant)
        {
            return (bool)isFloatingProp.GetValue(variant)!;
        }
    }
}
