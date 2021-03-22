// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System.Runtime.CompilerServices;
using GISharp.Lib.Gio;
using NUnit.Framework;

namespace GISharp.Test.Gio
{
    public class FileAttributeInfoListTests
    {
        [Test]
        public void TestNew()
        {
            using var list = new FileAttributeInfoList();
            Assert.That(list.Count, Is.Zero);
        }

        [Test]
        public void TestDup()
        {
            using var list = new FileAttributeInfoList();
            using var list2 = list.Dup();
            Assert.That(list.UnsafeHandle, Is.Not.EqualTo(list2.UnsafeHandle));
        }

        [Test]
        public void TestLookup()
        {
            using var list = new FileAttributeInfoList();
            ref readonly var info = ref list.Lookup("test");
            Assert.That(Unsafe.IsNullRef(ref Unsafe.AsRef(info)), Is.True);
        }

        [Test]
        public void TestAdd()
        {
            using var list = new FileAttributeInfoList {
                { "test", FileAttributeType.Boolean, FileAttributeInfoFlags.None }
            };
            Assert.That(list.Count, Is.EqualTo(1));
        }
    }
}
