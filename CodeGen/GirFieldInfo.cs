using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace GISharp.CodeGen
{
    class GirFieldInfo : FieldInfo, IGirInfo
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        readonly XElement element;

        GirFieldInfo (XElement element) {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            if (element.Name != gi + "field" && element.Name != gi + "constant" && element.Name != gi + "member") {
                throw new ArgumentException ("Requires a <field>, <constant> or <member> element.", nameof(element));
            }
            this.element = element;
        }

        public static GirFieldInfo Get (XElement element) {
            if (element.Annotation<GirFieldInfo> () == null) {
                element.AddAnnotation (new GirFieldInfo (element));
            }
            return element.Annotation<GirFieldInfo> ();
        }

        public override IList<CustomAttributeData> GetCustomAttributesData ()
        {
            return element.GetCustomAttributes (false).ToList ();
        }

        #region implemented abstract members of MemberInfo

        public override bool IsDefined (Type attributeType, bool inherit)
        {
            throw new NotImplementedException ();
        }

        public override object[] GetCustomAttributes (bool inherit)
        {
            if (inherit) {
                throw new NotImplementedException ();
            }
            return element.GetCustomAttributes (false).ToArray ();
        }

        public override object[] GetCustomAttributes (Type attributeType, bool inherit)
        {
            throw new NotImplementedException ();
        }

        public override Type DeclaringType {
            get {
                throw new NotImplementedException ();
            }
        }

        public override string Name {
            get {
                return element.Attribute (gs + "managed-name").Value;
            }
        }

        public override Type ReflectedType {
            get {
                throw new NotImplementedException ();
            }
        }

        #endregion

        #region implemented abstract members of FieldInfo

        public override object GetValue (object obj)
        {
            if (obj != null) {
                throw new NotImplementedException ();
            }
            if (element.Name == gi + "member") {
                return int.Parse (element.Attribute ("value").Value);
            }
            if (element.Name == gi + "constant") {
                switch (element.Attribute (gs + "managed-type").Value) {
                case "System.Boolean":
                    return bool.Parse (element.Attribute ("value").Value);
                case "System.Byte":
                    return byte.Parse (element.Attribute ("value").Value);
                case "System.SByte":
                    return sbyte.Parse (element.Attribute ("value").Value);
                case "System.Int16":
                    return short.Parse (element.Attribute ("value").Value);
                case "System.UInt16":
                    return ushort.Parse (element.Attribute ("value").Value);
                case "System.Int32":
                    return int.Parse (element.Attribute ("value").Value);
                case "System.UInt32":
                    return uint.Parse (element.Attribute ("value").Value);
                case "System.Int64":
                    return long.Parse (element.Attribute ("value").Value);
                case "System.UInt64":
                    return ulong.Parse (element.Attribute ("value").Value);
                case "System.String":
                    return element.Attribute ("value").Value;
                default:
                    var message = string.Format ("Unexpected constant type '{0}'",
                        element.Attribute (gs + "managed-type").Value);
                    throw new Exception (message);
                }
            }
            throw new NotImplementedException ();
        }

        public override void SetValue (object obj, object value, BindingFlags invokeAttr, Binder binder, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

        public override FieldAttributes Attributes {
            get {
                var attrs = default(FieldAttributes);

                if (element.Name == gi + "constant") {
                    attrs |= FieldAttributes.Static;
                    attrs |= FieldAttributes.Literal;
                }
                var accessModifier = element.Attribute (gs + "access-modifier");
                if (accessModifier != null) {
                    if (accessModifier.Value.Contains ("public")) {
                        attrs |= FieldAttributes.Public; // public keywork
                    }
                    if (accessModifier.Value.Contains ("private")) {
                        attrs |= FieldAttributes.Private;
                    }
                    if (accessModifier.Value.Contains ("protected")) {
                        attrs |= FieldAttributes.Family;
                    }
                    if (accessModifier.Value.Contains ("internal")) {
                        attrs |= FieldAttributes.Assembly;
                    }
                } else {
                    attrs |= FieldAttributes.Public;
                }

                return attrs;
            }
        }

        public override RuntimeFieldHandle FieldHandle {
            get {
                throw new NotImplementedException ();
            }
        }

        public override Type FieldType {
            get {
                if (element.Name == gi + "field") {
                    return GirType.GetType (element.Attribute (gs + "unmanaged-type").Value, element.Document);
                }
                return GirType.GetType (element.Attribute (gs + "managed-type").Value, element.Document);
            }
        }

        #endregion

        #region IGirInfo implementation

        public string DocumentationComments {
            get {
                return element.GetDocumentationComments ();
            }
        }

        #endregion
    }
}

