using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Syntax
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Converts a type to a type name syntax
        /// </summary>
        public static TypeSyntax ToSyntax(this Type type)
        {
            var typeName = type?.FullName ?? throw new ArgumentNullException(nameof(type));

            // nested types have "+" that needs to be changed to "."
            var fixedUpTypeName = typeName.Replace("+", ".");

            if (typeName == "System.Void") {
                // C# can't use System.Void
                fixedUpTypeName = "void";
            } else if (typeName.Contains("`")) {
                // Generics need fixing up
                fixedUpTypeName = typeName.Remove(typeName.IndexOf ('`'));
            }

            if (type.IsGenericType) {
                return GenericName(fixedUpTypeName)
                    .AddTypeArgumentListArguments(type.GenericTypeArguments
                        .Select(x => x.ToSyntax()).ToArray());
            }

            return ParseTypeName(fixedUpTypeName);
        }
    }
}
