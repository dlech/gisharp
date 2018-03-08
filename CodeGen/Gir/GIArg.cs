using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    /// <summary>
    /// Common base class for all parameter types
    /// </summary>
    public abstract class GIArg : GIBase
    {
        /// <summary>
        /// Gets the ownership transfer of this parameter
        /// </summary>
        public Transfer Ownership { get; }

        /// <summary>
        /// Gets the direction of this parameter
        /// </summary>
        public GIDirection Direction { get; }

        /// <summary>
        /// Gets if this parameter is allocated by the caller (for out parameters)
        /// </summary>
        public bool IsCallerAllocates { get; }

        /// <summary>
        /// Gets if this parameter is a callback
        /// </summary>
        public bool IsCallback { get; }

        /// <summary>
        /// Gets the callback of this parameter
        /// </summary>
        public CallbackScope Scope { get; }

        /// <summary>
        /// Gets the index of the user data parameter or -1 if none
        /// </summary>
        public int ClosureIndex { get; }

        /// <summary>
        /// Gets the index of the destroy notify parameter or -1 if none
        /// </summary>
        public int DestroyIndex { get; }

        /// <summary>
        /// Gets if this parameter can be null
        /// </summary>
        public bool IsNullable { get; }

        /// <summary>
        /// Gets if this parameter is optional
        /// </summary>
        public bool IsOptional { get; }

        /// <summary>
        /// Gets if this parameter should be skipped
        /// </summary>
        public bool IsSkip { get; }

        /// <summary>
        /// Gets if this parameter is a C# params argument
        /// </summary>
        public bool IsParams { get; }

        /// <summary>
        /// Gets the default value for this parameter, if any
        /// </summary>
        public string DefaultValue { get; }

        /// <summary>
        /// Gets the GIR type for this parameter
        /// </summary>
        public GIType GirType => _GirType.Value;
        readonly Lazy<GIType> _GirType;

        /// <summary>
        /// Gets the callable that declared this arg
        /// </summary>
        public GICallable Callable => _Callable.Value;
        readonly Lazy<GICallable> _Callable;


        private protected GIArg(XElement element, GirNode parent)
            : base (element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            var isReturnValue = element.Name == gi + "return-value";
            // TODO: setting the default value if none should really be done in Fixup
            var defaultDirection = isReturnValue ? "out" : "in";
            var direction = element.Attribute("direction").AsString(defaultDirection);
            var defaultTransfer = (isReturnValue || direction != "in") ? "full" : "none";

            Ownership = Element.Attribute("transfer-ownership").AsTransfer(defaultTransfer);
            Direction = Element.Attribute("direction").AsDirection(defaultDirection);
            IsCallerAllocates = Element.Attribute("caller-allocates").AsBool();
            IsCallback = Element.Attribute("scope") != null;
            Scope = Element.Attribute("scope").AsScope();
            ClosureIndex = Element.Attribute("closure").AsInt(-1);
            DestroyIndex = Element.Attribute("destroy").AsInt(-1);
            IsNullable = Element.Attribute("nullable").AsBool();
            IsOptional = Element.Attribute("optional").AsBool();
            IsSkip = Element.Attribute("skip").AsBool();
            IsParams = parent is ManagedParameters && Element.Attribute(gs + "params").AsBool();
            DefaultValue = Element.Attribute(gs + "default").AsString();
            _GirType = new Lazy<GIType>(LazyGetGirType, false);
            _Callable = new Lazy<GICallable>(LazyGetCallable, false);
        }

        GIType LazyGetGirType() =>
            (GIType)GetNode(Element.Element(gi + "type") ?? Element.Element(gi + "array"));

        GICallable LazyGetCallable() =>
            (ParentNode as GICallable) ?? (ParentNode.ParentNode as GICallable);
    }
}
