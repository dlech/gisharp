// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GObject
{
    public class BoxedTests : Tests
    {
        [Test]
        public void TestBoxingManagedType()
        {
            var expected = new object();
            using (var b = new Boxed<object>(expected)) {
                Assert.That(b.Value, Is.EqualTo(expected));
            }
            using (var b = new Boxed<object?>(null)) {
                Assert.That(b.Value, Is.Null);
            }
        }

#if false
        [Test]
        public void TestGType()
        {
            var gtype = typeof(Boxed).ToGType();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GBoxed"));

            gtype = typeof(Boxed<object>).ToGType();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GISharp-Lib-GObject-Boxed--of--1System-Object"));
        }
#endif
    }
}
