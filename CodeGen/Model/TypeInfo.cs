using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    public enum TypeClassification
    {
        /// <summary>
        /// A C-style array of structs
        /// </summary>
        CArray,
        /// <summary>
        /// A delegate.
        /// </summary>
        Delegate,
        /// <summary>
        /// A string encoded using filesystem encoding.
        /// </summary>
        FilenameString,
        /// <summary>
        /// A null-terminated array of filename strings.
        /// </summary>
        FilenameStrv,
        /// <summary>
        /// An <see cref="Opaque"/> object.
        /// </summary>
        Opaque,
        /// <summary>
        /// A C-style array of pointers to unmanaged <see cref="Opaque"/> objects
        /// </summary>
        OpaqueCArray,
        /// <summary>
        /// A null-terminated array of UTF-8 strings.
        /// </summary>
        Strv,
        /// <summary>
        /// A null-terminated UTF-8 string.
        /// </summary>
        Utf8String,
        /// <summary>
        /// A value type (struct).
        /// </summary>
        ValueType,
        /// <summary>
        /// No type.
        /// </summary>
        Void,
    }
    public class TypeInfo : BaseInfo
    {
        readonly string typeName;

        TypeClassification? _Classification;
        public TypeClassification Classification {
            get {
                if (!_Classification.HasValue) {
                    if (TypeObject == typeof(void)) {
                        _Classification = TypeClassification.Void;
                    } else if (typeof(Delegate).IsAssignableFrom (TypeObject) || TypeObject.IsSubclassOf (typeof(Delegate))) {
                        // GirType always returns false for IsAssignableFrom when type is a RuntimeType
                        // so we have to check IsSubclassOf as well.
                        _Classification = TypeClassification.Delegate;
                    } else if (typeof(GISharp.Core.Opaque).IsAssignableFrom (TypeObject) || TypeObject.IsSubclassOf (typeof(GISharp.Core.Opaque))) {
                        _Classification = TypeClassification.Opaque;
                    } else if (Element.Element (gi + "type")?.Attribute ("name").AsString () == "utf8") {
                        _Classification = TypeClassification.Utf8String;
                    } else if (Element.Element (gi + "type")?.Attribute ("name").AsString () == "filename") {
                        _Classification = TypeClassification.FilenameString;
                    } else if (TypeObject.IsArray) {
                        if (Element.Element (gi + "array")?.Element (gi + "type")?.Attribute ("name").AsString () == "utf8") {
                            _Classification = TypeClassification.Strv;
                        } else if (Element.Element (gi + "array")?.Element (gi + "type")?.Attribute ("name").AsString () == "filename") {
                            _Classification = TypeClassification.FilenameStrv;
                        } else if (TypeObject.GetElementType ().IsValueType) {
                            _Classification = TypeClassification.CArray;
                        } else if (TypeObject.GetElementType ().IsSubclassOf (typeof(GISharp.Core.Opaque))) {
                            _Classification = TypeClassification.OpaqueCArray;
                        } else {
                            throw new NotSupportedException ();
                        }
                    } else if (TypeObject.IsValueType) {
                        _Classification = TypeClassification.ValueType;
                    } else {
                        throw new NotSupportedException ();
                    }
                }
                return _Classification.Value;
            }
        }

        public bool RequiresMarshal { get; private set; }

        public bool ArrayZeroTerminated {
            get {
                var arrayElement = Element.Element (gi + "array");
                if (arrayElement == null) {
                    throw new NotSupportedException ();
                }
                return arrayElement.Attribute ("zero-terminated").AsBool ();
            }
        }

        public int ArrayFixedSize {
            get {
                return Element.GetFixedSize ();
            }
        }

        /// <summary>
        /// Gets the index of the length of an array parameter.
        /// </summary>
        /// <value>The index of the length or -1 if this is a fixed-size or null-terminated array or not an array type.</value>
        public int ArrayLengthIndex {
            get {
                return Element.GetLengthIndex (countInstanceParameter: true);
            }
        }

        Type _TypeObject;
        public Type TypeObject {
            get {
                if (_TypeObject == null) {
                    _TypeObject = GirType.GetType (typeName, Element.Document);
                }
                return _TypeObject;
            }
        }

        TypeSyntax _Type;
        public TypeSyntax Type {
            get {
                if (_Type == default(TypeSyntax)) {
                    var fixedUpTypeName = typeName;
                    if (typeName == "System.Void") {
                        // C# can't use System.Void
                        fixedUpTypeName = "void";
                    } else if (typeName.Contains ("`")) {
                        fixedUpTypeName = typeName.Remove (typeName.IndexOf ('`'))
                            + typeName.Substring (typeName.IndexOf ('['));
                        fixedUpTypeName = fixedUpTypeName.Replace ('[', '<').Replace (']', '>');
                    }
                    _Type = ParseTypeName (fixedUpTypeName);
                }
                return _Type;
            }
        }

        public TypeInfo (XElement element, bool managed)
            : base (element, null)
        {
            typeName = element.Attribute (gs + "managed-type")?.Value;
            if (typeName == null) {
                throw new ArgumentException ("Requires element with 'managed-type' attribute.", nameof(element));
            }
            var type = TypeObject;
            if (typeof(Delegate).IsAssignableFrom (type) || type.IsSubclassOf (typeof(Delegate))) {
                RequiresMarshal = true;
                if (managed) {
                    typeName += "Callback";
                }
            } else if (!type.IsValueType) {
                // If the managed type is a value type or a delegate, then it can
                // be passed directly, otherwise it requires special marshalling
                // via generated code.
                if (!managed) {
                    typeName = typeof(IntPtr).FullName;
                }
                RequiresMarshal = true;
            }
            // have to reset the lazy getter since we possibly changed the type.
            _TypeObject = null;
        }
    }
}
