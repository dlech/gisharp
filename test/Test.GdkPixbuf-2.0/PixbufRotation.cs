// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GdkPixbuf;
using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.GdkPixbuf
{
    public class PixbufRotationTests
    {
        [Test]
        public void PixbufRotationGType()
        {
            var gtype = typeof(PixbufRotation).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GdkPixbufRotation"));
        }
    }
}
