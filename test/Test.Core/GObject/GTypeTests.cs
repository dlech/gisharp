using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using clong = GISharp.Runtime.CLong;
using culong = GISharp.Runtime.CULong;

namespace GISharp.Test.Core.GObject
{
    public class GTypeTests : Tests
    {
        [Test]
        public void TestNone ()
        {
            Assert.That ((Type)GType.None, Is.EqualTo (typeof (void)));
        }

        [Test]
        public void TestInterface ()
        {
            Assert.That(() => (Type)GType.Interface, Is.EqualTo(typeof(GInterface<>)));
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
        public void TestLong()
        {
            Assert.That(() => (Type)GType.Long, Is.EqualTo(typeof(clong)));
        }

        [Test]
        public void TestULong()
        {
            Assert.That(() => (Type)GType.ULong, Is.EqualTo(typeof(culong)));
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
            Assert.That(() => (Type)GType.Flags, Is.EqualTo(typeof(System.Enum)));
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
        public void TestString()
        {
            Assert.That((Type)GType.String, Is.EqualTo(typeof(Utf8)));
        }

        [Test]
        public void TestPointer ()
        {
            Assert.That ((Type)GType.Pointer, Is.EqualTo (typeof (IntPtr)));
        }

        [Test]
        public void TestBoxed ()
        {
            Assert.That ((Type)GType.Boxed, Is.EqualTo(typeof(Boxed)));
        }

        [Test]
        public void TestParam ()
        {
            Assert.That ((Type)GType.Param, Is.EqualTo (typeof (ParamSpec)));
        }

        [Test]
        public void TestObject ()
        {
            Assert.That ((Type)GType.Object, Is.EqualTo (typeof (GISharp.Lib.GObject.Object)));
        }

        [Test]
        public void TestGType ()
        {
            Assert.That ((Type)GType.Type, Is.EqualTo (typeof (GType)));
        }

        [Test]
        public void TestVariant ()
        {
            Assert.That ((Type)GType.Variant, Is.EqualTo (typeof (Variant)));
        }

        [Test]
        public void TestGetGTypeName ()
        {
            Assert.That (typeof (GType).GetGTypeName (), Is.EqualTo ("GType"));
        }

        [Test]
        public void TestName ()
        {
            Assert.That<string?>(GType.Invalid.Name, Is.Null);
            Assert.That<string?>(GType.None.Name, Is.EqualTo("void"));
        }

        [Test]
        public void TestParent ()
        {
            Assert.That (GType.Invalid.Parent, Is.EqualTo (GType.Invalid));
            Assert.That (GType.None.Parent, Is.EqualTo (GType.Invalid));
            // TODO: would be nice to have a test case that does not return Invalid
        }

        [Test]
        public void TestChildren()
        {
            Assert.That(GType.Invalid.Children.IsEmpty);
            Assert.That(GType.None.Children.IsEmpty);
            // TODO: would be nice to have a test case that does not return Empty
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
        }

        [Test]
        public void TestTypeOfUnregisteredManagedType ()
        {
            // This tests that if a GType is received from unmanged code
            // that has never been initialized in managed code.

            const string testName = "TestTypeOfUnregisteredManagedType";

            // first we register the type in unmanged code and make sure that
            // it throws an exception because there is no matching type in
            // managed code.

            var gtype = GetDummyGType ();
            // TODO: Need more specific type of exception
            Assert.That(() => gtype.ToType(), Throws.Exception);

            // then we dynamically generate a matching managed type

            var asmBuilder = AssemblyBuilder.DefineDynamicAssembly (
                new AssemblyName(testName + "_assembly"),
                AssemblyBuilderAccess.Run);
            var modBuilder = asmBuilder.DefineDynamicModule (testName + "_module");
            var typeBuilder = modBuilder.DefineType (testName + "_type",
                TypeAttributes.Public);
            var gtypeAttribute = typeof(GTypeAttribute);
            typeBuilder.SetCustomAttribute (new CustomAttributeBuilder (
                gtypeAttribute.GetConstructors ().Single (),
                new object [] { dummyTypeName },
                new PropertyInfo[] {
                    gtypeAttribute.GetProperty("IsProxyForUnmanagedType")!,
                },
                new object [] {
                    true, // IsProxyForUnmanagedType
                }));
            var gtypeStructAttribute = typeof(GTypeStructAttribute);
            typeBuilder.SetCustomAttribute (new CustomAttributeBuilder (
                gtypeStructAttribute.GetConstructors ().Single (),
                new object[] { typeof(ObjectClass) },
                new FieldInfo[0], new object[0]));

            // define a private static readonly field named _GType
            var gtypeField = typeBuilder.DefineField("_GType", typeof(GType),
                FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.InitOnly);

            // define a static constructor that sets the value of _GType to GetDummyGType()
            var staticCtor = typeBuilder.DefineConstructor(MethodAttributes.Private |
                MethodAttributes.HideBySig | MethodAttributes.SpecialName |
                MethodAttributes.RTSpecialName | MethodAttributes.Static,
                CallingConventions.Standard, null);
            var getDummyGType = GetType().GetMethod(nameof(GetDummyGType))!;
            var generator = staticCtor.GetILGenerator();
            generator.Emit(OpCodes.Call, getDummyGType);
            generator.Emit(OpCodes.Stsfld, gtypeField);
            generator.Emit(OpCodes.Ret);

            var expectedType = typeBuilder.CreateType ();

            // and try the test again

            var actualType = gtype.ToType();
            Assert.That (actualType, Is.EqualTo (expectedType));
        }

        const string dummyTypeName = "GTypeTestDummyType";
        static GType _dummyGType;
        public static GType GetDummyGType ()
        {
            if (_dummyGType == GType.Invalid) {
                _dummyGType = g_type_register_static_simple(GType.Object,
                    GMarshal.StringToUtf8Ptr(dummyTypeName),
                    new UIntPtr (256), IntPtr.Zero, new UIntPtr (32), IntPtr.Zero, 0);
            }

            return _dummyGType;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_type_register_static_simple (
            GType parentType,
            IntPtr typeName,
            UIntPtr classSize,
            IntPtr classInit,
            UIntPtr instanceSize,
            IntPtr instanceInit,
            uint flags);
    }
}
