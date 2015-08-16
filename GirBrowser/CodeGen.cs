using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.CSharp;
using System.Runtime.InteropServices;

namespace GirBrowser
{
    public static class CodeGen
    {
        static readonly XNamespace gi = "http://www.gtk.org/introspection/core/1.0";
        static readonly XNamespace c = "http://www.gtk.org/introspection/c/1.0";
        static readonly XNamespace glib = "http://www.gtk.org/introspection/glib/1.0";
        static readonly XNamespace gs = "http://lechnology.com/introspection/gisharp/1.0";

        static readonly CSharpCodeProvider codeProvider = new CSharpCodeProvider ();
        static readonly CodeGeneratorOptions codeGeneratorOptions = new CodeGeneratorOptions ();

        public static CodeObject ToCodeObject (this XElement element, bool useManagedTypes = false)
        {
            if (element == null) {
                throw new ArgumentNullException ("element");
            }
            switch (element.Name.LocalName) {
            case "alias":
                var alias = new CodeTypeDeclaration (element.Attribute ("name").Value) {
                    IsStruct = true,
                    IsPartial = true,
                };
                alias.CustomAttributes.Add (new CodeAttributeDeclaration (new CodeTypeReference (typeof(StructLayoutAttribute)),
                    new CodeAttributeArgument (new CodeFieldReferenceExpression (new CodeTypeReferenceExpression (typeof(LayoutKind)), LayoutKind.Sequential.ToString ()))));
                foreach (var child in element.Elements (gi + "type")) {
                    alias.Members.Add (new CodeMemberField ((CodeTypeReference)child.ToCodeObject (), "Value") {
                        Attributes = MemberAttributes.Public,
                    });
                }
                foreach (var child in element.Elements (gi + "constant")) {
                    alias.Members.Add ((CodeTypeMember)child.ToCodeObject ());
                }
                foreach (var child in element.Elements (gi + "function")) {
                    alias.Members.Add ((CodeTypeMember)child.ToCodeObject ());
                }
                alias.Comments.Add ((CodeCommentStatement)element.Element (gi + "doc").ToCodeObject ());
                return alias;
            case "bitfield":
            case "enumeration":
                var enumeration = new CodeTypeDeclaration (element.Attribute ("name").Value) {
                    IsEnum = true,
                };
                if (element.Name.LocalName == "bitfield") {
                    enumeration.CustomAttributes.Add (
                        new CodeAttributeDeclaration (new CodeTypeReference (typeof(FlagsAttribute)))
                    );
                }
                foreach (var child in element.Elements (gi + "doc")) {
                    enumeration.Comments.Add ((CodeCommentStatement)child.ToCodeObject ());
                }
                foreach (var child in element.Elements (gi + "member")) {
                    enumeration.Members.Add ((CodeTypeMember)child.ToCodeObject ());
                }
                return enumeration;
            case "constant":
                var constantType = (CodeTypeReference)element.Element (gi + "type").ToCodeObject (useManagedTypes: true);
                object constantValue = element.Attribute ("value").Value;
                switch (constantType.BaseType) {
                case "System.Byte":
                    constantValue = byte.Parse (constantValue.ToString ());
                    break;
                case "System.SByte":
                    constantValue = sbyte.Parse (constantValue.ToString ());
                    break;
                case "System.Int32":
                    constantValue = int.Parse (constantValue.ToString ());
                    break;
                case "System.UInt32":
                    constantValue = uint.Parse (constantValue.ToString ());
                    break;
                case "System.String":
                    break;
                default:
                    throw new ArgumentException (string.Format ("Bad constant type '{0}'.", constantType.BaseType));
                }
                var constant = new CodeMemberField (constantType, element.Attribute ("name").Value.ToPascalCase ()) {
                    InitExpression = new CodePrimitiveExpression (constantValue),
                    Attributes = MemberAttributes.Const | MemberAttributes.Public,
                };
                constant.Comments.Add ((CodeCommentStatement)element.Element (gi + "doc").ToCodeObject ());
                return constant;
            case "doc":
                if (element.Parent.Name == gi + "return-value") {
                    return new CodeCommentStatement (
                        string.Format ("<returns>{0}</returns>", element.Value),
                        docComment: true);
                }
                if (element.Parent.Name == gi + "parameter") {
                    return new CodeCommentStatement (
                        string.Format ("<param name=\"{0}\">{1}</param>",
                            element.Parent.Attribute ("name"), element.Value),
                        docComment: true);
                }

                string summary;
                var remarks = new StringBuilder ();
                using (var reader = new StringReader (element.Value)) {
                    summary = reader.ReadLine ();
                    while (true) {
                        var line = reader.ReadLine ();
                        if (line == null) {
                            break;
                        }
                        remarks.AppendFormat (" {0}\n", line);
                    }
                }
                var docString = string.Format ("<summary>\n {0}\n </summary>", summary);
                if (remarks.Length > 0) {
                    docString += string.Format ("\n <remarks>\n{0}\n </remarks>", remarks);
                }
                return new CodeCommentStatement (docString, docComment: true);
            case "field":
                var fieldType = (CodeTypeReference)element.Element (gi + "type").ToCodeObject ();
                var field = new CodeMemberField (fieldType, element.Attribute ("name").Value.ToCamelCase ());
                if (element.Attribute ("writeable") == null || element.Attribute ("writeable").Value != "1") {
                    // TODO: how to make readonly ?
                }
                return field;
            case "function":
                var function = new CodeMemberMethod () {
                    Name = element.Attribute ("name").Value,
                    ReturnType = (CodeTypeReference)element.Element (gi + "return-value").Element (gi + "type").ToCodeObject (),
                };
                function.Comments.Add ((CodeCommentStatement)element.Element (gi + "doc").ToCodeObject ());
                function.Comments.Add ((CodeCommentStatement)element.Element (gi + "return-value").Element (gi + "doc").ToCodeObject ());
                foreach (var p in element.Element (gi + "parameters").Elements (gi + "parameter")) {
                    function.Parameters.Add ((CodeParameterDeclarationExpression)p.ToCodeObject ());
                    function.Comments.Add ((CodeCommentStatement)p.Element (gi + "doc").ToCodeObject ());
                }
                return function;
            case "member":
                var member = new CodeMemberField ("int", element.Attribute ("name").Value.ToPascalCase ()) {
                    InitExpression = new CodePrimitiveExpression (int.Parse (element.Attribute ("value").Value))
                };
                return member;
            case "namespace":
                return new CodeNamespace (element.Attribute ("name").Value);
            case "parameter":
                var parameter = new CodeParameterDeclarationExpression(
                    (CodeTypeReference)element.Element (gi + "type").ToCodeObject (),
                    element.Attribute ("name").Value);
                return parameter;
            case "record":
                var referenceCounted = element.Descendants (gi + "function").Union (element.Descendants (gi + "method")).Attributes ("name").Any (a => a.Value == "ref")
                                       && element.Descendants (gi + "function").Union (element.Descendants (gi + "method")).Attributes ("name").Any (a => a.Value == "unref");
                var record = new CodeTypeDeclaration (element.Attribute ("name").Value) {
                    IsStruct = !referenceCounted,
                    IsPartial = true,
                };
                record.CustomAttributes.Add (new CodeAttributeDeclaration (new CodeTypeReference (typeof(StructLayoutAttribute)),
                    new CodeAttributeArgument (new CodeFieldReferenceExpression (new CodeTypeReferenceExpression (typeof(LayoutKind)), LayoutKind.Sequential.ToString ()))));
                if (referenceCounted) {
                    record.BaseTypes.Add ("ReferenceCountedOpaque");
                }
                foreach (var child in element.Elements (gi + "constant")) {
                    record.Members.Add ((CodeTypeMember)child.ToCodeObject ());
                }
                foreach (var child in element.Elements (gi + "field")) {
                    record.Members.Add ((CodeTypeMember)child.ToCodeObject ());
                }
                record.Comments.Add ((CodeCommentStatement)element.Element (gi + "doc").ToCodeObject ());
                return record;
            case "type":
                var name = element.Attribute ("name").Value;
                CodeTypeReference type;
                switch (name) {
                case "gint":
                case "gsize":
                case "gpointer":
                case "gconstpointer":
                    type = new CodeTypeReference (typeof(IntPtr));
                    break;
                case "guint":
                case "gusize":
                    type = new CodeTypeReference (typeof(UIntPtr));
                    break;
                case "gint8":
                    type = new CodeTypeReference (typeof(SByte));
                    break;
                case "guint8":
                    type = new CodeTypeReference (typeof(Byte));
                    break;
                case "gint16":
                    type = new CodeTypeReference (typeof(Int16));
                    break;
                case "guint16":
                    type = new CodeTypeReference (typeof(UInt16));
                    break;
                case "gint32":
                    type = new CodeTypeReference (typeof(Int32));
                    break;
                case "guint32":
                    type = new CodeTypeReference (typeof(UInt32));
                    break;
                case "gint64":
                    type = new CodeTypeReference (typeof(Int64));
                    break;
                case "guint64":
                    type = new CodeTypeReference (typeof(UInt64));
                    break;
                case "utf8":
                    if (useManagedTypes) {
                        type = new CodeTypeReference (typeof(String));
                    } else {
                        type = new CodeTypeReference (typeof(IntPtr));
                    }
                    break;
                default:
                    if (!name.Contains (".")) {
                        var @namespace = element.Ancestors (gi + "namespace").Single ().Attribute ("name").Value;
                        return new CodeTypeReference (string.Format ("{0}.{1}", @namespace, name));
                    }
                    type = new CodeTypeReference (name);
                    break;
                }
                return type;
            default:
                throw new ArgumentException ("Unsupported element type", "element");
            }
        }

        public static string ToCodeFragment (this XElement element)
        {
            var codeObject = element.ToCodeObject ();
            using (var writer = new StringWriter ()) {
                var codeCompileUnit = codeObject as CodeCompileUnit;
                if (codeCompileUnit != null) {
                    codeProvider.GenerateCodeFromCompileUnit (codeCompileUnit, writer, codeGeneratorOptions);
                    return writer.ToString ();
                }
                var codeExpression = codeObject as CodeExpression;
                if (codeExpression != null) {
                    codeProvider.GenerateCodeFromExpression (codeExpression, writer, codeGeneratorOptions);
                    return writer.ToString ();
                }
                var codeNamespace = codeObject as CodeNamespace;
                if (codeNamespace != null) {
                    codeProvider.GenerateCodeFromNamespace (codeNamespace, writer, codeGeneratorOptions);
                    return writer.ToString ();
                }
                var codeStatement = codeObject as CodeStatement;
                if (codeStatement != null) {
                    codeProvider.GenerateCodeFromStatement (codeStatement, writer, codeGeneratorOptions);
                    return writer.ToString ();
                }
                var codeType = codeObject as CodeTypeDeclaration;
                if (codeType != null) {
                    codeProvider.GenerateCodeFromType (codeType, writer, codeGeneratorOptions);
                    return writer.ToString ();
                }
                var codeTypeReference = codeObject as CodeTypeReference;
                if (codeTypeReference != null) {
                    codeProvider.GenerateCodeFromExpression (new CodeTypeOfExpression (codeTypeReference), writer, codeGeneratorOptions);
                    return writer.ToString ();
                }
                var codeTypeMember = codeObject as CodeTypeMember;
                if (codeTypeMember != null) {
                    codeProvider.GenerateCodeFromMember (codeTypeMember, writer, codeGeneratorOptions);
                }
                throw new ArgumentException ("Unsupported CodeObject", "element");
            }
        }
    }
}
