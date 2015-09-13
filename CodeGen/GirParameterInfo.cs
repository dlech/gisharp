using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

using GISharp.Core;

namespace GISharp.CodeGen
{
    class GirParameterInfo : ParameterInfo, IGirInfo
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        readonly XElement element;
        readonly bool native;

        GirParameterInfo (XElement element, bool native) {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            if (element.Name != gi + "parameter" && element.Name != gi + "instance-parameter" && element.Name != gi + "return-value") {
                throw new ArgumentException ("Requires a <parameter>, <instance-parameter> or <return-value> element.", nameof(element));
            }

            this.element = element;
            this.native = native;

            // See https://developer.gnome.org/glib/stable/annotation-glossary.html for description of attributes
            var direction = element.Attribute ("direction").AsString ("in");
            var callerAllocates = element.Attribute ("caller-allocates").AsBool (true);
            // See https://blogs.gnome.org/desrt/2014/05/27/allow-none-is-dead-long-live-nullable/ for explanation of nullable/optional/allow-none
            var nullable = element.Attribute ("nullable").AsBool () || (direction != "out" && element.Attribute ("allow-none").AsBool ());
            var optional = element.Attribute ("optional").AsBool () || (direction == "out" && element.Attribute ("allow-none").AsBool ());
            var transfer = element.Attribute ("transfer-ownership").AsString (direction == "in" ? "none" : "full");

            if (optional) {
                //Console.WriteLine (element.Parent);
            }

            ClassImpl = native
                ? GirType.GetType (element.Attribute (gs + "unmanaged-type").Value, element.Document)
                : GirType.GetType (element.Attribute (gs + "managed-type").Value, element.Document);
            if (!native && nullable && typeof(ValueType).IsAssignableFrom (ClassImpl) && ClassImpl != typeof(IntPtr) && ClassImpl != typeof(UIntPtr)) {
                ClassImpl = typeof(Nullable<>).MakeGenericType (ClassImpl);
            }
            if (direction == "inout" || direction == "out") {
                ClassImpl = ClassImpl.MakeByRefType ();
            }

            NameImpl = element.Attribute (gs + "managed-name").Value;

            if (native && (direction == "in" || direction == "inout")) {
                // in pinvoke declarations, we will use [In] attribute
                AttrsImpl |= ParameterAttributes.In;
            }
            if ((native && direction == "inout") || direction == "out") {
                // in pinvoke declarations, we will use [Out] attribute
                // in managed declarations, we still need this flag to differentiate from ref
                AttrsImpl |= ParameterAttributes.Out;
            }
            if (element.Attribute ("optional").AsBool ()) {
                AttrsImpl |= ParameterAttributes.Optional;
            }
            if (!native && element.Attribute (gs + "default") != null) {
                AttrsImpl |= ParameterAttributes.HasDefault;
            }
        }

        public static GirParameterInfo Get (XElement element, bool native) {
            if (!element.Annotations<GirParameterInfo>().Any (i => i.native == native)) {
                element.AddAnnotation (new GirParameterInfo (element, native));
            }
            return element.Annotations<GirParameterInfo> ().Single (i => i.native == native);
        }

        public override bool HasDefaultValue {
            get {
                return Attributes.HasFlag (ParameterAttributes.HasDefault);
            }
        }

        public override object DefaultValue {
            get {
                if (HasDefaultValue) {
                    return element.Attribute (gs + "default").Value;
                }
                return null;
            }
        }

        public override object[] GetCustomAttributes (Type attributeType, bool inherit)
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

        #region IGirInfo implementation

        public string DocumentationComments {
            get {
                return element.GetDocumentationComments ();
            }
        }

        #endregion
    }
}
