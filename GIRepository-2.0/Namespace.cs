using System;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using GISharp.Lib.GIRepository.Dynamic;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    public sealed class Namespace : IDynamicMetaObjectProvider
    {
        /// <summary>
        /// Special string that can be returned by <see cref="TypelibPath"/>.
        /// </summary>
        public const string BuiltInPath = "<builtin>";

        readonly Utf8 @namespace;

        internal Namespace(Utf8 @namespace)
        {
            if (!Repository.LoadedNamespaces.Contains (@namespace)) {
                throw new ArgumentOutOfRangeException (nameof (@namespace));
            }

            this.@namespace = @namespace;
            _Infos = new Lazy<InfoDictionary<BaseInfo>> (() => Repository.GetInfos (@namespace));
        }

        /// <summary>
        /// Searches for a particular entry in a namespace.
        /// </summary>
        /// <returns>BaseInfo representing metadata about name , or <c>null</c> if no match was found.</returns>
        /// <param name="name">Name.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="name"/> is <c>null</c>.</exception>
        public BaseInfo FindByName (string name)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            return Repository.FindByName (@namespace, name);
        }

        public DynamicMetaObject GetMetaObject (Expression parameter)
        {
            return new NamespaceDynamicMetaObject (parameter, this);
        }

        /// <summary>
        /// Gets the name of this Namespace.
        /// </summary>
        /// <value>The name.</value>
        public Utf8 Name => @namespace;

        /// <summary>
        /// Gets the C prefix or the C level namespace associated with the given
        /// introspection namespace.
        /// </summary>
        /// <value>The C prefix or <c>null</c> if none associated.</value>
        /// <remarks>
        /// Each C symbol starts with this prefix, as well each GType in the library.
        /// </remarks>
        public NullableUnownedUtf8 CPrefix {
            get {
                return Repository.GetCPrefix (@namespace);
            }
        }

        /// <summary>
        /// Return an array of all (transitive) versioned dependencies for this namespace.
        /// Returned strings are of the form <code>namespace-version</code>.
        /// </summary>
        /// <value>String array of all versioned dependencies.</value>
        /// <remarks>
        /// The Namespace must have already been loaded using a function such as
        /// <see cref="Repository.Require"/> before calling this function.
        /// </remarks>
        public Strv Dependencies {
            get {
                return Repository.GetDependencies (@namespace);
            }
        }

        /// <summary>
        /// Return an array of the immediate versioned dependencies for this namespace.
        /// Returned strings are of the form <code>namespace-version</code>.
        /// </summary>
        /// <value>String array of immediate versioned dependencies.</value>
        /// <remarks>
        /// The Namespace must have already been loaded using a function such as
        /// <see cref="Repository.Require"/> before calling this function.
        /// </remarks>
        [Since ("1.44")]
        public Strv ImmediateDependencies {
            get {
                return Repository.GetImmediateDependencies (@namespace);
            }
        }

        Lazy<InfoDictionary<BaseInfo>> _Infos;
        public InfoDictionary<BaseInfo> Infos {
            get {
                return _Infos.Value;
            }
        }

        /// <summary>
        /// Gets the  the full path to the shared C library.
        /// </summary>
        /// <value>Full path to shared library or empty array if none associated.</value>
        /// <remarks>
        /// There may be no shared library path associated, in which case this
        /// will return an empty array. Additionally, some may return more than
        /// one library, but most should return only one.
        /// </remarks>
        public string[] SharedLibraries {
            get {
                var library = Repository.GetSharedLibrary (@namespace);
                if (library.IsNull) {
                    return new string[0];
                }
                return library.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// Gets the full path to the .typelib file it was loaded from.
        /// </summary>
        /// <value>The typelib path.</value>
        /// <remarks>
        ///  If the typelib for this Namespace was included in a shared
        /// library, return the special string "<builtin>".
        /// </remarks>
        public NullableUnownedUtf8 TypelibPath {
            get {
                return Repository.GetTypelibPath (@namespace);
            }
        }

        /// <summary>
        /// Gets the the loaded version associated with this Namespace.
        /// </summary>
        /// <value>Loaded version.</value>
        public UnownedUtf8 Version {
            get {
                return Repository.GetVersion (@namespace);
            }
        }

        /// <summary>
        /// Obtain an unordered list of versions (either currently loaded or available).
        /// </summary>
        /// <value>The array of versions.</value>
        public string[] Versions {
            get {
                return Repository.GetVersions (@namespace);
            }
        }
    }
}
