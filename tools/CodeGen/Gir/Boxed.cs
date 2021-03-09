// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Boxed : GIRegisteredType
    {
        public Boxed(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != glib + "boxed") {
                throw new ArgumentException("Requrires <glib:boxed> element", nameof(element));
            }
        }
    }
}
