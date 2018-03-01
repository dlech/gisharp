using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using GISharp.GLib;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Model
{
    public class MethodInfo : MemberInfo
    {
        /// <summary>
        /// Gets the dll name to use for PInvoke
        /// </summary>
        public string DllName => Element.Attribute(gs + "dll-name").Value;

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

        public bool IsRef =>  Element.Attribute(gs + "special-func").AsString() == "ref";
        
        public bool IsUnref =>  Element.Attribute(gs + "special-func").AsString() == "unref";

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

        /// <summary>
        /// Indicates the managed return type should be <c>void</c>. This may
        /// be because the unmanaged return parameter is "none" or the return
        /// value is not useful, like a bool return on a method that throws
        /// a GErrorException.
        /// </summary>
        public bool ShouldIgnoreReturnParameter {
            get {
                if (ManagedReturnParameterInfo.TypeInfo.Classification == TypeClassification.Void) {
                    return true;
                }
                if (ThrowsGErrorException && ManagedReturnParameterInfo.TypeInfo.TypeObject == typeof(bool)) {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets the unmanaged virtual method delegate field declaration
        public FieldDeclarationSyntax VirtualMethodDelegateFieldDeclaration =>
            _VirtualMethodDelegateFieldDeclaration.Value;
        readonly Lazy<FieldDeclarationSyntax> _VirtualMethodDelegateFieldDeclaration;

        System.Collections.Generic.List<ParameterInfo> _ManagedParameterInfos;
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

        System.Collections.Generic.List<ParameterInfo> _PinvokeParameterInfos;
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
            if (element.Name != gi + "function" && element.Name != gi + "method" && element.Name != gi + "virtual-method" && element.Name != gi + "constructor" && element.Name != gi + "callback" && element.Name != glib + "signal") {
                throw new ArgumentException("Requires <function>, <method>, <virtual-method> <constructor>, <callback> or <glib:signal> element.", nameof(element));
            }
            _VirtualMethodDelegateFieldDeclaration = new Lazy<FieldDeclarationSyntax>(LazyGetVirtualMethodFieldDeclaration, false);
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
                if (DeclaringMember is InterfaceInfo iface) {
                    var methodDeclaration = MethodDeclaration (ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithParameterList (ParameterList)
                        .WithSemicolonToken (Token (SyntaxKind.SemicolonToken))
                        .WithLeadingTrivia (DocumentationCommentTriviaList);
                    yield return methodDeclaration;
                }
                if (DeclaringMember is ClassInfo @class) {
                    var methodDeclaration = MethodDeclaration(ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                        .WithAttributeLists(AttributeLists)
                        .WithParameterList(ParameterList)
                        .AddModifiers(Token(ProtectedKeyword), Token(InternalKeyword), Token(VirtualKeyword))
                        .WithBody(Block(GetStatements()))
                        .WithLeadingTrivia(DocumentationCommentTriviaList);
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
            if (IsRef) {
                // if there is an unmanaged ref method, use it to override the
                // managed Take() method
                var takeReturnType = ParseTypeName(typeof(IntPtr).FullName);
                var takeExpression = ParseExpression($"{PinvokeIdentifier}(Handle)");
                var takeOverride = MethodDeclaration(takeReturnType, "Take")
                    .AddModifiers(Token(PublicKeyword), Token(OverrideKeyword))
                    .WithExpressionBody(ArrowExpressionClause(takeExpression))
                    .WithSemicolonToken(Token(SemicolonToken));
                yield return takeOverride;
            }
        }

        FieldDeclarationSyntax LazyGetVirtualMethodFieldDeclaration()
        {
            if (Element.Name != gi + "virtual-method") {
                throw new InvalidOperationException("only applies to virtual methods");
            }
            var fieldName = ManagedName.ToCamelCase() + "Delegate";

            throw new NotImplementedException("need to get info from gtype-struct");
        }

        IEnumerable<StatementSyntax> GetStatements ()
        {
            if ((IsInstanceMethod || IsVirtualMethod) && DeclaringMember is ClassInfo) {
                var statement = "var this_ = this.Handle;\n";
                yield return ParseStatement (statement);
            }
            foreach (var s in GetArgumentCheckStatements ()) {
                yield return s;
            }
            foreach (var p in ManagedParameterInfos.Where (x => x.TypeInfo.RequiresMarshal)) {
                if (p.IsInParam) {
                    foreach (var statement in GetMarshalManagedToUnmanagedParameterStatements(p, true)) {
                        yield return statement;
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
                    "var {0}_ = {1}.{2};\n",
                    PinvokeParameterInfos.Single(x => x.IsErrorParameter).Identifier,
                    typeof(IntPtr).FullName,
                    nameof(IntPtr.Zero));
                yield return ParseStatement (statement);
            }
            yield return GetPinvokeInvocationStatement ();

            // if we had any callbacks with a scope of "call", then we need
            // to free the unmanaged user data
            foreach (var callbacks in PinvokeParameterInfos.Where(x =>
                x.TypeInfo.Classification == TypeClassification.Delegate &&
                x.Scope == CallbackScope.Call))
            {
                yield return ParseStatement("destroy_(userData_);\n");
            }

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

        IEnumerable<StatementSyntax> GetMarshalManagedToUnmanagedParameterStatements(ParameterInfo managedParameter, bool declareVariable)
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
                var dataGetter = managedParameter.Transfer == Runtime.Transfer.None ? "Data" : "TakeData().Item1";
                statement = string.Format ("{0}_ = {0}?.{1} ?? {2};\n",
                    managedParameter.Identifier, dataGetter, nullValue);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return ParseStatement(statement);
                break;
            case TypeClassification.Delegate:
                var destroyParameter = pinvokeParameter.Scope != CallbackScope.Async ?
                    PinvokeParameterInfos[pinvokeParameter.DestoryIndex] : null;
                var userDataParameter = PinvokeParameterInfos[pinvokeParameter.ClosureIndex];
                var conditional = "";
                if (!pinvokeParameter.NeedsNullCheck) {
                    // if null is allowed, turn this into a conditional statement
                    conditional = string.Format("({0} == null) ?\n(default({1}), default({2}), {3}.{4}) :\n",
                        managedParameter.Identifier,
                        pinvokeParameter.TypeInfo.Type,
                        typeof(UnmanagedDestroyNotify).FullName,
                        typeof(IntPtr).FullName,
                        nameof(IntPtr.Zero));
                }
                statement = string.Format("var ({0}_, {1}_, {2}_) = {3}{4}Factory.Create({5}, {6}.{7});\n",
                    pinvokeParameter.Identifier,
                    destroyParameter?.Identifier.Text ?? "",
                    userDataParameter.Identifier,
                    conditional,
                    managedParameter.TypeInfo.Type,
                    managedParameter.Identifier,
                    typeof(CallbackScope).FullName,
                    pinvokeParameter.Scope);
                yield return ParseStatement(statement);
                break;
            case TypeClassification.Interface:
            case TypeClassification.Opaque:
                var getHandle = (managedParameter.Transfer == Runtime.Transfer.None) ?
                    "Handle" : "Take()";
                if (managedParameter.NeedsNullCheck) {
                    statement = string.Format("{0}_ = {0}?.{1} ?? throw new {2}(nameof({0}));\n",
                        managedParameter.Identifier,
                        getHandle,
                        typeof(ArgumentNullException).FullName);
                } else {
                    statement = string.Format("{0}_ = {0}?.{1} ?? {2}.{3};\n",
                        managedParameter.Identifier,
                        getHandle,
                        typeof(IntPtr).FullName,
                        nameof (IntPtr.Zero));
                }
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return ParseStatement(statement);
                break;
            default:
                // TODO: need to add more implementations
                statement = string.Format ("{0}_ = default({1});\n",
                    managedParameter.Identifier,
                    typeof(IntPtr).FullName);
                if (declareVariable) {
                    statement = "var " + statement;
                }
                yield return ParseStatement(statement);
                yield return ParseStatement(string.Format("throw new {0} ();\n",
                    typeof(NotImplementedException).FullName));
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

        StatementSyntax GetInvocationStatement(string methodName = null, bool skipFirstParameter = false, bool skipReturnValue = false)
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
            if (!skipReturnValue && ManagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
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
            var virtualMethodInvoke = string.Format("{0}.{1}<{2}>(_GType).{3}Delegate?.Invoke",
                typeof(GISharp.GObject.TypeClass).FullName,
                nameof(GISharp.GObject.TypeClass.GetInstance),
                (DeclaringMember as ClassInfo)?.GTypeStruct,
                ManagedName);
            var pinvokeExpression = InvocationExpression(IsVirtualMethod ?
                ParseExpression(virtualMethodInvoke) :
                IdentifierName(PinvokeIdentifier));
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
                var fullExpression = IsVirtualMethod ?
                    BinaryExpression(CoalesceExpression, pinvokeExpression,
                        DefaultExpression(ManagedReturnParameterInfo.TypeInfo.Type)) :
                    (ExpressionSyntax)pinvokeExpression;
                var ret = "ret";
                if (ManagedReturnParameterInfo.TypeInfo.RequiresMarshal) {
                    ret += "_";
                }
                statement = LocalDeclarationStatement (
                    VariableDeclaration (ParseTypeName ("var"))
                    .AddVariables (VariableDeclarator (ParseToken (ret))
                    .WithInitializer(EqualsValueClause(fullExpression))));
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
            case TypeClassification.Delegate:
                var userDataParameter = PinvokeParameterInfos[unmangedParameterInfo.ClosureIndex];
                statement = string.Format("var {0} = {1}Factory.Create({2}_, {3}_);\n",
                    managedParameterInfo.Identifier,
                    managedParameterInfo.TypeInfo.Type,
                    unmangedParameterInfo.Identifier,
                    userDataParameter.Identifier);
                yield return ParseStatement(statement);
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

        IEnumerable<StatementSyntax> GetCallbackStatements()
        {
            var catchType = ParseTypeName(typeof(Exception).FullName);
            var catchStatement = string.Format("{0}.{1}(ex);\n",
                typeof(Log).FullName,
                nameof(Log.LogUnhandledException));
            yield return TryStatement()
                .WithBlock(Block(LazyGetCallbackTryStatements()))
                .AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(catchType, ParseToken("ex")))
                    .WithBlock(Block(ParseStatement(catchStatement))));
            
            if (UnmanagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                var returnType = UnmanagedReturnParameterInfo.TypeInfo.Type;
                yield return ParseStatement($"return default({returnType});\n");
            }
        }

        IEnumerable<StatementSyntax> LazyGetCallbackTryStatements()
        {
            foreach(var p in ManagedParameterInfos) {
                foreach(var s in GetMarshalUnmanagedToManagedStatements(p, true)) {
                    yield return s;
                }
            }

            var dataParam = PinvokeParameterInfos.Single(x => x.ClosureIndex >= 0);
            var dataParamName = dataParam.ManagedName;

            var ghHandleType = typeof(GCHandle).FullName;
            yield return ParseStatement($"var gcHandle = ({ghHandleType}){dataParamName}_;\n");
            yield return ParseStatement($"var {dataParamName} = (UserData)gcHandle.Target;\n");

            var skipReturnValue = ThrowsGErrorException && UnmanagedReturnParameterInfo.TypeInfo.TypeObject == typeof(bool);

            yield return GetInvocationStatement($"{dataParamName}.ManagedDelegate", false, skipReturnValue);

            yield return ParseStatement(string.Format(@"if ({0}.Scope == {1}.{2}) {{
                    Destroy({0}_);
                }}
                ", dataParamName,
                typeof(CallbackScope).FullName,
                nameof(CallbackScope.Async)));

            if (skipReturnValue) {
                // callbacks that throw and return bool should always return true
                yield return ParseStatement("return true;\n");
            }
            else if (UnmanagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                foreach (var statement in GetMarshalManagedToUnmanagedParameterStatements(ManagedReturnParameterInfo, true)) {
                    yield return statement;
                }
                var ret = "ret";
                if (ManagedReturnParameterInfo.TypeInfo.RequiresMarshal) {
                    ret += "_";
                }
                var returnStatement = ReturnStatement(ParseExpression(ret));
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
            var invokeStatement = GetInvocationStatement($"{instanceParam.ManagedName}.On{ManagedName}", true);
            tryStatement = tryStatement.AddBlockStatements(invokeStatement);

            foreach (var p in ManagedParameterInfos.Where (x => x.IsOutParam)) {
                foreach (var statement in GetMarshalManagedToUnmanagedParameterStatements(p, false)) {
                    tryStatement = tryStatement.AddBlockStatements(statement);
                }
            }

            if (UnmanagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                foreach (var statement in GetMarshalManagedToUnmanagedParameterStatements(ManagedReturnParameterInfo, true)) {
                    tryStatement = tryStatement.AddBlockStatements(statement);
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
                returnDefault = ParseStatement($"return default({returnType});\n");
            }

            // if the method has an error parameter, we can propagate any
            // GErrorException thrown by the managed callback

            if (ThrowsGErrorException) {
                var gErrorException = typeof(GISharp.Runtime.GErrorException).FullName;
                var propagateError = ParseStatement(string.Format("{0}.{1}(ref {2}_, ex.{3});\n",
                    typeof(GISharp.Runtime.GMarshal).FullName,
                    nameof(GISharp.Runtime.GMarshal.PropagateError),
                    PinvokeParameterInfos.Single(x => x.IsErrorParameter).Identifier,
                    nameof(GISharp.Runtime.GErrorException.Error)));

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
                typeof(Log).FullName,
                nameof(Log.LogUnhandledException)));

            var exceptionStatements = List<StatementSyntax>().Add(logUnhandledException);

            foreach (var p in PinvokeParameterInfos.Where(x => !x.IsInParam)) {
                var setOutParamStatement = ParseStatement($"{p.Identifier}_ = default({p.TypeInfo.Type});");
                exceptionStatements = exceptionStatements.Add(setOutParamStatement);
            }

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
            if (returnValueElement == null || (managed && returnValueElement.Attribute (gs + "skip").AsBool ())) {
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
            var dllImportAttrName = ParseName (typeof(DllImportAttribute).FullName);
            var dllImportAttrArgListText = string.Format (
                "(\"{0}\", {1} = {2}.{3})",
                DllName,
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
