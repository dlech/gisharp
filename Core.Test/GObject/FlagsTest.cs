using System;

using NUnit.Framework;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class FlagsTest
    {
        [Test]
        public void TestRegister ()
        {
            // invalid because it does not have [GType] attribute.
            Assert.That (() => typeof (TestFlags1).GetGType (),
                         Throws.ArgumentException);

            // invalid because underlying type is too big.
            Assert.That (() => typeof (TestFlags2).GetGType (),
                         Throws.ArgumentException);

            // invalid because IsWrappedNativeType = true but there is not
            // a matching getGType method.
            Assert.That (() => typeof (TestFlags3).GetGType (),
                         Throws.ArgumentException);

            // this should register successfully
            var testFlags4GType = typeof (TestFlags4).GetGType ();
            Assert.That (testFlags4GType, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register flags");

            // make sure the type is not re-registed.
            Assert.That (testFlags4GType, Is.EqualTo (typeof (TestFlags4).GetGType ()));

            // a couple more GType checks
            Assert.That ((Type)testFlags4GType, Is.EqualTo (typeof (TestFlags4)));
            Assert.That (testFlags4GType.IsA (GType.Flags), Is.True);


            // make sure that we set the typename, value name and value nick
            Assert.That (testFlags4GType.Name, Is.EqualTo ("GISharp-Core-Test-GObject-FlagsTest+TestFlags4"));
            var flags4TypeClassPtr = g_type_class_ref (testFlags4GType);
            try {
                var valuePtr = g_flags_get_first_value (flags4TypeClassPtr, 1);
                var value = Marshal.PtrToStructure<GFlagsValue> (valuePtr);
                Assert.That (value.Value, Is.EqualTo ((int)TestFlags4.One));
                var valueName = MarshalG.Utf8PtrToString (value.ValueName);
                Assert.That (valueName, Is.EqualTo ("One"));
                var valueNick = MarshalG.Utf8PtrToString (value.ValueNick);
                Assert.That (valueNick, Is.EqualTo ("One"));
            } finally {
                g_type_class_unref (flags4TypeClassPtr);
            }

            // make sure that we can override name and nick with attributes
            var testFlags5GType = typeof(TestFlags5).GetGType ();
            Assert.That (testFlags5GType.Name, Is.EqualTo ("TestFlags5GTypeName"));
            var flags5TypeClassPtr = g_type_class_ref (testFlags5GType);
            try {
                var value1Ptr = g_flags_get_first_value (flags5TypeClassPtr, 1);
                var value1 = Marshal.PtrToStructure<GFlagsValue> (value1Ptr);
                Assert.That (value1.Value, Is.EqualTo ((int)TestFlags5.One));
                var value1Name = MarshalG.Utf8PtrToString (value1.ValueName);
                Assert.That (value1Name, Is.EqualTo ("test_flags_5_value_one"));
                var value1Nick = MarshalG.Utf8PtrToString (value1.ValueNick);
                Assert.That (value1Nick, Is.EqualTo ("One"));

                var value2Ptr = g_flags_get_first_value (flags5TypeClassPtr, 2);
                var value2 = Marshal.PtrToStructure<GFlagsValue> (value2Ptr);
                Assert.That (value2.Value, Is.EqualTo ((int)TestFlags5.Two));
                var value2Name = MarshalG.Utf8PtrToString (value2.ValueName);
                Assert.That (value2Name, Is.EqualTo ("Two"));
                var value2Nick = MarshalG.Utf8PtrToString (value2.ValueNick);
                Assert.That (value2Nick, Is.EqualTo ("test_flags_5_value_two"));
            } finally {
                g_type_class_unref (flags5TypeClassPtr);
            }
        }

        // This type is not registered with the GType system since it does not
        // have the [GType] attribute.
        [Flags]
        public enum TestFlags1
        {
            One,
            Two,
            Three,
        }

        // This type should not be allowed because of the underlying type
        [Flags, GType]
        public enum TestFlags2 : long
        {
            One,
            Two,
            Three,
        }

        // This type should not be allowed because of IsWrappedNativeType = true
        // but there is no matching getGType method (or TestFlags3Extensions class
        // for that matter)
        [Flags, GType (IsWrappedNativeType = true)]
        public enum TestFlags3
        {
            One,
            Two,
            Three,
        }

        // This type will be regiseted with the GObject type system
        [Flags, GType]
        public enum TestFlags4
        {
            One = 1,
            Two = 2,
            Four = 4,
        }

        // This type will be regiseted with the GObject type system
        // It has attributes set to check that we can override the default names
        [Flags, GType (Name = "TestFlags5GTypeName")]
        public enum TestFlags5
        {
            [EnumValue ("test_flags_5_value_one")]
            One = 1,
            [EnumValue (nick: "test_flags_5_value_two")]
            Two = 2,
            Four = 4,
        }

        struct GFlagsValue {
            public int Value;
            public IntPtr ValueName;
            public IntPtr ValueNick;
        };

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_class_ref (GType type);
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_class_unref (IntPtr gClass);
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_flags_get_first_value (IntPtr enumClass, int value);
    }
}
