// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class PrintOperationTests : Tests
    {
        [Test]
        public void PrintStatusGType()
        {
            var gtype = GType.Of<PrintStatus>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPrintStatus"));
        }

        [Test]
        public void PrintOperationActionGType()
        {
            var gtype = GType.Of<PrintOperationAction>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPrintOperationAction"));
        }

        [Test]
        public void PrintOperationResultGType()
        {
            var gtype = GType.Of<PrintOperationResult>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPrintOperationResult"));
        }

        [Test]
        public void PrintErrorGType()
        {
            var gtype = GType.Of<PrintError>();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GtkPrintError"));
        }

        [Test]
        public void PrintErrorQuark()
        {
            Assert.That(PrintError.General.GetGErrorDomain(),
                Is.EqualTo(PrintErrorDomain.Quark));
        }
    }
}
