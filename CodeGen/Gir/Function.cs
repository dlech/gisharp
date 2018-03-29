using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Function : GIFunction
    {
        /// <summary>
        /// Gets the async function that this function finishes, if any
        /// </summary>
        public GIFunction FinishForFunction => _FinishForFunction.Value;
        readonly Lazy<GIFunction> _FinishForFunction;

        public Function(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "function") {
                throw new ArgumentException("Requrires <function> element", nameof(element));
            }
            _FinishForFunction = new Lazy<GIFunction>(LazyGetFinishForFunction);
        }

        GIFunction LazyGetFinishForFunction =>
            (GIFunction)GirNode.GetNode(Element.Parent.Elements(gi + "function")
                .Concat(Element.Parent.Elements(gi + "method"))
                .SingleOrDefault(x => x.Attribute("name")?.Value == FinishFor));
    }
}
