// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using Signal = GISharp.CodeGen.Gir.Signal;

namespace GISharp.CodeGen.Syntax
{
    public static class SignalExtensions
    {
        private static SyntaxTriviaList GetSignalDocComments(this Signal signal)
        {
            // The event handler delegate gets the main docs since it has the
            // parameters, so the event itself just refers to the signal handler
            // delegate type, otherwise we end up with broken paramref elements
            // that have to be fixed.
            return ParseLeadingTrivia(
                $@"/// <seealso cref=""{signal.ManagedName}Handler""/>
            "
            );
        }

        /// <summary>
        /// Gets the C# interface event declaration for a GIR signal
        /// </summary>
        private static EventFieldDeclarationSyntax GetInterfaceEventDeclaration(this Signal signal)
        {
            var type = $"{signal.ManagedName}Handler";
            var variable = VariableDeclaration(ParseTypeName(type))
                .AddVariables(VariableDeclarator(signal.ManagedName));
            return EventFieldDeclaration(variable)
                .WithAttributeLists(signal.GetCommonAttributeLists())
                .AddAttributeLists(signal.GetGSignalAttributeList())
                .WithSemicolonToken(Token(SemicolonToken))
                .WithLeadingTrivia(signal.GetSignalDocComments())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        static AttributeListSyntax GetGSignalAttributeList(this Signal signal)
        {
            // create the attribute
            var attrName = ParseName(typeof(GSignalAttribute).FullName);
            var nameArg = ParseExpression($"\"{signal.GirName}\"");
            var attr = Attribute(attrName).AddArgumentListArguments(AttributeArgument(nameArg));

            var whenExpression =
                $"{nameof(GSignalAttribute.When)} = {typeof(EmissionStage)}.{signal.When}";
            attr = attr.AddArgumentListArguments(
                AttributeArgument(ParseExpression(whenExpression))
            );

            // add optional arguments

            if (signal.IsNoRecurse)
            {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsNoRecurse)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            if (signal.IsDetailed)
            {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsDetailed)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            if (signal.IsAction)
            {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsAction)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            if (signal.IsNoHooks)
            {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsNoHooks)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            return AttributeList().AddAttributes(attr);
        }

        /// <summary>
        /// Gets an event declaration like:
        /// <code>
        /// public event SomethingChangedSignalHandler SomethingChangedSignal {
        ///     add => AddEventSignalHandler("name", value);
        ///     remove => RemoveEventSignalHandler("name", value);
        /// }
        /// </code>
        /// </summary>
        public static EventDeclarationSyntax GetEventDeclaration(this Signal signal)
        {
            var typeName = ParseTypeName($"{signal.ManagedName}Handler");
            var name = signal.GirName;

            var addAccessor = AccessorDeclaration(AddAccessorDeclaration)
                .WithExpressionBody(
                    ArrowExpressionClause(
                        ParseExpression($"AddEventSignalHandler(\"{name}\", value)")
                    )
                )
                .WithSemicolonToken(Token(SemicolonToken));

            var removeAccessor = AccessorDeclaration(RemoveAccessorDeclaration)
                .WithExpressionBody(
                    ArrowExpressionClause(
                        ParseExpression($"RemoveEventSignalHandler(\"{name}\", value)")
                    )
                )
                .WithSemicolonToken(Token(SemicolonToken));

            var accessorList = AccessorList().AddAccessors(addAccessor, removeAccessor);

            return EventDeclaration(typeName, signal.ManagedName)
                .WithAttributeLists(signal.GetCommonAttributeLists())
                .AddAttributeLists(signal.GetGSignalAttributeList())
                .AddModifiers(signal.GetCommonAccessModifiers().ToArray())
                .WithAccessorList(accessorList)
                .WithLeadingTrivia(signal.GetSignalDocComments())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        /// <summary>
        /// Generates delegate like:
        /// <code>
        /// public delegate void SomethingChangedSignalHandler(Object @object, ...);
        /// </code>
        /// </summary>
        static DelegateDeclarationSyntax GetSignalHandlerDelegateDeclaration(this Signal signal)
        {
            var returnType = signal.ReturnValue.GetManagedTypeName();
            var identifier = $"{signal.ManagedName}Handler";
            return DelegateDeclaration(returnType, identifier)
                .AddModifiers(Token(PublicKeyword))
                .WithParameterList(signal.ManagedParameters.GetParameterList())
                .WithLeadingTrivia(
                    signal.Doc
                        .GetDocCommentTrivia()
                        .AddRange(
                            signal.ManagedParameters.SelectMany(x => x.Doc.GetDocCommentTrivia())
                        )
                        .AddRange(signal.ReturnValue.Doc.GetDocCommentTrivia())
                )
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        /// <summary>
        /// Gets the member declarations for the signals, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(
            this IEnumerable<Signal> signals,
            bool forInterface = false
        )
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var signal in signals)
            {
                try
                {
                    list = list.Add(signal.GetSignalHandlerDelegateDeclaration());
                    if (forInterface)
                    {
                        list = list.Add(signal.GetInterfaceEventDeclaration());
                    }
                    else
                    {
                        list = list.Add(signal.GetEventDeclaration());
                    }
                    list = list.Add(signal.GetManagedSignalCallbackDeclaration());
                }
                catch (Exception ex)
                {
                    signal.LogException(ex);
                }
            }

            return list;
        }

        private static MethodDeclarationSyntax GetManagedSignalCallbackDeclaration(
            this Signal signal
        )
        {
            var returnType = ParseTypeName(signal.ReturnValue.Type.GetUnmanagedType());
            var method = MethodDeclaration(returnType, $"Managed{signal.ManagedName}Handler")
                .AddAttributeLists(
                    AttributeList()
                        .AddAttributes(
                            Attribute(ParseName(typeof(UnmanagedCallersOnlyAttribute).FullName))
                                .AddArgumentListArguments(
                                    AttributeArgument(
                                        ParseExpression(
                                            $"CallConvs = new[] {{ typeof({typeof(CallConvCdecl)}) }}"
                                        )
                                    )
                                )
                        )
                )
                .AddModifiers(Token(PrivateKeyword), Token(StaticKeyword))
                .WithParameterList(signal.Parameters.GetParameterList())
                .WithBody(Block(signal.GetCallbackStatements()));
            return method;
        }

        // Gets an event declaration like:
        // public event SomethingChangedSignalHandler SomethingChangedSignal {
        ///     add => AddEventSignalHandler("name", value);
        ///     remove => RemoveEventSignalHandler("name", value);
        // }
        internal static EventDeclarationSyntax GetImplementsEventDeclaration(this Signal signal)
        {
            var delcaringType = signal.Ancestors.OfType<Interface>().Single();
            var typeName = ParseTypeName(
                $"{delcaringType.GetManagedType()}.{signal.ManagedName}Handler"
            );
            var name = signal.GirName;

            var addAccessor = AccessorDeclaration(AddAccessorDeclaration)
                .WithExpressionBody(
                    ArrowExpressionClause(
                        ParseExpression($"AddEventSignalHandler(\"{name}\", value)")
                    )
                )
                .WithSemicolonToken(Token(SemicolonToken));

            var removeAccessor = AccessorDeclaration(RemoveAccessorDeclaration)
                .WithExpressionBody(
                    ArrowExpressionClause(
                        ParseExpression($"RemoveEventSignalHandler(\"{name}\", value)")
                    )
                )
                .WithSemicolonToken(Token(SemicolonToken));

            return EventDeclaration(typeName, signal.ManagedName)
                .AddModifiers(
                    Token(PublicKeyword)
                        // Can't add leading trivia to EventDeclaration, so have to
                        // attach it to public keyword.
                        // TODO: inheritdoc only makes sense when implementing an
                        // interface. If info is GirEventInfo, we should be able to
                        // get docs from the GIR XML
                        .WithLeadingTrivia(ParseLeadingTrivia("/// <inheritdoc />\n"))
                )
                .AddAccessorListAccessors(addAccessor, removeAccessor);
        }
    }
}
