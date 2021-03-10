// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Record : GIRegisteredType
    {
        /// <summary>
        /// Gets if a record is an opaque type
        /// </summary>
        public bool IsDisguised { get; }

        /// <summary>
        /// If this is a GType class or interface struct, gets the GType name
        /// for this record, or null if this record is not a GType struct
        /// </summary>
        public string IsGTypeStructFor { get; }

        /// <summary>
        /// Gets the type that this record is a gytpe struct for, if any
        /// </summary>
        public GIRegisteredType IsGTypeStructForType => _IsGTypeStructForType.Value;
        readonly Lazy<GIRegisteredType> _IsGTypeStructForType;

        /// <summary>
        /// Indicates that the first field in the struct is the parent type.
        /// </summary>
        public bool HasParent { get; }

        /// <summary>
        /// Gets the base type for an opaque record. Not valid for records that
        /// are structs.
        /// </summary>
        public string BaseType => _BaseType.Value;
        readonly Lazy<string> _BaseType;

        public Record(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "record") {
                throw new ArgumentException("Requrires <record> element", nameof(element));
            }
            IsDisguised = Element.Attribute("disguised").AsBool();
            IsGTypeStructFor = element.Attribute(glib + "is-gtype-struct-for").AsString();
            HasParent = element.Attribute(gs + "has-parent").AsBool();
            _IsGTypeStructForType = new(LazyGetIsGTypeStructForType, false);
            _BaseType = new(LazyGetBaseType, false);
        }

        GIRegisteredType LazyGetIsGTypeStructForType() =>
            (GIRegisteredType)Namespace.AllTypes.SingleOrDefault(x => x.GirName == IsGTypeStructFor);

        string LazyGetBaseType()
        {
            if (IsGTypeStructFor is not null) {
                if (Fields.Any()) {
                    // in GType structs, the first field is always the base type
                    return Fields.First().Type.GetManagedType();
                }
                // if there weren't any fields, maybe it is a class
                if (IsGTypeStructForType is Class @class) {
                    var parent = @class.ParentType;
                    return $"GISharp.Lib.{parent.Namespace.Name}.{parent.GTypeStruct}";
                }
                throw new NotSupportedException("Don't know how to get the parent for this GType struct");
            }
            if (IsDisguised) {
                if (HasParent) {
                    return Fields.First().Type.GetManagedType();
                }
                return typeof(Opaque).FullName;
            }
            return typeof(ValueType).FullName;
        }
    }
}
