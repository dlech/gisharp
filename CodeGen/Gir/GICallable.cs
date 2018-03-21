using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GICallable : GIBase
    {
        /// <summary>
        /// Indicates that this callable throws a GError exception
        /// </summary>
        public bool ThrowsGErrorException { get; }

        /// <summary>
        /// Indicates that there is a custom arg check that should be called
        /// </summary>
        /// <remarks>
        /// The custom arg check must be defined manually in a partial class
        /// matching type this callable belongs to
        /// </remarks>
        public bool HasCustomArgCheck { get; }

        /// <summary>
        /// Gets the return value for this callable
        /// </summary>
        public ReturnValue ReturnValue => _ReturnValue.Value;
        readonly Lazy<ReturnValue> _ReturnValue;

        /// <summary>
        /// Gets the parameters for this callable
        /// </summary>
        public Parameters Parameters => _Parameters.Value;
        readonly Lazy<Parameters> _Parameters;

        /// <summary>
        /// Gets the parameters for this callable
        /// </summary>
        public ManagedParameters ManagedParameters => _ManagedParameters.Value;
        readonly Lazy<ManagedParameters> _ManagedParameters;

        private protected GICallable(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            ThrowsGErrorException = Element.Attribute("throws").AsBool();
            HasCustomArgCheck = Element.Attribute(gs + "custom-arg-check").AsBool();
            _ReturnValue = new Lazy<ReturnValue>(LazyGetReturnValue, false);
            _Parameters = new Lazy<Parameters>(LazyGetParameters, false);
            _ManagedParameters = new Lazy<ManagedParameters>(LazyGetManagedParameters, false);
        }

        ReturnValue LazyGetReturnValue() =>
            (ReturnValue)GetNode(Element.Element(gi + "return-value"));

        Parameters LazyGetParameters() =>
            (Parameters)GetNode(Element.Element(gi + "parameters"));

        ManagedParameters LazyGetManagedParameters() =>
            (ManagedParameters)GetNode(Element.Element(gs + "managed-parameters"));
    }
}
