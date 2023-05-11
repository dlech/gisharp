// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class SourcePosition : GirNode
    {
        public SourcePosition(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gi + "source-position")
            {
                throw new ArgumentException("Requrires <source-position> element", nameof(element));
            }
        }
    }
}
