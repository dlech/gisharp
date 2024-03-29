// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Bitfield : GIEnum
    {
        public Bitfield(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gi + "bitfield")
            {
                throw new ArgumentException("Requrires <bitfield> element", nameof(element));
            }
        }
    }
}
