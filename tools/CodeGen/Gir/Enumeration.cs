// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Enumeration : GIEnum
    {
        public Enumeration(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "enumeration") {
                throw new ArgumentException("Requrires <enumeration> element", nameof(element));
            }
        }
    }
}
