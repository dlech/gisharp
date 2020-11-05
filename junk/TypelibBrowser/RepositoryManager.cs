using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using GISharp.Lib.GIRepository;
using System.IO;

namespace GISharp.TypelibBrowser
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

        [global::GLib.Signal ("typelib-loaded")]
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
                        if (TypelibLoaded is not null) {
                            TypelibLoaded (this, new TypelibLoadedEventArgs (
                                @namespace, Repository.Namespaces[@namespace].Version));
                        }
                    } catch (Exception ex) {
                        Console.Error.WriteLine (ex.Message);
                    }
                }
            }
        }
    }

    public class TypelibLoadedEventArgs : EventArgs
    {
        public string Namespace { get; }
        public string Version { get; }

        public TypelibLoadedEventArgs(string @namespace, string version)
        {
            if (@namespace is null) {
                throw new ArgumentNullException ("namespace");
            }
            if (version is null) {
                throw new ArgumentNullException ("version");
            }
            Namespace = @namespace;
            Version = version;
        }
    }
}

