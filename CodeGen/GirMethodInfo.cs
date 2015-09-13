using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

using GISharp.Core;

namespace GISharp.CodeGen
{
    class GirMethodInfo : MethodInfo, IGirInfo
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        readonly XElement element;
        readonly bool native;

        GirMethodInfo (XElement element, bool native) {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            if (element.Name != gi + "constructor" && element.Name != gi + "function" && element.Name != gi + "method" && element.Name != gi + "callback") {
                throw new ArgumentException ("Requires a <constructor>, <function>, <method> or <callback> element.", nameof(element));
            }
            if (element.Name == gi + "constructor" && !native) {
                throw new ArgumentException ("<constructor> element must have native == true.", nameof(element));
            }
            this.element = element;
            this.native = native;
        }

        public static GirMethodInfo Get (XElement element, bool native) {
            if (!element.Annotations<GirMethodInfo>().Any (i => i.native == native)) {
                element.AddAnnotation (new GirMethodInfo (element, native));
            }
            return element.Annotations<GirMethodInfo> ().Single (i => i.native == native);
        }

        public override IList<CustomAttributeData> GetCustomAttributesData ()
        {
            return element.GetCustomAttributes (native).ToList ();
        }

        public override Type ReturnType {
            get {
                var returnValueElement = element.Element (gi + "return-value");
                if (native) {
                    return GirType.GetType (returnValueElement.Attribute (gs + "unmanaged-type").Value, element.Document);
                }
                if (/* !native && */ returnValueElement.Attribute ("skip").AsBool ()) {
                    return typeof(void);
                }
                return GirType.GetType (returnValueElement.Attribute (gs + "managed-type").Value, element.Document);
            }
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
            return element.GetCustomAttributes (native).ToArray ();
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
                if (native) {
                    if (element.Name == gi + "callback") {
                        return element.Attribute (gs + "managed-name").Value + "Native";
                    }
                    return element.Attribute (c + "identifier").Value;
                }

                return element.Attribute (gs + "managed-name").Value;
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
            var flags = default(MethodImplAttributes);

            if (element.Name != gi + "callback" && native) {
                flags |= MethodImplAttributes.InternalCall;
                flags |= MethodImplAttributes.PreserveSig;
            }

            return flags;
        }

        public override ParameterInfo[] GetParameters ()
        {
            return getParameters ().ToArray ();
        }

        IEnumerable<ParameterInfo> getParameters ()
        {
            var parametersElement = native
                ? element.Element (gi + "parameters")
                : element.Element (gs + "managed-parameters");
            if (parametersElement == null) {
                yield break;
            }
            if (native) {
                var instanceParameter = parametersElement.Element (gi + "instance-parameter");
                if (instanceParameter != null) {
                    yield return GirParameterInfo.Get (instanceParameter, native);
                }
            }
            foreach (var parameter in parametersElement.Elements (gi + "parameter")) {
                yield return GirParameterInfo.Get (parameter, native);
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

                if (element.Name != gi + "callback" && native) {
                    attrs |= MethodAttributes.PinvokeImpl;
                    attrs &= ~MethodAttributes.MemberAccessMask;
                    attrs |= MethodAttributes.Private;
                }

                if (element.Name == gi + "function" || (element.Name != gi + "callback" && native)) {
                    attrs |= MethodAttributes.Static;
                }

                var specialFunc = element.Attribute (gs + "special-func");
                if (specialFunc != null && !native) {
                    switch (specialFunc.Value) {
                    case "ref":
                    case "unref":
                    case "copy":
                    case "free":
                    case "to-string":
                        // these flags indicate "override"
                        attrs |= MethodAttributes.HideBySig;
                        attrs |= MethodAttributes.Virtual;
                        attrs |= MethodAttributes.ReuseSlot;
                        break;
                    }
                }

                return attrs;
            }
        }

        #endregion

        #region implemented abstract members of MethodInfo

        public override MethodInfo GetBaseDefinition ()
        {
            throw new NotImplementedException ();
        }

        public override ICustomAttributeProvider ReturnTypeCustomAttributes {
            get {
                return new ReturnTypeCustomAttributeProvider (element.Element (gi + "return-value"), native);
            }
        }

        class ReturnTypeCustomAttributeProvider : ICustomAttributeProvider
        {
            readonly XElement element;
            readonly bool native;

            public ReturnTypeCustomAttributeProvider (XElement element, bool native)
            {
                if (element == null) {
                    throw new ArgumentNullException (nameof(element));
                }
                if (element.Name != gi + "return-value") {
                    throw new ArgumentException ("Must be a <return-value> element.", nameof(element));
                }

                this.element = element;
                this.native = native;
            }

            #region ICustomAttributeProvider implementation

            public object[] GetCustomAttributes (Type attributeType, bool inherit)
            {
                throw new NotImplementedException ();
            }

            public object[] GetCustomAttributes (bool inherit)
            {
                if (inherit) {
                    throw new NotImplementedException ();
                }
                return element.GetCustomAttributes (native).ToArray ();
            }

            public bool IsDefined (Type attributeType, bool inherit)
            {
                throw new NotImplementedException ();
            }

            #endregion
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
