// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>


using GISharp.Lib.Gio;
using NUnit.Framework;

namespace GISharp.Test.Gio
{
    public class IconTests
    {
        [Test]
        public void TestEverything()
        {
            using var expected = IIcon.NewForString("file");
            using var serialized = expected.Serialize();
            Assert.That(serialized, Is.Not.Null);
            using var actual = IIcon.Deserialize(serialized!);
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
