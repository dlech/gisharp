// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIFunction : GICallable
    {
        /// <summary>
        /// Gets the C identifier for the callable, if any (not applicable to
        /// callbacks, signals and virtual methods)
        /// <summary>
        public string CIdentifier { get; }

        /// <summary>
        /// Indicates that only the PInvoke method should be generated and not
        /// the managed wrapper.
        /// </summary>
        public bool IsPInvokeOnly { get; }

        /// <summary>
        /// Gets the dll name to use for PInvoke
        /// </summary>
        public string DllName { get; }

        /// <summary>
        /// Gets the managed property name that this method is an accessor for,
        /// if any; this is not necessarily GObject property.
        /// </summary>
        public string ManagedPropertyName { get; }

        private protected GIFunction(XElement element, GirNode parent) : base(element, parent)
        {
            CIdentifier = Element.Attribute(c + "identifier").AsString();
            IsPInvokeOnly = Element.Attribute(gs + "pinvoke-only").AsBool();
            DllName = Element.Attribute(gs + "dll-name").AsString();
            ManagedPropertyName = Element.Attribute(gs + "property").AsString();
        }
    }
}
