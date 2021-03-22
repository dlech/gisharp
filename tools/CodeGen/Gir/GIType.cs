// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIType : GIBase
    {
        /// <summary>
        /// Gets the C type for this type
        /// </summary>
        public string CType { get; }

        /// <summary>
        /// Indicates if this type is a pointer type
        /// </summary>
        public bool IsPointer { get; }

        public IEnumerable<GIType> TypeParameters => _TypeParameters.Value;
        readonly Lazy<List<GIType>> _TypeParameters;

        /// <summary>
        /// If this is a GObject, GBoxed, GCallback, get the type, otherwise <c>null</c>.
        /// </summary>
        /// <remarks>
        /// This is not necessarily an interface in the .NET sense.
        /// </remarks>
        public GIBase Interface => _Interface.Value;
        readonly Lazy<GIBase> _Interface;
        private protected GIType(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            CType = element.Attribute(c + "type").AsString();
            IsPointer = element.Attribute(gs + "is-pointer").AsBool();
            _TypeParameters = new(() => LazyGetTypeParameters().ToList());
            _Interface = new(() => LazyGetInterface());
        }

        IEnumerable<GIType> LazyGetTypeParameters() =>
            Element.Elements().Where(x => x.Name == gi + "type" || x.Name == gi + "array")
                .Select(x => (GIType)GetNode(x));

        GIBase LazyGetInterface()
        {
            if (this is Array) {
                return null;
            }

            switch (GirName) {
            case "none":
            case "gboolean":
            case "gchar":
            case "guchar":
            case "gshort":
            case "gushort":
            case "gint":
            case "guint":
            case "glong":
            case "gulong":
            case "gint8":
            case "guint8":
            case "gint16":
            case "guint16":
            case "gint32":
            case "guint32":
            case "gint64":
            case "guint64":
            case "gfloat":
            case "gdouble":
            case "gtype":
            case "utf8":
            case "filename":
            case "gpointer":
            case "gconstpointer":
            case "gintptr":
            case "guintptr":
            case "gsize":
            case "gssize":
            case "gunichar":
            case "gunichar2":
            case "GType":
            case "GError":
            case "GLib.List":
            case "GLib.SList":
            case "GLib.HashTable":
                return null;
            default:
                break;
            }

            if (GirName.Contains("Private", StringComparison.Ordinal)) {
                return null;
            }

            if (ParentNode is Field field && field.Callback is Callback callback) {
                return callback;
            }

            return TypeResolver.ResolveType<GIBase>(Namespace, GirName);
        }
    }
}
