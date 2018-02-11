using System;
using System.Collections.Generic;
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

        public bool IsVirtualMethod {
            get {
                return Element.Name == gi + "virtual-method";
            }
        }

        public bool IsStaticMethod {
            get {
                return Element.Name == gi + "function" || IsExtensionMethod;
            }
        }

        public bool IsExtensionMethod {
            get {
                return Element.Attribute (gs + "extension-method").AsBool ();
            }
        }

        public bool IsPinvokeOnly {
            get {
                return Element.Attribute (gs + "pinvoke-only").AsBool ();
            }
        }

        public bool IsGetter {
            get {
                return Element.Attribute (gs + "managed-name").Value
                              .StartsWith ("get_", StringComparison.Ordinal);
            }
        }

        public bool IsSetter {
            get {
                return Element.Attribute (gs + "managed-name").Value
                              .StartsWith ("set_", StringComparison.Ordinal);
            }
        }

        public bool IsCopy => Element.Attribute(gs + "special-func").AsString() == "copy";

        public bool IsFree => Element.Attribute(gs + "special-func").AsString() == "free";

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

        public bool HasCustomArgCheck {
            get {
                return Element.Attribute (gs + "custom-arg-check").AsBool ();
            }
        }

        public bool ThrowsGErrorException {
            get {
                return Element.Attribute ("throws").AsBool ();
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

        SyntaxToken? _PinvokeIdentifier;
        public SyntaxToken PinvokeIdentifier { 
            get {
                if (!_PinvokeIdentifier.HasValue) {
                    var cIdentifier = Element.Attribute (c + "identifier").Value;
                    _PinvokeIdentifier = Identifier (cIdentifier);
                }
                return _PinvokeIdentifier.Value;
            }
        }

        ParameterListSyntax _ParameterList;
        public ParameterListSyntax ParameterList {
            get {
                if (_ParameterList == null) {
                    var parameterList = SeparatedList<ParameterSyntax> ()
                        .AddRange (ManagedParameterInfos.Select (x => x.Parameter));
                    _ParameterList = ParameterList (parameterList);
                }
                return _ParameterList;
            }
        }

        ConstructorInitializerSyntax _ConstructorInitializer;
        public ConstructorInitializerSyntax ConstructorInitializer {
            get {
                if (_ConstructorInitializer == null) {
                    _ConstructorInitializer = GetConstructorInitializer();
                }
                return _ConstructorInitializer;
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

        ParameterListSyntax _UnmanagedParameterList;
        public ParameterListSyntax UnmanagedParameterList {
            get {
                if (_UnmanagedParameterList == null) {
                    var parameterList = SeparatedList<ParameterSyntax> ()
                        .AddRange (PinvokeParameterInfos.Select (
                            x => x.Parameter.WithIdentifier (ParseToken (x.Identifier.Text + "_"))));
                    _UnmanagedParameterList = ParameterList (parameterList);
                }
                return _UnmanagedParameterList;
            }
        }

        ParameterListSyntax _PinvokeParameterList;
        public ParameterListSyntax PinvokeParameterList {
            get {
                if (_PinvokeParameterList == null) {
                    var parameterList = SeparatedList<ParameterSyntax> ()
                        .AddRange (PinvokeParameterInfos.Select (
                            x => x.Parameter.WithLeadingTrivia (
                                x.TypeInfo.GirXmlTrivia,
                                EndOfLine("\n"),
                                x.AnnotationTrivia,
                                EndOfLine("\n"))));
                    _PinvokeParameterList = ParameterList (parameterList);
                }
                return _PinvokeParameterList;
            }
        }

        SyntaxTokenList? _PinvokeModifiers;
        public SyntaxTokenList PinvokeModifiers {
            get {
                if (!_PinvokeModifiers.HasValue) {
                    _PinvokeModifiers = TokenList (GetPinvokeModifiers ());
                }
                return _PinvokeModifiers.Value;
            }
        }

        SyntaxList<AttributeListSyntax>? _PinvokeAttributeLists;
        public SyntaxList<AttributeListSyntax> PinvokeAttributeLists {
            get {
                if (!_PinvokeAttributeLists.HasValue) {
                    _PinvokeAttributeLists = List<AttributeListSyntax>(GetPinvokeAttributeLists());
                }
                return _PinvokeAttributeLists.Value;
            }
        }

        SyntaxTriviaList? _PinvokeDocumentationCommentTriviaList;
        public SyntaxTriviaList PinvokeDocumentationCommentTriviaList {
            get {
                if (!_PinvokeDocumentationCommentTriviaList.HasValue) {
                    _PinvokeDocumentationCommentTriviaList = GetPinvokeDocumentationCommentTriviaList ();
                }
                return _PinvokeDocumentationCommentTriviaList.Value;
            }
        }

        SyntaxList<StatementSyntax>? _CallbackStatements;
        public SyntaxList<StatementSyntax> CallbackStatements {
            get {
                if (!_CallbackStatements.HasValue) {
                    _CallbackStatements = List<StatementSyntax> ()
                        .AddRange (GetCallbackStatements ());
                }
                return _CallbackStatements.Value;
            }
        }

        SyntaxList<StatementSyntax>? _VirtualMethodImplStatements;
        public SyntaxList<StatementSyntax> VirtualMethodImplStatements {
            get {
                if (!_VirtualMethodImplStatements.HasValue) {
                    _VirtualMethodImplStatements = List<StatementSyntax> ()
                        .AddRange (GetVirtualMethodImplStatements ());
                }
                return _VirtualMethodImplStatements.Value;
            }
        }

        public MethodInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "function" && element.Name != gi + "method" && element.Name != gi + "virtual-method" && element.Name != gi + "constructor" && element.Name != gi + "callback") {
                throw new ArgumentException("Requires <function>, <method>, <virtual-method> <constructor> or <callback> element.", nameof(element));
            }
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return new BaseInfo[] {
                UnmanagedReturnParameterInfo,
                ManagedReturnParameterInfo
            }
                .Concat (PinvokeParameterInfos)
                .Concat (ManagedParameterInfos);
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            if (IsVirtualMethod) {
                var iface = DeclaringMember as InterfaceInfo;
                if (iface != null) {
                    var methodDeclaration = MethodDeclaration (ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithParameterList (ParameterList)
                        .WithSemicolonToken (Token (SyntaxKind.SemicolonToken))
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                    yield return methodDeclaration;
                }
                yield break;
            }
            var pinvokeMethod = MethodDeclaration (
                UnmanagedReturnParameterInfo.TypeInfo.Type,
                PinvokeIdentifier)
                .WithAttributeLists (PinvokeAttributeLists)
                .WithModifiers (PinvokeModifiers.Replace (
                    // add type info xml comment before declaration, but after attributes
                    PinvokeModifiers.First (),
                    PinvokeModifiers.First ().WithLeadingTrivia (
                        UnmanagedReturnParameterInfo.TypeInfo.GirXmlTrivia,
                        EndOfLine ("\n"),
                        UnmanagedReturnParameterInfo.AnnotationTrivia)))
                .WithParameterList (PinvokeParameterList)
                .WithSemicolonToken (Token (SyntaxKind.SemicolonToken))
                .WithLeadingTrivia (PinvokeDocumentationCommentTriviaList);
            yield return pinvokeMethod;
            if (!IsPinvokeOnly) {
                var body = Block (GetStatements ());
                if (IsGetter) {
                    var propertyGetter = AccessorDeclaration (SyntaxKind.GetAccessorDeclaration, body);
                    var propertyAccessorList = AccessorList ()
                        .AddAccessors (propertyGetter);
                    var propertySetterMethodInfo = (DeclaringMember as TypeDeclarationInfo)?.MethodInfos
                        .SingleOrDefault (x => x.ManagedName == ManagedName.Replace ("get_", "set_"));
                    if (propertySetterMethodInfo != null) {
                        var propertySetterBody = Block (propertySetterMethodInfo.GetStatements ());
                        var propertySetter = AccessorDeclaration (SyntaxKind.SetAccessorDeclaration, propertySetterBody);
                        // TODO: add modifiers to setter if they are different than getter
                        propertyAccessorList = propertyAccessorList.AddAccessors (propertySetter);
                    }
                    var propertyDeclaration = PropertyDeclaration (ManagedReturnParameterInfo.TypeInfo.Type, ManagedName.Substring (4))
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithAccessorList (propertyAccessorList)
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                    yield return propertyDeclaration;
                } else if (IsSetter) {
                    // This is handled in IsGetter - there should be *no* set-only properties
                } else {
                    var methodDeclaration = MethodDeclaration (ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithParameterList (ParameterList)
                        .WithBody (body)
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                    if (IsConstructor) {
                        // replace return type with IntPtr and make private static
                        methodDeclaration = methodDeclaration
                            .WithReturnType (ParseTypeName (typeof(IntPtr).FullName))
                            .WithModifiers (TokenList ().Add (Token (SyntaxKind.StaticKeyword)));
                    }
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
                if (IsConstructor) {
                    // actual constructor that calls the private static method created above
                    var constructorDeclaration = ConstructorDeclaration (DeclaringMember.Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithParameterList(ParameterList)
                        .WithInitializer(ConstructorInitializer)
                        .WithBody (Block ())
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                    yield return constructorDeclaration;
                }
            }
        }

        IEnumerable<StatementSyntax> GetStatements ()
        {
            if (IsInstanceMethod && DeclaringMember is ClassInfo) {
                var statement = "var this_ = this.Handle;\n";
                yield return ParseStatement (statement);
            }
            foreach (var s in GetArgumentCheckStatements ()) {
                yield return s;
            }
            var freeStatements = new List<StatementSyntax> ();
            foreach (var p in ManagedParameterInfos.Where (x => x.TypeInfo.RequiresMarshal)) {
                if (p.IsInParam) {
                    foreach (var (statement, freeStatement) in GetMarshalManagedToUnmanagedParameterStatements(p, true)) {
                        yield return statement;
                        if (freeStatement != null) {
                            freeStatements.Add(freeStatement);
                        }
                    }
                } else {
                    var unmangedParameter = PinvokeParameterInfos.Single (x => x.GirName == p.GirName);
                    yield return LocalDeclarationStatement (
                        VariableDeclaration(unmangedParameter.TypeInfo.Type)
                        .AddVariables (VariableDeclarator (unmangedParameter.ManagedName + "_")));
                }
            }
            foreach (var s in GetArrayLengthAssignmentStatements ()) {
                yield return s;
            }
            if (ThrowsGErrorException) {
                var statement = string.Format (
                    "{0} {1}_;\n",
                    typeof(IntPtr).FullName,
                    PinvokeParameterInfos.Single (x => x.IsErrorParameter).Identifier);
                yield return ParseStatement (statement);
            }
            yield return GetPinvokeInvocationStatement ();

            if (ThrowsGErrorException) {
                var errorIdentifier = PinvokeParameterInfos.Single (x => x.IsErrorParameter).Identifier;
                var conditionExpression = string.Format ("{0}_ != {1}.{2}",
                    errorIdentifier,
                    typeof(IntPtr).FullName,
                    nameof (IntPtr.Zero));
                var marshalStatement = string.Format ("var {0} = {1}.{2}<{3}> ({0}_, {4}.{5});",
                    errorIdentifier,
                    typeof (GISharp.Runtime.Opaque).FullName,
                    nameof (GISharp.Runtime.Opaque.GetInstance),
                    typeof (GISharp.GLib.Error).FullName,
                    typeof (GISharp.Runtime.Transfer).FullName,
                    nameof (GISharp.Runtime.Transfer.Full));
                var throwStatement = string.Format ("throw new {0} ({1});",
                    typeof(GISharp.Runtime.GErrorException).FullName,
                    errorIdentifier);
                yield return IfStatement(
                    ParseExpression (conditionExpression),
                    Block (
                        ParseStatement (marshalStatement + "\n"),
                        ParseStatement(throwStatement)));
            }

            // must marshal output parameters before freeing input parameters
            // in case input parameters are passed through as output parameters
            var marshalOutStatements = ManagedParameterInfos.Where(x => x.IsOutParam)
                .SelectMany(p => GetMarshalUnmanagedToManagedStatements(p, false));
            foreach (var statement in marshalOutStatements) {
                yield return statement;
            }

            foreach (var statement in freeStatements) {
                yield return statement;
            }

            if (!IsConstructor) {
                var marshalReturnStatements = GetMarshalUnmanagedToManagedStatements(ManagedReturnParameterInfo, true);
                foreach (var statement in marshalReturnStatements) {
                    yield return statement;
                }
            }

            var returnStatements = GetReturnStatements();
            foreach (var statement in returnStatements) {
                yield return statement;
            }
        }

        IEnumerable<StatementSyntax> GetArgumentCheckStatements ()
        {
            if (HasCustomArgCheck) {
                var invocation = InvocationExpression (
                    ParseExpression (string.Format ("Assert{0}Args", Identifier)));
                foreach (var p in ManagedParameterInfos.Where (x => x.IsInParam)) {
                    var item = Argument (ParseExpression(p.Identifier.Text));
                    invocation = invocation.AddArgumentListArguments (item);
                }
                var statement = ExpressionStatement (invocation);
                yield return statement;
            }
        }

        IEnumerable<ValueTuple<StatementSyntax, StatementSyntax>> GetMarshalManagedToUnmanagedParameterStatements(ParameterInfo managedParameter, bool declareVariable)
        {
            if (!managedParameter.TypeInfo.RequiresMarshal) {
                yield break;
            }
            var pinvokeParameter = managedParameter.IsReturnParameter
                ? UnmanagedReturnParameterInfo
                : PinvokeParameterInfos.Single (x => x.GirName == managedParameter.GirName);
            string statement;
            switch (managedParameter.TypeInfo.Classification) {
            case TypeClassification.CArray:
            case TypeClassification.CPtrArray:
                var nullValue = managedParameter.NeedsNullCheck ?
                    string.Format("throw new {0}(nameof({1}))",
                        typeof(ArgumentNullException).FullName, managedParameter.Identifier) :
                    string.Format("{0}.{1}", typeof(IntPtr).FullName, nameof(IntPtr.Zero));
                var dataGetter = managedParameter.Transfer == Runtime.Transfer.None ? "Data" : "TakeData()";
                statement = string.Format ("{0}_ = {0}?.{1} ?? {2};\n",
                    managedParameter.Identifier, dataGetter, nullValue);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return (ParseStatement(statement), null);
                break;
            case TypeClassification.Delegate:
                statement = string.Format (
                    "{0}_ = {1}Factory.Create ({0}, {2});\n",
                    managedParameter.Identifier,
                    pinvokeParameter.TypeInfo.Type,
                    // By defintion, scope of async is only called once, so we free userData
                    // other scopes can be called multiple times, so userData is freed elsewhere
                    pinvokeParameter.Scope == GISharp.Runtime.CallbackScope.Async ? "true" : "false");
                // TODO: need to find better way to handle delegates
                statement = string.Format ("{0}_ = default({1});", managedParameter.Identifier, pinvokeParameter.TypeInfo.Type);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return (ParseStatement(statement), null);
                statement = string.Format ("throw new {0} ();", typeof(NotImplementedException).FullName);
                yield return (ParseStatement(statement), null);
                if (pinvokeParameter.ClosureIndex >= 0) {
                    var closureParameter = PinvokeParameterInfos[pinvokeParameter.ClosureIndex];
                    var closureHandle = Identifier (pinvokeParameter.Identifier + "Handle");
                    var closureHandleStatement = string.Format (
                        "var {0} = {1}.{2} ({3});\n",
                        closureHandle,
                        typeof(GCHandle).FullName,
                        nameof(GCHandle.Alloc),
                        pinvokeParameter.Identifier);
                    var closureHandleFreeStatement = string.Format (
                        "{0}.{1} ();\n",
                        closureHandle,
                        nameof(GCHandle.Free));
                    yield return (ParseStatement(closureHandleStatement),
                        pinvokeParameter.Scope == GISharp.Runtime.CallbackScope.Call
                        ? ParseStatement (closureHandleFreeStatement) : null);
                    
                    if (pinvokeParameter.DestoryIndex >= 0) {
                        var notifyParameter = PinvokeParameterInfos[pinvokeParameter.DestoryIndex];
                        var notifyStatement = string.Format (
                            "var {0}_ = {1}.{2} ({3});\n",
                            notifyParameter.Identifier,
                            // FIXME:
                            "factory", "create",
                            // typeof(GISharp.GLib.UnmanagedDestoryNotifyFactory).FullName,
                            // nameof(GISharp.GLib.UnmanagedDestoryNotifyFactory.Create),
                            closureHandle);
                        yield return (ParseStatement(notifyStatement), null);
                        
                        var closureParameterStatement = string.Format (
                            "var {0}_ = {1}.{2} ({1}.{3} ({4}_));\n",
                            closureParameter.Identifier,
                            typeof(GCHandle).FullName,
                            nameof(GCHandle.ToIntPtr),
                            nameof(GCHandle.Alloc),
                            notifyParameter.Identifier);
                        yield return (ParseStatement(closureParameterStatement), null);
                    } else {
                        var closureParameterStatement = string.Format (
                            "var {0}_ = {1}.{2} ({3});\n",
                            closureParameter.Identifier,
                            typeof(GCHandle).FullName,
                            nameof(GCHandle.ToIntPtr),
                            closureHandle);
                        yield return (ParseStatement(closureParameterStatement), null);
                    }
                }
                break;
            case TypeClassification.Interface:
            case TypeClassification.Opaque:
                if (managedParameter.NeedsNullCheck) {
                    statement = string.Format("{0}_ = {0}?.Handle ?? throw new {1}(nameof({0}));\n",
                        managedParameter.Identifier,
                        typeof(ArgumentException).FullName);
                } else {
                    statement = string.Format("{0}_ = {0}?.Handle ?? {1}.{2};\n",
                        managedParameter.Identifier,
                        typeof(IntPtr).FullName,
                        nameof (IntPtr.Zero));
                }
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return (ParseStatement(statement), null);
                break;
            default:
                // TODO: need to add more implementations
                statement = string.Format ("{0}_ = default({1});\n",
                    managedParameter.Identifier,
                    typeof(IntPtr).FullName);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return (ParseStatement(statement), null);
                yield return (ParseStatement(string.Format("throw new {0} ();\n",
                    typeof(NotImplementedException).FullName)), null);
                break;
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
                    var statement = string.Format ("var {0}_ = ({1})({2}?.Length ?? 0);\n",
                        lengthParameter.Identifier,
                        lengthParameter.TypeInfo.Type,
                        p.Identifier);
                    yield return ParseStatement (statement);
                } else {
                    var statement = string.Format ("{0} {1}_;\n",
                        lengthParameter.TypeInfo.Type,
                        lengthParameter.Identifier);
                    yield return ParseStatement (statement);
                }
            }
        }

        StatementSyntax GetInvocationStatement (string methodName = null, bool skipFirstParameter = false)
        {
            var invokeExpression = InvocationExpression (IdentifierName (methodName ?? Identifier.Text));
            var argList = ArgumentList ();
            foreach (var p in ManagedParameterInfos.Skip (skipFirstParameter ? 1 : 0)) {
                var name = string.Format (
                    "{0} {1}",
                    p.Modifiers,
                    p.Identifier);
                if (!p.TypeInfo.RequiresMarshal) {
                    name += "_";
                }
                var arg = Argument (ParseExpression (name));
                argList = argList.AddArguments (arg);
            }
            invokeExpression = invokeExpression.WithArgumentList (argList);

            StatementSyntax statement = ExpressionStatement (invokeExpression);
            if (ManagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                statement = LocalDeclarationStatement (
                    VariableDeclaration (ParseTypeName ("var"))
                    .AddVariables (
                        VariableDeclarator (ParseToken ("ret"))
                            .WithInitializer (EqualsValueClause (invokeExpression))));
            }
            return statement;
        }

        StatementSyntax GetPinvokeInvocationStatement ()
        {
            var pinvokeExpression = InvocationExpression (
                IdentifierName (PinvokeIdentifier));
            var argumentList =  ArgumentList ();
            foreach (var p in PinvokeParameterInfos) {
                var name = string.Format ("{0} {1}", p.Modifiers,
                    // setters use "value" keyword for parameter
                    ManagedName.StartsWith ("set_", StringComparison.Ordinal) ? "value" : p.ManagedName);
                if (p.IsInstanceParameter) {
                    if (IsExtensionMethod) {
                        name = $"{p.ManagedName}_";
                    } else {
                        name = "this_";
                    }
                } else if (p.TypeInfo.RequiresMarshal || ManagedParameterInfos.All (x => x.GirName != p.GirName)) {
                    // add suffix unless the parameter is also a managed parameter and does not need to be marshaled
                    name += "_";
                }
                var arg = Argument (ParseExpression (name));
                argumentList = argumentList.AddArguments (arg);
            }
            pinvokeExpression = pinvokeExpression.WithArgumentList (argumentList);

            StatementSyntax statement = ExpressionStatement (pinvokeExpression);
            if (ManagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                var ret = "ret";
                if (ManagedReturnParameterInfo.TypeInfo.RequiresMarshal) {
                    ret += "_";
                }
                statement = LocalDeclarationStatement (
                    VariableDeclaration (ParseTypeName ("var"))
                    .AddVariables (VariableDeclarator (ParseToken (ret))
                    .WithInitializer (EqualsValueClause (pinvokeExpression))));
            }
            return statement;
        }

        IEnumerable<StatementSyntax> GetReturnStatements ()
        {
            if (ManagedReturnParameterInfo.TypeInfo.Classification == TypeClassification.Void) {
                yield break;
            }
            var ret = "ret";
            if (IsConstructor) {
                ret += "_";
            }
            yield return ParseStatement (string.Format ("return {0};", ret));
        }

        IEnumerable<StatementSyntax> GetMarshalUnmanagedToManagedStatements (ParameterInfo managedParameterInfo, bool declareVariable)
        {
            if (!managedParameterInfo.TypeInfo.RequiresMarshal) {
                yield break;
            }

            string statement;

            var unmangedParameterInfo = managedParameterInfo.IsReturnParameter
                ? UnmanagedReturnParameterInfo
                : PinvokeParameterInfos.Single (x => x.GirName == managedParameterInfo.GirName);

            switch (managedParameterInfo.TypeInfo.Classification) {
            case TypeClassification.CArray:
            case TypeClassification.CPtrArray:
                string length = null;
                if (unmangedParameterInfo.TypeInfo.ArrayFixedSize >= 0) {
                    length = "(int)" + unmangedParameterInfo.TypeInfo.ArrayFixedSize.ToString ();
                }
                if (unmangedParameterInfo.TypeInfo.ArrayLengthIndex >= 0) {
                    var lengthParameterInfo = PinvokeParameterInfos[unmangedParameterInfo.TypeInfo.ArrayLengthIndex];
                    length = "(int)" + lengthParameterInfo.Identifier.Text + "_";
                }
                if (unmangedParameterInfo.TypeInfo.ArrayZeroTerminated) {
                    length = "null";
                }
                if (length == null) {
                    var message = string.Format ("Parameter with unknown array size: {0} in {1}.{2}",
                        managedParameterInfo.Identifier,
                        DeclaringMember.Identifier,
                        Identifier);
                    throw new Exception (message);
                }
                var marshalFunc = managedParameterInfo.TypeInfo.Classification == TypeClassification.CArray
                    ? $"{typeof(GISharp.Runtime.CArray).FullName}.{nameof(GISharp.Runtime.CArray.GetInstance)}"
                    : $"{typeof(GISharp.Runtime.CPtrArray).FullName}.{nameof(GISharp.Runtime.CPtrArray.GetInstance)}";
                statement = string.Format("{0} = {1}<{2}> ({0}_, {3}, {4}.{5});\n",
                    managedParameterInfo.Identifier,
                    marshalFunc,
                    managedParameterInfo.TypeInfo.TypeObject.GetGenericArguments().Single().FullName,
                    length,
                    typeof(GISharp.Runtime.Transfer).FullName,
                    managedParameterInfo.Transfer);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return ParseStatement (statement);
                break;
            case TypeClassification.Interface:
                statement = string.Format ("{0} = ({1}){2}.{3}<{4}> ({0}_, {5}.{6});\n",
                    managedParameterInfo.Identifier,
                    managedParameterInfo.TypeInfo.Type,
                    typeof(GISharp.Runtime.Opaque),
                    nameof(GISharp.Runtime.Opaque.GetInstance),
                    typeof(GISharp.GObject.Object).FullName,
                    typeof(GISharp.Runtime.Transfer).FullName,
                    managedParameterInfo.Transfer);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return ParseStatement (statement);
                break;
            case TypeClassification.Opaque:
                statement = string.Format ("{0} = {1}.{2}<{3}> ({0}_, {4}.{5});\n",
                    managedParameterInfo.Identifier,
                    typeof(GISharp.Runtime.Opaque),
                    nameof(GISharp.Runtime.Opaque.GetInstance),
                    managedParameterInfo.TypeInfo.Type,
                    typeof(GISharp.Runtime.Transfer).FullName,
                    managedParameterInfo.Transfer);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return ParseStatement (statement);
                break;
            default:
                // TODO : need more implementations here
                statement = string.Format ("{0} = default({1});\n",
                    managedParameterInfo.Identifier,
                    managedParameterInfo.TypeInfo.Type);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return ParseStatement (statement);
                yield return ParseStatement (string.Format ("throw new {0} ();\n",
                    typeof(NotImplementedException).FullName));
                break;
            }
        }

        IEnumerable<StatementSyntax> GetCallbackStatements ()
        {
            foreach (var p in ManagedParameterInfos) {
                foreach (var s in GetMarshalUnmanagedToManagedStatements (p, true)) {
                    yield return s;
                }
            }
            yield return GetInvocationStatement ("method.Invoke");
            var closureParameters = GetClosureParameters ().ToList ();
            if (closureParameters.Any ()) {
                var ifBody = Block ();
                foreach (var p in closureParameters) {
                    ifBody = ifBody.AddStatements (
                        ParseStatement (string.Format (
                            "{0}.{1} ({2}).{3} ();",
                            typeof (GCHandle).FullName,
                            nameof(GCHandle.FromIntPtr),
                            p.Identifier + "_",
                            nameof(GCHandle.Free))));
                }

                yield return IfStatement (ParseExpression ("freeUserData"),ifBody);
            }
            if (UnmanagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                foreach (var (statement, freeStatement) in GetMarshalManagedToUnmanagedParameterStatements(ManagedReturnParameterInfo, true)) {
                    yield return statement;
                    if (freeStatement != null) {
                        yield return freeStatement;
                    }
                }
                var ret = "ret";
                if (!ManagedReturnParameterInfo.TypeInfo.RequiresMarshal) {
                    ret += "_";
                }
                var returnStatement = ReturnStatement (ParseExpression (ret));
                yield return returnStatement;
            }
        }

        IEnumerable<StatementSyntax> GetVirtualMethodImplStatements ()
        {
            var tryStatement = TryStatement();

            foreach (var p in ManagedParameterInfos) {
                if (p.IsOutParam) {
                    if (p.TypeInfo.RequiresMarshal) {
                        var statement = $"{p.TypeInfo.Type} {p.ManagedName};\n";
                        tryStatement = tryStatement.AddBlockStatements(ParseStatement(statement));
                    }
                } else {
                    var marshalStatements = GetMarshalUnmanagedToManagedStatements(p, true).ToArray();
                    tryStatement = tryStatement.AddBlockStatements(marshalStatements);
                }
            }
            var instanceParam = PinvokeParameterInfos.First ();
            var invokeStatement = GetInvocationStatement($"{instanceParam.ManagedName}.{ManagedName}", true);
            tryStatement = tryStatement.AddBlockStatements(invokeStatement);

            foreach (var p in ManagedParameterInfos.Where (x => x.IsOutParam)) {
                foreach (var (statement, freeStatement) in GetMarshalManagedToUnmanagedParameterStatements(p, false)) {
                    tryStatement = tryStatement.AddBlockStatements(statement);
                    if (freeStatement != null) {
                        // TODO: how to prevent memory leak?
                        //tryStatement = tryStatement.AddBlockStatements(freeStatement);
                    }
                }
            }

            if (UnmanagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                foreach (var (statement, freeStatement) in GetMarshalManagedToUnmanagedParameterStatements(ManagedReturnParameterInfo, true)) {
                    tryStatement = tryStatement.AddBlockStatements(statement);
                    if (freeStatement != null) {
                        // TODO: how to prevent memory leak?
                        //tryStatement = tryStatement.AddBlockStatements(freeStatement);
                    }
                }
                if (ManagedReturnParameterInfo.Transfer != GISharp.Runtime.Transfer.None) {
                    if (typeof(GISharp.Runtime.Opaque).IsAssignableFrom (ManagedReturnParameterInfo.TypeInfo.TypeObject)) {
                        var refStatement = ParseStatement ("ret.Ref ();\n");
                        if (ManagedReturnParameterInfo.CanBeNull) {
                            refStatement = IfStatement (ParseExpression ("ret != null"), Block(refStatement));
                        }
                        tryStatement = tryStatement.AddBlockStatements(refStatement);
                    }
                }
                var ret = "ret";
                if (ManagedReturnParameterInfo.TypeInfo.RequiresMarshal) {
                    ret += "_";
                }
                var returnStatement = ReturnStatement (ParseExpression (ret));
                tryStatement = tryStatement.AddBlockStatements(returnStatement);
            }

            var returnDefault = default(StatementSyntax);
            if (UnmanagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
            var returnType = UnmanagedReturnParameterInfo.TypeInfo.Type;
                returnDefault = ParseStatement($"return default({returnType});");
            }

            // if the method has an error parameter, we can propagate any
            // GErrorException thrown by the managed callback

            if (ThrowsGErrorException) {
                var gErrorException = typeof(GISharp.Runtime.GErrorException).FullName;
                var propagateError = ParseStatement(string.Format("{0}.{1}(ex.{2}, {3});\n",
                    typeof(GISharp.Runtime.GMarshal).FullName,
                    nameof(GISharp.Runtime.GMarshal.PropagateError),
                    nameof(GISharp.Runtime.GErrorException.Error),
                    PinvokeParameterInfos.Single(x => x.IsErrorParameter).Identifier));

                var gErrorExceptionStatements = List<StatementSyntax>().Add(propagateError);
                if (returnDefault != null) {
                    gErrorExceptionStatements = gErrorExceptionStatements.Add(returnDefault);
                }

                tryStatement = tryStatement.AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(ParseTypeName(gErrorException), ParseToken("ex")))
                    .WithBlock(Block(gErrorExceptionStatements)));
            }

            // otherwise, we just have to log an unhandled exception since we
            // are returning to unmanaged code, which doesn't know about
            // managed exceptions

            var exception = typeof(Exception).FullName;
            var logUnhandledException = ParseStatement(string.Format("{0}.{1}(ex);\n",
                typeof(GISharp.GLib.Log).FullName,
                nameof(GISharp.GLib.Log.LogUnhandledException)));

            var exceptionStatements = List<StatementSyntax>().Add(logUnhandledException);
            if (returnDefault != null) {
                exceptionStatements = exceptionStatements.Add(returnDefault);
            }

            tryStatement = tryStatement.AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(ParseTypeName(exception), ParseToken("ex")))
                    .WithBlock(Block(exceptionStatements)));

            yield return tryStatement;
        }

        MethodDeclarationSyntax CreateOverrideEqualsMethod ()
        {
            var syntax = MethodDeclaration (
                ParseTypeName ("bool"),
                ParseToken ("Equals"))
                .WithModifiers (TokenList (
                    ParseTokens ("public override")))
                .WithParameterList (ParseParameterList ("(object obj)"))
                .WithBody (Block ()
                    .AddStatements (
                        ParseStatement (
                            string.Format ("return Equals (obj as {0});", DeclaringMember.ManagedName))));
            return syntax;
        }

        MethodDeclarationSyntax CreateOverrideGetHashCodeMethod (string hashFunc)
        {
            var syntax = MethodDeclaration (
                ParseTypeName ("int"),
                ParseToken ("GetHashCode"))
                .WithModifiers (TokenList (
                    ParseTokens ("public override")))
                .WithBody (Block ()
                    .AddStatements (
                        ParseStatement (
                            string.Format ("return {0};", hashFunc))));
            return syntax;
        }

        OperatorDeclarationSyntax CreateEqualityOperator ()
        {
            var syntax = OperatorDeclaration (
                ParseTypeName ("bool"),
                ParseToken ("=="))
                .WithModifiers (TokenList (
                    ParseTokens ("public static")))
                .WithParameterList (ParseParameterList (
                    string.Format ("({0} one, {0} two)", DeclaringMember.ManagedName)))
                .WithBody (Block ()
                    .AddStatements (
                        ParseStatement (@"
                            if ((object)one == null) {
                                return (object)two == null;
                            }
                            if ((object)two == null) {
                                return false;
                            }
                            "),
                        ParseStatement (
                            "return one.Equals (two);\n")));
            return syntax;
        }

        OperatorDeclarationSyntax CreateInequalityOperator ()
        {
            var syntax = OperatorDeclaration (
                ParseTypeName ("bool"),
                ParseToken ("!="))
                .WithModifiers (TokenList (
                    ParseTokens ("public static")))
                .WithParameterList (ParseParameterList (
                    string.Format ("({0} one, {0} two)", DeclaringMember.ManagedName)))
                .WithBody (Block ()
                    .AddStatements (ParseStatement (
                        "return !(one == two);\n")));
            return syntax;
        }

        OperatorDeclarationSyntax CreateCompareToOperator (string @operator)
        {
            var syntax = OperatorDeclaration (
                ParseTypeName ("bool"),
                ParseToken (@operator))
                .WithModifiers (TokenList (
                    ParseTokens ("public static")))
                .WithParameterList (ParseParameterList (
                    string.Format ("({0} one, {0} two)", DeclaringMember.ManagedName)))
                .WithBody (Block ()
                    .AddStatements (ParseStatement (
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
                    // Alternately, we could check if this is function/method/constructor/callback
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

        ConstructorInitializerSyntax GetConstructorInitializer()
        {
            if (!IsConstructor) {
                throw new NotSupportedException ();
            }
            var invokeExpression = InvocationExpression (ParseExpression (Identifier.Text));
            foreach (var info in ManagedParameterInfos) {
                var item = Argument (ParseExpression (info.Identifier.Text));
                invokeExpression = invokeExpression.AddArgumentListArguments (item);
            }
            var invokeArgument = Argument (invokeExpression);
            var transfer = string.Format ("{0}.{1}",
                typeof(GISharp.Runtime.Transfer), UnmanagedReturnParameterInfo.Transfer);
            var transferExpression = ParseExpression (transfer);
            var transferArgument = Argument (transferExpression);
            var argList = ArgumentList ()
                .AddArguments (invokeArgument, transferArgument);
            var initializer = ConstructorInitializer (SyntaxKind.ThisConstructorInitializer)
                .WithArgumentList (argList);

            return initializer;
        }

        protected override IEnumerable<SyntaxToken> GetModifiers ()
        {
            var modifiers = base.GetModifiers ().ToList ();
            if (IsStaticMethod && !modifiers.Any (x => x.IsKind (SyntaxKind.StaticKeyword))) {
                modifiers.Add (Token (SyntaxKind.StaticKeyword));
            }
            return modifiers;
        }

        protected override SyntaxTriviaList GetDocumentationCommentTriviaList ()
        {
            var list = base.GetDocumentationCommentTriviaList ()
                .AddRange (ManagedParameterInfos.SelectMany (x => x.DocumentationCommentTriviaList))
                .AddRange (ManagedReturnParameterInfo.DocumentationCommentTriviaList)
                .AddRange (GetGErrorExceptionDocumentationCommentTriviaList ());
            return list;
        }

        IEnumerable<SyntaxToken> GetPinvokeModifiers ()
        {
            yield return Token (SyntaxKind.StaticKeyword);
            yield return Token (SyntaxKind.ExternKeyword);
        }

        IEnumerable<AttributeListSyntax> GetPinvokeAttributeLists ()
        {
            foreach (var baseAttr in base.GetAttributeLists ()) {
                yield return baseAttr;
            }
            var dllName = Element.Ancestors (gi + "repository")
                .Single ().Element (gi + "package")
                .Attribute ("name").Value;
            var dllImportAttrName = ParseName (typeof(DllImportAttribute).FullName);
            var dllImportAttrArgListText = string.Format (
                "(\"{0}\", {1} = {2}.{3})",
                dllName,
                nameof(DllImportAttribute.CallingConvention),
                typeof(CallingConvention).FullName,
                CallingConvention.Cdecl);
            var dllImportAttrArgList = ParseAttributeArgumentList (dllImportAttrArgListText);
            var dllImportAttr = Attribute (dllImportAttrName)
                .WithArgumentList (dllImportAttrArgList);
            yield return AttributeList ().AddAttributes (dllImportAttr);
        }

        SyntaxTriviaList GetPinvokeDocumentationCommentTriviaList ()
        {
            var list = base.GetDocumentationCommentTriviaList ()
                .AddRange (PinvokeParameterInfos.SelectMany (x => x.DocumentationCommentTriviaList))
                .AddRange (UnmanagedReturnParameterInfo.DocumentationCommentTriviaList);
            return list;
        }

        IEnumerable<ParameterInfo> GetClosureParameters ()
        {
            return PinvokeParameterInfos
                .Where (x => x.ClosureIndex >= 0)
                .Select (x => PinvokeParameterInfos[x.ClosureIndex])
                .Distinct ();
        }

        SyntaxTriviaList GetGErrorExceptionDocumentationCommentTriviaList ()
        {
            if (!ThrowsGErrorException) {
                return default (SyntaxTriviaList);
            }
            var builder = new StringBuilder ();
            builder.AppendFormat ("/// <exception name=\"{0}\">",
                                  typeof (GISharp.Runtime.GErrorException).FullName);
            builder.AppendLine ();
            builder.AppendLine ("/// On error");
            builder.AppendLine ("/// </exception>");

            return ParseLeadingTrivia (builder.ToString ());
        }
    }
}
