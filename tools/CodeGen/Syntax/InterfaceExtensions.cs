using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.CodeGen.Syntax
{
    public static class InterfaceExtensions
    {
        /// <summary>
        /// Gets the C# interface declaration for a GIR interface
        /// </summary>
        public static InterfaceDeclarationSyntax GetInterfaceDeclaration(this Interface @interface)
        {
            var baseTypes = SeparatedList(@interface.Prerequisites.Select(x => x.GetBaseType()));

            if (!baseTypes.Any(x => x.ToString().Contains("GInterface"))) {
                // if there was not an instantiatable prerequisite, use GObject
                baseTypes = baseTypes.Add(SimpleBaseType(typeof(GInterface<Object>).ToSyntax()));
            }

            var syntax = InterfaceDeclaration(@interface.ManagedName)
                .AddModifiers(Token(PublicKeyword), Token(PartialKeyword))
                .WithBaseList(BaseList(baseTypes))
                .WithAttributeLists(@interface.GetGTypeAttributeLists())
                .WithLeadingTrivia(@interface.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        /// <summary>
        /// Gets the C# interface member declarations for a GIR interface
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetInterfaceMembers(this Interface @interface)
        {
            return List<MemberDeclarationSyntax>()
                .AddRange(@interface.Properties.GetMemberDeclarations(true))
                .AddRange(@interface.Signals.GetMemberDeclarations(true))
                .AddRange(@interface.VirtualMethods.GetMemberDeclarations(true));
        }

        /// <summary>
        /// Gets the C# extension class declaration for a GIR interface
        /// </summary>
        public static ClassDeclarationSyntax GetExtClassDeclaration(this Interface @interface)
        {
            // trim "I" prefix
            var identifier = @interface.ManagedName.Substring(1);
            return ClassDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword), Token(PartialKeyword))
                .WithLeadingTrivia(ParseLeadingTrivia(string.Format(@"/// <summary>
                /// Extension methods for <see cref=""{0}""/>
                /// </summary>
                ", @interface.ManagedName)));
        }

        /// <summary>
        /// Gets the C# extension class member declarations for a GIR interface
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetExtClassMembers(this Interface @interface)
        {
            var members = List<MemberDeclarationSyntax>()
                .AddRange(@interface.Constants.GetMemberDeclarations())
                .AddRange(@interface.ManagedProperties.GetMemberDeclarations())
                .AddRange(@interface.Signals.Select(x => x.GetEventArgsClassDeclaration()))
                .AddRange(@interface.Functions.GetMemberDeclarations())
                .AddRange(@interface.Methods.GetMemberDeclarations());

            if (@interface.GTypeName != null) {
                members = members.Insert(0, @interface.GetGTypeFieldDeclaration());
            }

            return List(members);
        }
    }
}
