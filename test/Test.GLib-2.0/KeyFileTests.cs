// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using NUnit.Framework;

using GISharp.Lib.GLib;

using static GISharp.TestHelpers;

namespace GISharp.Test.GLib
{
    [TestOf(typeof(KeyFile))]
    public class KeyFileTests : Tests
    {
        static readonly Utf8 TestGroup = "TestGroup";
        static readonly Utf8 TestKey1 = "TestKey1";
        static readonly Utf8 TestKey2 = "TestKey2";

        [Test]
        public void TestString()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetString(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            using (var expected = (Utf8)"Test String") {
                keyFile.SetString(TestGroup, TestKey1, expected);
                var actual = keyFile.GetString(TestGroup, TestKey1);
                Assert.That<string>(actual, Is.EqualTo(expected));
            }

            Assert.That(() => keyFile.GetString(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestBoolean()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetBoolean(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            const bool expected = true;
            keyFile.SetBoolean(TestGroup, TestKey1, expected);
            var actual = keyFile.GetBoolean(TestGroup, TestKey1);
            Assert.That(actual, Is.EqualTo(expected));

            Assert.That(() => keyFile.GetBoolean(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestInteger()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetInteger(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            const int expected = 1;
            keyFile.SetInteger(TestGroup, TestKey1, expected);
            var actual = keyFile.GetInteger(TestGroup, TestKey1);
            Assert.That(actual, Is.EqualTo(expected));

            Assert.That(() => keyFile.GetInteger(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestInt64()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetInt64(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            const long expected = 1;
            keyFile.SetInt64(TestGroup, TestKey1, expected);
            var actual = keyFile.GetInt64(TestGroup, TestKey1);
            Assert.That(actual, Is.EqualTo(expected));

            Assert.That(() => keyFile.GetInt64(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestUInt64()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetUint64(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            const ulong expected = 1;
            keyFile.SetUint64(TestGroup, TestKey1, expected);
            var actual = keyFile.GetUint64(TestGroup, TestKey1);
            Assert.That(actual, Is.EqualTo(expected));

            Assert.That(() => keyFile.GetUint64(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestDouble()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetDouble(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            const double expected = 1;
            keyFile.SetDouble(TestGroup, TestKey1, expected);
            var actual = keyFile.GetDouble(TestGroup, TestKey1);
            Assert.That(actual, Is.EqualTo(expected));

            Assert.That(() => keyFile.GetDouble(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestStringList()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetStringList(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            using (var expected = new PtrArray<Utf8> { "Item 1", "Item 2" }) {
                keyFile.SetStringList(TestGroup, TestKey1, expected);
                var actual = keyFile.GetStringList(TestGroup, TestKey1);
                Assert.That(actual, Is.EqualTo(expected));
            }

            Assert.That(() => keyFile.GetStringList(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestBooleanList()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetBooleanList(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            var expected = new Runtime.Boolean[] { Runtime.Boolean.True, Runtime.Boolean.False };
            keyFile.SetBooleanList(TestGroup, TestKey1, expected);
            var actual = keyFile.GetBooleanList(TestGroup, TestKey1);
            Assert.That(actual, Is.EquivalentTo(expected));

            Assert.That(() => keyFile.GetBooleanList(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestIntegerList()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetIntegerList(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            var expected = new int[] { 1, 2 };
            keyFile.SetIntegerList(TestGroup, TestKey1, expected);
            var actual = keyFile.GetIntegerList(TestGroup, TestKey1);
            Assert.That(actual, Is.EquivalentTo(expected));

            Assert.That(() => keyFile.GetIntegerList(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }

        [Test]
        public void TestDoubleList()
        {
            using var keyFile = new KeyFile();
            Assert.That(() => keyFile.GetDoubleList(TestGroup, TestKey1),
                ThrowsGErrorException(KeyFileError.GroupNotFound),
                "Trying to get a non-existant group should throw an exception");

            var expected = new double[] { 1, 2 };
            keyFile.SetDoubleList(TestGroup, TestKey1, expected);
            var actual = keyFile.GetDoubleList(TestGroup, TestKey1);
            Assert.That(actual, Is.EquivalentTo(expected));

            Assert.That(() => keyFile.GetDoubleList(TestGroup, TestKey2),
                ThrowsGErrorException(KeyFileError.KeyNotFound),
                "Trying to get a non-existant key should throw an exception");
        }
    }
}
