// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Parameters : GirNode, IEnumerable<GIArg>
    {
        /// <summary>
        /// Gets the instance parameter for methods
        /// </summary>
        public InstanceParameter InstanceParameter => _InstanceParameter.Value;
        readonly Lazy<InstanceParameter> _InstanceParameter;

        /// <summary>
        /// Gets the regular parameters
        /// </summary>
        public IEnumerable<Parameter> RegularParameters => _RegularParameters.Value;
        readonly Lazy<List<Parameter>> _RegularParameters;

        /// <summary>
        /// Gets the instance parameter for methods
        /// </summary>
        public ErrorParameter ErrorParameter => _ErrorParameter.Value;
        readonly Lazy<ErrorParameter> _ErrorParameter;

        Lazy<List<GIArg>> _AllParameters;

        public Parameters(XElement element, GirNode parent): base(element, parent)
        {
            if (element.Name != gi + "parameters") {
                throw new ArgumentException("Requrires <parameters> element", nameof(element));
            }
            _InstanceParameter = new(LazyGetInstanceParameter, false);
            _RegularParameters = new(() => LazyGetRegularParameters().ToList(), false);
            _ErrorParameter = new(LazyGetErrorParameter, false);
            _AllParameters = new(() => LazyGetAllParameters().ToList(), false);
        }

        InstanceParameter LazyGetInstanceParameter() =>
            (InstanceParameter)GetNode(Element.Element(gi + "instance-parameter"));

        IEnumerable<Parameter> LazyGetRegularParameters() =>
            Element.Elements(gi + "parameter").Select(x => (Parameter)GetNode(x));

        ErrorParameter LazyGetErrorParameter() =>
            (ErrorParameter)GetNode(Element.Element(gs + "error-parameter"));

        IEnumerable<GIArg> LazyGetAllParameters()
        {
            var parameters = RegularParameters.Cast<GIArg>();

            if (InstanceParameter is not null) {
                parameters = parameters.Prepend(InstanceParameter);
            }

            if (ErrorParameter is not null) {
                parameters = parameters.Append(ErrorParameter);
            }

            return parameters;
        }

        IEnumerator<GIArg> IEnumerable<GIArg>.GetEnumerator() =>
            _AllParameters.Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _AllParameters.Value.GetEnumerator();
    }
}
