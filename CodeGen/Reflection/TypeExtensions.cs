
using System;

namespace GISharp.CodeGen.Reflection
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Because of the dynamic types used in CodeGen, we have to try really
        /// hard to determine inheritance.
        /// </summary>
        public static bool IsSubclassOf<T>(this Type type)
        {
            if (type == null) {
                throw new ArgumentNullException(nameof(type));
            }
            try {
                return type.IsSubclassOf(typeof(T));
            }
            catch (NotSupportedException) {
                return typeof(T).IsAssignableFrom(type);
            }
        }
    }
}
