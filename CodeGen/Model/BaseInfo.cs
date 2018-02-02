using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    /// <summary>
    /// Base class for wrapping xml elements from a fixed up .gir file.
    /// </summary>
    public abstract class BaseInfo
    {
        // Analysis disable InconsistentNaming
        protected static readonly XNamespace gi = Globals.CoreNamespace;
        protected static readonly XNamespace c = Globals.CNamespace;
        protected static readonly XNamespace glib = Globals.GLibNamespace;
        protected static readonly XNamespace gs = Globals.GISharpNamespace;
        // Analysis restore InconsistentNaming

        /// <summary>
        /// The GIR XML element.
        /// </summary>
        protected readonly XElement Element;

        /// <summary>
        /// Gets the "name" attribute of <see cref="Element"/>.
        /// </summary>
        public string GirName {
            get { return Element.Attribute("name").Value; }
        }

        /// <summary>
        /// Gets the "gs:managed-name" attribute of <see cref="Element"/>.
        /// </summary>
        public virtual string ManagedName {
            get { return Element.Attribute(gs + "managed-name").Value; }
        }

        /// <summary>
        /// Gets the namespace info associated with this item.
        /// </summary>
        public NamespaceInfo NamespaceInfo => _NamespaceInfo.Value;
        readonly Lazy<NamespaceInfo> _NamespaceInfo;

        /// <summary>
        /// Gets the parent member info that declares this item.
        /// </summary>
        /// <value>The declaring member or <c>null</c> if this is a top level element.</value>
        public MemberInfo DeclaringMember { get; }

        /// <summary>
        /// Gets the custom attribute syntax for this item.
        /// </summary>
        /// <value>The attribute lists.</value>
        /// <remarks>
        /// Implementing members can modify this value by overriding <see cref="GetAttributeLists"/>.
        /// </remarks>
        public SyntaxList<AttributeListSyntax> AttributeLists => _AttributeLists.Value;
        readonly Lazy<SyntaxList<AttributeListSyntax>> _AttributeLists;

        /// <summary>
        /// Gets the documentation comment syntax for this item.
        /// </summary>
        /// <value>The documentation comment trivia list.</value>
        /// <remarks>
        /// Implementing members can modify this value by overriding
        /// <see cref="GetDocumentationCommentTriviaList"/>.
        /// </remarks>
        public SyntaxTriviaList DocumentationCommentTriviaList => _DocumentationCommentTriviaList.Value;
        readonly Lazy<SyntaxTriviaList> _DocumentationCommentTriviaList;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GISharp.CodeGen.Model.BaseInfo"/> class.
        /// </summary>
        /// <param name="element">The xml element from the fixed up .gir file.</param>
        /// <param name="declaringMember">The parent member info on <c>null</c>
        /// if this is a top level element.</param>
        protected BaseInfo (XElement element, MemberInfo declaringMember)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            Element = element;
            DeclaringMember = declaringMember;

            _NamespaceInfo = new Lazy<NamespaceInfo>(GetNamespaceInfo);
            _AttributeLists = new Lazy<SyntaxList<AttributeListSyntax>>(() => List<AttributeListSyntax>(GetAttributeLists()));
            _DocumentationCommentTriviaList = new Lazy<SyntaxTriviaList>(GetDocumentationCommentTriviaList);
        }

        NamespaceInfo GetNamespaceInfo()
        {
            MemberInfo info = DeclaringMember;
            while (info != null) {
                var namespaceInfo = info as NamespaceInfo;
                if (namespaceInfo != null) {
                    return namespaceInfo;
                }
                info = info.DeclaringMember;
            }
            throw new InvalidOperationException("Missing NamespaceInfo ancestor");
        }

        internal abstract IEnumerable<BaseInfo> GetChildInfos ();

        internal BaseInfo InternalFindInfo (XElement element)
        {
            if (element == Element) {
                element.AddAnnotation (this);
                return this;
            }
            foreach (var child in GetChildInfos ()) {
                var info = child.InternalFindInfo (element);
                if (info != null) {
                    return info;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the attribute lists for this item.
        /// </summary>
        /// <returns>The attribute lists.</returns>
        /// <remarks>
        /// Overriding methods should return the values from the base method
        /// in addition to adding new attributes.
        /// </remarks>
        protected virtual IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            // Translate GIR "deprecated" annotation to .NET ObsoleteAttribute
            // and possibly a GISharp DeprecatedSinceAttribute

            if (Element.Attribute ("deprecated").AsBool ()) {
                var obsoleteAttribute = Attribute (ParseName (typeof(ObsoleteAttribute).FullName));

                // if there is a "doc-deprecated" annotation, use it as the
                // message parameter of ObsoleteAttribute

                var docDeprecated = Element.Element (gi + "doc-deprecated");
                if (docDeprecated != null) {
                    obsoleteAttribute = obsoleteAttribute.AddArgumentListArguments (
                        AttributeArgument (
                            LiteralExpression (SyntaxKind.StringLiteralExpression,
                                Literal (docDeprecated.Value))));
                }

                yield return AttributeList ().AddAttributes (obsoleteAttribute);

                // translate the "deprecated-version" annotation to a DeprecatedSinceAttribute

                var deprecatedVersion = Element.Attribute ("deprecated-version");
                if (deprecatedVersion != null) {
                    var deprecatedAttribute = Attribute(ParseName(typeof(GISharp.Runtime.DeprecatedSinceAttribute).FullName));
                    deprecatedAttribute = deprecatedAttribute.AddArgumentListArguments (
                        AttributeArgument (
                            LiteralExpression (SyntaxKind.StringLiteralExpression,
                                Literal (deprecatedVersion.Value))));
                    yield return AttributeList().AddAttributes(deprecatedAttribute);
                }
            }

            // If there is a "version" GIR annotation, convert it to a GISharp SinceAttribute

            if (Element.Attribute ("version") != null) {
                var sinceAttributeName = ParseName (typeof(GISharp.Runtime.SinceAttribute).FullName);
                var sinceAttribute = Attribute (sinceAttributeName)
                    .WithArgumentList (AttributeArgumentList ()
                        .AddArguments (AttributeArgument (
                            LiteralExpression (SyntaxKind.StringLiteralExpression,
                                Literal (Element.Attribute ("version").Value)))));

                yield return AttributeList ().AddAttributes (sinceAttribute);
            }
        }

        /// <summary>
        /// Gets the documentation comment trivia list for this item.
        /// </summary>
        /// <returns>The documentation comment trivia list.</returns>
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
            var trivia = ParseLeadingTrivia (builder.ToString ());
            return trivia;
        }
    }
}
