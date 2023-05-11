// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class ErrorParameter : GIArg
    {
        public ErrorParameter(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gs + "error-parameter")
            {
                throw new ArgumentException(
                    "Requrires <gs:error-parameter> element",
                    nameof(element)
                );
            }
        }
    }
}
