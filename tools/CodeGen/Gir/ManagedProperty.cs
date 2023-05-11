// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class ManagedProperty : GIBase
    {
        /// <summary>
        /// Gets the type of the property
        /// </summary>
        public GIType Type => _Type.Value;
        readonly Lazy<GIType> _Type;

        /// <summary>
        /// Gets the getter method of the property
        /// </summary>
        public GIFunction Getter => _Getter.Value;
        readonly Lazy<GIFunction> _Getter;

        /// <summary>
        /// Gets the setter method of the property, if any
        /// </summary>
        public GIFunction Setter => _Setter.Value;
        readonly Lazy<GIFunction> _Setter;

        public ManagedProperty(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gs + "managed-property")
            {
                throw new ArgumentException(
                    "Requrires <gs:managed-property> element",
                    nameof(element)
                );
            }

            _Type = new(LazyGetType, false);
            _Getter = new(LazyGetGetter, false);
            _Setter = new(LazyGetSetter, false);
        }

        GIType LazyGetType() =>
            (GIType)GetNode(
                Element.Element(gi + "return-value").Element(gi + "type")
                    ?? Element.Element(gi + "return-value").Element(gi + "array")
            );

        GIFunction LazyGetGetter() =>
            (GIFunction)GetNode(
                Element.Parent
                    .Elements()
                    .Single(x => x.Attribute(gs + "property-getter-for")?.Value == ManagedName)
            );

        GIFunction LazyGetSetter() =>
            (GIFunction)GetNode(
                Element.Parent
                    .Elements()
                    .SingleOrDefault(
                        x => x.Attribute(gs + "property-setter-for")?.Value == ManagedName
                    )
            );
    }
}
