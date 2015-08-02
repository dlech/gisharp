using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public class Repository
    {
        public IReadOnlyList<EnumInfo> Enums { get; private set; }

        public IReadOnlyList<InterfaceInfo> Interfaces { get; private set; }

        public IReadOnlyList<ObjectInfo> GObjects { get; private set; }

        public IReadOnlyList<StructInfo> ReferenceCountedOpaques { get; private set; }

        public IReadOnlyList<StructInfo> OwnedOpaques { get; private set; }

        public IReadOnlyList<StructInfo> Structs { get; private set; }

        public IReadOnlyList<UnionInfo> Unions { get; private set; }

        public IReadOnlyList<CallbackInfo> GlobalDelegates { get; private set; }

        public IReadOnlyList<ConstantInfo> GlobalConstants { get; private set; }

        public Repository (string @namespace, string version = null)
        {
            GISharp.GI.Repository.Require (@namespace, version);
            var giNamespace = GISharp.GI.Repository.Namespaces [@namespace];

            // infoPool starts with copy of all infos. As each info is used in
            // a registered type, it is removed from the list. This way, only
            // the globals are left at the end.
            var infoPool = giNamespace.Infos.Select (i => BaseInfo.WrapInfo (i)).ToList ();

            foreach (var info in infoPool.ToList ()) {
                if (info.IsHidden) {
                    infoPool.Remove (info);
                    continue;
                }

                var type = info as RegisteredTypeInfo;
                if (type != null) {
                    var extraConstants = infoPool.GetExtras<ConstantInfo> (type);
                    type.AddExtraConstants (extraConstants);
                    var extraFunctions = infoPool.GetExtras<FunctionInfo> (type);
                    type.AddExtraMethods (extraFunctions);

                    infoPool.RemoveAll (i => type.Constants.Contains (i as ConstantInfo));
                    infoPool.RemoveAll (i => type.Methods.Contains (i as FunctionInfo));
                    infoPool.Remove (info);
                }
            }
        }
    }

    static class RepositoryExtensions {
        internal static IReadOnlyList<T> GetExtras<T> (this List<BaseInfo> infoPool, RegisteredTypeInfo type) where T : BaseInfo
        {
            var prefix = string.Join (".", type.Namespace, type.Info.InfoType, string.Empty);
            var names = MainClass.fixup
                .Where (i => i.Key.StartsWith (prefix, StringComparison.Ordinal)
                    && i.Value.ContainsKey ("class") && i.Value["class"] == type.FixupPath)
                .Select (i => i.Key.Substring (prefix.Length));
            var extraInfos = infoPool.Where (i => i is T && names.Contains (i.Name)).Cast<T> ();
            return extraInfos.ToList ().AsReadOnly ();
        }
    }
}
