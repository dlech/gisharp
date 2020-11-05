using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Field : GIBase
    {
        /// <summary>
        /// Gets if the field is readable
        /// </summary>
        public bool Readable { get; }

        /// <summary>
        /// Gets if the field is writeable
        /// </summary>
        public bool Writeable { get; }

        /// <summary>
        /// Gets if the field is private
        /// </summary>
        public bool Private { get; }

        /// <summary>
        /// Gets the type of the field
        /// </summary>
        public GIType Type => _Type.Value;
        readonly Lazy<GIType> _Type;

        /// <summary>
        /// Gets the callback or null if this field is not a function pointer
        /// </summary>
        public Callback Callback => _Callback.Value;
        readonly Lazy<Callback> _Callback;

        public Field(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "field") {
                throw new ArgumentException("Requrires <field> element", nameof(element));
            }

            Readable = Element.Attribute("readable").AsBool(true);
            Writeable = Element.Attribute("writeable").AsBool(false);
            Private = Element.Attribute("private").AsBool(false);
            _Type = new(LazyGetType, false);
            _Callback = new(LazyGetCallback, false);
        }

        GIType LazyGetType() =>
            (GIType)GetNode(Element.Element(gi + "type") ?? Element.Element(gi + "array"));

        Callback LazyGetCallback() =>
            (Callback)GetNode(Element.Element(gi + "callback"));
    }
}
