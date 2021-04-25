// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using NUnit.Framework;
using GISharp.Runtime;

namespace GISharp.Test.Runtime
{
    public class BooleanTests
    {
        [Test]
        public void TestSizeOf()
        {
            Assert.That(sizeof(Boolean), Is.EqualTo(sizeof(int)));
        }
    }
}
