// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Interface : GIRegisteredType
    {
        public IEnumerable<Prerequisite> Prerequisites => _Prerequisites.Value;
        readonly Lazy<List<Prerequisite>> _Prerequisites;

        public Interface(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gi + "interface")
            {
                throw new ArgumentException("Requrires <interface> element", nameof(element));
            }
            _Prerequisites = new(() => LazyGetPrerequisites().ToList());
        }

        IEnumerable<Prerequisite> LazyGetPrerequisites() =>
            Element.Elements(gi + "prerequisite").Select(x => (Prerequisite)GetNode(x));
    }
}
