// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class RecentManagerTests
    {
        [Test]
        public void RecentManagerErrorGType()
        {
            var gtype = typeof(RecentManagerError).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkRecentManagerError"));
        }

        [Test]
        public void RecentManagerErrorQuark()
        {
            Assert.That(RecentManagerError.NotFound.GetGErrorDomain(),
                Is.EqualTo(RecentManagerErrorDomain.Quark));
        }
    }
}
