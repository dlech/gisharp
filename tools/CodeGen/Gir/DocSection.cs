// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class DocSection : GirNode
    {
        public string Name { get; }

        public DocSection(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            if (element.Name != gi + "docsection")
            {
                throw new ArgumentException("Requrires <docsection> element", nameof(element));
            }

            Name = element.Attribute("name").AsString();
        }
    }
}
