using System;

using NUnit.Framework;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Test.Core.GObject
{
    public class FlagsTests : Tests
    {
        [Test]
        public void TestRegister1()
        {
            // invalid because TestFlags1 does not have [GType] attribute so it
            // can't be registered
            Assert.That(() => GType.Of<TestFlags1>(), Throws.ArgumentException);
        }

        [Test]
        public void TestRegister2 ()
        {
            // invalid because underlying type is too big.
            Assert.That(() => GType.Of<TestFlags2>(),
                Throws.ArgumentException);
        }

        [Test]
        public void TestRegister3 ()
        {
            // invalid because IsProxyForUnmanagedType = true but there is not
            // a matching _GType property.
            Assert.That(() => GType.Of<TestFlags3>(),
                Throws.ArgumentException);
        }

        [Test]
        public void TestRegister4 ()
        {
            // this should register successfully
            var testFlags4GType = GType.Of<TestFlags4>();
            Assert.That (testFlags4GType, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register flags");

            // make sure the type is not re-registed.
            Assert.That(testFlags4GType, Is.EqualTo (GType.Of<TestFlags4>()));

            // a couple more GType checks
            Assert.That ((Type)testFlags4GType, Is.EqualTo (typeof (TestFlags4)));
            Assert.That (testFlags4GType.IsA (GType.Flags), Is.True);

            // make sure that we set the typename, value name and value nick
            Assert.That<string?>(testFlags4GType.Name, Is.EqualTo("GISharp-Test-Core-GObject-FlagsTests+TestFlags4"));
            using (var flags4TypeClass = (FlagsClass)TypeClass.Get (testFlags4GType)) {
                var value = Flags.GetFirstValue (flags4TypeClass, 1);
                Assert.That (value.Value, Is.EqualTo ((int)TestFlags4.One));
                Assert.That<string>(value.Name, Is.EqualTo("One"));
                Assert.That<string>(value.Nick, Is.EqualTo("One"));
            }

        }

        [Test]
        public void TestRegister5 ()
        {
            // make sure that we can override name and nick with attributes
            var testFlags5GType = GType.Of<TestFlags5>();
            Assert.That<string?>(testFlags5GType.Name, Is.EqualTo("TestFlags5GTypeName"));
            using (var flags5TypeClass = (FlagsClass)TypeClass.Get (testFlags5GType)) {
                var value1 = Flags.GetFirstValue (flags5TypeClass, 1);
                Assert.That (value1.Value, Is.EqualTo ((int)TestFlags5.One));
                Assert.That<string>(value1.Name, Is.EqualTo("test_flags_5_value_one"));
                Assert.That<string>(value1.Nick, Is.EqualTo("One"));

                var value2 = Flags.GetFirstValue (flags5TypeClass, 2);
                Assert.That (value2.Value, Is.EqualTo ((int)TestFlags5.Two));
                Assert.That<string>(value2.Name, Is.EqualTo("Two"));
                Assert.That<string>(value2.Nick, Is.EqualTo("test_flags_5_value_two"));
            }
        }

        // This type is registered as a boxed type with the GType system since
        // it does not have the [GType] attribute.
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

        // This type should not be allowed because of IsProxyForUnmanagedType = true
        // but there is no matching _GType property (or TestFlags3Extensions class
        // for that matter)
        [Flags, GType (IsProxyForUnmanagedType = true)]
        public enum TestFlags3
        {
            One,
            Two,
            Three,
        }

        // This type will be registered with the GObject type system
        [Flags, GType]
        public enum TestFlags4
        {
            One = 1,
            Two = 2,
            Four = 4,
        }

        // This type will be registered with the GObject type system
        // It has attributes set to check that we can override the default names
        [Flags, GType ("TestFlags5GTypeName")]
        public enum TestFlags5
        {
            [GEnumMember ("test_flags_5_value_one")]
            One = 1,
            [GEnumMember (nick: "test_flags_5_value_two")]
            Two = 2,
            Four = 4,
        }
    }
}
