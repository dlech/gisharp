using System;

using NUnit.Framework;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class EnumTest
    {
        [Test]
        public void TestRegister ()
        {
            // invalid because it does not have [GType] attribute.
            Assert.That (() => typeof (TestEnum1).GetGType (),
                         Throws.ArgumentException);

            // invalid because underlying type is too big.
            Assert.That (() => typeof (TestEnum2).GetGType (),
                         Throws.ArgumentException);

            // invalid because IsWrappedNativeType = true but there is no
            // matching getGType method.
            Assert.That (() => typeof (TestEnum3).GetGType (),
                         Throws.ArgumentException);

            // this should register successfully
            var testEnum4GType = typeof (TestEnum4).GetGType ();
            Assert.That (testEnum4GType, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register an enum");

            // make sure the type is not re-registed.
            Assert.That (testEnum4GType, Is.EqualTo (typeof (TestEnum4).GetGType ()));

            // a couple more GType checks
            Assert.That ((Type)testEnum4GType, Is.EqualTo (typeof (TestEnum4)));
            Assert.That (testEnum4GType.IsA (GType.Enum), Is.True);

            // make sure that we set the typename, value name and value nick
            Assert.That (testEnum4GType.Name, Is.EqualTo ("GISharp-Core-Test-GObject-EnumTest+TestEnum4"));
            var enum4TypeClassPtr = g_type_class_ref (testEnum4GType);
            try {
                var valuePtr = g_enum_get_value (enum4TypeClassPtr, 1);
                var value = Marshal.PtrToStructure<GEnumValue> (valuePtr);
                Assert.That (value.Value, Is.EqualTo ((int)TestEnum4.One));
                var valueName = MarshalG.Utf8PtrToString (value.ValueName);
                Assert.That (valueName, Is.EqualTo ("One"));
                var valueNick = MarshalG.Utf8PtrToString (value.ValueNick);
                Assert.That (valueNick, Is.EqualTo ("One"));
            } finally {
                g_type_class_unref (enum4TypeClassPtr);
            }

            // make sure that we can override name and nick with attributes
            var testEnum5GType = typeof(TestEnum5).GetGType ();
            Assert.That (testEnum5GType.Name, Is.EqualTo ("TestEnum5GTypeName"));
            var enum5TypeClassPtr = g_type_class_ref (testEnum5GType);
            try {
                var value1Ptr = g_enum_get_value (enum5TypeClassPtr, 1);
                var value1 = Marshal.PtrToStructure<GEnumValue> (value1Ptr);
                Assert.That (value1.Value, Is.EqualTo ((int)TestEnum5.One));
                var value1Name = MarshalG.Utf8PtrToString (value1.ValueName);
                Assert.That (value1Name, Is.EqualTo ("test_enum_5_value_one"));
                var value1Nick = MarshalG.Utf8PtrToString (value1.ValueNick);
                Assert.That (value1Nick, Is.EqualTo ("One"));

                var value2Ptr = g_enum_get_value (enum5TypeClassPtr, 2);
                var value2 = Marshal.PtrToStructure<GEnumValue> (value2Ptr);
                Assert.That (value2.Value, Is.EqualTo ((int)TestEnum5.Two));
                var value2Name = MarshalG.Utf8PtrToString (value2.ValueName);
                Assert.That (value2Name, Is.EqualTo ("Two"));
                var value2Nick = MarshalG.Utf8PtrToString (value2.ValueNick);
                Assert.That (value2Nick, Is.EqualTo ("test_enum_5_value_two"));
            } finally {
                g_type_class_unref (enum5TypeClassPtr);
            }
        }

        // This type is not registered with the GType system since it does not
        // have the [GType] attribute.
        public enum TestEnum1
        {
            One,
            Two,
            Three,
        }

        // This type should not be allowed because of the underlying type
        [GType]
        public enum TestEnum2 : long
        {
            One,
            Two,
            Three,
        }

        // This type should not be allowed because of IsWrappedNativeType = true
        // but there is no getGType method (or a matching TestEnum3Extension class
        // for that matter).
        [GType (IsWrappedNativeType = true)]
        public enum TestEnum3
        {
            One,
            Two,
            Three,
        }

        // This type will be regiseted with the GObject type system
        [GType]
        public enum TestEnum4
        {
            One = 1,
            Two = 2,
            Four = 4,
        }

        // This type will be regiseted with the GObject type system
        // It has attributes set to check that we can override the default names
        [GType (Name = "TestEnum5GTypeName")]
        public enum TestEnum5
        {
            [EnumValue ("test_enum_5_value_one")]
            One = 1,
            [EnumValue (nick: "test_enum_5_value_two")]
            Two = 2,
            Four = 4,
        }

        struct GEnumValue {
            public int Value;
            public IntPtr ValueName;
            public IntPtr ValueNick;
        };

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_class_ref (GType type);
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_class_unref (IntPtr gClass);
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_enum_get_value (IntPtr enumClass, int value);
    }
}
