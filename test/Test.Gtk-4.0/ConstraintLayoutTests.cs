// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ConstraintLayoutTests : Tests
    {
        [Test]
        public void ConstraintVflParserErrorGType()
        {
            var gtype = GType.Of<ConstraintVflParserError>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkConstraintVflParserError"));
        }

        [Test]
        public void ConstraintVflParserErrorQuark()
        {
            Assert.That(ConstraintVflParserError.InvalidSymbol.GetGErrorDomain(),
                Is.EqualTo(ConstraintVflParserErrorDomain.Quark));
        }
    }
}
