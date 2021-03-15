// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ImplementsExtensions
    {
        /// <summary>
        /// Gets the C# interface event implementation declarations for a GIR
        /// implements
        /// </summary>
        static SyntaxList<MemberDeclarationSyntax> GetSignalImplementations(this Implements implements)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var signal in implements.Interface.Signals) {
                list = list.Add(signal.GetImplementsEventDeclaration());
            }

            return list;
        }

        /// <summary>
        /// Gets the signal member declarations for the implementses,
        /// logging a warning for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetSignalMemberDeclarations(this IEnumerable<Implements> implementses)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var implements in implementses) {
                try {
                    list = list.AddRange(implements.GetSignalImplementations());
                }
                catch (Exception ex) {
                    implements.LogException(ex);
                }
            }

            return list;
        }

        /// <summary>
        /// Gets the C# interface method implementation declarations for a GIR
        /// implements
        /// </summary>
        static SyntaxList<MemberDeclarationSyntax> GetVirtualMethodImplementations(this Implements implements)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var m in implements.Interface.VirtualMethods) {
                var returnType = m.ReturnValue.GetManagedTypeName();
                var name = $"{implements.Interface.GetManagedType()}.{m.ManagedName}";
                var paramList = ParameterList().AddParameters(m.ManagedParameters.RegularParameters
                    .Select(x => x.GetParameter()).ToArray());
                // remove default value initializers
                paramList = paramList.WithParameters(SeparatedList(paramList.Parameters
                    .Select(x => x.WithDefault(default))));
                var method = MethodDeclaration(returnType, name)
                    .WithParameterList(paramList)
                    .WithBody(Block(ThrowStatement(ParseExpression("new System.NotImplementedException()"))));
                list = list.Add(method);
            }

            return list;
        }

        /// <summary>
        /// Gets the virtual method member declarations for the implementses,
        /// logging a warning for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetVirtualMethodMemberDeclarations(this IEnumerable<Implements> implementses)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var implements in implementses) {
                try {
                    list = list.AddRange(implements.GetVirtualMethodImplementations());
                }
                catch (Exception ex) {
                    implements.LogException(ex);
                }
            }

            return list;
        }
    }
}
