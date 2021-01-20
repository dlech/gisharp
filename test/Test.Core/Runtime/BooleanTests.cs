// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>


using System.Runtime.InteropServices;
using NUnit.Framework;
using GISharp.Runtime;

namespace GISharp.Test.Runtime
{
    public class BooleanTests : Tests
    {
        [Test]
        public void TestSizeOf()
        {
            Assert.That(sizeof(Boolean), Is.EqualTo(sizeof(int)));
        }
    }
}
