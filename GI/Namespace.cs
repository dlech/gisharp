using System;
using System.Linq;

namespace GI
{
    public class Namespace
    {
        Repository repository;
        string @namespace;

        internal Namespace (Repository repository, string @namespace)
        {
            if (repository == null)
                throw new ArgumentNullException ("repository");
            if (@namespace == null)
                throw new ArgumentNullException ("@namespace");
            if (!repository.LoadedNamespaces.Contains (@namespace))
                throw new ArgumentOutOfRangeException ("@namespace");

            this.repository = repository;
            this.@namespace = @namespace;
        }

        public BaseInfo FindByName (string name)
        {
            return repository.FindByName (@namespace, name);
        }

        public string Name {
            get {
                return @namespace;
            }
        }

        public string CPrefix {
            get {
                return repository.GetCPrefix (@namespace);
            }
        }

        public string[] Dependencies {
            get {
                return repository.GetDependencies (@namespace);
            }
        }

        public InfoCollection<BaseInfo> Infos {
            get {
                return repository.GetInfos (@namespace);
            }
        }

        public string[] SharedLibraries {
            get {
                return repository.GetSharedLibrary (@namespace).Split (new [] { ',' },
                    StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public string TypelibPath {
            get {
                return repository.GetTypelibPath (@namespace);
            }
        }

        public string Version {
            get {
                return repository.GetVersion (@namespace);
            }
        }

        public string[] Versions {
            get {
                return repository.GetVersions (@namespace);
            }
        }
    }
}
