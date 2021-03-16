// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

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

namespace GISharp.Test.GObject
{
    public class GTypeTests : Tests
    {
        [Test]
        public void TestNone()
        {
            Assert.That(GType.None.ToType(), Is.EqualTo(typeof(void)));
        }

        [Test]
        public void TestInterface()
        {
            Assert.That(() => GType.Interface.ToType(), Is.EqualTo(typeof(GInterface<>)));
        }

        [Test]
        public void TestChar()
        {
            Assert.That(GType.Char.ToType(), Is.EqualTo(typeof(sbyte)));
        }

        [Test]
        public void TestUChar()
        {
            Assert.That(GType.UChar.ToType(), Is.EqualTo(typeof(byte)));
        }

        [Test]
        public void TestBoolean()
        {
            Assert.That(GType.Boolean.ToType(), Is.EqualTo(typeof(bool)));
        }

        [Test]
        public void TestInt()
        {
            Assert.That(GType.Int.ToType(), Is.EqualTo(typeof(int)));
        }

        [Test]
        public void TestUInt()
        {
            Assert.That(GType.UInt.ToType(), Is.EqualTo(typeof(uint)));
        }

        [Test]
        public void TestLong()
        {
            Assert.That(() => GType.Long.ToType(), Is.EqualTo(typeof(clong)));
        }

        [Test]
        public void TestULong()
        {
            Assert.That(() => GType.ULong.ToType(), Is.EqualTo(typeof(culong)));
        }

        [Test]
        public void TestInt64()
        {
            Assert.That(GType.Int64.ToType(), Is.EqualTo(typeof(long)));
        }

        [Test]
        public void TestUInt64()
        {
            Assert.That(GType.UInt64.ToType(), Is.EqualTo(typeof(ulong)));
        }

        [Test]
        public void TestEnum()
        {
            Assert.That(GType.Enum.ToType(), Is.EqualTo(typeof(System.Enum)));
        }

        [Test]
        public void TestFlags()
        {
            Assert.That(() => GType.Flags.ToType(), Is.EqualTo(typeof(System.Enum)));
        }

        [Test]
        public void TestFloat()
        {
            Assert.That(GType.Float.ToType(), Is.EqualTo(typeof(float)));
        }

        [Test]
        public void TestDouble()
        {
            Assert.That(GType.Double.ToType(), Is.EqualTo(typeof(double)));
        }

        [Test]
        public void TestString()
        {
            Assert.That(GType.String.ToType(), Is.EqualTo(typeof(Utf8)));
        }

        [Test]
        public void TestPointer()
        {
            Assert.That(GType.Pointer.ToType(), Is.EqualTo(typeof(IntPtr)));
        }

        [Test]
        public void TestBoxed()
        {
            Assert.That(GType.Boxed.ToType(), Is.EqualTo(typeof(Boxed)));
        }

        [Test]
        public void TestParam()
        {
            Assert.That(GType.Param.ToType(), Is.EqualTo(typeof(ParamSpec)));
        }

        [Test]
        public void TestObject()
        {
            Assert.That(GType.Object.ToType(), Is.EqualTo(typeof(GISharp.Lib.GObject.Object)));
        }

        [Test]
        public void TestGType()
        {
            Assert.That(GType.Type.ToType(), Is.EqualTo(typeof(GType)));
        }

        [Test]
        public void TestVariant()
        {
            Assert.That(GType.Variant.ToType(), Is.EqualTo(typeof(Variant)));
        }

        [Test]
        public void TestGetGTypeName()
        {
            Assert.That(typeof(GType).GetGTypeName(), Is.EqualTo("GType"));
        }

        [Test]
        public void TestName()
        {
            Assert.That(GType.Invalid.Name, Is.Null);
            Assert.That(GType.None.Name, Is.EqualTo("void"));
        }

        [Test]
        public void TestParent()
        {
            Assert.That(GType.Invalid.Parent, Is.EqualTo(GType.Invalid));
            Assert.That(GType.None.Parent, Is.EqualTo(GType.Invalid));
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
        public void TestIsA()
        {
            Assert.That(GType.Invalid.IsA(GType.Invalid), Is.True);
            Assert.That(GType.None.IsA(GType.None), Is.True);
            Assert.That(GType.None.IsA(GType.Boolean), Is.False);
        }

        [Test]
        public void TestFromName()
        {
            Assert.That(GType.FromName("void"), Is.EqualTo(GType.None));
            Assert.That(GType.FromName("there-should-never-be-a-type-with-this-name"),
                         Is.EqualTo(GType.Invalid));
            Assert.That(() => GType.FromName("name has invalid characters"),
                         Throws.ArgumentException);
        }

        [Test]
        public void TestEqualityOperator()
        {
            Assert.That(GType.Invalid == GType.Invalid, Is.True);
            Assert.That(GType.Invalid == GType.None, Is.False);
        }

        [Test]
        public void TestInequalityOperator()
        {
            Assert.That(GType.Invalid != GType.None, Is.True);
            Assert.That(GType.Invalid != GType.Invalid, Is.False);
        }

        [Test]
        public void TestEquals()
        {
            Assert.That(GType.Invalid.Equals(GType.Invalid), Is.True);
            Assert.That(GType.Invalid.Equals(GType.None), Is.False);
            Assert.That(GType.Invalid.Equals(new object()), Is.False);
        }

        [Test]
        public void TestTypeOfUnregisteredManagedType()
        {
            // This tests that if a GType is received from unmanged code
            // that has never been initialized in managed code.

            const string testName = "TestTypeOfUnregisteredManagedType";

            // first we register the type in unmanged code and make sure that
            // it throws an exception because there is no matching type in
            // managed code.

            var gtype = GetDummyGType();
            // TODO: Need more specific type of exception
            Assert.That(() => gtype.ToType(), Throws.Exception);

            // then we dynamically generate a matching managed type

            var asmBuilder = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName(testName + "_assembly"),
                AssemblyBuilderAccess.Run);
            var modBuilder = asmBuilder.DefineDynamicModule(testName + "_module");
            var typeBuilder = modBuilder.DefineType(testName + "_type",
                TypeAttributes.Public);
            var gtypeAttribute = typeof(GTypeAttribute);
            typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(
                gtypeAttribute.GetConstructors().Single(),
                new object[] { dummyTypeName },
                new PropertyInfo[] {
                    gtypeAttribute.GetProperty("IsProxyForUnmanagedType")!,
                },
                new object[] {
                    true, // IsProxyForUnmanagedType
                }));
            var gtypeStructAttribute = typeof(GTypeStructAttribute);
            typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(
                gtypeStructAttribute.GetConstructors().Single(),
                new object[] { typeof(ObjectClass) },
                System.Array.Empty<FieldInfo>(), System.Array.Empty<object>()));

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

            var expectedType = typeBuilder.CreateType();

            // and try the test again

            var actualType = gtype.ToType();
            Assert.That(actualType, Is.EqualTo(expectedType));
        }

        const string dummyTypeName = "GTypeTestDummyType";
        static GType _dummyGType;
        public static GType GetDummyGType()
        {
            if (_dummyGType == GType.Invalid) {
                _dummyGType = g_type_register_static_simple(GType.Object,
                    GMarshal.StringToUtf8Ptr(dummyTypeName),
                    new UIntPtr(256), IntPtr.Zero, new UIntPtr(32), IntPtr.Zero, 0);
            }

            return _dummyGType;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_type_register_static_simple(
            GType parentType,
            IntPtr typeName,
            UIntPtr classSize,
            IntPtr classInit,
            UIntPtr instanceSize,
            IntPtr instanceInit,
            uint flags);
    }
}
