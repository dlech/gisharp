// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
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
        /// Indicates that this callable is a .NET async method
        /// </summary>
        public bool IsAsync { get; }

        /// <summary>
        /// Gets the managed name of the matching callable that finishes this
        /// callable if this callable is async,
        /// </summary>
        public string AsyncFinish { get; }

        /// <summary>
        /// Indicates that this callable is a finish function for an async method
        /// </summary>
        public bool IsFinish { get; }

        /// <summary>
        /// Indicates that a method should be generated to check the return value.
        /// </summary>
        public bool IsCheckReturn { get; }

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
            IsAsync = Element.Attribute(gs + "async").AsBool();
            AsyncFinish = Element.Attribute(gs + "async-finish").AsString();
            IsFinish = Element.Attribute(gs + "finish").AsBool();
            IsCheckReturn = Element.Attribute(gs + "check-return").AsBool();
            _ReturnValue = new(LazyGetReturnValue, false);
            _Parameters = new(LazyGetParameters, false);
            _ManagedParameters = new(LazyGetManagedParameters, false);
        }

        ReturnValue LazyGetReturnValue() =>
            (ReturnValue)GetNode(Element.Element(gi + "return-value"));

        Parameters LazyGetParameters() => (Parameters)GetNode(Element.Element(gi + "parameters"));

        ManagedParameters LazyGetManagedParameters() =>
            (ManagedParameters)GetNode(Element.Element(gs + "managed-parameters"));
    }
}
