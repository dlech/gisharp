using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

using GISharp.Core;

namespace GISharp.CodeGen
{
    class GirConstructorInfo : ConstructorInfo, IGirInfo
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        readonly XElement element;

        GirConstructorInfo (XElement element) {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            if (element.Name != gi + "constructor") {
                throw new ArgumentException ("Requires a <constructor> element.", nameof(element));
            }
            this.element = element;
        }

        public static GirConstructorInfo Get (XElement element) {
            if (element.Annotation<GirConstructorInfo> () == null) {
                element.AddAnnotation (new GirConstructorInfo (element));
            }
            return element.Annotation<GirConstructorInfo> ();
        }

        public override IList<CustomAttributeData> GetCustomAttributesData ()
        {
            return element.GetCustomAttributes (false).ToList ();
        }

        #region implemented abstract members of ConstructorInfo

        public override object Invoke (BindingFlags invokeAttr, Binder binder, object[] parameters, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

        #endregion

        #region implemented abstract members of MethodInfo

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
                return GirType.GetType (element.Parent.Attribute (gs + "managed-name").Value, element.Document);
            }
        }

        public override string Name {
            get {
                return element.Parent.Attribute (gs + "managed-name").Value;
            }
        }

        public override Type ReflectedType {
            get {
                throw new NotImplementedException ();
            }
        }

        #endregion

        #region implemented abstract members of MethodBase

        public override MethodImplAttributes GetMethodImplementationFlags ()
        {
            throw new NotImplementedException ();
        }

        public override ParameterInfo[] GetParameters ()
        {
            return getParameters ().ToArray ();
        }

        IEnumerable<ParameterInfo> getParameters ()
        {
            var parametersElement = element.Element (gs + "managed-parameters");
            if (parametersElement == null) {
                yield break;
            }
            foreach (var parameter in parametersElement.Elements (gi + "parameter")) {
                yield return GirParameterInfo.Get (parameter, false);
            }
        }

        public override object Invoke (object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException ();
        }

        public override RuntimeMethodHandle MethodHandle {
            get {
                throw new NotImplementedException ();
            }
        }

        public override MethodAttributes Attributes {
            get {
                var attrs = default(MethodAttributes);

                var accessModifier = element.Attribute (gs + "access-modifier");
                if (accessModifier != null) {
                    if (accessModifier.Value.Contains ("public")) {
                        attrs |= MethodAttributes.Public;
                    }
                    if (accessModifier.Value.Contains ("private")) {
                        attrs |= MethodAttributes.Private;
                    }
                    if (accessModifier.Value.Contains ("protected")) {
                        attrs |= MethodAttributes.Family;
                    }
                    if (accessModifier.Value.Contains ("internal")) {
                        attrs |= MethodAttributes.Assembly;
                    }
                } else {
                    attrs |= MethodAttributes.Public;
                }

                return attrs;
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
