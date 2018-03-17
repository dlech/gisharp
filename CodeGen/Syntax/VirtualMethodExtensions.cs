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
            var gtypeStruct = method.ParentNode.GTypeStructNode;
            var field = gtypeStruct.Fields.Single(x => x.GirName == method.GirName);
            var type = ParseTypeName($"{gtypeStruct.ManagedName}.Unmanaged{field.Callback.ManagedName}");
            var getter = nameof(TypeClass.GetUnmanagedVirtualMethod);
            var invoker = $"{typeof(TypeClass).FullName}.{getter}<{type}>(_GType)";

            // TODO: there is an unused GIR attribute override="always" that we
            // could use to generate C# abstract methods instead of virtual
            // methods.

            var returnType = method.ReturnValue.GirType.ManagedType.ToSyntax();
            yield return MethodDeclaration(returnType, method.ManagedName)
                .WithAttributeLists(method.GetAttributeLists())
                .AddModifiers(Token(InternalKeyword), Token(ProtectedKeyword), Token(VirtualKeyword))
                .WithParameterList(method.ManagedParameters.GetParameterList())
                .WithBody(Block(method.GetInvokeStatements(invoker)))
                .WithLeadingTrivia(TriviaList()
                    .AddRange(method.Doc.GetDocCommentTrivia())
                    .AddRange(method.ManagedParameters.RegularParameters
                        .SelectMany(x => x.Doc.GetDocCommentTrivia()))
                    .AddRange(method.ReturnValue.Doc.GetDocCommentTrivia())
                    .AddRange(method.GetGErrorExceptionDocCommentTrivia()));
        }

        /// <summary>
        /// Gets the C# interface method declaration for a GIR virtual method
        /// </summary>
        public static MethodDeclarationSyntax GetInterfaceDeclaration(this VirtualMethod method)
        {
            var returnType = method.ReturnValue.GirType.ManagedType.ToSyntax();
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

            var gtypeStruct = method.ParentNode.GTypeStructNode;
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
    }
}
