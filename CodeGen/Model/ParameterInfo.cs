using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GISharp.CodeGen.Model
{
    public class ParameterInfo : BaseInfo
    {
        readonly bool managed;

        /// <summary>
        /// Gets a value indicating whether this instance is an "in" or "inout" parameter.
        /// </summary>
        /// <value><c>true</c> if this instance is an "in" or "inout" parameter; otherwise, <c>false</c>.</value>
        public bool IsInParam {
            get {
                var defaultDirection = IsReturnParameter ? "out" : "in";
                return Element.Attribute ("direction").AsString (defaultDirection) != "out"
                    || Element.Attribute ("caller-allocates").AsBool ();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is an "out" or "inout" parameter.
        /// </summary>
        /// <value><c>true</c> if this instance is an "out" or "inout" parameter; otherwise, <c>false</c>.</value>
        public bool IsOutParam {
            get {
                var defaultDirection = IsReturnParameter ? "out" : "in";
                return Element.Attribute ("direction").AsString (defaultDirection) != "in";
            }
        }

        public Transfer Transfer {
            get {
                var transfer = Element.Attribute ("transfer-ownership").Value;
                switch (transfer) {
                case "none":
                case "floating":
                    return Transfer.None;
                case "container":
                    return Transfer.Container;
                case "full":
                    return Transfer.All;
                }
                var message = string.Format ("Unknown trasfer type '{0}'.", transfer);
                throw new NotSupportedException (message);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="GISharp.CodeGen.Model.ParameterInfo"/> needs a null check.
        /// </summary>
        /// <value><c>true</c> if needs a null check; otherwise, <c>false</c>.</value>
        public bool NeedsNullCheck {
            get {
                if (IsOutParam) {
                    return false;
                }
                if (TypeInfo.TypeObject.IsValueType) {
                    return false;
                }
                if (Element.Attribute ("nullable").AsBool ()) {
                    return false;
                }
                // TODO: Do we also need to check for the obsolete "allow-none"?
                return true;
            }
        }

        public bool IsReturnParameter {
            get {
                return Element.Name == gi + "return-value";
            }
        }

        public bool IsInstanceParameter {
            get {
                return Element.Name == gi + "instance-parameter";
            }
        }

        public bool IsErrorParameter {
            get {
                return Element.Name == gs + "error-parameter";
            }
        }

        /// <summary>
        /// Gets the index of the user data for a closure parameter.
        /// </summary>
        /// <value>The index of the user data or -1 if this is not a closure parameter.</value>
        public int ClosureIndex {
            get {
                if (managed) {
                    throw new NotSupportedException ();
                }
                return Element.GetClosureIndex (countInstanceParameter: true);
            }
        }

        /// <summary>
        /// Gets the index of the destory notify function for a parameter.
        /// </summary>
        /// <value>The index of the destory notify function or -1 if this is not a destory parameter.</value>
        public int DestoryIndex {
            get {
                if (managed) {
                    throw new NotSupportedException ();
                }
                return Element.GetDestroyIndex (countInstanceParameter: true);
            }
        }

        TypeInfo _TypeInfo;
        public TypeInfo TypeInfo {
            get {
                if (_TypeInfo == null) {
                    _TypeInfo = new TypeInfo (Element, managed);
                }
                return _TypeInfo;
            }
        }

        SyntaxToken _Identifier;
        public SyntaxToken Identifier {
            get {
                if (_Identifier == default(SyntaxToken)) {
                    _Identifier = SyntaxFactory.Identifier (ManagedName);
                }
                return _Identifier;
            }
        }

        ParameterSyntax _Parameter;
        public ParameterSyntax Parameter {
            get {
                if (_Parameter == default(ParameterSyntax)) {
                    _Parameter = SyntaxFactory.Parameter (Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithType (TypeInfo.Type).WithLeadingTrivia (
                            // put each parameter on a new line for better readability since we are using full type names
                            SyntaxFactory.EndOfLine("\n"),
                            SyntaxFactory.Whitespace ("\t"))
                        .WithTrailingTrivia (AnnotationTriviaList);
                    if (managed && HasDefault) {
                        var @default = SyntaxFactory.EqualsValueClause (Default);
                        _Parameter = _Parameter.WithDefault (@default);
                    }
                }
                return _Parameter;
            }
        }

        SyntaxTokenList _Modifiers;
        public SyntaxTokenList Modifiers {
            get {
                if (_Modifiers == default(SyntaxTokenList)) {
                    _Modifiers = SyntaxFactory.TokenList (GetModifiers ());
                }
                return _Modifiers;
            }
        }

        public bool HasDefault {
            get {
                return Element.Attribute (gs + "default") != null;
            }
        }

        ExpressionSyntax _Default;
        public ExpressionSyntax Default {
            get {
                if (_Default == default(ExpressionSyntax)) {
                    _Default = SyntaxFactory.ParseExpression (Element.Attribute (gs + "default")?.Value);
                }
                return _Default;
            }
        }

        SyntaxTriviaList _AnnotationTriviaList;
        public SyntaxTriviaList AnnotationTriviaList {
            get {
                if (_AnnotationTriviaList == default(SyntaxTriviaList)) {
                    _AnnotationTriviaList = SyntaxFactory.TriviaList (GetAnnotationTrivias ());
                }
                return _AnnotationTriviaList;
            }
        }

        public ParameterInfo (XElement element, MemberInfo declaringMember, bool managed)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "parameter" && element.Name != gi + "instance-parameter" && element.Name != gs + "error-parameter" && element.Name != gi + "return-value") {
                throw new ArgumentException ("Requires <parameter>, <instance-parameter>, <error-parameter> or <return-value> element.", nameof(element));
            }
            this.managed = managed;
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            return base.GetAttributeLists ().Union (TypeInfo.AttributeLists);
        }

        protected virtual IEnumerable<SyntaxToken> GetModifiers ()
        {
            if (!IsReturnParameter) {
                if (IsInParam && IsOutParam) {
                    yield return SyntaxFactory.Token (SyntaxKind.RefKeyword);
                } else if (IsOutParam) {
                    yield return SyntaxFactory.Token (SyntaxKind.OutKeyword);
                }
            }
        }

        protected override SyntaxTriviaList GetDocumentationCommentTriviaList ()
        {
            var builder = new StringBuilder ();
            var docElement = Element.Element (gi + "doc");
            if (docElement != null) {
                string line;
                using (var reader = new StringReader (docElement.Value)) {
                    if (IsReturnParameter) {
                        builder.AppendLine ("/// <returns>");
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </returns>");
                    } else {
                        builder.AppendFormat ("/// <param name=\"{0}\">", ManagedName.Replace ("@", ""));
                        builder.AppendLine ();
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </param>");
                    }
                }
            }

            return SyntaxFactory.ParseLeadingTrivia (builder.ToString ());
        }

        SyntaxTriviaList GetAnnotationTrivias ()
        {
            // only add comments to pinvoke parameters
            if (managed) {
                return default(SyntaxTriviaList);
            }
            var builder = new StringBuilder ();
            builder.Append (" /* ");
            var attrs = Element.Attributes ()
                .Where (x => x.Name.Namespace != gs && x.Name != "name");
            foreach (var attr in attrs) {
                builder.AppendFormat ("{0}:{1} ", attr.Name.LocalName, attr.Value);
            }
            builder.Append ("*/");
            return SyntaxFactory.ParseTrailingTrivia (builder.ToString ());
        }
    }
}
