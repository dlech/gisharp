using System;
using System.Reflection;
using System.Xml.Linq;
using System.Globalization;
using System.Linq;

namespace GISharp.CodeGen
{
    public class GirPropertyInfo : PropertyInfo, IGirInfo
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        readonly XElement getterElement;
        readonly XElement setterElement;

        GirPropertyInfo (XElement getterElement, XElement setterElement)
        {
            if (getterElement == null && setterElement == null) {
                throw new ArgumentException ("getterElement and setterElement cannot both be null.");
            }
            if (getterElement != null && getterElement.Name != gi + "function" && getterElement.Name != gi + "method") {
                throw new ArgumentException ("Requires a <function> or <method> element.", nameof(getterElement));
            }
            if (setterElement != null && setterElement.Name != gi + "function" && setterElement.Name != gi + "method") {
                throw new ArgumentException ("Requires a <function> or <method> element.", nameof(setterElement));
            }

            this.getterElement = getterElement;
            this.setterElement = setterElement;
        }

        public static GirPropertyInfo Get (XElement getterElement, XElement setterElement) {
            if (getterElement != null && getterElement.Annotation<GirPropertyInfo> () == null) {
                getterElement.AddAnnotation (new GirPropertyInfo (getterElement, setterElement));
            }
            if (setterElement != null && setterElement.Annotation<GirPropertyInfo> () == null) {
                setterElement.AddAnnotation (getterElement?.Annotation<GirPropertyInfo> () ?? new GirPropertyInfo (getterElement, setterElement));
            }
            return getterElement?.Annotation<GirPropertyInfo> () ?? setterElement?.Annotation<GirPropertyInfo> ();
        }

        #region PropertyInfo implementation

        public override PropertyAttributes Attributes {
            get {
                var attrs = default(PropertyAttributes);

                return attrs;
            }
        }

        public override bool CanRead {
            get {
                return getterElement != null;
            }
        }

        public override bool CanWrite {
            get {
                return setterElement != null;
            }
        }

        public override Type PropertyType {
            get {
                return GirType.GetType (getterElement.Element (gi + "return-value").Attribute (gs + "managed-type").Value, getterElement.Document);
            }
        }

        public override MethodInfo[] GetAccessors (bool nonPublic)
        {
            throw new NotImplementedException ();
        }

        public override MethodInfo GetGetMethod (bool nonPublic)
        {
            if (getterElement == null) {
                return null;
            }
            return GirMethodInfo.Get (getterElement, false);
        }

        public override ParameterInfo[] GetIndexParameters ()
        {
            throw new NotImplementedException ();
        }

        public override MethodInfo GetSetMethod (bool nonPublic)
        {
            if (setterElement == null) {
                return null;
            }
            return GirMethodInfo.Get (setterElement, false);
        }

        public override object GetValue (object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

        public override void SetValue (object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

        #endregion

        #region MemberInfo implementation

        public override Type DeclaringType {
            get {
                throw new NotImplementedException ();
            }
        }

        public override MemberTypes MemberType {
            get {
                throw new NotImplementedException ();
            }
        }

        public override string Name {
            get {
                return getterElement.Attribute (gs + "property").Value;
            }
        }

        public override Type ReflectedType {
            get {
                throw new NotImplementedException ();
            }
        }

        public override object[] GetCustomAttributes (Type attributeType, bool inherit)
        {
            throw new NotImplementedException ();
        }

        public override object[] GetCustomAttributes (bool inherit)
        {
            return getterElement.GetCustomAttributes (false).ToArray ();
        }

        public override bool IsDefined (Type attributeType, bool inherit)
        {
            throw new NotImplementedException ();
        }

        #endregion

        #region IGirInfo implementation

        public string DocumentationComments {
            get {
                return getterElement.GetDocumentationComments ();
            }
        }

        #endregion
    }
}

