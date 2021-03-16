// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class ReturnValue : GIArg
    {
        public ReturnValue(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "return-value") {
                throw new ArgumentException("Requrires <return-value> element", nameof(element));
            }
        }
    }
}
