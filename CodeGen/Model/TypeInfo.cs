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
    public class TypeInfo : BaseInfo
    {
        readonly string typeName;

        /// <summary>
        /// Gets a value indicating if this is a UTF-8 encoded, null terminated string.
        /// </summary>
        /// <value><c>true</c> if the type is a UTF-8 string.</value>
        public bool IsUtf8 {
            get {
                return Element.Element (gi + "type")?.Attribute ("name").AsString () == "utf8";
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
            if (type.IsDelegate ()) {
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
