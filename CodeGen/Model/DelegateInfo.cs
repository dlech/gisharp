using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

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

        SyntaxToken? _NativeIdentifier;
        public SyntaxToken NativeIdentifier {
            get {
                if (!_NativeIdentifier.HasValue) {
                    _NativeIdentifier = Identifier ("Native" + Identifier);
                }
                return _NativeIdentifier.Value;
            }
        }

        QualifiedNameSyntax _NativeQualifiedName;
        public QualifiedNameSyntax NativeQualifiedName {
            get {
                if (_NativeQualifiedName == null) {
                    _NativeQualifiedName = QualifiedName (
                        NamespaceInfo.Name,
                        IdentifierName (NativeIdentifier));
                    // callbacks can be declared by fields, in which case they
                    // are a child type.
                    var declaringType = DeclaringMember.DeclaringMember as TypeDeclarationInfo;
                    if (declaringType != null) {
                        _NativeQualifiedName = QualifiedName (
                            QualifiedName (
                                _NativeQualifiedName.Left,
                                IdentifierName (declaringType.Identifier)),
                            _NativeQualifiedName.Right);
                    }
                }
                return _NativeQualifiedName;
            }
        }

        SyntaxList<AttributeListSyntax>? _NativeAttributeLists;
        public SyntaxList<AttributeListSyntax> NativeAttributeLists {
            get {
                if (!_NativeAttributeLists.HasValue) {
                    var unmanagedFuncPtrAttrName = ParseName (typeof(UnmanagedFunctionPointerAttribute).FullName);
                    var unmangedFuncPtrAttrArgListText = string.Format ("({0}.{1})", typeof(CallingConvention), CallingConvention.Cdecl);
                    var unmanagedFuncPtrAttrArgList = ParseAttributeArgumentList (unmangedFuncPtrAttrArgListText);
                    var unmanagedFuncPtrAttr = Attribute (unmanagedFuncPtrAttrName)
                        .WithArgumentList (unmanagedFuncPtrAttrArgList);
                    _NativeAttributeLists = List<AttributeListSyntax> ()
                        .AddRange (base.GetAttributeLists ())
                        .Add (AttributeList ().AddAttributes (unmanagedFuncPtrAttr));
                }
                return _NativeAttributeLists.Value;
            }
        }

        SyntaxTriviaList? _NativeDocumentationCommentTriviaList;
        public SyntaxTriviaList NativeDocumentationCommentTriviaList {
            get {
                if (!_NativeDocumentationCommentTriviaList.HasValue) {
                    _NativeDocumentationCommentTriviaList = base.GetDocumentationCommentTriviaList ();
                }
                return _NativeDocumentationCommentTriviaList.Value;
            }
        }

        public DelegateInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "callback") {
                throw new ArgumentException ("Requires a <callback> element.", nameof(element));
            }
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return MethodInfo.GetChildInfos ();
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            var unmangedDeclaration = DelegateDeclaration (MethodInfo.UnmanagedReturnParameterInfo.TypeInfo.Type, NativeIdentifier)
                .WithAttributeLists (NativeAttributeLists)
                .WithModifiers (Modifiers)
                .WithParameterList (MethodInfo.PinvokeParameterList)
                .WithLeadingTrivia (NativeDocumentationCommentTriviaList);
            yield return unmangedDeclaration;

            var managedDeclaration = DelegateDeclaration (MethodInfo.ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                .WithAttributeLists (AttributeLists)
                .WithModifiers (Modifiers)
                .WithParameterList (MethodInfo.ParameterList)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            yield return managedDeclaration;

            var factoryDeclaration = ClassDeclaration (NativeIdentifier + "Factory")
                .AddModifiers (
                    Token (SyntaxKind.PublicKeyword),
                    Token (SyntaxKind.StaticKeyword))
                .AddMembers (
                    MethodDeclaration (NativeQualifiedName, "Create")
                    .AddModifiers (
                        Token (SyntaxKind.PublicKeyword),
                        Token (SyntaxKind.StaticKeyword))
                    .AddParameterListParameters (
                        Parameter (ParseToken ("method"))
                            .WithType (QualifiedName),
                        Parameter (ParseToken ("freeUserData"))
                        .WithType (ParseTypeName (typeof(bool).FullName)))
                    .WithBody (Block (GetFactoryStatements ()))
                    .WithLeadingTrivia (GetFactoryCreateMethodDocumentationCommentTrivia ()))
                .WithLeadingTrivia (GetFactoryDocumentationCommentTrivia ());
            //yield return factoryDeclaration;
        }

        IEnumerable<StatementSyntax> GetFactoryStatements ()
        {
            var nativeCallback = Identifier ("nativeCallback");
            var body = Block (MethodInfo.CallbackStatements);
            var lambdaExpression = ParenthesizedLambdaExpression (body)
                .WithParameterList (
                    MethodInfo.PinvokeParameterList
                    // Add "_" suffix to all parameters
                    .WithParameters (SeparatedList<ParameterSyntax> (
                        MethodInfo.PinvokeParameterList.Parameters
                            .Select (x => x.WithIdentifier (Identifier (x.Identifier + "_"))))));
            var declarationStatement = VariableDeclaration (NativeQualifiedName)
                .AddVariables (
                    VariableDeclarator (nativeCallback)
                    .WithInitializer (
                        EqualsValueClause (lambdaExpression)));
            yield return LocalDeclarationStatement (declarationStatement);
            yield return ReturnStatement (IdentifierName (nativeCallback));
        }

        SyntaxTriviaList GetFactoryDocumentationCommentTrivia ()
        {
            var comments = string.Format (@"/// <summary>
/// Factory for creating <see cref=""{0}""/> methods.
/// </summary>
", NativeIdentifier);
            return ParseLeadingTrivia (comments);
        }

        SyntaxTriviaList GetFactoryCreateMethodDocumentationCommentTrivia ()
        {
            var comments = string.Format (@"/// <summary>
/// Wraps <see cref=""{0}""/> in an anonymous method that can be passed
/// to unmaged code.
/// </summary>
/// <param name=""method"">The managed method to wrap.</param>
/// <param name=""freeUserData"">Frees the <see cref=""GCHandle""/> for any user
/// data closure parameters in the unmanged function</param>
/// <returns>The callback method for passing to unmanged code.</returns>
/// <remarks>
/// This function is used to marshal managed callbacks to unmanged code. If this
/// callback is only called once, <paramref name=""freeUserData""/> should be
/// set to <c>true</c>. If it can be called multiple times, it should be set to
/// <c>false</c> and the user data must be freed elsewhere. If the callback does
/// not have closure user data, then the <paramref name=""freeUserData""/> 
/// parameter has no effect.
/// </remarks>
", Identifier);
            return ParseLeadingTrivia (comments);
        }
    }
}
