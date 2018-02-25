

using System.Reflection;
using System.Xml.Linq;

namespace GISharp.CodeGen.Reflection
{
    public class GirModule : Module
    {
        public GirModule(XElement element)
        {
        }

        public override Assembly Assembly => Assembly.GetExecutingAssembly();
    }
}
