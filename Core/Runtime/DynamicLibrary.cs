using System;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public class DynamicLibrary : Opaque
    {
        const string LibraryPrefix = "lib";
        const string LibrarySuffix = ".so";

        static object lockObj = new object ();

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

            // TODO: need to make this platform-specific
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
