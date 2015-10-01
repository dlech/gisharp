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
    public abstract class TypeDeclarationInfo : MemberInfo
    {
        List<FieldInfo> _FieldInfos;
        public IReadOnlyList<FieldInfo> FieldInfos {
            get {
                if (_FieldInfos == null) {
                    _FieldInfos = GetFieldInfos ().ToList ();
                }
                return _FieldInfos.AsReadOnly ();
            }
        }

        List<MethodInfo> _MethodInfos;
        public IReadOnlyList<MethodInfo> MethodInfos {
            get {
                if (_MethodInfos == null) {
                    _MethodInfos = GetMethodInfos ().ToList ();
                }
                return _MethodInfos.AsReadOnly ();
            }
        }

        SyntaxList<MemberDeclarationSyntax> _TypeMembers;
        public SyntaxList<MemberDeclarationSyntax> TypeMembers {
            get {
                if (_TypeMembers == default(SyntaxList<MemberDeclarationSyntax>)) {
                    _TypeMembers = List<MemberDeclarationSyntax> ()
                        .AddRange (FieldInfos.SelectMany (x => x.Declarations))
                        .AddRange (MethodInfos.SelectMany (x => x.Declarations));
                }
                return _TypeMembers;
            }
        }

        protected TypeDeclarationInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
        }

        IEnumerable<FieldInfo> GetFieldInfos ()
        {
            foreach (var constant in Element.Elements (gi + "constant")) {
                yield return new FieldInfo (constant, this);
            }
            foreach (var field in Element.Elements (gi + "field")) {
                yield return new FieldInfo (field, this);
            }
        }

        IEnumerable<MethodInfo> GetMethodInfos ()
        {
            foreach (var constructor in Element.Elements (gi + "constructor")) {
                yield return new MethodInfo (constructor, this);
            }
            foreach (var function in Element.Elements (gi + "function")) {
                yield return new MethodInfo (function, this);
            }
            foreach (var method in Element.Elements (gi + "method")) {
                yield return new MethodInfo (method, this);
            }
        }
    }
}
