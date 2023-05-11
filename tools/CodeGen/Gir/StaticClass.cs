// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    // REVISIT: this is not really a GIRegisteredType or even GIBase
    public sealed class StaticClass : GIRegisteredType
    {
        public StaticClass(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gs + "static-class")
            {
                throw new ArgumentException("Requrires <gs:static-class> element", nameof(element));
            }
        }
    }
}
