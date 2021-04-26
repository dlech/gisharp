// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GdkPixbuf;
using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.GdkPixbuf
{
    public class PixbufFormatTests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(PixbufFormat).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GdkPixbufFormat"));
        }
    }
}
