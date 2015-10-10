﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

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

        public bool IsParams {
            get {
                return managed && Element.Attribute (gs + "params").AsBool ();
            }
        }

        public GISharp.Core.Transfer Transfer {
            get {
                var defaultTransfer = default(string);
                if (IsOutParam || IsReturnParameter || TypeInfo.Classification == TypeClassification.GObject) {
                    defaultTransfer = "full";
                } else if (TypeInfo.Classification == TypeClassification.Utf8String) {
                    var cType = Element.Element (gi + "type").Attribute (c + "type").Value;
                    if (cType == "gchar*") {
                        defaultTransfer = "full";
                    } else if (cType == "const gchar*") {
                        defaultTransfer = "none";
                    }
                }
                var transfer = Element.Attribute ("transfer-ownership").AsString (defaultTransfer);
                switch (transfer) {
                case "none":
                case "floating":
                    return GISharp.Core.Transfer.None;
                case "container":
                    return GISharp.Core.Transfer.Container;
                case "full":
                    return GISharp.Core.Transfer.All;
                }
                var message = string.Format ("Unknown trasfer type '{0}'.", transfer);
                throw new NotSupportedException (message);
            }
        }

        public ParameterScope Scope {
            get {
                if (TypeInfo.Classification != Model.TypeClassification.Delegate) {
                    throw new InvalidOperationException ("Scope only applies to callbacks.");
                }

                var scope = Element.Attribute ("scope").AsString ("call");
                switch (scope) {
                case "call":
                    return Model.ParameterScope.Call;
                case "async":
                    return Model.ParameterScope.Async;
                case "notified":
                    return Model.ParameterScope.Notified;
                default:
                    var message = string.Format ("Unknown scope: {0}", scope);
                    throw new NotSupportedException (message);
                }
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

        SyntaxToken? _Identifier;
        public SyntaxToken Identifier {
            get {
                if (!_Identifier.HasValue) {
                    _Identifier = Identifier (ManagedName);
                }
                return _Identifier.Value;
            }
        }

        ParameterSyntax _Parameter;
        public ParameterSyntax Parameter {
            get {
                if (_Parameter == null) {
                    _Parameter = Parameter (Identifier)
                        .WithAttributeLists (AttributeLists)
                        .WithModifiers (Modifiers)
                        .WithType (TypeInfo.Type);
                    if (managed && HasDefault) {
                        var @default = EqualsValueClause (Default);
                        _Parameter = _Parameter.WithDefault (@default);
                    }
                }
                return _Parameter;
            }
        }

        SyntaxTokenList? _Modifiers;
        public SyntaxTokenList Modifiers {
            get {
                if (!_Modifiers.HasValue) {
                    _Modifiers = TokenList (GetModifiers ());
                }
                return _Modifiers.Value;
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
                if (_Default == null) {
                    _Default = ParseExpression (Element.Attribute (gs + "default")?.Value);
                }
                return _Default;
            }
        }

        SyntaxTrivia? _AnnotationTrivia;
        public SyntaxTrivia AnnotationTrivia {
            get {
                if (!_AnnotationTrivia.HasValue) {
                    _AnnotationTrivia = GetAnnotationTrivia ();
                }
                return _AnnotationTrivia.Value;
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
                    yield return Token (SyntaxKind.RefKeyword);
                } else if (IsOutParam) {
                    yield return Token (SyntaxKind.OutKeyword);
                } else if (IsParams) {
                    yield return Token (SyntaxKind.ParamsKeyword);
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

            return ParseLeadingTrivia (builder.ToString ());
        }

        SyntaxTrivia GetAnnotationTrivia ()
        {
            var builder = new StringBuilder ();
            builder.Append ("/* ");
            var attrs = Element.Attributes ()
                .Where (x => x.Name.Namespace != gs && x.Name != "name");
            foreach (var attr in attrs) {
                builder.AppendFormat ("{0}:{1} ", attr.Name.LocalName, attr.Value);
            }
            builder.Append ("*/");
            return Comment (builder.ToString ());
        }
    }

    /// <summary>
    /// Parameter scope indicates how long a parameter must be kept alive.
    /// </summary>
    public enum ParameterScope
    {
        /// <summary>
        /// Only valid for the duration of the call.
        /// </summary>
        /// <remarks>>
        /// Can be called multiple times during the call.
        /// </remarks>
        Call,
        /// <summary>
        /// Only valid for the duration of the first callback invocation. Can only be called once. 
        /// </summary>
        Async,
        /// <summary>
        /// valid until the GDestroyNotify argument is called. Can be called multiple times before the GDestroyNotify is called. 
        /// </summary>
        Notified,
    }
}
