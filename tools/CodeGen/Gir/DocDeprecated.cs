// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class DocDeprecated : GirNode
    {
        /// <summary>
        /// Gets the documentation text
        /// </summary>
        public string Text => Element.Value;

        public DocDeprecated(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            if (element.Name != gi + "doc-deprecated") {
                throw new ArgumentException("Requrires <doc-deprecated> element", nameof(element));
            }
        }
    }
}
