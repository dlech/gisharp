// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

﻿using System;

using NUnit.Framework;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Test.Core.GObject
{
    public class EnumTests : Tests
    {
        [Test]
        public void TestRegister1()
        {
            // invalid because TestEnum1 does not have [GType] attribute so it
            // can't be registered.
            Assert.That(() => GType.Of<TestEnum1>(), Throws.ArgumentException);
        }

        [Test]
        public void TestRegister2 ()
        {
            // invalid because underlying type is too big.
            Assert.That(() => GType.Of<TestEnum2>(),
                Throws.ArgumentException);
        }

        [Test]
        public void TestRegister3 ()
        {
            // invalid because IsProxyForUnmanagedType = true but there is no
            // matching GType property.
            Assert.That(() => GType.Of<TestEnum3>(),
                Throws.ArgumentException);
        }

        [Test]
        public void TestRegister4 ()
        {
            // this should register successfully
            var testEnum4GType = GType.Of<TestEnum4>();
            Assert.That (testEnum4GType, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register an enum");

            // make sure the type is not re-registed.
            Assert.That(testEnum4GType, Is.EqualTo (GType.Of<TestEnum4>()));

            // a couple more GType checks
            Assert.That ((Type)testEnum4GType, Is.EqualTo (typeof (TestEnum4)));
            Assert.That (testEnum4GType.IsA (GType.Enum), Is.True);

            // make sure that we set the typename, value name and value nick
            Assert.That<string?>(testEnum4GType.Name, Is.EqualTo("GISharp-Test-Core-GObject-EnumTests+TestEnum4"));
            using (var enum4TypeClass = (EnumClass)TypeClass.Get (testEnum4GType)) {
                var value = GISharp.Lib.GObject.Enum.GetValue(enum4TypeClass, 1);
                Assert.That (value.Value, Is.EqualTo ((int)TestEnum4.One));
                Assert.That<string>(value.Name, Is.EqualTo("One"));
                Assert.That<string>(value.Nick, Is.EqualTo("One"));
            }
        }

        [Test]
        public void TestRegister5 ()
        {
            // make sure that we can override name and nick with attributes
            var testEnum5GType = GType.Of<TestEnum5>();
            Assert.That<string?>(testEnum5GType.Name, Is.EqualTo("TestEnum5GTypeName"));
            using (var enum5TypeClass = (EnumClass)TypeClass.Get (testEnum5GType)) {
                var value1 = GISharp.Lib.GObject.Enum.GetValue (enum5TypeClass, 1);
                Assert.That (value1.Value, Is.EqualTo ((int)TestEnum5.One));
                Assert.That<string>(value1.Name, Is.EqualTo("test_enum_5_value_one"));
                Assert.That<string>(value1.Nick, Is.EqualTo("One"));

                var value2 = GISharp.Lib.GObject.Enum.GetValue (enum5TypeClass, 2);
                Assert.That (value2.Value, Is.EqualTo ((int)TestEnum5.Two));
                Assert.That<string>(value2.Name, Is.EqualTo("Two"));
                Assert.That<string>(value2.Nick, Is.EqualTo("test_enum_5_value_two"));
            }
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
            [GEnumMember ("test_enum_5_value_one")]
            One = 1,
            [GEnumMember (nick: "test_enum_5_value_two")]
            Two = 2,
            Four = 4,
        }
    }
}
