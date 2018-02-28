using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using GISharp.CodeGen.Syntax;
using GISharp.GLib;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Model
{
    public class DelegateInfo : MemberInfo
    {
        MethodInfo _MethodInfo;
        public MethodInfo MethodInfo {
            get {
                if (_MethodInfo == null) {
                    _MethodInfo = new MethodInfo (Element, this);
                }
                return _MethodInfo;
            }
        }

        SyntaxToken? _UnmanagedIdentifier;
        public SyntaxToken UnmanagedIdentifier {
            get {
                if (!_UnmanagedIdentifier.HasValue) {
                    _UnmanagedIdentifier = Identifier ("Unmanaged" + Identifier);
                }
                return _UnmanagedIdentifier.Value;
            }
        }

        QualifiedNameSyntax _UnmanagedQualifiedName;
        public QualifiedNameSyntax UnmanagedQualifiedName {
            get {
                if (_UnmanagedQualifiedName == null) {
                    _UnmanagedQualifiedName = QualifiedName (
                        NamespaceInfo.Name,
                        IdentifierName (UnmanagedIdentifier));
                    // callbacks can be declared by fields, in which case they
                    // are a child type.
                    var declaringType = DeclaringMember.DeclaringMember as TypeDeclarationInfo;
                    if (declaringType != null) {
                        _UnmanagedQualifiedName = QualifiedName (
                            QualifiedName (
                                _UnmanagedQualifiedName.Left,
                                IdentifierName (declaringType.Identifier)),
                            _UnmanagedQualifiedName.Right);
                    }
                }
                return _UnmanagedQualifiedName;
            }
        }

        SyntaxList<AttributeListSyntax>? _UnmanagedAttributeLists;
        public SyntaxList<AttributeListSyntax> UnmanagedAttributeLists {
            get {
                if (!_UnmanagedAttributeLists.HasValue) {
                    var unmanagedFuncPtrAttrName = ParseName (typeof(UnmanagedFunctionPointerAttribute).FullName);
                    var unmangedFuncPtrAttrArgListText = string.Format ("({0}.{1})", typeof(CallingConvention), CallingConvention.Cdecl);
                    var unmanagedFuncPtrAttrArgList = ParseAttributeArgumentList (unmangedFuncPtrAttrArgListText);
                    var unmanagedFuncPtrAttr = Attribute (unmanagedFuncPtrAttrName)
                        .WithArgumentList (unmanagedFuncPtrAttrArgList);
                    _UnmanagedAttributeLists = AttributeLists
                        .Add (AttributeList ().AddAttributes (unmanagedFuncPtrAttr));
                }
                return _UnmanagedAttributeLists.Value;
            }
        }

        SyntaxTriviaList? _UnmanagedDocumentationCommentTriviaList;
        public SyntaxTriviaList UnmanagedDocumentationCommentTriviaList {
            get {
                if (!_UnmanagedDocumentationCommentTriviaList.HasValue) {
                    _UnmanagedDocumentationCommentTriviaList = base.GetDocumentationCommentTriviaList ();
                }
                return _UnmanagedDocumentationCommentTriviaList.Value;
            }
        }

        /// <summary>
        /// Gets the declaration for the managed version of this delegate.
        /// </summary>
        public DelegateDeclarationSyntax ManagedDelegateDeclaration =>
            _ManagedDelegateDeclaration.Value;
        readonly Lazy<DelegateDeclarationSyntax> _ManagedDelegateDeclaration;

        /// <summary>
        /// Gets the declaration for the unmanaged version of this delegate.
        /// </summary>
        public DelegateDeclarationSyntax UnmanagedDelegateDeclaration =>
            _UnmanagedDelegateDeclaration.Value;
        readonly Lazy<DelegateDeclarationSyntax> _UnmanagedDelegateDeclaration;

        /// <summary>
        /// Gets the unmanaged delegate factory class declaration for a callback
        /// </summary>
        public ClassDeclarationSyntax DelegateFactoryDeclaration =>
            _DelegateFactoryDeclaration.Value;
        readonly Lazy<ClassDeclarationSyntax> _DelegateFactoryDeclaration;

        /// <summary>
        /// Gets the method declaraion for the implementation of a virtual
        /// method callback.
        /// </summary>
        public MethodDeclarationSyntax VirtualMethodCallbackImplementation =>
            _VirtualMethodCallbackImplementation.Value;
        readonly Lazy<MethodDeclarationSyntax> _VirtualMethodCallbackImplementation;

        public DelegateInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "callback") {
                throw new ArgumentException ("Requires a <callback> element.", nameof(element));
            }
            _ManagedDelegateDeclaration = new Lazy<DelegateDeclarationSyntax>(LazyGetManagedDelegateDeclaration, false);
            _UnmanagedDelegateDeclaration = new Lazy<DelegateDeclarationSyntax>(LazyGetUnmanagedDelegateDeclaration, false);
            _DelegateFactoryDeclaration =
                new Lazy<ClassDeclarationSyntax>(LazyGetDelegateFactoryDeclaration, false);
            _VirtualMethodCallbackImplementation =
                new Lazy<MethodDeclarationSyntax>(LazyGetVirtualMethodCallbackImplementation, false);
        }

        // gets a delegate declaration like:
        // public void Func();
        DelegateDeclarationSyntax LazyGetManagedDelegateDeclaration()
        {
            var returnType = MethodInfo.ManagedReturnParameterInfo.TypeInfo.Type;
            if (MethodInfo.ThrowsGErrorException && returnType.ToString() == typeof(bool).FullName) {
                // don't return bool for managed delegates that throw
                returnType = PredefinedType(Token(VoidKeyword));
            }
            return DelegateDeclaration(returnType, Identifier)
                .WithAttributeLists(AttributeLists)
                .WithModifiers(Modifiers)
                .WithParameterList(MethodInfo.ParameterList)
                .WithLeadingTrivia(DocumentationCommentTriviaList);
        }

        // gets a delegate declaration like:
        // public void UnmanagedFunc(IntPtr data);
        DelegateDeclarationSyntax LazyGetUnmanagedDelegateDeclaration()
        {
            var returnType = MethodInfo.UnmanagedReturnParameterInfo.TypeInfo.Type;
            return DelegateDeclaration(returnType, UnmanagedIdentifier)
                .WithAttributeLists(UnmanagedAttributeLists)
                .WithModifiers(Modifiers)
                .WithParameterList(MethodInfo.PinvokeParameterList)
                .WithLeadingTrivia(UnmanagedDocumentationCommentTriviaList);
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return MethodInfo.GetChildInfos ();
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            MemberDeclarationSyntax unmangedDeclaration;
            MemberDeclarationSyntax managedDeclaration;
            MemberDeclarationSyntax factoryDeclaration;

            try {
                managedDeclaration = ManagedDelegateDeclaration;
                unmangedDeclaration = UnmanagedDelegateDeclaration;
                factoryDeclaration = DelegateFactoryDeclaration;
            } catch (Exception ex) {
                Console.WriteLine("Skipping {0} ({1}) due to error: {2}",
                    QualifiedName, Element.Name.LocalName, ex.Message);
                yield break;
            }
    
            yield return unmangedDeclaration;
            yield return managedDeclaration;
            yield return factoryDeclaration;
        }

        MethodDeclarationSyntax LazyGetVirtualMethodCallbackImplementation()
        {
            var returnType = MethodInfo.UnmanagedReturnParameterInfo.TypeInfo.Type;

            var method = MethodDeclaration(returnType, "On" + Identifier)
                .AddModifiers(Token(SyntaxKind.StaticKeyword))
                .WithParameterList(MethodInfo.UnmanagedParameterList)
                .WithBody(Block(MethodInfo.VirtualMethodImplStatements));

            return method;
        }

        ClassDeclarationSyntax LazyGetDelegateFactoryDeclaration()
        {
            var factoryDeclaration = ClassDeclaration(Identifier + "Factory")
               .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
               .WithMembers(List(LazyGetFactoryClassMembers()))
               .WithLeadingTrivia(GetFactoryDocumentationCommentTrivia());
            return factoryDeclaration;
        }

        IEnumerable<MemberDeclarationSyntax> LazyGetFactoryClassMembers()
        {
            // emit nested private Data class

            var managedDelegateField = FieldDeclaration(VariableDeclaration(QualifiedName)
                    .AddVariables(VariableDeclarator("ManagedDelegate")))
                .AddModifiers(Token(PublicKeyword));
            var unmanagedDelegateField = FieldDeclaration(VariableDeclaration(UnmanagedQualifiedName)
                    .AddVariables(VariableDeclarator("UnmanagedDelegate")))
                .AddModifiers(Token(PublicKeyword));
            var notifyType = typeof(UnmanagedDestroyNotify).ToSyntax();
            var notifyField = FieldDeclaration(VariableDeclaration(notifyType)
                    .AddVariables(VariableDeclarator("DestroyDelegate")))
                .AddModifiers(Token(PublicKeyword));
            var scopeType = typeof(CallbackScope).ToSyntax();
            var scopeField = FieldDeclaration(VariableDeclaration(scopeType)
                    .AddVariables(VariableDeclarator("Scope")))
                .AddModifiers(Token(PublicKeyword));
            var dataClass = ClassDeclaration("UserData")
                .AddMembers(managedDelegateField, unmanagedDelegateField, notifyField, scopeField);
            yield return dataClass;

            // emit Create() method

            var createMethodParams = $"({QualifiedName} callback, {scopeType} scope)";
            var createMethodParamList = ParseParameterList(createMethodParams);
            var returnType = ParseTypeName(string.Format("{0}<{1}, {2}, {3}>",
                typeof(ValueTuple).FullName,
                UnmanagedQualifiedName,
                typeof(UnmanagedDestroyNotify).FullName,
                typeof(IntPtr).FullName));
            var createMethod = MethodDeclaration(returnType, "Create")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .WithParameterList(createMethodParamList)
                .WithBody(Block(LazyGetFactoryStatements()))
                .WithLeadingTrivia(LazyGetFactoryCreateMethodDocumentationCommentTrivia());
            yield return createMethod;

            // emit unmanaged callback method

            var callbackReturnType = MethodInfo.UnmanagedReturnParameterInfo.TypeInfo.Type;
            var callbackMethod = MethodDeclaration(callbackReturnType, "UnmanagedCallback")
                .AddModifiers(Token(StaticKeyword))
                .WithParameterList(MethodInfo.UnmanagedParameterList)
                .WithBody(Block(MethodInfo.CallbackStatements));
            yield return callbackMethod;

            // emit destroy notify method

            var destroyReturnType = ParseTypeName("void");
            var destroyParamList = ParseParameterList($"({typeof(IntPtr).FullName} userData_)");

            var destroyTryStatement = ParseStatement(string.Format(@"try {{
                var gcHandle = ({0})userData_;
                gcHandle.Free();
            }}
            catch ({1} ex) {{
                {2}.{3}(ex);
            }}
            ", typeof(GCHandle).FullName,
                typeof(Exception).FullName,
                typeof(Log).FullName,
                nameof(Log.LogUnhandledException)));

            var destroyMethod = MethodDeclaration(destroyReturnType, "Destroy")
                .AddModifiers(Token(StaticKeyword))
                .WithParameterList(destroyParamList)
                .WithBody(Block(destroyTryStatement));

            yield return destroyMethod;
        }

        IEnumerable<StatementSyntax> LazyGetFactoryStatements()
        {
            var userDataStatement = string.Format(@"var userData = new UserData {{
                ManagedDelegate = callback ?? throw new {0}(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            }};
            ", typeof(ArgumentNullException).FullName);
            yield return ParseStatement(userDataStatement);

            var gcHandleStatement = string.Format("var userData_ = ({0}){1}.{2}(userData);\n",
                typeof(IntPtr).FullName,
                typeof(GCHandle).FullName,
                nameof(GCHandle.Alloc));
            yield return ParseStatement(gcHandleStatement);

            const string returnStatement = "return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);\n";
            yield return ParseStatement(returnStatement);
        }

        SyntaxTriviaList GetFactoryDocumentationCommentTrivia ()
        {
            var comments = string.Format (@"/// <summary>
/// Factory for creating <see cref=""{0}""/> methods.
/// </summary>
", UnmanagedIdentifier);
            return ParseLeadingTrivia (comments);
        }

        SyntaxTriviaList LazyGetFactoryCreateMethodDocumentationCommentTrivia()
        {
            var comments = string.Format(@"/// <summary>
/// Wraps a <see cref=""{0}""/> in an anonymous method that can
/// be passed to unmanaged code.
/// </summary>
/// <param name=""method"">The managed method to wrap.</param>
/// <param name=""scope"">The lifetime scope of the callback.</param>
/// <returns>
/// A tuple containing the unmanaged callback, the unmanaged
/// notify function and a pointer to the user data.
/// </returns>
/// <remarks>
/// This function is used to marshal managed callbacks to unmanged
/// code. If the scope is <see cref=""{1}.{2}""/>
/// then it is the caller's responsibility to invoke the notify function
/// when the callback is no longer needed. If the scope is
/// <see cref=""{1}.{3}""/>, then the notify
/// function should be ignored.
/// </remarks>
", Identifier, typeof(CallbackScope).FullName, nameof(CallbackScope.Call), nameof(CallbackScope.Async));

            return ParseLeadingTrivia(comments);
        }
    }
}
