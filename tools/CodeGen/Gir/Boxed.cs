// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Boxed : GirNode
    {
        /// <summary>
        /// Gets the name of the boxed type.
        /// </summary>
        public string GTypeName { get; }

        /// <summary>
        /// Gets the C symbol prefix.
        /// </summary>
        public string CSymbolPrefix { get; }

        /// <summary>
        /// Gets if the C type name
        /// </summary>
        public string CTypeName { get; }

        /// <summary>
        /// Gets the name of the GLib get type function.
        /// </summary>
        public string GTypeGetter { get; }

        public Boxed(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != glib + "boxed") {
                throw new ArgumentException("Requrires <glib:boxed> element", nameof(element));
            }
            GTypeName = Element.Attribute(glib + "name").AsString();
            CSymbolPrefix = element.Attribute(c + "symbol-prefix").AsString();
            CTypeName = element.Attribute(glib + "type-name").AsString();
            GTypeGetter = element.Attribute(glib + "get-type").AsString();
        }
    }
}
