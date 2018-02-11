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
        /// A C-style array of pointers to unmanaged <see cref="Opaque"/> objects
        /// </summary>
        CPtrArray,
        /// <summary>
        /// A delegate.
        /// </summary>
        Delegate,
        /// <summary>
        /// A string encoded using filesystem encoding.
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

        /// <summary>
        /// Gets the classification of this type
        /// </summary>
        public TypeClassification Classification => _Classification.Value;
        Lazy<TypeClassification> _Classification;

        /// <summary>
        /// Indicates that this type cannot be passed directly to pinvoke functions
        /// </summary>
        public bool RequiresMarshal { get; }

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

        /// <summary>
        /// Gets the type that this type info represents.
        /// </summary>
        public Type TypeObject => _TypeObject.Value;
        Lazy<Type> _TypeObject;

        TypeSyntax _Type;
        public TypeSyntax Type {
            get {
                if (_Type == null) {
                    // nested types have "+" that needs to be changed to "."
                    var fixedUpTypeName = TypeObject.FullName.Replace("+", ".");
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

        /// <summary>
        /// Gets the gir xml for the type as a comment.
        /// </summary>
        /// <value>The gir xml trivia.</value>
        public SyntaxTrivia GirXmlTrivia => _GirXmlTrivia.Value;
        Lazy<SyntaxTrivia> _GirXmlTrivia;

        public TypeInfo(XElement element, bool managed) : base(element, null)
        {
            typeName = element.Attribute (gs + "managed-type")?.Value;
            if (typeName == null) {
                throw new ArgumentException ("Requires element with 'managed-type' attribute.", nameof(element));
            }
            var type = GetTypeObject();
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
                    var typeElement = element.Element(gi + "type") ?? element.Element(gi + "array");
                    if (typeElement.Attribute(gs + "is-pointer").AsBool()) {
                        typeName = typeof(IntPtr).FullName;
                    }
                    else {
                        // when we need to pass an opaque by value, we use the nested Struct struct
                        typeName += "+Struct";
                    }
                }
                RequiresMarshal = true;
            }

            _Classification = new Lazy<TypeClassification>(GetTypeClassification);
            _TypeObject = new Lazy<Type>(GetTypeObject);
            _GirXmlTrivia = new Lazy<SyntaxTrivia>(GetGirXmlTrivia);
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            yield break;
        }

        // create a multi-line comment that contains the type info from the GIR XML file
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

        Type GetTypeObject() => GirType.ResolveType(typeName, Element.Document);

        // classify this type based on its characteristics
        TypeClassification GetTypeClassification()
        {
            if (TypeObject == typeof(void)) {
                // void is easy
                return TypeClassification.Void;
            }
            else if (TypeObject.IsInterface) {
                // for interfaces, we check first for the special IArray<T> interface (for C arrays)
                if (TypeObject.IsConstructedGenericType && TypeObject.GetGenericTypeDefinition() == typeof(GISharp.Runtime.IArray<>)) {
                    var genericArgument = TypeObject.GetGenericArguments().Single();
                    if (genericArgument.IsValueType) {
                        return TypeClassification.CArray;
                    }
                    else if (genericArgument.IsSubclassOf (typeof(GISharp.Runtime.Opaque))) {
                        return TypeClassification.CPtrArray;
                    }
                    else {
                        throw new NotSupportedException("IArray<T> parameter must be ValueType or Opaque");
                    }
                }
                else {
                    // otherwise we assume it is a GObject interface
                    return TypeClassification.Interface;
                }
            }
            else if (Element.Attribute(glib + "is-gtype-struct-for") != null || typeof(GISharp.GObject.TypeClass).IsAssignableFrom(TypeObject)) {
                // GType structs are handled differently than other Opaques
                return TypeClassification.GTypeStruct;
            }
            // GirType always returns false for IsAssignableFrom when type is a RuntimeType
            // so we have to check IsSubclassOf as well.
            else if (typeof(Delegate).IsAssignableFrom(TypeObject) || TypeObject.IsSubclassOf(typeof(Delegate))) {
                // GLib callbacks map to delegates
                return TypeClassification.Delegate;
            }
            else if (Element.Element(gi + "type")?.Attribute("name").AsString() == "utf8") {
                // may want to handle this differently, so keeping it separate from Opaque test below
                return TypeClassification.Opaque;
            }
            else if (Element.Element(gi + "type")?.Attribute("name").AsString() == "filename") {
                // may want to handle this differently, so keeping it separate from Opaque test below
                return TypeClassification.Opaque;
            }
            else if (typeof(GISharp.Runtime.Opaque).IsAssignableFrom(TypeObject) || TypeObject.IsSubclassOf(typeof(GISharp.Runtime.Opaque))) {
                // most everything is going to be an Opaque
                return TypeClassification.Opaque;
            }
            else if (TypeObject.IsArray) {
                // Handle cases where an array is not an Opaque already
                if (Element.Element(gi + "array")?.Attribute(gi + "zero-terminated").AsBool() == true &&
                        Element.Element(gi + "array")?.Element(gi + "type")?.Attribute("name").AsString() == "utf8") {
                    // null-terminated arrays of utf8 are GStrv
                    return TypeClassification.Opaque;
                }
                else if (Element.Element(gi + "array")?.Element(gi + "type")?.Attribute("name").AsString() == "filename") {
                    return TypeClassification.FilenameStrv;
                }
                else {
                    throw new NotSupportedException($"unknown array type '{TypeObject.Name}'");
                }
            }
            else if (TypeObject.IsValueType) {
                // value types (structs)
                return TypeClassification.ValueType;
            }
            throw new NotSupportedException($"don't know how to classify type '{TypeObject.Name}'");
        }
    }
}
