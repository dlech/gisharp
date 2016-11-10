using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public class DynamicLibrary : Opaque
    {
        static readonly string LibraryPrefix;
        static readonly string LibrarySuffix;

        static object lockObj = new object ();

        static DynamicLibrary () {
            if (Environment.OSVersion.Platform == PlatformID.Unix) {
                LibraryPrefix = "lib";
                LibrarySuffix = ".so";
                // Hack to detect macOS
                if (File.Exists ("/usr/lib/libSystem.dylib")) {
                    LibrarySuffix = ".dylib";
                }
            } else if (Environment.OSVersion.Platform == PlatformID.MacOSX) {
                // Pretty sure that this case will never happen because of
                // http://lists.ximian.com/pipermail/mono-devel-list/2011-November/038257.html
                // ...but including it just in case.
                LibraryPrefix = "lib";
                LibrarySuffix = ".dylib";
            } else {
                LibraryPrefix = "";
                LibrarySuffix = ".dll";
            }
        }

        [DllImport ("dl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr dlopen (string path, Mode mode);

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicLibrary"/> class.
        /// </summary>
        /// <param name="name">The name of the library.</param>
        /// <param name="mode">The mode flags.</param>
        public DynamicLibrary (string name, Mode mode = Mode.Lazy | Mode.Local)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof(name));
            }
            if (!mode.HasFlag (Mode.Lazy) && !mode.HasFlag (Mode.Now)) {
                var message = "mode must contain one of Mode.Lazy or Mode.Now";
                throw new ArgumentException (message, nameof(mode));
            }

            name = string.Format ($"{LibraryPrefix}{name}{LibrarySuffix}");

            lock (lockObj) {
                ClearLastError ();
                Handle = dlopen (name, mode);
                if (Handle == IntPtr.Zero) {
                    throw new Exception (CheckLastError ());
                }
            }
        }

        public int? GetInt32 (string symbol)
        {
            AssertNotDisposed ();
            var ptr = GetSymbol (symbol);
            if (ptr == IntPtr.Zero) {
                return null;
            }
            return Marshal.ReadInt32 (ptr);
        }

        public uint? GetUInt32 (string symbol)
        {
            AssertNotDisposed ();
            var ptr = GetSymbol (symbol);
            if (ptr == IntPtr.Zero) {
                return null;
            }
            return(uint)Marshal.ReadInt32 (ptr);
        }

        public IntPtr GetPointer (string symbol)
        {
            AssertNotDisposed ();
            return GetSymbol (symbol);
        }

        public T GetFunction<T> (string symbol)
        {
            AssertNotDisposed ();
            var ptr = GetSymbol (symbol);
            if (ptr == IntPtr.Zero) {
                return default(T);
            }
            return Marshal.GetDelegateForFunctionPointer<T> (ptr);
        }

        [DllImport ("dl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr dlsym (IntPtr handle, string symbol);

        IntPtr GetSymbol (string symbol)
        {
            if (symbol == null) {
                throw new ArgumentNullException (nameof(symbol));
            }
            lock (lockObj) {
                ClearLastError ();
                var ret = dlsym (Handle, symbol);
                var err = CheckLastError (); 
                if (err!= null) {
                    throw new Exception (err);
                }
                return ret;
            }
        }

        [DllImport ("dl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int dlclose (IntPtr handle);

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed) {
                dlclose (Handle);
            }
            base.Dispose(disposing);
        }

        [DllImport ("dl.dll")]
        internal static extern IntPtr dlerror ();

        static string CheckLastError ()
        {
            // we can't free the string returned from dlerror
            var ptr = dlerror ();
            var message = Marshal.PtrToStringAnsi (ptr);
            return message;
        }

        static void ClearLastError ()
        {
            dlerror ();
        }

        [Flags]
        public enum Mode
        {
            /// <summary>
            /// Lazy function call binding.
            /// </summary>
            Lazy      = 0x00001,

            /// <summary>
            /// Immediate function call binding.
            /// </summary>
            Now       = 0x00002,

            /// <summary>
            /// Mask of binding time value.
            /// </summary>
            BindingMask = 0x3,

            /// <summary>
            /// Do not load the object.
            /// </summary>
            NoLoad    = 0x00004,

            /// <summary>
            /// Use deep binding.
            /// </summary>
            DeepBind  = 0x00008,

            /// <summary>
            /// The symbols of the loaded object and its dependencies are made
            /// visible as if the object were linked directly into the program.
            /// </summary>
            Global =    0x00100,

            /// <summary>
            /// Inverse of <see cref="Global"/>. (Default)
            /// </summary>
            Local = 0,

            /// <summary>>
            /// Do not delete object when closed.
            /// </summary>
            NoDelete =  0x01000,
        }
    }
}
