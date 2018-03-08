using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        /// <returns>The documentation comment trivia list.</returns>
        public static SyntaxTriviaList GetDocCommentTrivia(this Doc doc)
        {
            if (doc == null) {
                return default(SyntaxTriviaList);
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

            var trivia = ParseLeadingTrivia(builder.ToString());
            return trivia;
        }
    }
}
