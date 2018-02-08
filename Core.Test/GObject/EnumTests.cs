using System;

using NUnit.Framework;
using GISharp.GObject;
using GISharp.Runtime;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class EnumTests
    {
        [Test]
        public void TestRegister1 ()
        {
            // invalid because TestEnum1 does not have [GType] attribute so it
            // gets registered as a boxed type instead of as an enum type.
            var testEnum1GType = typeof(TestEnum1).GetGType ();
            Assert.That (() => (EnumClass)TypeClass.Get (testEnum1GType),
                Throws.ArgumentException);

            AssertNoGLibLog();
        }

        [Test]
        public void TestRegister2 ()
        {
            // invalid because underlying type is too big.
            Assert.That (() => typeof (TestEnum2).GetGType (),
                Throws.ArgumentException);

            AssertNoGLibLog();
        }

        [Test]
        public void TestRegister3 ()
        {
            // invalid because IsProxyForUnmanagedType = true but there is no
            // matching GType property.
            Assert.That (() => typeof (TestEnum3).GetGType (),
                Throws.ArgumentException);

            AssertNoGLibLog();
        }

        [Test]
        public void TestRegister4 ()
        {
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
            Assert.That (testEnum4GType.Name, Is.EqualTo ("GISharp-Core-Test-GObject-EnumTests+TestEnum4"));
            using (var enum4TypeClass = (EnumClass)TypeClass.Get (testEnum4GType)) {
                var value = GISharp.GObject.Enum.GetValue (enum4TypeClass, 1);
                Assert.That (value.Value, Is.EqualTo ((int)TestEnum4.One));
                var valueName = GMarshal.Utf8PtrToString (value.ValueName);
                Assert.That (valueName, Is.EqualTo ("One"));
                var valueNick = GMarshal.Utf8PtrToString (value.ValueNick);
                Assert.That (valueNick, Is.EqualTo ("One"));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRegister5 ()
        {
            // make sure that we can override name and nick with attributes
            var testEnum5GType = typeof(TestEnum5).GetGType ();
            Assert.That (testEnum5GType.Name, Is.EqualTo ("TestEnum5GTypeName"));
            using (var enum5TypeClass = (EnumClass)TypeClass.Get (testEnum5GType)) {
                var value1 = GISharp.GObject.Enum.GetValue (enum5TypeClass, 1);
                Assert.That (value1.Value, Is.EqualTo ((int)TestEnum5.One));
                var value1Name = GMarshal.Utf8PtrToString (value1.ValueName);
                Assert.That (value1Name, Is.EqualTo ("test_enum_5_value_one"));
                var value1Nick = GMarshal.Utf8PtrToString (value1.ValueNick);
                Assert.That (value1Nick, Is.EqualTo ("One"));

                var value2 = GISharp.GObject.Enum.GetValue (enum5TypeClass, 2);
                Assert.That (value2.Value, Is.EqualTo ((int)TestEnum5.Two));
                var value2Name = GMarshal.Utf8PtrToString (value2.ValueName);
                Assert.That (value2Name, Is.EqualTo ("Two"));
                var value2Nick = GMarshal.Utf8PtrToString (value2.ValueNick);
                Assert.That (value2Nick, Is.EqualTo ("test_enum_5_value_two"));
            }

            AssertNoGLibLog();
        }

        // This type is registered as a boxed type with the GType system since
        // it does not have the [GType] attribute.
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

        // This type should not be allowed because of IsProxyForUnmanagedType = true
        // but there is no GType property (or a matching TestEnum3Extension class
        // for that matter).
        [GType (IsProxyForUnmanagedType = true)]
        public enum TestEnum3
        {
            One,
            Two,
            Three,
        }

        // This type will be registered with the GObject type system
        [GType]
        public enum TestEnum4
        {
            One = 1,
            Two = 2,
            Four = 4,
        }

        // This type will be registered with the GObject type system
        // It has attributes set to check that we can override the default names
        [GType ("TestEnum5GTypeName")]
        public enum TestEnum5
        {
            [EnumValue ("test_enum_5_value_one")]
            One = 1,
            [EnumValue (nick: "test_enum_5_value_two")]
            Two = 2,
            Four = 4,
        }
    }
}
