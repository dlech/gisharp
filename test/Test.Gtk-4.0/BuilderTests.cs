// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class BuilderTests : Tests
    {
        [Test]
        public void BuilderClosureFlagsGType()
        {
            var gtype = GType.Of<BuilderClosureFlags>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkBuilderClosureFlags"));
        }

        [Test]
        public void BuilderErrorGType()
        {
            var gtype = GType.Of<BuilderError>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkBuilderError"));
        }

        [Test]
        public void BuilderErrorQuark()
        {
            Assert.That(BuilderError.InvalidTypeFunction.GetGErrorDomain(),
                Is.EqualTo(BuilderErrorDomain.Quark));
        }
    }
}
