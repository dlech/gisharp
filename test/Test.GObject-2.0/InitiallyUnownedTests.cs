// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using NUnit.Framework;
using static System.Reflection.BindingFlags;

namespace GISharp.Test.GObject
{
    public unsafe class InitiallyUnownedTests
    {
        [Test]
        public void TestFloatingReference()
        {
            using var obj = Object.CreateInstance<InitiallyUnowned>();
            var refCount = (uint)typeof(Object).GetProperty("RefCount", Instance | NonPublic)!.GetValue(obj)!;
            Assert.That(refCount, Is.EqualTo(1));
            Assert.That(obj.IsFloating, Is.False);
        }

        [Test]
        public void TestGType()
        {
            var gtype = typeof(InitiallyUnowned).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GInitiallyUnowned"));
        }
    }
}
