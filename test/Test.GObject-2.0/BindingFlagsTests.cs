// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using NUnit.Framework;
using GISharp.Lib.GObject;

namespace GISharp.Test.GObject
{
    public class BindingFlagsTests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(BindingFlags).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GBindingFlags"));
        }
    }
}
