// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Method : GIFunction
    {
        /// <summary>
        /// Indicates that this is an extension method
        /// </summary>
        public bool IsExtensionMethod => Element.Attribute(gs + "extension-method").AsBool();

        /// <summary>
        /// Tests if this method is a ref method
        /// </summary>
        public bool IsRef => Element.Attribute(gs + "special-func").AsString() == "ref";

        /// <summary>
        /// Tests if this method is an unref method
        /// </summary>
        public bool IsUnref => Element.Attribute(gs + "special-func").AsString() == "unref";

        /// <summary>
        /// Tests if this method is a copy method
        /// </summary>
        public bool IsCopy => Element.Attribute(gs + "special-func").AsString() == "copy";

        /// <summary>
        /// Tests if this method is a free method
        /// </summary>
        public bool IsFree => Element.Attribute(gs + "special-func").AsString() == "free";

        /// <summary>
        /// Indicates that this function is a hash function suitable for GHashTable
        /// </summary>
        public bool IsHash { get; }

        /// <summary>
        /// Tests if this method is a equal method
        /// </summary>
        public bool IsEqual { get; }

        /// <summary>
        /// Indicates that this method is a to-string method
        /// </summary>
        public bool IsToString { get; }

        /// <summary>
        /// Gets the async function that this method finishes, if any
        /// </summary>
        public GIFunction FinishForFunction => _FinishForFunction.Value;
        readonly Lazy<GIFunction> _FinishForFunction;

        public Method(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gi + "method")
            {
                throw new ArgumentException("Requrires <method> element", nameof(element));
            }
            IsHash = Element.Attribute(gs + "hash").AsBool();
            IsEqual = Element.Attribute(gs + "equal").AsBool();
            IsToString = Element.Attribute(gs + "to-string").AsBool();
            _FinishForFunction = new(LazyGetFinishForFunction);
        }

        GIFunction LazyGetFinishForFunction =>
            (GIFunction)GetNode(
                Element.Parent
                    .Elements(gi + "function")
                    .Concat(Element.Parent.Elements(gi + "method"))
                    .FirstOrDefault(x => x.Attribute("async-finish")?.Value == ManagedName)
            );
    }
}
