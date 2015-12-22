using System;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class ValueTest
    {
        [Test]
        public void TestBoolean ()
        {
            var v = new Value (GType.Boolean);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Boolean));
            v.Boolean = true;
            Assert.That (v.Boolean, Is.True);

            var v2 = new Value (GType.Char);
            Assert.That (() => v2.Boolean = true, Throws.InvalidOperationException);
            Assert.That (() => v2.Boolean, Throws.InvalidOperationException);
        }

        [Test]
        public void TestChar ()
        {
            var v = new Value (GType.Char);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Char));
            sbyte expected = 1;
            v.Char = expected;
            Assert.That (v.Char, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Char = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Char, Throws.InvalidOperationException);
        }

        [Test]
        public void TestUChar ()
        {
            var v = new Value (GType.UChar);
            Assert.That (v.ValueGType, Is.EqualTo (GType.UChar));
            byte expected = 1;
            v.UChar = expected;
            Assert.That (v.UChar, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.UChar = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.UChar, Throws.InvalidOperationException);
        }

        [Test]
        public void TestInt ()
        {
            var v = new Value (GType.Int);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Int));
            int expected = 1;
            v.Int = expected;
            Assert.That (v.Int, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Int = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Int, Throws.InvalidOperationException);
        }

        [Test]
        public void TestUInt ()
        {
            var v = new Value (GType.UInt);
            Assert.That (v.ValueGType, Is.EqualTo (GType.UInt));
            uint expected = 1;
            v.UInt = expected;
            Assert.That (v.UInt, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.UInt = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.UInt, Throws.InvalidOperationException);
        }

        [Test]
        public void TestLong ()
        {
            var v = new Value (GType.Long);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Long));
            long expected = 1;
            v.Long = expected;
            Assert.That (v.Long, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Long = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Long, Throws.InvalidOperationException);
        }

        [Test]
        public void TestULong ()
        {
            var v = new Value (GType.ULong);
            Assert.That (v.ValueGType, Is.EqualTo (GType.ULong));
            ulong expected = 1;
            v.ULong = expected;
            Assert.That (v.ULong, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.ULong = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.ULong, Throws.InvalidOperationException);
        }

        [Test]
        public void TestInt64 ()
        {
            var v = new Value (GType.Int64);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Int64));
            long expected = 1;
            v.Int64 = expected;
            Assert.That (v.Int64, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Int64 = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Int64, Throws.InvalidOperationException);
        }

        [Test]
        public void TestUInt64 ()
        {
            var v = new Value (GType.UInt64);
            Assert.That (v.ValueGType, Is.EqualTo (GType.UInt64));
            ulong expected = 1;
            v.UInt64 = expected;
            Assert.That (v.UInt64, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.UInt64 = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.UInt64, Throws.InvalidOperationException);
        }

        [Test]
        public void TestFloat ()
        {
            var v = new Value (GType.Float);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Float));
            float expected = 1;
            v.Float = expected;
            Assert.That (v.Float, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Float = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Float, Throws.InvalidOperationException);
        }

        [Test]
        public void TestDouble ()
        {
            var v = new Value (GType.Double);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Double));
            double expected = 1;
            v.Double = expected;
            Assert.That (v.Double, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Double = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Double, Throws.InvalidOperationException);
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

            var gtype = GType.Register (typeof (ValueTestEnum));
            var v = new Value (gtype);
            Assert.That (v.ValueGType, Is.EqualTo (gtype));
            var expected = ValueTestEnum.Value;
            v.Enum = (int)expected;
            Assert.That ((ValueTestEnum)v.Enum, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Enum = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Enum, Throws.InvalidOperationException);
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

            var gtype = GType.Register (typeof (ValueTestFlags));
            var v = new Value (gtype);
            Assert.That (v.ValueGType, Is.EqualTo (gtype));
            var expected = ValueTestFlags.Value;
            v.Flags = (uint)expected;
            Assert.That ((ValueTestFlags)v.Flags, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Flags = 1, Throws.InvalidOperationException);
            Assert.That (() => v2.Flags, Throws.InvalidOperationException);
        }

        [Test]
        public void TestString ()
        {
            var v = new Value (GType.String);
            Assert.That (v.ValueGType, Is.EqualTo (GType.String));
            var expected = "1";
            v.String = expected;
            Assert.That (v.String, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.String = "1", Throws.InvalidOperationException);
            Assert.That (() => v2.String, Throws.InvalidOperationException);
        }

        //[Test]
        //public void TestParam ()
        //{
        //    var v = new Value (GType.Param);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Param));
        //    var expected = "1";
        //    v.Param = expected;
        //    Assert.That (v.Param, Is.EqualTo (expected));

        //    var v2 = new Value (GType.Invalid);
        //    Assert.That (() => v2.Param = "1", Throws.InvalidOperationException);
        //    Assert.That (() => v2.Param, Throws.InvalidOperationException);
        //}

        //[Test]
        //public void TestBoxed ()
        //{
        //    var v = new Value (GType.Boxed);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Boxed));
        //    var expected = (IntPtr)1;
        //    v.Boxed = expected;
        //    Assert.That (v.Boxed, Is.EqualTo (expected));

        //    var v2 = new Value (GType.Boolean);
        //    Assert.That (() => v2.Boxed = IntPtr.Zero, Throws.InvalidOperationException);
        //    Assert.That (() => v2.Boxed, Throws.InvalidOperationException);
        //}

        [Test]
        public void TestPointer ()
        {
            var v = new Value (GType.Pointer);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Pointer));
            var expected = (IntPtr)1;
            v.Pointer = expected;
            Assert.That (v.Pointer, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.Pointer = IntPtr.Zero, Throws.InvalidOperationException);
            Assert.That (() => v2.Pointer, Throws.InvalidOperationException);
        }

        //[Test]
        //public void TestObject ()
        //{
        //    var v = new Value (GType.Object);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Object));
        //    var expected = (IntPtr)1;
        //    v.Object = expected;
        //    Assert.That (v.Object, Is.EqualTo (expected));

        //    var v2 = new Value (GType.Boolean);
        //    Assert.That (() => v2.Object = IntPtr.Zero, Throws.InvalidOperationException);
        //    Assert.That (() => v2.Object, Throws.InvalidOperationException);
        //}

        [Test]
        public void TestType ()
        {
            var v = new Value (GType.Type);
            Assert.That (v.ValueGType, Is.EqualTo (GType.Type));
            var expected = GType.None;
            v.GType = expected;
            Assert.That (v.GType, Is.EqualTo (expected));

            var v2 = new Value (GType.Boolean);
            Assert.That (() => v2.GType = GType.None, Throws.InvalidOperationException);
            Assert.That (() => v2.GType, Throws.InvalidOperationException);
        }

        //[Test]
        //public void TestVariant ()
        //{
        //    var v = new Value (GType.Variant);
        //    Assert.That (v.ValueGType, Is.EqualTo (GType.Variant));
        //    var expected = (IntPtr)1;
        //    v.Variant = GType.None;
        //    Assert.That (v.Variant, Is.EqualTo (expected));

        //    var v2 = new Value (GType.Boolean);
        //    Assert.That (() => v2.Variant = GType.None, Throws.InvalidOperationException);
        //    Assert.That (() => v2.Variant, Throws.InvalidOperationException);
        //}
    }
}
