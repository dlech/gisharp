// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019 David Lechner <david@lechnology.com>

﻿using System;
using System.Linq;
using System.Xml.Linq;
using Gtk;

namespace GISharp.GirBrowser
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Application.Init ();
            var win = new MainWindow ();
            win.Show ();
            Application.Run ();
        }
    }
}
