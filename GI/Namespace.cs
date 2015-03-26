using System;
using System.Linq;

namespace GI
{
    public class Namespace
    {
        string @namespace;

        internal Namespace (string @namespace)
        {
            if (@namespace == null)
                throw new ArgumentNullException ("@namespace");
            if (!Repository.LoadedNamespaces.Contains (@namespace))
                throw new ArgumentOutOfRangeException ("@namespace");

            this.@namespace = @namespace;
        }

        public BaseInfo FindByName (string name)
        {
            return Repository.FindByName (@namespace, name);
        }

        public string Name {
            get {
                return @namespace;
            }
        }

        public string CPrefix {
            get {
                return Repository.GetCPrefix (@namespace);
            }
        }

        public string[] Dependencies {
            get {
                return Repository.GetDependencies (@namespace);
            }
        }

        public InfoCollection<BaseInfo> Infos {
            get {
                return Repository.GetInfos (@namespace);
            }
        }

        public string[] SharedLibraries {
            get {
                return Repository.GetSharedLibrary (@namespace).Split (new [] { ',' },
                    StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public string TypelibPath {
            get {
                return Repository.GetTypelibPath (@namespace);
            }
        }

        public string Version {
            get {
                return Repository.GetVersion (@namespace);
            }
        }

        public string[] Versions {
            get {
                return Repository.GetVersions (@namespace);
            }
        }
    }
}
