// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;

using NUnit.Framework;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;
using culong = GISharp.Runtime.CULong;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Test.GObject
{
    public class ValueTests
    {
        [Test]
        public void TestBoolean()
        {
            var v = new Value(GType.Boolean);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Boolean));

            Assume.That((bool)v, Is.False);
            Assert.That(v.Get(), Is.False);
            v.Set(true);
            Assert.That((bool)v, Is.True);
            Assert.That(v.Get(), Is.True);

            Assert.That(() => {
                var v2 = new Value(GType.Char);
                v2.Set(true);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Char);
                var _ = (bool)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestChar()
        {
            var v = new Value(GType.Char);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Char));
            sbyte expected = 1;
            v.Set(expected);
            Assert.That((sbyte)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set((sbyte)1);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (sbyte)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestUChar()
        {
            var v = new Value(GType.UChar);
            Assert.That(v.ValueGType, Is.EqualTo(GType.UChar));
            byte expected = 1;
            v.Set(expected);
            Assert.That((byte)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set((byte)1);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (byte)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestInt()
        {
            var v = new Value(GType.Int);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Int));
            int expected = 1;
            v.Set(expected);
            Assert.That((int)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (int)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestUInt()
        {
            var v = new Value(GType.UInt);
            Assert.That(v.ValueGType, Is.EqualTo(GType.UInt));
            uint expected = 1;
            v.Set(expected);
            Assert.That((uint)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1U);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (uint)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestLong()
        {
            var v = new Value(GType.Long);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Long));
            clong expected = 1;
            v.Set(expected);
            Assert.That((clong)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1L);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (clong)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestULong()
        {
            var v = new Value(GType.ULong);
            Assert.That(v.ValueGType, Is.EqualTo(GType.ULong));
            culong expected = 1;
            v.Set(expected);
            Assert.That((culong)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1UL);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (culong)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestInt64()
        {
            var v = new Value(GType.Int64);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Int64));
            long expected = 1;
            v.Set(expected);
            Assert.That((long)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1L);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (long)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestUInt64()
        {
            var v = new Value(GType.UInt64);
            Assert.That(v.ValueGType, Is.EqualTo(GType.UInt64));
            ulong expected = 1;
            v.Set(expected);
            Assert.That((ulong)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1UL);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (ulong)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestFloat()
        {
            var v = new Value(GType.Float);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Float));
            float expected = 1;
            v.Set(expected);
            Assert.That((float)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1.0);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (float)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestDouble()
        {
            var v = new Value(GType.Double);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Double));
            double expected = 1;
            v.Set(expected);
            Assert.That((double)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1F);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (double)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [GType]
        enum ValueTestEnum
        {
            Value = 1
        }

        [Test]
        public void TestEnum()
        {
            // Can't have enum without implementation
            Assert.That(() => new Value(GType.Enum), Throws.ArgumentException);

            var gtype = typeof(ValueTestEnum).ToGType();
            Assume.That(gtype.Fundamental, Is.EqualTo(GType.Enum));
            var v = new Value(gtype);
            Assert.That(v.ValueGType, Is.EqualTo(gtype));
            var expected = ValueTestEnum.Value;
            v.Set(expected);
            // Assert.That ((ValueTestEnum)v, Is.EqualTo (expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(ValueTestEnum.Value);
            }, Throws.ArgumentException);
            // Assert.That (() => (ValueTestEnum)v2, Throws.InstanceOf<InvalidCastException> ());
        }

        [Flags, GType]
        enum ValueTestFlags
        {
            Value = 2
        }

        [Test]
        public void TestFlags()
        {
            // Can't have flags without implementation
            Assert.That(() => new Value(GType.Flags), Throws.ArgumentException);

            var gtype = typeof(ValueTestFlags).ToGType();
            Assume.That(gtype.Fundamental, Is.EqualTo(GType.Flags));
            var v = new Value(gtype);
            Assert.That(v.ValueGType, Is.EqualTo(gtype));
            var expected = ValueTestFlags.Value;
            v.Set(expected);
            // Assert.That ((ValueTestFlags)v, Is.EqualTo (expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(ValueTestFlags.Value);
            }, Throws.ArgumentException);
            // Assert.That (() => (ValueTestFlags)v2, Throws.InstanceOf<InvalidCastException> ());
        }

        [Test]
        public void TestString()
        {
            var v = new Value(GType.String);
            Assert.That(v.ValueGType, Is.EqualTo(GType.String));
            var expected = "1";
            v.Set(expected);
            Assert.That((string?)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set("1");
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (string?)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestParam()
        {
            var v = new Value(typeof(ParamSpecBoolean).ToGType());
            Assert.That(v.ValueGType, Is.Not.EqualTo(GType.Param));
            Assert.That(v.ValueGType.Fundamental, Is.EqualTo(GType.Param));
            using var expected = new ParamSpecBoolean("test", "test", "test", false, default);
            v.Set(expected);
            Assert.That((ParamSpec?)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(expected);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (ParamSpec?)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestBoxed()
        {
            var v = new Value(typeof(Strv).ToGType());
            Assert.That(v.ValueGType, Is.Not.EqualTo(GType.Boxed));
            Assert.That(v.ValueGType.Fundamental, Is.EqualTo(GType.Boxed));
            using var expected = new Strv();
            v.Set(expected);
            Assert.That((Boxed?)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(IntPtr.Zero);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (Boxed?)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestPointer()
        {
            var v = new Value(GType.Pointer);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Pointer));
            var expected = (IntPtr)1;
            v.Set(expected);
            Assert.That((IntPtr)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(IntPtr.Zero);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (IntPtr)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestObject()
        {
            var v = new Value(GType.Object);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Object));
            using var expected = new Object();
            v.Set(expected);
            Assert.That((Object?)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(expected);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (Object?)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestType()
        {
            var v = new Value(GType.Type);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Type));
            var expected = GType.None;
            v.Set(expected);
            Assert.That((GType)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(GType.Boolean);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (GType)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        [Test]
        public void TestVariant()
        {
            var v = new Value(GType.Variant);
            Assert.That(v.ValueGType, Is.EqualTo(GType.Variant));
            using var expected = (Variant)1;
            v.Set(expected);
            Assert.That((Variant?)v, Is.EqualTo(expected));
            Assert.That(v.Get(), Is.EqualTo(expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(expected);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (Variant?)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }
    }
}
