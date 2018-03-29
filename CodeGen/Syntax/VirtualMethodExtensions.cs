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

namespace GISharp.CodeGen.Syntax
{
    public static class VirtualMethodExtensions
    {
        public static IEnumerable<MethodDeclarationSyntax> GetClassMembers(this VirtualMethod method)
        {
            var delcaringType = (GIRegisteredType)method.ParentNode;
            var gtypeStruct = delcaringType.GTypeStructNode;
            var field = gtypeStruct.Fields.Single(x => x.GirName == method.GirName);
            var type = ParseTypeName($"{gtypeStruct.ManagedName}.Unmanaged{field.Callback.ManagedName}");
            var getter = nameof(TypeClass.GetUnmanagedVirtualMethod);
            var invoker = $"{typeof(TypeClass)}.{getter}<{type}>(_GType)";

            var returnType = method.ReturnValue.GetManagedTypeName();
            
            var syntax = MethodDeclaration(returnType, method.ManagedName)
                .WithAttributeLists(method.GetAttributeLists())
                .AddModifiers(Token(ProtectedKeyword), Token(VirtualKeyword), Token(UnsafeKeyword))
                .WithParameterList(method.ManagedParameters.GetParameterList())
                .WithBody(Block(method.GetInvokeStatements(invoker)))
                .WithLeadingTrivia(TriviaList()
                    .AddRange(method.Doc.GetDocCommentTrivia())
                    .AddRange(method.ManagedParameters.RegularParameters
                        .SelectMany(x => x.Doc.GetDocCommentTrivia()))
                    .AddRange(method.ReturnValue.Doc.GetDocCommentTrivia())
                    .AddRange(method.GetGErrorExceptionDocCommentTrivia()));

            yield return syntax;
        }

        /// <summary>
        /// Gets the C# interface method declaration for a GIR virtual method
        /// </summary>
        public static MethodDeclarationSyntax GetInterfaceDeclaration(this VirtualMethod method)
        {
            var returnType = method.ReturnValue.GetManagedTypeName();
            return MethodDeclaration(returnType, method.ManagedName)
                .WithAttributeLists(method.GetAttributeLists())
                .WithParameterList(method.ManagedParameters.GetParameterList())
                .WithSemicolonToken(Token(SemicolonToken))
                .WithLeadingTrivia(TriviaList()
                    .AddRange(method.Doc.GetDocCommentTrivia())
                    .AddRange(method.ManagedParameters.RegularParameters
                        .SelectMany(x => x.Doc.GetDocCommentTrivia()))
                    .AddRange(method.ReturnValue.Doc.GetDocCommentTrivia())
                    .AddRange(method.GetGErrorExceptionDocCommentTrivia()));
        }

        static SyntaxList<AttributeListSyntax> GetAttributeLists(this VirtualMethod method)
        {
            var attrName = typeof(GVirtualMethodAttribute).FullName;

            var delcaringType = (GIRegisteredType)method.ParentNode;
            var gtypeStruct = delcaringType.GTypeStructNode;
            var field = gtypeStruct.Fields.Single(x => x.GirName == method.GirName);
            var type = ParseTypeName($"{gtypeStruct.ManagedName}.Unmanaged{field.Callback.ManagedName}");
            var typeArg = AttributeArgument(TypeOfExpression(type));

            // TODO: there is an unused GIR attribute must-chain-up="1" that
            // could be turned into a parameter to GVirtualMethodAttribute

            var attr = Attribute(ParseName(attrName))
                .AddArgumentListArguments(typeArg);
            var list = method.GetCommonAttributeLists()
                .Add(AttributeList().AddAttributes(attr));

            return list;
        }

        /// <summary>
        /// Gets the member declarations for the virtual methods, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<VirtualMethod> methods, bool forInterface = false)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var method in methods) {
                try {
                    if (forInterface) {
                        list = list.Add(method.GetInterfaceDeclaration());
                    }
                    else {
                        list = list.AddRange(method.GetClassMembers());
                    }
                }
                catch (Exception ex) {
                    method.LogException(ex);
                }
            }

            return list;
        }
    }
}
