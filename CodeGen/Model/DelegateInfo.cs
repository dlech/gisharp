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
    public class DelegateInfo : MemberInfo
    {
        public override string ManagedName {
            get {
                return base.ManagedName + "Callback";
            }
        }

        MethodInfo _MethodInfo;
        public MethodInfo MethodInfo {
            get {
                if (_MethodInfo == null) {
                    _MethodInfo = new MethodInfo (Element, this);
                }
                return _MethodInfo;
            }
        }

        SyntaxToken _NativeIdentifier;
        public SyntaxToken NativeIdentifier {
            get {
                if (_NativeIdentifier == default(SyntaxToken)) {
                    _NativeIdentifier = SyntaxFactory.Identifier (base.ManagedName);
                }
                return _NativeIdentifier;
            }
        }

        SyntaxList<AttributeListSyntax> _NativeAttributeLists;
        public SyntaxList<AttributeListSyntax> NativeAttributeLists {
            get {
                if (_NativeAttributeLists == default(SyntaxList<AttributeListSyntax>)) {
                    var unmanagedFuncPtrAttrName = SyntaxFactory.ParseName (typeof(UnmanagedFunctionPointerAttribute).FullName);
                    var unmangedFuncPtrAttrArgListText = string.Format ("({0}.{1})", typeof(CallingConvention), CallingConvention.Cdecl);
                    var unmanagedFuncPtrAttrArgList = SyntaxFactory.ParseAttributeArgumentList (unmangedFuncPtrAttrArgListText);
                    var unmanagedFuncPtrAttr = SyntaxFactory.Attribute (unmanagedFuncPtrAttrName)
                        .WithArgumentList (unmanagedFuncPtrAttrArgList);
                    _NativeAttributeLists = SyntaxFactory.List<AttributeListSyntax> ()
                        .AddRange (base.GetAttributeLists ())
                        .Add (SyntaxFactory.AttributeList ().AddAttributes (unmanagedFuncPtrAttr));
                }
                return _NativeAttributeLists;
            }
        }

        SyntaxTriviaList _NativeDocumentationCommentTriviaList;
        public SyntaxTriviaList NativeDocumentationCommentTriviaList {
            get {
                if (_NativeDocumentationCommentTriviaList == default(SyntaxTriviaList)) {
                    _NativeDocumentationCommentTriviaList = base.GetDocumentationCommentTriviaList ();
                }
                return _NativeDocumentationCommentTriviaList;
            }
        }

        public DelegateInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "callback") {
                throw new ArgumentException ("Requires a <callback> element.", nameof(element));
            }
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            var unmangedDeclaration = SyntaxFactory.DelegateDeclaration (MethodInfo.ManagedReturnParameterInfo.TypeInfo.Type, NativeIdentifier)
                .WithAttributeLists (NativeAttributeLists)
                .WithModifiers (Modifiers)
                .WithParameterList (MethodInfo.PinvokeParameterList)
                .WithLeadingTrivia (NativeDocumentationCommentTriviaList);
            yield return unmangedDeclaration;

            var managedDeclaration = SyntaxFactory.DelegateDeclaration (MethodInfo.ManagedReturnParameterInfo.TypeInfo.Type, Identifier)
                .WithAttributeLists (AttributeLists)
                .WithModifiers (Modifiers)
                .WithParameterList (MethodInfo.ParameterList)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            yield return managedDeclaration;
        }
    }
}
