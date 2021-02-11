// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using NUnit.Framework;
using GISharp.Lib.GObject;

namespace GISharp.Test.Core.GObject
{
    public class BindingFlagsTests : Tests
    {
        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<BindingFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GBindingFlags"));
        }
    }
}
