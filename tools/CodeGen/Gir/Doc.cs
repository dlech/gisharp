// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Doc : GirNode
    {
        /// <summary>
        /// Gets the documentation text
        /// </summary>
        public string Text => Element.Value;

        public Doc(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            if (element.Name != gi + "doc") {
                throw new ArgumentException("Requrires <doc> element", nameof(element));
            }
        }
    }
}
