using System;
using System.Runtime.InteropServices;
using System.Linq;
using GISharp.GLib;
using System.Collections.Generic;
using System.Reflection;

namespace GISharp.Runtime
{
    /// <summary>
    /// Exception that wraps an unmanaged GError.
    /// </summary>
    public abstract class GErrorException : Exception
    {
        static readonly Dictionary<Quark, Type> errorDomainMap = new Dictionary<Quark, Type> ();
        static readonly object errorDomainMapLock = new object ();

        public Error Error { get; private set; }

        public override string Message {
            get {
                return Error.Message;
            }
        }

        protected GErrorException (Error error)
        {
            Error = error;
        }

        public static GErrorException CreateInstance (IntPtr error)
        {
            var err = Opaque.GetInstance<Error> (error, Transfer.All);
            lock (errorDomainMapLock) {
                if (!errorDomainMap.ContainsKey (err.Domain)) {
                    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies ()) {
                        foreach (var enumType in assembly.GetTypes ().Where (t => t.IsEnum)) {
                            var errorDomainAttr = enumType.GetCustomAttribute<ErrorDomainAttribute> ();
                            if (errorDomainAttr == null) {
                                continue;
                            }
                            var errorDomainQuark = Quark.FromString (errorDomainAttr.ErrorDomain);
                            if (errorDomainMap.ContainsKey (errorDomainQuark)) {
                                continue;
                            }
                            var exceptionType = assembly.GetType (enumType.FullName + "Exception", true);
                            errorDomainMap.Add (errorDomainQuark, exceptionType);
                            if (err.Domain == errorDomainQuark) {
                                break;
                            }
                        }
                    }
                }
                var type = errorDomainMap[err.Domain];
                var instance = Activator.CreateInstance (type, err);
                return (GErrorException)instance;
            }
        }
    }
}
