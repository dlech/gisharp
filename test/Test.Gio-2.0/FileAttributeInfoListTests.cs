// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>


using GISharp.Lib.Gio;
using NUnit.Framework;

namespace GISharp.Test.Gio
{
    public class FileAttributeInfoListTests : Tests
    {
        [Test]
        public void TestNew()
        {
            using (var list = new FileAttributeInfoList()) {
                Assert.That(list.Count, Is.Zero);
            }
        }

        [Test]
        public void TestDup()
        {
            using (var list = new FileAttributeInfoList())
            using (var list2 = list.Dup()) {
                Assert.That(list.Handle, Is.Not.EqualTo(list2.Handle));
            }
        }

        [Test]
        public void TestLookup()
        {
            using (var list = new FileAttributeInfoList()) {
                Assert.That(list.Lookup("test"), Is.Null);
            }
        }

        [Test]
        public void TestAdd()
        {
            using (var list = new FileAttributeInfoList()) {
                list.Add("test", FileAttributeType.Boolean, FileAttributeInfoFlags.None);
                Assert.That(list.Count, Is.EqualTo(1));
            }
        }
    }
}
