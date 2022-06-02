// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

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
            if (doc is null) {
                return default;
            }

            var builder = new StringBuilder();
            string line;

            using (var reader = new StringReader(doc.Text)) {
                if (doc.ParentNode is ReturnValue) {
                    builder.AppendLine("/// <returns>");
                    while ((line = reader.ReadLine()) is not null) {
                        builder.AppendFormat("/// {0}", new XText(line));
                        builder.AppendLine();
                    }
                    builder.AppendLine("/// </returns>");
                }
                else if (doc.ParentNode is GIArg arg) {
                    builder.AppendFormat("/// <param name=\"{0}\">", arg.ManagedName.Replace("@", ""));
                    builder.AppendLine();
                    while ((line = reader.ReadLine()) is not null) {
                        builder.AppendFormat("/// {0}", new XText(line));
                        builder.AppendLine();
                    }
                    builder.AppendLine("/// </param>");
                }
                else {
                    builder.AppendLine("/// <summary>");
                    while ((line = reader.ReadLine()) is not null) {
                        // summary is only the first paragraph
                        if (string.IsNullOrWhiteSpace(line)) {
                            break;
                        }
                        builder.AppendFormat("/// {0}", new XText(line));
                        builder.AppendLine();
                    }
                    builder.AppendLine("/// </summary>");
                    if (line is not null) {
                        // if there are more lines, they go in the remarks
                        builder.AppendLine("/// <remarks>");
                        builder.AppendLine("/// <para>");
                        while ((line = reader.ReadLine()) is not null) {
                            if (string.IsNullOrEmpty(line)) {
                                builder.AppendLine("/// </para>");
                                builder.AppendLine("/// <para>");
                            }
                            else {
                                builder.AppendFormat("/// {0}", new XText(line));
                                builder.AppendLine();
                            }
                        }
                        builder.AppendLine("/// </para>");
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
                    var constants = Regex.Matches(text, @$"%{prefix.ToUpperInvariant()}_\w+");
                    foreach (Match c in constants.OrderByDescending(x => x.Value.Length)) {
                        var member = (GIBase)ns.FindNodeByCIdentifier(c.Value[1..]);
                        if (member is null) {
                            continue;
                        }
                        var parent = (GIBase)member.ParentNode;
                        builder.Replace(c.Value, $"<see cref=\"{parent.ManagedName}.{member.ManagedName}\"/>");
                    }

                    var typeRefs = Regex.Matches(text, "#" + prefix + @"\w+");
                    foreach (Match t in typeRefs.OrderByDescending(x => x.Value.Length)) {
                        var type = ns.AllTypes
                            .SingleOrDefault(x => ((x as GIRegisteredType)?.CType ?? (x as Callback)?.CType) == t.Value[1..]);
                        if (type is null) {
                            continue;
                        }
                        builder.Replace(t.Value, $"<see cref=\"{type.ManagedName}\"/>");
                    }
                }

                // anything that starts with an "@" is probably a paramref
                var paramRefs = Regex.Matches(text, @"@\w+");
                foreach (Match p in paramRefs.OrderByDescending(x => x.Value.Length)) {
                    var callable = doc.Ancestors.OfType<GICallable>().SingleOrDefault();
                    if (callable is null) {
                        var property = doc.Ancestors.OfType<ManagedProperty>().SingleOrDefault();
                        if (property is not null) {
                            callable = property.Getter;
                        }
                    }
                    if (callable is not null) {
                        // if this is an instance parameter, replace it with "this instance'
                        var instanceParam = callable.Parameters.InstanceParameter;
                        if (instanceParam?.GirName == p.Value[1..] && !(callable is Method m && m.IsExtensionMethod)) {
                            builder.Replace(p.Value, $"this instance");
                            continue;
                        }

                        // if this is an error parameter, cref GError exception instead
                        var errorParam = callable.Parameters.ErrorParameter;
                        if (errorParam?.GirName == p.Value[1..]) {
                            builder.Replace(p.Value, "<see cref=\"GISharp.Lib.GLib.Error.Exception\"/>");
                            continue;
                        }

                        // if this is an array length parameter
                        foreach (var (arrayArg, type) in callable.Parameters.Select(x => (x, x.Type as Array)).Where(x => x.Item2?.LengthIndex >= 0)) {
                            if (callable.Parameters.RegularParameters.ElementAt(type.LengthIndex).GirName == p.Value[1..]) {
                                builder.Replace(p.Value, $"the length of <paramref name=\"{arrayArg.ManagedName}\"/>");
                                continue;
                            }
                        }

                        // this is a regular parameter
                        if (callable.Parameters.SingleOrDefault(x => x.GirName == p.Value[1..]) is GIArg arg) {
                            builder.Replace(p.Value, $"<paramref name=\"{arg.ManagedName.Replace("@", "")}\"/>");
                            continue;
                        }
                    }

                    if (doc.ParentNode is GIRegisteredType declaringType) {
                        if (declaringType.Fields.SingleOrDefault(x => x.GirName == p.Value[1..]) is Field field) {
                            builder.Replace(p.Value, $"<see cref=\"{field.ManagedName}\"/>");
                            continue;
                        }

                        // virtual methods are declared in the GType struct for a type
                        if (declaringType.GTypeStruct is not null && declaringType.ParentNode is Namespace @namespace) {
                            var gtype = @namespace.Records.Single(x => x is GIRegisteredType t && t.GirName == declaringType.GTypeStruct) as GIRegisteredType;
                            if (gtype.Fields.SingleOrDefault(x => x.GirName == p.Value[1..]) is Field gtypeField) {
                                builder.Replace(p.Value, $"<see cref=\"Do{gtypeField.ManagedName}\"/>");
                                continue;
                            }
                        }

                        builder.Replace(p.Value, $"<c>{p.Value[1..].ToCamelCase()}</c>");
                        continue;
                    }

                    // not sure what this is. probably a reference to a parameter
                    // elsewhere. just use code formatting for now
                    builder.Replace(p.Value, $"<c>{p.Value[1..].ToCamelCase()}</c>");
                }

                // find all references to functions/methods in this namespace
                // These references look like "prefix_name()"
                foreach (var prefix in ns.CSymbolPrefixes) {
                    var functions = Regex.Matches(text, prefix + @"_\w+(?=\(\))");
                    
                    foreach (var f in functions.Cast<Match>()) {
                        var callable = (GICallable)ns.FindNodeByCIdentifier(f.Value);
                        if (callable is null) {
                            continue;
                        }
                        if (callable.ParentNode is not GIBase parent) {
                            continue;
                        }
                        var method = callable.ManagedName;
                        if (callable is Constructor) {
                            // constructors are special
                            method = parent.GirName;
                        }
                        static string getManagedType(GIArg arg)
                        {
                            var type = arg.GetSpecializedManagedType();

                            var result = type.ToString();

                            // see rules at https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format
                            // Roslyn compiler doesn't seem to follow these rules
                            if (arg.Direction == "out" && !arg.IsCallerAllocatesBuffer()) {
                                result = "out " + result;
                            }
                            if (arg.Direction == "inout") {
                                result = "ref " + result;
                            }
                            if (arg.Direction == "in" && arg.IsByRefValueType()) {
                                if (arg.Type.CType.Contains("const")) {
                                    result = "in " + result;
                                }
                                else {
                                    result = "ref " + result;
                                }
                            }
                            // fix generics
                            result = result.Replace("<", "{").Replace(">", "}");
                            return result;
                        }
                        // include parameter types so we don't get conflicts with overloads
                        var parameters = callable.ManagedParameters.RegularParameters.Cast<GIArg>();
                        // extension methods need instance parameter
                        if (callable is Method m && m.IsExtensionMethod) {
                            parameters = parameters.Prepend(callable.ManagedParameters.ThisParameter);
                        }
                        method += $"({string.Join(",", parameters.Select(x => getManagedType(x)))})";
                        builder.Replace($"{f.Value}()", $"<see cref=\"{parent.GirName}.{method}\"/>");
                    }
                }
            }

            var trivia = ParseLeadingTrivia(builder.ToString());
            return trivia;
        }
    }
}
