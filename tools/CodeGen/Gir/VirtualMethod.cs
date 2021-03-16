// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class VirtualMethod : GICallable
    {
        public VirtualMethod(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "virtual-method") {
                throw new ArgumentException("Requrires <virtual-method> element", nameof(element));
            }
        }
    }
}
