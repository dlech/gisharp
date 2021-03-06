// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class ManagedParameters : GirNode, IEnumerable<GIArg>
    {
        /// <summary>
        /// Gets the this parameter for extension methods
        /// </summary>
        public InstanceParameter ThisParameter => _ThisParameter.Value;
        readonly Lazy<InstanceParameter> _ThisParameter;

        /// <summary>
        /// Gets the regular parameters
        /// </summary>
        public IEnumerable<Parameter> RegularParameters => _RegularParameters.Value;
        readonly Lazy<List<Parameter>> _RegularParameters;
        readonly Lazy<List<GIArg>> _AllParameters;

        public ManagedParameters(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gs + "managed-parameters") {
                throw new ArgumentException("Requrires <gs:managed-parameters> element", nameof(element));
            }
            _ThisParameter = new(LazyGetThisParameter, false);
            _RegularParameters = new(() => LazyGetRegularParameters().ToList(), false);
            _AllParameters = new(() => LazyGetAllParameters().ToList(), false);
        }

        InstanceParameter LazyGetThisParameter() =>
            (InstanceParameter)GetNode(Element.Element(gi + "instance-parameter"));

        IEnumerable<Parameter> LazyGetRegularParameters() =>
            Element.Elements(gi + "parameter").Select(x => (Parameter)GetNode(x));

        IEnumerable<GIArg> LazyGetAllParameters()
        {
            var parameters = RegularParameters.Cast<GIArg>();

            if (ThisParameter is not null) {
                parameters = parameters.Prepend(ThisParameter);
            }

            return parameters;
        }

        IEnumerator<GIArg> IEnumerable<GIArg>.GetEnumerator() =>
            _AllParameters.Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _AllParameters.Value.GetEnumerator();
    }
}
