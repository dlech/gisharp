﻿using System;

using NUnit.Framework;
using GISharp.Lib.GObject;
using GISharp.Runtime;

using static GISharp.TestHelpers;

using nlong = GISharp.Runtime.NativeLong;
using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.Test.Core.GObject
{
    [TestFixture]
    public class ValueTests
    {
        [Test]
        public void TestBoolean ()
        {
            var v = new Value (GType.Boolean);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Boolean));

            Assume.That ((bool)v, Is.False);
            Assert.That (v.Get (), Is.False);
            v.Set (true);
            Assert.That ((bool)v, Is.True);
            Assert.That (v.Get (), Is.True);

            Assert.That(() => {
                var v2 = new Value(GType.Char);
                v2.Set(true);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Char);
                var _ = (bool)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestChar ()
        {
            var v = new Value (GType.Char);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Char));
            sbyte expected = 1;
            v.Set (expected);
            Assert.That ((sbyte)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set ((sbyte)1);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (sbyte)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestUChar ()
        {
            var v = new Value (GType.UChar);
            Assert.That (v.ValueGType, Is.EqualTo (GType.UChar));
            byte expected = 1;
            v.Set (expected);
            Assert.That ((byte)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set((byte)1);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (byte)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestInt ()
        {
            var v = new Value (GType.Int);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Int));
            int expected = 1;
            v.Set (expected);
            Assert.That ((int)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (int)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestUInt ()
        {
            var v = new Value (GType.UInt);
            Assert.That (v.ValueGType, Is.EqualTo (GType.UInt));
            uint expected = 1;
            v.Set (expected);
            Assert.That ((uint)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1U);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (uint)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestLong ()
        {
            var v = new Value (GType.Long);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Long));
            nlong expected = 1;
            v.Set (expected);
            Assert.That ((nlong)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1L);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (nlong)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestULong ()
        {
            var v = new Value (GType.ULong);
            Assert.That (v.ValueGType, Is.EqualTo (GType.ULong));
            nulong expected = 1;
            v.Set (expected);
            Assert.That ((nulong)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1UL);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (nulong)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestInt64 ()
        {
            var v = new Value (GType.Int64);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Int64));
            long expected = 1;
            v.Set (expected);
            Assert.That ((long)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1L);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (long)v2;
             }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestUInt64 ()
        {
            var v = new Value (GType.UInt64);
            Assert.That (v.ValueGType, Is.EqualTo (GType.UInt64));
            ulong expected = 1;
            v.Set (expected);
            Assert.That ((ulong)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1UL);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (ulong)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestFloat ()
        {
            var v = new Value (GType.Float);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Float));
            float expected = 1;
            v.Set (expected);
            Assert.That ((float)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1.0);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (float)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [Test]
        public void TestDouble ()
        {
            var v = new Value (GType.Double);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Double));
            double expected = 1;
            v.Set (expected);
            Assert.That ((double)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(1F);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (double)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        [GType]
        enum ValueTestEnum
        {
            Value = 1
        }

        [Test]
        public void TestEnum ()
        {
            // Can't have enum without implementation
            Assert.That (() => new Value (GType.Enum), Throws.ArgumentException);

            var gtype = typeof (ValueTestEnum).GetGType ();
            Assume.That (gtype.Fundamental, Is.EqualTo (GType.Enum));
            var v = new Value (gtype);
            Assert.That (v.ValueGType, Is.EqualTo (gtype));
            var expected = ValueTestEnum.Value;
            v.Set (expected);
            //            Assert.That ((ValueTestEnum)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(ValueTestEnum.Value);
            }, Throws.ArgumentException);
//            Assert.That (() => (ValueTestEnum)v2, Throws.InstanceOf<InvalidCastException> ());

            AssertNoGLibLog();
        }

        [Flags, GType]
        enum ValueTestFlags
        {
            Value = 2
        }

        [Test]
        public void TestFlags ()
        {
            // Can't have flags without implementation
            Assert.That (() => new Value (GType.Flags), Throws.ArgumentException);

            var gtype = typeof (ValueTestFlags).GetGType ();
            Assume.That (gtype.Fundamental, Is.EqualTo (GType.Flags));
            var v = new Value (gtype);
            Assert.That (v.ValueGType, Is.EqualTo (gtype));
            var expected = ValueTestFlags.Value;
            v.Set (expected);
            //            Assert.That ((ValueTestFlags)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(ValueTestFlags.Value);
            }, Throws.ArgumentException);
//            Assert.That (() => (ValueTestFlags)v2, Throws.InstanceOf<InvalidCastException> ());

            AssertNoGLibLog();
        }

        [Test]
        public void TestString ()
        {
            var v = new Value (GType.String);
            Assert.That (v.ValueGType, Is.EqualTo (GType.String));
            var expected = "1";
            v.Set (expected);
            Assert.That ((string)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set("1");
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (string)v2;
            }, Throws.InstanceOf<InvalidCastException>());
        }

        //[Test]
        //public void TestParam ()
        //{
        //    var v = new Value (GType.Param);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Param));
        //    var expected = "1";
        //    v.Param = expected;
        //    Assert.That (v.Param, Is.EqualTo (expected));
        //    Assert.That (v.Get (), Is.EqualTo (expected));

        //    var v2 = new Value (GType.Invalid);
        //    Assert.That (() => v2.Param = "1", Throws.InstanceOf<InvalidCastException> ());
        //    Assert.That (() => v2.Param, Throws.InstanceOf<InvalidCastException> ());

        //    AssertNoGLibLog();
        //}

        //[Test]
        //public void TestBoxed ()
        //{
        //    var v = new Value (GType.Boxed);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Boxed));
        //    var expected = (IntPtr)1;
        //    v.Boxed = expected;
        //    Assert.That (v.Boxed, Is.EqualTo (expected));
        //    Assert.That (v.Get (), Is.EqualTo (expected));

        //    var v2 = new Value (GType.Boolean);
        //    Assert.That (() => v2.Boxed = IntPtr.Zero, Throws.InstanceOf<InvalidCastException> ());
        //    Assert.That (() => v2.Boxed, Throws.InstanceOf<InvalidCastException> ());

        //    AssertNoGLibLog();
        //}

        [Test]
        public void TestPointer ()
        {
            var v = new Value (GType.Pointer);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Pointer));
            var expected = (IntPtr)1;
            v.Set (expected);
            Assert.That ((IntPtr)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(IntPtr.Zero);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (IntPtr)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        //[Test]
        //public void TestObject ()
        //{
        //    var v = new Value (GType.Object);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Object));
        //    var expected = (IntPtr)1;
        //    v.Object = expected;
        //    Assert.That (v.Object, Is.EqualTo (expected));
        //    Assert.That (v.Get (), Is.EqualTo (expected));

        //    var v2 = new Value (GType.Boolean);
        //    Assert.That (() => v2.Object = IntPtr.Zero, Throws.InstanceOf<InvalidCastException> ());
        //    Assert.That (() => v2.Object, Throws.InstanceOf<InvalidCastException> ());

        //    AssertNoGLibLog();
        //}

        [Test]
        public void TestType ()
        {
            var v = new Value (GType.Type);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Type));
            var expected = GType.None;
            v.Set (expected);
            Assert.That ((GType)v, Is.EqualTo (expected));
            Assert.That (v.Get (), Is.EqualTo (expected));

            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                v2.Set(GType.Boolean);
            }, Throws.ArgumentException);
            Assert.That(() => {
                var v2 = new Value(GType.Boolean);
                var _ = (GType)v2;
            }, Throws.InstanceOf<InvalidCastException>());

            AssertNoGLibLog();
        }

        //[Test]
        //public void TestVariant ()
        //{
        //    var v = new Value (GType.Variant);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Variant));
        //    var expected = (IntPtr)1;
        //    v.Variant = GType.None;
        //    Assert.That (v.Variant, Is.EqualTo (expected));
        //    Assert.That (v.Get (), Is.EqualTo (expected));

        //    var v2 = new Value (GType.Boolean);
        //    Assert.That (() => v2.Variant = GType.None, Throws.InstanceOf<InvalidCastException> ());
        //    Assert.That (() => v2.Variant, Throws.InstanceOf<InvalidCastException> ());

        //    AssertNoGLibLog();
        //}
    }
}
