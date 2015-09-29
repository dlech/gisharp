using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GISharp.CodeGen.Model
{
    public abstract class BaseInfo
    {
        // Analysis disable InconsistentNaming
        protected static readonly XNamespace gi = Globals.CoreNamespace;
        protected static readonly XNamespace c = Globals.CNamespace;
        protected static readonly XNamespace glib = Globals.GLibNamespace;
        protected static readonly XNamespace gs = Globals.GISharpNamespace;
        // Analysis restore InconsistentNaming

        protected readonly XElement Element;

        public string GirName {
            get { return Element.Attribute ("name").Value; }
        }

        public virtual string ManagedName {
            get { return Element.Attribute (gs + "managed-name").Value; }
        }

        public MemberInfo DeclaringMember { get; private set; }

        SyntaxList<AttributeListSyntax> _AttributeLists;
        public SyntaxList<AttributeListSyntax> AttributeLists {
            get {
                if (_AttributeLists == default(SyntaxList<AttributeListSyntax>)) {
                    _AttributeLists = SyntaxFactory.List<AttributeListSyntax> ()
                        .AddRange (GetAttributeLists ());
                }
                return _AttributeLists;
            }
        }

        SyntaxTriviaList _DocumentationCommentTriviaList;
        public SyntaxTriviaList DocumentationCommentTriviaList {
            get {
                if (_DocumentationCommentTriviaList == default(SyntaxTriviaList)) {
                    _DocumentationCommentTriviaList = GetDocumentationCommentTriviaList ();
                }
                return _DocumentationCommentTriviaList;
            }
        }

        protected BaseInfo (XElement element, MemberInfo declaringMember)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            this.Element = element;
            DeclaringMember = declaringMember;
        }

        protected virtual IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            if (Element.Attribute ("deprecated").AsBool ()) {
                var obsoleteAttribute = SyntaxFactory.Attribute (SyntaxFactory.ParseName (typeof(ObsoleteAttribute).FullName));

                var message = new StringBuilder ();
                var docDeprecated = Element.Element (gi + "doc-deprecated");
                if (docDeprecated != null) {
                    message.Append (docDeprecated.Value);
                }
                var deprecatedSince = Element.Attribute ("deprecated-since");
                if (deprecatedSince != null) {
                    if (message.Length > 0) {
                        message.Append (" ");
                    }
                    message.Append (deprecatedSince.Value);
                }
                if (message.Length > 0) {
                    obsoleteAttribute = obsoleteAttribute.AddArgumentListArguments (
                        SyntaxFactory.AttributeArgument (
                            SyntaxFactory.LiteralExpression (SyntaxKind.StringLiteralExpression,
                                SyntaxFactory.Literal (message.ToString ()))));
                }

                yield return SyntaxFactory.AttributeList ().AddAttributes (obsoleteAttribute);
            }

            if (Element.Attribute ("version") != null) {
                var sinceAttributeName = SyntaxFactory.ParseName (typeof(GISharp.Core.SinceAttribute).FullName);
                var sinceAttribute = SyntaxFactory.Attribute (sinceAttributeName)
                    .WithArgumentList (SyntaxFactory.AttributeArgumentList ()
                        .AddArguments (SyntaxFactory.AttributeArgument (
                            SyntaxFactory.LiteralExpression (SyntaxKind.StringLiteralExpression,
                                SyntaxFactory.Literal (Element.Attribute ("version").Value)))));

                yield return SyntaxFactory.AttributeList ().AddAttributes (sinceAttribute);
            }
        }

        protected virtual SyntaxTriviaList GetDocumentationCommentTriviaList ()
        {
            var builder = new StringBuilder ();
            string line;
            if (Element.Element (gi + "doc") != null) {
                using (var reader = new StringReader (Element.Element (gi + "doc").Value)) {
                    builder.AppendLine ("/// <summary>");
                    while ((line = reader.ReadLine ()) != null) {
                        // summary is only the first paragraph
                        if (string.IsNullOrWhiteSpace (line)) {
                            break;
                        }
                        builder.AppendFormat ("/// {0}", new XText (line));
                        builder.AppendLine ();
                    }
                    builder.AppendLine ("/// </summary>");
                    if (line != null) {
                        // if there are more lines, they go in the remarks
                        builder.AppendLine ("/// <remarks>");
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </remarks>");
                    }
                }
            }
            var trivia = SyntaxFactory.ParseLeadingTrivia (builder.ToString ());
            return trivia;
        }
    }
}
