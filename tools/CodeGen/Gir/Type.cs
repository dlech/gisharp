// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Type : GIType
    {
        public Type(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gi + "type")
            {
                throw new ArgumentException("Requrires <type> element", nameof(element));
            }
        }
    }
}
