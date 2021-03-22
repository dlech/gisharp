// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;

using NUnit.Framework;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Test.GObject
{
    public class FlagsTests
    {
        [Test]
        public void TestRegister1()
        {
            // invalid because TestFlags1 does not have [GType] attribute so it
            // can't be registered
            Assert.That(() => typeof(TestFlags1).ToGType(), Throws.ArgumentException);
        }

        [Test]
        public void TestRegister2()
        {
            // invalid because underlying type is too big.
            Assert.That(() => typeof(TestFlags2).ToGType(),
                Throws.ArgumentException);
        }

        [Test]
        public void TestRegister3()
        {
            // invalid because IsProxyForUnmanagedType = true but there is not
            // a matching _GType property.
            Assert.That(() => typeof(TestFlags3).ToGType(),
                Throws.ArgumentException);
        }

        [Test]
        public void TestRegister4()
        {
            // this should register successfully
            var testFlags4GType = typeof(TestFlags4).ToGType();
            Assert.That(testFlags4GType, Is.Not.EqualTo(GType.Invalid),
                         "Failed to register flags");

            // make sure the type is not re-registed.
            Assert.That(testFlags4GType, Is.EqualTo(typeof(TestFlags4).ToGType()));

            // a couple more GType checks
            Assert.That(testFlags4GType.ToType(), Is.EqualTo(typeof(TestFlags4)));
            Assert.That(testFlags4GType.IsA(GType.Flags), Is.True);

            // make sure that we set the typename, value name and value nick
            Assert.That(testFlags4GType.Name, Is.EqualTo("GISharp-Test-GObject-FlagsTests+TestFlags4"));
            using var flags4TypeClass = (FlagsClass)TypeClass.Get(testFlags4GType);
            var value = Flags.GetFirstValue(flags4TypeClass, 1);
            Assert.That(value.Value, Is.EqualTo((int)TestFlags4.One));
            Assert.That<string>(value.Name, Is.EqualTo("One"));
            Assert.That<string>(value.Nick, Is.EqualTo("One"));

        }

        [Test]
        public void TestRegister5()
        {
            // make sure that we can override name and nick with attributes
            var testFlags5GType = typeof(TestFlags5).ToGType();
            Assert.That(testFlags5GType.Name, Is.EqualTo("TestFlags5GTypeName"));
            using var flags5TypeClass = (FlagsClass)TypeClass.Get(testFlags5GType);
            var value1 = Flags.GetFirstValue(flags5TypeClass, 1);
            Assert.That(value1.Value, Is.EqualTo((int)TestFlags5.One));
            Assert.That<string>(value1.Name, Is.EqualTo("test_flags_5_value_one"));
            Assert.That<string>(value1.Nick, Is.EqualTo("One"));

            var value2 = Flags.GetFirstValue(flags5TypeClass, 2);
            Assert.That(value2.Value, Is.EqualTo((int)TestFlags5.Two));
            Assert.That<string>(value2.Name, Is.EqualTo("Two"));
            Assert.That<string>(value2.Nick, Is.EqualTo("test_flags_5_value_two"));
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
        [Flags, GType(IsProxyForUnmanagedType = true)]
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
        [Flags, GType("TestFlags5GTypeName")]
        public enum TestFlags5
        {
            [GEnumMember("test_flags_5_value_one")]
            One = 1,
            [GEnumMember(nick: "test_flags_5_value_two")]
            Two = 2,
            Four = 4,
        }
    }
}
