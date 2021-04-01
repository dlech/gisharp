// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    public class VariantIterTests
    {
        [Test]
        public void TestNew()
        {
            using var v = new Variant(0);
            Assert.That(() => new VariantIter(v), Throws.ArgumentException);
        }

        [Test]
        public void TestNChildren()
        {
            using var vt = VariantType.String;
            using var v = new Variant(vt, UnownedCPtrArray<Variant>.Empty);
            using var iter = new VariantIter(v);
            Assert.That(iter.Count, Is.Zero);
        }

        [Test]
        public void TestNextValue()
        {
            {
                using var vt = VariantType.String;
                using var v = new Variant(vt, UnownedCPtrArray<Variant>.Empty);
                using var iter = new VariantIter(v);
                Assert.That(iter.MoveNext(), Is.False);
            }
            {
                using var vt = VariantType.String;
                using var test = new Variant("test");
                using var v = Variant.CreateArray(vt, test);
                using var iter = new VariantIter(v);
                Assert.That(iter.MoveNext(), Is.True);
                Assert.That(iter.Current, Is.EqualTo(test));
            }
        }
    }
}
