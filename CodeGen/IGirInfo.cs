using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

using GISharp.Core;

namespace GISharp.CodeGen
{
    public interface IGirInfo
    {
        string DocumentationComments { get; }
    }

    public static class GirInfoExtenstion
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        internal static string GetDocumentationComments (this XElement element)
        {
            var builder = new StringBuilder ();
            string line;

            if (element.Element (gi + "doc") != null) {
                using (var reader = new StringReader (element.Element (gi + "doc").Value)) {
                    builder.AppendLine ("/// <summary>");
                    while ((line = reader.ReadLine ()) != null) {
                        // summary is only the first paragraph
                        if (string.IsNullOrWhiteSpace (line)) {
                            break;
                        }
                        builder.AppendFormat ("/// {0}", new XText (line));
                        builder.AppendLine ();
                    }
                    builder.AppendLine ("/// </summary>");
                    if (line != null) {
                        // if there are more lines, they go in the remarks
                        builder.AppendLine ("/// <remarks>");
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </remarks>");
                    }
                }
            }

            foreach (var paramElement in element.EnumerateParameters (managed: false)) {
                if (paramElement.Element (gi + "doc") != null) {
                    using (var reader = new StringReader (paramElement.Element (gi + "doc").Value)) {
                        builder.AppendFormat ("/// <param name=\"{0}\">",
                            paramElement.Attribute (gs + "managed-name").Value.Replace ("@", ""));
                        builder.AppendLine ();
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </param>");
                    }
                }
            }

            if (element.Element (gi + "return-value") != null) {
                if (element.Element (gi + "return-value").Element (gi + "doc") != null) {
                    using (var reader = new StringReader (element.Element (gi + "return-value").Element (gi + "doc").Value)) {
                        builder.AppendLine ("/// <returns>");
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </returns>");
                    }
                }
            }

            return builder.ToString ();
        }

        static string GetObsoleteMessage (this XElement element)
        {
            var builder = new StringBuilder ();
            var docDeprecated = element.Element (gi + "doc-deprecated");
            if (docDeprecated != null) {
                builder.Append (docDeprecated.Value);
            }
            var deprecatedSince = element.Attribute ("deprecated-since");
            if (deprecatedSince != null) {
                if (builder.Length > 0) {
                    builder.Append (" ");
                }
                builder.Append (deprecatedSince.Value);
            }
            if (builder.Length > 0) {
                return builder.ToString ();
            }
            return null;
        }

        internal static IEnumerable<CustomAttributeData> GetCustomAttributes (this XElement element, bool native)
        {
            if (Fixup.ElementsThatDefineAType.Contains (element.Name)) {
                yield return new GirXmlAttributeData (element.ToString ());
            }

            // aliases and non-opaque records are C# structs
            if (element.Name == gi + "alias" || (element.Name == gi + "record" && element.Attribute (gs + "opaque") == null)) {
                yield return new StructLayoutAttributeData (LayoutKind.Sequential);
            }

            // bitfields are C# enums with Flags
            if (element.Name == gi + "bitfield") {
                yield return new FlagsAttributeData ();
            }

            // callbacks are C# delegates
            if (element.Name == gi + "callback" && native) {
                yield return new UnmanagedFunctionPointerAttributeData ();
            }

            // constructors, functions and methods use PInvoke
            if ((element.Name == gi + "constructor" || element.Name == gi + "function" || element.Name == gi + "method") && native) {
                var package = element.Ancestors (gi + "repository").Single ().Element (gi + "package").Attribute ("name").Value;
                yield return new DllImportAttributeData (package + ".dll");
            }

            // enumerations can be associated with an error domain
            if (element.Name == gi + "enumeration" && element.Attribute (glib + "error-domain") != null) {
                var name = element.Attribute (glib + "error-domain").Value;
                yield return new ErrorDomainAttributeData (name);
            }

            // unions are C# structs
            if (element.Name == gi + "union") {
                yield return new StructLayoutAttributeData (LayoutKind.Explicit);
            }

            // fields are C# fields
            if (element.Name == gi + "field" && element.Parent.Name == gi + "union") {
                yield return new FieldOffsetAttributeData (0);
            }

            // parameters are C# parameters/arguments
            if (element.Name == gi + "parameter" || element.Name == gi + "instance-parameter") {
                if (native) {
                    var direction = element.Attribute ("direction").AsString ("in");
                    if (direction == "in" || direction == "inout") {
                        yield return new InAttributeData ();
                    }
                    if (direction == "inout" || direction == "out") {
                        yield return new OutAttributeData ();
                    }
                }
            }

            // return-values and parameters can have assoicated array info
            if (element.Name == gi + "return-value" || element.Name == gi + "parameter") {
                if (native && element.Attribute (gs + "unmanaged-type").Value.EndsWith ("[]", StringComparison.Ordinal)) {
                    var arrayElement = element.Element (gi + "array");
                    if (arrayElement != null) {
                        var lengthAttr = arrayElement.Attribute ("length");
                        if (lengthAttr != null) {
                            var index = int.Parse (lengthAttr.Value);
                            // Note: parent could be parameters element or method/function/constructor/callback element
                            if (element.Parent.Descendants (gi + "instance-parameter").Any ()) {
                                // gir does not count instance parameter in index, but we have to
                                index++;
                            }
                            yield return new MarshalAsAttributeData (UnmanagedType.LPArray, "SizeParamIndex", index);
                        }
                        var fixedSizeAttr = arrayElement.Attribute ("fixed-size");
                        if (fixedSizeAttr != null) {
                            var fixedSize = int.Parse (fixedSizeAttr.Value);
                            yield return new MarshalAsAttributeData (UnmanagedType.LPArray, "SizeConst", fixedSize);
                        }
                    }
                }
            }

            // anything can be flagged as Obsolete
            if (element.Attribute ("deprecated").AsBool ()) {
                yield return new ObsoleteAttributeData (element.GetObsoleteMessage ());
            }

            // anything can be flagged as Since
            if (element.Attribute ("version") != null) {
                var version = element.Attribute ("version").Value;
                yield return new SinceAttributeData (version);
            }
        }

        abstract class GirCustomAttributeData : CustomAttributeData
        {
            public GirCustomAttributeData (Type type, params Type[] constructorArgs)
            {
                if (type == null) {
                    throw new ArgumentNullException ("type");
                }
                if (!typeof(Attribute).IsAssignableFrom (type)) {
                    throw new ArgumentException ("Expecting an Attribute type.", "type");
                }
                // work around bad implementation of CustomAttributeData in Mono
                var ctorInfoField = typeof(CustomAttributeData).GetField ("ctorInfo",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                var constructor = type.GetConstructor (constructorArgs);
                if (constructor == null) {
                    throw new ArgumentException ("Could not find matching constructor", "constructorArgs");
                }
                ctorInfoField.SetValue (this, constructor);
            }
            public override IList<CustomAttributeTypedArgument> ConstructorArguments {
                get {
                    return GetConstructorArguments ().ToList ();
                }
            }

            protected virtual IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield break;
            }

            public override string ToString ()
            {
                return GetType ().ToString ();
            }

            public override IList<CustomAttributeNamedArgument> NamedArguments {
                get {
                    return GetNamedArguments ().ToList ();
                }
            }

            protected virtual IEnumerable<CustomAttributeNamedArgument> GetNamedArguments ()
            {
                yield break;
            }

        }

        class ObsoleteAttributeData : GirCustomAttributeData
        {
            readonly string message;

            public ObsoleteAttributeData (string message)
                : base (typeof(ObsoleteAttribute), typeof(string))
            {
                this.message = message;
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                if (message != null) {
                    yield return new CustomAttributeTypedArgument (message);
                }
            }
        }

        class FlagsAttributeData : GirCustomAttributeData
        {
            public FlagsAttributeData () : base (typeof(FlagsAttribute))
            {
            }
        }

        class GirXmlAttributeData : GirCustomAttributeData
        {
            readonly string name;

            public GirXmlAttributeData (string name)
                : base (typeof(GirXmlAttribute), typeof(string))
            {
                this.name = name;
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (name);
            }
        }

        class ErrorDomainAttributeData : GirCustomAttributeData
        {
            readonly string name;

            public ErrorDomainAttributeData (string name)
                : base (typeof(ErrorDomainAttribute), typeof(string))
            {
                this.name = name;
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (name);
            }
        }

        class StructLayoutAttributeData : GirCustomAttributeData
        {
            readonly LayoutKind layoutKind;

            public StructLayoutAttributeData (LayoutKind layoutKind)
                : base (typeof(StructLayoutAttribute), typeof(LayoutKind))
            {
                this.layoutKind = layoutKind;
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (layoutKind);
            }
        }

        class FieldOffsetAttributeData : GirCustomAttributeData
        {
            readonly int offset;

            public FieldOffsetAttributeData (int offset)
                : base (typeof(FieldOffsetAttribute), typeof(int))
            {
                this.offset = offset;
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (offset);
            }
        }

        class UnmanagedFunctionPointerAttributeData : GirCustomAttributeData
        {
            public UnmanagedFunctionPointerAttributeData ()
                : base (typeof(UnmanagedFunctionPointerAttribute), typeof(CallingConvention))
            {
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (CallingConvention.Cdecl);
            }
        }

        class SinceAttributeData : GirCustomAttributeData
        {
            readonly string version;

            public SinceAttributeData (string version)
                : base (typeof(SinceAttribute), typeof(string))
            {
                this.version = version;
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (version);
            }
        }

        class DllImportAttributeData : GirCustomAttributeData
        {
            readonly string name;
            readonly MemberInfo callingConventionMemberInfo;

            public DllImportAttributeData (string name)
                : base (typeof(DllImportAttribute), typeof(string))
            {
                this.name = name;
                callingConventionMemberInfo = typeof(DllImportAttribute).GetField ("CallingConvention");
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (name);
            }

            protected override IEnumerable<CustomAttributeNamedArgument> GetNamedArguments ()
            {
                var arg = new CustomAttributeTypedArgument (typeof(CallingConvention), CallingConvention.Cdecl);
                yield return new CustomAttributeNamedArgument (callingConventionMemberInfo, arg);
            }
        }

        class InAttributeData : GirCustomAttributeData
        {
            public InAttributeData () : base (typeof(InAttribute))
            {
            }
        }

        class OutAttributeData : GirCustomAttributeData
        {
            public OutAttributeData () : base (typeof(OutAttribute))
            {
            }
        }

        class MarshalAsAttributeData : GirCustomAttributeData
        {
            readonly UnmanagedType type;
            readonly FieldInfo fieldMemberInfo;
            readonly object value;

            public MarshalAsAttributeData (UnmanagedType type, string field = null, object value = null)
                : base (typeof(MarshalAsAttribute), typeof(UnmanagedType))
            {
                this.type = type;
                if (field != null) {
                    fieldMemberInfo = typeof(MarshalAsAttribute).GetField (field);
                    if (fieldMemberInfo == null) {
                        var message = string.Format ("Could not find matching field '{0}'", field);
                        throw new ArgumentException (message, nameof(field));
                    }
                    this.value = value;
                }
            }

            protected override IEnumerable<CustomAttributeTypedArgument> GetConstructorArguments ()
            {
                yield return new CustomAttributeTypedArgument (type);
            }

            protected override IEnumerable<CustomAttributeNamedArgument> GetNamedArguments ()
            {
                if (fieldMemberInfo != null) {
                    var arg = new CustomAttributeTypedArgument (fieldMemberInfo.FieldType, value);
                    yield return new CustomAttributeNamedArgument (fieldMemberInfo, arg);
                }
            }
        }
    }
}
