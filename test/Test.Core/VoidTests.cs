// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Runtime
{
    public class VoidTests : Tests
    {
        [Test]
        public void TestEquals()
        {
            Assert.That(Void.Default.Equals(Void.Default));
            Assert.That(Void.Default, Is.EqualTo(Void.Default));
            Assert.That(Void.Default, Is.EqualTo(default(Void)));
            Assert.That(Equals(Void.Default, Void.Default));
            Assert.That(Void.Default, Is.Not.EqualTo(null));
        }

        [Test]
        public void TestEqualityOperator()
        {
            Assert.That(Void.Default == Void.Default, Is.True);
#pragma warning disable CS8073
            Assert.That(Void.Default == null, Is.False);
#pragma warning restore CS8073
        }

        [Test]
        public void TestInequalityOperator()
        {
            Assert.That(Void.Default != Void.Default, Is.False);
#pragma warning disable CS8073
            Assert.That(Void.Default != null, Is.True);
#pragma warning restore CS8073
        }
    }
}
