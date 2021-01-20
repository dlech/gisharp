// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>


using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.Core.GObject
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

        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<Boxed>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GBoxed"));

            gtype = GType.Of<Boxed<object>>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GISharp-Lib-GObject-Boxed--of--1System-Object"));
        }
    }
}
