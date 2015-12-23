using System;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class GTypeTest
    {
        [Test]
        public void TestNone ()
        {
            Assert.That ((Type)GType.None, Is.EqualTo (typeof (void)));
        }

        [Test]
        public void TestInterface ()
        {
            Assert.That (() => (Type)GType.Interface, Throws.Exception);
        }

        [Test]
        public void TestChar ()
        {
            Assert.That ((Type)GType.Char, Is.EqualTo (typeof (sbyte)));
        }

        [Test]
        public void TestUChar ()
        {
            Assert.That ((Type)GType.UChar, Is.EqualTo (typeof (byte)));
        }

        [Test]
        public void TestBoolean ()
        {
            Assert.That ((Type)GType.Boolean, Is.EqualTo (typeof (bool)));
        }

        [Test]
        public void TestInt ()
        {
            Assert.That ((Type)GType.Int, Is.EqualTo (typeof (int)));
        }

        [Test]
        public void TestUInt ()
        {
            Assert.That ((Type)GType.UInt, Is.EqualTo (typeof (uint)));
        }

        [Test]
        public void TestLong ()
        {
            Assert.That (() => (Type)GType.Long, Throws.Exception);
        }

        [Test]
        public void TestULong ()
        {
            Assert.That (() => (Type)GType.ULong, Throws.Exception);
        }

        [Test]
        public void TestInt64 ()
        {
            Assert.That ((Type)GType.Int64, Is.EqualTo (typeof (long)));
        }

        [Test]
        public void TestUInt64 ()
        {
            Assert.That ((Type)GType.UInt64, Is.EqualTo (typeof (ulong)));
        }

        [Test]
        public void TestEnum ()
        {
            Assert.That ((Type)GType.Enum, Is.EqualTo (typeof (System.Enum)));
        }

        [Test]
        public void TestFlags ()
        {
            Assert.That (() => (Type)GType.Flags, Throws.Exception);
        }

        [Test]
        public void TestFloat ()
        {
            Assert.That ((Type)GType.Float, Is.EqualTo (typeof (float)));
        }

        [Test]
        public void TestDouble ()
        {
            Assert.That ((Type)GType.Double, Is.EqualTo (typeof (double)));
        }

        [Test]
        public void TestString ()
        {
            Assert.That ((Type)GType.String, Is.EqualTo (typeof (string)));
        }

        [Test]
        public void TestPointer ()
        {
            Assert.That ((Type)GType.Pointer, Is.EqualTo (typeof (IntPtr)));
        }

        [Test]
        public void TestBoxed ()
        {
            // TODO: Boxed is not implemented yet
            Assert.That (() => (Type)GType.Boxed, Throws.Exception);
        }

        [Test]
        public void TestParam ()
        {
            // TODO: ParamSpec is currently not public
            //Assert.That ((Type)GType.Param, Is.EqualTo (typeof (ParamSpec)));
        }

        [Test]
        public void TestObject ()
        {
            Assert.That ((Type)GType.Object, Is.EqualTo (typeof (Core.Object)));
        }

        [Test]
        public void TestGType ()
        {
            Assert.That ((Type)GType.Type, Is.EqualTo (typeof (GType)));
        }

        [Test]
        public void TestVariant ()
        {
            // TODO: Need to move Variant from GLib
            //Assert.That ((Type)GType.Variant, Is.EqualTo (typeof (Variant)));
        }

        [Test]
        public void TestGetGTypeName ()
        {
            Assert.That (typeof (GType).GetGTypeName (), Is.EqualTo ("GType"));
        }

        [Test]
        public void TestName ()
        {
            Assert.That (GType.Invalid.Name, Is.Null);
            Assert.That (GType.None.Name, Is.EqualTo ("void"));
        }

        [Test]
        public void TestParent ()
        {
            Assert.That (GType.Invalid.Parent, Is.EqualTo (GType.Invalid));
            Assert.That (GType.None.Parent, Is.EqualTo (GType.Invalid));
            // TODO: would be nice to have a test case that does not return Invalid
        }

        [Test]
        public void TestChildren ()
        {
            Assert.That (GType.Invalid.Children, Is.Null);
            Assert.That (GType.None.Children, Is.Empty);
        }

        [Test]
        public void TestIsA ()
        {
            Assert.That (GType.Invalid.IsA (GType.Invalid), Is.True);
            Assert.That (GType.None.IsA (GType.None), Is.True);
            Assert.That (GType.None.IsA (GType.Boolean), Is.False);
        }

        [Test]
        public void TestFromName ()
        {
            Assert.That (GType.FromName ("void"), Is.EqualTo (GType.None));
            Assert.That (GType.FromName ("there-should-never-be-a-type-with-this-name"),
                         Is.EqualTo (GType.Invalid));
            Assert.That (() => GType.FromName ("name has invalid characters"),
                         Throws.TypeOf<InvalidGTypeNameException> ());
            Assert.That (() => GType.FromName (null),
                         Throws.TypeOf<ArgumentNullException> ());
        }

        [Test]
        public void TestEqualityOperator ()
        {
            Assert.That (GType.Invalid == GType.Invalid, Is.True);
            Assert.That (GType.Invalid == GType.None, Is.False);
        }

        [Test]
        public void TestInequalityOperator ()
        {
            Assert.That (GType.Invalid != GType.None, Is.True);
            Assert.That (GType.Invalid != GType.Invalid, Is.False);
        }

        [Test]
        public void TestEquals ()
        {
            Assert.That (GType.Invalid.Equals (GType.Invalid), Is.True);
            Assert.That (GType.Invalid.Equals (GType.None), Is.False);
            Assert.That (GType.Invalid.Equals (new object ()), Is.False);
            Assert.That (GType.Invalid.Equals (null), Is.False);
        }
    }
}
