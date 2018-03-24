using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
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
        /// Indicates that this record is a GLib.Source
        /// </summary>
        public bool IsSource { get; }

        /// <summary>
        /// Gets the type that this record is a gytpe struct for, if any
        /// </summary>
        public GIRegisteredType IsGTypeStructForType => _IsGTypeStructForType.Value;
        readonly Lazy<GIRegisteredType> _IsGTypeStructForType;

        /// <summary>
        /// Gets the base type for an opaque record. Not valid for records that
        /// are structs.
        /// </summary>
        public System.Type BaseType => _BaseType.Value;
        readonly Lazy<System.Type> _BaseType;

        public Record(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "record") {
                throw new ArgumentException("Requrires <record> element", nameof(element));
            }
            IsDisguised = Element.Attribute("disguised").AsBool();
            IsGTypeStructFor = element.Attribute(glib + "is-gtype-struct-for").AsString();
            IsSource = element.Attribute(gs + "source").AsBool();
            _IsGTypeStructForType = new Lazy<GIRegisteredType>(LazyGetIsGTypeStructForType, false);
            _BaseType = new Lazy<System.Type>(LazyGetBaseType, false);
        }

        GIRegisteredType LazyGetIsGTypeStructForType() =>
            (GIRegisteredType)Namespace.AllTypes.SingleOrDefault(x => x.GirName == IsGTypeStructFor);

        System.Type LazyGetBaseType()
        {
            if (IsGTypeStructFor != null) {
                if (Fields.Any()) {
                    // in GType structs, the first field is always the base type
                    return Fields.First().Type.ManagedType;
                }
                // if there weren't any fields, maybe it is a class
                if (IsGTypeStructForType is Class @class) {
                    return @class.ParentType.GetGTypeStruct();
                }
                throw new NotSupportedException("Don't know how to get the parent for this GType struct");
            }
            if (IsSource) {
                return typeof(Source);
            }
            if (GTypeName != null) {
                return typeof(Boxed);
            }
            if (IsDisguised) {
                return typeof(Opaque);
            }
            throw new InvalidOperationException("structs cannot have a base type");
        }
    }
}
