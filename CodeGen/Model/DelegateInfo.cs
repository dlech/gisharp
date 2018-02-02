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
                    _UnmanagedAttributeLists = base.AttributeLists
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

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            MemberDeclarationSyntax unmangedDeclaration;
            MemberDeclarationSyntax managedDeclaration;

            try {
                unmangedDeclaration = DelegateDeclaration (MethodInfo.UnmanagedReturnParameterInfo.TypeInfo.Type, UnmanagedIdentifier)
                    .WithAttributeLists (UnmanagedAttributeLists)
                    .WithModifiers (Modifiers)
                    .WithParameterList (MethodInfo.PinvokeParameterList)
                    .WithLeadingTrivia (UnmanagedDocumentationCommentTriviaList);

                managedDeclaration = DelegateDeclaration (MethodInfo.ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                    .WithAttributeLists (AttributeLists)
                    .WithModifiers (Modifiers)
                    .WithParameterList (MethodInfo.ParameterList)
                    .WithLeadingTrivia (DocumentationCommentTriviaList);
            } catch (Exception ex) {
                Console.WriteLine ("Skipping {0} due to error: {1}", QualifiedName, ex.Message);
                yield break;
            }
            yield return unmangedDeclaration;
            yield return managedDeclaration;

            //var factoryDeclaration = ClassDeclaration (UnmanagedIdentifier + "Factory")
            //    .AddModifiers (
            //        Token (SyntaxKind.PublicKeyword),
            //        Token (SyntaxKind.StaticKeyword))
            //    .AddMembers (
            //        MethodDeclaration (UnmanagedQualifiedName, "Create")
            //        .AddModifiers (
            //            Token (SyntaxKind.PublicKeyword),
            //            Token (SyntaxKind.StaticKeyword))
            //        .AddParameterListParameters (
            //            Parameter (ParseToken ("method"))
            //                .WithType (QualifiedName),
            //            Parameter (ParseToken ("freeUserData"))
            //            .WithType (ParseTypeName (typeof(bool).FullName)))
            //        .WithBody (Block (GetFactoryStatements ()))
            //        .WithLeadingTrivia (GetFactoryCreateMethodDocumentationCommentTrivia ()))
            //    .WithLeadingTrivia (GetFactoryDocumentationCommentTrivia ());
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
            var declarationStatement = VariableDeclaration (UnmanagedQualifiedName)
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
", UnmanagedIdentifier);
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
