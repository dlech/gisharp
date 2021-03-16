// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GObject;
using GISharp.Lib.Gtk;
using NUnit.Framework;

namespace GISharp.Test.Gtk
{
    public class AssistantTests : Tests
    {
        [Test]
        public void AssistantPageTypeGtype()
        {
            var gtype = typeof(AssistantPageType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GtkAssistantPageType"));
        }
    }
}
