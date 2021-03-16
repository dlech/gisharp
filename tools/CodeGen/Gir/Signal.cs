// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Signal : GICallable
    {
        /// <summary>
        /// Gets the type that this type is an alias for
        /// </summary>
        public EmissionStage When { get; }

        /// <summary>
        /// Gets if the signal has the "no-recurse" attribute set.
        /// </summary>
        public bool IsNoRecurse { get; }

        /// <summary>
        /// Gets if the signal has the "detailed" attribute set.
        /// </summary>
        public bool IsDetailed { get; }

        /// <summary>
        /// Gets if the signal has the "action" attribute set.
        /// </summary>
        public bool IsAction { get; }

        /// <summary>
        /// Gets if the signal has the "no-hooks" attribute set.
        /// </summary>
        public bool IsNoHooks { get; }

        public Signal(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != glib + "signal") {
                throw new ArgumentException("Requrires <glib:signal> element", nameof(element));
            }
            When = Element.Attribute("when").ToEmissionStage();
            IsNoRecurse = element.Attribute("no-recurse").AsBool();
            IsDetailed = element.Attribute("detailed").AsBool();
            IsAction = element.Attribute("action").AsBool();
            IsNoHooks = element.Attribute("no-hooks").AsBool();
        }
    }
}
