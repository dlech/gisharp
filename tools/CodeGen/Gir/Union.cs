// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Union : GIRegisteredType
    {
        public Union(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "union") {
                throw new ArgumentException("Requrires <union> element", nameof(element));
            }
        }
    }
}
