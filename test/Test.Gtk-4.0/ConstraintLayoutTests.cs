// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class ConstraintLayoutTests
    {
        [Test]
        public void ConstraintVflParserErrorGType()
        {
            var gtype = typeof(ConstraintVflParserError).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkConstraintVflParserError"));
        }

        [Test]
        public void ConstraintVflParserErrorQuark()
        {
            Assert.That(ConstraintVflParserError.InvalidSymbol.GetGErrorDomain(),
                Is.EqualTo(ConstraintVflParserErrorDomain.Quark));
        }
    }
}
