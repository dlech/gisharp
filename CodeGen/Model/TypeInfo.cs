using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// A GObject.
        /// </summary>
        GObject,
        /// <summary>
        /// A GType TypeClass or TypeInterface
        /// </summary>
        GTypeStruct,
        /// <summary>
        /// An interface.
        /// </summary>
        Interface,
        /// <summary>
        /// An <see cref="Opaque"/> object.
        /// </summary>
        Opaque,
        /// <summary>
        /// A C-style array of pointers to unmanaged <see cref="Opaque"/> objects
        /// </summary>
        OpaqueCArray,
        /// <summary>
        /// A UTF-32/UCS-4 character.
        /// </summary>
        Utf32Char,
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
                    } else if (TypeObject.IsInterface) {
                        _Classification = TypeClassification.Interface;
                    } else if (Element.Attribute(glib + "is-gtype-struct-for") != null || typeof(GISharp.GObject.TypeClass).IsAssignableFrom(TypeObject)) {
                        _Classification = TypeClassification.GTypeStruct;
                    } else if (typeof(Delegate).IsAssignableFrom (TypeObject) || TypeObject.IsSubclassOf (typeof(Delegate))) {
                        // GirType always returns false for IsAssignableFrom when type is a RuntimeType
                        // so we have to check IsSubclassOf as well.
                        _Classification = TypeClassification.Delegate;
                    } else if (typeof(GISharp.Runtime.Opaque).IsAssignableFrom (TypeObject) || TypeObject.IsSubclassOf (typeof(GISharp.Runtime.Opaque))) {
                        _Classification = TypeClassification.Opaque;
                    } else if (Element.Element (gi + "type")?.Attribute ("name").AsString () == "utf8") {
                        _Classification = TypeClassification.Opaque;
                    } else if (Element.Element (gi + "type")?.Attribute ("name").AsString () == "filename") {
                        _Classification = TypeClassification.FilenameString;
                    } else if (Element.Element (gi + "type")?.Attribute ("name").AsString () == "gunichar") {
                        _Classification = TypeClassification.Utf32Char;
                    } else if (TypeObject.IsArray) {
                        // null-terminated arrays of utf8 are GStrv
                        if (Element.Element(gi + "array")?.Attribute(gi + "zero-terminated").AsBool() == true &&
                                Element.Element(gi + "array")?.Element(gi + "type")?.Attribute("name").AsString() == "utf8") {
                            _Classification = TypeClassification.Opaque;
                        } else if (Element.Element (gi + "array")?.Element (gi + "type")?.Attribute ("name").AsString () == "filename") {
                            _Classification = TypeClassification.FilenameStrv;
                        } else if (TypeObject.GetElementType ().IsValueType) {
                            _Classification = TypeClassification.CArray;
                        } else if (TypeObject.GetElementType ().IsSubclassOf (typeof(GISharp.Runtime.Opaque))) {
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
                    throw new InvalidOperationException("Not an array");
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
                    _TypeObject = GirType.ResolveType (typeName, Element.Document);
                }
                return _TypeObject;
            }
        }

        TypeSyntax _Type;
        public TypeSyntax Type {
            get {
                if (_Type == null) {
                    var fixedUpTypeName = TypeObject.FullName;
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

        SyntaxTrivia? _GirXmlTrivia;
        /// <summary>
        /// Gets the gir xml for the type as a comment.
        /// </summary>
        /// <value>The gir xml trivia.</value>
        public SyntaxTrivia GirXmlTrivia {
            get {
                if (!_GirXmlTrivia.HasValue) {
                    _GirXmlTrivia = GetGirXmlTrivia ();
                }
                return _GirXmlTrivia.Value;
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
                if (!managed && type is GirType) {
                    var split = typeName.Split ('.');
                    split[split.Length -1] = "Unmanaged" + split[split.Length -1];
                    typeName = string.Join (".", split);
                }
                RequiresMarshal = true;
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

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            yield break;
        }

        SyntaxTrivia GetGirXmlTrivia ()
        {
            var copy = new XElement (Element);
            copy.Descendants (gi + "doc").Remove ();
            // Thanks: http://stackoverflow.com/a/14865785/1976323
            foreach (var e in copy.DescendantsAndSelf()) {
                // Stripping the namespace by setting the name of the element to it's localname only
                e.Name = e.Name.LocalName;
                // replacing all attributes with attributes that are not namespaces
                // and their names are set to only the localname
                e.ReplaceAttributes (e.Attributes()
                    .Where(a => !a.IsNamespaceDeclaration)
                    .Select (a => new XAttribute(a.Name.LocalName, a.Value)));
            }
            var comment = $"/* {copy.Elements().Single()} */".Replace("\n", "\n * ");
            return Comment (comment);
        }
    }
}
