// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class FileChooserTests
    {
        [Test]
        public void FileChooserActionGType()
        {
            var gtype = typeof(FileChooserAction).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkFileChooserAction"));
        }

        [Test]
        public void FileChooserErrorGType()
        {
            var gtype = typeof(FileChooserError).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkFileChooserError"));
        }

        [Test]
        public void BuilderErrorQuark()
        {
            Assert.That(FileChooserError.Nonexistent.GetGErrorDomain(),
                Is.EqualTo(FileChooserErrorDomain.Quark));
        }
    }
}
