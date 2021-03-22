// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    [TestOf(typeof(VariantParseError))]
    public class VariantParseErrorTests
    {
        [Test]
        public void TestQuark()
        {
            Assert.That(default(VariantParseError).GetGErrorDomain(),
                Is.EqualTo(VariantParseErrorDomain.Quark));
        }

        [Test]
        public void TestPrintContext()
        {
            using Utf8 badSourceStr = "(1, 2, 3, 'abc";
            using var err = new Error(TestError.Failed, "test");
            Assert.That(() => err.PrintContext(badSourceStr), Throws.ArgumentException);

            var exception = Assert.Throws<GErrorException>(() => Variant.Parse(null, badSourceStr));
            Assert.That(exception.Matches(VariantParseError.UnterminatedStringConstant));
            Assert.That(exception.Error.PrintContext(badSourceStr), Is.Not.Null);
        }
    }
}
