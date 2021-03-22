// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

using System.Linq;

using NUnit.Framework;

using GISharp.Lib.GLib;

namespace GISharp.Test.GLib
{
    public class VariantTypeTests
    {
        [Test]
        public void TestIsMaybe()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(vt.IsMaybe, Is.False);
            }

            using (var vt = VariantType.Maybe) {
                Assert.That(vt.IsMaybe, Is.True);
            }
        }

        [Test]
        public void TestIsArray()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(vt.IsArray, Is.False);
            }

            using (var vt = VariantType.Array) {
                Assert.That(vt.IsArray, Is.True);
            }
        }

        [Test]
        public void TestIsTuple()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(vt.IsTuple, Is.False);
            }

            using (var vt = VariantType.Tuple) {
                Assert.That(vt.IsTuple, Is.True);
            }
        }

        [Test]
        public void TestIsDictEntry()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(vt.IsDictionaryEntry, Is.False);
            }

            using (var vt = VariantType.DictionaryEntry) {
                Assert.That(vt.IsDictionaryEntry, Is.True);
            }
        }

        [Test]
        public void TestIsVariant()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(vt.IsVariant, Is.False);
            }

            using (var vt = VariantType.Variant) {
                Assert.That(vt.IsVariant, Is.True);
            }
        }

        [Test]
        public void TestEqual()
        {
            using var a = VariantType.Int32;
            using var b = new VariantType("i");
            Assert.That(a, Is.EqualTo(b));
            Assert.That(a == b, Is.True);
            Assert.That(a != b, Is.False);
        }

        [Test]
        public void TestIsSubtypeOf()
        {
            using var array = VariantType.Array;
            using var stringArray = VariantType.StringArray;
            Assert.That(stringArray.IsSubtypeOf(array), Is.True);
            Assert.That(array.IsSubtypeOf(stringArray), Is.False);
        }

        [Test]
        public void TestNewMaybe()
        {
            using var element = VariantType.String;
            using var vt = VariantType.CreateMaybe(element);
            Assert.That(vt.ToString(), Is.EqualTo("ms"));
        }

        [Test]
        public void TestNewArray()
        {
            using var element = VariantType.String;
            using var vt = VariantType.CreateArray(element);
            Assert.That(vt.ToString(), Is.EqualTo("as"));
        }

        [Test]
        public void TestNewTuple()
        {
            using var a = VariantType.String;
            using var b = VariantType.Variant;
            using var vt = VariantType.CreateTuple(a, b);
            Assert.That(vt.ToString(), Is.EqualTo("(sv)"));
        }

        [Test]
        public void TestNewDictEntry()
        {
            using var key = VariantType.String;
            using var value = VariantType.Variant;
            using var vt = VariantType.CreateDictEntry(key, value);
            Assert.That(vt.ToString(), Is.EqualTo("{sv}"));
        }

        [Test]
        public void TestElement()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(() => vt.ElementType, Throws.InvalidOperationException);
            }

            using (var any = VariantType.Any)
            using (var vt = VariantType.Array)
            using (var element = vt.ElementType) {
                Assert.That(element, Is.EqualTo(any));
            }

            using (var any = VariantType.Any)
            using (var vt = VariantType.Maybe)
            using (var element = vt.ElementType) {
                Assert.That(element, Is.EqualTo(any));
            }
        }

        [Test]
        public void TestNItems()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(() => vt.Count, Throws.InvalidOperationException);
            }

            using (var vt = VariantType.Tuple) {
                Assert.That(() => vt.Count, Throws.InvalidOperationException);
            }

            using (var vt = VariantType.Unit) {
                Assert.That(vt.Count, Is.Zero);
            }

            using (var basic = VariantType.Basic)
            using (var any = VariantType.Any)
            using (var vt = VariantType.DictionaryEntry) {
                Assert.That(vt.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void TestFirstNext()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(() => vt.Items.Any(), Throws.InvalidOperationException);
            }

            using (var vt = VariantType.Tuple) {
                Assert.That(() => vt.Items.Any(), Throws.InvalidOperationException);
            }

            using (var vt = VariantType.Unit) {
                Assert.That(vt.Items.Count(), Is.Zero);
            }

            using (var basic = VariantType.Basic)
            using (var any = VariantType.Any)
            using (var vt = VariantType.DictionaryEntry) {
                var items = vt.Items.ToArray();
                Assert.That(items.Length, Is.EqualTo(2));
                Assert.That(items[0], Is.EqualTo(basic));
                Assert.That(items[1], Is.EqualTo(any));
            }
        }

        [Test]
        public void TestKey()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(() => vt.Key, Throws.InvalidOperationException);
            }

            using (var basic = VariantType.Basic)
            using (var vt = VariantType.DictionaryEntry) {
                Assert.That(vt.Key, Is.EqualTo(basic));
            }
        }

        [Test]
        public void TestValue()
        {
            using (var vt = VariantType.Int32) {
                Assert.That(() => vt.Value, Throws.InvalidOperationException);
            }

            using (var any = VariantType.Any)
            using (var vt = VariantType.DictionaryEntry) {
                Assert.That(vt.Value, Is.EqualTo(any));
            }
        }
    }
}
