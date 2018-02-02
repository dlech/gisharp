using System;
using System.Reflection;
using System.Collections.Generic;

namespace GISharp.CodeGen
{
    public static class TypeResolver
    {
        static readonly Dictionary<string, Assembly> assemblyCache =
            new Dictionary<string, Assembly> ();

        public static void LoadAssembly(Assembly assembly)
        {
            assemblyCache.Add(assembly.FullName, assembly);
        }

        public static void LoadAssembly(string path)
        {
            var assembly = Assembly.LoadFrom(path);
            LoadAssembly(assembly);
        }

        public static Assembly Resolve (object sender, ResolveEventArgs e)
        {
            foreach (var assembly in assemblyCache.Values) {
                if (assembly.GetType (e.Name) != null) {
                    return assembly;
                }
            }

            return null;
        }
    }
}
