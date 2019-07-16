
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    /// <summary>
    /// Common base class for all GIR element types
    /// </summary>
    public abstract class GirNode
    {
        // Analysis disable InconsistentNaming
        private protected static readonly XNamespace gi = Globals.CoreNamespace;
        private protected static readonly XNamespace c = Globals.CNamespace;
        private protected static readonly XNamespace glib = Globals.GLibNamespace;
        private protected static readonly XNamespace gs = Globals.GISharpNamespace;
        // Analysis restore InconsistentNaming

        /// <summary>
        /// The XML element from the GIR file
        /// </summary>
        public XElement Element { get; }

        /// <summary>
        /// The parent node
        /// </summary>
        public GirNode ParentNode { get; }

        /// <summary>
        /// Gets the ancestors of this node, starting with the parent
        /// </summary>
        public IEnumerable<GirNode> Ancestors => _Ancestors.Value;
        readonly Lazy<List<GirNode>> _Ancestors;

        /// <summary>
        /// The documentation node, if any
        /// </summary>
        public Doc Doc => _Doc.Value;
        readonly Lazy<Doc> _Doc;

        protected GirNode(XElement element, GirNode parent)
        {
            Element = element ?? throw new ArgumentNullException(nameof(element));
            ParentNode = parent;
            _Ancestors = new Lazy<List<GirNode>>(() => LazyGetAncestors().ToList());
            _Doc = new Lazy<Doc>(LazyGetDoc, false);
            element.AddAnnotation(this);
        }

        public static GirNode GetNode(XElement element)
        {
            if (element == null) {
                return null;
            }

            // if this element already has a node object attached, use it
            var node = element.Annotation<GirNode>();
            if (node != null) {
                return node;
            }

            // otherwise, create a new node based on the element name
            if (element.Name == gi + "alias") {
                return new Alias(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "array") {
                return new Array(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "bitfield") {
                return new Bitfield(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "callback") {
                return new Callback(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "class") {
                return new Class(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "constant") {
                return new Constant(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "constructor") {
                return new Constructor(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "doc") {
                return new Doc(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "doc-deprecated") {
                return new DocDeprecated(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "enumeration") {
                return new Enumeration(element, GetNode(element.Parent));
            }
            else if (element.Name == gs + "error-parameter") {
                return new ErrorParameter(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "field") {
                return new Field(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "function") {
                return new Function(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "instance-parameter") {
                return new InstanceParameter(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "interface") {
                return new Interface(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "implements") {
                return new Implements(element, GetNode(element.Parent));
            }
            else if (element.Name == gs + "managed-property") {
                return new ManagedProperty(element, GetNode(element.Parent));
            }
            else if (element.Name == gs + "managed-parameters") {
                return new ManagedParameters(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "member") {
                return new Member(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "method") {
                return new Method(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "namespace") {
                return new Namespace(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "package") {
                return new Package(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "parameter") {
                return new Parameter(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "parameters") {
                return new Parameters(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "prerequisite") {
                return new Prerequisite(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "property") {
                return new Property(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "record") {
                return new Record(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "return-value") {
                return new ReturnValue(element, GetNode(element.Parent));
            }
            else if (element.Name == glib + "signal") {
                return new Signal(element, GetNode(element.Parent));
            }
            else if (element.Name == gs + "static-class") {
                return new StaticClass(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "type") {
                return new Type(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "union") {
                return new Union(element, GetNode(element.Parent));
            }
            else if (element.Name == gi + "virtual-method") {
                return new VirtualMethod(element, GetNode(element.Parent));
            }

            var message = $"Unknown element <{element.Name}>";
            throw new ArgumentException(message, nameof(element));
        }

        IEnumerable<GirNode> LazyGetAncestors()
        {
            var node = this;
            while ((node = node.ParentNode) != null) {
                yield return node;
            }
        }

        Doc LazyGetDoc() => (Doc)GetNode(Element.Element(gi + "doc"));
    }
}
