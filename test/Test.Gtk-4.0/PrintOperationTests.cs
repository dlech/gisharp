// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class PrintOperationTests
    {
        [Test]
        public void PrintCapabilitiesGType()
        {
            var gtype = typeof(PrintCapabilities).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintCapabilities"));
        }

        [Test]
        public void PrintStatusGType()
        {
            var gtype = typeof(PrintStatus).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintStatus"));
        }

        [Test]
        public void PrintOperationActionGType()
        {
            var gtype = typeof(PrintOperationAction).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintOperationAction"));
        }

        [Test]
        public void PrintOperationResultGType()
        {
            var gtype = typeof(PrintOperationResult).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintOperationResult"));
        }

        [Test]
        public void PrintErrorGType()
        {
            var gtype = typeof(PrintError).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkPrintError"));
        }

        [Test]
        public void PrintErrorQuark()
        {
            Assert.That(PrintError.General.GetGErrorDomain(),
                Is.EqualTo(PrintErrorDomain.Quark));
        }
    }
}
