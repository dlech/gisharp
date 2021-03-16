// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Parameter : GIArg
    {
        public Parameter(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "parameter") {
                throw new ArgumentException("Requrires <parameter> element", nameof(element));
            }
        }
    }
}
