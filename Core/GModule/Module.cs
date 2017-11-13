using System;
using System.IO;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GModule
{
    /// <summary>
    /// This class provides a portable way to dynamically load object files
    /// (commonly known as 'plug-ins'). The current implementation supports all
    /// systems that provide an implementation of dlopen() (e.g. Linux/Sun), as
    /// well as Windows platforms via DLLs.
    /// </summary>
    /// <remarks>
    /// To use this class you must first determine whether dynamic loading is
    /// supported on the platform by checking <see cref="Supported"/>.
    /// If it is, you can open a module with <see cref="#ctor"/>,
    /// find the module's symbols (e.g. function names) with <see cref="GetSymbol"/>,
    /// and later close the module with <see cref="base.Dispose"/>. <see cref="Name"/>
    /// will return the file name of a currently opened module.
    ///
    /// If any of the above methods fail, a <see cref="ModuleErrorException"/>
    /// will be thrown.
    ///
    /// If your module introduces static data to common subsystems in the running
    /// program, e.g.through calling g_quark_from_static_string ("my-module-stuff"),
    /// it must ensure that it is never unloaded, by calling <see cref="MakeResident"/>.
    /// </remarks>
    public sealed class Module : Opaque
    {
        static object errorLock = new object ();

        /// <summary>
        /// The proper shared library prefix for the current platform. For
        /// most Unices and Linux, this is "lib" and for Windows it is "".
        /// </summary>
        public static readonly string Prefix;

        /// <summary>
        /// The proper shared module suffix for the current platform without
        /// the leading dot. For most Unices and Linux this is "so", and for
        /// Windows this is "dll".
        /// </summary>
        public static readonly string Suffix;

        /// <summary>
        /// The proper shared library suffix for the current platform without
        /// the leading dot. This is the same as <see cref="Suffix"/>, except
        /// on macOS, where it is "dylib" instead of "so".
        /// </summary>
        public static readonly string LibrarySuffix;

        static Module ()
        {
            // Initialize the platform-specific "constants". Suffix should end
            // up being the same as G_MODULE_SUFFIX in C code.

            var emptyName = GMarshal.StringToUtf8Ptr (string.Empty);
            var path_ = g_module_build_path (IntPtr.Zero, emptyName);
            var path = GMarshal.Utf8PtrToString (path_, true);
            GMarshal.Free (emptyName);

            var parts = path.Split ('.');
            Prefix = parts[0];
            Suffix = parts[1];

            // Hack to detect macOS
            if (File.Exists ("/usr/lib/libSystem.dylib")) {
                LibrarySuffix = "dylib";
            } else {
                LibrarySuffix = Suffix;
            }
        }

        public sealed class SafeHandle : SafeOpaqueHandle
        {
            public SafeHandle (IntPtr handle, Transfer ownership)
            {
                if (ownership == Transfer.None) {
                    throw new NotSupportedException ();
                }
                SetHandle (handle);
            }

            public SafeHandle ()
            {
            }

            [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern bool g_module_close (IntPtr module);

            protected override bool ReleaseHandle ()
            {
                return g_module_close (handle);
            }
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

        public Module (SafeHandle handle) : base (handle)
        {
        }

        [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_module_supported ();

        /// <summary>
        /// Checks if modules are supported on the current platform.
        /// </summary>
        /// <value><c>true</c> if modules are supported.</value>
        public static bool Supported {
            get {
                return g_module_supported ();
            }
        }

        [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_module_build_path (IntPtr directory, IntPtr moduleName);

        /// <summary>
        /// A portable way to build the filename of a module. The platform-specific
        /// prefix and suffix are added to the filename, if needed, and the result
        /// is added to the directory, using the correct separator character.
        /// </summary>
        /// <returns>The complete path of the module, including the standard module
        /// prefix and suffix.</returns>
        /// <param name="directory">The directory where the module is. This can be
        /// <c>null</c> or the empty string to indicate that the standard platform-specific
        /// directories will be used, though that is not recommended.</param>
        /// <param name="moduleName">The name of the module.</param>
        /// <param name="isSharedLibrary">Use the shared library suffix instead of the module suffix.</param>
        /// <remarks>
        /// The directory should specify the directory where the module can be
        /// found. It can be <c>null</c> or an empty string to indicate that the
        /// module is in a standard platform-specific directory, though this is
        /// not recommended since the wrong module may be found.
        ///
        /// For example, calling <see cref="BuildPath"/> on a Linux system with
        /// a <paramref name="directory"/> of <c>/lib</c> and a <paramref name="moduleName"/>
        /// of "mylibrary" will return <c>/lib/libmylibrary.so</c>.On a Windows system,
        /// using <c>\Windows</c> as the directory it will return <c>\Windows\mylibrary.dll</c>.
        /// 
        /// The <paramref name="isSharedLibrary"/> parameter only makes a difference
        /// on macOS, where modules use the suffix "so" and shared libraries use
        /// the suffix "dylib".
        /// </remarks>
        public static string BuildPath (string directory, string moduleName, bool isSharedLibrary = false)
        {
            if (moduleName == null) {
                throw new ArgumentNullException (nameof (moduleName));
            }

            // BuildPath was originally a wrapper around g_module_build_path,
            // but it is easy enough to implment it in managed code and we want
            // to be able to handle both "so" and "dylib" suffixes on macOS.

            var prefix = moduleName.StartsWith (Prefix, StringComparison.OrdinalIgnoreCase)
                                   ? string.Empty : Prefix;
            var suffix = isSharedLibrary ? LibrarySuffix : Suffix;
            var fullName = prefix + moduleName + "." + suffix;

            if (string.IsNullOrEmpty (directory)) {
                return fullName;
            }

            return Path.Combine (directory, fullName);
        }

        [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_module_open (IntPtr fileName, ModuleFlags flags);

        /// <summary>
        /// Opens a module.
        /// </summary>
        /// <returns>A <see cref="Module"/>.</returns>
        /// <param name="fileName">The name of the file containing the module,
        /// or <c>null</c> to obtain a <see cref="Module"/> representing the main
        /// program itself.</param>
        /// <param name="flags">The flags used for opening the module. This can
        /// be the logical OR of any of the <see cref="ModuleFlags"/></param>
        /// <remarks>
        /// First of all <see cref="#ctor"/> tries to open <paramref name="fileName"/>
        /// as a module. If that fails and <paramref name="fileName"/> has the ".la"-suffix
        /// (and is a libtool archive) it tries to open the corresponding module. If
        /// that fails and it doesn't have the proper module suffix for the platform
        /// (<see cref="Suffix"/>), this suffix will be appended and the corresponding
        /// module will be opended. If that fails and <paramref name="fileName"/> doesn't
        /// have the ".la"-suffix, this suffix is appended and <see cref="#ctor"/> tries
        /// to open the corresponding module. If eventually that fails as well,
        /// a <see cref="ModuleErrorException"/> is thrown.
        /// </remarks>
        /// <exception cref="ModuleErrorException">
        /// On failure
        /// </exception>
        public static Module Open (string fileName, ModuleFlags flags = 0)
        {
            var fileName_ = GMarshal.StringToUtf8Ptr (fileName);
            try {
                lock (errorLock) {
                    var ret_ = g_module_open (fileName_, flags);
                    if (ret_ == IntPtr.Zero) {
                        throw new ModuleErrorException (Error);
                    }
                    var ret = Opaque.GetOrCreate<Module> (ret_, Transfer.Full);
                    return ret;
                }
            } finally {
                GMarshal.Free (fileName_);
            }
        }

        [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_module_symbol (
            SafeHandle module,
            IntPtr symbolName,
            out IntPtr symbol);

        /// <summary>
        /// Gets a symbol pointer from a module.
        /// </summary>
        /// <returns>The pointer to the symbol value.</returns>
        /// <param name="symbolName">The name of the symbol to find.</param>
        /// <exception cref="ModuleErrorException">
        /// On failure
        /// </exception>
        public IntPtr GetSymbol (string symbolName)
        {
            AssertNotDisposed ();
            if (symbolName == null) {
                throw new ArgumentNullException (nameof (symbolName));
            }
            lock (errorLock) {
                var symbolName_ = GMarshal.StringToUtf8Ptr (symbolName);
                try {
                    IntPtr symbol;
                    if (!g_module_symbol (Handle, symbolName_, out symbol)) {
                        throw new ModuleErrorException (Error);
                    }
                    return symbol;
                } finally {
                    GMarshal.Free (symbolName_);
                }
            }
        }

        [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_module_name (
            SafeHandle module);

        /// <summary>
        /// Gets the filename that the module was opened with.
        /// </summary>
        /// <value>The filename of the module.</value>
        /// <remarks>
        /// If this module refers to the application itself, "main" is returned.
        /// </remarks>
        public string Name {
            get {
                AssertNotDisposed ();
                var ret_ = g_module_name (Handle);
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_module_make_resident (
            SafeHandle module);

        /// <summary>
        /// Ensures that a module will never be unloaded.
        /// </summary>
        public void MakeResident ()
        {
            AssertNotDisposed ();
            g_module_make_resident (Handle);
        }

        [DllImport ("gmodule-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_module_error ();

        /// <summary>
        /// Gets a string describing the last module error.
        /// </summary>
        /// <value>A string describing the last module error.</value>
        static string Error {
            get {
                var ret_ = g_module_error ();
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }
    }

    /// <summary>
    /// Module error exception.
    /// </summary>
    public class ModuleErrorException : Exception
    {
        internal ModuleErrorException (string message) : base (message)
        {
        }
    }
}
