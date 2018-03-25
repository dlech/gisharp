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
        public Method FinishForFunction => _FinishForFunction.Value;
        readonly Lazy<Method> _FinishForFunction;

        public Function(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "function") {
                throw new ArgumentException("Requrires <function> element", nameof(element));
            }
            _FinishForFunction = new Lazy<Method>(LazyGetFinishForFunction);
        }

        Method LazyGetFinishForFunction =>
            (Method)GirNode.GetNode(Element.Parent.Elements(Element.Name)
                .SingleOrDefault(x => x.Attribute("name")?.Value == FinishFor));
    }
}
