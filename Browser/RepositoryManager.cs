using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using GISharp.GI;
using System.IO;

namespace GISharp.Browser
{
    public class RepositoryManager
    {
        public IEnumerable<string[]> Namespaces {
            get {
                return Repository.Namespaces.Select ((n) => new [] {
                    n.Name,
                    n.Version
                });
            }
        }

        [GLib.Signal ("typelib-loaded")]
        public event EventHandler<TypelibLoadedEventArgs> TypelibLoaded;

        public RepositoryManager ()
        {
        }

        public void LoadAllTypelibs ()
        {
            foreach (var path in Repository.SearchPaths) {
                var typelibFiles = Directory.EnumerateFiles (path, "*.typelib");
                var namespaces = new List<string> ();
                foreach (var file in typelibFiles) {
                    // File names are of the format <namespace>-<version>.typelib
                    var baseName = Path.GetFileNameWithoutExtension (file);
                    var @namespace = baseName.Substring (0, baseName.LastIndexOf ("-"));
                    if (namespaces.Contains(@namespace)) {
                        // prevent duplicate events
                        continue;
                    }
                    namespaces.Add (@namespace);
                    try {
                        Repository.Require (@namespace);
                        if (TypelibLoaded != null) {
                            TypelibLoaded (this, new TypelibLoadedEventArgs (
                                @namespace, Repository.Namespaces[@namespace].Version));
                        }
                    } catch (Exception ex) {
                        Debug.WriteLine (ex.Message);
                    }
                }
            }
        }
    }

    public class TypelibLoadedEventArgs : EventArgs
    {
        public string Namespace { get; private set; }
        public string Version { get; private set; }

        public TypelibLoadedEventArgs(string @namespace, string version)
        {
            if (@namespace == null) {
                throw new ArgumentNullException ("namespace");
            }
            if (@namespace == null) {
                throw new ArgumentNullException ("version");
            }
            Namespace = @namespace;
            Version = version;
        }
    }
}

