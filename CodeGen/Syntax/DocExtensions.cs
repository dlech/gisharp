using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class DocExtensions
    {
        /// <summary>
        /// Gets the documentation comment trivia list for this item.
        /// </summary>
        /// <param name="doc">The GIR doc node</param>
        /// <param name="extraFixups">When <c>true</c>, will fix up some gtk-doc
        /// elements, like %NULL -> <c>null</c></param>
        /// <returns>The documentation comment trivia list.</returns>
        public static SyntaxTriviaList GetDocCommentTrivia(this Doc doc, bool extraFixups = true)
        {
            if (doc == null) {
                return default;
            }

            var builder = new StringBuilder();
            string line;

            using (var reader = new StringReader(doc.Text)) {
                if (doc.ParentNode is ReturnValue) {
                    builder.AppendLine("/// <returns>");
                    while ((line = reader.ReadLine()) != null) {
                        builder.AppendFormat("/// {0}", new XText(line));
                        builder.AppendLine();
                    }
                    builder.AppendLine("/// </returns>");
                }
                else if (doc.ParentNode is GIArg arg) {
                    builder.AppendFormat("/// <param name=\"{0}\">", arg.ManagedName.Replace("@", ""));
                    builder.AppendLine();
                    while ((line = reader.ReadLine ()) != null) {
                        builder.AppendFormat("/// {0}", new XText(line));
                        builder.AppendLine();
                    }
                    builder.AppendLine ("/// </param>");
                }
                else {
                    builder.AppendLine("/// <summary>");
                    while ((line = reader.ReadLine()) != null) {
                        // summary is only the first paragraph
                        if (string.IsNullOrWhiteSpace(line)) {
                            break;
                        }
                        builder.AppendFormat("/// {0}", new XText(line));
                        builder.AppendLine();
                    }
                    builder.AppendLine("/// </summary>");
                    if (line != null) {
                        // if there are more lines, they go in the remarks
                        builder.AppendLine("/// <remarks>");
                        while ((line = reader.ReadLine()) != null) {
                            builder.AppendFormat("/// {0}", new XText(line));
                            builder.AppendLine();
                        }
                        builder.AppendLine("/// </remarks>");
                    }
                }
            }

            if (extraFixups) {
                var text = builder.ToString();
                var ns = (Namespace)doc.Ancestors.Single(x => x is Namespace);

                builder.Replace("%NULL", "<c>null</c>");
                builder.Replace("%TRUE", "<c>true</c>");
                builder.Replace("%FALSE", "<c>false</c>");

                foreach (var prefix in ns.CIdentifierPrefixes) {
                    var consts = Regex.Matches(text, "%" + prefix + @"_\w+");
                    foreach (Match c in consts.OrderByDescending(x => x.Value.Length)) {
                        var member = (GIBase)ns.FindNodeByCIdentifier(c.Value.Substring(1));
                        if (member == null) {
                            continue;
                        }
                        var parent = (GIBase)member.ParentNode;
                        builder.Replace(c.Value, $"<see cref=\"{parent.ManagedName}.{member.ManagedName}\"/>");
                    }

                    var typeRefs = Regex.Matches(text, "#" + prefix + @"\w+");
                    foreach (Match t in typeRefs.OrderByDescending(x => x.Value.Length)) {
                        var type = ns.AllTypes
                            .SingleOrDefault(x => ((x as GIRegisteredType)?.CType ?? (x as Callback)?.CType) == t.Value.Substring(1));
                        if (type == null) {
                            continue;
                        }
                        builder.Replace(t.Value, $"<see cref=\"{type.ManagedName}\"/>");
                    }
                }

                // anything that starts with an "@" is probably a paramref
                var paramRefs = Regex.Matches(text, @"@\w+");
                foreach (Match p in paramRefs.OrderByDescending(x => x.Value.Length)) {
                    // if this is an instance parameter, replace it with "this instance'
                    var callable = doc.Ancestors.OfType<GICallable>().SingleOrDefault();
                    if (callable == null) {
                        var property = doc.Ancestors.OfType<ManagedProperty>().SingleOrDefault();
                        if (property != null) {
                            callable = property.Getter;
                        }
                    }
                    if (callable != null) {
                        var instanceParam = callable.Parameters.InstanceParameter;
                        if (instanceParam != null) {
                            builder.Replace(p.Value, $"this instance");
                            continue;
                        }
                    }
                    // otherwise replace it with a paramref element
                    // TODO: can probably do a better job of detecting @ ref
                    // to fields/virtual methods and signal callback parameters
                    // (EventArgs)
                    var name = p.Value.Substring(1).ToCamelCase();
                    builder.Replace(p.Value, $"<paramref name=\"{name}\"/>");
                }

                // find all references to functions/methods in this namespace
                // These references look like "prefix_name()"
                foreach (var prefix in ns.CSymbolPrefixes) {
                    var funcs = Regex.Matches(text, prefix + @"_\w+(?=\(\))");
                    foreach (Match f in funcs) {
                        var callable = (GICallable)ns.FindNodeByCIdentifier(f.Value);
                        if (callable == null) {
                            continue;
                        }
                        var parent = (GIBase)callable.ParentNode;
                        var method = callable.ManagedName;
                        if (callable is Constructor) {
                            // constructors are special
                            method = "#ctor";
                        }
                        // include parameter types so we don't get conflicts with overloads
                        method += $"({string.Join(",", callable.ManagedParameters.Select(x => x.Type.ManagedType))})";
                        builder.Replace($"{f.Value}()", $"<see cref=\"M:{parent.GirName}.{method}\"/>");
                    }
                }
            }

            var trivia = ParseLeadingTrivia(builder.ToString());
            return trivia;
        }
    }
}
