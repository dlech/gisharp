using System;
using System.Linq;
using System.Reflection;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;

namespace GISharp.CodeGen.Reflection
{
    class GirInterfaceType : GirType
    {
        internal GirInterfaceType(Interface @interface) : base(@interface)
        {
        }

        public static System.Type ResolveType(Implements implements)
        {
            if (implements.ManagedName.Contains('.')) {
                var type = GetType(implements.ManagedName);
                if (type != null) {
                    return type;
                }
                throw new TypeNotFoundException(implements.ManagedName);
            }
            
            var @namespace = implements.ParentNode.Namespace;
            var @interface = @namespace.Interfaces.SingleOrDefault(x => x.GirName == implements.GirName);
            if (@interface != null) {
                return new GirInterfaceType(@interface);
            }

            throw new TypeNotFoundException(implements.ManagedName);
        }

        public static System.Type ResolveType(Prerequisite prerequisite)
        {
            if (prerequisite.GirName.Contains('.')) {
                var type = GetType(prerequisite.GirName);
                if (type != null) {
                    return type;
                }
                throw new TypeNotFoundException(prerequisite.GirName);
            }
            
            var @namespace = prerequisite.ParentNode.Namespace;
            var @interface = @namespace.Interfaces.SingleOrDefault(x => x.GirName == prerequisite.GirName);
            if (@interface != null) {
                return new GirInterfaceType(@interface);
            }

            var @class = @namespace.Classes.SingleOrDefault(x => x.GirName == prerequisite.GirName);
            if (@class != null) {
                var classType = new GirClassType(@class);
                return typeof(GInterface<>).MakeGenericType(classType);
            }

            throw new TypeNotFoundException(prerequisite.GirName);
        }

        public override string Name => "I" + base.Name;

        protected override TypeAttributes GetAttributeFlagsImpl() => base.GetAttributeFlagsImpl() | TypeAttributes.Interface;
    }
}
