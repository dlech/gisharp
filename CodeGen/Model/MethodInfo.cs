using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GISharp.CodeGen.Model
{
    public class MethodInfo : MemberInfo
    {
        public bool IsConstructor {
            get {
                return Element.Name == gi + "constructor";
            }
        }

        public bool IsInstanceMethod {
            get {
                return Element.Name == gi + "method";
            }
        }

        public bool IsStaticMethod {
            get {
                return Element.Name == gi + "function";
            }
        }

        public bool IsPinvokeOnly {
            get {
                return Element.Attribute (gs + "pinvoke-only").AsBool ();
            }
        }

        public bool IsGetter {
            get {
                return Element.Attribute (gs + "managed-name").Value.StartsWith ("get_", StringComparison.Ordinal);
            }
        }

        public bool IsSetter {
            get {
                return Element.Attribute (gs + "managed-name").Value.StartsWith ("set_", StringComparison.Ordinal);
            }
        }

        public bool IsEquals {
            get {
                return Element.Attribute (gs + "special-func").AsString () == "equal";
            }
        }

        public bool IsCompare {
            get {
                return Element.Attribute (gs + "special-func").AsString () == "compare";
            }
        }

        List<ParameterInfo> _ManagedParameterInfos;
        public IReadOnlyList<ParameterInfo> ManagedParameterInfos {
            get {
                if (_ManagedParameterInfos == null) {
                    _ManagedParameterInfos = GetParameterElements (managed: true)
                        .Select (x => new ParameterInfo (x, this, managed: true))
                        .ToList ();
                }
                return _ManagedParameterInfos;
            }
        }

        List<ParameterInfo> _PinvokeParameterInfos;
        public IReadOnlyList<ParameterInfo> PinvokeParameterInfos {
            get {
                if (_PinvokeParameterInfos == null) {
                    _PinvokeParameterInfos = GetParameterElements (managed: false)
                        .Select (x => new ParameterInfo (x, this, managed: false))
                        .ToList ();
                }
                return _PinvokeParameterInfos;
            }
        }
        
        ParameterInfo _ManagedReturnParameterInfo;
        public ParameterInfo ManagedReturnParameterInfo {
            get {
                if (_ManagedReturnParameterInfo == null) {
                    _ManagedReturnParameterInfo = GetReturnParameterInfo (managed: true);
                }
                return _ManagedReturnParameterInfo;
            }
        }

        SyntaxToken _PinvokeIdentifier;
        public SyntaxToken PinvokeIdentifier { 
            get {
                if (_PinvokeIdentifier == default(SyntaxToken)) {
                    var cIdentifier = Element.Attribute (c + "identifier").Value;
                    _PinvokeIdentifier = SyntaxFactory.Identifier (cIdentifier);
                }
                return _PinvokeIdentifier;
            }
        }

        ParameterListSyntax _ParameterList;
        public ParameterListSyntax ParameterList {
            get {
                if (_ParameterList == default(ParameterListSyntax)) {
                    var parameterList = SyntaxFactory.SeparatedList<ParameterSyntax> ()
                        .AddRange (ManagedParameterInfos.Select (x => x.Parameter));
                    _ParameterList = SyntaxFactory.ParameterList (parameterList);
                }
                return _ParameterList;
            }
        }

        ParameterInfo _UnmanagedReturnParameterInfo;
        public ParameterInfo UnmanagedReturnParameterInfo {
            get {
                if (_UnmanagedReturnParameterInfo == null) {
                    _UnmanagedReturnParameterInfo = GetReturnParameterInfo (managed: false);
                }
                return _UnmanagedReturnParameterInfo;
            }
        }

        ParameterListSyntax _PinvokeParameterList;
        public ParameterListSyntax PinvokeParameterList {
            get {
                if (_PinvokeParameterList == default(ParameterListSyntax)) {
                    var parameterList = SyntaxFactory.SeparatedList<ParameterSyntax> ()
                        .AddRange (PinvokeParameterInfos.Select (x => x.Parameter));
                    _PinvokeParameterList = SyntaxFactory.ParameterList (parameterList);
                }
                return _PinvokeParameterList;
            }
        }

        SyntaxTokenList _PinvokeModifiers;
        public SyntaxTokenList PinvokeModifiers {
            get {
                if (_PinvokeModifiers == default(SyntaxTokenList)) {
                    _PinvokeModifiers = SyntaxFactory.TokenList (GetPinvokeModifiers ());
                }
                return _PinvokeModifiers;
            }
        }

        SyntaxList<AttributeListSyntax> _PinvokeAttributeLists;
        public SyntaxList<AttributeListSyntax> PinvokeAttributeLists {
            get {
                if (_PinvokeAttributeLists == default(SyntaxList<AttributeListSyntax>)) {
                    _PinvokeAttributeLists = SyntaxFactory.List<AttributeListSyntax> ()
                        .AddRange (GetPinvokeAttributeLists ());
                }
                return _PinvokeAttributeLists;
            }
        }

        SyntaxTriviaList _PinvokeDocumentationCommentTriviaList;
        public SyntaxTriviaList PinvokeDocumentationCommentTriviaList {
            get {
                if (_PinvokeDocumentationCommentTriviaList == default(SyntaxTriviaList)) {
                    _PinvokeDocumentationCommentTriviaList = GetPinvokeDocumentationCommentTriviaList ();
                }
                return _PinvokeDocumentationCommentTriviaList;
            }
        }

        public MethodInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "function" && element.Name != gi + "method" && element.Name != gi + "constructor" && element.Name != gi + "callback") {
                throw new ArgumentException ("Requires <fuction>, <method>, <constructor> or <callback> element.", nameof(element));
            }
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            var pinvokeMethod = SyntaxFactory.MethodDeclaration (
                UnmanagedReturnParameterInfo.TypeInfo.Type,
                PinvokeIdentifier
                    .WithTrailingTrivia (UnmanagedReturnParameterInfo.AnnotationTriviaList))
                .WithAttributeLists (PinvokeAttributeLists)
                .WithModifiers (PinvokeModifiers)
                .WithParameterList (PinvokeParameterList)
                .WithSemicolonToken (SyntaxFactory.Token (SyntaxKind.SemicolonToken))
                .WithLeadingTrivia (PinvokeDocumentationCommentTriviaList);
            yield return pinvokeMethod;
            if (!IsPinvokeOnly) {
                var body = SyntaxFactory.Block (GetStatements ());
                if (IsConstructor) {
                    var constructorDeclaration = SyntaxFactory.ConstructorDeclaration (DeclaringMember.Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithParameterList (ParameterList)
                        .WithBody (body)
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                    yield return constructorDeclaration;
                } else if (IsGetter) {
                    var propertyGetter = SyntaxFactory.AccessorDeclaration (SyntaxKind.GetAccessorDeclaration, body);
                    var propertyAccessorList = SyntaxFactory.AccessorList ()
                        .AddAccessors (propertyGetter);
                    var propertySetterMethodInfo = (DeclaringMember as TypeDeclarationInfo)?.MethodInfos
                        .SingleOrDefault (x => x.ManagedName == ManagedName.Replace ("get_", "set_"));
                    if (propertySetterMethodInfo != null) {
                        var propertySetterBody = SyntaxFactory.Block (propertySetterMethodInfo.GetStatements ());
                        var propertySetter = SyntaxFactory.AccessorDeclaration (SyntaxKind.SetAccessorDeclaration, propertySetterBody);
                        // TODO: add modifiers to setter if they are different than getter
                        propertyAccessorList = propertyAccessorList.AddAccessors (propertySetter);
                    }
                    var propertyDeclaration = SyntaxFactory.PropertyDeclaration (ManagedReturnParameterInfo.TypeInfo.Type, ManagedName.Substring (4))
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithAccessorList (propertyAccessorList)
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                    yield return propertyDeclaration;
                } else if (IsSetter) {
                    // This is handled in IsGetter - there should be *no* set-only properties
                } else {
                    var methodDeclaration = SyntaxFactory.MethodDeclaration (ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithParameterList (ParameterList)
                        .WithBody (body)
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                        yield return methodDeclaration;
                    if (IsEquals) {
                        yield return CreateOverrideEqualsMethod ();
                        yield return CreateEqualityOperator ();
                        yield return CreateInequalityOperator ();
                        // TODO: override hash code
                    }
                    if (IsCompare) {
                        yield return CreateCompareToOperator (">=");
                        yield return CreateCompareToOperator (">");
                        yield return CreateCompareToOperator ("<");
                        yield return CreateCompareToOperator ("<=");
                    }
                }
            }
        }

        IEnumerable<StatementSyntax> GetStatements ()
        {
            foreach (var s in GetArgumentCheckStatements ()) {
                yield return s;
            }
            foreach (var s in GetMarshalManagedToNativeParameterStatements ()) {
                yield return s;
            }
            foreach (var s in GetArrayLengthAssignmentStatements ()) {
                yield return s;
            }
            yield return GetPinvokeInvocationStatement ();

            // TODO: these are temporary
            foreach (var p in ManagedParameterInfos.Where (x => x.IsOutParam)) {
                var assignOutParam = string.Format ("{0} = default({1});",
                    p.ManagedName, p.TypeInfo.Type);
                yield return SyntaxFactory.ParseStatement (assignOutParam);
            }
            if (!IsConstructor && ManagedReturnParameterInfo.TypeInfo.TypeObject != typeof(void)) {
                var returnDefault = string.Format ("return default({0});",
                    ManagedReturnParameterInfo.TypeInfo.Type);
                yield return SyntaxFactory.ParseStatement (returnDefault);
            }
        }

        IEnumerable<StatementSyntax> GetArgumentCheckStatements ()
        {
            // check for parameters where null is not allowed

            foreach (var p in ManagedParameterInfos.Where (x => x.NeedsNullCheck)) {
                var statement = SyntaxFactory.ParseStatement (
                    string.Format (@"if ({0} == null) {{
                        throw new {1} (""{0}"");
                    }}", p.Identifier.Text,
                        typeof(ArgumentNullException).FullName));
                yield return statement;
            }
            // TODO: check Element.Attribute (gs + "arg-check) for statements
        }

        IEnumerable<StatementSyntax> GetMarshalManagedToNativeParameterStatements ()
        {
            foreach (var p in PinvokeParameterInfos.Where (x => x.DestoryIndex >= 0)) {
                var destroyParam = PinvokeParameterInfos[p.DestoryIndex];
                // TODO: needs real implementation
                var statement = string.Format ("var {0}Native = default({1});\n",
                    destroyParam.Identifier, destroyParam.TypeInfo.Type);
                yield return SyntaxFactory.ParseStatement (statement);
            }
            foreach (var p in PinvokeParameterInfos.Where (x => x.ClosureIndex >= 0)) {
                var closureParam = PinvokeParameterInfos[p.ClosureIndex];
                // TODO: needs real implementation
                var statement = string.Format ("var {0} = default({1});\n",
                    closureParam.Identifier, typeof(IntPtr).FullName);
                yield return SyntaxFactory.ParseStatement (statement);
            }
            foreach (var p in ManagedParameterInfos.Where (x => x.TypeInfo.RequiresMarshal)) {
                var nativeParameter = PinvokeParameterInfos.Single (x => x.GirName == p.GirName);
                // TODO: needs real implementation
                if (p.TypeInfo.TypeObject.IsDelegate ()) {
                    var statement = string.Format ("var {0}Native = default({1});\n",
                        p.Identifier,
                        nativeParameter.TypeInfo.Type);
                    yield return SyntaxFactory.ParseStatement (statement);
                } else {
                    var statement = string.Format ("var {0}Ptr = default({1});\n",
                                    p.Identifier,
                                    typeof(IntPtr).FullName);
                    yield return SyntaxFactory.ParseStatement (statement);
                }
            }
            foreach (var p in PinvokeParameterInfos.Where (x => x.IsErrorParameter)) {
                var statement = string.Format ("{0} {1};\n", typeof(IntPtr).FullName, p.Identifier);
                yield return SyntaxFactory.ParseStatement (statement);
            }
        }

        IEnumerable<StatementSyntax> GetArrayLengthAssignmentStatements ()
        {
            var parameters = new[] { UnmanagedReturnParameterInfo }
                .Union (PinvokeParameterInfos)
                .Where (x => x.TypeInfo.ArrayLengthIndex >= 0);
            foreach (var p in parameters) {
                var lengthParameter = PinvokeParameterInfos[p.TypeInfo.ArrayLengthIndex];
                if (p.IsInParam) {
                    var statement = string.Format ("var {0} = ({1}){2}.Length;\n",
                        lengthParameter.Identifier,
                        lengthParameter.TypeInfo.Type,
                        p.Identifier);
                    yield return SyntaxFactory.ParseStatement (statement);
                } else {
                    var statement = string.Format ("{0} {1};\n",
                        lengthParameter.TypeInfo.Type,
                        lengthParameter.Identifier);
                    yield return SyntaxFactory.ParseStatement (statement);
                }
            }
        }

        StatementSyntax GetPinvokeInvocationStatement () {
            var pinvokeExpression = SyntaxFactory.InvocationExpression (
                SyntaxFactory.IdentifierName (PinvokeIdentifier));
            var argumentList = SyntaxFactory. ArgumentList ();
            foreach (var p in PinvokeParameterInfos) {
                var name = string.Format ("{0} {1}", p.Modifiers,
                    // setters use "value" keyword for parameter
                    ManagedName.StartsWith ("set_", StringComparison.Ordinal) ? "value" : p.ManagedName);
                if (p.IsInstanceParameter) {
                    name = "Handle";
                } else if (p.TypeInfo.TypeObject.IsDelegate ()) {
                    name += "Native";
                } else if (p.TypeInfo.RequiresMarshal) {
                    name += "Ptr";
                }
                var arg = SyntaxFactory.Argument (SyntaxFactory.ParseExpression (name));
                argumentList = argumentList.AddArguments (arg);
            }
            pinvokeExpression = pinvokeExpression.WithArgumentList (argumentList);

            StatementSyntax statement = SyntaxFactory.ExpressionStatement (pinvokeExpression);
            if (IsConstructor) {
                statement = SyntaxFactory.ExpressionStatement (
                    SyntaxFactory.AssignmentExpression (SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.ParseExpression ("Handle"), pinvokeExpression));
            } else if (ManagedReturnParameterInfo.TypeInfo.TypeObject != typeof(void)) {
                var ret = "ret";
                if (ManagedReturnParameterInfo.TypeInfo.RequiresMarshal) {
                    ret += "Ptr";
                }
                statement = SyntaxFactory.LocalDeclarationStatement (
                    SyntaxFactory.VariableDeclaration (SyntaxFactory.ParseTypeName ("var"))
                    .AddVariables (SyntaxFactory.VariableDeclarator (SyntaxFactory.ParseToken (ret))
                    .WithInitializer (SyntaxFactory.EqualsValueClause (pinvokeExpression))));
            }
            return statement;
        }

        MethodDeclarationSyntax CreateOverrideEqualsMethod ()
        {
            var syntax = SyntaxFactory.MethodDeclaration (
                SyntaxFactory.ParseTypeName ("bool"),
                SyntaxFactory.ParseToken ("Equals"))
                .WithModifiers (SyntaxFactory.TokenList (
                    SyntaxFactory.ParseTokens ("public override")))
                .WithParameterList (SyntaxFactory.ParseParameterList ("(object obj)"))
                .WithBody (SyntaxFactory.Block ()
                    .AddStatements (
                        SyntaxFactory.ParseStatement (
                            string.Format ("return Equals (obj as {0});", DeclaringMember.ManagedName))));
            return syntax;
        }

        MethodDeclarationSyntax CreateOverrideGetHashCodeMethod (string hashFunc)
        {
            var syntax = SyntaxFactory.MethodDeclaration (
                SyntaxFactory.ParseTypeName ("int"),
                SyntaxFactory.ParseToken ("GetHashCode"))
                .WithModifiers (SyntaxFactory.TokenList (
                    SyntaxFactory.ParseTokens ("public override")))
                .WithBody (SyntaxFactory.Block ()
                    .AddStatements (
                        SyntaxFactory.ParseStatement (
                            string.Format ("return {0};", hashFunc))));
            return syntax;
        }

        OperatorDeclarationSyntax CreateEqualityOperator ()
        {
            var syntax = SyntaxFactory.OperatorDeclaration (
                SyntaxFactory.ParseTypeName ("bool"),
                SyntaxFactory.ParseToken ("=="))
                .WithModifiers (SyntaxFactory.TokenList (
                    SyntaxFactory.ParseTokens ("public static")))
                .WithParameterList (SyntaxFactory.ParseParameterList (
                    string.Format ("({0} one, {0} two)", DeclaringMember.ManagedName)))
                .WithBody (SyntaxFactory.Block ()
                    .AddStatements (
                        SyntaxFactory.ParseStatement (@"
                            if ((object)one == null) {
                                return (object)two == null;
                            }"),
                        SyntaxFactory.ParseStatement (
                            "return one.Equals (two);")));
            return syntax;
        }

        OperatorDeclarationSyntax CreateInequalityOperator ()
        {
            var syntax = SyntaxFactory.OperatorDeclaration (
                SyntaxFactory.ParseTypeName ("bool"),
                SyntaxFactory.ParseToken ("!="))
                .WithModifiers (SyntaxFactory.TokenList (
                    SyntaxFactory.ParseTokens ("public static")))
                .WithParameterList (SyntaxFactory.ParseParameterList (
                    string.Format ("({0} one, {0} two)", DeclaringMember.ManagedName)))
                .WithBody (SyntaxFactory.Block ()
                    .AddStatements (SyntaxFactory.ParseStatement (
                        "return !(one == two);")));
            return syntax;
        }

        OperatorDeclarationSyntax CreateCompareToOperator (string @operator)
        {
            var syntax = SyntaxFactory.OperatorDeclaration (
                SyntaxFactory.ParseTypeName ("bool"),
                SyntaxFactory.ParseToken (@operator))
                .WithModifiers (SyntaxFactory.TokenList (
                    SyntaxFactory.ParseTokens ("public static")))
                .WithParameterList (SyntaxFactory.ParseParameterList (
                    string.Format ("({0} one, {0} two)", DeclaringMember.ManagedName)))
                .WithBody (SyntaxFactory.Block ()
                    .AddStatements (SyntaxFactory.ParseStatement (
                        string.Format ("return one.CompareTo (two) {0} 0;", @operator))));

            return syntax;
        }

        ParameterInfo GetReturnParameterInfo (bool managed)
        {
            var returnValueElement = Element.Element (gi + "return-value");
            if (returnValueElement == null || (managed && returnValueElement.Attribute ("skip").AsBool ())) {
                var voidElement = new XElement (gi + "return-value",
                    new XAttribute (gs + "managed-type", "System.Void"));
                return new ParameterInfo (voidElement, this, managed);
            }

            return new ParameterInfo (returnValueElement, this, managed);
        }

        IEnumerable<XElement> GetParameterElements (bool managed)
        {
            var childElementName = managed ? gs + "managed-parameters" : gi + "parameters";
            var parametersElement = Element.Element (childElementName);

            if (parametersElement == null) {
                if (Element.Element (gi + "return-value") != null) {
                    // if we have a <return-value>, then we can assume that this is a
                    // proper node and just does not have any parameters.
                    // Alternatly, we could check if this is function/method/constructor/callback
                    yield break;
                }
                var message = string.Format ("Expecting element with <{0}> child element.", childElementName.LocalName);
                throw new Exception (message);
            } 
            var instanceParameter = parametersElement.Element (gi + "instance-parameter");
            if (instanceParameter != null) {
                yield return instanceParameter;
            }
            foreach (var parameter in parametersElement.Elements (gi + "parameter")) {
                yield return parameter;
            }
            var errorParameter = parametersElement.Element (gs + "error-parameter");
            if (errorParameter != null) {
                yield return errorParameter;
            }
        }

        protected override IEnumerable<SyntaxToken> GetModifiers ()
        {
            foreach (var baseModifier in base.GetModifiers ()) {
                yield return baseModifier;
            }
            if (IsStaticMethod) {
                yield return SyntaxFactory.Token (SyntaxKind.StaticKeyword);
            }
        }

        protected override SyntaxTriviaList GetDocumentationCommentTriviaList ()
        {
            var list = base.GetDocumentationCommentTriviaList ()
                .AddRange (ManagedParameterInfos.SelectMany (x => x.DocumentationCommentTriviaList))
                .AddRange (ManagedReturnParameterInfo.DocumentationCommentTriviaList);
            return list;
        }

        IEnumerable<SyntaxToken> GetPinvokeModifiers ()
        {
            yield return SyntaxFactory.Token (SyntaxKind.StaticKeyword);
            yield return SyntaxFactory.Token (SyntaxKind.ExternKeyword);
        }

        IEnumerable<AttributeListSyntax> GetPinvokeAttributeLists ()
        {
            foreach (var baseAttr in base.GetAttributeLists ()) {
                yield return baseAttr;
            }
            var dllName = Element.Ancestors (gi + "repository")
                .Single ().Element (gi + "package").Attribute ("name").Value + ".dll";
            var dllImportAttrName = SyntaxFactory.ParseName (typeof(DllImportAttribute).FullName);
            var dllImportAttrArgListText = string.Format ("(\"{0}\", CallingConvention = {1}.{2})",
                dllName,
                typeof(CallingConvention).FullName,
                CallingConvention.Cdecl);
            var dllImportAttrArgList = SyntaxFactory.ParseAttributeArgumentList (dllImportAttrArgListText);
            var dllImportAttr = SyntaxFactory.Attribute (dllImportAttrName)
                .WithArgumentList (dllImportAttrArgList);
            yield return SyntaxFactory.AttributeList ().AddAttributes (dllImportAttr);
        }

        SyntaxTriviaList GetPinvokeDocumentationCommentTriviaList ()
        {
            var list = base.GetDocumentationCommentTriviaList ()
                .AddRange (PinvokeParameterInfos.SelectMany (x => x.DocumentationCommentTriviaList))
                .AddRange (UnmanagedReturnParameterInfo.DocumentationCommentTriviaList);
            return list;
        }
    }
}

