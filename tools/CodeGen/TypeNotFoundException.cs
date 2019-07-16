using System;

namespace GISharp.CodeGen
{
    public class TypeNotFoundException : Exception
    {
        public TypeNotFoundException (string typeName)
            : base (string.Format ("Failed to get type for '{0}'.", typeName))
        {
        }
    }
}
