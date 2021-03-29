// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Function : GIFunction
    {
        /// <summary>
        /// Tests if this function is a compare function
        /// </summary>
        public bool IsCompare => Element.Attribute(gs + "special-func").AsString() == "compare";

        /// <summary>
        /// Gets the async function that this function finishes, if any
        /// </summary>
        public GIFunction FinishForFunction => _FinishForFunction.Value;
        readonly Lazy<GIFunction> _FinishForFunction;

        public Function(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "function") {
                throw new ArgumentException("Requrires <function> element", nameof(element));
            }
            _FinishForFunction = new(LazyGetFinishForFunction);
        }

        GIFunction LazyGetFinishForFunction =>
            (GIFunction)GetNode(Element.Parent.Elements(gi + "function")
                .Concat(Element.Parent.Elements(gi + "method"))
                .FirstOrDefault(x => x.Attribute("name")?.Value == FinishFor));
    }
}
