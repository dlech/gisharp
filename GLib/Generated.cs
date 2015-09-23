using System;
using System.Runtime.InteropServices;

namespace GISharp.GLib
{
    /// <summary>
    /// Specifies the type of function passed to g_dataset_foreach(). It is
    /// called with each #GQuark id and associated data element, together
    /// with the @user_data parameter supplied to g_dataset_foreach().
    /// </summary>
    /// <param name="keyId">
    /// the #GQuark id to identifying the data element.
    /// </param>
    /// <param name="data">
    /// the data element.
    /// </param>
    /// <param name="userData">
    /// user data passed to g_dataset_foreach().
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void DataForeachFuncNative( System.IntPtr keyId,  System.IntPtr data,  System.IntPtr userData);

    /// <summary>
    /// Specifies the type of function passed to g_dataset_foreach(). It is
    /// called with each #GQuark id and associated data element, together
    /// with the @user_data parameter supplied to g_dataset_foreach().
    /// </summary>
    /// <param name="keyId">
    /// the #GQuark id to identifying the data element.
    /// </param>
    /// <param name="data">
    /// the data element.
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void DataForeachFunc( GISharp.GLib.Quark keyId,  System.IntPtr data);

    /// <summary>
    /// Specifies the type of function which is called when a data element
    /// is destroyed. It is passed the pointer to the data element and
    /// should free any memory and resources allocated for it.
    /// </summary>
    /// <param name="data">
    /// the data element.
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void DestroyNotifyNative( System.IntPtr data);

    /// <summary>
    /// Specifies the type of function which is called when a data element
    /// is destroyed. It is passed the pointer to the data element and
    /// should free any memory and resources allocated for it.
    /// </summary>
    /// <param name="data">
    /// the data element.
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void DestroyNotify( System.IntPtr data);

    /// <summary>
    /// The type of functions that are used to 'duplicate' an object.
    /// What this means depends on the context, it could just be
    /// incrementing the reference count, if @data is a ref-counted
    /// object.
    /// </summary>
    /// <param name="data">
    /// the data to duplicate
    /// </param>
    /// <param name="userData">
    /// user data that was specified in g_datalist_id_dup_data()
    /// </param>
    /// <returns>
    /// a duplicate of data
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.IntPtr DuplicateFuncNative( System.IntPtr data,  System.IntPtr userData);

    /// <summary>
    /// The type of functions that are used to 'duplicate' an object.
    /// What this means depends on the context, it could just be
    /// incrementing the reference count, if @data is a ref-counted
    /// object.
    /// </summary>
    /// <param name="data">
    /// the data to duplicate
    /// </param>
    /// <returns>
    /// a duplicate of data
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.IntPtr DuplicateFunc( System.IntPtr data);

    /// <summary>
    /// Declares a type of function which takes an arbitrary
    /// data pointer argument and has no return value. It is
    /// not currently used in GLib or GTK+.
    /// </summary>
    /// <param name="data">
    /// a data pointer
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void FreeFuncNative( System.IntPtr data);

    /// <summary>
    /// Declares a type of function which takes an arbitrary
    /// data pointer argument and has no return value. It is
    /// not currently used in GLib or GTK+.
    /// </summary>
    /// <param name="data">
    /// a data pointer
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void FreeFunc( System.IntPtr data);

    /// <summary>
    /// Specifies the prototype of log handler functions.
    /// </summary>
    /// <remarks>
    /// The default log handler, g_log_default_handler(), automatically appends a
    /// new-line character to @message when printing it. It is advised that any
    /// custom log handler functions behave similarly, so that logging calls in user
    /// code do not need modifying to add a new-line character to the message if the
    /// log handler is changed.
    /// </remarks>
    /// <param name="logDomain">
    /// the log domain of the message
    /// </param>
    /// <param name="logLevel">
    /// the log level of the message (including the
    ///     fatal and recursion flags)
    /// </param>
    /// <param name="message">
    /// the message to process
    /// </param>
    /// <param name="userData">
    /// user data, set in g_log_set_handler()
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void LogFuncNative( System.IntPtr logDomain,  System.IntPtr logLevel,  System.IntPtr message,  System.IntPtr userData);

    /// <summary>
    /// Specifies the prototype of log handler functions.
    /// </summary>
    /// <remarks>
    /// The default log handler, g_log_default_handler(), automatically appends a
    /// new-line character to @message when printing it. It is advised that any
    /// custom log handler functions behave similarly, so that logging calls in user
    /// code do not need modifying to add a new-line character to the message if the
    /// log handler is changed.
    /// </remarks>
    /// <param name="logDomain">
    /// the log domain of the message
    /// </param>
    /// <param name="logLevel">
    /// the log level of the message (including the
    ///     fatal and recursion flags)
    /// </param>
    /// <param name="message">
    /// the message to process
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void LogFunc( System.String logDomain,  GISharp.GLib.LogLevelFlags logLevel,  System.String message);

    /// <summary>
    /// Specifies the type of function passed to g_node_children_foreach().
    /// The function is called with each child node, together with the user
    /// data passed to g_node_children_foreach().
    /// </summary>
    /// <param name="node">
    /// a #GNode.
    /// </param>
    /// <param name="data">
    /// user data passed to g_node_children_foreach().
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void NodeForeachFuncNative( System.IntPtr node,  System.IntPtr data);

    /// <summary>
    /// Specifies the type of function passed to g_node_children_foreach().
    /// The function is called with each child node, together with the user
    /// data passed to g_node_children_foreach().
    /// </summary>
    /// <param name="node">
    /// a #GNode.
    /// </param>
    /// <param name="data">
    /// user data passed to g_node_children_foreach().
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void NodeForeachFunc( GISharp.GLib.Node node,  System.IntPtr data);

    /// <summary>
    /// Specifies the type of function passed to g_node_traverse(). The
    /// function is called with each of the nodes visited, together with the
    /// user data passed to g_node_traverse(). If the function returns
    /// %TRUE, then the traversal is stopped.
    /// </summary>
    /// <param name="node">
    /// a #GNode.
    /// </param>
    /// <param name="data">
    /// user data passed to g_node_traverse().
    /// </param>
    /// <returns>
    /// %TRUE to stop the traversal.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Boolean NodeTraverseFuncNative( System.IntPtr node,  System.IntPtr data);

    /// <summary>
    /// Specifies the type of function passed to g_node_traverse(). The
    /// function is called with each of the nodes visited, together with the
    /// user data passed to g_node_traverse(). If the function returns
    /// %TRUE, then the traversal is stopped.
    /// </summary>
    /// <param name="node">
    /// a #GNode.
    /// </param>
    /// <param name="data">
    /// user data passed to g_node_traverse().
    /// </param>
    /// <returns>
    /// %TRUE to stop the traversal.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Boolean NodeTraverseFunc( GISharp.GLib.Node node,  System.IntPtr data);

    /// <summary>
    /// Specifies the type of function passed to g_main_context_set_poll_func().
    /// The semantics of the function should match those of the poll() system call.
    /// </summary>
    /// <param name="ufds">
    /// an array of #GPollFD elements
    /// </param>
    /// <param name="nfsd">
    /// the number of elements in @ufds
    /// </param>
    /// <param name="timeout">
    /// the maximum time to wait for an event of the file descriptors.
    ///     A negative value indicates an infinite timeout.
    /// </param>
    /// <returns>
    /// the number of #GPollFD elements which have events or errors
    ///     reported, or -1 if an error occurred.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Int32 PollFuncNative( System.IntPtr ufds,  System.UInt32 nfsd,  System.Int32 timeout);

    /// <summary>
    /// Specifies the type of function passed to g_main_context_set_poll_func().
    /// The semantics of the function should match those of the poll() system call.
    /// </summary>
    /// <param name="ufds">
    /// an array of #GPollFD elements
    /// </param>
    /// <param name="nfsd">
    /// the number of elements in @ufds
    /// </param>
    /// <param name="timeout">
    /// the maximum time to wait for an event of the file descriptors.
    ///     A negative value indicates an infinite timeout.
    /// </param>
    /// <returns>
    /// the number of #GPollFD elements which have events or errors
    ///     reported, or -1 if an error occurred.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Int32 PollFunc( GISharp.GLib.PollFD ufds,  System.UInt32 nfsd,  System.Int32 timeout);

    /// <summary>
    /// A #GSequenceIterCompareFunc is a function used to compare iterators.
    /// It must return zero if the iterators compare equal, a negative value
    /// if @a comes before @b, and a positive value if @b comes before @a.
    /// </summary>
    /// <param name="a">
    /// a #GSequenceIter
    /// </param>
    /// <param name="b">
    /// a #GSequenceIter
    /// </param>
    /// <param name="data">
    /// user data
    /// </param>
    /// <returns>
    /// zero if the iterators are equal, a negative value if @a
    ///     comes before @b, and a positive value if @b comes before @a.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Int32 SequenceIterCompareFuncNative( System.IntPtr a,  System.IntPtr b,  System.IntPtr data);

    /// <summary>
    /// A #GSequenceIterCompareFunc is a function used to compare iterators.
    /// It must return zero if the iterators compare equal, a negative value
    /// if @a comes before @b, and a positive value if @b comes before @a.
    /// </summary>
    /// <param name="a">
    /// a #GSequenceIter
    /// </param>
    /// <param name="b">
    /// a #GSequenceIter
    /// </param>
    /// <param name="data">
    /// user data
    /// </param>
    /// <returns>
    /// zero if the iterators are equal, a negative value if @a
    ///     comes before @b, and a positive value if @b comes before @a.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Int32 SequenceIterCompareFunc( GISharp.GLib.SequenceIter a,  GISharp.GLib.SequenceIter b,  System.IntPtr data);

    /// <summary>
    /// This is just a placeholder for #GClosureMarshal,
    /// which cannot be used here for dependency reasons.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void SourceDummyMarshalNative();

    /// <summary>
    /// This is just a placeholder for #GClosureMarshal,
    /// which cannot be used here for dependency reasons.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void SourceDummyMarshal();

    /// <summary>
    /// Specifies the type of function passed to g_timeout_add(),
    /// g_timeout_add_full(), g_idle_add(), and g_idle_add_full().
    /// </summary>
    /// <param name="userData">
    /// data passed to the function, set when the source was
    ///     created with one of the above functions
    /// </param>
    /// <returns>
    /// %FALSE if the source should be removed. #G_SOURCE_CONTINUE and
    /// #G_SOURCE_REMOVE are more memorable names for the return value.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Boolean SourceFuncNative( System.IntPtr userData);

    /// <summary>
    /// Specifies the type of function passed to g_timeout_add(),
    /// g_timeout_add_full(), g_idle_add(), and g_idle_add_full().
    /// </summary>
    /// <returns>
    /// %FALSE if the source should be removed. #G_SOURCE_CONTINUE and
    /// #G_SOURCE_REMOVE are more memorable names for the return value.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Boolean SourceFunc();

    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    /// <param name="str">
    /// the untranslated string
    /// </param>
    /// <param name="data">
    /// user data specified when installing the function, e.g.
    ///  in g_option_group_set_translate_func()
    /// </param>
    /// <returns>
    /// a translation of the string for the current locale.
    ///  The returned string is owned by GLib and must not be freed.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.String TranslateFuncNative( System.IntPtr str,  System.IntPtr data);

    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    /// <param name="str">
    /// the untranslated string
    /// </param>
    /// <param name="data">
    /// user data specified when installing the function, e.g.
    ///  in g_option_group_set_translate_func()
    /// </param>
    /// <returns>
    /// a translation of the string for the current locale.
    ///  The returned string is owned by GLib and must not be freed.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.String TranslateFunc( System.String str,  System.IntPtr data);

    /// <summary>
    /// Specifies the type of function passed to g_tree_traverse(). It is
    /// passed the key and value of each node, together with the @user_data
    /// parameter passed to g_tree_traverse(). If the function returns
    /// %TRUE, the traversal is stopped.
    /// </summary>
    /// <param name="key">
    /// a key of a #GTree node
    /// </param>
    /// <param name="value">
    /// the value corresponding to the key
    /// </param>
    /// <param name="data">
    /// user data passed to g_tree_traverse()
    /// </param>
    /// <returns>
    /// %TRUE to stop the traversal
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Boolean TraverseFuncNative( System.IntPtr key,  System.IntPtr value,  System.IntPtr data);

    /// <summary>
    /// Specifies the type of function passed to g_tree_traverse(). It is
    /// passed the key and value of each node, together with the @user_data
    /// parameter passed to g_tree_traverse(). If the function returns
    /// %TRUE, the traversal is stopped.
    /// </summary>
    /// <param name="key">
    /// a key of a #GTree node
    /// </param>
    /// <param name="value">
    /// the value corresponding to the key
    /// </param>
    /// <param name="data">
    /// user data passed to g_tree_traverse()
    /// </param>
    /// <returns>
    /// %TRUE to stop the traversal
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Boolean TraverseFunc( System.IntPtr key,  System.IntPtr value,  System.IntPtr data);

    /// <summary>
    /// Declares a type of function which takes no arguments
    /// and has no return value. It is used to specify the type
    /// function passed to g_atexit().
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void VoidFuncNative();

    /// <summary>
    /// Declares a type of function which takes no arguments
    /// and has no return value. It is used to specify the type
    /// function passed to g_atexit().
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate System.Void VoidFunc();

    public static partial class Constants
    {
        /// <summary>
        /// The position of the first bit which is not reserved for internal
        /// use be the #GHook implementation, i.e.
        /// `1 &lt;&lt; G_HOOK_FLAG_USER_SHIFT` is the first
        /// bit which can be used for application-defined flags.
        /// </summary>
        public const System.Int32 HookFlagUserShift = 4;

        /// <summary>
        /// Number of microseconds in one second (1 million).
        /// This macro is provided for code readability.
        /// </summary>
        public const System.Int32 UsecPerSec = 1000000;
        public const System.Int32 VaCopyAsArray = 1;
        public const System.String ExternDllName = "glib-2.0.dll";
    }

    /// <summary>
    /// Integer representing a day of the month; between 1 and 31.
    /// #G_DATE_BAD_DAY represents an invalid day of the month.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DateDay
    {
        private System.Byte value;
    }

    /// <summary>
    /// Integer representing a year; #G_DATE_BAD_YEAR is the invalid
    /// value. The year must be 1 or higher; negative (BC) years are not
    /// allowed. The year is represented with four digits.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DateYear
    {
        private System.UInt16 value;
    }

    /// <summary>
    /// A GQuark is a non-zero integer which uniquely identifies a
    /// particular string. A GQuark value of zero is associated to %NULL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Quark
    {
        private System.UInt32 value;

        /// <summary>
        /// Gets the string associated with the given #GQuark.
        /// </summary>
        /// <returns>
        /// the string associated with the #GQuark
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_quark_to_string();

        /// <summary>
        /// Gets the string associated with the given #GQuark.
        /// </summary>
        /// <returns>
        /// the string associated with the #GQuark
        /// </returns>
        public override System.String ToString()
        {
            var ret = g_quark_to_string();
            return default(System.String);
        }

        /// <summary>
        /// Gets the #GQuark identifying the given string. If the string does
        /// not currently have an associated #GQuark, a new #GQuark is created,
        /// using a copy of the string.
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark identifying the string, or 0 if @string is %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_quark_from_string( System.IntPtr @string);

        /// <summary>
        /// Gets the #GQuark identifying the given string. If the string does
        /// not currently have an associated #GQuark, a new #GQuark is created,
        /// using a copy of the string.
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark identifying the string, or 0 if @string is %NULL
        /// </returns>
        public static GISharp.GLib.Quark FromString( System.String @string)
        {
            var ret = g_quark_from_string(@string);
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Gets the #GQuark associated with the given string, or 0 if string is
        /// %NULL or it has no associated #GQuark.
        /// </summary>
        /// <remarks>
        /// If you want the GQuark to be created if it doesn't already exist,
        /// use g_quark_from_string() or g_quark_from_static_string().
        /// </remarks>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark associated with the string, or 0 if @string is
        ///     %NULL or there is no #GQuark associated with it
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_quark_try_string( System.IntPtr @string);

        /// <summary>
        /// Gets the #GQuark associated with the given string, or 0 if string is
        /// %NULL or it has no associated #GQuark.
        /// </summary>
        /// <remarks>
        /// If you want the GQuark to be created if it doesn't already exist,
        /// use g_quark_from_string() or g_quark_from_static_string().
        /// </remarks>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark associated with the string, or 0 if @string is
        ///     %NULL or there is no #GQuark associated with it
        /// </returns>
        public static GISharp.GLib.Quark TryString( System.String @string)
        {
            var ret = g_quark_try_string(@string);
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Returns a canonical representation for @string. Interned strings
        /// can be compared for equality by comparing the pointers, instead of
        /// using strcmp().
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// a canonical representation for the string
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_intern_string( System.IntPtr @string);

        /// <summary>
        /// Returns a canonical representation for @string. Interned strings
        /// can be compared for equality by comparing the pointers, instead of
        /// using strcmp().
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// a canonical representation for the string
        /// </returns>
        [GISharp.Core.Since("2.10")]
        public static System.IntPtr InternString( System.String @string)
        {
            var ret = g_intern_string(@string);
            return default(System.IntPtr);
        }
    }

    /// <summary>
    /// A C representable type name for #G_TYPE_STRV.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Strv
    {
        private System.IntPtr value;
    }

    /// <summary>
    /// A value representing an interval of time, in microseconds.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct TimeSpan
    {
        /// <summary>
        /// Evaluates to a time span of one day.
        /// </summary>
        [GISharp.Core.Since("2.26")]
        public const System.Int64 Day = 86400000000L;

        /// <summary>
        /// Evaluates to a time span of one hour.
        /// </summary>
        [GISharp.Core.Since("2.26")]
        public const System.Int64 Hour = 3600000000L;

        /// <summary>
        /// Evaluates to a time span of one millisecond.
        /// </summary>
        [GISharp.Core.Since("2.26")]
        public const System.Int64 Millisecond = 1000L;

        /// <summary>
        /// Evaluates to a time span of one minute.
        /// </summary>
        [GISharp.Core.Since("2.26")]
        public const System.Int64 Minute = 60000000L;

        /// <summary>
        /// Evaluates to a time span of one second.
        /// </summary>
        [GISharp.Core.Since("2.26")]
        public const System.Int64 Second = 1000000L;
        private System.Int64 value;
    }

    /// <summary>
    /// Flags which influence the parsing.
    /// </summary>
    [Flags]
    public enum KeyFileFlags
    {
        /// <summary>
        /// No flags, default behaviour
        /// </summary>
        None = 0,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise all comments will be lost when the key file is
        ///     written back.
        /// </summary>
        KeepComments = 1,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise only the translations for the current language will be
        ///     written back.
        /// </summary>
        KeepTranslations = 2
    }

    /// <summary>
    /// Flags specifying the level of log messages.
    /// </summary>
    /// <remarks>
    /// It is possible to change how GLib treats messages of the various
    /// levels using g_log_set_handler() and g_log_set_fatal_mask().
    /// </remarks>
    [Flags]
    public enum LogLevelFlags
    {
        /// <summary>
        /// internal flag
        /// </summary>
        FlagRecursion = 1,
        /// <summary>
        /// internal flag
        /// </summary>
        FlagFatal = 2,
        /// <summary>
        /// log level for errors, see g_error().
        ///     This level is also used for messages produced by g_assert().
        /// </summary>
        LevelError = 4,
        /// <summary>
        /// log level for critical messages, see g_critical().
        ///     This level is also used for messages produced by g_return_if_fail()
        ///     and g_return_val_if_fail().
        /// </summary>
        LevelCritical = 8,
        /// <summary>
        /// log level for warnings, see g_warning()
        /// </summary>
        LevelWarning = 16,
        /// <summary>
        /// log level for messages, see g_message()
        /// </summary>
        LevelMessage = 32,
        /// <summary>
        /// log level for informational messages, see g_info()
        /// </summary>
        LevelInfo = 64,
        /// <summary>
        /// log level for debug messages, see g_debug()
        /// </summary>
        LevelDebug = 128,
        /// <summary>
        /// a mask including all log levels
        /// </summary>
        LevelMask = -4
    }

    /// <summary>
    /// Specifies which nodes are visited during several of the tree
    /// functions, including g_node_traverse() and g_node_find().
    /// </summary>
    [Flags]
    public enum TraverseFlags
    {
        /// <summary>
        /// only leaf nodes should be visited. This name has
        ///                     been introduced in 2.6, for older version use
        ///                     %G_TRAVERSE_LEAFS.
        /// </summary>
        Leaves = 1,
        /// <summary>
        /// only non-leaf nodes should be visited. This
        ///                         name has been introduced in 2.6, for older
        ///                         version use %G_TRAVERSE_NON_LEAFS.
        /// </summary>
        NonLeaves = 2,
        /// <summary>
        /// all nodes should be visited.
        /// </summary>
        All = 3,
        /// <summary>
        /// a mask of all traverse flags.
        /// </summary>
        Mask = 3,
        /// <summary>
        /// identical to %G_TRAVERSE_LEAVES.
        /// </summary>
        Leafs = 1,
        /// <summary>
        /// identical to %G_TRAVERSE_NON_LEAVES.
        /// </summary>
        NonLeafs = 2
    }

    /// <summary>
    /// This enumeration isn't used in the API, but may be useful if you need
    /// to mark a number as a day, month, or year.
    /// </summary>
    public enum DateDMY
    {
        /// <summary>
        /// a day
        /// </summary>
        Day = 0,
        /// <summary>
        /// a month
        /// </summary>
        Month = 1,
        /// <summary>
        /// a year
        /// </summary>
        Year = 2
    }

    /// <summary>
    /// Enumeration representing a month; values are #G_DATE_JANUARY,
    /// #G_DATE_FEBRUARY, etc. #G_DATE_BAD_MONTH is the invalid value.
    /// </summary>
    public enum DateMonth
    {
        /// <summary>
        /// invalid value
        /// </summary>
        BadMonth = 0,
        /// <summary>
        /// January
        /// </summary>
        January = 1,
        /// <summary>
        /// February
        /// </summary>
        February = 2,
        /// <summary>
        /// March
        /// </summary>
        March = 3,
        /// <summary>
        /// April
        /// </summary>
        April = 4,
        /// <summary>
        /// May
        /// </summary>
        May = 5,
        /// <summary>
        /// June
        /// </summary>
        June = 6,
        /// <summary>
        /// July
        /// </summary>
        July = 7,
        /// <summary>
        /// August
        /// </summary>
        August = 8,
        /// <summary>
        /// September
        /// </summary>
        September = 9,
        /// <summary>
        /// October
        /// </summary>
        October = 10,
        /// <summary>
        /// November
        /// </summary>
        November = 11,
        /// <summary>
        /// December
        /// </summary>
        December = 12
    }

    /// <summary>
    /// Enumeration representing a day of the week; #G_DATE_MONDAY,
    /// #G_DATE_TUESDAY, etc. #G_DATE_BAD_WEEKDAY is an invalid weekday.
    /// </summary>
    public enum DateWeekday
    {
        /// <summary>
        /// invalid value
        /// </summary>
        BadWeekday = 0,
        /// <summary>
        /// Monday
        /// </summary>
        Monday = 1,
        /// <summary>
        /// Tuesday
        /// </summary>
        Tuesday = 2,
        /// <summary>
        /// Wednesday
        /// </summary>
        Wednesday = 3,
        /// <summary>
        /// Thursday
        /// </summary>
        Thursday = 4,
        /// <summary>
        /// Friday
        /// </summary>
        Friday = 5,
        /// <summary>
        /// Saturday
        /// </summary>
        Saturday = 6,
        /// <summary>
        /// Sunday
        /// </summary>
        Sunday = 7
    }

    /// <summary>
    /// The possible errors, used in the @v_error field
    /// of #GTokenValue, when the token is a %G_TOKEN_ERROR.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// unknown error
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// unexpected end of file
        /// </summary>
        UnexpEof = 1,
        /// <summary>
        /// unterminated string constant
        /// </summary>
        UnexpEofInString = 2,
        /// <summary>
        /// unterminated comment
        /// </summary>
        UnexpEofInComment = 3,
        /// <summary>
        /// non-digit character in a number
        /// </summary>
        NonDigitInConst = 4,
        /// <summary>
        /// digit beyond radix in a number
        /// </summary>
        DigitRadix = 5,
        /// <summary>
        /// non-decimal floating point number
        /// </summary>
        FloatRadix = 6,
        /// <summary>
        /// malformed floating point number
        /// </summary>
        FloatMalformed = 7
    }

    /// <summary>
    /// Error codes returned by key file parsing.
    /// </summary>
    [GISharp.Core.ErrorDomain("g-key-file-error-quark")]
    public enum KeyFileError
    {
        /// <summary>
        /// the text being parsed was in
        ///     an unknown encoding
        /// </summary>
        UnknownEncoding = 0,
        /// <summary>
        /// document was ill-formed
        /// </summary>
        Parse = 1,
        /// <summary>
        /// the file was not found
        /// </summary>
        NotFound = 2,
        /// <summary>
        /// a requested key was not found
        /// </summary>
        KeyNotFound = 3,
        /// <summary>
        /// a requested group was not found
        /// </summary>
        GroupNotFound = 4,
        /// <summary>
        /// a value could not be parsed
        /// </summary>
        InvalidValue = 5
    }

    /// <summary>
    /// An enumeration specifying the base position for a
    /// g_io_channel_seek_position() operation.
    /// </summary>
    public enum SeekType
    {
        /// <summary>
        /// the current position in the file.
        /// </summary>
        Cur = 0,
        /// <summary>
        /// the start of the file.
        /// </summary>
        Set = 1,
        /// <summary>
        /// the end of the file.
        /// </summary>
        End = 2
    }

    /// <summary>
    /// Disambiguates a given time in two ways.
    /// </summary>
    /// <remarks>
    /// First, specifies if the given time is in universal or local time.
    /// 
    /// Second, if the time is in local time, specifies if it is local
    /// standard time or local daylight time.  This is important for the case
    /// where the same local time occurs twice (during daylight savings time
    /// transitions, for example).
    /// </remarks>
    public enum TimeType
    {
        /// <summary>
        /// the time is in local standard time
        /// </summary>
        Standard = 0,
        /// <summary>
        /// the time is in local daylight time
        /// </summary>
        Daylight = 1,
        /// <summary>
        /// the time is in UTC
        /// </summary>
        Universal = 2
    }

    /// <summary>
    /// Specifies the type of traveral performed by g_tree_traverse(),
    /// g_node_traverse() and g_node_find(). The different orders are
    /// illustrated here:
    /// - In order: A, B, C, D, E, F, G, H, I
    ///   ![](Sorted_binary_tree_inorder.svg)
    /// - Pre order: F, B, A, D, C, E, G, I, H
    ///   ![](Sorted_binary_tree_preorder.svg)
    /// - Post order: A, C, E, D, B, H, I, G, F
    ///   ![](Sorted_binary_tree_postorder.svg)
    /// - Level order: F, B, G, A, D, I, C, E, H
    ///   ![](Sorted_binary_tree_breadth-first_traversal.svg)
    /// </summary>
    public enum TraverseType
    {
        /// <summary>
        /// vists a node's left child first, then the node itself,
        ///              then its right child. This is the one to use if you
        ///              want the output sorted according to the compare
        ///              function.
        /// </summary>
        InOrder = 0,
        /// <summary>
        /// visits a node, then its children.
        /// </summary>
        PreOrder = 1,
        /// <summary>
        /// visits the node's children, then the node itself.
        /// </summary>
        PostOrder = 2,
        /// <summary>
        /// is not implemented for
        ///              [balanced binary trees][glib-Balanced-Binary-Trees].
        ///              For [n-ary trees][glib-N-ary-Trees], it
        ///              vists the root node first, then its children, then
        ///              its grandchildren, and so on. Note that this is less
        ///              efficient than the other orders.
        /// </summary>
        LevelOrder = 3
    }

    /// <summary>
    /// The range of possible top-level types of #GVariant instances.
    /// </summary>
    [GISharp.Core.Since("2.24")]
    public enum VariantClass
    {
        /// <summary>
        /// The #GVariant is a boolean.
        /// </summary>
        Boolean = 98,
        /// <summary>
        /// The #GVariant is a byte.
        /// </summary>
        Byte = 121,
        /// <summary>
        /// The #GVariant is a signed 16 bit integer.
        /// </summary>
        Int16 = 110,
        /// <summary>
        /// The #GVariant is an unsigned 16 bit integer.
        /// </summary>
        Uint16 = 113,
        /// <summary>
        /// The #GVariant is a signed 32 bit integer.
        /// </summary>
        Int32 = 105,
        /// <summary>
        /// The #GVariant is an unsigned 32 bit integer.
        /// </summary>
        Uint32 = 117,
        /// <summary>
        /// The #GVariant is a signed 64 bit integer.
        /// </summary>
        Int64 = 120,
        /// <summary>
        /// The #GVariant is an unsigned 64 bit integer.
        /// </summary>
        Uint64 = 116,
        /// <summary>
        /// The #GVariant is a file handle index.
        /// </summary>
        Handle = 104,
        /// <summary>
        /// The #GVariant is a double precision floating
        ///                          point value.
        /// </summary>
        Double = 100,
        /// <summary>
        /// The #GVariant is a normal string.
        /// </summary>
        String = 115,
        /// <summary>
        /// The #GVariant is a D-Bus object path
        ///                               string.
        /// </summary>
        ObjectPath = 111,
        /// <summary>
        /// The #GVariant is a D-Bus signature string.
        /// </summary>
        Signature = 103,
        /// <summary>
        /// The #GVariant is a variant.
        /// </summary>
        Variant = 118,
        /// <summary>
        /// The #GVariant is a maybe-typed value.
        /// </summary>
        Maybe = 109,
        /// <summary>
        /// The #GVariant is an array.
        /// </summary>
        Array = 97,
        /// <summary>
        /// The #GVariant is a tuple.
        /// </summary>
        Tuple = 40,
        /// <summary>
        /// The #GVariant is a dictionary entry.
        /// </summary>
        DictEntry = 123
    }

    /// <summary>
    /// Error codes returned by parsing text-format GVariants.
    /// </summary>
    [GISharp.Core.ErrorDomain("g-variant-parse-error-quark")]
    public enum VariantParseError
    {
        /// <summary>
        /// generic error (unused)
        /// </summary>
        Failed = 0,
        /// <summary>
        /// a non-basic #GVariantType was given where a basic type was expected
        /// </summary>
        BasicTypeExpected = 1,
        /// <summary>
        /// cannot infer the #GVariantType
        /// </summary>
        CannotInferType = 2,
        /// <summary>
        /// an indefinite #GVariantType was given where a definite type was expected
        /// </summary>
        DefiniteTypeExpected = 3,
        /// <summary>
        /// extra data after parsing finished
        /// </summary>
        InputNotAtEnd = 4,
        /// <summary>
        /// invalid character in number or unicode escape
        /// </summary>
        InvalidCharacter = 5,
        /// <summary>
        /// not a valid #GVariant format string
        /// </summary>
        InvalidFormatString = 6,
        /// <summary>
        /// not a valid object path
        /// </summary>
        InvalidObjectPath = 7,
        /// <summary>
        /// not a valid type signature
        /// </summary>
        InvalidSignature = 8,
        /// <summary>
        /// not a valid #GVariant type string
        /// </summary>
        InvalidTypeString = 9,
        /// <summary>
        /// could not find a common type for array entries
        /// </summary>
        NoCommonType = 10,
        /// <summary>
        /// the numerical value is out of range of the given type
        /// </summary>
        NumberOutOfRange = 11,
        /// <summary>
        /// the numerical value is out of range for any type
        /// </summary>
        NumberTooBig = 12,
        /// <summary>
        /// cannot parse as variant of the specified type
        /// </summary>
        TypeError = 13,
        /// <summary>
        /// an unexpected token was encountered
        /// </summary>
        UnexpectedToken = 14,
        /// <summary>
        /// an unknown keyword was encountered
        /// </summary>
        UnknownKeyword = 15,
        /// <summary>
        /// unterminated string constant
        /// </summary>
        UnterminatedStringConstant = 16,
        /// <summary>
        /// no value given
        /// </summary>
        ValueExpected = 17
    }

    /// <summary>
    /// A simple refcounted data type representing an immutable sequence of zero or
    /// more bytes from an unspecified origin.
    /// </summary>
    /// <remarks>
    /// The purpose of a #GBytes is to keep the memory region that it holds
    /// alive for as long as anyone holds a reference to the bytes.  When
    /// the last reference count is dropped, the memory is released. Multiple
    /// unrelated callers can use byte data in the #GBytes without coordinating
    /// their activities, resting assured that the byte data will not change or
    /// move while they hold a reference.
    /// 
    /// A #GBytes can come from many different origins that may have
    /// different procedures for freeing the memory region.  Examples are
    /// memory from g_malloc(), from memory slices, from a #GMappedFile or
    /// memory from other allocators.
    /// 
    /// #GBytes work well as keys in #GHashTable. Use g_bytes_equal() and
    /// g_bytes_hash() as parameters to g_hash_table_new() or g_hash_table_new_full().
    /// #GBytes can also be used as keys in a #GTree by passing the g_bytes_compare()
    /// function to g_tree_new().
    /// 
    /// The data pointed to by this bytes must not be modified. For a mutable
    /// array of bytes see #GByteArray. Use g_bytes_unref_to_array() to create a
    /// mutable array for a #GBytes sequence. To create an immutable #GBytes from
    /// a mutable #GByteArray, use the g_byte_array_free_to_bytes() function.
    /// </remarks>
    [GISharp.Core.Since("2.32")]
    public partial class Bytes : GISharp.Core.ReferenceCountedOpaque<Bytes>, IComparable<Bytes>
    {
        public Bytes(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// @data is copied. If @size is 0, @data may be %NULL.
        /// </remarks>
        /// <param name="data">
        /// 
        ///        the data to be used for the bytes
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_new( System.Byte[] data,  System.UInt64 size);

        /// <summary>
        /// Creates a new #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// @data is copied. If @size is 0, @data may be %NULL.
        /// </remarks>
        /// <param name="data">
        /// 
        ///        the data to be used for the bytes
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public Bytes( System.Byte[] data) : base(IntPtr.Zero)
        {
            var size = (System.UInt64)data.Length;
            var ret = g_bytes_new(data, size);
        }

        /// <summary>
        /// Creates a #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// When the last reference is dropped, @free_func will be called with the
        /// @user_data argument.
        /// 
        /// @data must not be modified after this call is made until @free_func has
        /// been called to indicate that the bytes is no longer in use.
        /// 
        /// @data may be %NULL if @size is 0.
        /// </remarks>
        /// <param name="data">
        /// the data to be used for the bytes
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <param name="freeFunc">
        /// the function to call to release the data
        /// </param>
        /// <param name="userData">
        /// data to pass to @free_func
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_new_with_free_func( System.IntPtr[] data,  System.UInt64 size,  System.IntPtr freeFunc,  System.IntPtr userData);

        /// <summary>
        /// Creates a #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// When the last reference is dropped, @free_func will be called with the
        /// @user_data argument.
        /// 
        /// @data must not be modified after this call is made until @free_func has
        /// been called to indicate that the bytes is no longer in use.
        /// 
        /// @data may be %NULL if @size is 0.
        /// </remarks>
        /// <param name="data">
        /// the data to be used for the bytes
        /// </param>
        /// <param name="freeFunc">
        /// the function to call to release the data
        /// </param>
        /// <param name="userData">
        /// data to pass to @free_func
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public Bytes( System.IntPtr[] data,  GISharp.Core.DestroyNotify`1[GISharp.GLib.Bytes]freeFunc,  System.IntPtr userData) : base(IntPtr.Zero)
        {
            if (freeFunc == null)
            {
                throw new ArgumentNullException("freeFunc");
            }
            var size = (System.UInt64)data.Length;
            var ret = g_bytes_new_with_free_func(data, size, freeFunc, userData);
        }

        /// <summary>
        /// Compares the two #GBytes values.
        /// </summary>
        /// <remarks>
        /// This function can be used to sort GBytes instances in lexographical order.
        /// </remarks>
        /// <param name="bytes1">
        /// a pointer to a #GBytes
        /// </param>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// a negative value if bytes2 is lesser, a positive value if bytes2 is
        ///          greater, and zero if bytes2 is equal to bytes1
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_bytes_compare( System.IntPtr bytes1,  System.IntPtr bytes2);

        /// <summary>
        /// Compares the two #GBytes values.
        /// </summary>
        /// <remarks>
        /// This function can be used to sort GBytes instances in lexographical order.
        /// </remarks>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// a negative value if bytes2 is lesser, a positive value if bytes2 is
        ///          greater, and zero if bytes2 is equal to bytes1
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public System.Int32 CompareTo( GISharp.GLib.Bytes bytes2)
        {
            if (bytes2 == null)
            {
                throw new ArgumentNullException("bytes2");
            }
            var ret = g_bytes_compare(Handle, bytes2);
            return default(System.Int32);
        }

        public static bool operator <(Bytes one, Bytes two)
        {
            return one.CompareTo(two) < 0;
        }

        public static bool operator <=(Bytes one, Bytes two)
        {
            return one.CompareTo(two) <= 0;
        }

        public static bool operator >=(Bytes one, Bytes two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator >(Bytes one, Bytes two)
        {
            return one.CompareTo(two) > 0;
        }

        /// <summary>
        /// Compares the two #GBytes values being pointed to and returns
        /// %TRUE if they are equal.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes1">
        /// a pointer to a #GBytes
        /// </param>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_bytes_equal( System.IntPtr bytes1,  System.IntPtr bytes2);

        /// <summary>
        /// Compares the two #GBytes values being pointed to and returns
        /// %TRUE if they are equal.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public System.Boolean Equals( GISharp.GLib.Bytes bytes2)
        {
            if (bytes2 == null)
            {
                throw new ArgumentNullException("bytes2");
            }
            var ret = g_bytes_equal(Handle, bytes2);
            return default(System.Boolean);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Bytes);
        }

        public override int GetHashCode()
        {
            return (int)Hash();
        }

        public static bool operator ==(Bytes one, Bytes two)
        {
            if ((object)one == null)
            {
                return (object)two == null;
            }
            return one.Equals(two);
        }

        public static bool operator !=(Bytes one, Bytes two)
        {
            return !(one == two);
        }

        /// <summary>
        /// Get the byte data in the #GBytes. This data should not be modified.
        /// </summary>
        /// <remarks>
        /// This function will always return the same pointer for a given #GBytes.
        /// 
        /// %NULL may be returned if @size is 0. This is not guaranteed, as the #GBytes
        /// may represent an empty string with @data non-%NULL and @size as 0. %NULL will
        /// not be returned if @size is non-zero.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="size">
        /// location to return size of byte data
        /// </param>
        /// <returns>
        /// a pointer to the
        ///          byte data, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        static extern System.Byte[] g_bytes_get_data( System.IntPtr bytes, out System.UInt64 size);

        /// <summary>
        /// Get the byte data in the #GBytes. This data should not be modified.
        /// </summary>
        /// <remarks>
        /// This function will always return the same pointer for a given #GBytes.
        /// 
        /// %NULL may be returned if @size is 0. This is not guaranteed, as the #GBytes
        /// may represent an empty string with @data non-%NULL and @size as 0. %NULL will
        /// not be returned if @size is non-zero.
        /// </remarks>
        /// <returns>
        /// a pointer to the
        ///          byte data, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public System.Byte[] get_Data()
        {
            var ret = g_bytes_get_data(Handle, size);
            return default(System.Byte[]);
        }

        /// <summary>
        /// Get the size of the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function will always return the same value for a given #GBytes.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// the size
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_bytes_get_size( System.IntPtr bytes);

        /// <summary>
        /// Get the size of the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function will always return the same value for a given #GBytes.
        /// </remarks>
        /// <returns>
        /// the size
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public System.UInt64 get_Size()
        {
            var ret = g_bytes_get_size(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Creates an integer hash code for the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_hash_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes">
        /// a pointer to a #GBytes key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_bytes_hash( System.IntPtr bytes);

        /// <summary>
        /// Creates an integer hash code for the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_hash_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [GISharp.Core.Since("2.32")]
        protected System.UInt32 Hash()
        {
            var ret = g_bytes_hash(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Creates a #GBytes which is a subsection of another #GBytes. The @offset +
        /// @length may not be longer than the size of @bytes.
        /// </summary>
        /// <remarks>
        /// A reference to @bytes will be held by the newly created #GBytes until
        /// the byte data is no longer needed.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="offset">
        /// offset which subsection starts at
        /// </param>
        /// <param name="length">
        /// length of subsection
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_new_from_bytes( System.IntPtr bytes,  System.UInt64 offset,  System.UInt64 length);

        /// <summary>
        /// Creates a #GBytes which is a subsection of another #GBytes. The @offset +
        /// @length may not be longer than the size of @bytes.
        /// </summary>
        /// <remarks>
        /// A reference to @bytes will be held by the newly created #GBytes until
        /// the byte data is no longer needed.
        /// </remarks>
        /// <param name="offset">
        /// offset which subsection starts at
        /// </param>
        /// <param name="length">
        /// length of subsection
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public GISharp.GLib.Bytes NewFromBytes( System.UInt64 offset,  System.UInt64 length)
        {
            var ret = g_bytes_new_from_bytes(Handle, offset, length);
            return default(GISharp.GLib.Bytes);
        }

        /// <summary>
        /// Increase the reference count on @bytes.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// the #GBytes
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_ref( System.IntPtr bytes);

        /// <summary>
        /// Increase the reference count on @bytes.
        /// </summary>
        /// <returns>
        /// the #GBytes
        /// </returns>
        [GISharp.Core.Since("2.32")]
        protected override void Ref()
        {
            var ret = g_bytes_ref(Handle);
        }

        /// <summary>
        /// Releases a reference on @bytes.  This may result in the bytes being
        /// freed.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_bytes_unref( System.IntPtr bytes);

        /// <summary>
        /// Releases a reference on @bytes.  This may result in the bytes being
        /// freed.
        /// </summary>
        [GISharp.Core.Since("2.32")]
        protected override System.Void Unref()
        {
            var ret = g_bytes_unref(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Unreferences the bytes, and returns a new mutable #GByteArray containing
        /// the same byte data.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is transferred to the array without copying
        /// if this was the last reference to bytes and bytes was created with
        /// g_bytes_new(), g_bytes_new_take() or g_byte_array_free_to_bytes(). In all
        /// other cases the data is copied.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// a new mutable #GByteArray containing the same byte data
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_unref_to_array( System.IntPtr bytes);

        /// <summary>
        /// Unreferences the bytes, and returns a new mutable #GByteArray containing
        /// the same byte data.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is transferred to the array without copying
        /// if this was the last reference to bytes and bytes was created with
        /// g_bytes_new(), g_bytes_new_take() or g_byte_array_free_to_bytes(). In all
        /// other cases the data is copied.
        /// </remarks>
        /// <returns>
        /// a new mutable #GByteArray containing the same byte data
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public GISharp.Core.ByteArray UnrefToArray()
        {
            var ret = g_bytes_unref_to_array(Handle);
            return default(GISharp.Core.ByteArray);
        }

        /// <summary>
        /// Unreferences the bytes, and returns a pointer the same byte data
        /// contents.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is returned without copying if this was
        /// the last reference to bytes and bytes was created with g_bytes_new(),
        /// g_bytes_new_take() or g_byte_array_free_to_bytes(). In all other cases the
        /// data is copied.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="size">
        /// location to place the length of the returned data
        /// </param>
        /// <returns>
        /// a pointer to the same byte data, which should
        ///          be freed with g_free()
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_bytes_unref_to_data( System.IntPtr bytes,  System.UInt64 size);

        /// <summary>
        /// Unreferences the bytes, and returns a pointer the same byte data
        /// contents.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is returned without copying if this was
        /// the last reference to bytes and bytes was created with g_bytes_new(),
        /// g_bytes_new_take() or g_byte_array_free_to_bytes(). In all other cases the
        /// data is copied.
        /// </remarks>
        /// <param name="size">
        /// location to place the length of the returned data
        /// </param>
        /// <returns>
        /// a pointer to the same byte data, which should
        ///          be freed with g_free()
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public System.IntPtr UnrefToData( System.UInt64 size)
        {
            var ret = g_bytes_unref_to_data(Handle, size);
            return default(System.IntPtr);
        }
    }

    /// <summary>
    /// The #GData struct is an opaque data structure to represent a
    /// [Keyed Data List][glib-Keyed-Data-Lists]. It should only be
    /// accessed via the following functions.
    /// </summary>
    public partial struct Data
    {
    }

    /// <summary>
    /// Represents a day between January 1, Year 1 and a few thousand years in
    /// the future. None of its members should be accessed directly.
    /// </summary>
    /// <remarks>
    /// If the #GDate-struct is obtained from g_date_new(), it will be safe
    /// to mutate but invalid and thus not safe for calendrical computations.
    /// 
    /// If it's declared on the stack, it will contain garbage so must be
    /// initialized with g_date_clear(). g_date_clear() makes the date invalid
    /// but sane. An invalid date doesn't represent a day, it's "empty." A date
    /// becomes valid after you set it to a Julian day or you set a day, month,
    /// and year.
    /// </remarks>
    public partial class Date : GISharp.Core.OwnedOpaque<Date>, IComparable<Date>
    {
        /// <summary>
        /// Represents an invalid #GDateDay.
        /// </summary>
        public const System.Byte BadDay = 0;

        /// <summary>
        /// Represents an invalid Julian day number.
        /// </summary>
        public const System.Int32 BadJulian = 0;

        /// <summary>
        /// Represents an invalid year.
        /// </summary>
        public const System.UInt16 BadYear = 0;

        public Date(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Allocates a #GDate and initializes
        /// it to a sane state. The new date will
        /// be cleared (as if you'd called g_date_clear()) but invalid (it won't
        /// represent an existing day). Free the return value with g_date_free().
        /// </summary>
        /// <returns>
        /// a newly-allocated #GDate
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_new();

        /// <summary>
        /// Allocates a #GDate and initializes
        /// it to a sane state. The new date will
        /// be cleared (as if you'd called g_date_clear()) but invalid (it won't
        /// represent an existing day). Free the return value with g_date_free().
        /// </summary>
        /// <returns>
        /// a newly-allocated #GDate
        /// </returns>
        public Date() : base(IntPtr.Zero)
        {
            var ret = g_date_new();
        }

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// day-month-year triplet you pass in represents an existing day, the
        /// returned date will be valid.
        /// </summary>
        /// <param name="day">
        /// day of the month
        /// </param>
        /// <param name="month">
        /// month of the year
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @day, @month, and @year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_new_dmy( System.IntPtr day,  System.IntPtr month,  System.IntPtr year);

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// day-month-year triplet you pass in represents an existing day, the
        /// returned date will be valid.
        /// </summary>
        /// <param name="day">
        /// day of the month
        /// </param>
        /// <param name="month">
        /// month of the year
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @day, @month, and @year
        /// </returns>
        public Date( GISharp.GLib.DateDay day,  GISharp.GLib.DateMonth month,  GISharp.GLib.DateYear year) : base(IntPtr.Zero)
        {
            var ret = g_date_new_dmy(day, month, year);
        }

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// Julian day number you pass in is valid (greater than 0, less than an
        /// unreasonably large number), the returned date will be valid.
        /// </summary>
        /// <param name="julianDay">
        /// days since January 1, Year 1
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @julian_day
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_new_julian( System.UInt32 julianDay);

        /// <summary>
        /// Like g_date_new(), but also sets the value of the date. Assuming the
        /// Julian day number you pass in is valid (greater than 0, less than an
        /// unreasonably large number), the returned date will be valid.
        /// </summary>
        /// <param name="julianDay">
        /// days since January 1, Year 1
        /// </param>
        /// <returns>
        /// a newly-allocated #GDate initialized with @julian_day
        /// </returns>
        public Date( System.UInt32 julianDay) : base(IntPtr.Zero)
        {
            var ret = g_date_new_julian(julianDay);
        }

        /// <summary>
        /// Increments a date some number of days.
        /// To move forward by weeks, add weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to increment
        /// </param>
        /// <param name="nDays">
        /// number of days to move the date forward
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_add_days( System.IntPtr date,  System.UInt32 nDays);

        /// <summary>
        /// Increments a date some number of days.
        /// To move forward by weeks, add weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="nDays">
        /// number of days to move the date forward
        /// </param>
        public System.Void AddDays( System.UInt32 nDays)
        {
            var ret = g_date_add_days(Handle, nDays);
            return default(System.Void);
        }

        /// <summary>
        /// Increments a date by some number of months.
        /// If the day of the month is greater than 28,
        /// this routine may change the day of the month
        /// (because the destination month may not have
        /// the current day in it). The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to increment
        /// </param>
        /// <param name="nMonths">
        /// number of months to move forward
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_add_months( System.IntPtr date,  System.UInt32 nMonths);

        /// <summary>
        /// Increments a date by some number of months.
        /// If the day of the month is greater than 28,
        /// this routine may change the day of the month
        /// (because the destination month may not have
        /// the current day in it). The date must be valid.
        /// </summary>
        /// <param name="nMonths">
        /// number of months to move forward
        /// </param>
        public System.Void AddMonths( System.UInt32 nMonths)
        {
            var ret = g_date_add_months(Handle, nMonths);
            return default(System.Void);
        }

        /// <summary>
        /// Increments a date by some number of years.
        /// If the date is February 29, and the destination
        /// year is not a leap year, the date will be changed
        /// to February 28. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to increment
        /// </param>
        /// <param name="nYears">
        /// number of years to move forward
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_add_years( System.IntPtr date,  System.UInt32 nYears);

        /// <summary>
        /// Increments a date by some number of years.
        /// If the date is February 29, and the destination
        /// year is not a leap year, the date will be changed
        /// to February 28. The date must be valid.
        /// </summary>
        /// <param name="nYears">
        /// number of years to move forward
        /// </param>
        public System.Void AddYears( System.UInt32 nYears)
        {
            var ret = g_date_add_years(Handle, nYears);
            return default(System.Void);
        }

        /// <summary>
        /// If @date is prior to @min_date, sets @date equal to @min_date.
        /// If @date falls after @max_date, sets @date equal to @max_date.
        /// Otherwise, @date is unchanged.
        /// Either of @min_date and @max_date may be %NULL.
        /// All non-%NULL dates must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to clamp
        /// </param>
        /// <param name="minDate">
        /// minimum accepted value for @date
        /// </param>
        /// <param name="maxDate">
        /// maximum accepted value for @date
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_clamp( System.IntPtr date,  System.IntPtr minDate,  System.IntPtr maxDate);

        /// <summary>
        /// If @date is prior to @min_date, sets @date equal to @min_date.
        /// If @date falls after @max_date, sets @date equal to @max_date.
        /// Otherwise, @date is unchanged.
        /// Either of @min_date and @max_date may be %NULL.
        /// All non-%NULL dates must be valid.
        /// </summary>
        /// <param name="minDate">
        /// minimum accepted value for @date
        /// </param>
        /// <param name="maxDate">
        /// maximum accepted value for @date
        /// </param>
        public System.Void Clamp( GISharp.GLib.Date minDate,  GISharp.GLib.Date maxDate)
        {
            if (minDate == null)
            {
                throw new ArgumentNullException("minDate");
            }
            if (maxDate == null)
            {
                throw new ArgumentNullException("maxDate");
            }
            var ret = g_date_clamp(Handle, minDate, maxDate);
            return default(System.Void);
        }

        /// <summary>
        /// Initializes one or more #GDate structs to a sane but invalid
        /// state. The cleared dates will not represent an existing date, but will
        /// not contain garbage. Useful to init a date declared on the stack.
        /// Validity can be tested with g_date_valid().
        /// </summary>
        /// <param name="date">
        /// pointer to one or more dates to clear
        /// </param>
        /// <param name="nDates">
        /// number of dates to clear
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_clear( System.IntPtr date,  System.UInt32 nDates);

        /// <summary>
        /// Initializes one or more #GDate structs to a sane but invalid
        /// state. The cleared dates will not represent an existing date, but will
        /// not contain garbage. Useful to init a date declared on the stack.
        /// Validity can be tested with g_date_valid().
        /// </summary>
        /// <param name="nDates">
        /// number of dates to clear
        /// </param>
        public System.Void Clear( System.UInt32 nDates)
        {
            var ret = g_date_clear(Handle, nDates);
            return default(System.Void);
        }

        /// <summary>
        /// qsort()-style comparison function for dates.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="lhs">
        /// first date to compare
        /// </param>
        /// <param name="rhs">
        /// second date to compare
        /// </param>
        /// <returns>
        /// 0 for equal, less than zero if @lhs is less than @rhs,
        ///     greater than zero if @lhs is greater than @rhs
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_compare( System.IntPtr lhs,  System.IntPtr rhs);

        /// <summary>
        /// qsort()-style comparison function for dates.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="rhs">
        /// second date to compare
        /// </param>
        /// <returns>
        /// 0 for equal, less than zero if @lhs is less than @rhs,
        ///     greater than zero if @lhs is greater than @rhs
        /// </returns>
        public System.Int32 CompareTo( GISharp.GLib.Date rhs)
        {
            if (rhs == null)
            {
                throw new ArgumentNullException("rhs");
            }
            var ret = g_date_compare(Handle, rhs);
            return default(System.Int32);
        }

        public static bool operator <(Date one, Date two)
        {
            return one.CompareTo(two) < 0;
        }

        public static bool operator <=(Date one, Date two)
        {
            return one.CompareTo(two) <= 0;
        }

        public static bool operator >=(Date one, Date two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator >(Date one, Date two)
        {
            return one.CompareTo(two) > 0;
        }

        /// <summary>
        /// Computes the number of days between two dates.
        /// If @date2 is prior to @date1, the returned value is negative.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="date1">
        /// the first date
        /// </param>
        /// <param name="date2">
        /// the second date
        /// </param>
        /// <returns>
        /// the number of days between @date1 and @date2
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_days_between( System.IntPtr date1,  System.IntPtr date2);

        /// <summary>
        /// Computes the number of days between two dates.
        /// If @date2 is prior to @date1, the returned value is negative.
        /// Both dates must be valid.
        /// </summary>
        /// <param name="date2">
        /// the second date
        /// </param>
        /// <returns>
        /// the number of days between @date1 and @date2
        /// </returns>
        public System.Int32 DaysBetween( GISharp.GLib.Date date2)
        {
            if (date2 == null)
            {
                throw new ArgumentNullException("date2");
            }
            var ret = g_date_days_between(Handle, date2);
            return default(System.Int32);
        }

        /// <summary>
        /// Frees a #GDate returned from g_date_new().
        /// </summary>
        /// <param name="date">
        /// a #GDate to free
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_free( System.IntPtr date);

        /// <summary>
        /// Frees a #GDate returned from g_date_new().
        /// </summary>
        protected override System.Void Free()
        {
            var ret = g_date_free(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the day of the month. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to extract the day of the month from
        /// </param>
        /// <returns>
        /// day of the month
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_get_day( System.IntPtr date);

        /// <summary>
        /// Returns the day of the month. The date must be valid.
        /// </summary>
        /// <returns>
        /// day of the month
        /// </returns>
        public GISharp.GLib.DateDay get_Day()
        {
            var ret = g_date_get_day(Handle);
            return default(GISharp.GLib.DateDay);
        }

        /// <summary>
        /// Returns the day of the year, where Jan 1 is the first day of the
        /// year. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to extract day of year from
        /// </param>
        /// <returns>
        /// day of the year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_day_of_year( System.IntPtr date);

        /// <summary>
        /// Returns the day of the year, where Jan 1 is the first day of the
        /// year. The date must be valid.
        /// </summary>
        /// <returns>
        /// day of the year
        /// </returns>
        public System.UInt32 get_DayOfYear()
        {
            var ret = g_date_get_day_of_year(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Returns the week of the year, where weeks are interpreted according
        /// to ISO 8601.
        /// </summary>
        /// <param name="date">
        /// a valid #GDate
        /// </param>
        /// <returns>
        /// ISO 8601 week number of the year.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_iso8601_week_of_year( System.IntPtr date);

        /// <summary>
        /// Returns the week of the year, where weeks are interpreted according
        /// to ISO 8601.
        /// </summary>
        /// <returns>
        /// ISO 8601 week number of the year.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.UInt32 get_Iso8601WeekOfYear()
        {
            var ret = g_date_get_iso8601_week_of_year(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Returns the Julian day or "serial number" of the #GDate. The
        /// Julian day is simply the number of days since January 1, Year 1; i.e.,
        /// January 1, Year 1 is Julian day 1; January 2, Year 1 is Julian day 2,
        /// etc. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to extract the Julian day from
        /// </param>
        /// <returns>
        /// Julian day
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_julian( System.IntPtr date);

        /// <summary>
        /// Returns the Julian day or "serial number" of the #GDate. The
        /// Julian day is simply the number of days since January 1, Year 1; i.e.,
        /// January 1, Year 1 is Julian day 1; January 2, Year 1 is Julian day 2,
        /// etc. The date must be valid.
        /// </summary>
        /// <returns>
        /// Julian day
        /// </returns>
        public System.UInt32 get_Julian()
        {
            var ret = g_date_get_julian(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Returns the week of the year, where weeks are understood to start on
        /// Monday. If the date is before the first Monday of the year, return
        /// 0. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// week of the year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_monday_week_of_year( System.IntPtr date);

        /// <summary>
        /// Returns the week of the year, where weeks are understood to start on
        /// Monday. If the date is before the first Monday of the year, return
        /// 0. The date must be valid.
        /// </summary>
        /// <returns>
        /// week of the year
        /// </returns>
        public System.UInt32 get_MondayWeekOfYear()
        {
            var ret = g_date_get_monday_week_of_year(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Returns the month of the year. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to get the month from
        /// </param>
        /// <returns>
        /// month of the year as a #GDateMonth
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_get_month( System.IntPtr date);

        /// <summary>
        /// Returns the month of the year. The date must be valid.
        /// </summary>
        /// <returns>
        /// month of the year as a #GDateMonth
        /// </returns>
        public GISharp.GLib.DateMonth get_Month()
        {
            var ret = g_date_get_month(Handle);
            return default(GISharp.GLib.DateMonth);
        }

        /// <summary>
        /// Returns the week of the year during which this date falls, if weeks
        /// are understood to being on Sunday. The date must be valid. Can return
        /// 0 if the day is before the first Sunday of the year.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// week number
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_get_sunday_week_of_year( System.IntPtr date);

        /// <summary>
        /// Returns the week of the year during which this date falls, if weeks
        /// are understood to being on Sunday. The date must be valid. Can return
        /// 0 if the day is before the first Sunday of the year.
        /// </summary>
        /// <returns>
        /// week number
        /// </returns>
        public System.UInt32 get_SundayWeekOfYear()
        {
            var ret = g_date_get_sunday_week_of_year(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Returns the day of the week for a #GDate. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// day of the week as a #GDateWeekday.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_get_weekday( System.IntPtr date);

        /// <summary>
        /// Returns the day of the week for a #GDate. The date must be valid.
        /// </summary>
        /// <returns>
        /// day of the week as a #GDateWeekday.
        /// </returns>
        public GISharp.GLib.DateWeekday get_Weekday()
        {
            var ret = g_date_get_weekday(Handle);
            return default(GISharp.GLib.DateWeekday);
        }

        /// <summary>
        /// Returns the year of a #GDate. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <returns>
        /// year in which the date falls
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_get_year( System.IntPtr date);

        /// <summary>
        /// Returns the year of a #GDate. The date must be valid.
        /// </summary>
        /// <returns>
        /// year in which the date falls
        /// </returns>
        public GISharp.GLib.DateYear get_Year()
        {
            var ret = g_date_get_year(Handle);
            return default(GISharp.GLib.DateYear);
        }

        /// <summary>
        /// Returns %TRUE if the date is on the first of a month.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to check
        /// </param>
        /// <returns>
        /// %TRUE if the date is the first of the month
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_is_first_of_month( System.IntPtr date);

        /// <summary>
        /// Returns %TRUE if the date is on the first of a month.
        /// The date must be valid.
        /// </summary>
        /// <returns>
        /// %TRUE if the date is the first of the month
        /// </returns>
        public System.Boolean get_IsFirstOfMonth()
        {
            var ret = g_date_is_first_of_month(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the date is the last day of the month.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to check
        /// </param>
        /// <returns>
        /// %TRUE if the date is the last day of the month
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_is_last_of_month( System.IntPtr date);

        /// <summary>
        /// Returns %TRUE if the date is the last day of the month.
        /// The date must be valid.
        /// </summary>
        /// <returns>
        /// %TRUE if the date is the last day of the month
        /// </returns>
        public System.Boolean get_IsLastOfMonth()
        {
            var ret = g_date_is_last_of_month(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Checks if @date1 is less than or equal to @date2,
        /// and swap the values if this is not the case.
        /// </summary>
        /// <param name="date1">
        /// the first date
        /// </param>
        /// <param name="date2">
        /// the second date
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_order( System.IntPtr date1,  System.IntPtr date2);

        /// <summary>
        /// Checks if @date1 is less than or equal to @date2,
        /// and swap the values if this is not the case.
        /// </summary>
        /// <param name="date2">
        /// the second date
        /// </param>
        public System.Void Order( GISharp.GLib.Date date2)
        {
            if (date2 == null)
            {
                throw new ArgumentNullException("date2");
            }
            var ret = g_date_order(Handle, date2);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the day of the month for a #GDate. If the resulting
        /// day-month-year triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="day">
        /// day to set
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_set_day( System.IntPtr date,  System.IntPtr day);

        /// <summary>
        /// Sets the day of the month for a #GDate. If the resulting
        /// day-month-year triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="value">
        /// day to set
        /// </param>
        public System.Void set_Day( GISharp.GLib.DateDay value)
        {
            var ret = g_date_set_day(Handle, day);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the value of a #GDate from a day, month, and year.
        /// The day-month-year triplet must be valid; if you aren't
        /// sure it is, call g_date_valid_dmy() to check before you
        /// set it.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="y">
        /// year
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_set_dmy( System.IntPtr date,  System.IntPtr day,  System.IntPtr month,  System.IntPtr y);

        /// <summary>
        /// Sets the value of a #GDate from a day, month, and year.
        /// The day-month-year triplet must be valid; if you aren't
        /// sure it is, call g_date_valid_dmy() to check before you
        /// set it.
        /// </summary>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="y">
        /// year
        /// </param>
        public System.Void SetDmy( GISharp.GLib.DateDay day,  GISharp.GLib.DateMonth month,  GISharp.GLib.DateYear y)
        {
            var ret = g_date_set_dmy(Handle, day, month, y);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the value of a #GDate from a Julian day number.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="julianDate">
        /// Julian day number (days since January 1, Year 1)
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_set_julian( System.IntPtr date,  System.UInt32 julianDate);

        /// <summary>
        /// Sets the value of a #GDate from a Julian day number.
        /// </summary>
        /// <param name="value">
        /// Julian day number (days since January 1, Year 1)
        /// </param>
        public System.Void set_Julian( System.UInt32 value)
        {
            var ret = g_date_set_julian(Handle, julianDate);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the month of the year for a #GDate.  If the resulting
        /// day-month-year triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="month">
        /// month to set
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_set_month( System.IntPtr date,  System.IntPtr month);

        /// <summary>
        /// Sets the month of the year for a #GDate.  If the resulting
        /// day-month-year triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="value">
        /// month to set
        /// </param>
        public System.Void set_Month( GISharp.GLib.DateMonth value)
        {
            var ret = g_date_set_month(Handle, month);
            return default(System.Void);
        }

        /// <summary>
        /// Parses a user-inputted string @str, and try to figure out what date it
        /// represents, taking the [current locale][setlocale] into account. If the
        /// string is successfully parsed, the date will be valid after the call.
        /// Otherwise, it will be invalid. You should check using g_date_valid()
        /// to see whether the parsing succeeded.
        /// </summary>
        /// <remarks>
        /// This function is not appropriate for file formats and the like; it
        /// isn't very precise, and its exact behavior varies with the locale.
        /// It's intended to be a heuristic routine that guesses what the user
        /// means by a given string (and it does work pretty well in that
        /// capacity).
        /// </remarks>
        /// <param name="date">
        /// a #GDate to fill in
        /// </param>
        /// <param name="str">
        /// string to parse
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_set_parse( System.IntPtr date,  System.IntPtr str);

        /// <summary>
        /// Parses a user-inputted string @str, and try to figure out what date it
        /// represents, taking the [current locale][setlocale] into account. If the
        /// string is successfully parsed, the date will be valid after the call.
        /// Otherwise, it will be invalid. You should check using g_date_valid()
        /// to see whether the parsing succeeded.
        /// </summary>
        /// <remarks>
        /// This function is not appropriate for file formats and the like; it
        /// isn't very precise, and its exact behavior varies with the locale.
        /// It's intended to be a heuristic routine that guesses what the user
        /// means by a given string (and it does work pretty well in that
        /// capacity).
        /// </remarks>
        /// <param name="str">
        /// string to parse
        /// </param>
        public System.Void SetParse( System.String str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            var ret = g_date_set_parse(Handle, str);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the value of a date from a #GTimeVal value.  Note that the
        /// @tv_usec member is ignored, because #GDate can't make use of the
        /// additional precision.
        /// </summary>
        /// <remarks>
        /// The time to date conversion is done using the user's current timezone.
        /// </remarks>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="timeval">
        /// #GTimeVal value to set
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_set_time_val( System.IntPtr date,  System.IntPtr timeval);

        /// <summary>
        /// Sets the value of a date from a #GTimeVal value.  Note that the
        /// @tv_usec member is ignored, because #GDate can't make use of the
        /// additional precision.
        /// </summary>
        /// <remarks>
        /// The time to date conversion is done using the user's current timezone.
        /// </remarks>
        /// <param name="timeval">
        /// #GTimeVal value to set
        /// </param>
        [GISharp.Core.Since("2.10")]
        public System.Void SetTimeVal( GISharp.GLib.TimeVal timeval)
        {
            var ret = g_date_set_time_val(Handle, timeval);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the year for a #GDate. If the resulting day-month-year
        /// triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="date">
        /// a #GDate
        /// </param>
        /// <param name="year">
        /// year to set
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_set_year( System.IntPtr date,  System.IntPtr year);

        /// <summary>
        /// Sets the year for a #GDate. If the resulting day-month-year
        /// triplet is invalid, the date will be invalid.
        /// </summary>
        /// <param name="value">
        /// year to set
        /// </param>
        public System.Void set_Year( GISharp.GLib.DateYear value)
        {
            var ret = g_date_set_year(Handle, year);
            return default(System.Void);
        }

        /// <summary>
        /// Moves a date some number of days into the past.
        /// To move by weeks, just move by weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to decrement
        /// </param>
        /// <param name="nDays">
        /// number of days to move
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_subtract_days( System.IntPtr date,  System.UInt32 nDays);

        /// <summary>
        /// Moves a date some number of days into the past.
        /// To move by weeks, just move by weeks*7 days.
        /// The date must be valid.
        /// </summary>
        /// <param name="nDays">
        /// number of days to move
        /// </param>
        public System.Void SubtractDays( System.UInt32 nDays)
        {
            var ret = g_date_subtract_days(Handle, nDays);
            return default(System.Void);
        }

        /// <summary>
        /// Moves a date some number of months into the past.
        /// If the current day of the month doesn't exist in
        /// the destination month, the day of the month
        /// may change. The date must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to decrement
        /// </param>
        /// <param name="nMonths">
        /// number of months to move
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_subtract_months( System.IntPtr date,  System.UInt32 nMonths);

        /// <summary>
        /// Moves a date some number of months into the past.
        /// If the current day of the month doesn't exist in
        /// the destination month, the day of the month
        /// may change. The date must be valid.
        /// </summary>
        /// <param name="nMonths">
        /// number of months to move
        /// </param>
        public System.Void SubtractMonths( System.UInt32 nMonths)
        {
            var ret = g_date_subtract_months(Handle, nMonths);
            return default(System.Void);
        }

        /// <summary>
        /// Moves a date some number of years into the past.
        /// If the current day doesn't exist in the destination
        /// year (i.e. it's February 29 and you move to a non-leap-year)
        /// then the day is changed to February 29. The date
        /// must be valid.
        /// </summary>
        /// <param name="date">
        /// a #GDate to decrement
        /// </param>
        /// <param name="nYears">
        /// number of years to move
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_subtract_years( System.IntPtr date,  System.UInt32 nYears);

        /// <summary>
        /// Moves a date some number of years into the past.
        /// If the current day doesn't exist in the destination
        /// year (i.e. it's February 29 and you move to a non-leap-year)
        /// then the day is changed to February 29. The date
        /// must be valid.
        /// </summary>
        /// <param name="nYears">
        /// number of years to move
        /// </param>
        public System.Void SubtractYears( System.UInt32 nYears)
        {
            var ret = g_date_subtract_years(Handle, nYears);
            return default(System.Void);
        }

        /// <summary>
        /// Fills in the date-related bits of a struct tm using the @date value.
        /// Initializes the non-date parts with something sane but meaningless.
        /// </summary>
        /// <param name="date">
        /// a #GDate to set the struct tm from
        /// </param>
        /// <param name="tm">
        /// struct tm to fill
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_to_struct_tm( System.IntPtr date,  System.IntPtr tm);

        /// <summary>
        /// Fills in the date-related bits of a struct tm using the @date value.
        /// Initializes the non-date parts with something sane but meaningless.
        /// </summary>
        /// <param name="tm">
        /// struct tm to fill
        /// </param>
        public System.Void ToStructTm( System.IntPtr tm)
        {
            var ret = g_date_to_struct_tm(Handle, tm);
            return default(System.Void);
        }

        /// <summary>
        /// Returns %TRUE if the #GDate represents an existing day. The date must not
        /// contain garbage; it should have been initialized with g_date_clear()
        /// if it wasn't allocated by one of the g_date_new() variants.
        /// </summary>
        /// <param name="date">
        /// a #GDate to check
        /// </param>
        /// <returns>
        /// Whether the date is valid
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid( System.IntPtr date);

        /// <summary>
        /// Returns %TRUE if the #GDate represents an existing day. The date must not
        /// contain garbage; it should have been initialized with g_date_clear()
        /// if it wasn't allocated by one of the g_date_new() variants.
        /// </summary>
        /// <returns>
        /// Whether the date is valid
        /// </returns>
        public System.Boolean Valid()
        {
            var ret = g_date_valid(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the number of days in a month, taking leap
        /// years into account.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// number of days in @month during the @year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Byte g_date_get_days_in_month( System.IntPtr month,  System.IntPtr year);

        /// <summary>
        /// Returns the number of days in a month, taking leap
        /// years into account.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// number of days in @month during the @year
        /// </returns>
        public static System.Byte GetDaysInMonth( GISharp.GLib.DateMonth month,  GISharp.GLib.DateYear year)
        {
            var ret = g_date_get_days_in_month(month, year);
            return default(System.Byte);
        }

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Monday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Mondays are in the year, i.e. there are 53 Mondays if
        /// one of the extra days happens to be a Monday.)
        /// </summary>
        /// <param name="year">
        /// a year
        /// </param>
        /// <returns>
        /// number of Mondays in the year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Byte g_date_get_monday_weeks_in_year( System.IntPtr year);

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Monday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Mondays are in the year, i.e. there are 53 Mondays if
        /// one of the extra days happens to be a Monday.)
        /// </summary>
        /// <param name="year">
        /// a year
        /// </param>
        /// <returns>
        /// number of Mondays in the year
        /// </returns>
        public static System.Byte GetMondayWeeksInYear( GISharp.GLib.DateYear year)
        {
            var ret = g_date_get_monday_weeks_in_year(year);
            return default(System.Byte);
        }

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Sunday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Sundays are in the year, i.e. there are 53 Sundays if
        /// one of the extra days happens to be a Sunday.)
        /// </summary>
        /// <param name="year">
        /// year to count weeks in
        /// </param>
        /// <returns>
        /// the number of weeks in @year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Byte g_date_get_sunday_weeks_in_year( System.IntPtr year);

        /// <summary>
        /// Returns the number of weeks in the year, where weeks
        /// are taken to start on Sunday. Will be 52 or 53. The
        /// date must be valid. (Years always have 52 7-day periods,
        /// plus 1 or 2 extra days depending on whether it's a leap
        /// year. This function is basically telling you how many
        /// Sundays are in the year, i.e. there are 53 Sundays if
        /// one of the extra days happens to be a Sunday.)
        /// </summary>
        /// <param name="year">
        /// year to count weeks in
        /// </param>
        /// <returns>
        /// the number of weeks in @year
        /// </returns>
        public static System.Byte GetSundayWeeksInYear( GISharp.GLib.DateYear year)
        {
            var ret = g_date_get_sunday_weeks_in_year(year);
            return default(System.Byte);
        }

        /// <summary>
        /// Returns %TRUE if the year is a leap year.
        /// </summary>
        /// <remarks>
        /// For the purposes of this function, leap year is every year
        /// divisible by 4 unless that year is divisible by 100. If it
        /// is divisible by 100 it would be a leap year only if that year
        /// is also divisible by 400.
        /// </remarks>
        /// <param name="year">
        /// year to check
        /// </param>
        /// <returns>
        /// %TRUE if the year is a leap year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_is_leap_year( System.IntPtr year);

        /// <summary>
        /// Returns %TRUE if the year is a leap year.
        /// </summary>
        /// <remarks>
        /// For the purposes of this function, leap year is every year
        /// divisible by 4 unless that year is divisible by 100. If it
        /// is divisible by 100 it would be a leap year only if that year
        /// is also divisible by 400.
        /// </remarks>
        /// <param name="year">
        /// year to check
        /// </param>
        /// <returns>
        /// %TRUE if the year is a leap year
        /// </returns>
        public static System.Boolean IsLeapYear( GISharp.GLib.DateYear year)
        {
            var ret = g_date_is_leap_year(year);
            return default(System.Boolean);
        }

        /// <summary>
        /// Generates a printed representation of the date, in a
        /// [locale][setlocale]-specific way.
        /// Works just like the platform's C library strftime() function,
        /// but only accepts date-related formats; time-related formats
        /// give undefined results. Date must be valid. Unlike strftime()
        /// (which uses the locale encoding), works on a UTF-8 format
        /// string and stores a UTF-8 result.
        /// </summary>
        /// <remarks>
        /// This function does not provide any conversion specifiers in
        /// addition to those implemented by the platform's C library.
        /// For example, don't expect that using g_date_strftime() would
        /// make the \%F provided by the C99 strftime() work on Windows
        /// where the C library only complies to C89.
        /// </remarks>
        /// <param name="s">
        /// destination buffer
        /// </param>
        /// <param name="slen">
        /// buffer size
        /// </param>
        /// <param name="format">
        /// format string
        /// </param>
        /// <param name="date">
        /// valid #GDate
        /// </param>
        /// <returns>
        /// number of characters written to the buffer, or 0 the buffer was too small
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_date_strftime( System.IntPtr s,  System.UInt64 slen,  System.IntPtr format,  System.IntPtr date);

        /// <summary>
        /// Generates a printed representation of the date, in a
        /// [locale][setlocale]-specific way.
        /// Works just like the platform's C library strftime() function,
        /// but only accepts date-related formats; time-related formats
        /// give undefined results. Date must be valid. Unlike strftime()
        /// (which uses the locale encoding), works on a UTF-8 format
        /// string and stores a UTF-8 result.
        /// </summary>
        /// <remarks>
        /// This function does not provide any conversion specifiers in
        /// addition to those implemented by the platform's C library.
        /// For example, don't expect that using g_date_strftime() would
        /// make the \%F provided by the C99 strftime() work on Windows
        /// where the C library only complies to C89.
        /// </remarks>
        /// <param name="s">
        /// destination buffer
        /// </param>
        /// <param name="slen">
        /// buffer size
        /// </param>
        /// <param name="format">
        /// format string
        /// </param>
        /// <param name="date">
        /// valid #GDate
        /// </param>
        /// <returns>
        /// number of characters written to the buffer, or 0 the buffer was too small
        /// </returns>
        public static System.UInt64 Strftime( System.String s,  System.UInt64 slen,  System.String format,  GISharp.GLib.Date date)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            if (date == null)
            {
                throw new ArgumentNullException("date");
            }
            var ret = g_date_strftime(s, slen, format, date);
            return default(System.UInt64);
        }

        /// <summary>
        /// Returns %TRUE if the day of the month is valid (a day is valid if it's
        /// between 1 and 31 inclusive).
        /// </summary>
        /// <param name="day">
        /// day to check
        /// </param>
        /// <returns>
        /// %TRUE if the day is valid
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_day( System.IntPtr day);

        /// <summary>
        /// Returns %TRUE if the day of the month is valid (a day is valid if it's
        /// between 1 and 31 inclusive).
        /// </summary>
        /// <param name="day">
        /// day to check
        /// </param>
        /// <returns>
        /// %TRUE if the day is valid
        /// </returns>
        public static System.Boolean ValidDay( GISharp.GLib.DateDay day)
        {
            var ret = g_date_valid_day(day);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the day-month-year triplet forms a valid, existing day
        /// in the range of days #GDate understands (Year 1 or later, no more than
        /// a few thousand years in the future).
        /// </summary>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the date is a valid one
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_dmy( System.IntPtr day,  System.IntPtr month,  System.IntPtr year);

        /// <summary>
        /// Returns %TRUE if the day-month-year triplet forms a valid, existing day
        /// in the range of days #GDate understands (Year 1 or later, no more than
        /// a few thousand years in the future).
        /// </summary>
        /// <param name="day">
        /// day
        /// </param>
        /// <param name="month">
        /// month
        /// </param>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the date is a valid one
        /// </returns>
        public static System.Boolean ValidDmy( GISharp.GLib.DateDay day,  GISharp.GLib.DateMonth month,  GISharp.GLib.DateYear year)
        {
            var ret = g_date_valid_dmy(day, month, year);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the Julian day is valid. Anything greater than zero
        /// is basically a valid Julian, though there is a 32-bit limit.
        /// </summary>
        /// <param name="julianDate">
        /// Julian day to check
        /// </param>
        /// <returns>
        /// %TRUE if the Julian day is valid
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_julian( System.UInt32 julianDate);

        /// <summary>
        /// Returns %TRUE if the Julian day is valid. Anything greater than zero
        /// is basically a valid Julian, though there is a 32-bit limit.
        /// </summary>
        /// <param name="julianDate">
        /// Julian day to check
        /// </param>
        /// <returns>
        /// %TRUE if the Julian day is valid
        /// </returns>
        public static System.Boolean ValidJulian( System.UInt32 julianDate)
        {
            var ret = g_date_valid_julian(julianDate);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the month value is valid. The 12 #GDateMonth
        /// enumeration values are the only valid months.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <returns>
        /// %TRUE if the month is valid
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_month( System.IntPtr month);

        /// <summary>
        /// Returns %TRUE if the month value is valid. The 12 #GDateMonth
        /// enumeration values are the only valid months.
        /// </summary>
        /// <param name="month">
        /// month
        /// </param>
        /// <returns>
        /// %TRUE if the month is valid
        /// </returns>
        public static System.Boolean ValidMonth( GISharp.GLib.DateMonth month)
        {
            var ret = g_date_valid_month(month);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the weekday is valid. The seven #GDateWeekday enumeration
        /// values are the only valid weekdays.
        /// </summary>
        /// <param name="weekday">
        /// weekday
        /// </param>
        /// <returns>
        /// %TRUE if the weekday is valid
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_weekday( System.IntPtr weekday);

        /// <summary>
        /// Returns %TRUE if the weekday is valid. The seven #GDateWeekday enumeration
        /// values are the only valid weekdays.
        /// </summary>
        /// <param name="weekday">
        /// weekday
        /// </param>
        /// <returns>
        /// %TRUE if the weekday is valid
        /// </returns>
        public static System.Boolean ValidWeekday( GISharp.GLib.DateWeekday weekday)
        {
            var ret = g_date_valid_weekday(weekday);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns %TRUE if the year is valid. Any year greater than 0 is valid,
        /// though there is a 16-bit limit to what #GDate will understand.
        /// </summary>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the year is valid
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_valid_year( System.IntPtr year);

        /// <summary>
        /// Returns %TRUE if the year is valid. Any year greater than 0 is valid,
        /// though there is a 16-bit limit to what #GDate will understand.
        /// </summary>
        /// <param name="year">
        /// year
        /// </param>
        /// <returns>
        /// %TRUE if the year is valid
        /// </returns>
        public static System.Boolean ValidYear( GISharp.GLib.DateYear year)
        {
            var ret = g_date_valid_year(year);
            return default(System.Boolean);
        }
    }

    /// <summary>
    /// `GDateTime` is an opaque structure whose members
    /// cannot be accessed directly.
    /// </summary>
    [GISharp.Core.Since("2.26")]
    public partial class DateTime : GISharp.Core.ReferenceCountedOpaque<DateTime>
    {
        public DateTime(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The @year must be between 1 and 9999, @month between 1 and 12 and @day
        /// between 1 and 28, 29, 30 or 31 depending on the month and the year.
        /// 
        /// @hour must be between 0 and 23 and @minute must be between 0 and 59.
        /// 
        /// @seconds must be at least 0.0 and must be strictly less than 60.0.
        /// It will be rounded down to the nearest microsecond.
        /// 
        /// If the given time is not representable in the given time zone (for
        /// example, 02:30 on March 14th 2010 in Toronto, due to daylight savings
        /// time) then the time will be rounded up to the nearest existing time
        /// (in this case, 03:00).  If this matters to you then you should verify
        /// the return value for containing the same as the numbers you gave.
        /// 
        /// In the case that the given time is ambiguous in the given time zone
        /// (for example, 01:30 on November 7th 2010 in Toronto, due to daylight
        /// savings time) then the time falling within standard (ie:
        /// non-daylight) time is taken.
        /// 
        /// It not considered a programmer error for the values to this function
        /// to be out of range, but in the case that they are, the function will
        /// return %NULL.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new( System.IntPtr tz,  System.Int32 year,  System.Int32 month,  System.Int32 day,  System.Int32 hour,  System.Int32 minute,  System.Double seconds);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The @year must be between 1 and 9999, @month between 1 and 12 and @day
        /// between 1 and 28, 29, 30 or 31 depending on the month and the year.
        /// 
        /// @hour must be between 0 and 23 and @minute must be between 0 and 59.
        /// 
        /// @seconds must be at least 0.0 and must be strictly less than 60.0.
        /// It will be rounded down to the nearest microsecond.
        /// 
        /// If the given time is not representable in the given time zone (for
        /// example, 02:30 on March 14th 2010 in Toronto, due to daylight savings
        /// time) then the time will be rounded up to the nearest existing time
        /// (in this case, 03:00).  If this matters to you then you should verify
        /// the return value for containing the same as the numbers you gave.
        /// 
        /// In the case that the given time is ambiguous in the given time zone
        /// (for example, 01:30 on November 7th 2010 in Toronto, due to daylight
        /// savings time) then the time falling within standard (ie:
        /// non-daylight) time is taken.
        /// 
        /// It not considered a programmer error for the values to this function
        /// to be out of range, but in the case that they are, the function will
        /// return %NULL.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public DateTime( GISharp.GLib.TimeZone tz,  System.Int32 year,  System.Int32 month,  System.Int32 day,  System.Int32 hour,  System.Int32 minute,  System.Double seconds) : base(IntPtr.Zero)
        {
            if (tz == null)
            {
                throw new ArgumentNullException("tz");
            }
            var ret = g_date_time_new(tz, year, month, day, hour, minute, seconds);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified timespan to the copy.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="timespan">
        /// a #GTimeSpan
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add( System.IntPtr datetime,  System.IntPtr timespan);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified timespan to the copy.
        /// </summary>
        /// <param name="timespan">
        /// a #GTimeSpan
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime Add( GISharp.GLib.TimeSpan timespan)
        {
            var ret = g_date_time_add(Handle, timespan);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of days to the
        /// copy. Add negative values to subtract days.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="days">
        /// the number of days
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_days( System.IntPtr datetime,  System.Int32 days);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of days to the
        /// copy. Add negative values to subtract days.
        /// </summary>
        /// <param name="days">
        /// the number of days
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddDays( System.Int32 days)
        {
            var ret = g_date_time_add_days(Handle, days);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a new #GDateTime adding the specified values to the current date and
        /// time in @datetime. Add negative values to subtract.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="years">
        /// the number of years to add
        /// </param>
        /// <param name="months">
        /// the number of months to add
        /// </param>
        /// <param name="days">
        /// the number of days to add
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime that should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_full( System.IntPtr datetime,  System.Int32 years,  System.Int32 months,  System.Int32 days,  System.Int32 hours,  System.Int32 minutes,  System.Double seconds);

        /// <summary>
        /// Creates a new #GDateTime adding the specified values to the current date and
        /// time in @datetime. Add negative values to subtract.
        /// </summary>
        /// <param name="years">
        /// the number of years to add
        /// </param>
        /// <param name="months">
        /// the number of months to add
        /// </param>
        /// <param name="days">
        /// the number of days to add
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime that should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddFull( System.Int32 years,  System.Int32 months,  System.Int32 days,  System.Int32 hours,  System.Int32 minutes,  System.Double seconds)
        {
            var ret = g_date_time_add_full(Handle, years, months, days, hours, minutes, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of hours.
        /// Add negative values to subtract hours.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_hours( System.IntPtr datetime,  System.Int32 hours);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of hours.
        /// Add negative values to subtract hours.
        /// </summary>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddHours( System.Int32 hours)
        {
            var ret = g_date_time_add_hours(Handle, hours);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime adding the specified number of minutes.
        /// Add negative values to subtract minutes.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_minutes( System.IntPtr datetime,  System.Int32 minutes);

        /// <summary>
        /// Creates a copy of @datetime adding the specified number of minutes.
        /// Add negative values to subtract minutes.
        /// </summary>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddMinutes( System.Int32 minutes)
        {
            var ret = g_date_time_add_minutes(Handle, minutes);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of months to the
        /// copy. Add negative values to subtract months.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="months">
        /// the number of months
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_months( System.IntPtr datetime,  System.Int32 months);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of months to the
        /// copy. Add negative values to subtract months.
        /// </summary>
        /// <param name="months">
        /// the number of months
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddMonths( System.Int32 months)
        {
            var ret = g_date_time_add_months(Handle, months);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of seconds.
        /// Add negative values to subtract seconds.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_seconds( System.IntPtr datetime,  System.Double seconds);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of seconds.
        /// Add negative values to subtract seconds.
        /// </summary>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddSeconds( System.Double seconds)
        {
            var ret = g_date_time_add_seconds(Handle, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of weeks to the
        /// copy. Add negative values to subtract weeks.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="weeks">
        /// the number of weeks
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_weeks( System.IntPtr datetime,  System.Int32 weeks);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of weeks to the
        /// copy. Add negative values to subtract weeks.
        /// </summary>
        /// <param name="weeks">
        /// the number of weeks
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddWeeks( System.Int32 weeks)
        {
            var ret = g_date_time_add_weeks(Handle, weeks);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of years to the
        /// copy. Add negative values to subtract years.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="years">
        /// the number of years
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_add_years( System.IntPtr datetime,  System.Int32 years);

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of years to the
        /// copy. Add negative values to subtract years.
        /// </summary>
        /// <param name="years">
        /// the number of years
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime AddYears( System.Int32 years)
        {
            var ret = g_date_time_add_years(Handle, years);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Calculates the difference in time between @end and @begin.  The
        /// #GTimeSpan that is returned is effectively @end - @begin (ie:
        /// positive if the first parameter is larger).
        /// </summary>
        /// <param name="end">
        /// a #GDateTime
        /// </param>
        /// <param name="begin">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the difference between the two #GDateTime, as a time
        ///   span expressed in microseconds.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_difference( System.IntPtr end,  System.IntPtr begin);

        /// <summary>
        /// Calculates the difference in time between @end and @begin.  The
        /// #GTimeSpan that is returned is effectively @end - @begin (ie:
        /// positive if the first parameter is larger).
        /// </summary>
        /// <param name="begin">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the difference between the two #GDateTime, as a time
        ///   span expressed in microseconds.
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.TimeSpan Difference( GISharp.GLib.DateTime begin)
        {
            if (begin == null)
            {
                throw new ArgumentNullException("begin");
            }
            var ret = g_date_time_difference(Handle, begin);
            return default(GISharp.GLib.TimeSpan);
        }

        /// <summary>
        /// Creates a newly allocated string representing the requested @format.
        /// </summary>
        /// <remarks>
        /// The format strings understood by this function are a subset of the
        /// strftime() format language as specified by C99.  The \%D, \%U and \%W
        /// conversions are not supported, nor is the 'E' modifier.  The GNU
        /// extensions \%k, \%l, \%s and \%P are supported, however, as are the
        /// '0', '_' and '-' modifiers.
        /// 
        /// In contrast to strftime(), this function always produces a UTF-8
        /// string, regardless of the current locale.  Note that the rendering of
        /// many formats is locale-dependent and may not match the strftime()
        /// output exactly.
        /// 
        /// The following format specifiers are supported:
        /// 
        /// - \%a: the abbreviated weekday name according to the current locale
        /// - \%A: the full weekday name according to the current locale
        /// - \%b: the abbreviated month name according to the current locale
        /// - \%B: the full month name according to the current locale
        /// - \%c: the  preferred date and time rpresentation for the current locale
        /// - \%C: the century number (year/100) as a 2-digit integer (00-99)
        /// - \%d: the day of the month as a decimal number (range 01 to 31)
        /// - \%e: the day of the month as a decimal number (range  1 to 31)
        /// - \%F: equivalent to `%Y-%m-%d` (the ISO 8601 date format)
        /// - \%g: the last two digits of the ISO 8601 week-based year as a
        ///   decimal number (00-99). This works well with \%V and \%u.
        /// - \%G: the ISO 8601 week-based year as a decimal number. This works
        ///   well with \%V and \%u.
        /// - \%h: equivalent to \%b
        /// - \%H: the hour as a decimal number using a 24-hour clock (range 00 to 23)
        /// - \%I: the hour as a decimal number using a 12-hour clock (range 01 to 12)
        /// - \%j: the day of the year as a decimal number (range 001 to 366)
        /// - \%k: the hour (24-hour clock) as a decimal number (range 0 to 23);
        ///   single digits are preceded by a blank
        /// - \%l: the hour (12-hour clock) as a decimal number (range 1 to 12);
        ///   single digits are preceded by a blank
        /// - \%m: the month as a decimal number (range 01 to 12)
        /// - \%M: the minute as a decimal number (range 00 to 59)
        /// - \%p: either "AM" or "PM" according to the given time value, or the
        ///   corresponding  strings for the current locale.  Noon is treated as
        ///   "PM" and midnight as "AM".
        /// - \%P: like \%p but lowercase: "am" or "pm" or a corresponding string for
        ///   the current locale
        /// - \%r: the time in a.m. or p.m. notation
        /// - \%R: the time in 24-hour notation (\%H:\%M)
        /// - \%s: the number of seconds since the Epoch, that is, since 1970-01-01
        ///   00:00:00 UTC
        /// - \%S: the second as a decimal number (range 00 to 60)
        /// - \%t: a tab character
        /// - \%T: the time in 24-hour notation with seconds (\%H:\%M:\%S)
        /// - \%u: the ISO 8601 standard day of the week as a decimal, range 1 to 7,
        ///    Monday being 1. This works well with \%G and \%V.
        /// - \%V: the ISO 8601 standard week number of the current year as a decimal
        ///   number, range 01 to 53, where week 1 is the first week that has at
        ///   least 4 days in the new year. See g_date_time_get_week_of_year().
        ///   This works well with \%G and \%u.
        /// - \%w: the day of the week as a decimal, range 0 to 6, Sunday being 0.
        ///   This is not the ISO 8601 standard format -- use \%u instead.
        /// - \%x: the preferred date representation for the current locale without
        ///   the time
        /// - \%X: the preferred time representation for the current locale without
        ///   the date
        /// - \%y: the year as a decimal number without the century
        /// - \%Y: the year as a decimal number including the century
        /// - \%z: the time zone as an offset from UTC (+hhmm)
        /// - \%:z: the time zone as an offset from UTC (+hh:mm).
        ///   This is a gnulib strftime() extension. Since: 2.38
        /// - \%::z: the time zone as an offset from UTC (+hh:mm:ss). This is a
        ///   gnulib strftime() extension. Since: 2.38
        /// - \%:::z: the time zone as an offset from UTC, with : to necessary
        ///   precision (e.g., -04, +05:30). This is a gnulib strftime() extension. Since: 2.38
        /// - \%Z: the time zone or name or abbreviation
        /// - \%\%: a literal \% character
        /// 
        /// Some conversion specifications can be modified by preceding the
        /// conversion specifier by one or more modifier characters. The
        /// following modifiers are supported for many of the numeric
        /// conversions:
        /// 
        /// - O: Use alternative numeric symbols, if the current locale supports those.
        /// - _: Pad a numeric result with spaces. This overrides the default padding
        ///   for the specifier.
        /// - -: Do not pad a numeric result. This overrides the default padding
        ///   for the specifier.
        /// - 0: Pad a numeric result with zeros. This overrides the default padding
        ///   for the specifier.
        /// </remarks>
        /// <param name="datetime">
        /// A #GDateTime
        /// </param>
        /// <param name="format">
        /// a valid UTF-8 string, containing the format for the
        ///          #GDateTime
        /// </param>
        /// <returns>
        /// a newly allocated string formatted to the requested format
        ///     or %NULL in the case that there was an error. The string
        ///     should be freed with g_free().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_format( System.IntPtr datetime,  System.IntPtr format);

        /// <summary>
        /// Creates a newly allocated string representing the requested @format.
        /// </summary>
        /// <remarks>
        /// The format strings understood by this function are a subset of the
        /// strftime() format language as specified by C99.  The \%D, \%U and \%W
        /// conversions are not supported, nor is the 'E' modifier.  The GNU
        /// extensions \%k, \%l, \%s and \%P are supported, however, as are the
        /// '0', '_' and '-' modifiers.
        /// 
        /// In contrast to strftime(), this function always produces a UTF-8
        /// string, regardless of the current locale.  Note that the rendering of
        /// many formats is locale-dependent and may not match the strftime()
        /// output exactly.
        /// 
        /// The following format specifiers are supported:
        /// 
        /// - \%a: the abbreviated weekday name according to the current locale
        /// - \%A: the full weekday name according to the current locale
        /// - \%b: the abbreviated month name according to the current locale
        /// - \%B: the full month name according to the current locale
        /// - \%c: the  preferred date and time rpresentation for the current locale
        /// - \%C: the century number (year/100) as a 2-digit integer (00-99)
        /// - \%d: the day of the month as a decimal number (range 01 to 31)
        /// - \%e: the day of the month as a decimal number (range  1 to 31)
        /// - \%F: equivalent to `%Y-%m-%d` (the ISO 8601 date format)
        /// - \%g: the last two digits of the ISO 8601 week-based year as a
        ///   decimal number (00-99). This works well with \%V and \%u.
        /// - \%G: the ISO 8601 week-based year as a decimal number. This works
        ///   well with \%V and \%u.
        /// - \%h: equivalent to \%b
        /// - \%H: the hour as a decimal number using a 24-hour clock (range 00 to 23)
        /// - \%I: the hour as a decimal number using a 12-hour clock (range 01 to 12)
        /// - \%j: the day of the year as a decimal number (range 001 to 366)
        /// - \%k: the hour (24-hour clock) as a decimal number (range 0 to 23);
        ///   single digits are preceded by a blank
        /// - \%l: the hour (12-hour clock) as a decimal number (range 1 to 12);
        ///   single digits are preceded by a blank
        /// - \%m: the month as a decimal number (range 01 to 12)
        /// - \%M: the minute as a decimal number (range 00 to 59)
        /// - \%p: either "AM" or "PM" according to the given time value, or the
        ///   corresponding  strings for the current locale.  Noon is treated as
        ///   "PM" and midnight as "AM".
        /// - \%P: like \%p but lowercase: "am" or "pm" or a corresponding string for
        ///   the current locale
        /// - \%r: the time in a.m. or p.m. notation
        /// - \%R: the time in 24-hour notation (\%H:\%M)
        /// - \%s: the number of seconds since the Epoch, that is, since 1970-01-01
        ///   00:00:00 UTC
        /// - \%S: the second as a decimal number (range 00 to 60)
        /// - \%t: a tab character
        /// - \%T: the time in 24-hour notation with seconds (\%H:\%M:\%S)
        /// - \%u: the ISO 8601 standard day of the week as a decimal, range 1 to 7,
        ///    Monday being 1. This works well with \%G and \%V.
        /// - \%V: the ISO 8601 standard week number of the current year as a decimal
        ///   number, range 01 to 53, where week 1 is the first week that has at
        ///   least 4 days in the new year. See g_date_time_get_week_of_year().
        ///   This works well with \%G and \%u.
        /// - \%w: the day of the week as a decimal, range 0 to 6, Sunday being 0.
        ///   This is not the ISO 8601 standard format -- use \%u instead.
        /// - \%x: the preferred date representation for the current locale without
        ///   the time
        /// - \%X: the preferred time representation for the current locale without
        ///   the date
        /// - \%y: the year as a decimal number without the century
        /// - \%Y: the year as a decimal number including the century
        /// - \%z: the time zone as an offset from UTC (+hhmm)
        /// - \%:z: the time zone as an offset from UTC (+hh:mm).
        ///   This is a gnulib strftime() extension. Since: 2.38
        /// - \%::z: the time zone as an offset from UTC (+hh:mm:ss). This is a
        ///   gnulib strftime() extension. Since: 2.38
        /// - \%:::z: the time zone as an offset from UTC, with : to necessary
        ///   precision (e.g., -04, +05:30). This is a gnulib strftime() extension. Since: 2.38
        /// - \%Z: the time zone or name or abbreviation
        /// - \%\%: a literal \% character
        /// 
        /// Some conversion specifications can be modified by preceding the
        /// conversion specifier by one or more modifier characters. The
        /// following modifiers are supported for many of the numeric
        /// conversions:
        /// 
        /// - O: Use alternative numeric symbols, if the current locale supports those.
        /// - _: Pad a numeric result with spaces. This overrides the default padding
        ///   for the specifier.
        /// - -: Do not pad a numeric result. This overrides the default padding
        ///   for the specifier.
        /// - 0: Pad a numeric result with zeros. This overrides the default padding
        ///   for the specifier.
        /// </remarks>
        /// <param name="format">
        /// a valid UTF-8 string, containing the format for the
        ///          #GDateTime
        /// </param>
        /// <returns>
        /// a newly allocated string formatted to the requested format
        ///     or %NULL in the case that there was an error. The string
        ///     should be freed with g_free().
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.String Format( System.String format)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            var ret = g_date_time_format(Handle, format);
            return default(System.String);
        }

        /// <summary>
        /// Retrieves the day of the month represented by @datetime in the gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the month
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_day_of_month( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the day of the month represented by @datetime in the gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the day of the month
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_DayOfMonth()
        {
            var ret = g_date_time_get_day_of_month(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the ISO 8601 day of the week on which @datetime falls (1 is
        /// Monday, 2 is Tuesday... 7 is Sunday).
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the week
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_day_of_week( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the ISO 8601 day of the week on which @datetime falls (1 is
        /// Monday, 2 is Tuesday... 7 is Sunday).
        /// </summary>
        /// <returns>
        /// the day of the week
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_DayOfWeek()
        {
            var ret = g_date_time_get_day_of_week(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the day of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the year
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_day_of_year( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the day of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the day of the year
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_DayOfYear()
        {
            var ret = g_date_time_get_day_of_year(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the hour of the day represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the hour of the day
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_hour( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the hour of the day represented by @datetime
        /// </summary>
        /// <returns>
        /// the hour of the day
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_Hour()
        {
            var ret = g_date_time_get_hour(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the microsecond of the date represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the microsecond of the second
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_microsecond( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the microsecond of the date represented by @datetime
        /// </summary>
        /// <returns>
        /// the microsecond of the second
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_Microsecond()
        {
            var ret = g_date_time_get_microsecond(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the minute of the hour represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the minute of the hour
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_minute( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the minute of the hour represented by @datetime
        /// </summary>
        /// <returns>
        /// the minute of the hour
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_Minute()
        {
            var ret = g_date_time_get_minute(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the month of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the month represented by @datetime
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_month( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the month of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the month represented by @datetime
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_Month()
        {
            var ret = g_date_time_get_month(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the second of the minute represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the second represented by @datetime
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_second( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the second of the minute represented by @datetime
        /// </summary>
        /// <returns>
        /// the second represented by @datetime
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_Second()
        {
            var ret = g_date_time_get_second(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the number of seconds since the start of the last minute,
        /// including the fractional part.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the number of seconds
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Double g_date_time_get_seconds( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the number of seconds since the start of the last minute,
        /// including the fractional part.
        /// </summary>
        /// <returns>
        /// the number of seconds
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Double get_Seconds()
        {
            var ret = g_date_time_get_seconds(Handle);
            return default(System.Double);
        }

        /// <summary>
        /// Determines the time zone abbreviation to be used at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings
        /// time is in effect.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the time zone abbreviation. The returned
        ///          string is owned by the #GDateTime and it should not be
        ///          modified or freed
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_get_timezone_abbreviation( System.IntPtr datetime);

        /// <summary>
        /// Determines the time zone abbreviation to be used at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings
        /// time is in effect.
        /// </remarks>
        /// <returns>
        /// the time zone abbreviation. The returned
        ///          string is owned by the #GDateTime and it should not be
        ///          modified or freed
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.String get_TimezoneAbbreviation()
        {
            var ret = g_date_time_get_timezone_abbreviation(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Determines the offset to UTC in effect at the time and in the time
        /// zone of @datetime.
        /// </summary>
        /// <remarks>
        /// The offset is the number of microseconds that you add to UTC time to
        /// arrive at local time for the time zone (ie: negative numbers for time
        /// zones west of GMT, positive numbers for east).
        /// 
        /// If @datetime represents UTC time, then the offset is always zero.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the number of microseconds that should be added to UTC to
        ///          get the local time
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_get_utc_offset( System.IntPtr datetime);

        /// <summary>
        /// Determines the offset to UTC in effect at the time and in the time
        /// zone of @datetime.
        /// </summary>
        /// <remarks>
        /// The offset is the number of microseconds that you add to UTC time to
        /// arrive at local time for the time zone (ie: negative numbers for time
        /// zones west of GMT, positive numbers for east).
        /// 
        /// If @datetime represents UTC time, then the offset is always zero.
        /// </remarks>
        /// <returns>
        /// the number of microseconds that should be added to UTC to
        ///          get the local time
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.TimeSpan get_UtcOffset()
        {
            var ret = g_date_time_get_utc_offset(Handle);
            return default(GISharp.GLib.TimeSpan);
        }

        /// <summary>
        /// Returns the ISO 8601 week-numbering year in which the week containing
        /// @datetime falls.
        /// </summary>
        /// <remarks>
        /// This function, taken together with g_date_time_get_week_of_year() and
        /// g_date_time_get_day_of_week() can be used to determine the full ISO
        /// week date on which @datetime falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// g_date_time_get_year()), except as detailed below:
        /// 
        /// For Thursday, the week-numbering year is always equal to the usual
        /// calendar year.  For other days, the number is such that every day
        /// within a complete week (Monday to Sunday) is contained within the
        /// same week-numbering year.
        /// 
        /// For Monday, Tuesday and Wednesday occurring near the end of the year,
        /// this may mean that the week-numbering year is one greater than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring early in the next year).
        /// 
        /// For Friday, Saturaday and Sunday occurring near the start of the year,
        /// this may mean that the week-numbering year is one less than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring late in the previous year).
        /// 
        /// An equivalent description is that the week-numbering year is equal to
        /// the calendar year containing the majority of the days in the current
        /// week (Monday to Sunday).
        /// 
        /// Note that January 1 0001 in the proleptic Gregorian calendar is a
        /// Monday, so this function never returns 0.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the ISO 8601 week-numbering year for @datetime
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_week_numbering_year( System.IntPtr datetime);

        /// <summary>
        /// Returns the ISO 8601 week-numbering year in which the week containing
        /// @datetime falls.
        /// </summary>
        /// <remarks>
        /// This function, taken together with g_date_time_get_week_of_year() and
        /// g_date_time_get_day_of_week() can be used to determine the full ISO
        /// week date on which @datetime falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// g_date_time_get_year()), except as detailed below:
        /// 
        /// For Thursday, the week-numbering year is always equal to the usual
        /// calendar year.  For other days, the number is such that every day
        /// within a complete week (Monday to Sunday) is contained within the
        /// same week-numbering year.
        /// 
        /// For Monday, Tuesday and Wednesday occurring near the end of the year,
        /// this may mean that the week-numbering year is one greater than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring early in the next year).
        /// 
        /// For Friday, Saturaday and Sunday occurring near the start of the year,
        /// this may mean that the week-numbering year is one less than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring late in the previous year).
        /// 
        /// An equivalent description is that the week-numbering year is equal to
        /// the calendar year containing the majority of the days in the current
        /// week (Monday to Sunday).
        /// 
        /// Note that January 1 0001 in the proleptic Gregorian calendar is a
        /// Monday, so this function never returns 0.
        /// </remarks>
        /// <returns>
        /// the ISO 8601 week-numbering year for @datetime
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_WeekNumberingYear()
        {
            var ret = g_date_time_get_week_numbering_year(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Returns the ISO 8601 week number for the week containing @datetime.
        /// The ISO 8601 week number is the same for every day of the week (from
        /// Moday through Sunday).  That can produce some unusual results
        /// (described below).
        /// </summary>
        /// <remarks>
        /// The first week of the year is week 1.  This is the week that contains
        /// the first Thursday of the year.  Equivalently, this is the first week
        /// that has more than 4 of its days falling within the calendar year.
        /// 
        /// The value 0 is never returned by this function.  Days contained
        /// within a year but occurring before the first ISO 8601 week of that
        /// year are considered as being contained in the last week of the
        /// previous year.  Similarly, the final days of a calendar year may be
        /// considered as being part of the first ISO 8601 week of the next year
        /// if 4 or more days of that week are contained within the new year.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the ISO 8601 week number for @datetime.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_week_of_year( System.IntPtr datetime);

        /// <summary>
        /// Returns the ISO 8601 week number for the week containing @datetime.
        /// The ISO 8601 week number is the same for every day of the week (from
        /// Moday through Sunday).  That can produce some unusual results
        /// (described below).
        /// </summary>
        /// <remarks>
        /// The first week of the year is week 1.  This is the week that contains
        /// the first Thursday of the year.  Equivalently, this is the first week
        /// that has more than 4 of its days falling within the calendar year.
        /// 
        /// The value 0 is never returned by this function.  Days contained
        /// within a year but occurring before the first ISO 8601 week of that
        /// year are considered as being contained in the last week of the
        /// previous year.  Similarly, the final days of a calendar year may be
        /// considered as being part of the first ISO 8601 week of the next year
        /// if 4 or more days of that week are contained within the new year.
        /// </remarks>
        /// <returns>
        /// the ISO 8601 week number for @datetime.
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_WeekOfYear()
        {
            var ret = g_date_time_get_week_of_year(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the year represented by @datetime in the Gregorian calendar.
        /// </summary>
        /// <param name="datetime">
        /// A #GDateTime
        /// </param>
        /// <returns>
        /// the year represented by @datetime
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_get_year( System.IntPtr datetime);

        /// <summary>
        /// Retrieves the year represented by @datetime in the Gregorian calendar.
        /// </summary>
        /// <returns>
        /// the year represented by @datetime
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 get_Year()
        {
            var ret = g_date_time_get_year(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Retrieves the Gregorian day, month, and year of a given #GDateTime.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime.
        /// </param>
        /// <param name="year">
        /// the return location for the gregorian year, or %NULL.
        /// </param>
        /// <param name="month">
        /// the return location for the month of the year, or %NULL.
        /// </param>
        /// <param name="day">
        /// the return location for the day of the month, or %NULL.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_time_get_ymd( System.IntPtr datetime, out System.Int32 year, out System.Int32 month, out System.Int32 day);

        /// <summary>
        /// Retrieves the Gregorian day, month, and year of a given #GDateTime.
        /// </summary>
        /// <param name="year">
        /// the return location for the gregorian year, or %NULL.
        /// </param>
        /// <param name="month">
        /// the return location for the month of the year, or %NULL.
        /// </param>
        /// <param name="day">
        /// the return location for the day of the month, or %NULL.
        /// </param>
        [GISharp.Core.Since("2.26")]
        public System.Void GetYmd(out System.Int32 year, out System.Int32 month, out System.Int32 day)
        {
            var ret = g_date_time_get_ymd(Handle, year, month, day);
            return default(System.Void);
        }

        /// <summary>
        /// Determines if daylight savings time is in effect at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_time_is_daylight_savings( System.IntPtr datetime);

        /// <summary>
        /// Determines if daylight savings time is in effect at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Boolean get_IsDaylightSavings()
        {
            var ret = g_date_time_is_daylight_savings(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Atomically increments the reference count of @datetime by one.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the #GDateTime with the reference count increased
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_ref( System.IntPtr datetime);

        /// <summary>
        /// Atomically increments the reference count of @datetime by one.
        /// </summary>
        /// <returns>
        /// the #GDateTime with the reference count increased
        /// </returns>
        [GISharp.Core.Since("2.26")]
        protected override void Ref()
        {
            var ret = g_date_time_ref(Handle);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_to_local( System.IntPtr datetime);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime ToLocal()
        {
            var ret = g_date_time_to_local(Handle);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Stores the instant in time that @datetime represents into @tv.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the time
        /// zone associated with @datetime.
        /// 
        /// On systems where 'long' is 32bit (ie: all 32bit systems and all
        /// Windows systems), a #GTimeVal is incapable of storing the entire
        /// range of values that #GDateTime is capable of expressing.  On those
        /// systems, this function returns %FALSE to indicate that the time is
        /// out of range.
        /// 
        /// On systems where 'long' is 64bit, this function never fails.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="tv">
        /// a #GTimeVal to modify
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_time_to_timeval( System.IntPtr datetime,  System.IntPtr tv);

        /// <summary>
        /// Stores the instant in time that @datetime represents into @tv.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the time
        /// zone associated with @datetime.
        /// 
        /// On systems where 'long' is 32bit (ie: all 32bit systems and all
        /// Windows systems), a #GTimeVal is incapable of storing the entire
        /// range of values that #GDateTime is capable of expressing.  On those
        /// systems, this function returns %FALSE to indicate that the time is
        /// out of range.
        /// 
        /// On systems where 'long' is 64bit, this function never fails.
        /// </remarks>
        /// <param name="tv">
        /// a #GTimeVal to modify
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Boolean ToTimeval( GISharp.GLib.TimeVal tv)
        {
            var ret = g_date_time_to_timeval(Handle, tv);
            return default(System.Boolean);
        }

        /// <summary>
        /// Create a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// This call can fail in the case that the time goes out of bounds.  For
        /// example, converting 0001-01-01 00:00:00 UTC to a time zone west of
        /// Greenwich will fail (due to the year 0 being out of range).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="tz">
        /// the new #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_to_timezone( System.IntPtr datetime,  System.IntPtr tz);

        /// <summary>
        /// Create a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// This call can fail in the case that the time goes out of bounds.  For
        /// example, converting 0001-01-01 00:00:00 UTC to a time zone west of
        /// Greenwich will fail (due to the year 0 being out of range).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// the new #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime ToTimezone( GISharp.GLib.TimeZone tz)
        {
            if (tz == null)
            {
                throw new ArgumentNullException("tz");
            }
            var ret = g_date_time_to_timezone(Handle, tz);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Gives the Unix time corresponding to @datetime, rounding down to the
        /// nearest second.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the time zone associated with @datetime.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the Unix time corresponding to @datetime
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int64 g_date_time_to_unix( System.IntPtr datetime);

        /// <summary>
        /// Gives the Unix time corresponding to @datetime, rounding down to the
        /// nearest second.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the time zone associated with @datetime.
        /// </remarks>
        /// <returns>
        /// the Unix time corresponding to @datetime
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int64 ToUnix()
        {
            var ret = g_date_time_to_unix(Handle);
            return default(System.Int64);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_to_utc( System.IntPtr datetime);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public GISharp.GLib.DateTime ToUtc()
        {
            var ret = g_date_time_to_utc(Handle);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Atomically decrements the reference count of @datetime by one.
        /// </summary>
        /// <remarks>
        /// When the reference count reaches zero, the resources allocated by
        /// @datetime are freed
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_date_time_unref( System.IntPtr datetime);

        /// <summary>
        /// Atomically decrements the reference count of @datetime by one.
        /// </summary>
        /// <remarks>
        /// When the reference count reaches zero, the resources allocated by
        /// @datetime are freed
        /// </remarks>
        [GISharp.Core.Since("2.26")]
        protected override System.Void Unref()
        {
            var ret = g_date_time_unref(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given #GTimeVal @tv in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the
        /// local time offset.
        /// 
        /// This call can fail (returning %NULL) if @tv represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_from_timeval_local( System.IntPtr tv);

        /// <summary>
        /// Creates a #GDateTime corresponding to the given #GTimeVal @tv in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the
        /// local time offset.
        /// 
        /// This call can fail (returning %NULL) if @tv represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime FromTimevalLocal( GISharp.GLib.TimeVal tv)
        {
            var ret = g_date_time_new_from_timeval_local(tv);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given #GTimeVal @tv in UTC.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @tv represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_from_timeval_utc( System.IntPtr tv);

        /// <summary>
        /// Creates a #GDateTime corresponding to the given #GTimeVal @tv in UTC.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @tv represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime FromTimevalUtc( GISharp.GLib.TimeVal tv)
        {
            var ret = g_date_time_new_from_timeval_utc(tv);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the local time offset.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_from_unix_local( System.Int64 t);

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the local time offset.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime FromUnixLocal( System.Int64 t)
        {
            var ret = g_date_time_new_from_unix_local(t);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in UTC.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_from_unix_utc( System.Int64 t);

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in UTC.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime FromUnixUtc( System.Int64 t)
        {
            var ret = g_date_time_new_from_unix_utc(t);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_local( System.Int32 year,  System.Int32 month,  System.Int32 day,  System.Int32 hour,  System.Int32 minute,  System.Double seconds);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime Local( System.Int32 year,  System.Int32 month,  System.Int32 day,  System.Int32 hour,  System.Int32 minute,  System.Double seconds)
        {
            var ret = g_date_time_new_local(year, month, day, hour, minute, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the given
        /// time zone @tz.  The time is as accurate as the system allows, to a
        /// maximum accuracy of 1 microsecond.
        /// </summary>
        /// <remarks>
        /// This function will always succeed unless the system clock is set to
        /// truly insane values (or unless GLib is still being used after the
        /// year 9999).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_now( System.IntPtr tz);

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the given
        /// time zone @tz.  The time is as accurate as the system allows, to a
        /// maximum accuracy of 1 microsecond.
        /// </summary>
        /// <remarks>
        /// This function will always succeed unless the system clock is set to
        /// truly insane values (or unless GLib is still being used after the
        /// year 9999).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime Now( GISharp.GLib.TimeZone tz)
        {
            if (tz == null)
            {
                throw new ArgumentNullException("tz");
            }
            var ret = g_date_time_new_now(tz);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the local
        /// time zone.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_now_local();

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the local
        /// time zone.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime NowLocal()
        {
            var ret = g_date_time_new_now_local();
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_now_utc();

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime NowUtc()
        {
            var ret = g_date_time_new_now_utc();
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_date_time_new_utc( System.Int32 year,  System.Int32 month,  System.Int32 day,  System.Int32 hour,  System.Int32 minute,  System.Double seconds);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.DateTime Utc( System.Int32 year,  System.Int32 month,  System.Int32 day,  System.Int32 hour,  System.Int32 minute,  System.Double seconds)
        {
            var ret = g_date_time_new_utc(year, month, day, hour, minute, seconds);
            return default(GISharp.GLib.DateTime);
        }

        /// <summary>
        /// A comparison function for #GDateTimes that is suitable
        /// as a #GCompareFunc. Both #GDateTimes must be non-%NULL.
        /// </summary>
        /// <param name="dt1">
        /// first #GDateTime to compare
        /// </param>
        /// <param name="dt2">
        /// second #GDateTime to compare
        /// </param>
        /// <returns>
        /// -1, 0 or 1 if @dt1 is less than, equal to or greater
        ///   than @dt2.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_date_time_compare( System.IntPtr dt1,  System.IntPtr dt2);

        /// <summary>
        /// A comparison function for #GDateTimes that is suitable
        /// as a #GCompareFunc. Both #GDateTimes must be non-%NULL.
        /// </summary>
        /// <param name="dt1">
        /// first #GDateTime to compare
        /// </param>
        /// <param name="dt2">
        /// second #GDateTime to compare
        /// </param>
        /// <returns>
        /// -1, 0 or 1 if @dt1 is less than, equal to or greater
        ///   than @dt2.
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static System.Int32 Compare( System.IntPtr dt1,  System.IntPtr dt2)
        {
            var ret = g_date_time_compare(dt1, dt2);
            return default(System.Int32);
        }

        /// <summary>
        /// Checks to see if @dt1 and @dt2 are equal.
        /// </summary>
        /// <remarks>
        /// Equal here means that they represent the same moment after converting
        /// them to the same time zone.
        /// </remarks>
        /// <param name="dt1">
        /// a #GDateTime
        /// </param>
        /// <param name="dt2">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if @dt1 and @dt2 are equal
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_date_time_equal( System.IntPtr dt1,  System.IntPtr dt2);

        /// <summary>
        /// Checks to see if @dt1 and @dt2 are equal.
        /// </summary>
        /// <remarks>
        /// Equal here means that they represent the same moment after converting
        /// them to the same time zone.
        /// </remarks>
        /// <param name="dt1">
        /// a #GDateTime
        /// </param>
        /// <param name="dt2">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if @dt1 and @dt2 are equal
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static System.Boolean Equal( System.IntPtr dt1,  System.IntPtr dt2)
        {
            var ret = g_date_time_equal(dt1, dt2);
            return default(System.Boolean);
        }

        /// <summary>
        /// Hashes @datetime into a #guint, suitable for use within #GHashTable.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// a #guint containing the hash
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_date_time_hash( System.IntPtr datetime);

        /// <summary>
        /// Hashes @datetime into a #guint, suitable for use within #GHashTable.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// a #guint containing the hash
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static System.UInt32 Hash( System.IntPtr datetime)
        {
            var ret = g_date_time_hash(datetime);
            return default(System.UInt32);
        }
    }

    /// <summary>
    /// The `GError` structure contains information about
    /// an error that has occurred.
    /// </summary>
    public partial class Error : GISharp.Core.OwnedOpaque<Error>
    {
        public Error(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GError; unlike g_error_new(), @message is
        /// not a printf()-style format string. Use this function if
        /// @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_error_new_literal( System.IntPtr domain,  System.Int32 code,  System.IntPtr message);

        /// <summary>
        /// Creates a new #GError; unlike g_error_new(), @message is
        /// not a printf()-style format string. Use this function if
        /// @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        public Error( GISharp.GLib.Quark domain,  System.Int32 code,  System.String message) : base(IntPtr.Zero)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            var ret = g_error_new_literal(domain, code, message);
        }

        /// <summary>
        /// Creates a new #GError with the given @domain and @code,
        /// and a message formatted with @format.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="format">
        /// printf()-style format for error message
        /// </param>
        /// <param name="args">
        /// #va_list of parameters for the message format
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_error_new_valist( System.IntPtr domain,  System.Int32 code,  System.IntPtr format,  System.IntPtr args);

        /// <summary>
        /// Creates a new #GError with the given @domain and @code,
        /// and a message formatted with @format.
        /// </summary>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="format">
        /// printf()-style format for error message
        /// </param>
        /// <param name="args">
        /// #va_list of parameters for the message format
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [GISharp.Core.Since("2.22")]
        public Error( GISharp.GLib.Quark domain,  System.Int32 code,  System.String format,  System.Object[] args) : base(IntPtr.Zero)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }
            var ret = g_error_new_valist(domain, code, format, args);
        }

        /// <summary>
        /// Makes a copy of @error.
        /// </summary>
        /// <param name="error">
        /// a #GError
        /// </param>
        /// <returns>
        /// a new #GError
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_error_copy( System.IntPtr error);

        /// <summary>
        /// Makes a copy of @error.
        /// </summary>
        /// <returns>
        /// a new #GError
        /// </returns>
        public override GISharp.GLib.Error Copy()
        {
            var ret = g_error_copy(Handle);
            return default(GISharp.GLib.Error);
        }

        /// <summary>
        /// Frees a #GError and associated resources.
        /// </summary>
        /// <param name="error">
        /// a #GError
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_error_free( System.IntPtr error);

        /// <summary>
        /// Frees a #GError and associated resources.
        /// </summary>
        protected override System.Void Free()
        {
            var ret = g_error_free(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Returns %TRUE if @error matches @domain and @code, %FALSE
        /// otherwise. In particular, when @error is %NULL, %FALSE will
        /// be returned.
        /// </summary>
        /// <remarks>
        /// If @domain contains a `FAILED` (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should
        /// instead treat any not-explicitly-recognized error code as being
        /// equilalent to the `FAILED` code. This way, if the domain is
        /// extended in the future to provide a more specific error code for
        /// a certain case, your code will still work.
        /// </remarks>
        /// <param name="error">
        /// a #GError or %NULL
        /// </param>
        /// <param name="domain">
        /// an error domain
        /// </param>
        /// <param name="code">
        /// an error code
        /// </param>
        /// <returns>
        /// whether @error has @domain and @code
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_error_matches( System.IntPtr error,  System.IntPtr domain,  System.Int32 code);

        /// <summary>
        /// Returns %TRUE if @error matches @domain and @code, %FALSE
        /// otherwise. In particular, when @error is %NULL, %FALSE will
        /// be returned.
        /// </summary>
        /// <remarks>
        /// If @domain contains a `FAILED` (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should
        /// instead treat any not-explicitly-recognized error code as being
        /// equilalent to the `FAILED` code. This way, if the domain is
        /// extended in the future to provide a more specific error code for
        /// a certain case, your code will still work.
        /// </remarks>
        /// <param name="domain">
        /// an error domain
        /// </param>
        /// <param name="code">
        /// an error code
        /// </param>
        /// <returns>
        /// whether @error has @domain and @code
        /// </returns>
        public System.Boolean Matches( GISharp.GLib.Quark domain,  System.Int32 code)
        {
            var ret = g_error_matches(Handle, domain, code);
            return default(System.Boolean);
        }

        /// <summary>
        /// Does nothing if @err is %NULL; if @err is non-%NULL, then *@err
        /// must be %NULL. A new #GError is created and assigned to *@err.
        /// Unlike g_set_error(), @message is not a printf()-style format string.
        /// Use this function if @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="err">
        /// a return location for a #GError, or %NULL
        /// </param>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_set_error_literal( System.IntPtr err,  System.IntPtr domain,  System.Int32 code,  System.IntPtr message);

        /// <summary>
        /// Does nothing if @err is %NULL; if @err is non-%NULL, then *@err
        /// must be %NULL. A new #GError is created and assigned to *@err.
        /// Unlike g_set_error(), @message is not a printf()-style format string.
        /// Use this function if @message contains text you don't have control over,
        /// that could include printf() escape sequences.
        /// </summary>
        /// <param name="err">
        /// a return location for a #GError, or %NULL
        /// </param>
        /// <param name="domain">
        /// error domain
        /// </param>
        /// <param name="code">
        /// error code
        /// </param>
        /// <param name="message">
        /// error message
        /// </param>
        [GISharp.Core.Since("2.18")]
        public static System.Void SetErrorLiteral( GISharp.GLib.Error err,  GISharp.GLib.Quark domain,  System.Int32 code,  System.String message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            var ret = g_set_error_literal(err, domain, code, message);
            return default(System.Void);
        }

        /// <summary>
        /// If @dest is %NULL, free @src; otherwise, moves @src into *@dest.
        /// The error variable @dest points to must be %NULL.
        /// </summary>
        /// <param name="dest">
        /// error return location
        /// </param>
        /// <param name="src">
        /// error to move into the return location
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_propagate_error( System.IntPtr dest,  System.IntPtr src);

        /// <summary>
        /// If @dest is %NULL, free @src; otherwise, moves @src into *@dest.
        /// The error variable @dest points to must be %NULL.
        /// </summary>
        /// <param name="dest">
        /// error return location
        /// </param>
        /// <param name="src">
        /// error to move into the return location
        /// </param>
        public static System.Void PropagateError( GISharp.GLib.Error dest,  GISharp.GLib.Error src)
        {
            if (dest == null)
            {
                throw new ArgumentNullException("dest");
            }
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            var ret = g_propagate_error(dest, src);
            return default(System.Void);
        }

        /// <summary>
        /// If @err is %NULL, does nothing. If @err is non-%NULL,
        /// calls g_error_free() on *@err and sets *@err to %NULL.
        /// </summary>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_clear_error();

        /// <summary>
        /// If @err is %NULL, does nothing. If @err is non-%NULL,
        /// calls g_error_free() on *@err and sets *@err to %NULL.
        /// </summary>
        public static System.Void ClearError()
        {
            var ret = g_clear_error();
            return default(System.Void);
        }
    }

    /// <summary>
    /// A GHashTableIter structure represents an iterator that can be used
    /// to iterate over the elements of a #GHashTable. GHashTableIter
    /// structures are typically allocated on the stack and then initialized
    /// with g_hash_table_iter_init().
    /// </summary>
    public partial struct HashTableIter
    {
        public System.IntPtr Dummy1;
        public System.IntPtr Dummy2;
        public System.IntPtr Dummy3;
        public System.Int32 Dummy4;
        public System.Boolean Dummy5;
        public System.IntPtr Dummy6;

        /// <summary>
        /// Returns the #GHashTable associated with @iter.
        /// </summary>
        /// <param name="iter">
        /// an initialized #GHashTableIter
        /// </param>
        /// <returns>
        /// the #GHashTable associated with @iter.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_hash_table_iter_get_hash_table( System.IntPtr iter);

        /// <summary>
        /// Returns the #GHashTable associated with @iter.
        /// </summary>
        /// <returns>
        /// the #GHashTable associated with @iter.
        /// </returns>
        [GISharp.Core.Since("2.16")]
        public GISharp.Core.HashTable`2[System.IntPtr,System.IntPtr]get_HashTable()
        {
            var ret = g_hash_table_iter_get_hash_table(Handle);
            return default(GISharp.Core.HashTable);
        }

        /// <summary>
        /// Initializes a key/value pair iterator and associates it with
        /// @hash_table. Modifying the hash table after calling this function
        /// invalidates the returned iterator.
        /// |[&lt;!-- language="C" --&gt;
        /// GHashTableIter iter;
        /// gpointer key, value;
        /// </summary>
        /// <remarks>
        /// g_hash_table_iter_init (&amp;iter, hash_table);
        /// while (g_hash_table_iter_next (&amp;iter, &amp;key, &amp;value))
        ///   {
        ///     // do something with key and value
        ///   }
        /// ]|
        /// </remarks>
        /// <param name="iter">
        /// an uninitialized #GHashTableIter
        /// </param>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_hash_table_iter_init( System.IntPtr iter,  System.IntPtr hashTable);

        /// <summary>
        /// Initializes a key/value pair iterator and associates it with
        /// @hash_table. Modifying the hash table after calling this function
        /// invalidates the returned iterator.
        /// |[&lt;!-- language="C" --&gt;
        /// GHashTableIter iter;
        /// gpointer key, value;
        /// </summary>
        /// <remarks>
        /// g_hash_table_iter_init (&amp;iter, hash_table);
        /// while (g_hash_table_iter_next (&amp;iter, &amp;key, &amp;value))
        ///   {
        ///     // do something with key and value
        ///   }
        /// ]|
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        [GISharp.Core.Since("2.16")]
        public System.Void Init( GISharp.Core.HashTable`2[System.IntPtr,System.IntPtr]hashTable)
        {
            if (hashTable == null)
            {
                throw new ArgumentNullException("hashTable");
            }
            var ret = g_hash_table_iter_init(Handle, hashTable);
            return default(System.Void);
        }

        /// <summary>
        /// Advances @iter and retrieves the key and/or value that are now
        /// pointed to as a result of this advancement. If %FALSE is returned,
        /// @key and @value are not set, and the iterator becomes invalid.
        /// </summary>
        /// <param name="iter">
        /// an initialized #GHashTableIter
        /// </param>
        /// <param name="key">
        /// a location to store the key, or %NULL
        /// </param>
        /// <param name="value">
        /// a location to store the value, or %NULL
        /// </param>
        /// <returns>
        /// %FALSE if the end of the #GHashTable has been reached.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_hash_table_iter_next( System.IntPtr iter,  System.IntPtr key,  System.IntPtr value);

        /// <summary>
        /// Advances @iter and retrieves the key and/or value that are now
        /// pointed to as a result of this advancement. If %FALSE is returned,
        /// @key and @value are not set, and the iterator becomes invalid.
        /// </summary>
        /// <param name="key">
        /// a location to store the key, or %NULL
        /// </param>
        /// <param name="value">
        /// a location to store the value, or %NULL
        /// </param>
        /// <returns>
        /// %FALSE if the end of the #GHashTable has been reached.
        /// </returns>
        [GISharp.Core.Since("2.16")]
        public System.Boolean Next( System.IntPtr key,  System.IntPtr value)
        {
            var ret = g_hash_table_iter_next(Handle, key, value);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes the key/value pair currently pointed to by the iterator
        /// from its associated #GHashTable. Can only be called after
        /// g_hash_table_iter_next() returned %TRUE, and cannot be called
        /// more than once for the same key/value pair.
        /// </summary>
        /// <remarks>
        /// If the #GHashTable was created using g_hash_table_new_full(),
        /// the key and value are freed using the supplied destroy functions,
        /// otherwise you have to make sure that any dynamically allocated
        /// values are freed yourself.
        /// 
        /// It is safe to continue iterating the #GHashTable afterward:
        /// |[&lt;!-- language="C" --&gt;
        /// while (g_hash_table_iter_next (&amp;iter, &amp;key, &amp;value))
        ///   {
        ///     if (condition)
        ///       g_hash_table_iter_remove (&amp;iter);
        ///   }
        /// ]|
        /// </remarks>
        /// <param name="iter">
        /// an initialized #GHashTableIter
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_hash_table_iter_remove( System.IntPtr iter);

        /// <summary>
        /// Removes the key/value pair currently pointed to by the iterator
        /// from its associated #GHashTable. Can only be called after
        /// g_hash_table_iter_next() returned %TRUE, and cannot be called
        /// more than once for the same key/value pair.
        /// </summary>
        /// <remarks>
        /// If the #GHashTable was created using g_hash_table_new_full(),
        /// the key and value are freed using the supplied destroy functions,
        /// otherwise you have to make sure that any dynamically allocated
        /// values are freed yourself.
        /// 
        /// It is safe to continue iterating the #GHashTable afterward:
        /// |[&lt;!-- language="C" --&gt;
        /// while (g_hash_table_iter_next (&amp;iter, &amp;key, &amp;value))
        ///   {
        ///     if (condition)
        ///       g_hash_table_iter_remove (&amp;iter);
        ///   }
        /// ]|
        /// </remarks>
        [GISharp.Core.Since("2.16")]
        public System.Void Remove()
        {
            var ret = g_hash_table_iter_remove(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Replaces the value currently pointed to by the iterator
        /// from its associated #GHashTable. Can only be called after
        /// g_hash_table_iter_next() returned %TRUE.
        /// </summary>
        /// <remarks>
        /// If you supplied a @value_destroy_func when creating the
        /// #GHashTable, the old value is freed using that function.
        /// </remarks>
        /// <param name="iter">
        /// an initialized #GHashTableIter
        /// </param>
        /// <param name="value">
        /// the value to replace with
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_hash_table_iter_replace( System.IntPtr iter,  System.IntPtr value);

        /// <summary>
        /// Replaces the value currently pointed to by the iterator
        /// from its associated #GHashTable. Can only be called after
        /// g_hash_table_iter_next() returned %TRUE.
        /// </summary>
        /// <remarks>
        /// If you supplied a @value_destroy_func when creating the
        /// #GHashTable, the old value is freed using that function.
        /// </remarks>
        /// <param name="value">
        /// the value to replace with
        /// </param>
        [GISharp.Core.Since("2.30")]
        public System.Void Replace( System.IntPtr value)
        {
            var ret = g_hash_table_iter_replace(Handle, value);
            return default(System.Void);
        }

        /// <summary>
        /// Removes the key/value pair currently pointed to by the
        /// iterator from its associated #GHashTable, without calling
        /// the key and value destroy functions. Can only be called
        /// after g_hash_table_iter_next() returned %TRUE, and cannot
        /// be called more than once for the same key/value pair.
        /// </summary>
        /// <param name="iter">
        /// an initialized #GHashTableIter
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_hash_table_iter_steal( System.IntPtr iter);

        /// <summary>
        /// Removes the key/value pair currently pointed to by the
        /// iterator from its associated #GHashTable, without calling
        /// the key and value destroy functions. Can only be called
        /// after g_hash_table_iter_next() returned %TRUE, and cannot
        /// be called more than once for the same key/value pair.
        /// </summary>
        [GISharp.Core.Since("2.16")]
        public System.Void Steal()
        {
            var ret = g_hash_table_iter_steal(Handle);
            return default(System.Void);
        }
    }

    /// <summary>
    /// The GKeyFile struct contains only private data
    /// and should not be accessed directly.
    /// </summary>
    public partial class KeyFile : GISharp.Core.ReferenceCountedOpaque<KeyFile>
    {
        /// <summary>
        /// The name of the main group of a desktop entry file, as defined in the
        /// [Desktop Entry Specification](http://freedesktop.org/Standards/desktop-entry-spec).
        /// Consult the specification for more
        /// details about the meanings of the keys below.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopGroup = "Desktop Entry";
        public const System.String DesktopKeyActions = "Actions";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the categories in which the desktop entry
        /// should be shown in a menu.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyCategories = "Categories";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the tooltip for the desktop entry.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyComment = "Comment";
        public const System.String DesktopKeyDbusActivatable = "DBusActivatable";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the command line to execute. It is only valid for desktop
        /// entries with the `Application` type.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyExec = "Exec";
        public const System.String DesktopKeyFullname = "X-GNOME-FullName";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the generic name of the desktop entry.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyGenericName = "GenericName";
        public const System.String DesktopKeyGettextDomain = "X-GNOME-Gettext-Domain";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry has been deleted by the user.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyHidden = "Hidden";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the name of the icon to be displayed for the desktop
        /// entry.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyIcon = "Icon";
        public const System.String DesktopKeyKeywords = "Keywords";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the MIME types supported by this desktop entry.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyMimeType = "MimeType";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the specific name of the desktop entry.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyName = "Name";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should not display the
        /// desktop entry.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyNotShowIn = "NotShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry should be shown in menus.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyNoDisplay = "NoDisplay";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should display the
        /// desktop entry.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyOnlyShowIn = "OnlyShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// containing the working directory to run the program in. It is only
        /// valid for desktop entries with the `Application` type.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyPath = "Path";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the application supports the
        /// [Startup Notification Protocol Specification](http://www.freedesktop.org/Standards/startup-notification-spec).
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyStartupNotify = "StartupNotify";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is string
        /// identifying the WM class or name hint of a window that the application
        /// will create, which can be used to emulate Startup Notification with
        /// older applications.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyStartupWmClass = "StartupWMClass";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the program should be run in a terminal window.
        /// It is only valid for desktop entries with the
        /// `Application` type.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyTerminal = "Terminal";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the file name of a binary on disk used to determine if the
        /// program is actually installed. It is only valid for desktop entries
        /// with the `Application` type.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyTryExec = "TryExec";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the type of the desktop entry. Usually
        /// #G_KEY_FILE_DESKTOP_TYPE_APPLICATION,
        /// #G_KEY_FILE_DESKTOP_TYPE_LINK, or
        /// #G_KEY_FILE_DESKTOP_TYPE_DIRECTORY.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyType = "Type";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the URL to access. It is only valid for desktop entries
        /// with the `Link` type.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyUrl = "URL";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the version of the Desktop Entry Specification used for
        /// the desktop entry file.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopKeyVersion = "Version";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing applications.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopTypeApplication = "Application";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing directories.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopTypeDirectory = "Directory";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing links to documents.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public const System.String DesktopTypeLink = "Link";

        public KeyFile(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_new();

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public KeyFile() : base(IntPtr.Zero)
        {
            var ret = g_key_file_new();
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %FALSE is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with @key cannot be interpreted as a boolean then %FALSE
        /// is returned and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or %FALSE if the key was not found or could not be parsed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_get_boolean( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %FALSE is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with @key cannot be interpreted as a boolean then %FALSE
        /// is returned and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or %FALSE if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean GetBoolean( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_boolean(Handle, groupName, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as booleans then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of booleans returned
        /// </param>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or %NULL if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
        static extern System.Boolean[] g_key_file_get_boolean_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key, out System.UInt64 length);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as booleans then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or %NULL if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean[] GetBooleanList( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_boolean_list(Handle, groupName, key, length);
            return default(System.Boolean[]);
        }

        /// <summary>
        /// Retrieves a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be read from above
        /// @group_name. If both @key and @group_name are %NULL, then
        /// @comment will be read from above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_comment( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Retrieves a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be read from above
        /// @group_name. If both @key and @group_name are %NULL, then
        /// @comment will be read from above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String GetComment( System.String groupName,  System.String key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_comment(Handle, groupName, key);
            return default(System.String);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// double. If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0.0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as a double then 0.0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Double g_key_file_get_double( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// double. If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0.0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as a double then 0.0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.Since("2.12")]
        public System.Double GetDouble( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_double(Handle, groupName, key);
            return default(System.Double);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as doubles then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of doubles returned
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or %NULL if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
        static extern System.Double[] g_key_file_get_double_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key, out System.UInt64 length);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as doubles then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or %NULL if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.Since("2.12")]
        public System.Double[] GetDoubleList( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_double_list(Handle, groupName, key, length);
            return default(System.Double[]);
        }

        /// <summary>
        /// Returns all groups in the key file loaded with @key_file.
        /// The array of returned groups will be %NULL-terminated, so
        /// @length may optionally be %NULL.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the number of returned groups, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr[] g_key_file_get_groups( System.IntPtr keyFile, out System.UInt64 length);

        /// <summary>
        /// Returns all groups in the key file loaded with @key_file.
        /// The array of returned groups will be %NULL-terminated, so
        /// @length may optionally be %NULL.
        /// </summary>
        /// <param name="length">
        /// return location for the number of returned groups, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String[] GetGroups(out System.UInt64 length)
        {
            var ret = g_key_file_get_groups(Handle, length);
            return default(System.String[]);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a signed
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int64 g_key_file_get_int64( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a signed
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int64 GetInt64( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_int64(Handle, groupName, key);
            return default(System.Int64);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as an integer then 0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_key_file_get_integer( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Returns the value associated with @key under @group_name as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as an integer then 0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Int32 GetInteger( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_integer(Handle, groupName, key);
            return default(System.Int32);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as integers then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of integers returned
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or %NULL if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
        static extern System.Int32[] g_key_file_get_integer_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key, out System.UInt64 length);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as integers then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or %NULL if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Int32[] GetIntegerList( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_integer_list(Handle, groupName, key, length);
            return default(System.Int32[]);
        }

        /// <summary>
        /// Returns all keys for the group name @group_name.  The array of
        /// returned keys will be %NULL-terminated, so @length may
        /// optionally be %NULL. In the event that the @group_name cannot
        /// be found, %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="length">
        /// return location for the number of keys returned, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr[] g_key_file_get_keys( System.IntPtr keyFile,  System.IntPtr groupName, out System.UInt64 length);

        /// <summary>
        /// Returns all keys for the group name @group_name.  The array of
        /// returned keys will be %NULL-terminated, so @length may
        /// optionally be %NULL. In the event that the @group_name cannot
        /// be found, %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="length">
        /// return location for the number of keys returned, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String[] GetKeys( System.String groupName, out System.UInt64 length)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            var ret = g_key_file_get_keys(Handle, groupName, length);
            return default(System.String[]);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with @key cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_locale_string( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr locale);

        /// <summary>
        /// Returns the value associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with @key cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String GetLocaleString( System.String groupName,  System.String key,  System.String locale)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_locale_string(Handle, groupName, key, locale);
            return default(System.String);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with @key cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is %NULL-terminated, so @length may optionally
        /// be %NULL.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated %NULL-terminated string array
        ///   or %NULL if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
        static extern System.IntPtr g_key_file_get_locale_string_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr locale, out System.UInt64 length);

        /// <summary>
        /// Returns the values associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with @key cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is %NULL-terminated, so @length may optionally
        /// be %NULL.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated %NULL-terminated string array
        ///   or %NULL if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String[] GetLocaleStringList( System.String groupName,  System.String key,  System.String locale)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_locale_string_list(Handle, groupName, key, locale, length);
            return default(System.String[]);
        }

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_start_group( System.IntPtr keyFile);

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String get_StartGroup()
        {
            var ret = g_key_file_get_start_group(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Returns the string value associated with @key under @group_name.
        /// Unlike g_key_file_get_value(), this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_string( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Returns the string value associated with @key under @group_name.
        /// Unlike g_key_file_get_value(), this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String GetString( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_string(Handle, groupName, key);
            return default(System.String);
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings, or %NULL
        /// </param>
        /// <returns>
        /// 
        ///  a %NULL-terminated string array or %NULL if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
        static extern System.IntPtr g_key_file_get_string_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key, out System.UInt64 length);

        /// <summary>
        /// Returns the values associated with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///  a %NULL-terminated string array or %NULL if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String[] GetStringList( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_string_list(Handle, groupName, key, length);
            return default(System.String[]);
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an unsigned
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_key_file_get_uint64( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Returns the value associated with @key under @group_name as an unsigned
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.UInt64 GetUint64( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_uint64(Handle, groupName, key);
            return default(System.UInt64);
        }

        /// <summary>
        /// Returns the raw value associated with @key under @group_name.
        /// Use g_key_file_get_string() to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///  key cannot be found.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_get_value( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Returns the raw value associated with @key under @group_name.
        /// Use g_key_file_get_string() to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///  key cannot be found.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String GetValue( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_get_value(Handle, groupName, key);
            return default(System.String);
        }

        /// <summary>
        /// Looks whether the key file has the group @group_name.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if @group_name is a part of @key_file, %FALSE
        /// otherwise.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_has_group( System.IntPtr keyFile,  System.IntPtr groupName);

        /// <summary>
        /// Looks whether the key file has the group @group_name.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if @group_name is a part of @key_file, %FALSE
        /// otherwise.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean HasGroup( System.String groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            var ret = g_key_file_has_group(Handle, groupName);
            return default(System.Boolean);
        }

        /// <summary>
        /// Looks whether the key file has the key @key in the group
        /// @group_name.
        /// </summary>
        /// <remarks>
        /// Note that this function does not follow the rules for #GError strictly;
        /// the return value both carries meaning and signals an error.  To use
        /// this function, you must pass a #GError pointer in @error, and check
        /// whether it is not %NULL to see if an error occurred.
        /// 
        /// Language bindings should use g_key_file_get_value() to test whether
        /// or not a key exists.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name
        /// </param>
        /// <returns>
        /// %TRUE if @key is a part of @group_name, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_has_key( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Looks whether the key file has the key @key in the group
        /// @group_name.
        /// </summary>
        /// <remarks>
        /// Note that this function does not follow the rules for #GError strictly;
        /// the return value both carries meaning and signals an error.  To use
        /// this function, you must pass a #GError pointer in @error, and check
        /// whether it is not %NULL to see if an error occurred.
        /// 
        /// Language bindings should use g_key_file_get_value() to test whether
        /// or not a key exists.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name
        /// </param>
        /// <returns>
        /// %TRUE if @key is a part of @group_name, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean HasKey( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_has_key(Handle, groupName, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Loads a key file from memory into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <param name="length">
        /// the length of @data in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_data( System.IntPtr keyFile,  System.IntPtr data,  System.UInt64 length,  System.IntPtr flags);

        /// <summary>
        /// Loads a key file from memory into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <param name="length">
        /// the length of @data in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean LoadFromData( System.String data,  System.UInt64 length,  GISharp.GLib.KeyFileFlags flags)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            var ret = g_key_file_load_from_data(Handle, data, length, flags);
            return default(System.Boolean);
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into @key_file and returns the file's full path in
        /// @full_path.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE othewise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_data_dirs( System.IntPtr keyFile,  System.IntPtr file, out System.IntPtr fullPath,  System.IntPtr flags);

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into @key_file and returns the file's full path in
        /// @full_path.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE othewise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean LoadFromDataDirs( System.String file, out System.String fullPath,  GISharp.GLib.KeyFileFlags flags)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
            var ret = g_key_file_load_from_data_dirs(Handle, file, fullPath, flags);
            return default(System.Boolean);
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// specified in @search_dirs, loads the file into @key_file and
        /// returns the file's full path in @full_path.  If the file could not
        /// be loaded then an %error is set to either a #GFileError or
        /// #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="searchDirs">
        /// %NULL-terminated array of directories to search
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_dirs( System.IntPtr keyFile,  System.IntPtr file,  System.IntPtr[] searchDirs, out System.IntPtr fullPath,  System.IntPtr flags);

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// specified in @search_dirs, loads the file into @key_file and
        /// returns the file's full path in @full_path.  If the file could not
        /// be loaded then an %error is set to either a #GFileError or
        /// #GKeyFileError.
        /// </summary>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="searchDirs">
        /// %NULL-terminated array of directories to search
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public System.Boolean LoadFromDirs( System.String file,  System.String[] searchDirs, out System.String fullPath,  GISharp.GLib.KeyFileFlags flags)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
            if (searchDirs == null)
            {
                throw new ArgumentNullException("searchDirs");
            }
            var ret = g_key_file_load_from_dirs(Handle, file, searchDirs, fullPath, flags);
            return default(System.Boolean);
        }

        /// <summary>
        /// Loads a key file into an empty #GKeyFile structure.
        /// If the file could not be loaded then @error is set to
        /// either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_load_from_file( System.IntPtr keyFile,  System.IntPtr file,  System.IntPtr flags);

        /// <summary>
        /// Loads a key file into an empty #GKeyFile structure.
        /// If the file could not be loaded then @error is set to
        /// either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean LoadFromFile( System.String file,  GISharp.GLib.KeyFileFlags flags)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
            var ret = g_key_file_load_from_file(Handle, file, flags);
            return default(System.Boolean);
        }

        /// <summary>
        /// Increases the reference count of @key_file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <returns>
        /// the same @key_file.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_ref( System.IntPtr keyFile);

        /// <summary>
        /// Increases the reference count of @key_file.
        /// </summary>
        /// <returns>
        /// the same @key_file.
        /// </returns>
        [GISharp.Core.Since("2.32")]
        protected override void Ref()
        {
            var ret = g_key_file_ref(Handle);
        }

        /// <summary>
        /// Removes a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be removed above @group_name.
        /// If both @key and @group_name are %NULL, then @comment will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// %TRUE if the comment was removed, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_remove_comment( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Removes a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be removed above @group_name.
        /// If both @key and @group_name are %NULL, then @comment will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// %TRUE if the comment was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean RemoveComment( System.String groupName,  System.String key)
        {
            var ret = g_key_file_remove_comment(Handle, groupName, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes the specified group, @group_name,
        /// from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if the group was removed, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_remove_group( System.IntPtr keyFile,  System.IntPtr groupName);

        /// <summary>
        /// Removes the specified group, @group_name,
        /// from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if the group was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean RemoveGroup( System.String groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            var ret = g_key_file_remove_group(Handle, groupName);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes @key in @group_name from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was removed, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_remove_key( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key);

        /// <summary>
        /// Removes @key in @group_name from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean RemoveKey( System.String groupName,  System.String key)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_remove_key(Handle, groupName, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Writes the contents of @key_file to @filename using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_save_to_file( System.IntPtr keyFile,  System.IntPtr filename);

        /// <summary>
        /// Writes the contents of @key_file to @filename using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [GISharp.Core.Since("2.40")]
        public System.Boolean SaveToFile( System.String filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException("filename");
            }
            var ret = g_key_file_save_to_file(Handle, filename);
            return default(System.Boolean);
        }

        /// <summary>
        /// Associates a new boolean value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// %TRUE or %FALSE
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_boolean( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.Boolean value);

        /// <summary>
        /// Associates a new boolean value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// %TRUE or %FALSE
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetBoolean( System.String groupName,  System.String key,  System.Boolean value)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_set_boolean(Handle, groupName, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a list of boolean values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        /// <param name="length">
        /// length of @list
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_boolean_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.Boolean[] list,  System.UInt64 length);

        /// <summary>
        /// Associates a list of boolean values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetBooleanList( System.String groupName,  System.String key,  System.Boolean[] list)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            var length = (System.UInt64)list.Length;
            var ret = g_key_file_set_boolean_list(Handle, groupName, key, list, length);
            return default(System.Void);
        }

        /// <summary>
        /// Places a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be written above @group_name.
        /// If both @key and @group_name  are %NULL, then @comment will be
        /// written above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <returns>
        /// %TRUE if the comment was written, %FALSE otherwise
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_key_file_set_comment( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr comment);

        /// <summary>
        /// Places a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be written above @group_name.
        /// If both @key and @group_name  are %NULL, then @comment will be
        /// written above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <returns>
        /// %TRUE if the comment was written, %FALSE otherwise
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.Boolean SetComment( System.String groupName,  System.String key,  System.String comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            var ret = g_key_file_set_comment(Handle, groupName, key, comment);
            return default(System.Boolean);
        }

        /// <summary>
        /// Associates a new double value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an double value
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_double( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.Double value);

        /// <summary>
        /// Associates a new double value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an double value
        /// </param>
        [GISharp.Core.Since("2.12")]
        public System.Void SetDouble( System.String groupName,  System.String key,  System.Double value)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_set_double(Handle, groupName, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a list of double values with @key under
        /// @group_name.  If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of double values
        /// </param>
        /// <param name="length">
        /// number of double values in @list
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_double_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.Double[] list,  System.UInt64 length);

        /// <summary>
        /// Associates a list of double values with @key under
        /// @group_name.  If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of double values
        /// </param>
        [GISharp.Core.Since("2.12")]
        public System.Void SetDoubleList( System.String groupName,  System.String key,  System.Double[] list)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            var length = (System.UInt64)list.Length;
            var ret = g_key_file_set_double_list(Handle, groupName, key, list, length);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_int64( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.Int64 value);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.Since("2.26")]
        public System.Void SetInt64( System.String groupName,  System.String key,  System.Int64 value)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_set_int64(Handle, groupName, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_integer( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.Int32 value);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetInteger( System.String groupName,  System.String key,  System.Int32 value)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_set_integer(Handle, groupName, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a list of integer values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        /// <param name="length">
        /// number of integer values in @list
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_integer_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.Int32[] list,  System.UInt64 length);

        /// <summary>
        /// Associates a list of integer values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetIntegerList( System.String groupName,  System.String key,  System.Int32[] list)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            var length = (System.UInt64)list.Length;
            var ret = g_key_file_set_integer_list(Handle, groupName, key, list, length);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="separator">
        /// the separator
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_list_separator( System.IntPtr keyFile,  System.SByte separator);

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="separator">
        /// the separator
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetListSeparator( System.SByte separator)
        {
            var ret = g_key_file_set_list_separator(Handle, separator);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a string value for @key and @locale under @group_name.
        /// If the translation for @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_locale_string( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr locale,  System.IntPtr @string);

        /// <summary>
        /// Associates a string value for @key and @locale under @group_name.
        /// If the translation for @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetLocaleString( System.String groupName,  System.String key,  System.String locale,  System.String @string)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (locale == null)
            {
                throw new ArgumentNullException("locale");
            }
            if (@string == null)
            {
                throw new ArgumentNullException("@string");
            }
            var ret = g_key_file_set_locale_string(Handle, groupName, key, locale, @string);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a list of string values for @key and @locale under
        /// @group_name.  If the translation for @key cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="list">
        /// a %NULL-terminated array of locale string values
        /// </param>
        /// <param name="length">
        /// the length of @list
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_locale_string_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr locale,  System.IntPtr list,  System.UInt64 length);

        /// <summary>
        /// Associates a list of string values for @key and @locale under
        /// @group_name.  If the translation for @key cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="list">
        /// a %NULL-terminated array of locale string values
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetLocaleStringList( System.String groupName,  System.String key,  System.String locale,  System.String[] list)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (locale == null)
            {
                throw new ArgumentNullException("locale");
            }
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            var length = (System.UInt64)list.Length;
            var ret = g_key_file_set_locale_string_list(Handle, groupName, key, locale, list, length);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a new string value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// Unlike g_key_file_set_value(), this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_string( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr @string);

        /// <summary>
        /// Associates a new string value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// Unlike g_key_file_set_value(), this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetString( System.String groupName,  System.String key,  System.String @string)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (@string == null)
            {
                throw new ArgumentNullException("@string");
            }
            var ret = g_key_file_set_string(Handle, groupName, key, @string);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a list of string values for @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of string values
        /// </param>
        /// <param name="length">
        /// number of string values in @list
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_string_list( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr list,  System.UInt64 length);

        /// <summary>
        /// Associates a list of string values for @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of string values
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetStringList( System.String groupName,  System.String key,  System.String[] list)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            var length = (System.UInt64)list.Length;
            var ret = g_key_file_set_string_list(Handle, groupName, key, list, length);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_uint64( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.UInt64 value);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Core.Since("2.26")]
        public System.Void SetUint64( System.String groupName,  System.String key,  System.UInt64 value)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_key_file_set_uint64(Handle, groupName, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Associates a new value with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then it is created. If @group_name cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// g_key_file_set_string().
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// a string
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_set_value( System.IntPtr keyFile,  System.IntPtr groupName,  System.IntPtr key,  System.IntPtr value);

        /// <summary>
        /// Associates a new value with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then it is created. If @group_name cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// g_key_file_set_string().
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// a string
        /// </param>
        [GISharp.Core.Since("2.6")]
        public System.Void SetValue( System.String groupName,  System.String key,  System.String value)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_key_file_set_value(Handle, groupName, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// This function outputs @key_file as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass %NULL as @error.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the #GKeyFile
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_to_data( System.IntPtr keyFile, out System.UInt64 length);

        /// <summary>
        /// This function outputs @key_file as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass %NULL as @error.
        /// </remarks>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the #GKeyFile
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public System.String ToData(out System.UInt64 length)
        {
            var ret = g_key_file_to_data(Handle, length);
            return default(System.String);
        }

        /// <summary>
        /// Decreases the reference count of @key_file by 1. If the reference count
        /// reaches zero, frees the key file and all its allocated memory.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_key_file_unref( System.IntPtr keyFile);

        /// <summary>
        /// Decreases the reference count of @key_file by 1. If the reference count
        /// reaches zero, frees the key file and all its allocated memory.
        /// </summary>
        [GISharp.Core.Since("2.32")]
        protected override System.Void Unref()
        {
            var ret = g_key_file_unref(Handle);
            return default(System.Void);
        }

        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_key_file_error_quark();

        public static GISharp.GLib.Quark ErrorQuark()
        {
            var ret = g_key_file_error_quark();
            return default(GISharp.GLib.Quark);
        }
    }

    /// <summary>
    /// The `GMainContext` struct is an opaque data
    /// type representing a set of sources to be handled in a main loop.
    /// </summary>
    public partial class MainContext : GISharp.Core.ReferenceCountedOpaque<MainContext>
    {
        public MainContext(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GMainContext structure.
        /// </summary>
        /// <returns>
        /// the new #GMainContext
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_new();

        /// <summary>
        /// Creates a new #GMainContext structure.
        /// </summary>
        /// <returns>
        /// the new #GMainContext
        /// </returns>
        public MainContext() : base(IntPtr.Zero)
        {
            var ret = g_main_context_new();
        }

        /// <summary>
        /// Tries to become the owner of the specified context.
        /// If some other thread is the owner of the context,
        /// returns %FALSE immediately. Ownership is properly
        /// recursive: the owner can require ownership again
        /// and will release ownership when g_main_context_release()
        /// is called as many times as g_main_context_acquire().
        /// </summary>
        /// <remarks>
        /// You must be the owner of a context before you
        /// can call g_main_context_prepare(), g_main_context_query(),
        /// g_main_context_check(), g_main_context_dispatch().
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// %TRUE if the operation succeeded, and
        ///   this thread is now the owner of @context.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_acquire( System.IntPtr context);

        /// <summary>
        /// Tries to become the owner of the specified context.
        /// If some other thread is the owner of the context,
        /// returns %FALSE immediately. Ownership is properly
        /// recursive: the owner can require ownership again
        /// and will release ownership when g_main_context_release()
        /// is called as many times as g_main_context_acquire().
        /// </summary>
        /// <remarks>
        /// You must be the owner of a context before you
        /// can call g_main_context_prepare(), g_main_context_query(),
        /// g_main_context_check(), g_main_context_dispatch().
        /// </remarks>
        /// <returns>
        /// %TRUE if the operation succeeded, and
        ///   this thread is now the owner of @context.
        /// </returns>
        public System.Boolean Acquire()
        {
            var ret = g_main_context_acquire(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this context. This will very seldom be used directly. Instead
        /// a typical event source will use g_source_add_unix_fd() instead.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (or %NULL for the default context)
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        /// <param name="priority">
        /// the priority for this file descriptor which should be
        ///      the same as the priority used for g_source_attach() to ensure that the
        ///      file descriptor is polled whenever the results may be needed.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_add_poll( System.IntPtr context,  System.IntPtr fd,  System.Int32 priority);

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this context. This will very seldom be used directly. Instead
        /// a typical event source will use g_source_add_unix_fd() instead.
        /// </summary>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        /// <param name="priority">
        /// the priority for this file descriptor which should be
        ///      the same as the priority used for g_source_attach() to ensure that the
        ///      file descriptor is polled whenever the results may be needed.
        /// </param>
        public System.Void AddPoll( GISharp.GLib.PollFD fd,  System.Int32 priority)
        {
            var ret = g_main_context_add_poll(Handle, fd, priority);
            return default(System.Void);
        }

        /// <summary>
        /// Passes the results of polling back to the main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="maxPriority">
        /// the maximum numerical priority of sources to check
        /// </param>
        /// <param name="fds">
        /// array of #GPollFD's that was passed to
        ///       the last call to g_main_context_query()
        /// </param>
        /// <param name="nFds">
        /// return value of g_main_context_query()
        /// </param>
        /// <returns>
        /// %TRUE if some sources are ready to be dispatched.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_main_context_check( System.IntPtr context,  System.Int32 maxPriority,  System.IntPtr[] fds,  System.Int32 nFds);

        /// <summary>
        /// Passes the results of polling back to the main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="maxPriority">
        /// the maximum numerical priority of sources to check
        /// </param>
        /// <param name="fds">
        /// array of #GPollFD's that was passed to
        ///       the last call to g_main_context_query()
        /// </param>
        /// <returns>
        /// %TRUE if some sources are ready to be dispatched.
        /// </returns>
        public System.Int32 Check( System.Int32 maxPriority,  GISharp.GLib.PollFD[] fds)
        {
            if (fds == null)
            {
                throw new ArgumentNullException("fds");
            }
            var nFds = (System.Int32)fds.Length;
            var ret = g_main_context_check(Handle, maxPriority, fds, nFds);
            return default(System.Int32);
        }

        /// <summary>
        /// Dispatches all pending sources.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_dispatch( System.IntPtr context);

        /// <summary>
        /// Dispatches all pending sources.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        public System.Void Dispatch()
        {
            var ret = g_main_context_dispatch(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Finds a source with the given source functions and user data.  If
        /// multiple sources exist with the same source function and user data,
        /// the first one found will be returned.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used).
        /// </param>
        /// <param name="funcs">
        /// the @source_funcs passed to g_source_new().
        /// </param>
        /// <param name="userData">
        /// the user data from the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_find_source_by_funcs_user_data( System.IntPtr context,  System.IntPtr funcs,  System.IntPtr userData);

        /// <summary>
        /// Finds a source with the given source functions and user data.  If
        /// multiple sources exist with the same source function and user data,
        /// the first one found will be returned.
        /// </summary>
        /// <param name="funcs">
        /// the @source_funcs passed to g_source_new().
        /// </param>
        /// <param name="userData">
        /// the user data from the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        public GISharp.GLib.Source FindSourceByFuncsUserData( GISharp.GLib.SourceFuncs funcs,  System.IntPtr userData)
        {
            var ret = g_main_context_find_source_by_funcs_user_data(Handle, funcs, userData);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Finds a #GSource given a pair of context and ID.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to attempt to lookup a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <param name="sourceId">
        /// the source ID, as returned by g_source_get_id().
        /// </param>
        /// <returns>
        /// the #GSource
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_find_source_by_id( System.IntPtr context,  System.UInt32 sourceId);

        /// <summary>
        /// Finds a #GSource given a pair of context and ID.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to attempt to lookup a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="sourceId">
        /// the source ID, as returned by g_source_get_id().
        /// </param>
        /// <returns>
        /// the #GSource
        /// </returns>
        public GISharp.GLib.Source FindSourceById( System.UInt32 sourceId)
        {
            var ret = g_main_context_find_source_by_id(Handle, sourceId);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Finds a source with the given user data for the callback.  If
        /// multiple sources exist with the same user data, the first
        /// one found will be returned.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_find_source_by_user_data( System.IntPtr context,  System.IntPtr userData);

        /// <summary>
        /// Finds a source with the given user data for the callback.  If
        /// multiple sources exist with the same user data, the first
        /// one found will be returned.
        /// </summary>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// the source, if one was found, otherwise %NULL
        /// </returns>
        public GISharp.GLib.Source FindSourceByUserData( System.IntPtr userData)
        {
            var ret = g_main_context_find_source_by_user_data(Handle, userData);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Gets the poll function set by g_main_context_set_poll_func().
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// the poll function
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_get_poll_func( System.IntPtr context);

        /// <summary>
        /// Gets the poll function set by g_main_context_set_poll_func().
        /// </summary>
        /// <returns>
        /// the poll function
        /// </returns>
        public GISharp.GLib.PollFunc get_PollFunc()
        {
            var ret = g_main_context_get_poll_func(Handle);
            return default(GISharp.GLib.PollFunc);
        }

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// If @context is %NULL then the global default main context — as
        /// returned by g_main_context_default() — is used.
        /// 
        /// If @context is owned by the current thread, @function is called
        /// directly.  Otherwise, if @context is the thread-default main context
        /// of the current thread and g_main_context_acquire() succeeds, then
        /// @function is called and g_main_context_release() is called
        /// afterwards.
        /// 
        /// In any other case, an idle source is created to call @function and
        /// that source is attached to @context (presumably to be run in another
        /// thread).  The idle source is attached with #G_PRIORITY_DEFAULT
        /// priority.  If you want a different priority, use
        /// g_main_context_invoke_full().
        /// 
        /// Note that, as with normal idle functions, @function should probably
        /// return %FALSE.  If it returns %TRUE, it will be continuously run in a
        /// loop (and may prevent this call from returning).
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_invoke( System.IntPtr context,  System.IntPtr function,  System.IntPtr data);

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// If @context is %NULL then the global default main context — as
        /// returned by g_main_context_default() — is used.
        /// 
        /// If @context is owned by the current thread, @function is called
        /// directly.  Otherwise, if @context is the thread-default main context
        /// of the current thread and g_main_context_acquire() succeeds, then
        /// @function is called and g_main_context_release() is called
        /// afterwards.
        /// 
        /// In any other case, an idle source is created to call @function and
        /// that source is attached to @context (presumably to be run in another
        /// thread).  The idle source is attached with #G_PRIORITY_DEFAULT
        /// priority.  If you want a different priority, use
        /// g_main_context_invoke_full().
        /// 
        /// Note that, as with normal idle functions, @function should probably
        /// return %FALSE.  If it returns %TRUE, it will be continuously run in a
        /// loop (and may prevent this call from returning).
        /// </remarks>
        /// <param name="function">
        /// function to call
        /// </param>
        [GISharp.Core.Since("2.28")]
        public System.Void Invoke( GISharp.GLib.SourceFunc function)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }
            var ret = g_main_context_invoke(Handle, function, data);
            return default(System.Void);
        }

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// This function is the same as g_main_context_invoke() except that it
        /// lets you specify the priority incase @function ends up being
        /// scheduled as an idle and also lets you give a #GDestroyNotify for @data.
        /// 
        /// @notify should not assume that it is called from any particular
        /// thread or with any particular context acquired.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL
        /// </param>
        /// <param name="priority">
        /// the priority at which to run @function
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// a function to call when @data is no longer in use, or %NULL.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_invoke_full( System.IntPtr context,  System.Int32 priority,  System.IntPtr function,  System.IntPtr data,  System.IntPtr notify);

        /// <summary>
        /// Invokes a function in such a way that @context is owned during the
        /// invocation of @function.
        /// </summary>
        /// <remarks>
        /// This function is the same as g_main_context_invoke() except that it
        /// lets you specify the priority incase @function ends up being
        /// scheduled as an idle and also lets you give a #GDestroyNotify for @data.
        /// 
        /// @notify should not assume that it is called from any particular
        /// thread or with any particular context acquired.
        /// </remarks>
        /// <param name="priority">
        /// the priority at which to run @function
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        [GISharp.Core.Since("2.28")]
        public System.Void InvokeFull( System.Int32 priority,  GISharp.GLib.SourceFunc function)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }
            var ret = g_main_context_invoke_full(Handle, priority, function, data, notify);
            return default(System.Void);
        }

        /// <summary>
        /// Determines whether this thread holds the (recursive)
        /// ownership of this #GMainContext. This is useful to
        /// know before waiting on another thread that may be
        /// blocking to get ownership of @context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// %TRUE if current thread is owner of @context.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_is_owner( System.IntPtr context);

        /// <summary>
        /// Determines whether this thread holds the (recursive)
        /// ownership of this #GMainContext. This is useful to
        /// know before waiting on another thread that may be
        /// blocking to get ownership of @context.
        /// </summary>
        /// <returns>
        /// %TRUE if current thread is owner of @context.
        /// </returns>
        [GISharp.Core.Since("2.10")]
        public System.Boolean get_IsOwner()
        {
            var ret = g_main_context_is_owner(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Runs a single iteration for the given main loop. This involves
        /// checking to see if any event sources are ready to be processed,
        /// then if no events sources are ready and @may_block is %TRUE, waiting
        /// for a source to become ready, then dispatching the highest priority
        /// events sources that are ready. Otherwise, if @may_block is %FALSE
        /// sources are not waited to become ready, only those highest priority
        /// events sources will be dispatched (if any), that are ready at this
        /// given moment without further waiting.
        /// </summary>
        /// <remarks>
        /// Note that even when @may_block is %TRUE, it is still possible for
        /// g_main_context_iteration() to return %FALSE, since the wait may
        /// be interrupted for other reasons than an event source becoming ready.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <param name="mayBlock">
        /// whether the call may block.
        /// </param>
        /// <returns>
        /// %TRUE if events were dispatched.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_iteration( System.IntPtr context,  System.Boolean mayBlock);

        /// <summary>
        /// Runs a single iteration for the given main loop. This involves
        /// checking to see if any event sources are ready to be processed,
        /// then if no events sources are ready and @may_block is %TRUE, waiting
        /// for a source to become ready, then dispatching the highest priority
        /// events sources that are ready. Otherwise, if @may_block is %FALSE
        /// sources are not waited to become ready, only those highest priority
        /// events sources will be dispatched (if any), that are ready at this
        /// given moment without further waiting.
        /// </summary>
        /// <remarks>
        /// Note that even when @may_block is %TRUE, it is still possible for
        /// g_main_context_iteration() to return %FALSE, since the wait may
        /// be interrupted for other reasons than an event source becoming ready.
        /// </remarks>
        /// <param name="mayBlock">
        /// whether the call may block.
        /// </param>
        /// <returns>
        /// %TRUE if events were dispatched.
        /// </returns>
        public System.Boolean Iteration( System.Boolean mayBlock)
        {
            var ret = g_main_context_iteration(Handle, mayBlock);
            return default(System.Boolean);
        }

        /// <summary>
        /// Checks if any sources have pending events for the given context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// %TRUE if events are pending.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_pending( System.IntPtr context);

        /// <summary>
        /// Checks if any sources have pending events for the given context.
        /// </summary>
        /// <returns>
        /// %TRUE if events are pending.
        /// </returns>
        public System.Boolean Pending()
        {
            var ret = g_main_context_pending(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Pops @context off the thread-default context stack (verifying that
        /// it was on the top of the stack).
        /// </summary>
        /// <param name="context">
        /// a #GMainContext object, or %NULL
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_pop_thread_default( System.IntPtr context);

        /// <summary>
        /// Pops @context off the thread-default context stack (verifying that
        /// it was on the top of the stack).
        /// </summary>
        [GISharp.Core.Since("2.22")]
        public System.Void PopThreadDefault()
        {
            var ret = g_main_context_pop_thread_default(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Prepares to poll sources within a main loop. The resulting information
        /// for polling is determined by calling g_main_context_query ().
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="priority">
        /// location to store priority of highest priority
        ///            source already ready.
        /// </param>
        /// <returns>
        /// %TRUE if some source is ready to be dispatched
        ///               prior to polling.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_main_context_prepare( System.IntPtr context,  System.Int32 priority);

        /// <summary>
        /// Prepares to poll sources within a main loop. The resulting information
        /// for polling is determined by calling g_main_context_query ().
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="priority">
        /// location to store priority of highest priority
        ///            source already ready.
        /// </param>
        /// <returns>
        /// %TRUE if some source is ready to be dispatched
        ///               prior to polling.
        /// </returns>
        public System.Boolean Prepare( System.Int32 priority)
        {
            var ret = g_main_context_prepare(Handle, priority);
            return default(System.Boolean);
        }

        /// <summary>
        /// Acquires @context and sets it as the thread-default context for the
        /// current thread. This will cause certain asynchronous operations
        /// (such as most [gio][gio]-based I/O) which are
        /// started in this thread to run under @context and deliver their
        /// results to its main loop, rather than running under the global
        /// default context in the main thread. Note that calling this function
        /// changes the context returned by g_main_context_get_thread_default(),
        /// not the one returned by g_main_context_default(), so it does not affect
        /// the context used by functions like g_idle_add().
        /// </summary>
        /// <remarks>
        /// Normally you would call this function shortly after creating a new
        /// thread, passing it a #GMainContext which will be run by a
        /// #GMainLoop in that thread, to set a new default context for all
        /// async operations in that thread. (In this case, you don't need to
        /// ever call g_main_context_pop_thread_default().) In some cases
        /// however, you may want to schedule a single operation in a
        /// non-default context, or temporarily use a non-default context in
        /// the main thread. In that case, you can wrap the call to the
        /// asynchronous operation inside a
        /// g_main_context_push_thread_default() /
        /// g_main_context_pop_thread_default() pair, but it is up to you to
        /// ensure that no other asynchronous operations accidentally get
        /// started while the non-default context is active.
        /// 
        /// Beware that libraries that predate this function may not correctly
        /// handle being used from a thread with a thread-default context. Eg,
        /// see g_file_supports_thread_contexts().
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext, or %NULL for the global default context
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_push_thread_default( System.IntPtr context);

        /// <summary>
        /// Acquires @context and sets it as the thread-default context for the
        /// current thread. This will cause certain asynchronous operations
        /// (such as most [gio][gio]-based I/O) which are
        /// started in this thread to run under @context and deliver their
        /// results to its main loop, rather than running under the global
        /// default context in the main thread. Note that calling this function
        /// changes the context returned by g_main_context_get_thread_default(),
        /// not the one returned by g_main_context_default(), so it does not affect
        /// the context used by functions like g_idle_add().
        /// </summary>
        /// <remarks>
        /// Normally you would call this function shortly after creating a new
        /// thread, passing it a #GMainContext which will be run by a
        /// #GMainLoop in that thread, to set a new default context for all
        /// async operations in that thread. (In this case, you don't need to
        /// ever call g_main_context_pop_thread_default().) In some cases
        /// however, you may want to schedule a single operation in a
        /// non-default context, or temporarily use a non-default context in
        /// the main thread. In that case, you can wrap the call to the
        /// asynchronous operation inside a
        /// g_main_context_push_thread_default() /
        /// g_main_context_pop_thread_default() pair, but it is up to you to
        /// ensure that no other asynchronous operations accidentally get
        /// started while the non-default context is active.
        /// 
        /// Beware that libraries that predate this function may not correctly
        /// handle being used from a thread with a thread-default context. Eg,
        /// see g_file_supports_thread_contexts().
        /// </remarks>
        [GISharp.Core.Since("2.22")]
        public System.Void PushThreadDefault()
        {
            var ret = g_main_context_push_thread_default(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Determines information necessary to poll this main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="maxPriority">
        /// maximum priority source to check
        /// </param>
        /// <param name="timeout">
        /// location to store timeout to be used in polling
        /// </param>
        /// <param name="fds">
        /// location to
        ///       store #GPollFD records that need to be polled.
        /// </param>
        /// <param name="nFds">
        /// length of @fds.
        /// </param>
        /// <returns>
        /// the number of records actually stored in @fds,
        ///   or, if more than @n_fds records need to be stored, the number
        ///   of records that need to be stored.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_main_context_query( System.IntPtr context,  System.Int32 maxPriority, out System.Int32 timeout, out System.IntPtr[] fds,  System.Int32 nFds);

        /// <summary>
        /// Determines information necessary to poll this main loop.
        /// </summary>
        /// <remarks>
        /// You must have successfully acquired the context with
        /// g_main_context_acquire() before you may call this function.
        /// </remarks>
        /// <param name="maxPriority">
        /// maximum priority source to check
        /// </param>
        /// <param name="timeout">
        /// location to store timeout to be used in polling
        /// </param>
        /// <param name="fds">
        /// location to
        ///       store #GPollFD records that need to be polled.
        /// </param>
        /// <returns>
        /// the number of records actually stored in @fds,
        ///   or, if more than @n_fds records need to be stored, the number
        ///   of records that need to be stored.
        /// </returns>
        public System.Int32 Query( System.Int32 maxPriority, out System.Int32 timeout, out GISharp.GLib.PollFD[] fds)
        {
            var ret = g_main_context_query(Handle, maxPriority, timeout, fds, nFds);
            return default(System.Int32);
        }

        /// <summary>
        /// Increases the reference count on a #GMainContext object by one.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <returns>
        /// the @context that was passed in (since 2.6)
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_ref( System.IntPtr context);

        /// <summary>
        /// Increases the reference count on a #GMainContext object by one.
        /// </summary>
        /// <returns>
        /// the @context that was passed in (since 2.6)
        /// </returns>
        protected override void Ref()
        {
            var ret = g_main_context_ref(Handle);
        }

        /// <summary>
        /// Releases ownership of a context previously acquired by this thread
        /// with g_main_context_acquire(). If the context was acquired multiple
        /// times, the ownership will be released only when g_main_context_release()
        /// is called as many times as it was acquired.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_release( System.IntPtr context);

        /// <summary>
        /// Releases ownership of a context previously acquired by this thread
        /// with g_main_context_acquire(). If the context was acquired multiple
        /// times, the ownership will be released only when g_main_context_release()
        /// is called as many times as it was acquired.
        /// </summary>
        public System.Void Release()
        {
            var ret = g_main_context_release(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Removes file descriptor from the set of file descriptors to be
        /// polled for a particular context.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="fd">
        /// a #GPollFD descriptor previously added with g_main_context_add_poll()
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_remove_poll( System.IntPtr context,  System.IntPtr fd);

        /// <summary>
        /// Removes file descriptor from the set of file descriptors to be
        /// polled for a particular context.
        /// </summary>
        /// <param name="fd">
        /// a #GPollFD descriptor previously added with g_main_context_add_poll()
        /// </param>
        public System.Void RemovePoll( GISharp.GLib.PollFD fd)
        {
            var ret = g_main_context_remove_poll(Handle, fd);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the function to use to handle polling of file descriptors. It
        /// will be used instead of the poll() system call
        /// (or GLib's replacement function, which is used where
        /// poll() isn't available).
        /// </summary>
        /// <remarks>
        /// This function could possibly be used to integrate the GLib event
        /// loop with an external event loop.
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        /// <param name="func">
        /// the function to call to poll all file descriptors
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_set_poll_func( System.IntPtr context,  System.IntPtr func);

        /// <summary>
        /// Sets the function to use to handle polling of file descriptors. It
        /// will be used instead of the poll() system call
        /// (or GLib's replacement function, which is used where
        /// poll() isn't available).
        /// </summary>
        /// <remarks>
        /// This function could possibly be used to integrate the GLib event
        /// loop with an external event loop.
        /// </remarks>
        /// <param name="value">
        /// the function to call to poll all file descriptors
        /// </param>
        public System.Void set_PollFunc( GISharp.GLib.PollFunc value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_main_context_set_poll_func(Handle, func);
            return default(System.Void);
        }

        /// <summary>
        /// Decreases the reference count on a #GMainContext object by one. If
        /// the result is zero, free the context and free all associated memory.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_unref( System.IntPtr context);

        /// <summary>
        /// Decreases the reference count on a #GMainContext object by one. If
        /// the result is zero, free the context and free all associated memory.
        /// </summary>
        protected override System.Void Unref()
        {
            var ret = g_main_context_unref(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// If @context is currently blocking in g_main_context_iteration()
        /// waiting for a source to become ready, cause it to stop blocking
        /// and return.  Otherwise, cause the next invocation of
        /// g_main_context_iteration() to return without blocking.
        /// </summary>
        /// <remarks>
        /// This API is useful for low-level control over #GMainContext; for
        /// example, integrating it with main loop implementations such as
        /// #GMainLoop.
        /// 
        /// Another related use for this function is when implementing a main
        /// loop with a termination condition, computed from multiple threads:
        /// 
        /// |[&lt;!-- language="C" --&gt;
        ///   #define NUM_TASKS 10
        ///   static volatile gint tasks_remaining = NUM_TASKS;
        ///   ...
        ///  
        ///   while (g_atomic_int_get (&amp;tasks_remaining) != 0)
        ///     g_main_context_iteration (NULL, TRUE);
        /// ]|
        ///  
        /// Then in a thread:
        /// |[&lt;!-- language="C" --&gt;
        ///   perform_work();
        /// 
        ///   if (g_atomic_int_dec_and_test (&amp;tasks_remaining))
        ///     g_main_context_wakeup (NULL);
        /// ]|
        /// </remarks>
        /// <param name="context">
        /// a #GMainContext
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_context_wakeup( System.IntPtr context);

        /// <summary>
        /// If @context is currently blocking in g_main_context_iteration()
        /// waiting for a source to become ready, cause it to stop blocking
        /// and return.  Otherwise, cause the next invocation of
        /// g_main_context_iteration() to return without blocking.
        /// </summary>
        /// <remarks>
        /// This API is useful for low-level control over #GMainContext; for
        /// example, integrating it with main loop implementations such as
        /// #GMainLoop.
        /// 
        /// Another related use for this function is when implementing a main
        /// loop with a termination condition, computed from multiple threads:
        /// 
        /// |[&lt;!-- language="C" --&gt;
        ///   #define NUM_TASKS 10
        ///   static volatile gint tasks_remaining = NUM_TASKS;
        ///   ...
        ///  
        ///   while (g_atomic_int_get (&amp;tasks_remaining) != 0)
        ///     g_main_context_iteration (NULL, TRUE);
        /// ]|
        ///  
        /// Then in a thread:
        /// |[&lt;!-- language="C" --&gt;
        ///   perform_work();
        /// 
        ///   if (g_atomic_int_dec_and_test (&amp;tasks_remaining))
        ///     g_main_context_wakeup (NULL);
        /// ]|
        /// </remarks>
        public System.Void Wakeup()
        {
            var ret = g_main_context_wakeup(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the global default main context. This is the main context
        /// used for main loop functions when a main loop is not explicitly
        /// specified, and corresponds to the "main" main loop. See also
        /// g_main_context_get_thread_default().
        /// </summary>
        /// <returns>
        /// the global default main context.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_default();

        /// <summary>
        /// Returns the global default main context. This is the main context
        /// used for main loop functions when a main loop is not explicitly
        /// specified, and corresponds to the "main" main loop. See also
        /// g_main_context_get_thread_default().
        /// </summary>
        /// <returns>
        /// the global default main context.
        /// </returns>
        public static GISharp.GLib.MainContext get_Default()
        {
            var ret = g_main_context_default();
            return default(GISharp.GLib.MainContext);
        }

        /// <summary>
        /// Gets the thread-default #GMainContext for this thread, as with
        /// g_main_context_get_thread_default(), but also adds a reference to
        /// it with g_main_context_ref(). In addition, unlike
        /// g_main_context_get_thread_default(), if the thread-default context
        /// is the global default context, this will return that #GMainContext
        /// (with a ref added to it) rather than returning %NULL.
        /// </summary>
        /// <returns>
        /// the thread-default #GMainContext. Unref
        ///     with g_main_context_unref() when you are done with it.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_context_ref_thread_default();

        /// <summary>
        /// Gets the thread-default #GMainContext for this thread, as with
        /// g_main_context_get_thread_default(), but also adds a reference to
        /// it with g_main_context_ref(). In addition, unlike
        /// g_main_context_get_thread_default(), if the thread-default context
        /// is the global default context, this will return that #GMainContext
        /// (with a ref added to it) rather than returning %NULL.
        /// </summary>
        /// <returns>
        /// the thread-default #GMainContext. Unref
        ///     with g_main_context_unref() when you are done with it.
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public static GISharp.GLib.MainContext RefThreadDefault()
        {
            var ret = g_main_context_ref_thread_default();
            return default(GISharp.GLib.MainContext);
        }

        /// <summary>
        /// Returns the depth of the stack of calls to
        /// g_main_context_dispatch() on any #GMainContext in the current thread.
        ///  That is, when called from the toplevel, it gives 0. When
        /// called from within a callback from g_main_context_iteration()
        /// (or g_main_loop_run(), etc.) it returns 1. When called from within
        /// a callback to a recursive call to g_main_context_iteration(),
        /// it returns 2. And so forth.
        /// </summary>
        /// <remarks>
        /// This function is useful in a situation like the following:
        /// Imagine an extremely simple "garbage collected" system.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static GList *free_list;
        /// 
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   gpointer result = g_malloc (size);
        ///   free_list = g_list_prepend (free_list, result);
        ///   return result;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   for (l = free_list; l; l = l-&gt;next);
        ///     g_free (l-&gt;data);
        ///   g_list_free (free_list);
        ///   free_list = NULL;
        ///  }
        /// 
        /// [...]
        /// 
        /// while (TRUE);
        ///  {
        ///    g_main_context_iteration (NULL, TRUE);
        ///    free_allocated_memory();
        ///   }
        /// ]|
        /// 
        /// This works from an application, however, if you want to do the same
        /// thing from a library, it gets more difficult, since you no longer
        /// control the main loop. You might think you can simply use an idle
        /// function to make the call to free_allocated_memory(), but that
        /// doesn't work, since the idle function could be called from a
        /// recursive callback. This can be fixed by using g_main_depth()
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   FreeListBlock *block = g_new (FreeListBlock, 1);
        ///   block-&gt;mem = g_malloc (size);
        ///   block-&gt;depth = g_main_depth ();
        ///   free_list = g_list_prepend (free_list, block);
        ///   return block-&gt;mem;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   
        ///   int depth = g_main_depth ();
        ///   for (l = free_list; l; );
        ///     {
        ///       GList *next = l-&gt;next;
        ///       FreeListBlock *block = l-&gt;data;
        ///       if (block-&gt;depth &gt; depth)
        ///         {
        ///           g_free (block-&gt;mem);
        ///           g_free (block);
        ///           free_list = g_list_delete_link (free_list, l);
        ///         }
        ///               
        ///       l = next;
        ///     }
        ///   }
        /// ]|
        /// 
        /// There is a temptation to use g_main_depth() to solve
        /// problems with reentrancy. For instance, while waiting for data
        /// to be received from the network in response to a menu item,
        /// the menu item might be selected again. It might seem that
        /// one could make the menu item's callback return immediately
        /// and do nothing if g_main_depth() returns a value greater than 1.
        /// However, this should be avoided since the user then sees selecting
        /// the menu item do nothing. Furthermore, you'll find yourself adding
        /// these checks all over your code, since there are doubtless many,
        /// many things that the user could do. Instead, you can use the
        /// following techniques:
        /// 
        /// 1. Use gtk_widget_set_sensitive() or modal dialogs to prevent
        ///    the user from interacting with elements while the main
        ///    loop is recursing.
        /// 
        /// 2. Avoid main loop recursion in situations where you can't handle
        ///    arbitrary  callbacks. Instead, structure your code so that you
        ///    simply return to the main loop and then get called again when
        ///    there is more work to do.
        /// </remarks>
        /// <returns>
        /// The main loop recursion level in the current thread
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_main_depth();

        /// <summary>
        /// Returns the depth of the stack of calls to
        /// g_main_context_dispatch() on any #GMainContext in the current thread.
        ///  That is, when called from the toplevel, it gives 0. When
        /// called from within a callback from g_main_context_iteration()
        /// (or g_main_loop_run(), etc.) it returns 1. When called from within
        /// a callback to a recursive call to g_main_context_iteration(),
        /// it returns 2. And so forth.
        /// </summary>
        /// <remarks>
        /// This function is useful in a situation like the following:
        /// Imagine an extremely simple "garbage collected" system.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static GList *free_list;
        /// 
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   gpointer result = g_malloc (size);
        ///   free_list = g_list_prepend (free_list, result);
        ///   return result;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   for (l = free_list; l; l = l-&gt;next);
        ///     g_free (l-&gt;data);
        ///   g_list_free (free_list);
        ///   free_list = NULL;
        ///  }
        /// 
        /// [...]
        /// 
        /// while (TRUE);
        ///  {
        ///    g_main_context_iteration (NULL, TRUE);
        ///    free_allocated_memory();
        ///   }
        /// ]|
        /// 
        /// This works from an application, however, if you want to do the same
        /// thing from a library, it gets more difficult, since you no longer
        /// control the main loop. You might think you can simply use an idle
        /// function to make the call to free_allocated_memory(), but that
        /// doesn't work, since the idle function could be called from a
        /// recursive callback. This can be fixed by using g_main_depth()
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// gpointer
        /// allocate_memory (gsize size)
        /// {
        ///   FreeListBlock *block = g_new (FreeListBlock, 1);
        ///   block-&gt;mem = g_malloc (size);
        ///   block-&gt;depth = g_main_depth ();
        ///   free_list = g_list_prepend (free_list, block);
        ///   return block-&gt;mem;
        /// }
        /// 
        /// void
        /// free_allocated_memory (void)
        /// {
        ///   GList *l;
        ///   
        ///   int depth = g_main_depth ();
        ///   for (l = free_list; l; );
        ///     {
        ///       GList *next = l-&gt;next;
        ///       FreeListBlock *block = l-&gt;data;
        ///       if (block-&gt;depth &gt; depth)
        ///         {
        ///           g_free (block-&gt;mem);
        ///           g_free (block);
        ///           free_list = g_list_delete_link (free_list, l);
        ///         }
        ///               
        ///       l = next;
        ///     }
        ///   }
        /// ]|
        /// 
        /// There is a temptation to use g_main_depth() to solve
        /// problems with reentrancy. For instance, while waiting for data
        /// to be received from the network in response to a menu item,
        /// the menu item might be selected again. It might seem that
        /// one could make the menu item's callback return immediately
        /// and do nothing if g_main_depth() returns a value greater than 1.
        /// However, this should be avoided since the user then sees selecting
        /// the menu item do nothing. Furthermore, you'll find yourself adding
        /// these checks all over your code, since there are doubtless many,
        /// many things that the user could do. Instead, you can use the
        /// following techniques:
        /// 
        /// 1. Use gtk_widget_set_sensitive() or modal dialogs to prevent
        ///    the user from interacting with elements while the main
        ///    loop is recursing.
        /// 
        /// 2. Avoid main loop recursion in situations where you can't handle
        ///    arbitrary  callbacks. Instead, structure your code so that you
        ///    simply return to the main loop and then get called again when
        ///    there is more work to do.
        /// </remarks>
        /// <returns>
        /// The main loop recursion level in the current thread
        /// </returns>
        public static System.Int32 MainDepth()
        {
            var ret = g_main_depth();
            return default(System.Int32);
        }

        /// <summary>
        /// Polls @fds, as with the poll() system call, but portably. (On
        /// systems that don't have poll(), it is emulated using select().)
        /// This is used internally by #GMainContext, but it can be called
        /// directly if you need to block until a file descriptor is ready, but
        /// don't want to run the full main loop.
        /// </summary>
        /// <remarks>
        /// Each element of @fds is a #GPollFD describing a single file
        /// descriptor to poll. The %fd field indicates the file descriptor,
        /// and the %events field indicates the events to poll for. On return,
        /// the %revents fields will be filled with the events that actually
        /// occurred.
        /// 
        /// On POSIX systems, the file descriptors in @fds can be any sort of
        /// file descriptor, but the situation is much more complicated on
        /// Windows. If you need to use g_poll() in code that has to run on
        /// Windows, the easiest solution is to construct all of your
        /// #GPollFDs with g_io_channel_win32_make_pollfd().
        /// </remarks>
        /// <param name="fds">
        /// file descriptors to poll
        /// </param>
        /// <param name="nfds">
        /// the number of file descriptors in @fds
        /// </param>
        /// <param name="timeout">
        /// amount of time to wait, in milliseconds, or -1 to wait forever
        /// </param>
        /// <returns>
        /// the number of entries in @fds whose %revents fields
        /// were filled in, or 0 if the operation timed out, or -1 on error or
        /// if the call was interrupted.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_poll( System.IntPtr fds,  System.UInt32 nfds,  System.Int32 timeout);

        /// <summary>
        /// Polls @fds, as with the poll() system call, but portably. (On
        /// systems that don't have poll(), it is emulated using select().)
        /// This is used internally by #GMainContext, but it can be called
        /// directly if you need to block until a file descriptor is ready, but
        /// don't want to run the full main loop.
        /// </summary>
        /// <remarks>
        /// Each element of @fds is a #GPollFD describing a single file
        /// descriptor to poll. The %fd field indicates the file descriptor,
        /// and the %events field indicates the events to poll for. On return,
        /// the %revents fields will be filled with the events that actually
        /// occurred.
        /// 
        /// On POSIX systems, the file descriptors in @fds can be any sort of
        /// file descriptor, but the situation is much more complicated on
        /// Windows. If you need to use g_poll() in code that has to run on
        /// Windows, the easiest solution is to construct all of your
        /// #GPollFDs with g_io_channel_win32_make_pollfd().
        /// </remarks>
        /// <param name="fds">
        /// file descriptors to poll
        /// </param>
        /// <param name="nfds">
        /// the number of file descriptors in @fds
        /// </param>
        /// <param name="timeout">
        /// amount of time to wait, in milliseconds, or -1 to wait forever
        /// </param>
        /// <returns>
        /// the number of entries in @fds whose %revents fields
        /// were filled in, or 0 if the operation timed out, or -1 on error or
        /// if the call was interrupted.
        /// </returns>
        [GISharp.Core.Since("2.20")]
        public static System.Int32 Poll( GISharp.GLib.PollFD fds,  System.UInt32 nfds,  System.Int32 timeout)
        {
            var ret = g_poll(fds, nfds, timeout);
            return default(System.Int32);
        }
    }

    /// <summary>
    /// The `GMainLoop` struct is an opaque data type
    /// representing the main event loop of a GLib or GTK+ application.
    /// </summary>
    public partial class MainLoop : GISharp.Core.ReferenceCountedOpaque<MainLoop>
    {
        public MainLoop(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GMainLoop structure.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext  (if %NULL, the default context will be used).
        /// </param>
        /// <param name="isRunning">
        /// set to %TRUE to indicate that the loop is running. This
        /// is not very important since calling g_main_loop_run() will set this to
        /// %TRUE anyway.
        /// </param>
        /// <returns>
        /// a new #GMainLoop.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_loop_new( System.IntPtr context,  System.Boolean isRunning);

        /// <summary>
        /// Creates a new #GMainLoop structure.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext  (if %NULL, the default context will be used).
        /// </param>
        /// <param name="isRunning">
        /// set to %TRUE to indicate that the loop is running. This
        /// is not very important since calling g_main_loop_run() will set this to
        /// %TRUE anyway.
        /// </param>
        /// <returns>
        /// a new #GMainLoop.
        /// </returns>
        public MainLoop( GISharp.GLib.MainContext context = null,  System.Boolean isRunning = false) : base(IntPtr.Zero)
        {
            var ret = g_main_loop_new(context, isRunning);
        }

        /// <summary>
        /// Returns the #GMainContext of @loop.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop.
        /// </param>
        /// <returns>
        /// the #GMainContext of @loop
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_loop_get_context( System.IntPtr loop);

        /// <summary>
        /// Returns the #GMainContext of @loop.
        /// </summary>
        /// <returns>
        /// the #GMainContext of @loop
        /// </returns>
        public GISharp.GLib.MainContext get_Context()
        {
            var ret = g_main_loop_get_context(Handle);
            return default(GISharp.GLib.MainContext);
        }

        /// <summary>
        /// Checks to see if the main loop is currently being run via g_main_loop_run().
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop.
        /// </param>
        /// <returns>
        /// %TRUE if the mainloop is currently being run.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_main_loop_is_running( System.IntPtr loop);

        /// <summary>
        /// Checks to see if the main loop is currently being run via g_main_loop_run().
        /// </summary>
        /// <returns>
        /// %TRUE if the mainloop is currently being run.
        /// </returns>
        public System.Boolean get_IsRunning()
        {
            var ret = g_main_loop_is_running(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Stops a #GMainLoop from running. Any calls to g_main_loop_run()
        /// for the loop will return.
        /// </summary>
        /// <remarks>
        /// Note that sources that have already been dispatched when
        /// g_main_loop_quit() is called will still be executed.
        /// </remarks>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_loop_quit( System.IntPtr loop);

        /// <summary>
        /// Stops a #GMainLoop from running. Any calls to g_main_loop_run()
        /// for the loop will return.
        /// </summary>
        /// <remarks>
        /// Note that sources that have already been dispatched when
        /// g_main_loop_quit() is called will still be executed.
        /// </remarks>
        public System.Void Quit()
        {
            var ret = g_main_loop_quit(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Increases the reference count on a #GMainLoop object by one.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        /// <returns>
        /// @loop
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_loop_ref( System.IntPtr loop);

        /// <summary>
        /// Increases the reference count on a #GMainLoop object by one.
        /// </summary>
        /// <returns>
        /// @loop
        /// </returns>
        protected override void Ref()
        {
            var ret = g_main_loop_ref(Handle);
        }

        /// <summary>
        /// Runs a main loop until g_main_loop_quit() is called on the loop.
        /// If this is called for the thread of the loop's #GMainContext,
        /// it will process events from the loop, otherwise it will
        /// simply wait.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_loop_run( System.IntPtr loop);

        /// <summary>
        /// Runs a main loop until g_main_loop_quit() is called on the loop.
        /// If this is called for the thread of the loop's #GMainContext,
        /// it will process events from the loop, otherwise it will
        /// simply wait.
        /// </summary>
        public System.Void Run()
        {
            var ret = g_main_loop_run(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Decreases the reference count on a #GMainLoop object by one. If
        /// the result is zero, free the loop and free all associated memory.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_main_loop_unref( System.IntPtr loop);

        /// <summary>
        /// Decreases the reference count on a #GMainLoop object by one. If
        /// the result is zero, free the loop and free all associated memory.
        /// </summary>
        protected override System.Void Unref()
        {
            var ret = g_main_loop_unref(Handle);
            return default(System.Void);
        }
    }

    /// <summary>
    /// The #GNode struct represents one node in a [n-ary tree][glib-N-ary-Trees].
    /// </summary>
    public partial class Node : GISharp.Core.OwnedOpaque<Node>
    {
        public Node(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Gets the position of the first child of a #GNode
        /// which contains the given data.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the child of @node which contains
        ///     @data, or -1 if the data is not found
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_node_child_index( System.IntPtr node,  System.IntPtr data);

        /// <summary>
        /// Gets the position of the first child of a #GNode
        /// which contains the given data.
        /// </summary>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the child of @node which contains
        ///     @data, or -1 if the data is not found
        /// </returns>
        public System.Int32 ChildIndex( System.IntPtr data)
        {
            var ret = g_node_child_index(Handle, data);
            return default(System.Int32);
        }

        /// <summary>
        /// Gets the position of a #GNode with respect to its siblings.
        /// @child must be a child of @node. The first child is numbered 0,
        /// the second 1, and so on.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="child">
        /// a child of @node
        /// </param>
        /// <returns>
        /// the position of @child with respect to its siblings
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_node_child_position( System.IntPtr node,  System.IntPtr child);

        /// <summary>
        /// Gets the position of a #GNode with respect to its siblings.
        /// @child must be a child of @node. The first child is numbered 0,
        /// the second 1, and so on.
        /// </summary>
        /// <param name="child">
        /// a child of @node
        /// </param>
        /// <returns>
        /// the position of @child with respect to its siblings
        /// </returns>
        public System.Int32 ChildPosition( GISharp.GLib.Node child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("child");
            }
            var ret = g_node_child_position(Handle, child);
            return default(System.Int32);
        }

        /// <summary>
        /// Calls a function for each of the children of a #GNode.
        /// Note that it doesn't descend beneath the child nodes.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="func">
        /// the function to call for each visited node
        /// </param>
        /// <param name="data">
        /// user data to pass to the function
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_node_children_foreach( System.IntPtr node,  System.IntPtr flags,  System.IntPtr func,  System.IntPtr data);

        /// <summary>
        /// Calls a function for each of the children of a #GNode.
        /// Note that it doesn't descend beneath the child nodes.
        /// </summary>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="func">
        /// the function to call for each visited node
        /// </param>
        public System.Void ChildrenForeach( GISharp.GLib.TraverseFlags flags,  GISharp.GLib.NodeForeachFunc func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_node_children_foreach(Handle, flags, func, data);
            return default(System.Void);
        }

        /// <summary>
        /// Recursively copies a #GNode (but does not deep-copy the data inside the
        /// nodes, see g_node_copy_deep() if you need that).
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// a new #GNode containing the same data pointers
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_copy( System.IntPtr node);

        /// <summary>
        /// Recursively copies a #GNode (but does not deep-copy the data inside the
        /// nodes, see g_node_copy_deep() if you need that).
        /// </summary>
        /// <returns>
        /// a new #GNode containing the same data pointers
        /// </returns>
        public override GISharp.GLib.Node Copy()
        {
            var ret = g_node_copy(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Recursively copies a #GNode and its data.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="copyFunc">
        /// the function which is called to copy the data inside each node,
        ///   or %NULL to use the original data.
        /// </param>
        /// <param name="data">
        /// data to pass to @copy_func
        /// </param>
        /// <returns>
        /// a new #GNode containing copies of the data in @node.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_copy_deep( System.IntPtr node,  System.IntPtr copyFunc,  System.IntPtr data);

        /// <summary>
        /// Recursively copies a #GNode and its data.
        /// </summary>
        /// <param name="copyFunc">
        /// the function which is called to copy the data inside each node,
        ///   or %NULL to use the original data.
        /// </param>
        /// <returns>
        /// a new #GNode containing copies of the data in @node.
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public GISharp.GLib.Node CopyDeep( GISharp.Core.CopyFunc`1[GISharp.GLib.Node]copyFunc)
        {
            if (copyFunc == null)
            {
                throw new ArgumentNullException("copyFunc");
            }
            var ret = g_node_copy_deep(Handle, copyFunc, data);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the depth of a #GNode.
        /// </summary>
        /// <remarks>
        /// If @node is %NULL the depth is 0. The root node has a depth of 1.
        /// For the children of the root node the depth is 2. And so on.
        /// </remarks>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the depth of the #GNode
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_depth( System.IntPtr node);

        /// <summary>
        /// Gets the depth of a #GNode.
        /// </summary>
        /// <remarks>
        /// If @node is %NULL the depth is 0. The root node has a depth of 1.
        /// For the children of the root node the depth is 2. And so on.
        /// </remarks>
        /// <returns>
        /// the depth of the #GNode
        /// </returns>
        public System.UInt32 Depth()
        {
            var ret = g_node_depth(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Removes @root and its children from the tree, freeing any memory
        /// allocated.
        /// </summary>
        /// <param name="root">
        /// the root of the tree/subtree to destroy
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_node_destroy( System.IntPtr root);

        /// <summary>
        /// Removes @root and its children from the tree, freeing any memory
        /// allocated.
        /// </summary>
        protected override System.Void Free()
        {
            var ret = g_node_destroy(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Finds a #GNode in a tree.
        /// </summary>
        /// <param name="root">
        /// the root #GNode of the tree to search
        /// </param>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER
        /// </param>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found #GNode, or %NULL if the data is not found
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_find( System.IntPtr root,  System.IntPtr order,  System.IntPtr flags,  System.IntPtr data);

        /// <summary>
        /// Finds a #GNode in a tree.
        /// </summary>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER
        /// </param>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found #GNode, or %NULL if the data is not found
        /// </returns>
        public GISharp.GLib.Node Find( GISharp.GLib.TraverseType order,  GISharp.GLib.TraverseFlags flags,  System.IntPtr data)
        {
            var ret = g_node_find(Handle, order, flags, data);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Finds the first child of a #GNode with the given data.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found child #GNode, or %NULL if the data is not found
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_find_child( System.IntPtr node,  System.IntPtr flags,  System.IntPtr data);

        /// <summary>
        /// Finds the first child of a #GNode with the given data.
        /// </summary>
        /// <param name="flags">
        /// which types of children are to be searched, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the found child #GNode, or %NULL if the data is not found
        /// </returns>
        public GISharp.GLib.Node FindChild( GISharp.GLib.TraverseFlags flags,  System.IntPtr data)
        {
            var ret = g_node_find_child(Handle, flags, data);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the first sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the first sibling of @node
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_first_sibling( System.IntPtr node);

        /// <summary>
        /// Gets the first sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <returns>
        /// the first sibling of @node
        /// </returns>
        public GISharp.GLib.Node FirstSibling()
        {
            var ret = g_node_first_sibling(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the root of a tree.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the root of the tree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_get_root( System.IntPtr node);

        /// <summary>
        /// Gets the root of a tree.
        /// </summary>
        /// <returns>
        /// the root of the tree
        /// </returns>
        public GISharp.GLib.Node get_Root()
        {
            var ret = g_node_get_root(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Inserts a #GNode beneath the parent at the given position.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place @node under
        /// </param>
        /// <param name="position">
        /// the position to place @node at, with respect to its siblings
        ///     If position is -1, @node is inserted as the last child of @parent
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_insert( System.IntPtr parent,  System.Int32 position,  System.IntPtr node);

        /// <summary>
        /// Inserts a #GNode beneath the parent at the given position.
        /// </summary>
        /// <param name="position">
        /// the position to place @node at, with respect to its siblings
        ///     If position is -1, @node is inserted as the last child of @parent
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node Insert( System.Int32 position,  GISharp.GLib.Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            var ret = g_node_insert(Handle, position, node);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Inserts a #GNode beneath the parent after the given sibling.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place @node under
        /// </param>
        /// <param name="sibling">
        /// the sibling #GNode to place @node after.
        ///     If sibling is %NULL, the node is inserted as the first child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_insert_after( System.IntPtr parent,  System.IntPtr sibling,  System.IntPtr node);

        /// <summary>
        /// Inserts a #GNode beneath the parent after the given sibling.
        /// </summary>
        /// <param name="sibling">
        /// the sibling #GNode to place @node after.
        ///     If sibling is %NULL, the node is inserted as the first child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node InsertAfter( GISharp.GLib.Node sibling,  GISharp.GLib.Node node)
        {
            if (sibling == null)
            {
                throw new ArgumentNullException("sibling");
            }
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            var ret = g_node_insert_after(Handle, sibling, node);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Inserts a #GNode beneath the parent before the given sibling.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place @node under
        /// </param>
        /// <param name="sibling">
        /// the sibling #GNode to place @node before.
        ///     If sibling is %NULL, the node is inserted as the last child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_insert_before( System.IntPtr parent,  System.IntPtr sibling,  System.IntPtr node);

        /// <summary>
        /// Inserts a #GNode beneath the parent before the given sibling.
        /// </summary>
        /// <param name="sibling">
        /// the sibling #GNode to place @node before.
        ///     If sibling is %NULL, the node is inserted as the last child of @parent.
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node InsertBefore( GISharp.GLib.Node sibling,  GISharp.GLib.Node node)
        {
            if (sibling == null)
            {
                throw new ArgumentNullException("sibling");
            }
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            var ret = g_node_insert_before(Handle, sibling, node);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Returns %TRUE if @node is an ancestor of @descendant.
        /// This is true if node is the parent of @descendant,
        /// or if node is the grandparent of @descendant etc.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="descendant">
        /// a #GNode
        /// </param>
        /// <returns>
        /// %TRUE if @node is an ancestor of @descendant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_node_is_ancestor( System.IntPtr node,  System.IntPtr descendant);

        /// <summary>
        /// Returns %TRUE if @node is an ancestor of @descendant.
        /// This is true if node is the parent of @descendant,
        /// or if node is the grandparent of @descendant etc.
        /// </summary>
        /// <param name="descendant">
        /// a #GNode
        /// </param>
        /// <returns>
        /// %TRUE if @node is an ancestor of @descendant
        /// </returns>
        public System.Boolean IsAncestor( GISharp.GLib.Node descendant)
        {
            if (descendant == null)
            {
                throw new ArgumentNullException("descendant");
            }
            var ret = g_node_is_ancestor(Handle, descendant);
            return default(System.Boolean);
        }

        /// <summary>
        /// Gets the last child of a #GNode.
        /// </summary>
        /// <param name="node">
        /// a #GNode (must not be %NULL)
        /// </param>
        /// <returns>
        /// the last child of @node, or %NULL if @node has no children
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_last_child( System.IntPtr node);

        /// <summary>
        /// Gets the last child of a #GNode.
        /// </summary>
        /// <returns>
        /// the last child of @node, or %NULL if @node has no children
        /// </returns>
        public GISharp.GLib.Node LastChild()
        {
            var ret = g_node_last_child(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the last sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the last sibling of @node
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_last_sibling( System.IntPtr node);

        /// <summary>
        /// Gets the last sibling of a #GNode.
        /// This could possibly be the node itself.
        /// </summary>
        /// <returns>
        /// the last sibling of @node
        /// </returns>
        public GISharp.GLib.Node LastSibling()
        {
            var ret = g_node_last_sibling(Handle);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Gets the maximum height of all branches beneath a #GNode.
        /// This is the maximum distance from the #GNode to all leaf nodes.
        /// </summary>
        /// <remarks>
        /// If @root is %NULL, 0 is returned. If @root has no children,
        /// 1 is returned. If @root has children, 2 is returned. And so on.
        /// </remarks>
        /// <param name="root">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the maximum height of the tree beneath @root
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_max_height( System.IntPtr root);

        /// <summary>
        /// Gets the maximum height of all branches beneath a #GNode.
        /// This is the maximum distance from the #GNode to all leaf nodes.
        /// </summary>
        /// <remarks>
        /// If @root is %NULL, 0 is returned. If @root has no children,
        /// 1 is returned. If @root has children, 2 is returned. And so on.
        /// </remarks>
        /// <returns>
        /// the maximum height of the tree beneath @root
        /// </returns>
        public System.UInt32 MaxHeight()
        {
            var ret = g_node_max_height(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Gets the number of children of a #GNode.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <returns>
        /// the number of children of @node
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_n_children( System.IntPtr node);

        /// <summary>
        /// Gets the number of children of a #GNode.
        /// </summary>
        /// <returns>
        /// the number of children of @node
        /// </returns>
        public System.UInt32 NChildren()
        {
            var ret = g_node_n_children(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Gets the number of nodes in a tree.
        /// </summary>
        /// <param name="root">
        /// a #GNode
        /// </param>
        /// <param name="flags">
        /// which types of children are to be counted, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <returns>
        /// the number of nodes in the tree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_node_n_nodes( System.IntPtr root,  System.IntPtr flags);

        /// <summary>
        /// Gets the number of nodes in a tree.
        /// </summary>
        /// <param name="flags">
        /// which types of children are to be counted, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <returns>
        /// the number of nodes in the tree
        /// </returns>
        public System.UInt32 NNodes( GISharp.GLib.TraverseFlags flags)
        {
            var ret = g_node_n_nodes(Handle, flags);
            return default(System.UInt32);
        }

        /// <summary>
        /// Gets a child of a #GNode, using the given index.
        /// The first child is at index 0. If the index is
        /// too big, %NULL is returned.
        /// </summary>
        /// <param name="node">
        /// a #GNode
        /// </param>
        /// <param name="n">
        /// the index of the desired child
        /// </param>
        /// <returns>
        /// the child of @node at index @n
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_nth_child( System.IntPtr node,  System.UInt32 n);

        /// <summary>
        /// Gets a child of a #GNode, using the given index.
        /// The first child is at index 0. If the index is
        /// too big, %NULL is returned.
        /// </summary>
        /// <param name="n">
        /// the index of the desired child
        /// </param>
        /// <returns>
        /// the child of @node at index @n
        /// </returns>
        public GISharp.GLib.Node NthChild( System.UInt32 n)
        {
            var ret = g_node_nth_child(Handle, n);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Inserts a #GNode as the first child of the given parent.
        /// </summary>
        /// <param name="parent">
        /// the #GNode to place the new #GNode under
        /// </param>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_prepend( System.IntPtr parent,  System.IntPtr node);

        /// <summary>
        /// Inserts a #GNode as the first child of the given parent.
        /// </summary>
        /// <param name="node">
        /// the #GNode to insert
        /// </param>
        /// <returns>
        /// the inserted #GNode
        /// </returns>
        public GISharp.GLib.Node Prepend( GISharp.GLib.Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            var ret = g_node_prepend(Handle, node);
            return default(GISharp.GLib.Node);
        }

        /// <summary>
        /// Reverses the order of the children of a #GNode.
        /// (It doesn't change the order of the grandchildren.)
        /// </summary>
        /// <param name="node">
        /// a #GNode.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_node_reverse_children( System.IntPtr node);

        /// <summary>
        /// Reverses the order of the children of a #GNode.
        /// (It doesn't change the order of the grandchildren.)
        /// </summary>
        public System.Void ReverseChildren()
        {
            var ret = g_node_reverse_children(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Traverses a tree starting at the given root #GNode.
        /// It calls the given function for each node visited.
        /// The traversal can be halted at any point by returning %TRUE from @func.
        /// </summary>
        /// <param name="root">
        /// the root #GNode of the tree to traverse
        /// </param>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER.
        /// </param>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="maxDepth">
        /// the maximum depth of the traversal. Nodes below this
        ///     depth will not be visited. If max_depth is -1 all nodes in
        ///     the tree are visited. If depth is 1, only the root is visited.
        ///     If depth is 2, the root and its children are visited. And so on.
        /// </param>
        /// <param name="func">
        /// the function to call for each visited #GNode
        /// </param>
        /// <param name="data">
        /// user data to pass to the function
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_node_traverse( System.IntPtr root,  System.IntPtr order,  System.IntPtr flags,  System.Int32 maxDepth,  System.IntPtr func,  System.IntPtr data);

        /// <summary>
        /// Traverses a tree starting at the given root #GNode.
        /// It calls the given function for each node visited.
        /// The traversal can be halted at any point by returning %TRUE from @func.
        /// </summary>
        /// <param name="order">
        /// the order in which nodes are visited - %G_IN_ORDER,
        ///     %G_PRE_ORDER, %G_POST_ORDER, or %G_LEVEL_ORDER.
        /// </param>
        /// <param name="flags">
        /// which types of children are to be visited, one of
        ///     %G_TRAVERSE_ALL, %G_TRAVERSE_LEAVES and %G_TRAVERSE_NON_LEAVES
        /// </param>
        /// <param name="maxDepth">
        /// the maximum depth of the traversal. Nodes below this
        ///     depth will not be visited. If max_depth is -1 all nodes in
        ///     the tree are visited. If depth is 1, only the root is visited.
        ///     If depth is 2, the root and its children are visited. And so on.
        /// </param>
        /// <param name="func">
        /// the function to call for each visited #GNode
        /// </param>
        public System.Void Traverse( GISharp.GLib.TraverseType order,  GISharp.GLib.TraverseFlags flags,  System.Int32 maxDepth,  GISharp.GLib.NodeTraverseFunc func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_node_traverse(Handle, order, flags, maxDepth, func, data);
            return default(System.Void);
        }

        /// <summary>
        /// Unlinks a #GNode from a tree, resulting in two separate trees.
        /// </summary>
        /// <param name="node">
        /// the #GNode to unlink, which becomes the root of a new tree
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_node_unlink( System.IntPtr node);

        /// <summary>
        /// Unlinks a #GNode from a tree, resulting in two separate trees.
        /// </summary>
        public System.Void Unlink()
        {
            var ret = g_node_unlink(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Creates a new #GNode containing the given data.
        /// Used to create the first node in a tree.
        /// </summary>
        /// <param name="data">
        /// the data of the new node
        /// </param>
        /// <returns>
        /// a new #GNode
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_node_new( System.IntPtr data);

        /// <summary>
        /// Creates a new #GNode containing the given data.
        /// Used to create the first node in a tree.
        /// </summary>
        /// <param name="data">
        /// the data of the new node
        /// </param>
        /// <returns>
        /// a new #GNode
        /// </returns>
        public static GISharp.GLib.Node New( System.IntPtr data)
        {
            var ret = g_node_new(data);
            return default(GISharp.GLib.Node);
        }
    }

    /// <summary>
    /// Represents a file descriptor, which events to poll for, and which events
    /// occurred.
    /// </summary>
    public partial struct PollFD
    {
        /// <summary>
        /// the file descriptor to poll (or a HANDLE on Win32)
        /// </summary>
        public System.Int32 Fd;

        /// <summary>
        /// a bitwise combination from #GIOCondition, specifying which
        ///     events should be polled for. Typically for reading from a file
        ///     descriptor you would use %G_IO_IN | %G_IO_HUP | %G_IO_ERR, and
        ///     for writing you would use %G_IO_OUT | %G_IO_ERR.
        /// </summary>
        public System.UInt16 Events;

        /// <summary>
        /// a bitwise combination of flags from #GIOCondition, returned
        ///     from the poll() function to indicate which events occurred.
        /// </summary>
        public System.UInt16 Revents;
    }

    /// <summary>
    /// Contains the public fields of a
    /// [Queue][glib-Double-ended-Queues].
    /// </summary>
    public partial class Queue : GISharp.Core.OwnedOpaque<Queue>
    {
        public Queue(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GQueue.
        /// </summary>
        /// <returns>
        /// a newly allocated #GQueue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_new();

        /// <summary>
        /// Creates a new #GQueue.
        /// </summary>
        /// <returns>
        /// a newly allocated #GQueue
        /// </returns>
        public Queue() : base(IntPtr.Zero)
        {
            var ret = g_queue_new();
        }

        /// <summary>
        /// Removes all the elements in @queue. If queue elements contain
        /// dynamically-allocated memory, they should be freed first.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_clear( System.IntPtr queue);

        /// <summary>
        /// Removes all the elements in @queue. If queue elements contain
        /// dynamically-allocated memory, they should be freed first.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public System.Void Clear()
        {
            var ret = g_queue_clear(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Copies a @queue. Note that is a shallow copy. If the elements in the
        /// queue consist of pointers to data, the pointers are copied, but the
        /// actual data is not.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// a copy of @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_copy( System.IntPtr queue);

        /// <summary>
        /// Copies a @queue. Note that is a shallow copy. If the elements in the
        /// queue consist of pointers to data, the pointers are copied, but the
        /// actual data is not.
        /// </summary>
        /// <returns>
        /// a copy of @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public override GISharp.GLib.Queue Copy()
        {
            var ret = g_queue_copy(Handle);
            return default(GISharp.GLib.Queue);
        }

        /// <summary>
        /// Removes @link_ from @queue and frees it.
        /// </summary>
        /// <remarks>
        /// @link_ must be part of @queue.
        /// </remarks>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="link">
        /// a #GList link that must be part of @queue
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_delete_link( System.IntPtr queue,  System.IntPtr link);

        /// <summary>
        /// Removes @link_ from @queue and frees it.
        /// </summary>
        /// <remarks>
        /// @link_ must be part of @queue.
        /// </remarks>
        /// <param name="link">
        /// a #GList link that must be part of @queue
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void DeleteLink( GISharp.Core.List`1[System.IntPtr]link)
        {
            if (link == null)
            {
                throw new ArgumentNullException("link");
            }
            var ret = g_queue_delete_link(Handle, link);
            return default(System.Void);
        }

        /// <summary>
        /// Finds the first link in @queue which contains @data.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// data to find
        /// </param>
        /// <returns>
        /// the first link in @queue which contains @data
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_find( System.IntPtr queue,  System.IntPtr data);

        /// <summary>
        /// Finds the first link in @queue which contains @data.
        /// </summary>
        /// <param name="data">
        /// data to find
        /// </param>
        /// <returns>
        /// the first link in @queue which contains @data
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public GISharp.Core.List`1[System.IntPtr]Find( System.IntPtr data)
        {
            var ret = g_queue_find(Handle, data);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Finds an element in a #GQueue, using a supplied function to find the
        /// desired element. It iterates over the queue, calling the given function
        /// which should return 0 when the desired element is found. The function
        /// takes two gconstpointer arguments, the #GQueue element's data as the
        /// first argument and the given user data as the second argument.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// user data passed to @func
        /// </param>
        /// <param name="func">
        /// a #GCompareFunc to call for each element. It should return 0
        ///     when the desired element is found
        /// </param>
        /// <returns>
        /// the found link, or %NULL if it wasn't found
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_find_custom( System.IntPtr queue,  System.IntPtr data,  System.IntPtr func);

        /// <summary>
        /// Finds an element in a #GQueue, using a supplied function to find the
        /// desired element. It iterates over the queue, calling the given function
        /// which should return 0 when the desired element is found. The function
        /// takes two gconstpointer arguments, the #GQueue element's data as the
        /// first argument and the given user data as the second argument.
        /// </summary>
        /// <param name="data">
        /// user data passed to @func
        /// </param>
        /// <param name="func">
        /// a #GCompareFunc to call for each element. It should return 0
        ///     when the desired element is found
        /// </param>
        /// <returns>
        /// the found link, or %NULL if it wasn't found
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public GISharp.Core.List`1[System.IntPtr]FindCustom( System.IntPtr data,  GISharp.Core.CompareFunc`1[GISharp.GLib.Queue]func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_queue_find_custom(Handle, data, func);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Calls @func for each element in the queue passing @user_data to the
        /// function.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="func">
        /// the function to call for each element's data
        /// </param>
        /// <param name="userData">
        /// user data to pass to @func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_foreach( System.IntPtr queue,  System.IntPtr func,  System.IntPtr userData);

        /// <summary>
        /// Calls @func for each element in the queue passing @user_data to the
        /// function.
        /// </summary>
        /// <param name="func">
        /// the function to call for each element's data
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void Foreach( GISharp.Core.Func`1[GISharp.GLib.Queue]func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_queue_foreach(Handle, func, userData);
            return default(System.Void);
        }

        /// <summary>
        /// Frees the memory allocated for the #GQueue. Only call this function
        /// if @queue was created with g_queue_new(). If queue elements contain
        /// dynamically-allocated memory, they should be freed first.
        /// </summary>
        /// <remarks>
        /// If queue elements contain dynamically-allocated memory, you should
        /// either use g_queue_free_full() or free them manually first.
        /// </remarks>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_free( System.IntPtr queue);

        /// <summary>
        /// Frees the memory allocated for the #GQueue. Only call this function
        /// if @queue was created with g_queue_new(). If queue elements contain
        /// dynamically-allocated memory, they should be freed first.
        /// </summary>
        /// <remarks>
        /// If queue elements contain dynamically-allocated memory, you should
        /// either use g_queue_free_full() or free them manually first.
        /// </remarks>
        protected override System.Void Free()
        {
            var ret = g_queue_free(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Convenience method, which frees all the memory used by a #GQueue,
        /// and calls the specified destroy function on every element's data.
        /// </summary>
        /// <param name="queue">
        /// a pointer to a #GQueue
        /// </param>
        /// <param name="freeFunc">
        /// the function to be called to free each element's data
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_free_full( System.IntPtr queue,  System.IntPtr freeFunc);

        /// <summary>
        /// Convenience method, which frees all the memory used by a #GQueue,
        /// and calls the specified destroy function on every element's data.
        /// </summary>
        /// <param name="freeFunc">
        /// the function to be called to free each element's data
        /// </param>
        [GISharp.Core.Since("2.32")]
        public System.Void FreeFull( GISharp.Core.DestroyNotify`1[GISharp.GLib.Queue]freeFunc)
        {
            if (freeFunc == null)
            {
                throw new ArgumentNullException("freeFunc");
            }
            var ret = g_queue_free_full(Handle, freeFunc);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the number of items in @queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the number of items in @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_queue_get_length( System.IntPtr queue);

        /// <summary>
        /// Returns the number of items in @queue.
        /// </summary>
        /// <returns>
        /// the number of items in @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public System.UInt32 get_Length()
        {
            var ret = g_queue_get_length(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Returns the position of the first element in @queue which contains @data.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the position of the first element in @queue which
        ///     contains @data, or -1 if no element in @queue contains @data
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_queue_index( System.IntPtr queue,  System.IntPtr data);

        /// <summary>
        /// Returns the position of the first element in @queue which contains @data.
        /// </summary>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the position of the first element in @queue which
        ///     contains @data, or -1 if no element in @queue contains @data
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public System.Int32 Index( System.IntPtr data)
        {
            var ret = g_queue_index(Handle, data);
            return default(System.Int32);
        }

        /// <summary>
        /// A statically-allocated #GQueue must be initialized with this function
        /// before it can be used. Alternatively you can initialize it with
        /// #G_QUEUE_INIT. It is not necessary to initialize queues created with
        /// g_queue_new().
        /// </summary>
        /// <param name="queue">
        /// an uninitialized #GQueue
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_init( System.IntPtr queue);

        /// <summary>
        /// A statically-allocated #GQueue must be initialized with this function
        /// before it can be used. Alternatively you can initialize it with
        /// #G_QUEUE_INIT. It is not necessary to initialize queues created with
        /// g_queue_new().
        /// </summary>
        [GISharp.Core.Since("2.14")]
        public System.Void Init()
        {
            var ret = g_queue_init(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Inserts @data into @queue after @sibling
        /// </summary>
        /// <remarks>
        /// @sibling must be part of @queue
        /// </remarks>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="sibling">
        /// a #GList link that must be part of @queue
        /// </param>
        /// <param name="data">
        /// the data to insert
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_insert_after( System.IntPtr queue,  System.IntPtr sibling,  System.IntPtr data);

        /// <summary>
        /// Inserts @data into @queue after @sibling
        /// </summary>
        /// <remarks>
        /// @sibling must be part of @queue
        /// </remarks>
        /// <param name="sibling">
        /// a #GList link that must be part of @queue
        /// </param>
        /// <param name="data">
        /// the data to insert
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void InsertAfter( GISharp.Core.List`1[System.IntPtr]sibling,  System.IntPtr data)
        {
            if (sibling == null)
            {
                throw new ArgumentNullException("sibling");
            }
            var ret = g_queue_insert_after(Handle, sibling, data);
            return default(System.Void);
        }

        /// <summary>
        /// Inserts @data into @queue before @sibling.
        /// </summary>
        /// <remarks>
        /// @sibling must be part of @queue.
        /// </remarks>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="sibling">
        /// a #GList link that must be part of @queue
        /// </param>
        /// <param name="data">
        /// the data to insert
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_insert_before( System.IntPtr queue,  System.IntPtr sibling,  System.IntPtr data);

        /// <summary>
        /// Inserts @data into @queue before @sibling.
        /// </summary>
        /// <remarks>
        /// @sibling must be part of @queue.
        /// </remarks>
        /// <param name="sibling">
        /// a #GList link that must be part of @queue
        /// </param>
        /// <param name="data">
        /// the data to insert
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void InsertBefore( GISharp.Core.List`1[System.IntPtr]sibling,  System.IntPtr data)
        {
            if (sibling == null)
            {
                throw new ArgumentNullException("sibling");
            }
            var ret = g_queue_insert_before(Handle, sibling, data);
            return default(System.Void);
        }

        /// <summary>
        /// Inserts @data into @queue using @func to determine the new position.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// the data to insert
        /// </param>
        /// <param name="func">
        /// the #GCompareDataFunc used to compare elements in the queue. It is
        ///     called with two elements of the @queue and @user_data. It should
        ///     return 0 if the elements are equal, a negative value if the first
        ///     element comes before the second, and a positive value if the second
        ///     element comes before the first.
        /// </param>
        /// <param name="userData">
        /// user data passed to @func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_insert_sorted( System.IntPtr queue,  System.IntPtr data,  System.IntPtr func,  System.IntPtr userData);

        /// <summary>
        /// Inserts @data into @queue using @func to determine the new position.
        /// </summary>
        /// <param name="data">
        /// the data to insert
        /// </param>
        /// <param name="func">
        /// the #GCompareDataFunc used to compare elements in the queue. It is
        ///     called with two elements of the @queue and @user_data. It should
        ///     return 0 if the elements are equal, a negative value if the first
        ///     element comes before the second, and a positive value if the second
        ///     element comes before the first.
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void InsertSorted( System.IntPtr data,  GISharp.Core.CompareFunc`1[GISharp.GLib.Queue]func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_queue_insert_sorted(Handle, data, func, userData);
            return default(System.Void);
        }

        /// <summary>
        /// Returns %TRUE if the queue is empty.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue.
        /// </param>
        /// <returns>
        /// %TRUE if the queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_queue_is_empty( System.IntPtr queue);

        /// <summary>
        /// Returns %TRUE if the queue is empty.
        /// </summary>
        /// <returns>
        /// %TRUE if the queue is empty
        /// </returns>
        public System.Boolean get_IsEmpty()
        {
            var ret = g_queue_is_empty(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the position of @link_ in @queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="link">
        /// a #GList link
        /// </param>
        /// <returns>
        /// the position of @link_, or -1 if the link is
        ///     not part of @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_queue_link_index( System.IntPtr queue,  System.IntPtr link);

        /// <summary>
        /// Returns the position of @link_ in @queue.
        /// </summary>
        /// <param name="link">
        /// a #GList link
        /// </param>
        /// <returns>
        /// the position of @link_, or -1 if the link is
        ///     not part of @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public System.Int32 LinkIndex( GISharp.Core.List`1[System.IntPtr]link)
        {
            if (link == null)
            {
                throw new ArgumentNullException("link");
            }
            var ret = g_queue_link_index(Handle, link);
            return default(System.Int32);
        }

        /// <summary>
        /// Returns the first element of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the data of the first element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_peek_head( System.IntPtr queue);

        /// <summary>
        /// Returns the first element of the queue.
        /// </summary>
        /// <returns>
        /// the data of the first element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        public System.IntPtr PeekHead()
        {
            var ret = g_queue_peek_head(Handle);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Returns the first link in @queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the first link in @queue, or %NULL if @queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_peek_head_link( System.IntPtr queue);

        /// <summary>
        /// Returns the first link in @queue.
        /// </summary>
        /// <returns>
        /// the first link in @queue, or %NULL if @queue is empty
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public GISharp.Core.List`1[System.IntPtr]PeekHeadLink()
        {
            var ret = g_queue_peek_head_link(Handle);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Returns the @n'th element of @queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the data for the @n'th element of @queue,
        ///     or %NULL if @n is off the end of @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_peek_nth( System.IntPtr queue,  System.UInt32 n);

        /// <summary>
        /// Returns the @n'th element of @queue.
        /// </summary>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the data for the @n'th element of @queue,
        ///     or %NULL if @n is off the end of @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public System.IntPtr PeekNth( System.UInt32 n)
        {
            var ret = g_queue_peek_nth(Handle, n);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Returns the link at the given position
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="n">
        /// the position of the link
        /// </param>
        /// <returns>
        /// the link at the @n'th position, or %NULL
        ///     if @n is off the end of the list
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_peek_nth_link( System.IntPtr queue,  System.UInt32 n);

        /// <summary>
        /// Returns the link at the given position
        /// </summary>
        /// <param name="n">
        /// the position of the link
        /// </param>
        /// <returns>
        /// the link at the @n'th position, or %NULL
        ///     if @n is off the end of the list
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public GISharp.Core.List`1[System.IntPtr]PeekNthLink( System.UInt32 n)
        {
            var ret = g_queue_peek_nth_link(Handle, n);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Returns the last element of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the data of the last element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_peek_tail( System.IntPtr queue);

        /// <summary>
        /// Returns the last element of the queue.
        /// </summary>
        /// <returns>
        /// the data of the last element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        public System.IntPtr PeekTail()
        {
            var ret = g_queue_peek_tail(Handle);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Returns the last link in @queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the last link in @queue, or %NULL if @queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_peek_tail_link( System.IntPtr queue);

        /// <summary>
        /// Returns the last link in @queue.
        /// </summary>
        /// <returns>
        /// the last link in @queue, or %NULL if @queue is empty
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public GISharp.Core.List`1[System.IntPtr]PeekTailLink()
        {
            var ret = g_queue_peek_tail_link(Handle);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Removes the first element of the queue and returns its data.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the data of the first element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_pop_head( System.IntPtr queue);

        /// <summary>
        /// Removes the first element of the queue and returns its data.
        /// </summary>
        /// <returns>
        /// the data of the first element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        public System.IntPtr PopHead()
        {
            var ret = g_queue_pop_head(Handle);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Removes and returns the first element of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the #GList element at the head of the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_pop_head_link( System.IntPtr queue);

        /// <summary>
        /// Removes and returns the first element of the queue.
        /// </summary>
        /// <returns>
        /// the #GList element at the head of the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        public GISharp.Core.List`1[System.IntPtr]PopHeadLink()
        {
            var ret = g_queue_pop_head_link(Handle);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Removes the @n'th element of @queue and returns its data.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or %NULL if @n is off the end of @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_pop_nth( System.IntPtr queue,  System.UInt32 n);

        /// <summary>
        /// Removes the @n'th element of @queue and returns its data.
        /// </summary>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or %NULL if @n is off the end of @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public System.IntPtr PopNth( System.UInt32 n)
        {
            var ret = g_queue_pop_nth(Handle, n);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Removes and returns the link at the given position.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="n">
        /// the link's position
        /// </param>
        /// <returns>
        /// the @n'th link, or %NULL if @n is off the end of @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_pop_nth_link( System.IntPtr queue,  System.UInt32 n);

        /// <summary>
        /// Removes and returns the link at the given position.
        /// </summary>
        /// <param name="n">
        /// the link's position
        /// </param>
        /// <returns>
        /// the @n'th link, or %NULL if @n is off the end of @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public GISharp.Core.List`1[System.IntPtr]PopNthLink( System.UInt32 n)
        {
            var ret = g_queue_pop_nth_link(Handle, n);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Removes the last element of the queue and returns its data.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the data of the last element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_pop_tail( System.IntPtr queue);

        /// <summary>
        /// Removes the last element of the queue and returns its data.
        /// </summary>
        /// <returns>
        /// the data of the last element in the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        public System.IntPtr PopTail()
        {
            var ret = g_queue_pop_tail(Handle);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Removes and returns the last element of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <returns>
        /// the #GList element at the tail of the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_queue_pop_tail_link( System.IntPtr queue);

        /// <summary>
        /// Removes and returns the last element of the queue.
        /// </summary>
        /// <returns>
        /// the #GList element at the tail of the queue, or %NULL
        ///     if the queue is empty
        /// </returns>
        public GISharp.Core.List`1[System.IntPtr]PopTailLink()
        {
            var ret = g_queue_pop_tail_link(Handle);
            return default(GISharp.Core.List);
        }

        /// <summary>
        /// Adds a new element at the head of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue.
        /// </param>
        /// <param name="data">
        /// the data for the new element.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_push_head( System.IntPtr queue,  System.IntPtr data);

        /// <summary>
        /// Adds a new element at the head of the queue.
        /// </summary>
        /// <param name="data">
        /// the data for the new element.
        /// </param>
        public System.Void PushHead( System.IntPtr data)
        {
            var ret = g_queue_push_head(Handle, data);
            return default(System.Void);
        }

        /// <summary>
        /// Adds a new element at the head of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="link">
        /// a single #GList element, not a list with more than one element
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_push_head_link( System.IntPtr queue,  System.IntPtr link);

        /// <summary>
        /// Adds a new element at the head of the queue.
        /// </summary>
        /// <param name="link">
        /// a single #GList element, not a list with more than one element
        /// </param>
        public System.Void PushHeadLink( GISharp.Core.List`1[System.IntPtr]link)
        {
            if (link == null)
            {
                throw new ArgumentNullException("link");
            }
            var ret = g_queue_push_head_link(Handle, link);
            return default(System.Void);
        }

        /// <summary>
        /// Inserts a new element into @queue at the given position.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="n">
        /// the position to insert the new element. If @n is negative or
        ///     larger than the number of elements in the @queue, the element is
        ///     added to the end of the queue.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_push_nth( System.IntPtr queue,  System.IntPtr data,  System.Int32 n);

        /// <summary>
        /// Inserts a new element into @queue at the given position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="n">
        /// the position to insert the new element. If @n is negative or
        ///     larger than the number of elements in the @queue, the element is
        ///     added to the end of the queue.
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void PushNth( System.IntPtr data,  System.Int32 n)
        {
            var ret = g_queue_push_nth(Handle, data, n);
            return default(System.Void);
        }

        /// <summary>
        /// Inserts @link into @queue at the given position.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="n">
        /// the position to insert the link. If this is negative or larger than
        ///     the number of elements in @queue, the link is added to the end of
        ///     @queue.
        /// </param>
        /// <param name="link">
        /// the link to add to @queue
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_push_nth_link( System.IntPtr queue,  System.Int32 n,  System.IntPtr link);

        /// <summary>
        /// Inserts @link into @queue at the given position.
        /// </summary>
        /// <param name="n">
        /// the position to insert the link. If this is negative or larger than
        ///     the number of elements in @queue, the link is added to the end of
        ///     @queue.
        /// </param>
        /// <param name="link">
        /// the link to add to @queue
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void PushNthLink( System.Int32 n,  GISharp.Core.List`1[System.IntPtr]link)
        {
            if (link == null)
            {
                throw new ArgumentNullException("link");
            }
            var ret = g_queue_push_nth_link(Handle, n, link);
            return default(System.Void);
        }

        /// <summary>
        /// Adds a new element at the tail of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_push_tail( System.IntPtr queue,  System.IntPtr data);

        /// <summary>
        /// Adds a new element at the tail of the queue.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public System.Void PushTail( System.IntPtr data)
        {
            var ret = g_queue_push_tail(Handle, data);
            return default(System.Void);
        }

        /// <summary>
        /// Adds a new element at the tail of the queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="link">
        /// a single #GList element, not a list with more than one element
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_push_tail_link( System.IntPtr queue,  System.IntPtr link);

        /// <summary>
        /// Adds a new element at the tail of the queue.
        /// </summary>
        /// <param name="link">
        /// a single #GList element, not a list with more than one element
        /// </param>
        public System.Void PushTailLink( GISharp.Core.List`1[System.IntPtr]link)
        {
            if (link == null)
            {
                throw new ArgumentNullException("link");
            }
            var ret = g_queue_push_tail_link(Handle, link);
            return default(System.Void);
        }

        /// <summary>
        /// Removes the first element in @queue that contains @data.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// the data to remove
        /// </param>
        /// <returns>
        /// %TRUE if @data was found and removed from @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_queue_remove( System.IntPtr queue,  System.IntPtr data);

        /// <summary>
        /// Removes the first element in @queue that contains @data.
        /// </summary>
        /// <param name="data">
        /// the data to remove
        /// </param>
        /// <returns>
        /// %TRUE if @data was found and removed from @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public System.Boolean Remove( System.IntPtr data)
        {
            var ret = g_queue_remove(Handle, data);
            return default(System.Boolean);
        }

        /// <summary>
        /// Remove all elements whose data equals @data from @queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="data">
        /// the data to remove
        /// </param>
        /// <returns>
        /// the number of elements removed from @queue
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_queue_remove_all( System.IntPtr queue,  System.IntPtr data);

        /// <summary>
        /// Remove all elements whose data equals @data from @queue.
        /// </summary>
        /// <param name="data">
        /// the data to remove
        /// </param>
        /// <returns>
        /// the number of elements removed from @queue
        /// </returns>
        [GISharp.Core.Since("2.4")]
        public System.UInt32 RemoveAll( System.IntPtr data)
        {
            var ret = g_queue_remove_all(Handle, data);
            return default(System.UInt32);
        }

        /// <summary>
        /// Reverses the order of the items in @queue.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_reverse( System.IntPtr queue);

        /// <summary>
        /// Reverses the order of the items in @queue.
        /// </summary>
        [GISharp.Core.Since("2.4")]
        public System.Void Reverse()
        {
            var ret = g_queue_reverse(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Sorts @queue using @compare_func.
        /// </summary>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="compareFunc">
        /// the #GCompareDataFunc used to sort @queue. This function
        ///     is passed two elements of the queue and should return 0 if they are
        ///     equal, a negative value if the first comes before the second, and
        ///     a positive value if the second comes before the first.
        /// </param>
        /// <param name="userData">
        /// user data passed to @compare_func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_sort( System.IntPtr queue,  System.IntPtr compareFunc,  System.IntPtr userData);

        /// <summary>
        /// Sorts @queue using @compare_func.
        /// </summary>
        /// <param name="compareFunc">
        /// the #GCompareDataFunc used to sort @queue. This function
        ///     is passed two elements of the queue and should return 0 if they are
        ///     equal, a negative value if the first comes before the second, and
        ///     a positive value if the second comes before the first.
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void Sort( GISharp.Core.CompareFunc`1[GISharp.GLib.Queue]compareFunc)
        {
            if (compareFunc == null)
            {
                throw new ArgumentNullException("compareFunc");
            }
            var ret = g_queue_sort(Handle, compareFunc, userData);
            return default(System.Void);
        }

        /// <summary>
        /// Unlinks @link_ so that it will no longer be part of @queue.
        /// The link is not freed.
        /// </summary>
        /// <remarks>
        /// @link_ must be part of @queue.
        /// </remarks>
        /// <param name="queue">
        /// a #GQueue
        /// </param>
        /// <param name="link">
        /// a #GList link that must be part of @queue
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_queue_unlink( System.IntPtr queue,  System.IntPtr link);

        /// <summary>
        /// Unlinks @link_ so that it will no longer be part of @queue.
        /// The link is not freed.
        /// </summary>
        /// <remarks>
        /// @link_ must be part of @queue.
        /// </remarks>
        /// <param name="link">
        /// a #GList link that must be part of @queue
        /// </param>
        [GISharp.Core.Since("2.4")]
        public System.Void Unlink( GISharp.Core.List`1[System.IntPtr]link)
        {
            if (link == null)
            {
                throw new ArgumentNullException("link");
            }
            var ret = g_queue_unlink(Handle, link);
            return default(System.Void);
        }
    }

    /// <summary>
    /// The #GSequence struct is an opaque data type representing a
    /// [sequence][glib-Sequences] data type.
    /// </summary>
    public partial class Sequence : GISharp.Core.OwnedOpaque<Sequence>
    {
        public Sequence(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new GSequence. The @data_destroy function, if non-%NULL will
        /// be called on all items when the sequence is destroyed and on items that
        /// are removed from the sequence.
        /// </summary>
        /// <param name="dataDestroy">
        /// a #GDestroyNotify function, or %NULL
        /// </param>
        /// <returns>
        /// a new #GSequence
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_new( System.IntPtr dataDestroy);

        /// <summary>
        /// Creates a new GSequence. The @data_destroy function, if non-%NULL will
        /// be called on all items when the sequence is destroyed and on items that
        /// are removed from the sequence.
        /// </summary>
        /// <param name="dataDestroy">
        /// a #GDestroyNotify function, or %NULL
        /// </param>
        /// <returns>
        /// a new #GSequence
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public Sequence( GISharp.Core.DestroyNotify`1[GISharp.GLib.Sequence]dataDestroy) : base(IntPtr.Zero)
        {
            var ret = g_sequence_new(dataDestroy);
        }

        /// <summary>
        /// Adds a new item to the end of @seq.
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// the data for the new item
        /// </param>
        /// <returns>
        /// an iterator pointing to the new item
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_append( System.IntPtr seq,  System.IntPtr data);

        /// <summary>
        /// Adds a new item to the end of @seq.
        /// </summary>
        /// <param name="data">
        /// the data for the new item
        /// </param>
        /// <returns>
        /// an iterator pointing to the new item
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter Append( System.IntPtr data)
        {
            var ret = g_sequence_append(Handle, data);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Calls @func for each item in the sequence passing @user_data
        /// to the function.
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="func">
        /// the function to call for each item in @seq
        /// </param>
        /// <param name="userData">
        /// user data passed to @func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_foreach( System.IntPtr seq,  System.IntPtr func,  System.IntPtr userData);

        /// <summary>
        /// Calls @func for each item in the sequence passing @user_data
        /// to the function.
        /// </summary>
        /// <param name="func">
        /// the function to call for each item in @seq
        /// </param>
        [GISharp.Core.Since("2.14")]
        public System.Void Foreach( GISharp.Core.Func`1[GISharp.GLib.Sequence]func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_sequence_foreach(Handle, func, userData);
            return default(System.Void);
        }

        /// <summary>
        /// Frees the memory allocated for @seq. If @seq has a data destroy
        /// function associated with it, that function is called on all items
        /// in @seq.
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_free( System.IntPtr seq);

        /// <summary>
        /// Frees the memory allocated for @seq. If @seq has a data destroy
        /// function associated with it, that function is called on all items
        /// in @seq.
        /// </summary>
        [GISharp.Core.Since("2.14")]
        protected override System.Void Free()
        {
            var ret = g_sequence_free(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the begin iterator for @seq.
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <returns>
        /// the begin iterator for @seq.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_get_begin_iter( System.IntPtr seq);

        /// <summary>
        /// Returns the begin iterator for @seq.
        /// </summary>
        /// <returns>
        /// the begin iterator for @seq.
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter get_BeginIter()
        {
            var ret = g_sequence_get_begin_iter(Handle);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Returns the end iterator for @seg
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <returns>
        /// the end iterator for @seq
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_get_end_iter( System.IntPtr seq);

        /// <summary>
        /// Returns the end iterator for @seg
        /// </summary>
        /// <returns>
        /// the end iterator for @seq
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter get_EndIter()
        {
            var ret = g_sequence_get_end_iter(Handle);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Returns the iterator at position @pos. If @pos is negative or larger
        /// than the number of items in @seq, the end iterator is returned.
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="pos">
        /// a position in @seq, or -1 for the end
        /// </param>
        /// <returns>
        /// The #GSequenceIter at position @pos
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_get_iter_at_pos( System.IntPtr seq,  System.Int32 pos);

        /// <summary>
        /// Returns the iterator at position @pos. If @pos is negative or larger
        /// than the number of items in @seq, the end iterator is returned.
        /// </summary>
        /// <param name="pos">
        /// a position in @seq, or -1 for the end
        /// </param>
        /// <returns>
        /// The #GSequenceIter at position @pos
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter GetIterAtPos( System.Int32 pos)
        {
            var ret = g_sequence_get_iter_at_pos(Handle, pos);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Returns the length of @seq
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <returns>
        /// the length of @seq
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_sequence_get_length( System.IntPtr seq);

        /// <summary>
        /// Returns the length of @seq
        /// </summary>
        /// <returns>
        /// the length of @seq
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public System.Int32 get_Length()
        {
            var ret = g_sequence_get_length(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Inserts @data into @sequence using @func to determine the new
        /// position. The sequence must already be sorted according to @cmp_func;
        /// otherwise the new position of @data is undefined.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value
        /// if the first item comes before the second, and a positive value
        /// if the second  item comes before the first.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// the data to insert
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func.
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the new item.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_insert_sorted( System.IntPtr seq,  System.IntPtr data,  System.IntPtr cmpFunc,  System.IntPtr cmpData);

        /// <summary>
        /// Inserts @data into @sequence using @func to determine the new
        /// position. The sequence must already be sorted according to @cmp_func;
        /// otherwise the new position of @data is undefined.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value
        /// if the first item comes before the second, and a positive value
        /// if the second  item comes before the first.
        /// </remarks>
        /// <param name="data">
        /// the data to insert
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the new item.
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter InsertSorted( System.IntPtr data,  GISharp.Core.CompareFunc`1[GISharp.GLib.Sequence]cmpFunc)
        {
            if (cmpFunc == null)
            {
                throw new ArgumentNullException("cmpFunc");
            }
            var ret = g_sequence_insert_sorted(Handle, data, cmpFunc, cmpData);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Like g_sequence_insert_sorted(), but uses
        /// a #GSequenceIterCompareFunc instead of a #GCompareDataFunc as
        /// the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq.
        /// It should return 0 if the iterators are equal, a negative
        /// value if the first iterator comes before the second, and a
        /// positive value if the second iterator comes before the first.
        /// 
        /// It is called with two iterators pointing into @seq. It should
        /// return 0 if the iterators are equal, a negative value if the
        /// first iterator comes before the second, and a positive value
        /// if the second iterator comes before the first.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// data for the new item
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the new item
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_insert_sorted_iter( System.IntPtr seq,  System.IntPtr data,  System.IntPtr iterCmp,  System.IntPtr cmpData);

        /// <summary>
        /// Like g_sequence_insert_sorted(), but uses
        /// a #GSequenceIterCompareFunc instead of a #GCompareDataFunc as
        /// the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq.
        /// It should return 0 if the iterators are equal, a negative
        /// value if the first iterator comes before the second, and a
        /// positive value if the second iterator comes before the first.
        /// 
        /// It is called with two iterators pointing into @seq. It should
        /// return 0 if the iterators are equal, a negative value if the
        /// first iterator comes before the second, and a positive value
        /// if the second iterator comes before the first.
        /// </remarks>
        /// <param name="data">
        /// data for the new item
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the new item
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter InsertSortedIter( System.IntPtr data,  GISharp.GLib.SequenceIterCompareFunc iterCmp)
        {
            if (iterCmp == null)
            {
                throw new ArgumentNullException("iterCmp");
            }
            var ret = g_sequence_insert_sorted_iter(Handle, data, iterCmp, cmpData);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Returns an iterator pointing to the position of the first item found
        /// equal to @data according to @cmp_func and @cmp_data. If more than one
        /// item is equal, it is not guaranteed that it is the first which is
        /// returned. In that case, you can use g_sequence_iter_next() and
        /// g_sequence_iter_prev() to get others.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value if
        /// the first item comes before the second, and a positive value if
        /// the second item comes before the first.
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// data to lookup
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func
        /// </param>
        /// <returns>
        /// an #GSequenceIter pointing to the position of the
        ///     first item found equal to @data according to @cmp_func and
        ///     @cmp_data, or %NULL if no such item exists
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_lookup( System.IntPtr seq,  System.IntPtr data,  System.IntPtr cmpFunc,  System.IntPtr cmpData);

        /// <summary>
        /// Returns an iterator pointing to the position of the first item found
        /// equal to @data according to @cmp_func and @cmp_data. If more than one
        /// item is equal, it is not guaranteed that it is the first which is
        /// returned. In that case, you can use g_sequence_iter_next() and
        /// g_sequence_iter_prev() to get others.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value if
        /// the first item comes before the second, and a positive value if
        /// the second item comes before the first.
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="data">
        /// data to lookup
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        /// <returns>
        /// an #GSequenceIter pointing to the position of the
        ///     first item found equal to @data according to @cmp_func and
        ///     @cmp_data, or %NULL if no such item exists
        /// </returns>
        [GISharp.Core.Since("2.28")]
        public GISharp.GLib.SequenceIter Lookup( System.IntPtr data,  GISharp.Core.CompareFunc`1[GISharp.GLib.Sequence]cmpFunc)
        {
            if (cmpFunc == null)
            {
                throw new ArgumentNullException("cmpFunc");
            }
            var ret = g_sequence_lookup(Handle, data, cmpFunc, cmpData);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Like g_sequence_lookup(), but uses a #GSequenceIterCompareFunc
        /// instead of a #GCompareDataFunc as the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq.
        /// It should return 0 if the iterators are equal, a negative value
        /// if the first iterator comes before the second, and a positive
        /// value if the second iterator comes before the first.
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// data to lookup
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @iter_cmp
        /// </param>
        /// <returns>
        /// an #GSequenceIter pointing to the position of
        ///     the first item found equal to @data according to @cmp_func
        ///     and @cmp_data, or %NULL if no such item exists
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_lookup_iter( System.IntPtr seq,  System.IntPtr data,  System.IntPtr iterCmp,  System.IntPtr cmpData);

        /// <summary>
        /// Like g_sequence_lookup(), but uses a #GSequenceIterCompareFunc
        /// instead of a #GCompareDataFunc as the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq.
        /// It should return 0 if the iterators are equal, a negative value
        /// if the first iterator comes before the second, and a positive
        /// value if the second iterator comes before the first.
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="data">
        /// data to lookup
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <returns>
        /// an #GSequenceIter pointing to the position of
        ///     the first item found equal to @data according to @cmp_func
        ///     and @cmp_data, or %NULL if no such item exists
        /// </returns>
        [GISharp.Core.Since("2.28")]
        public GISharp.GLib.SequenceIter LookupIter( System.IntPtr data,  GISharp.GLib.SequenceIterCompareFunc iterCmp)
        {
            if (iterCmp == null)
            {
                throw new ArgumentNullException("iterCmp");
            }
            var ret = g_sequence_lookup_iter(Handle, data, iterCmp, cmpData);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Adds a new item to the front of @seq
        /// </summary>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// the data for the new item
        /// </param>
        /// <returns>
        /// an iterator pointing to the new item
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_prepend( System.IntPtr seq,  System.IntPtr data);

        /// <summary>
        /// Adds a new item to the front of @seq
        /// </summary>
        /// <param name="data">
        /// the data for the new item
        /// </param>
        /// <returns>
        /// an iterator pointing to the new item
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter Prepend( System.IntPtr data)
        {
            var ret = g_sequence_prepend(Handle, data);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Returns an iterator pointing to the position where @data would
        /// be inserted according to @cmp_func and @cmp_data.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value if
        /// the first item comes before the second, and a positive value if
        /// the second item comes before the first.
        /// 
        /// If you are simply searching for an existing element of the sequence,
        /// consider using g_sequence_lookup().
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// data for the new item
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func
        /// </param>
        /// <returns>
        /// an #GSequenceIter pointing to the position where @data
        ///     would have been inserted according to @cmp_func and @cmp_data
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_search( System.IntPtr seq,  System.IntPtr data,  System.IntPtr cmpFunc,  System.IntPtr cmpData);

        /// <summary>
        /// Returns an iterator pointing to the position where @data would
        /// be inserted according to @cmp_func and @cmp_data.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value if
        /// the first item comes before the second, and a positive value if
        /// the second item comes before the first.
        /// 
        /// If you are simply searching for an existing element of the sequence,
        /// consider using g_sequence_lookup().
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="data">
        /// data for the new item
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        /// <returns>
        /// an #GSequenceIter pointing to the position where @data
        ///     would have been inserted according to @cmp_func and @cmp_data
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter Search( System.IntPtr data,  GISharp.Core.CompareFunc`1[GISharp.GLib.Sequence]cmpFunc)
        {
            if (cmpFunc == null)
            {
                throw new ArgumentNullException("cmpFunc");
            }
            var ret = g_sequence_search(Handle, data, cmpFunc, cmpData);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Like g_sequence_search(), but uses a #GSequenceIterCompareFunc
        /// instead of a #GCompareDataFunc as the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq.
        /// It should return 0 if the iterators are equal, a negative value
        /// if the first iterator comes before the second, and a positive
        /// value if the second iterator comes before the first.
        /// 
        /// If you are simply searching for an existing element of the sequence,
        /// consider using g_sequence_lookup_iter().
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="data">
        /// data for the new item
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @iter_cmp
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the position in @seq
        ///     where @data would have been inserted according to @iter_cmp
        ///     and @cmp_data
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_search_iter( System.IntPtr seq,  System.IntPtr data,  System.IntPtr iterCmp,  System.IntPtr cmpData);

        /// <summary>
        /// Like g_sequence_search(), but uses a #GSequenceIterCompareFunc
        /// instead of a #GCompareDataFunc as the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq.
        /// It should return 0 if the iterators are equal, a negative value
        /// if the first iterator comes before the second, and a positive
        /// value if the second iterator comes before the first.
        /// 
        /// If you are simply searching for an existing element of the sequence,
        /// consider using g_sequence_lookup_iter().
        /// 
        /// This function will fail if the data contained in the sequence is
        /// unsorted.  Use g_sequence_insert_sorted() or
        /// g_sequence_insert_sorted_iter() to add data to your sequence or, if
        /// you want to add a large amount of data, call g_sequence_sort() after
        /// doing unsorted insertions.
        /// </remarks>
        /// <param name="data">
        /// data for the new item
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the position in @seq
        ///     where @data would have been inserted according to @iter_cmp
        ///     and @cmp_data
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter SearchIter( System.IntPtr data,  GISharp.GLib.SequenceIterCompareFunc iterCmp)
        {
            if (iterCmp == null)
            {
                throw new ArgumentNullException("iterCmp");
            }
            var ret = g_sequence_search_iter(Handle, data, iterCmp, cmpData);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Sorts @seq using @cmp_func.
        /// </summary>
        /// <remarks>
        /// @cmp_func is passed two items of @seq and should
        /// return 0 if they are equal, a negative value if the
        /// first comes before the second, and a positive value
        /// if the second comes before the first.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to sort the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_sort( System.IntPtr seq,  System.IntPtr cmpFunc,  System.IntPtr cmpData);

        /// <summary>
        /// Sorts @seq using @cmp_func.
        /// </summary>
        /// <remarks>
        /// @cmp_func is passed two items of @seq and should
        /// return 0 if they are equal, a negative value if the
        /// first comes before the second, and a positive value
        /// if the second comes before the first.
        /// </remarks>
        /// <param name="cmpFunc">
        /// the function used to sort the sequence
        /// </param>
        [GISharp.Core.Since("2.14")]
        public System.Void Sort( GISharp.Core.CompareFunc`1[GISharp.GLib.Sequence]cmpFunc)
        {
            if (cmpFunc == null)
            {
                throw new ArgumentNullException("cmpFunc");
            }
            var ret = g_sequence_sort(Handle, cmpFunc, cmpData);
            return default(System.Void);
        }

        /// <summary>
        /// Like g_sequence_sort(), but uses a #GSequenceIterCompareFunc instead
        /// of a GCompareDataFunc as the compare function
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two iterators pointing into @seq. It should
        /// return 0 if the iterators are equal, a negative value if the first
        /// iterator comes before the second, and a positive value if the second
        /// iterator comes before the first.
        /// </remarks>
        /// <param name="seq">
        /// a #GSequence
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_sort_iter( System.IntPtr seq,  System.IntPtr cmpFunc,  System.IntPtr cmpData);

        /// <summary>
        /// Like g_sequence_sort(), but uses a #GSequenceIterCompareFunc instead
        /// of a GCompareDataFunc as the compare function
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two iterators pointing into @seq. It should
        /// return 0 if the iterators are equal, a negative value if the first
        /// iterator comes before the second, and a positive value if the second
        /// iterator comes before the first.
        /// </remarks>
        /// <param name="cmpFunc">
        /// the function used to compare iterators in the sequence
        /// </param>
        [GISharp.Core.Since("2.14")]
        public System.Void SortIter( GISharp.GLib.SequenceIterCompareFunc cmpFunc)
        {
            if (cmpFunc == null)
            {
                throw new ArgumentNullException("cmpFunc");
            }
            var ret = g_sequence_sort_iter(Handle, cmpFunc, cmpData);
            return default(System.Void);
        }

        /// <summary>
        /// Calls @func for each item in the range (@begin, @end) passing
        /// @user_data to the function.
        /// </summary>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        /// <param name="func">
        /// a #GFunc
        /// </param>
        /// <param name="userData">
        /// user data passed to @func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_foreach_range( System.IntPtr begin,  System.IntPtr end,  System.IntPtr func,  System.IntPtr userData);

        /// <summary>
        /// Calls @func for each item in the range (@begin, @end) passing
        /// @user_data to the function.
        /// </summary>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        /// <param name="func">
        /// a #GFunc
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void ForeachRange( GISharp.GLib.SequenceIter begin,  GISharp.GLib.SequenceIter end,  GISharp.Core.Func`1[GISharp.GLib.Sequence]func)
        {
            if (begin == null)
            {
                throw new ArgumentNullException("begin");
            }
            if (end == null)
            {
                throw new ArgumentNullException("end");
            }
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_sequence_foreach_range(begin, end, func, userData);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the data that @iter points to.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// the data that @iter points to
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_get( System.IntPtr iter);

        /// <summary>
        /// Returns the data that @iter points to.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// the data that @iter points to
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public static System.IntPtr Get( GISharp.GLib.SequenceIter iter)
        {
            if (iter == null)
            {
                throw new ArgumentNullException("iter");
            }
            var ret = g_sequence_get(iter);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Inserts a new item just before the item pointed to by @iter.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <param name="data">
        /// the data for the new item
        /// </param>
        /// <returns>
        /// an iterator pointing to the new item
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_insert_before( System.IntPtr iter,  System.IntPtr data);

        /// <summary>
        /// Inserts a new item just before the item pointed to by @iter.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <param name="data">
        /// the data for the new item
        /// </param>
        /// <returns>
        /// an iterator pointing to the new item
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public static GISharp.GLib.SequenceIter InsertBefore( GISharp.GLib.SequenceIter iter,  System.IntPtr data)
        {
            if (iter == null)
            {
                throw new ArgumentNullException("iter");
            }
            var ret = g_sequence_insert_before(iter, data);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Moves the item pointed to by @src to the position indicated by @dest.
        /// After calling this function @dest will point to the position immediately
        /// after @src. It is allowed for @src and @dest to point into different
        /// sequences.
        /// </summary>
        /// <param name="src">
        /// a #GSequenceIter pointing to the item to move
        /// </param>
        /// <param name="dest">
        /// a #GSequenceIter pointing to the position to which
        ///     the item is moved
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_move( System.IntPtr src,  System.IntPtr dest);

        /// <summary>
        /// Moves the item pointed to by @src to the position indicated by @dest.
        /// After calling this function @dest will point to the position immediately
        /// after @src. It is allowed for @src and @dest to point into different
        /// sequences.
        /// </summary>
        /// <param name="src">
        /// a #GSequenceIter pointing to the item to move
        /// </param>
        /// <param name="dest">
        /// a #GSequenceIter pointing to the position to which
        ///     the item is moved
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void Move( GISharp.GLib.SequenceIter src,  GISharp.GLib.SequenceIter dest)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dest == null)
            {
                throw new ArgumentNullException("dest");
            }
            var ret = g_sequence_move(src, dest);
            return default(System.Void);
        }

        /// <summary>
        /// Inserts the (@begin, @end) range at the destination pointed to by ptr.
        /// The @begin and @end iters must point into the same sequence. It is
        /// allowed for @dest to point to a different sequence than the one pointed
        /// into by @begin and @end.
        /// </summary>
        /// <remarks>
        /// If @dest is NULL, the range indicated by @begin and @end is
        /// removed from the sequence. If @dest iter points to a place within
        /// the (@begin, @end) range, the range does not move.
        /// </remarks>
        /// <param name="dest">
        /// a #GSequenceIter
        /// </param>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_move_range( System.IntPtr dest,  System.IntPtr begin,  System.IntPtr end);

        /// <summary>
        /// Inserts the (@begin, @end) range at the destination pointed to by ptr.
        /// The @begin and @end iters must point into the same sequence. It is
        /// allowed for @dest to point to a different sequence than the one pointed
        /// into by @begin and @end.
        /// </summary>
        /// <remarks>
        /// If @dest is NULL, the range indicated by @begin and @end is
        /// removed from the sequence. If @dest iter points to a place within
        /// the (@begin, @end) range, the range does not move.
        /// </remarks>
        /// <param name="dest">
        /// a #GSequenceIter
        /// </param>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void MoveRange( GISharp.GLib.SequenceIter dest,  GISharp.GLib.SequenceIter begin,  GISharp.GLib.SequenceIter end)
        {
            if (dest == null)
            {
                throw new ArgumentNullException("dest");
            }
            if (begin == null)
            {
                throw new ArgumentNullException("begin");
            }
            if (end == null)
            {
                throw new ArgumentNullException("end");
            }
            var ret = g_sequence_move_range(dest, begin, end);
            return default(System.Void);
        }

        /// <summary>
        /// Finds an iterator somewhere in the range (@begin, @end). This
        /// iterator will be close to the middle of the range, but is not
        /// guaranteed to be exactly in the middle.
        /// </summary>
        /// <remarks>
        /// The @begin and @end iterators must both point to the same sequence
        /// and @begin must come before or be equal to @end in the sequence.
        /// </remarks>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing somewhere in the
        ///    (@begin, @end) range
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_range_get_midpoint( System.IntPtr begin,  System.IntPtr end);

        /// <summary>
        /// Finds an iterator somewhere in the range (@begin, @end). This
        /// iterator will be close to the middle of the range, but is not
        /// guaranteed to be exactly in the middle.
        /// </summary>
        /// <remarks>
        /// The @begin and @end iterators must both point to the same sequence
        /// and @begin must come before or be equal to @end in the sequence.
        /// </remarks>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing somewhere in the
        ///    (@begin, @end) range
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public static GISharp.GLib.SequenceIter RangeGetMidpoint( GISharp.GLib.SequenceIter begin,  GISharp.GLib.SequenceIter end)
        {
            if (begin == null)
            {
                throw new ArgumentNullException("begin");
            }
            if (end == null)
            {
                throw new ArgumentNullException("end");
            }
            var ret = g_sequence_range_get_midpoint(begin, end);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Removes the item pointed to by @iter. It is an error to pass the
        /// end iterator to this function.
        /// </summary>
        /// <remarks>
        /// If the sequence has a data destroy function associated with it, this
        /// function is called on the data for the removed item.
        /// </remarks>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_remove( System.IntPtr iter);

        /// <summary>
        /// Removes the item pointed to by @iter. It is an error to pass the
        /// end iterator to this function.
        /// </summary>
        /// <remarks>
        /// If the sequence has a data destroy function associated with it, this
        /// function is called on the data for the removed item.
        /// </remarks>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void Remove( GISharp.GLib.SequenceIter iter)
        {
            if (iter == null)
            {
                throw new ArgumentNullException("iter");
            }
            var ret = g_sequence_remove(iter);
            return default(System.Void);
        }

        /// <summary>
        /// Removes all items in the (@begin, @end) range.
        /// </summary>
        /// <remarks>
        /// If the sequence has a data destroy function associated with it, this
        /// function is called on the data for the removed items.
        /// </remarks>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_remove_range( System.IntPtr begin,  System.IntPtr end);

        /// <summary>
        /// Removes all items in the (@begin, @end) range.
        /// </summary>
        /// <remarks>
        /// If the sequence has a data destroy function associated with it, this
        /// function is called on the data for the removed items.
        /// </remarks>
        /// <param name="begin">
        /// a #GSequenceIter
        /// </param>
        /// <param name="end">
        /// a #GSequenceIter
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void RemoveRange( GISharp.GLib.SequenceIter begin,  GISharp.GLib.SequenceIter end)
        {
            if (begin == null)
            {
                throw new ArgumentNullException("begin");
            }
            if (end == null)
            {
                throw new ArgumentNullException("end");
            }
            var ret = g_sequence_remove_range(begin, end);
            return default(System.Void);
        }

        /// <summary>
        /// Changes the data for the item pointed to by @iter to be @data. If
        /// the sequence has a data destroy function associated with it, that
        /// function is called on the existing data that @iter pointed to.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <param name="data">
        /// new data for the item
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_set( System.IntPtr iter,  System.IntPtr data);

        /// <summary>
        /// Changes the data for the item pointed to by @iter to be @data. If
        /// the sequence has a data destroy function associated with it, that
        /// function is called on the existing data that @iter pointed to.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <param name="data">
        /// new data for the item
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void Set( GISharp.GLib.SequenceIter iter,  System.IntPtr data)
        {
            if (iter == null)
            {
                throw new ArgumentNullException("iter");
            }
            var ret = g_sequence_set(iter, data);
            return default(System.Void);
        }

        /// <summary>
        /// Moves the data pointed to a new position as indicated by @cmp_func. This
        /// function should be called for items in a sequence already sorted according
        /// to @cmp_func whenever some aspect of an item changes so that @cmp_func
        /// may return different values for that item.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value if
        /// the first item comes before the second, and a positive value if
        /// the second item comes before the first.
        /// </remarks>
        /// <param name="iter">
        /// A #GSequenceIter
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_sort_changed( System.IntPtr iter,  System.IntPtr cmpFunc,  System.IntPtr cmpData);

        /// <summary>
        /// Moves the data pointed to a new position as indicated by @cmp_func. This
        /// function should be called for items in a sequence already sorted according
        /// to @cmp_func whenever some aspect of an item changes so that @cmp_func
        /// may return different values for that item.
        /// </summary>
        /// <remarks>
        /// @cmp_func is called with two items of the @seq and @user_data.
        /// It should return 0 if the items are equal, a negative value if
        /// the first item comes before the second, and a positive value if
        /// the second item comes before the first.
        /// </remarks>
        /// <param name="iter">
        /// A #GSequenceIter
        /// </param>
        /// <param name="cmpFunc">
        /// the function used to compare items in the sequence
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void SortChanged( GISharp.GLib.SequenceIter iter,  GISharp.Core.CompareFunc`1[GISharp.GLib.Sequence]cmpFunc)
        {
            if (iter == null)
            {
                throw new ArgumentNullException("iter");
            }
            if (cmpFunc == null)
            {
                throw new ArgumentNullException("cmpFunc");
            }
            var ret = g_sequence_sort_changed(iter, cmpFunc, cmpData);
            return default(System.Void);
        }

        /// <summary>
        /// Like g_sequence_sort_changed(), but uses
        /// a #GSequenceIterCompareFunc instead of a #GCompareDataFunc as
        /// the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq. It should
        /// return 0 if the iterators are equal, a negative value if the first
        /// iterator comes before the second, and a positive value if the second
        /// iterator comes before the first.
        /// </remarks>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        /// <param name="cmpData">
        /// user data passed to @cmp_func
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_sort_changed_iter( System.IntPtr iter,  System.IntPtr iterCmp,  System.IntPtr cmpData);

        /// <summary>
        /// Like g_sequence_sort_changed(), but uses
        /// a #GSequenceIterCompareFunc instead of a #GCompareDataFunc as
        /// the compare function.
        /// </summary>
        /// <remarks>
        /// @iter_cmp is called with two iterators pointing into @seq. It should
        /// return 0 if the iterators are equal, a negative value if the first
        /// iterator comes before the second, and a positive value if the second
        /// iterator comes before the first.
        /// </remarks>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <param name="iterCmp">
        /// the function used to compare iterators in the sequence
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void SortChangedIter( GISharp.GLib.SequenceIter iter,  GISharp.GLib.SequenceIterCompareFunc iterCmp)
        {
            if (iter == null)
            {
                throw new ArgumentNullException("iter");
            }
            if (iterCmp == null)
            {
                throw new ArgumentNullException("iterCmp");
            }
            var ret = g_sequence_sort_changed_iter(iter, iterCmp, cmpData);
            return default(System.Void);
        }

        /// <summary>
        /// Swaps the items pointed to by @a and @b. It is allowed for @a and @b
        /// to point into difference sequences.
        /// </summary>
        /// <param name="a">
        /// a #GSequenceIter
        /// </param>
        /// <param name="b">
        /// a #GSequenceIter
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_sequence_swap( System.IntPtr a,  System.IntPtr b);

        /// <summary>
        /// Swaps the items pointed to by @a and @b. It is allowed for @a and @b
        /// to point into difference sequences.
        /// </summary>
        /// <param name="a">
        /// a #GSequenceIter
        /// </param>
        /// <param name="b">
        /// a #GSequenceIter
        /// </param>
        [GISharp.Core.Since("2.14")]
        public static System.Void Swap( GISharp.GLib.SequenceIter a,  GISharp.GLib.SequenceIter b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
            var ret = g_sequence_swap(a, b);
            return default(System.Void);
        }
    }

    /// <summary>
    /// The #GSequenceIter struct is an opaque data type representing an
    /// iterator pointing into a #GSequence.
    /// </summary>
    public partial class SequenceIter : GISharp.Core.OwnedOpaque<SequenceIter>, IComparable<SequenceIter>
    {
        public SequenceIter(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Returns a negative number if @a comes before @b, 0 if they are equal,
        /// and a positive number if @a comes after @b.
        /// </summary>
        /// <remarks>
        /// The @a and @b iterators must point into the same sequence.
        /// </remarks>
        /// <param name="a">
        /// a #GSequenceIter
        /// </param>
        /// <param name="b">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// a negative number if @a comes before @b, 0 if they are
        ///     equal, and a positive number if @a comes after @b
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_sequence_iter_compare( System.IntPtr a,  System.IntPtr b);

        /// <summary>
        /// Returns a negative number if @a comes before @b, 0 if they are equal,
        /// and a positive number if @a comes after @b.
        /// </summary>
        /// <remarks>
        /// The @a and @b iterators must point into the same sequence.
        /// </remarks>
        /// <param name="b">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// a negative number if @a comes before @b, 0 if they are
        ///     equal, and a positive number if @a comes after @b
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public System.Int32 CompareTo( GISharp.GLib.SequenceIter b)
        {
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
            var ret = g_sequence_iter_compare(Handle, b);
            return default(System.Int32);
        }

        public static bool operator <(SequenceIter one, SequenceIter two)
        {
            return one.CompareTo(two) < 0;
        }

        public static bool operator <=(SequenceIter one, SequenceIter two)
        {
            return one.CompareTo(two) <= 0;
        }

        public static bool operator >=(SequenceIter one, SequenceIter two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator >(SequenceIter one, SequenceIter two)
        {
            return one.CompareTo(two) > 0;
        }

        /// <summary>
        /// Returns the position of @iter
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// the position of @iter
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_sequence_iter_get_position( System.IntPtr iter);

        /// <summary>
        /// Returns the position of @iter
        /// </summary>
        /// <returns>
        /// the position of @iter
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public System.Int32 get_Position()
        {
            var ret = g_sequence_iter_get_position(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Returns the #GSequence that @iter points into.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// the #GSequence that @iter points into
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_iter_get_sequence( System.IntPtr iter);

        /// <summary>
        /// Returns the #GSequence that @iter points into.
        /// </summary>
        /// <returns>
        /// the #GSequence that @iter points into
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.Sequence get_Sequence()
        {
            var ret = g_sequence_iter_get_sequence(Handle);
            return default(GISharp.GLib.Sequence);
        }

        /// <summary>
        /// Returns whether @iter is the begin iterator
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// whether @iter is the begin iterator
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_sequence_iter_is_begin( System.IntPtr iter);

        /// <summary>
        /// Returns whether @iter is the begin iterator
        /// </summary>
        /// <returns>
        /// whether @iter is the begin iterator
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public System.Boolean get_IsBegin()
        {
            var ret = g_sequence_iter_is_begin(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns whether @iter is the end iterator
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// Whether @iter is the end iterator
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_sequence_iter_is_end( System.IntPtr iter);

        /// <summary>
        /// Returns whether @iter is the end iterator
        /// </summary>
        /// <returns>
        /// Whether @iter is the end iterator
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public System.Boolean get_IsEnd()
        {
            var ret = g_sequence_iter_is_end(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the #GSequenceIter which is @delta positions away from @iter.
        /// If @iter is closer than -@delta positions to the beginning of the sequence,
        /// the begin iterator is returned. If @iter is closer than @delta positions
        /// to the end of the sequence, the end iterator is returned.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <param name="delta">
        /// A positive or negative number indicating how many positions away
        ///    from @iter the returned #GSequenceIter will be
        /// </param>
        /// <returns>
        /// a #GSequenceIter which is @delta positions away from @iter
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_iter_move( System.IntPtr iter,  System.Int32 delta);

        /// <summary>
        /// Returns the #GSequenceIter which is @delta positions away from @iter.
        /// If @iter is closer than -@delta positions to the beginning of the sequence,
        /// the begin iterator is returned. If @iter is closer than @delta positions
        /// to the end of the sequence, the end iterator is returned.
        /// </summary>
        /// <param name="delta">
        /// A positive or negative number indicating how many positions away
        ///    from @iter the returned #GSequenceIter will be
        /// </param>
        /// <returns>
        /// a #GSequenceIter which is @delta positions away from @iter
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter Move( System.Int32 delta)
        {
            var ret = g_sequence_iter_move(Handle, delta);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Returns an iterator pointing to the next position after @iter.
        /// If @iter is the end iterator, the end iterator is returned.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the next position after @iter
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_iter_next( System.IntPtr iter);

        /// <summary>
        /// Returns an iterator pointing to the next position after @iter.
        /// If @iter is the end iterator, the end iterator is returned.
        /// </summary>
        /// <returns>
        /// a #GSequenceIter pointing to the next position after @iter
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter Next()
        {
            var ret = g_sequence_iter_next(Handle);
            return default(GISharp.GLib.SequenceIter);
        }

        /// <summary>
        /// Returns an iterator pointing to the previous position before @iter.
        /// If @iter is the begin iterator, the begin iterator is returned.
        /// </summary>
        /// <param name="iter">
        /// a #GSequenceIter
        /// </param>
        /// <returns>
        /// a #GSequenceIter pointing to the previous position
        ///     before @iter
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_sequence_iter_prev( System.IntPtr iter);

        /// <summary>
        /// Returns an iterator pointing to the previous position before @iter.
        /// If @iter is the begin iterator, the begin iterator is returned.
        /// </summary>
        /// <returns>
        /// a #GSequenceIter pointing to the previous position
        ///     before @iter
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public GISharp.GLib.SequenceIter Prev()
        {
            var ret = g_sequence_iter_prev(Handle);
            return default(GISharp.GLib.SequenceIter);
        }
    }

    /// <summary>
    /// The `GSource` struct is an opaque data type
    /// representing an event source.
    /// </summary>
    public partial class Source : GISharp.Core.ReferenceCountedOpaque<Source>
    {
        /// <summary>
        /// Use this macro as the return value of a #GSourceFunc to leave
        /// the #GSource in the main loop.
        /// </summary>
        [GISharp.Core.Since("2.32")]
        public const System.Boolean Continue = true;

        /// <summary>
        /// Use this macro as the return value of a #GSourceFunc to remove
        /// the #GSource from the main loop.
        /// </summary>
        [GISharp.Core.Since("2.32")]
        public const System.Boolean Remove = false;

        public Source(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GSource structure. The size is specified to
        /// allow creating structures derived from #GSource that contain
        /// additional data. The size passed in must be at least
        /// `sizeof (GSource)`.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="sourceFuncs">
        /// structure containing functions that implement
        ///                the sources behavior.
        /// </param>
        /// <param name="structSize">
        /// size of the #GSource structure to create.
        /// </param>
        /// <returns>
        /// the newly-created #GSource.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_new( System.IntPtr sourceFuncs,  System.UInt32 structSize);

        /// <summary>
        /// Creates a new #GSource structure. The size is specified to
        /// allow creating structures derived from #GSource that contain
        /// additional data. The size passed in must be at least
        /// `sizeof (GSource)`.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="sourceFuncs">
        /// structure containing functions that implement
        ///                the sources behavior.
        /// </param>
        /// <param name="structSize">
        /// size of the #GSource structure to create.
        /// </param>
        /// <returns>
        /// the newly-created #GSource.
        /// </returns>
        public Source( GISharp.GLib.SourceFuncs sourceFuncs,  System.UInt32 structSize) : base(IntPtr.Zero)
        {
            var ret = g_source_new(sourceFuncs, structSize);
        }

        /// <summary>
        /// Adds @child_source to @source as a "polled" source; when @source is
        /// added to a #GMainContext, @child_source will be automatically added
        /// with the same priority, when @child_source is triggered, it will
        /// cause @source to dispatch (in addition to calling its own
        /// callback), and when @source is destroyed, it will destroy
        /// @child_source as well. (@source will also still be dispatched if
        /// its own prepare/check functions indicate that it is ready.)
        /// </summary>
        /// <remarks>
        /// If you don't need @child_source to do anything on its own when it
        /// triggers, you can call g_source_set_dummy_callback() on it to set a
        /// callback that does nothing (except return %TRUE if appropriate).
        /// 
        /// @source will hold a reference on @child_source while @child_source
        /// is attached to it.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="childSource">
        /// a second #GSource that @source should "poll"
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_add_child_source( System.IntPtr source,  System.IntPtr childSource);

        /// <summary>
        /// Adds @child_source to @source as a "polled" source; when @source is
        /// added to a #GMainContext, @child_source will be automatically added
        /// with the same priority, when @child_source is triggered, it will
        /// cause @source to dispatch (in addition to calling its own
        /// callback), and when @source is destroyed, it will destroy
        /// @child_source as well. (@source will also still be dispatched if
        /// its own prepare/check functions indicate that it is ready.)
        /// </summary>
        /// <remarks>
        /// If you don't need @child_source to do anything on its own when it
        /// triggers, you can call g_source_set_dummy_callback() on it to set a
        /// callback that does nothing (except return %TRUE if appropriate).
        /// 
        /// @source will hold a reference on @child_source while @child_source
        /// is attached to it.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="childSource">
        /// a second #GSource that @source should "poll"
        /// </param>
        [GISharp.Core.Since("2.28")]
        public System.Void AddChildSource( GISharp.GLib.Source childSource)
        {
            if (childSource == null)
            {
                throw new ArgumentNullException("childSource");
            }
            var ret = g_source_add_child_source(Handle, childSource);
            return default(System.Void);
        }

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this source. This is usually combined with g_source_new() to add an
        /// event source. The event source's check function will typically test
        /// the @revents field in the #GPollFD struct and return %TRUE if events need
        /// to be processed.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// Using this API forces the linear scanning of event sources on each
        /// main loop iteration.  Newly-written event sources should try to use
        /// g_source_add_unix_fd() instead of this API.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_add_poll( System.IntPtr source,  System.IntPtr fd);

        /// <summary>
        /// Adds a file descriptor to the set of file descriptors polled for
        /// this source. This is usually combined with g_source_new() to add an
        /// event source. The event source's check function will typically test
        /// the @revents field in the #GPollFD struct and return %TRUE if events need
        /// to be processed.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// Using this API forces the linear scanning of event sources on each
        /// main loop iteration.  Newly-written event sources should try to use
        /// g_source_add_unix_fd() instead of this API.
        /// </remarks>
        /// <param name="fd">
        /// a #GPollFD structure holding information about a file
        ///      descriptor to watch.
        /// </param>
        public System.Void AddPoll( GISharp.GLib.PollFD fd)
        {
            var ret = g_source_add_poll(Handle, fd);
            return default(System.Void);
        }

        /// <summary>
        /// Adds a #GSource to a @context so that it will be executed within
        /// that context. Remove it by calling g_source_destroy().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source within the
        ///   #GMainContext.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_source_attach( System.IntPtr source,  System.IntPtr context);

        /// <summary>
        /// Adds a #GSource to a @context so that it will be executed within
        /// that context. Remove it by calling g_source_destroy().
        /// </summary>
        /// <param name="context">
        /// a #GMainContext (if %NULL, the default context will be used)
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source within the
        ///   #GMainContext.
        /// </returns>
        public System.UInt32 Attach( GISharp.GLib.MainContext context)
        {
            var ret = g_source_attach(Handle, context);
            return default(System.UInt32);
        }

        /// <summary>
        /// Removes a source from its #GMainContext, if any, and mark it as
        /// destroyed.  The source cannot be subsequently added to another
        /// context. It is safe to call this on sources which have already been
        /// removed from their context.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_destroy( System.IntPtr source);

        /// <summary>
        /// Removes a source from its #GMainContext, if any, and mark it as
        /// destroyed.  The source cannot be subsequently added to another
        /// context. It is safe to call this on sources which have already been
        /// removed from their context.
        /// </summary>
        public System.Void Destroy()
        {
            var ret = g_source_destroy(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Checks whether a source is allowed to be called recursively.
        /// see g_source_set_can_recurse().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// whether recursion is allowed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_source_get_can_recurse( System.IntPtr source);

        /// <summary>
        /// Checks whether a source is allowed to be called recursively.
        /// see g_source_set_can_recurse().
        /// </summary>
        /// <returns>
        /// whether recursion is allowed.
        /// </returns>
        public System.Boolean get_CanRecurse()
        {
            var ret = g_source_get_can_recurse(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Gets the #GMainContext with which the source is associated.
        /// </summary>
        /// <remarks>
        /// You can call this on a source that has been destroyed, provided
        /// that the #GMainContext it was attached to still exists (in which
        /// case it will return that #GMainContext). In particular, you can
        /// always call this function on the source returned from
        /// g_main_current_source(). But calling this function on a source
        /// whose #GMainContext has been destroyed is an error.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the #GMainContext with which the
        ///               source is associated, or %NULL if the context has not
        ///               yet been added to a source.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_get_context( System.IntPtr source);

        /// <summary>
        /// Gets the #GMainContext with which the source is associated.
        /// </summary>
        /// <remarks>
        /// You can call this on a source that has been destroyed, provided
        /// that the #GMainContext it was attached to still exists (in which
        /// case it will return that #GMainContext). In particular, you can
        /// always call this function on the source returned from
        /// g_main_current_source(). But calling this function on a source
        /// whose #GMainContext has been destroyed is an error.
        /// </remarks>
        /// <returns>
        /// the #GMainContext with which the
        ///               source is associated, or %NULL if the context has not
        ///               yet been added to a source.
        /// </returns>
        public GISharp.GLib.MainContext get_Context()
        {
            var ret = g_source_get_context(Handle);
            return default(GISharp.GLib.MainContext);
        }

        /// <summary>
        /// This function ignores @source and is otherwise the same as
        /// g_get_current_time().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="timeval">
        /// #GTimeVal structure in which to store current time.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_get_current_time( System.IntPtr source,  System.IntPtr timeval);

        /// <summary>
        /// This function ignores @source and is otherwise the same as
        /// g_get_current_time().
        /// </summary>
        /// <param name="timeval">
        /// #GTimeVal structure in which to store current time.
        /// </param>
        [Obsolete("use g_source_get_time() instead")]
        public System.Void GetCurrentTime( GISharp.GLib.TimeVal timeval)
        {
            var ret = g_source_get_current_time(Handle, timeval);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the numeric ID for a particular source. The ID of a source
        /// is a positive integer which is unique within a particular main loop
        /// context. The reverse
        /// mapping from ID to source is done by g_main_context_find_source_by_id().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the ID (greater than 0) for the source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_source_get_id( System.IntPtr source);

        /// <summary>
        /// Returns the numeric ID for a particular source. The ID of a source
        /// is a positive integer which is unique within a particular main loop
        /// context. The reverse
        /// mapping from ID to source is done by g_main_context_find_source_by_id().
        /// </summary>
        /// <returns>
        /// the ID (greater than 0) for the source
        /// </returns>
        public System.UInt32 get_Id()
        {
            var ret = g_source_get_id(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Gets a name for the source, used in debugging and profiling.  The
        /// name may be #NULL if it has never been set with g_source_set_name().
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the name of the source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_get_name( System.IntPtr source);

        /// <summary>
        /// Gets a name for the source, used in debugging and profiling.  The
        /// name may be #NULL if it has never been set with g_source_set_name().
        /// </summary>
        /// <returns>
        /// the name of the source
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.String get_Name()
        {
            var ret = g_source_get_name(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Gets the priority of a source.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the priority of the source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_source_get_priority( System.IntPtr source);

        /// <summary>
        /// Gets the priority of a source.
        /// </summary>
        /// <returns>
        /// the priority of the source
        /// </returns>
        public System.Int32 get_Priority()
        {
            var ret = g_source_get_priority(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Gets the "ready time" of @source, as set by
        /// g_source_set_ready_time().
        /// </summary>
        /// <remarks>
        /// Any time before the current monotonic time (including 0) is an
        /// indication that the source will fire immediately.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the monotonic ready time, -1 for "never"
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int64 g_source_get_ready_time( System.IntPtr source);

        /// <summary>
        /// Gets the "ready time" of @source, as set by
        /// g_source_set_ready_time().
        /// </summary>
        /// <remarks>
        /// Any time before the current monotonic time (including 0) is an
        /// indication that the source will fire immediately.
        /// </remarks>
        /// <returns>
        /// the monotonic ready time, -1 for "never"
        /// </returns>
        public System.Int64 get_ReadyTime()
        {
            var ret = g_source_get_ready_time(Handle);
            return default(System.Int64);
        }

        /// <summary>
        /// Gets the time to be used when checking this source. The advantage of
        /// calling this function over calling g_get_monotonic_time() directly is
        /// that when checking multiple sources, GLib can cache a single value
        /// instead of having to repeatedly get the system monotonic time.
        /// </summary>
        /// <remarks>
        /// The time here is the system monotonic time, if available, or some
        /// other reasonable alternative otherwise.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// the monotonic time in microseconds
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int64 g_source_get_time( System.IntPtr source);

        /// <summary>
        /// Gets the time to be used when checking this source. The advantage of
        /// calling this function over calling g_get_monotonic_time() directly is
        /// that when checking multiple sources, GLib can cache a single value
        /// instead of having to repeatedly get the system monotonic time.
        /// </summary>
        /// <remarks>
        /// The time here is the system monotonic time, if available, or some
        /// other reasonable alternative otherwise.  See g_get_monotonic_time().
        /// </remarks>
        /// <returns>
        /// the monotonic time in microseconds
        /// </returns>
        [GISharp.Core.Since("2.28")]
        public System.Int64 get_Time()
        {
            var ret = g_source_get_time(Handle);
            return default(System.Int64);
        }

        /// <summary>
        /// Returns whether @source has been destroyed.
        /// </summary>
        /// <remarks>
        /// This is important when you operate upon your objects
        /// from within idle handlers, but may have freed the object
        /// before the dispatch of your idle handler.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///    
        ///   GDK_THREADS_ENTER ();
        ///   // do stuff with self
        ///   self-&gt;idle_id = 0;
        ///   GDK_THREADS_LEAVE ();
        ///    
        ///   return G_SOURCE_REMOVE;
        /// }
        ///  
        /// static void
        /// some_widget_do_stuff_later (SomeWidget *self)
        /// {
        ///   self-&gt;idle_id = g_idle_add (idle_callback, self);
        /// }
        ///  
        /// static void
        /// some_widget_finalize (GObject *object)
        /// {
        ///   SomeWidget *self = SOME_WIDGET (object);
        ///    
        ///   if (self-&gt;idle_id)
        ///     g_source_remove (self-&gt;idle_id);
        ///    
        ///   G_OBJECT_CLASS (parent_class)-&gt;finalize (object);
        /// }
        /// ]|
        /// 
        /// This will fail in a multi-threaded application if the
        /// widget is destroyed before the idle handler fires due
        /// to the use after free in the callback. A solution, to
        /// this particular problem, is to check to if the source
        /// has already been destroy within the callback.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///   
        ///   GDK_THREADS_ENTER ();
        ///   if (!g_source_is_destroyed (g_main_current_source ()))
        ///     {
        ///       // do stuff with self
        ///     }
        ///   GDK_THREADS_LEAVE ();
        ///   
        ///   return FALSE;
        /// }
        /// ]|
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// %TRUE if the source has been destroyed
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_source_is_destroyed( System.IntPtr source);

        /// <summary>
        /// Returns whether @source has been destroyed.
        /// </summary>
        /// <remarks>
        /// This is important when you operate upon your objects
        /// from within idle handlers, but may have freed the object
        /// before the dispatch of your idle handler.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///    
        ///   GDK_THREADS_ENTER ();
        ///   // do stuff with self
        ///   self-&gt;idle_id = 0;
        ///   GDK_THREADS_LEAVE ();
        ///    
        ///   return G_SOURCE_REMOVE;
        /// }
        ///  
        /// static void
        /// some_widget_do_stuff_later (SomeWidget *self)
        /// {
        ///   self-&gt;idle_id = g_idle_add (idle_callback, self);
        /// }
        ///  
        /// static void
        /// some_widget_finalize (GObject *object)
        /// {
        ///   SomeWidget *self = SOME_WIDGET (object);
        ///    
        ///   if (self-&gt;idle_id)
        ///     g_source_remove (self-&gt;idle_id);
        ///    
        ///   G_OBJECT_CLASS (parent_class)-&gt;finalize (object);
        /// }
        /// ]|
        /// 
        /// This will fail in a multi-threaded application if the
        /// widget is destroyed before the idle handler fires due
        /// to the use after free in the callback. A solution, to
        /// this particular problem, is to check to if the source
        /// has already been destroy within the callback.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// static gboolean
        /// idle_callback (gpointer data)
        /// {
        ///   SomeWidget *self = data;
        ///   
        ///   GDK_THREADS_ENTER ();
        ///   if (!g_source_is_destroyed (g_main_current_source ()))
        ///     {
        ///       // do stuff with self
        ///     }
        ///   GDK_THREADS_LEAVE ();
        ///   
        ///   return FALSE;
        /// }
        /// ]|
        /// </remarks>
        /// <returns>
        /// %TRUE if the source has been destroyed
        /// </returns>
        [GISharp.Core.Since("2.12")]
        public System.Boolean get_IsDestroyed()
        {
            var ret = g_source_is_destroyed(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Increases the reference count on a source by one.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <returns>
        /// @source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_source_ref( System.IntPtr source);

        /// <summary>
        /// Increases the reference count on a source by one.
        /// </summary>
        /// <returns>
        /// @source
        /// </returns>
        protected override void Ref()
        {
            var ret = g_source_ref(Handle);
        }

        /// <summary>
        /// Detaches @child_source from @source and destroys it.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="childSource">
        /// a #GSource previously passed to
        ///     g_source_add_child_source().
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_remove_child_source( System.IntPtr source,  System.IntPtr childSource);

        /// <summary>
        /// Detaches @child_source from @source and destroys it.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="childSource">
        /// a #GSource previously passed to
        ///     g_source_add_child_source().
        /// </param>
        [GISharp.Core.Since("2.28")]
        public System.Void RemoveChildSource( GISharp.GLib.Source childSource)
        {
            if (childSource == null)
            {
                throw new ArgumentNullException("childSource");
            }
            var ret = g_source_remove_child_source(Handle, childSource);
            return default(System.Void);
        }

        /// <summary>
        /// Removes a file descriptor from the set of file descriptors polled for
        /// this source.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="fd">
        /// a #GPollFD structure previously passed to g_source_add_poll().
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_remove_poll( System.IntPtr source,  System.IntPtr fd);

        /// <summary>
        /// Removes a file descriptor from the set of file descriptors polled for
        /// this source.
        /// </summary>
        /// <remarks>
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="fd">
        /// a #GPollFD structure previously passed to g_source_add_poll().
        /// </param>
        public System.Void RemovePoll( GISharp.GLib.PollFD fd)
        {
            var ret = g_source_remove_poll(Handle, fd);
            return default(System.Void);
        }

        /// <summary>
        /// Reverses the effect of a previous call to g_source_add_unix_fd().
        /// </summary>
        /// <remarks>
        /// You only need to call this if you want to remove an fd from being
        /// watched while keeping the same source around.  In the normal case you
        /// will just want to destroy the source.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// As the name suggests, this function is not available on Windows.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="tag">
        /// the tag from g_source_add_unix_fd()
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_remove_unix_fd( System.IntPtr source,  System.IntPtr tag);

        /// <summary>
        /// Reverses the effect of a previous call to g_source_add_unix_fd().
        /// </summary>
        /// <remarks>
        /// You only need to call this if you want to remove an fd from being
        /// watched while keeping the same source around.  In the normal case you
        /// will just want to destroy the source.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// 
        /// As the name suggests, this function is not available on Windows.
        /// </remarks>
        /// <param name="tag">
        /// the tag from g_source_add_unix_fd()
        /// </param>
        [GISharp.Core.Since("2.36")]
        public System.Void RemoveUnixFd( System.IntPtr tag)
        {
            var ret = g_source_remove_unix_fd(Handle, tag);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        /// <remarks>
        /// The exact type of @func depends on the type of source; ie. you
        /// should not count on @func being called with @data as its first
        /// parameter.
        /// 
        /// Typically, you won't use this function. Instead use functions specific
        /// to the type of source you are using.
        /// </remarks>
        /// <param name="source">
        /// the source
        /// </param>
        /// <param name="func">
        /// a callback function
        /// </param>
        /// <param name="data">
        /// the data to pass to callback function
        /// </param>
        /// <param name="notify">
        /// a function to call when @data is no longer in use, or %NULL.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_callback( System.IntPtr source,  System.IntPtr func,  System.IntPtr data,  System.IntPtr notify);

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        /// <remarks>
        /// The exact type of @func depends on the type of source; ie. you
        /// should not count on @func being called with @data as its first
        /// parameter.
        /// 
        /// Typically, you won't use this function. Instead use functions specific
        /// to the type of source you are using.
        /// </remarks>
        /// <param name="func">
        /// a callback function
        /// </param>
        public System.Void SetCallback( GISharp.GLib.SourceFunc func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_source_set_callback(Handle, func, data, notify);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the callback function storing the data as a refcounted callback
        /// "object". This is used internally. Note that calling
        /// g_source_set_callback_indirect() assumes
        /// an initial reference count on @callback_data, and thus
        /// @callback_funcs-&gt;unref will eventually be called once more
        /// than @callback_funcs-&gt;ref.
        /// </summary>
        /// <param name="source">
        /// the source
        /// </param>
        /// <param name="callbackData">
        /// pointer to callback data "object"
        /// </param>
        /// <param name="callbackFuncs">
        /// functions for reference counting @callback_data
        ///                  and getting the callback and data
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_callback_indirect( System.IntPtr source,  System.IntPtr callbackData,  System.IntPtr callbackFuncs);

        /// <summary>
        /// Sets the callback function storing the data as a refcounted callback
        /// "object". This is used internally. Note that calling
        /// g_source_set_callback_indirect() assumes
        /// an initial reference count on @callback_data, and thus
        /// @callback_funcs-&gt;unref will eventually be called once more
        /// than @callback_funcs-&gt;ref.
        /// </summary>
        /// <param name="callbackData">
        /// pointer to callback data "object"
        /// </param>
        /// <param name="callbackFuncs">
        /// functions for reference counting @callback_data
        ///                  and getting the callback and data
        /// </param>
        public System.Void SetCallbackIndirect( System.IntPtr callbackData,  GISharp.GLib.SourceCallbackFuncs callbackFuncs)
        {
            var ret = g_source_set_callback_indirect(Handle, callbackData, callbackFuncs);
            return default(System.Void);
        }

        /// <summary>
        /// Sets whether a source can be called recursively. If @can_recurse is
        /// %TRUE, then while the source is being dispatched then this source
        /// will be processed normally. Otherwise, all processing of this
        /// source is blocked until the dispatch function returns.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="canRecurse">
        /// whether recursion is allowed for this source
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_can_recurse( System.IntPtr source,  System.Boolean canRecurse);

        /// <summary>
        /// Sets whether a source can be called recursively. If @can_recurse is
        /// %TRUE, then while the source is being dispatched then this source
        /// will be processed normally. Otherwise, all processing of this
        /// source is blocked until the dispatch function returns.
        /// </summary>
        /// <param name="value">
        /// whether recursion is allowed for this source
        /// </param>
        public System.Void set_CanRecurse( System.Boolean value)
        {
            var ret = g_source_set_can_recurse(Handle, canRecurse);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the source functions (can be used to override
        /// default implementations) of an unattached source.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="funcs">
        /// the new #GSourceFuncs
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_funcs( System.IntPtr source,  System.IntPtr funcs);

        /// <summary>
        /// Sets the source functions (can be used to override
        /// default implementations) of an unattached source.
        /// </summary>
        /// <param name="funcs">
        /// the new #GSourceFuncs
        /// </param>
        [GISharp.Core.Since("2.12")]
        public System.Void SetFuncs( GISharp.GLib.SourceFuncs funcs)
        {
            var ret = g_source_set_funcs(Handle, funcs);
            return default(System.Void);
        }

        /// <summary>
        /// Sets a name for the source, used in debugging and profiling.
        /// The name defaults to #NULL.
        /// </summary>
        /// <remarks>
        /// The source name should describe in a human-readable way
        /// what the source does. For example, "X11 event queue"
        /// or "GTK+ repaint idle handler" or whatever it is.
        /// 
        /// It is permitted to call this function multiple times, but is not
        /// recommended due to the potential performance impact.  For example,
        /// one could change the name in the "check" function of a #GSourceFuncs
        /// to include details like the event type in the source name.
        /// 
        /// Use caution if changing the name while another thread may be
        /// accessing it with g_source_get_name(); that function does not copy
        /// the value, and changing the value will free it while the other thread
        /// may be attempting to use it.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_name( System.IntPtr source,  System.IntPtr name);

        /// <summary>
        /// Sets a name for the source, used in debugging and profiling.
        /// The name defaults to #NULL.
        /// </summary>
        /// <remarks>
        /// The source name should describe in a human-readable way
        /// what the source does. For example, "X11 event queue"
        /// or "GTK+ repaint idle handler" or whatever it is.
        /// 
        /// It is permitted to call this function multiple times, but is not
        /// recommended due to the potential performance impact.  For example,
        /// one could change the name in the "check" function of a #GSourceFuncs
        /// to include details like the event type in the source name.
        /// 
        /// Use caution if changing the name while another thread may be
        /// accessing it with g_source_get_name(); that function does not copy
        /// the value, and changing the value will free it while the other thread
        /// may be attempting to use it.
        /// </remarks>
        /// <param name="value">
        /// debug name for the source
        /// </param>
        [GISharp.Core.Since("2.26")]
        public System.Void set_Name( System.String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_source_set_name(Handle, name);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the priority of a source. While the main loop is being run, a
        /// source will be dispatched if it is ready to be dispatched and no
        /// sources at a higher (numerically smaller) priority are ready to be
        /// dispatched.
        /// </summary>
        /// <remarks>
        /// A child source always has the same priority as its parent.  It is not
        /// permitted to change the priority of a source once it has been added
        /// as a child of another source.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="priority">
        /// the new priority.
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_priority( System.IntPtr source,  System.Int32 priority);

        /// <summary>
        /// Sets the priority of a source. While the main loop is being run, a
        /// source will be dispatched if it is ready to be dispatched and no
        /// sources at a higher (numerically smaller) priority are ready to be
        /// dispatched.
        /// </summary>
        /// <remarks>
        /// A child source always has the same priority as its parent.  It is not
        /// permitted to change the priority of a source once it has been added
        /// as a child of another source.
        /// </remarks>
        /// <param name="value">
        /// the new priority.
        /// </param>
        public System.Void set_Priority( System.Int32 value)
        {
            var ret = g_source_set_priority(Handle, priority);
            return default(System.Void);
        }

        /// <summary>
        /// Sets a #GSource to be dispatched when the given monotonic time is
        /// reached (or passed).  If the monotonic time is in the past (as it
        /// always will be if @ready_time is 0) then the source will be
        /// dispatched immediately.
        /// </summary>
        /// <remarks>
        /// If @ready_time is -1 then the source is never woken up on the basis
        /// of the passage of time.
        /// 
        /// Dispatching the source does not reset the ready time.  You should do
        /// so yourself, from the source dispatch function.
        /// 
        /// Note that if you have a pair of sources where the ready time of one
        /// suggests that it will be delivered first but the priority for the
        /// other suggests that it would be delivered first, and the ready time
        /// for both sources is reached during the same main context iteration
        /// then the order of dispatch is undefined.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="source">
        /// a #GSource
        /// </param>
        /// <param name="readyTime">
        /// the monotonic time at which the source will be ready,
        ///              0 for "immediately", -1 for "never"
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_ready_time( System.IntPtr source,  System.Int64 readyTime);

        /// <summary>
        /// Sets a #GSource to be dispatched when the given monotonic time is
        /// reached (or passed).  If the monotonic time is in the past (as it
        /// always will be if @ready_time is 0) then the source will be
        /// dispatched immediately.
        /// </summary>
        /// <remarks>
        /// If @ready_time is -1 then the source is never woken up on the basis
        /// of the passage of time.
        /// 
        /// Dispatching the source does not reset the ready time.  You should do
        /// so yourself, from the source dispatch function.
        /// 
        /// Note that if you have a pair of sources where the ready time of one
        /// suggests that it will be delivered first but the priority for the
        /// other suggests that it would be delivered first, and the ready time
        /// for both sources is reached during the same main context iteration
        /// then the order of dispatch is undefined.
        /// 
        /// This API is only intended to be used by implementations of #GSource.
        /// Do not call this API on a #GSource that you did not create.
        /// </remarks>
        /// <param name="value">
        /// the monotonic time at which the source will be ready,
        ///              0 for "immediately", -1 for "never"
        /// </param>
        [GISharp.Core.Since("2.36")]
        public System.Void set_ReadyTime( System.Int64 value)
        {
            var ret = g_source_set_ready_time(Handle, readyTime);
            return default(System.Void);
        }

        /// <summary>
        /// Decreases the reference count of a source by one. If the
        /// resulting reference count is zero the source and associated
        /// memory will be destroyed.
        /// </summary>
        /// <param name="source">
        /// a #GSource
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_unref( System.IntPtr source);

        /// <summary>
        /// Decreases the reference count of a source by one. If the
        /// resulting reference count is zero the source and associated
        /// memory will be destroyed.
        /// </summary>
        protected override System.Void Unref()
        {
            var ret = g_source_unref(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Removes the source with the given id from the default main context.
        /// </summary>
        /// <remarks>
        /// The id of a #GSource is given by g_source_get_id(), or will be
        /// returned by the functions g_source_attach(), g_idle_add(),
        /// g_idle_add_full(), g_timeout_add(), g_timeout_add_full(),
        /// g_child_watch_add(), g_child_watch_add_full(), g_io_add_watch(), and
        /// g_io_add_watch_full().
        /// 
        /// See also g_source_destroy(). You must use g_source_destroy() for sources
        /// added to a non-default main context.
        /// 
        /// It is a programmer error to attempt to remove a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// the ID of the source to remove.
        /// </param>
        /// <returns>
        /// For historical reasons, this function always returns %TRUE
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_source_remove( System.UInt32 tag);

        /// <summary>
        /// Removes the source with the given id from the default main context.
        /// </summary>
        /// <remarks>
        /// The id of a #GSource is given by g_source_get_id(), or will be
        /// returned by the functions g_source_attach(), g_idle_add(),
        /// g_idle_add_full(), g_timeout_add(), g_timeout_add_full(),
        /// g_child_watch_add(), g_child_watch_add_full(), g_io_add_watch(), and
        /// g_io_add_watch_full().
        /// 
        /// See also g_source_destroy(). You must use g_source_destroy() for sources
        /// added to a non-default main context.
        /// 
        /// It is a programmer error to attempt to remove a non-existent source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// the ID of the source to remove.
        /// </param>
        /// <returns>
        /// For historical reasons, this function always returns %TRUE
        /// </returns>
        public static System.Boolean RemoveByTag( System.UInt32 tag)
        {
            var ret = g_source_remove(tag);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes a source from the default main loop context given the
        /// source functions and user data. If multiple sources exist with the
        /// same source functions and user data, only one will be destroyed.
        /// </summary>
        /// <param name="funcs">
        /// The @source_funcs passed to g_source_new()
        /// </param>
        /// <param name="userData">
        /// the user data for the callback
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_source_remove_by_funcs_user_data( System.IntPtr funcs,  System.IntPtr userData);

        /// <summary>
        /// Removes a source from the default main loop context given the
        /// source functions and user data. If multiple sources exist with the
        /// same source functions and user data, only one will be destroyed.
        /// </summary>
        /// <param name="funcs">
        /// The @source_funcs passed to g_source_new()
        /// </param>
        /// <param name="userData">
        /// the user data for the callback
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        public static System.Boolean RemoveByFuncsUserData( GISharp.GLib.SourceFuncs funcs,  System.IntPtr userData)
        {
            var ret = g_source_remove_by_funcs_user_data(funcs, userData);
            return default(System.Boolean);
        }

        /// <summary>
        /// Removes a source from the default main loop context given the user
        /// data for the callback. If multiple sources exist with the same user
        /// data, only one will be destroyed.
        /// </summary>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_source_remove_by_user_data( System.IntPtr userData);

        /// <summary>
        /// Removes a source from the default main loop context given the user
        /// data for the callback. If multiple sources exist with the same user
        /// data, only one will be destroyed.
        /// </summary>
        /// <param name="userData">
        /// the user_data for the callback.
        /// </param>
        /// <returns>
        /// %TRUE if a source was found and removed.
        /// </returns>
        public static System.Boolean RemoveByUserData( System.IntPtr userData)
        {
            var ret = g_source_remove_by_user_data(userData);
            return default(System.Boolean);
        }

        /// <summary>
        /// Sets the name of a source using its ID.
        /// </summary>
        /// <remarks>
        /// This is a convenience utility to set source names from the return
        /// value of g_idle_add(), g_timeout_add(), etc.
        /// 
        /// It is a programmer error to attempt to set the name of a non-existent
        /// source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// a #GSource ID
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_source_set_name_by_id( System.UInt32 tag,  System.IntPtr name);

        /// <summary>
        /// Sets the name of a source using its ID.
        /// </summary>
        /// <remarks>
        /// This is a convenience utility to set source names from the return
        /// value of g_idle_add(), g_timeout_add(), etc.
        /// 
        /// It is a programmer error to attempt to set the name of a non-existent
        /// source.
        /// 
        /// More specifically: source IDs can be reissued after a source has been
        /// destroyed and therefore it is never valid to use this function with a
        /// source ID which may have already been removed.  An example is when
        /// scheduling an idle to run in another thread with g_idle_add(): the
        /// idle may already have run and been removed by the time this function
        /// is called on its (now invalid) source ID.  This source ID may have
        /// been reissued, leading to the operation being performed against the
        /// wrong source.
        /// </remarks>
        /// <param name="tag">
        /// a #GSource ID
        /// </param>
        /// <param name="name">
        /// debug name for the source
        /// </param>
        [GISharp.Core.Since("2.26")]
        public static System.Void SetNameById( System.UInt32 tag,  System.String name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            var ret = g_source_set_name_by_id(tag, name);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the currently firing source for this thread.
        /// </summary>
        /// <returns>
        /// The currently firing source or %NULL.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_main_current_source();

        /// <summary>
        /// Returns the currently firing source for this thread.
        /// </summary>
        /// <returns>
        /// The currently firing source or %NULL.
        /// </returns>
        [GISharp.Core.Since("2.12")]
        public static GISharp.GLib.Source MainCurrentSource()
        {
            var ret = g_main_current_source();
            return default(GISharp.GLib.Source);
        }
    }

    /// <summary>
    /// The `GSourceCallbackFuncs` struct contains
    /// functions for managing callback objects.
    /// </summary>
    public partial struct SourceCallbackFuncs
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate System.Void RefNative( System.IntPtr cbData);

        public RefNative Ref;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate System.Void UnrefNative( System.IntPtr cbData);

        public UnrefNative Unref;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate System.Void GetNative( System.IntPtr cbData,  System.IntPtr source,  System.IntPtr func,  System.IntPtr data);

        public GetNative Get;
    }

    /// <summary>
    /// The `GSourceFuncs` struct contains a table of
    /// functions used to handle event sources in a generic manner.
    /// </summary>
    /// <remarks>
    /// For idle sources, the prepare and check functions always return %TRUE
    /// to indicate that the source is always ready to be processed. The prepare
    /// function also returns a timeout value of 0 to ensure that the poll() call
    /// doesn't block (since that would be time wasted which could have been spent
    /// running the idle function).
    /// 
    /// For timeout sources, the prepare and check functions both return %TRUE
    /// if the timeout interval has expired. The prepare function also returns
    /// a timeout value to ensure that the poll() call doesn't block too long
    /// and miss the next timeout.
    /// 
    /// For file descriptor sources, the prepare function typically returns %FALSE,
    /// since it must wait until poll() has been called before it knows whether
    /// any events need to be processed. It sets the returned timeout to -1 to
    /// indicate that it doesn't mind how long the poll() call blocks. In the
    /// check function, it tests the results of the poll() call to see if the
    /// required condition has been met, and returns %TRUE if so.
    /// </remarks>
    public partial struct SourceFuncs
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate System.Boolean PrepareNative( System.IntPtr source,  System.Int32 timeout);

        public PrepareNative Prepare;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate System.Boolean CheckNative( System.IntPtr source);

        public CheckNative Check;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate System.Boolean DispatchNative( System.IntPtr source,  System.IntPtr callback,  System.IntPtr userData);

        public DispatchNative Dispatch;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate System.Void FinalizeNative( System.IntPtr source);

        public FinalizeNative Finalize;
        public GISharp.GLib.SourceFunc ClosureCallback;
        public GISharp.GLib.SourceDummyMarshal ClosureMarshal;
    }

    /// <summary>
    /// Represents a precise time, with seconds and microseconds.
    /// Similar to the struct timeval returned by the gettimeofday()
    /// UNIX system call.
    /// </summary>
    /// <remarks>
    /// GLib is attempting to unify around the use of 64bit integers to
    /// represent microsecond-precision time. As such, this type will be
    /// removed from a future version of GLib.
    /// </remarks>
    public partial struct TimeVal
    {
        /// <summary>
        /// seconds
        /// </summary>
        public System.Int64 TvSec;

        /// <summary>
        /// microseconds
        /// </summary>
        public System.Int64 TvUsec;

        /// <summary>
        /// Adds the given number of microseconds to @time_. @microseconds can
        /// also be negative to decrease the value of @time_.
        /// </summary>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <param name="microseconds">
        /// number of microseconds to add to @time
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_time_val_add( System.IntPtr time,  System.Int64 microseconds);

        /// <summary>
        /// Adds the given number of microseconds to @time_. @microseconds can
        /// also be negative to decrease the value of @time_.
        /// </summary>
        /// <param name="microseconds">
        /// number of microseconds to add to @time
        /// </param>
        public System.Void Add( System.Int64 microseconds)
        {
            var ret = g_time_val_add(Handle, microseconds);
            return default(System.Void);
        }

        /// <summary>
        /// Converts @time_ into an RFC 3339 encoded string, relative to the
        /// Coordinated Universal Time (UTC). This is one of the many formats
        /// allowed by ISO 8601.
        /// </summary>
        /// <remarks>
        /// ISO 8601 allows a large number of date/time formats, with or without
        /// punctuation and optional elements. The format returned by this function
        /// is a complete date and time, with optional punctuation included, the
        /// UTC time zone represented as "Z", and the @tv_usec part included if
        /// and only if it is nonzero, i.e. either
        /// "YYYY-MM-DDTHH:MM:SSZ" or "YYYY-MM-DDTHH:MM:SS.fffffZ".
        /// 
        /// This corresponds to the Internet date/time format defined by
        /// [RFC 3339](https://www.ietf.org/rfc/rfc3339.txt),
        /// and to either of the two most-precise formats defined by
        /// the W3C Note
        /// [Date and Time Formats](http://www.w3.org/TR/NOTE-datetime-19980827).
        /// Both of these documents are profiles of ISO 8601.
        /// 
        /// Use g_date_time_format() or g_strdup_printf() if a different
        /// variation of ISO 8601 format is required.
        /// </remarks>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a newly allocated string containing an ISO 8601 date
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_val_to_iso8601( System.IntPtr time);

        /// <summary>
        /// Converts @time_ into an RFC 3339 encoded string, relative to the
        /// Coordinated Universal Time (UTC). This is one of the many formats
        /// allowed by ISO 8601.
        /// </summary>
        /// <remarks>
        /// ISO 8601 allows a large number of date/time formats, with or without
        /// punctuation and optional elements. The format returned by this function
        /// is a complete date and time, with optional punctuation included, the
        /// UTC time zone represented as "Z", and the @tv_usec part included if
        /// and only if it is nonzero, i.e. either
        /// "YYYY-MM-DDTHH:MM:SSZ" or "YYYY-MM-DDTHH:MM:SS.fffffZ".
        /// 
        /// This corresponds to the Internet date/time format defined by
        /// [RFC 3339](https://www.ietf.org/rfc/rfc3339.txt),
        /// and to either of the two most-precise formats defined by
        /// the W3C Note
        /// [Date and Time Formats](http://www.w3.org/TR/NOTE-datetime-19980827).
        /// Both of these documents are profiles of ISO 8601.
        /// 
        /// Use g_date_time_format() or g_strdup_printf() if a different
        /// variation of ISO 8601 format is required.
        /// </remarks>
        /// <returns>
        /// a newly allocated string containing an ISO 8601 date
        /// </returns>
        [GISharp.Core.Since("2.12")]
        public System.String ToIso8601()
        {
            var ret = g_time_val_to_iso8601(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Converts a string containing an ISO 8601 encoded date and time
        /// to a #GTimeVal and puts it into @time_.
        /// </summary>
        /// <remarks>
        /// @iso_date must include year, month, day, hours, minutes, and
        /// seconds. It can optionally include fractions of a second and a time
        /// zone indicator. (In the absence of any time zone indication, the
        /// timestamp is assumed to be in local time.)
        /// </remarks>
        /// <param name="isoDate">
        /// an ISO 8601 encoded date string
        /// </param>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// %TRUE if the conversion was successful.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_time_val_from_iso8601( System.IntPtr isoDate, out System.IntPtr time);

        /// <summary>
        /// Converts a string containing an ISO 8601 encoded date and time
        /// to a #GTimeVal and puts it into @time_.
        /// </summary>
        /// <remarks>
        /// @iso_date must include year, month, day, hours, minutes, and
        /// seconds. It can optionally include fractions of a second and a time
        /// zone indicator. (In the absence of any time zone indication, the
        /// timestamp is assumed to be in local time.)
        /// </remarks>
        /// <param name="isoDate">
        /// an ISO 8601 encoded date string
        /// </param>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// %TRUE if the conversion was successful.
        /// </returns>
        [GISharp.Core.Since("2.12")]
        public static System.Boolean FromIso8601( System.String isoDate, out GISharp.GLib.TimeVal time)
        {
            if (isoDate == null)
            {
                throw new ArgumentNullException("isoDate");
            }
            var ret = g_time_val_from_iso8601(isoDate, time);
            return default(System.Boolean);
        }
    }

    /// <summary>
    /// #GTimeZone is an opaque structure whose members cannot be accessed
    /// directly.
    /// </summary>
    [GISharp.Core.Since("2.26")]
    public partial class TimeZone : GISharp.Core.ReferenceCountedOpaque<TimeZone>
    {
        public TimeZone(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to @identifier.
        /// </summary>
        /// <remarks>
        /// @identifier can either be an RFC3339/ISO 8601 time offset or
        /// something that would pass as a valid value for the `TZ` environment
        /// variable (including %NULL).
        /// 
        /// In Windows, @identifier can also be the unlocalized name of a time
        /// zone for standard time, for example "Pacific Standard Time".
        /// 
        /// Valid RFC3339 time offsets are `"Z"` (for UTC) or
        /// `"±hh:mm"`.  ISO 8601 additionally specifies
        /// `"±hhmm"` and `"±hh"`.  Offsets are
        /// time values to be added to Coordinated Universal Time (UTC) to get
        /// the local time.
        /// 
        /// In UNIX, the `TZ` environment variable typically corresponds
        /// to the name of a file in the zoneinfo database, or string in
        /// "std offset [dst [offset],start[/time],end[/time]]" (POSIX) format.
        /// There  are  no spaces in the specification. The name of standard
        /// and daylight savings time zone must be three or more alphabetic
        /// characters. Offsets are time values to be added to local time to
        /// get Coordinated Universal Time (UTC) and should be
        /// `"[±]hh[[:]mm[:ss]]"`.  Dates are either
        /// `"Jn"` (Julian day with n between 1 and 365, leap
        /// years not counted), `"n"` (zero-based Julian day
        /// with n between 0 and 365) or `"Mm.w.d"` (day d
        /// (0 &lt;= d &lt;= 6) of week w (1 &lt;= w &lt;= 5) of month m (1 &lt;= m &lt;= 12), day
        /// 0 is a Sunday).  Times are in local wall clock time, the default is
        /// 02:00:00.
        /// 
        /// In Windows, the "tzn[+|–]hh[:mm[:ss]][dzn]" format is used, but also
        /// accepts POSIX format.  The Windows format uses US rules for all time
        /// zones; daylight savings time is 60 minutes behind the standard time
        /// with date and time of change taken from Pacific Standard Time.
        /// Offsets are time values to be added to the local time to get
        /// Coordinated Universal Time (UTC).
        /// 
        /// g_time_zone_new_local() calls this function with the value of the
        /// `TZ` environment variable. This function itself is independent of
        /// the value of `TZ`, but if @identifier is %NULL then `/etc/localtime`
        /// will be consulted to discover the correct time zone on UNIX and the
        /// registry will be consulted or GetTimeZoneInformation() will be used
        /// to get the local time zone on Windows.
        /// 
        /// If intervals are not available, only time zone rules from `TZ`
        /// environment variable or other means, then they will be computed
        /// from year 1900 to 2037.  If the maximum year for the rules is
        /// available and it is greater than 2037, then it will followed
        /// instead.
        /// 
        /// See
        /// [RFC3339 §5.6](http://tools.ietf.org/html/rfc3339#section-5.6)
        /// for a precise definition of valid RFC3339 time offsets
        /// (the `time-offset` expansion) and ISO 8601 for the
        /// full list of valid time offsets.  See
        /// [The GNU C Library manual](http://www.gnu.org/s/libc/manual/html_node/TZ-Variable.html)
        /// for an explanation of the possible
        /// values of the `TZ` environment variable. See
        /// [Microsoft Time Zone Index Values](http://msdn.microsoft.com/en-us/library/ms912391%28v=winembedded.11%29.aspx)
        /// for the list of time zones on Windows.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="identifier">
        /// a timezone identifier
        /// </param>
        /// <returns>
        /// the requested timezone
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_new( System.IntPtr identifier);

        /// <summary>
        /// Creates a #GTimeZone corresponding to @identifier.
        /// </summary>
        /// <remarks>
        /// @identifier can either be an RFC3339/ISO 8601 time offset or
        /// something that would pass as a valid value for the `TZ` environment
        /// variable (including %NULL).
        /// 
        /// In Windows, @identifier can also be the unlocalized name of a time
        /// zone for standard time, for example "Pacific Standard Time".
        /// 
        /// Valid RFC3339 time offsets are `"Z"` (for UTC) or
        /// `"±hh:mm"`.  ISO 8601 additionally specifies
        /// `"±hhmm"` and `"±hh"`.  Offsets are
        /// time values to be added to Coordinated Universal Time (UTC) to get
        /// the local time.
        /// 
        /// In UNIX, the `TZ` environment variable typically corresponds
        /// to the name of a file in the zoneinfo database, or string in
        /// "std offset [dst [offset],start[/time],end[/time]]" (POSIX) format.
        /// There  are  no spaces in the specification. The name of standard
        /// and daylight savings time zone must be three or more alphabetic
        /// characters. Offsets are time values to be added to local time to
        /// get Coordinated Universal Time (UTC) and should be
        /// `"[±]hh[[:]mm[:ss]]"`.  Dates are either
        /// `"Jn"` (Julian day with n between 1 and 365, leap
        /// years not counted), `"n"` (zero-based Julian day
        /// with n between 0 and 365) or `"Mm.w.d"` (day d
        /// (0 &lt;= d &lt;= 6) of week w (1 &lt;= w &lt;= 5) of month m (1 &lt;= m &lt;= 12), day
        /// 0 is a Sunday).  Times are in local wall clock time, the default is
        /// 02:00:00.
        /// 
        /// In Windows, the "tzn[+|–]hh[:mm[:ss]][dzn]" format is used, but also
        /// accepts POSIX format.  The Windows format uses US rules for all time
        /// zones; daylight savings time is 60 minutes behind the standard time
        /// with date and time of change taken from Pacific Standard Time.
        /// Offsets are time values to be added to the local time to get
        /// Coordinated Universal Time (UTC).
        /// 
        /// g_time_zone_new_local() calls this function with the value of the
        /// `TZ` environment variable. This function itself is independent of
        /// the value of `TZ`, but if @identifier is %NULL then `/etc/localtime`
        /// will be consulted to discover the correct time zone on UNIX and the
        /// registry will be consulted or GetTimeZoneInformation() will be used
        /// to get the local time zone on Windows.
        /// 
        /// If intervals are not available, only time zone rules from `TZ`
        /// environment variable or other means, then they will be computed
        /// from year 1900 to 2037.  If the maximum year for the rules is
        /// available and it is greater than 2037, then it will followed
        /// instead.
        /// 
        /// See
        /// [RFC3339 §5.6](http://tools.ietf.org/html/rfc3339#section-5.6)
        /// for a precise definition of valid RFC3339 time offsets
        /// (the `time-offset` expansion) and ISO 8601 for the
        /// full list of valid time offsets.  See
        /// [The GNU C Library manual](http://www.gnu.org/s/libc/manual/html_node/TZ-Variable.html)
        /// for an explanation of the possible
        /// values of the `TZ` environment variable. See
        /// [Microsoft Time Zone Index Values](http://msdn.microsoft.com/en-us/library/ms912391%28v=winembedded.11%29.aspx)
        /// for the list of time zones on Windows.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="identifier">
        /// a timezone identifier
        /// </param>
        /// <returns>
        /// the requested timezone
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public TimeZone( System.String identifier) : base(IntPtr.Zero)
        {
            var ret = g_time_zone_new(identifier);
        }

        /// <summary>
        /// Finds an interval within @tz that corresponds to the given @time_,
        /// possibly adjusting @time_ if required to fit into an interval.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_time_zone_find_interval(), with the
        /// difference that it always succeeds (by making the adjustments
        /// described below).
        /// 
        /// In any of the cases where g_time_zone_find_interval() succeeds then
        /// this function returns the same value, without modifying @time_.
        /// 
        /// This function may, however, modify @time_ in order to deal with
        /// non-existent times.  If the non-existent local @time_ of 02:30 were
        /// requested on March 14th 2010 in Toronto then this function would
        /// adjust @time_ to be 03:00 and return the interval containing the
        /// adjusted time.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a pointer to a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, never -1
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_time_zone_adjust_time( System.IntPtr tz,  System.IntPtr type,  System.Int64 time);

        /// <summary>
        /// Finds an interval within @tz that corresponds to the given @time_,
        /// possibly adjusting @time_ if required to fit into an interval.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_time_zone_find_interval(), with the
        /// difference that it always succeeds (by making the adjustments
        /// described below).
        /// 
        /// In any of the cases where g_time_zone_find_interval() succeeds then
        /// this function returns the same value, without modifying @time_.
        /// 
        /// This function may, however, modify @time_ in order to deal with
        /// non-existent times.  If the non-existent local @time_ of 02:30 were
        /// requested on March 14th 2010 in Toronto then this function would
        /// adjust @time_ to be 03:00 and return the interval containing the
        /// adjusted time.
        /// </remarks>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a pointer to a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, never -1
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 AdjustTime( GISharp.GLib.TimeType type,  System.Int64 time)
        {
            var ret = g_time_zone_adjust_time(Handle, type, time);
            return default(System.Int32);
        }

        /// <summary>
        /// Finds an the interval within @tz that corresponds to the given @time_.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// If @type is %G_TIME_TYPE_UNIVERSAL then this function will always
        /// succeed (since universal time is monotonic and continuous).
        /// 
        /// Otherwise @time_ is treated as local time.  The distinction between
        /// %G_TIME_TYPE_STANDARD and %G_TIME_TYPE_DAYLIGHT is ignored except in
        /// the case that the given @time_ is ambiguous.  In Toronto, for example,
        /// 01:30 on November 7th 2010 occurred twice (once inside of daylight
        /// savings time and the next, an hour later, outside of daylight savings
        /// time).  In this case, the different value of @type would result in a
        /// different interval being returned.
        /// 
        /// It is still possible for this function to fail.  In Toronto, for
        /// example, 02:00 on March 14th 2010 does not exist (due to the leap
        /// forward to begin daylight savings time).  -1 is returned in that
        /// case.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, or -1 in case of failure
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_time_zone_find_interval( System.IntPtr tz,  System.IntPtr type,  System.Int64 time);

        /// <summary>
        /// Finds an the interval within @tz that corresponds to the given @time_.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// If @type is %G_TIME_TYPE_UNIVERSAL then this function will always
        /// succeed (since universal time is monotonic and continuous).
        /// 
        /// Otherwise @time_ is treated as local time.  The distinction between
        /// %G_TIME_TYPE_STANDARD and %G_TIME_TYPE_DAYLIGHT is ignored except in
        /// the case that the given @time_ is ambiguous.  In Toronto, for example,
        /// 01:30 on November 7th 2010 occurred twice (once inside of daylight
        /// savings time and the next, an hour later, outside of daylight savings
        /// time).  In this case, the different value of @type would result in a
        /// different interval being returned.
        /// 
        /// It is still possible for this function to fail.  In Toronto, for
        /// example, 02:00 on March 14th 2010 does not exist (due to the leap
        /// forward to begin daylight savings time).  -1 is returned in that
        /// case.
        /// </remarks>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, or -1 in case of failure
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 FindInterval( GISharp.GLib.TimeType type,  System.Int64 time)
        {
            var ret = g_time_zone_find_interval(Handle, type, time);
            return default(System.Int32);
        }

        /// <summary>
        /// Determines the time zone abbreviation to be used during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings time
        /// is in effect.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the time zone abbreviation, which belongs to @tz
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_get_abbreviation( System.IntPtr tz,  System.Int32 interval);

        /// <summary>
        /// Determines the time zone abbreviation to be used during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings time
        /// is in effect.
        /// </remarks>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the time zone abbreviation, which belongs to @tz
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.String GetAbbreviation( System.Int32 interval)
        {
            var ret = g_time_zone_get_abbreviation(Handle, interval);
            return default(System.String);
        }

        /// <summary>
        /// Determines the offset to UTC in effect during a particular @interval
        /// of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The offset is the number of seconds that you add to UTC time to
        /// arrive at local time for @tz (ie: negative numbers for time zones
        /// west of GMT, positive numbers for east).
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the number of seconds that should be added to UTC to get the
        ///          local time in @tz
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_time_zone_get_offset( System.IntPtr tz,  System.Int32 interval);

        /// <summary>
        /// Determines the offset to UTC in effect during a particular @interval
        /// of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The offset is the number of seconds that you add to UTC time to
        /// arrive at local time for @tz (ie: negative numbers for time zones
        /// west of GMT, positive numbers for east).
        /// </remarks>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the number of seconds that should be added to UTC to get the
        ///          local time in @tz
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 GetOffset( System.Int32 interval)
        {
            var ret = g_time_zone_get_offset(Handle, interval);
            return default(System.Int32);
        }

        /// <summary>
        /// Determines if daylight savings time is in effect during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_time_zone_is_dst( System.IntPtr tz,  System.Int32 interval);

        /// <summary>
        /// Determines if daylight savings time is in effect during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Boolean IsDst( System.Int32 interval)
        {
            var ret = g_time_zone_is_dst(Handle, interval);
            return default(System.Boolean);
        }

        /// <summary>
        /// Increases the reference count on @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new reference to @tz.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_ref( System.IntPtr tz);

        /// <summary>
        /// Increases the reference count on @tz.
        /// </summary>
        /// <returns>
        /// a new reference to @tz.
        /// </returns>
        [GISharp.Core.Since("2.26")]
        protected override void Ref()
        {
            var ret = g_time_zone_ref(Handle);
        }

        /// <summary>
        /// Decreases the reference count on @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_time_zone_unref( System.IntPtr tz);

        /// <summary>
        /// Decreases the reference count on @tz.
        /// </summary>
        [GISharp.Core.Since("2.26")]
        protected override System.Void Unref()
        {
            var ret = g_time_zone_unref(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to local time.  The local time
        /// zone may change between invocations to this function; for example,
        /// if the system administrator changes it.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with the value of
        /// the `TZ` environment variable (including the possibility of %NULL).
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the local timezone
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_new_local();

        /// <summary>
        /// Creates a #GTimeZone corresponding to local time.  The local time
        /// zone may change between invocations to this function; for example,
        /// if the system administrator changes it.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with the value of
        /// the `TZ` environment variable (including the possibility of %NULL).
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the local timezone
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.TimeZone Local()
        {
            var ret = g_time_zone_new_local();
            return default(GISharp.GLib.TimeZone);
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the universal timezone
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_time_zone_new_utc();

        /// <summary>
        /// Creates a #GTimeZone corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the universal timezone
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public static GISharp.GLib.TimeZone Utc()
        {
            var ret = g_time_zone_new_utc();
            return default(GISharp.GLib.TimeZone);
        }
    }

    /// <summary>
    /// The GTree struct is an opaque data structure representing a
    /// [balanced binary tree][glib-Balanced-Binary-Trees]. It should be
    /// accessed only by using the following functions.
    /// </summary>
    public partial class Tree : GISharp.Core.ReferenceCountedOpaque<Tree>
    {
        public Tree(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Removes all keys and values from the #GTree and decreases its
        /// reference count by one. If keys and/or values are dynamically
        /// allocated, you should either free them first or create the #GTree
        /// using g_tree_new_full(). In the latter case the destroy functions
        /// you supplied will be called on all keys and values before destroying
        /// the #GTree.
        /// </summary>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_tree_destroy( System.IntPtr tree);

        /// <summary>
        /// Removes all keys and values from the #GTree and decreases its
        /// reference count by one. If keys and/or values are dynamically
        /// allocated, you should either free them first or create the #GTree
        /// using g_tree_new_full(). In the latter case the destroy functions
        /// you supplied will be called on all keys and values before destroying
        /// the #GTree.
        /// </summary>
        public System.Void Destroy()
        {
            var ret = g_tree_destroy(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Calls the given function for each of the key/value pairs in the #GTree.
        /// The function is passed the key and value of each pair, and the given
        /// @data parameter. The tree is traversed in sorted order.
        /// </summary>
        /// <remarks>
        /// The tree may not be modified while iterating over it (you can't
        /// add/remove items). To remove all items matching a predicate, you need
        /// to add each item to a list in your #GTraverseFunc as you walk over
        /// the tree, then walk the list and remove each item.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="func">
        /// the function to call for each node visited.
        ///     If this function returns %TRUE, the traversal is stopped.
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_tree_foreach( System.IntPtr tree,  System.IntPtr func,  System.IntPtr userData);

        /// <summary>
        /// Calls the given function for each of the key/value pairs in the #GTree.
        /// The function is passed the key and value of each pair, and the given
        /// @data parameter. The tree is traversed in sorted order.
        /// </summary>
        /// <remarks>
        /// The tree may not be modified while iterating over it (you can't
        /// add/remove items). To remove all items matching a predicate, you need
        /// to add each item to a list in your #GTraverseFunc as you walk over
        /// the tree, then walk the list and remove each item.
        /// </remarks>
        /// <param name="func">
        /// the function to call for each node visited.
        ///     If this function returns %TRUE, the traversal is stopped.
        /// </param>
        public System.Void Foreach( GISharp.GLib.TraverseFunc func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            var ret = g_tree_foreach(Handle, func, userData);
            return default(System.Void);
        }

        /// <summary>
        /// Gets the height of a #GTree.
        /// </summary>
        /// <remarks>
        /// If the #GTree contains no nodes, the height is 0.
        /// If the #GTree contains only one root node the height is 1.
        /// If the root node has children the height is 2, etc.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <returns>
        /// the height of @tree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_tree_height( System.IntPtr tree);

        /// <summary>
        /// Gets the height of a #GTree.
        /// </summary>
        /// <remarks>
        /// If the #GTree contains no nodes, the height is 0.
        /// If the #GTree contains only one root node the height is 1.
        /// If the root node has children the height is 2, etc.
        /// </remarks>
        /// <returns>
        /// the height of @tree
        /// </returns>
        public System.Int32 Height()
        {
            var ret = g_tree_height(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Inserts a key/value pair into a #GTree.
        /// </summary>
        /// <remarks>
        /// If the given key already exists in the #GTree its corresponding value
        /// is set to the new value. If you supplied a @value_destroy_func when
        /// creating the #GTree, the old value is freed using that function. If
        /// you supplied a @key_destroy_func when creating the #GTree, the passed
        /// key is freed using that function.
        /// 
        /// The tree is automatically 'balanced' as new key/value pairs are added,
        /// so that the distance from the root to every leaf is as small as possible.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="key">
        /// the key to insert
        /// </param>
        /// <param name="value">
        /// the value corresponding to the key
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_tree_insert( System.IntPtr tree,  System.IntPtr key,  System.IntPtr value);

        /// <summary>
        /// Inserts a key/value pair into a #GTree.
        /// </summary>
        /// <remarks>
        /// If the given key already exists in the #GTree its corresponding value
        /// is set to the new value. If you supplied a @value_destroy_func when
        /// creating the #GTree, the old value is freed using that function. If
        /// you supplied a @key_destroy_func when creating the #GTree, the passed
        /// key is freed using that function.
        /// 
        /// The tree is automatically 'balanced' as new key/value pairs are added,
        /// so that the distance from the root to every leaf is as small as possible.
        /// </remarks>
        /// <param name="key">
        /// the key to insert
        /// </param>
        /// <param name="value">
        /// the value corresponding to the key
        /// </param>
        public System.Void Insert( System.IntPtr key,  System.IntPtr value)
        {
            var ret = g_tree_insert(Handle, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Gets the value corresponding to the given key. Since a #GTree is
        /// automatically balanced as key/value pairs are added, key lookup
        /// is O(log n) (where n is the number of key/value pairs in the tree).
        /// </summary>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="key">
        /// the key to look up
        /// </param>
        /// <returns>
        /// the value corresponding to the key, or %NULL
        ///     if the key was not found
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_tree_lookup( System.IntPtr tree,  System.IntPtr key);

        /// <summary>
        /// Gets the value corresponding to the given key. Since a #GTree is
        /// automatically balanced as key/value pairs are added, key lookup
        /// is O(log n) (where n is the number of key/value pairs in the tree).
        /// </summary>
        /// <param name="key">
        /// the key to look up
        /// </param>
        /// <returns>
        /// the value corresponding to the key, or %NULL
        ///     if the key was not found
        /// </returns>
        public System.IntPtr Lookup( System.IntPtr key)
        {
            var ret = g_tree_lookup(Handle, key);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Looks up a key in the #GTree, returning the original key and the
        /// associated value. This is useful if you need to free the memory
        /// allocated for the original key, for example before calling
        /// g_tree_remove().
        /// </summary>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="lookupKey">
        /// the key to look up
        /// </param>
        /// <param name="origKey">
        /// returns the original key
        /// </param>
        /// <param name="value">
        /// returns the value associated with the key
        /// </param>
        /// <returns>
        /// %TRUE if the key was found in the #GTree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_tree_lookup_extended( System.IntPtr tree,  System.IntPtr lookupKey,  System.IntPtr origKey,  System.IntPtr value);

        /// <summary>
        /// Looks up a key in the #GTree, returning the original key and the
        /// associated value. This is useful if you need to free the memory
        /// allocated for the original key, for example before calling
        /// g_tree_remove().
        /// </summary>
        /// <param name="lookupKey">
        /// the key to look up
        /// </param>
        /// <param name="origKey">
        /// returns the original key
        /// </param>
        /// <param name="value">
        /// returns the value associated with the key
        /// </param>
        /// <returns>
        /// %TRUE if the key was found in the #GTree
        /// </returns>
        public System.Boolean LookupExtended( System.IntPtr lookupKey,  System.IntPtr origKey,  System.IntPtr value)
        {
            var ret = g_tree_lookup_extended(Handle, lookupKey, origKey, value);
            return default(System.Boolean);
        }

        /// <summary>
        /// Gets the number of nodes in a #GTree.
        /// </summary>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <returns>
        /// the number of nodes in @tree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_tree_nnodes( System.IntPtr tree);

        /// <summary>
        /// Gets the number of nodes in a #GTree.
        /// </summary>
        /// <returns>
        /// the number of nodes in @tree
        /// </returns>
        public System.Int32 Nnodes()
        {
            var ret = g_tree_nnodes(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Increments the reference count of @tree by one.
        /// </summary>
        /// <remarks>
        /// It is safe to call this function from any thread.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <returns>
        /// the passed in #GTree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_tree_ref( System.IntPtr tree);

        /// <summary>
        /// Increments the reference count of @tree by one.
        /// </summary>
        /// <remarks>
        /// It is safe to call this function from any thread.
        /// </remarks>
        /// <returns>
        /// the passed in #GTree
        /// </returns>
        [GISharp.Core.Since("2.22")]
        protected override void Ref()
        {
            var ret = g_tree_ref(Handle);
        }

        /// <summary>
        /// Removes a key/value pair from a #GTree.
        /// </summary>
        /// <remarks>
        /// If the #GTree was created using g_tree_new_full(), the key and value
        /// are freed using the supplied destroy functions, otherwise you have to
        /// make sure that any dynamically allocated values are freed yourself.
        /// If the key does not exist in the #GTree, the function does nothing.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found (prior to 2.8, this function
        ///     returned nothing)
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_tree_remove( System.IntPtr tree,  System.IntPtr key);

        /// <summary>
        /// Removes a key/value pair from a #GTree.
        /// </summary>
        /// <remarks>
        /// If the #GTree was created using g_tree_new_full(), the key and value
        /// are freed using the supplied destroy functions, otherwise you have to
        /// make sure that any dynamically allocated values are freed yourself.
        /// If the key does not exist in the #GTree, the function does nothing.
        /// </remarks>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found (prior to 2.8, this function
        ///     returned nothing)
        /// </returns>
        public System.Boolean Remove( System.IntPtr key)
        {
            var ret = g_tree_remove(Handle, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Inserts a new key and value into a #GTree similar to g_tree_insert().
        /// The difference is that if the key already exists in the #GTree, it gets
        /// replaced by the new key. If you supplied a @value_destroy_func when
        /// creating the #GTree, the old value is freed using that function. If you
        /// supplied a @key_destroy_func when creating the #GTree, the old key is
        /// freed using that function.
        /// </summary>
        /// <remarks>
        /// The tree is automatically 'balanced' as new key/value pairs are added,
        /// so that the distance from the root to every leaf is as small as possible.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="key">
        /// the key to insert
        /// </param>
        /// <param name="value">
        /// the value corresponding to the key
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_tree_replace( System.IntPtr tree,  System.IntPtr key,  System.IntPtr value);

        /// <summary>
        /// Inserts a new key and value into a #GTree similar to g_tree_insert().
        /// The difference is that if the key already exists in the #GTree, it gets
        /// replaced by the new key. If you supplied a @value_destroy_func when
        /// creating the #GTree, the old value is freed using that function. If you
        /// supplied a @key_destroy_func when creating the #GTree, the old key is
        /// freed using that function.
        /// </summary>
        /// <remarks>
        /// The tree is automatically 'balanced' as new key/value pairs are added,
        /// so that the distance from the root to every leaf is as small as possible.
        /// </remarks>
        /// <param name="key">
        /// the key to insert
        /// </param>
        /// <param name="value">
        /// the value corresponding to the key
        /// </param>
        public System.Void Replace( System.IntPtr key,  System.IntPtr value)
        {
            var ret = g_tree_replace(Handle, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Searches a #GTree using @search_func.
        /// </summary>
        /// <remarks>
        /// The @search_func is called with a pointer to the key of a key/value
        /// pair in the tree, and the passed in @user_data. If @search_func returns
        /// 0 for a key/value pair, then the corresponding value is returned as
        /// the result of g_tree_search(). If @search_func returns -1, searching
        /// will proceed among the key/value pairs that have a smaller key; if
        /// @search_func returns 1, searching will proceed among the key/value
        /// pairs that have a larger key.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="searchFunc">
        /// a function used to search the #GTree
        /// </param>
        /// <param name="userData">
        /// the data passed as the second argument to @search_func
        /// </param>
        /// <returns>
        /// the value corresponding to the found key, or %NULL
        ///     if the key was not found
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_tree_search( System.IntPtr tree,  System.IntPtr searchFunc,  System.IntPtr userData);

        /// <summary>
        /// Searches a #GTree using @search_func.
        /// </summary>
        /// <remarks>
        /// The @search_func is called with a pointer to the key of a key/value
        /// pair in the tree, and the passed in @user_data. If @search_func returns
        /// 0 for a key/value pair, then the corresponding value is returned as
        /// the result of g_tree_search(). If @search_func returns -1, searching
        /// will proceed among the key/value pairs that have a smaller key; if
        /// @search_func returns 1, searching will proceed among the key/value
        /// pairs that have a larger key.
        /// </remarks>
        /// <param name="searchFunc">
        /// a function used to search the #GTree
        /// </param>
        /// <returns>
        /// the value corresponding to the found key, or %NULL
        ///     if the key was not found
        /// </returns>
        public System.IntPtr Search( GISharp.Core.CompareFunc`1[GISharp.GLib.Tree]searchFunc)
        {
            if (searchFunc == null)
            {
                throw new ArgumentNullException("searchFunc");
            }
            var ret = g_tree_search(Handle, searchFunc, userData);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Removes a key and its associated value from a #GTree without calling
        /// the key and value destroy functions.
        /// </summary>
        /// <remarks>
        /// If the key does not exist in the #GTree, the function does nothing.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found (prior to 2.8, this function
        ///     returned nothing)
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_tree_steal( System.IntPtr tree,  System.IntPtr key);

        /// <summary>
        /// Removes a key and its associated value from a #GTree without calling
        /// the key and value destroy functions.
        /// </summary>
        /// <remarks>
        /// If the key does not exist in the #GTree, the function does nothing.
        /// </remarks>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found (prior to 2.8, this function
        ///     returned nothing)
        /// </returns>
        public System.Boolean Steal( System.IntPtr key)
        {
            var ret = g_tree_steal(Handle, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Calls the given function for each node in the #GTree.
        /// </summary>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        /// <param name="traverseFunc">
        /// the function to call for each node visited. If this
        ///   function returns %TRUE, the traversal is stopped.
        /// </param>
        /// <param name="traverseType">
        /// the order in which nodes are visited, one of %G_IN_ORDER,
        ///   %G_PRE_ORDER and %G_POST_ORDER
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_tree_traverse( System.IntPtr tree,  System.IntPtr traverseFunc,  System.IntPtr traverseType,  System.IntPtr userData);

        /// <summary>
        /// Calls the given function for each node in the #GTree.
        /// </summary>
        /// <param name="traverseFunc">
        /// the function to call for each node visited. If this
        ///   function returns %TRUE, the traversal is stopped.
        /// </param>
        /// <param name="traverseType">
        /// the order in which nodes are visited, one of %G_IN_ORDER,
        ///   %G_PRE_ORDER and %G_POST_ORDER
        /// </param>
        [Obsolete("The order of a balanced tree is somewhat arbitrary.\n    If you just want to visit all nodes in sorted order, use\n    g_tree_foreach() instead. If you really need to visit nodes in\n    a different order, consider using an [n-ary tree][glib-N-ary-Trees].")]
        public System.Void Traverse( GISharp.GLib.TraverseFunc traverseFunc,  GISharp.GLib.TraverseType traverseType)
        {
            if (traverseFunc == null)
            {
                throw new ArgumentNullException("traverseFunc");
            }
            var ret = g_tree_traverse(Handle, traverseFunc, traverseType, userData);
            return default(System.Void);
        }

        /// <summary>
        /// Decrements the reference count of @tree by one.
        /// If the reference count drops to 0, all keys and values will
        /// be destroyed (if destroy functions were specified) and all
        /// memory allocated by @tree will be released.
        /// </summary>
        /// <remarks>
        /// It is safe to call this function from any thread.
        /// </remarks>
        /// <param name="tree">
        /// a #GTree
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_tree_unref( System.IntPtr tree);

        /// <summary>
        /// Decrements the reference count of @tree by one.
        /// If the reference count drops to 0, all keys and values will
        /// be destroyed (if destroy functions were specified) and all
        /// memory allocated by @tree will be released.
        /// </summary>
        /// <remarks>
        /// It is safe to call this function from any thread.
        /// </remarks>
        [GISharp.Core.Since("2.22")]
        protected override System.Void Unref()
        {
            var ret = g_tree_unref(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Creates a new #GTree.
        /// </summary>
        /// <param name="keyCompareFunc">
        /// the function used to order the nodes in the #GTree.
        ///   It should return values similar to the standard strcmp() function -
        ///   0 if the two arguments are equal, a negative value if the first argument
        ///   comes before the second, or a positive value if the first argument comes
        ///   after the second.
        /// </param>
        /// <returns>
        /// a newly allocated #GTree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_tree_new( System.IntPtr keyCompareFunc);

        /// <summary>
        /// Creates a new #GTree.
        /// </summary>
        /// <param name="keyCompareFunc">
        /// the function used to order the nodes in the #GTree.
        ///   It should return values similar to the standard strcmp() function -
        ///   0 if the two arguments are equal, a negative value if the first argument
        ///   comes before the second, or a positive value if the first argument comes
        ///   after the second.
        /// </param>
        /// <returns>
        /// a newly allocated #GTree
        /// </returns>
        public static GISharp.GLib.Tree New( GISharp.Core.CompareFunc`1[GISharp.GLib.Tree]keyCompareFunc)
        {
            if (keyCompareFunc == null)
            {
                throw new ArgumentNullException("keyCompareFunc");
            }
            var ret = g_tree_new(keyCompareFunc);
            return default(GISharp.GLib.Tree);
        }

        /// <summary>
        /// Creates a new #GTree like g_tree_new() and allows to specify functions
        /// to free the memory allocated for the key and value that get called when
        /// removing the entry from the #GTree.
        /// </summary>
        /// <param name="keyCompareFunc">
        /// qsort()-style comparison function
        /// </param>
        /// <param name="keyCompareData">
        /// data to pass to comparison function
        /// </param>
        /// <param name="keyDestroyFunc">
        /// a function to free the memory allocated for the key
        ///   used when removing the entry from the #GTree or %NULL if you don't
        ///   want to supply such a function
        /// </param>
        /// <param name="valueDestroyFunc">
        /// a function to free the memory allocated for the
        ///   value used when removing the entry from the #GTree or %NULL if you
        ///   don't want to supply such a function
        /// </param>
        /// <returns>
        /// a newly allocated #GTree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_tree_new_full( System.IntPtr keyCompareFunc,  System.IntPtr keyCompareData,  System.IntPtr keyDestroyFunc,  System.IntPtr valueDestroyFunc);

        /// <summary>
        /// Creates a new #GTree like g_tree_new() and allows to specify functions
        /// to free the memory allocated for the key and value that get called when
        /// removing the entry from the #GTree.
        /// </summary>
        /// <param name="keyCompareFunc">
        /// qsort()-style comparison function
        /// </param>
        /// <param name="keyDestroyFunc">
        /// a function to free the memory allocated for the key
        ///   used when removing the entry from the #GTree or %NULL if you don't
        ///   want to supply such a function
        /// </param>
        /// <returns>
        /// a newly allocated #GTree
        /// </returns>
        public static GISharp.GLib.Tree NewFull( GISharp.Core.CompareFunc`1[GISharp.GLib.Tree]keyCompareFunc,  GISharp.Core.DestroyNotify`1[GISharp.GLib.Tree]keyDestroyFunc)
        {
            if (keyCompareFunc == null)
            {
                throw new ArgumentNullException("keyCompareFunc");
            }
            if (keyDestroyFunc == null)
            {
                throw new ArgumentNullException("keyDestroyFunc");
            }
            var ret = g_tree_new_full(keyCompareFunc, keyCompareData, keyDestroyFunc, valueDestroyFunc);
            return default(GISharp.GLib.Tree);
        }

        /// <summary>
        /// Creates a new #GTree with a comparison function that accepts user data.
        /// See g_tree_new() for more details.
        /// </summary>
        /// <param name="keyCompareFunc">
        /// qsort()-style comparison function
        /// </param>
        /// <param name="keyCompareData">
        /// data to pass to comparison function
        /// </param>
        /// <returns>
        /// a newly allocated #GTree
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_tree_new_with_data( System.IntPtr keyCompareFunc,  System.IntPtr keyCompareData);

        /// <summary>
        /// Creates a new #GTree with a comparison function that accepts user data.
        /// See g_tree_new() for more details.
        /// </summary>
        /// <param name="keyCompareFunc">
        /// qsort()-style comparison function
        /// </param>
        /// <returns>
        /// a newly allocated #GTree
        /// </returns>
        public static GISharp.GLib.Tree NewWithData( GISharp.Core.CompareFunc`1[GISharp.GLib.Tree]keyCompareFunc)
        {
            if (keyCompareFunc == null)
            {
                throw new ArgumentNullException("keyCompareFunc");
            }
            var ret = g_tree_new_with_data(keyCompareFunc, keyCompareData);
            return default(GISharp.GLib.Tree);
        }
    }

    /// <summary>
    /// #GVariant is a variant datatype; it stores a value along with
    /// information about the type of that value.  The range of possible
    /// values is determined by the type.  The type system used by #GVariant
    /// is #GVariantType.
    /// </summary>
    /// <remarks>
    /// #GVariant instances always have a type and a value (which are given
    /// at construction time).  The type and value of a #GVariant instance
    /// can never change other than by the #GVariant itself being
    /// destroyed.  A #GVariant cannot contain a pointer.
    /// 
    /// #GVariant is reference counted using g_variant_ref() and
    /// g_variant_unref().  #GVariant also has floating reference counts --
    /// see g_variant_ref_sink().
    /// 
    /// #GVariant is completely threadsafe.  A #GVariant instance can be
    /// concurrently accessed in any way from any number of threads without
    /// problems.
    /// 
    /// #GVariant is heavily optimised for dealing with data in serialised
    /// form.  It works particularly well with data located in memory-mapped
    /// files.  It can perform nearly all deserialisation operations in a
    /// small constant time, usually touching only a single memory page.
    /// Serialised #GVariant data can also be sent over the network.
    /// 
    /// #GVariant is largely compatible with D-Bus.  Almost all types of
    /// #GVariant instances can be sent over D-Bus.  See #GVariantType for
    /// exceptions.  (However, #GVariant's serialisation format is not the same
    /// as the serialisation format of a D-Bus message body: use #GDBusMessage,
    /// in the gio library, for those.)
    /// 
    /// For space-efficiency, the #GVariant serialisation format does not
    /// automatically include the variant's length, type or endianness,
    /// which must either be implied from context (such as knowledge that a
    /// particular file format always contains a little-endian
    /// %G_VARIANT_TYPE_VARIANT which occupies the whole length of the file)
    /// or supplied out-of-band (for instance, a length, type and/or endianness
    /// indicator could be placed at the beginning of a file, network message
    /// or network stream).
    /// 
    /// A #GVariant's size is limited mainly by any lower level operating
    /// system constraints, such as the number of bits in #gsize.  For
    /// example, it is reasonable to have a 2GB file mapped into memory
    /// with #GMappedFile, and call g_variant_new_from_data() on it.
    /// 
    /// For convenience to C programmers, #GVariant features powerful
    /// varargs-based value construction and destruction.  This feature is
    /// designed to be embedded in other libraries.
    /// 
    /// There is a Python-inspired text language for describing #GVariant
    /// values.  #GVariant includes a printer for this language and a parser
    /// with type inferencing.
    /// 
    /// ## Memory Use
    /// 
    /// #GVariant tries to be quite efficient with respect to memory use.
    /// This section gives a rough idea of how much memory is used by the
    /// current implementation.  The information here is subject to change
    /// in the future.
    /// 
    /// The memory allocated by #GVariant can be grouped into 4 broad
    /// purposes: memory for serialised data, memory for the type
    /// information cache, buffer management memory and memory for the
    /// #GVariant structure itself.
    /// 
    /// ## Serialised Data Memory
    /// 
    /// This is the memory that is used for storing GVariant data in
    /// serialised form.  This is what would be sent over the network or
    /// what would end up on disk, not counting any indicator of the
    /// endianness, or of the length or type of the top-level variant.
    /// 
    /// The amount of memory required to store a boolean is 1 byte. 16,
    /// 32 and 64 bit integers and double precision floating point numbers
    /// use their "natural" size.  Strings (including object path and
    /// signature strings) are stored with a nul terminator, and as such
    /// use the length of the string plus 1 byte.
    /// 
    /// Maybe types use no space at all to represent the null value and
    /// use the same amount of space (sometimes plus one byte) as the
    /// equivalent non-maybe-typed value to represent the non-null case.
    /// 
    /// Arrays use the amount of space required to store each of their
    /// members, concatenated.  Additionally, if the items stored in an
    /// array are not of a fixed-size (ie: strings, other arrays, etc)
    /// then an additional framing offset is stored for each item.  The
    /// size of this offset is either 1, 2 or 4 bytes depending on the
    /// overall size of the container.  Additionally, extra padding bytes
    /// are added as required for alignment of child values.
    /// 
    /// Tuples (including dictionary entries) use the amount of space
    /// required to store each of their members, concatenated, plus one
    /// framing offset (as per arrays) for each non-fixed-sized item in
    /// the tuple, except for the last one.  Additionally, extra padding
    /// bytes are added as required for alignment of child values.
    /// 
    /// Variants use the same amount of space as the item inside of the
    /// variant, plus 1 byte, plus the length of the type string for the
    /// item inside the variant.
    /// 
    /// As an example, consider a dictionary mapping strings to variants.
    /// In the case that the dictionary is empty, 0 bytes are required for
    /// the serialisation.
    /// 
    /// If we add an item "width" that maps to the int32 value of 500 then
    /// we will use 4 byte to store the int32 (so 6 for the variant
    /// containing it) and 6 bytes for the string.  The variant must be
    /// aligned to 8 after the 6 bytes of the string, so that's 2 extra
    /// bytes.  6 (string) + 2 (padding) + 6 (variant) is 14 bytes used
    /// for the dictionary entry.  An additional 1 byte is added to the
    /// array as a framing offset making a total of 15 bytes.
    /// 
    /// If we add another entry, "title" that maps to a nullable string
    /// that happens to have a value of null, then we use 0 bytes for the
    /// null value (and 3 bytes for the variant to contain it along with
    /// its type string) plus 6 bytes for the string.  Again, we need 2
    /// padding bytes.  That makes a total of 6 + 2 + 3 = 11 bytes.
    /// 
    /// We now require extra padding between the two items in the array.
    /// After the 14 bytes of the first item, that's 2 bytes required.
    /// We now require 2 framing offsets for an extra two
    /// bytes. 14 + 2 + 11 + 2 = 29 bytes to encode the entire two-item
    /// dictionary.
    /// 
    /// ## Type Information Cache
    /// 
    /// For each GVariant type that currently exists in the program a type
    /// information structure is kept in the type information cache.  The
    /// type information structure is required for rapid deserialisation.
    /// 
    /// Continuing with the above example, if a #GVariant exists with the
    /// type "a{sv}" then a type information struct will exist for
    /// "a{sv}", "{sv}", "s", and "v".  Multiple uses of the same type
    /// will share the same type information.  Additionally, all
    /// single-digit types are stored in read-only static memory and do
    /// not contribute to the writable memory footprint of a program using
    /// #GVariant.
    /// 
    /// Aside from the type information structures stored in read-only
    /// memory, there are two forms of type information.  One is used for
    /// container types where there is a single element type: arrays and
    /// maybe types.  The other is used for container types where there
    /// are multiple element types: tuples and dictionary entries.
    /// 
    /// Array type info structures are 6 * sizeof (void *), plus the
    /// memory required to store the type string itself.  This means that
    /// on 32-bit systems, the cache entry for "a{sv}" would require 30
    /// bytes of memory (plus malloc overhead).
    /// 
    /// Tuple type info structures are 6 * sizeof (void *), plus 4 *
    /// sizeof (void *) for each item in the tuple, plus the memory
    /// required to store the type string itself.  A 2-item tuple, for
    /// example, would have a type information structure that consumed
    /// writable memory in the size of 14 * sizeof (void *) (plus type
    /// string)  This means that on 32-bit systems, the cache entry for
    /// "{sv}" would require 61 bytes of memory (plus malloc overhead).
    /// 
    /// This means that in total, for our "a{sv}" example, 91 bytes of
    /// type information would be allocated.
    /// 
    /// The type information cache, additionally, uses a #GHashTable to
    /// store and lookup the cached items and stores a pointer to this
    /// hash table in static storage.  The hash table is freed when there
    /// are zero items in the type cache.
    /// 
    /// Although these sizes may seem large it is important to remember
    /// that a program will probably only have a very small number of
    /// different types of values in it and that only one type information
    /// structure is required for many different values of the same type.
    /// 
    /// ## Buffer Management Memory
    /// 
    /// #GVariant uses an internal buffer management structure to deal
    /// with the various different possible sources of serialised data
    /// that it uses.  The buffer is responsible for ensuring that the
    /// correct call is made when the data is no longer in use by
    /// #GVariant.  This may involve a g_free() or a g_slice_free() or
    /// even g_mapped_file_unref().
    /// 
    /// One buffer management structure is used for each chunk of
    /// serialised data.  The size of the buffer management structure
    /// is 4 * (void *).  On 32-bit systems, that's 16 bytes.
    /// 
    /// ## GVariant structure
    /// 
    /// The size of a #GVariant structure is 6 * (void *).  On 32-bit
    /// systems, that's 24 bytes.
    /// 
    /// #GVariant structures only exist if they are explicitly created
    /// with API calls.  For example, if a #GVariant is constructed out of
    /// serialised data for the example given above (with the dictionary)
    /// then although there are 9 individual values that comprise the
    /// entire dictionary (two keys, two values, two variants containing
    /// the values, two dictionary entries, plus the dictionary itself),
    /// only 1 #GVariant instance exists -- the one referring to the
    /// dictionary.
    /// 
    /// If calls are made to start accessing the other values then
    /// #GVariant instances will exist for those values only for as long
    /// as they are in use (ie: until you call g_variant_unref()).  The
    /// type information is shared.  The serialised data and the buffer
    /// management structure for that serialised data is shared by the
    /// child.
    /// 
    /// ## Summary
    /// 
    /// To put the entire example together, for our dictionary mapping
    /// strings to variants (with two entries, as given above), we are
    /// using 91 bytes of memory for type information, 29 byes of memory
    /// for the serialised data, 16 bytes for buffer management and 24
    /// bytes for the #GVariant instance, or a total of 160 bytes, plus
    /// malloc overhead.  If we were to use g_variant_get_child_value() to
    /// access the two dictionary entries, we would use an additional 48
    /// bytes.  If we were to have other dictionaries of the same type, we
    /// would use more memory for the serialised data and buffer
    /// management for those dictionaries, but the type information would
    /// be shared.
    /// </remarks>
    [GISharp.Core.Since("2.24")]
    public partial class Variant : GISharp.Core.ReferenceCountedOpaque<Variant>, IComparable<Variant>
    {
        public Variant(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GVariant array from @children.
        /// </summary>
        /// <remarks>
        /// @child_type must be non-%NULL if @n_children is zero.  Otherwise, the
        /// child type is determined by inspecting the first element of the
        /// @children array.  If @child_type is non-%NULL then it must be a
        /// definite type.
        /// 
        /// The items of the array are taken from the @children array.  No entry
        /// in the @children array may be %NULL.
        /// 
        /// All items in the array must have the same type, which must be the
        /// same as @child_type, if given.
        /// 
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="childType">
        /// the element type of the new array
        /// </param>
        /// <param name="children">
        /// an array of
        ///            #GVariant pointers, the children
        /// </param>
        /// <param name="nChildren">
        /// the length of @children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant array
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_array( System.IntPtr childType,  System.IntPtr[] children,  System.UInt64 nChildren);

        /// <summary>
        /// Creates a new #GVariant array from @children.
        /// </summary>
        /// <remarks>
        /// @child_type must be non-%NULL if @n_children is zero.  Otherwise, the
        /// child type is determined by inspecting the first element of the
        /// @children array.  If @child_type is non-%NULL then it must be a
        /// definite type.
        /// 
        /// The items of the array are taken from the @children array.  No entry
        /// in the @children array may be %NULL.
        /// 
        /// All items in the array must have the same type, which must be the
        /// same as @child_type, if given.
        /// 
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="childType">
        /// the element type of the new array
        /// </param>
        /// <param name="children">
        /// an array of
        ///            #GVariant pointers, the children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant array
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( GISharp.GLib.VariantType childType,  GISharp.GLib.Variant[] children) : base(IntPtr.Zero)
        {
            var nChildren = (System.UInt64)children.Length;
            var ret = g_variant_new_array(childType, children, nChildren);
        }

        /// <summary>
        /// Creates a new boolean #GVariant instance -- either %TRUE or %FALSE.
        /// </summary>
        /// <param name="value">
        /// a #gboolean value
        /// </param>
        /// <returns>
        /// a floating reference to a new boolean #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_boolean( System.Boolean value);

        /// <summary>
        /// Creates a new boolean #GVariant instance -- either %TRUE or %FALSE.
        /// </summary>
        /// <param name="value">
        /// a #gboolean value
        /// </param>
        /// <returns>
        /// a floating reference to a new boolean #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.Boolean value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_boolean(value);
        }

        /// <summary>
        /// Creates a new byte #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint8 value
        /// </param>
        /// <returns>
        /// a floating reference to a new byte #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_byte( System.Byte value);

        /// <summary>
        /// Creates a new byte #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint8 value
        /// </param>
        /// <returns>
        /// a floating reference to a new byte #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.Byte value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_byte(value);
        }

        /// <summary>
        /// Creates an array-of-bytes #GVariant with the contents of @string.
        /// This function is just like g_variant_new_string() except that the
        /// string need not be valid utf8.
        /// </summary>
        /// <remarks>
        /// The nul terminator character at the end of the string is stored in
        /// the array.
        /// </remarks>
        /// <param name="string">
        /// a normal
        ///          nul-terminated string in no particular encoding
        /// </param>
        /// <returns>
        /// a floating reference to a new bytestring #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_bytestring( System.Byte[] @string);

        /// <summary>
        /// Creates an array-of-bytes #GVariant with the contents of @string.
        /// This function is just like g_variant_new_string() except that the
        /// string need not be valid utf8.
        /// </summary>
        /// <remarks>
        /// The nul terminator character at the end of the string is stored in
        /// the array.
        /// </remarks>
        /// <param name="string">
        /// a normal
        ///          nul-terminated string in no particular encoding
        /// </param>
        /// <returns>
        /// a floating reference to a new bytestring #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public Variant( System.Byte[] @string) : base(IntPtr.Zero)
        {
            if (@string == null)
            {
                throw new ArgumentNullException("@string");
            }
            var ret = g_variant_new_bytestring(@string);
        }

        /// <summary>
        /// Constructs an array of bytestring #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_bytestring_array( System.IntPtr strv,  System.Int64 length);

        /// <summary>
        /// Creates a new dictionary entry #GVariant. @key and @value must be
        /// non-%NULL. @key must be a value of a basic type (ie: not a container).
        /// </summary>
        /// <remarks>
        /// If the @key or @value are floating references (see g_variant_ref_sink()),
        /// the new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariant, the key
        /// </param>
        /// <param name="value">
        /// a #GVariant, the value
        /// </param>
        /// <returns>
        /// a floating reference to a new dictionary entry #GVariant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_dict_entry( System.IntPtr key,  System.IntPtr value);

        /// <summary>
        /// Creates a new dictionary entry #GVariant. @key and @value must be
        /// non-%NULL. @key must be a value of a basic type (ie: not a container).
        /// </summary>
        /// <remarks>
        /// If the @key or @value are floating references (see g_variant_ref_sink()),
        /// the new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariant, the key
        /// </param>
        /// <param name="value">
        /// a #GVariant, the value
        /// </param>
        /// <returns>
        /// a floating reference to a new dictionary entry #GVariant
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( GISharp.GLib.Variant key,  GISharp.GLib.Variant value) : base(IntPtr.Zero)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_variant_new_dict_entry(key, value);
        }

        /// <summary>
        /// Creates a new double #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gdouble floating point value
        /// </param>
        /// <returns>
        /// a floating reference to a new double #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_double( System.Double value);

        /// <summary>
        /// Creates a new double #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gdouble floating point value
        /// </param>
        /// <returns>
        /// a floating reference to a new double #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.Double value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_double(value);
        }

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array.
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementType">
        /// the #GVariantType of each element
        /// </param>
        /// <param name="elements">
        /// a pointer to the fixed array of contiguous elements
        /// </param>
        /// <param name="nElements">
        /// the number of elements
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a floating reference to a new array #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_fixed_array( System.IntPtr elementType,  System.IntPtr elements,  System.UInt64 nElements,  System.UInt64 elementSize);

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array.
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementType">
        /// the #GVariantType of each element
        /// </param>
        /// <param name="elements">
        /// a pointer to the fixed array of contiguous elements
        /// </param>
        /// <param name="nElements">
        /// the number of elements
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a floating reference to a new array #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.32")]
        public Variant( GISharp.GLib.VariantType elementType,  System.IntPtr elements,  System.UInt64 nElements,  System.UInt64 elementSize) : base(IntPtr.Zero)
        {
            if (elementType == null)
            {
                throw new ArgumentNullException("elementType");
            }
            var ret = g_variant_new_fixed_array(elementType, elements, nElements, elementSize);
        }

        /// <summary>
        /// Constructs a new serialised-mode #GVariant instance.  This is the
        /// inner interface for creation of new serialised values that gets
        /// called from various functions in gvariant.c.
        /// </summary>
        /// <remarks>
        /// A reference is taken on @bytes.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="trusted">
        /// if the contents of @bytes are trusted
        /// </param>
        /// <returns>
        /// a new #GVariant with a floating reference
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_from_bytes( System.IntPtr type,  System.IntPtr bytes,  System.Boolean trusted);

        /// <summary>
        /// Constructs a new serialised-mode #GVariant instance.  This is the
        /// inner interface for creation of new serialised values that gets
        /// called from various functions in gvariant.c.
        /// </summary>
        /// <remarks>
        /// A reference is taken on @bytes.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="trusted">
        /// if the contents of @bytes are trusted
        /// </param>
        /// <returns>
        /// a new #GVariant with a floating reference
        /// </returns>
        [GISharp.Core.Since("2.36")]
        public Variant( GISharp.GLib.VariantType type,  GISharp.GLib.Bytes bytes,  System.Boolean trusted) : base(IntPtr.Zero)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            var ret = g_variant_new_from_bytes(type, bytes, trusted);
        }

        /// <summary>
        /// Creates a new #GVariant instance from serialised data.
        /// </summary>
        /// <remarks>
        /// @type is the type of #GVariant instance that will be constructed.
        /// The interpretation of @data depends on knowing the type.
        /// 
        /// @data is not modified by this function and must remain valid with an
        /// unchanging value until such a time as @notify is called with
        /// @user_data.  If the contents of @data change before that time then
        /// the result is undefined.
        /// 
        /// If @data is trusted to be serialised data in normal form then
        /// @trusted should be %TRUE.  This applies to serialised data created
        /// within this process or read from a trusted location on the disk (such
        /// as a file installed in /usr/lib alongside your application).  You
        /// should set trusted to %FALSE if @data is read from the network, a
        /// file in the user's home directory, etc.
        /// 
        /// If @data was not stored in this machine's native endianness, any multi-byte
        /// numeric values in the returned variant will also be in non-native
        /// endianness. g_variant_byteswap() can be used to recover the original values.
        /// 
        /// @notify will be called with @user_data when @data is no longer
        /// needed.  The exact time of this call is unspecified and might even be
        /// before this function returns.
        /// </remarks>
        /// <param name="type">
        /// a definite #GVariantType
        /// </param>
        /// <param name="data">
        /// the serialised data
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <param name="trusted">
        /// %TRUE if @data is definitely in normal form
        /// </param>
        /// <param name="notify">
        /// function to call when @data is no longer needed
        /// </param>
        /// <param name="userData">
        /// data for @notify
        /// </param>
        /// <returns>
        /// a new floating #GVariant of type @type
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_from_data( System.IntPtr type,  System.Byte[] data,  System.UInt64 size,  System.Boolean trusted,  System.IntPtr notify,  System.IntPtr userData);

        /// <summary>
        /// Creates a new handle #GVariant instance.
        /// </summary>
        /// <remarks>
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new handle #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_handle( System.Int32 value);

        /// <summary>
        /// Creates a new int16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int16 #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_int16( System.Int16 value);

        /// <summary>
        /// Creates a new int16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int16 #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.Int16 value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_int16(value);
        }

        /// <summary>
        /// Creates a new int32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int32 #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_int32( System.Int32 value);

        /// <summary>
        /// Creates a new int32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int32 #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.Int32 value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_int32(value);
        }

        /// <summary>
        /// Creates a new int64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int64 #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_int64( System.Int64 value);

        /// <summary>
        /// Creates a new int64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int64 #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.Int64 value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_int64(value);
        }

        /// <summary>
        /// Depending on if @child is %NULL, either wraps @child inside of a
        /// maybe container or creates a Nothing instance for the given @type.
        /// </summary>
        /// <remarks>
        /// At least one of @child_type and @child must be non-%NULL.
        /// If @child_type is non-%NULL then it must be a definite type.
        /// If they are both non-%NULL then @child_type must be the type
        /// of @child.
        /// 
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="childType">
        /// the #GVariantType of the child, or %NULL
        /// </param>
        /// <param name="child">
        /// the child value, or %NULL
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant maybe instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_maybe( System.IntPtr childType,  System.IntPtr child);

        /// <summary>
        /// Depending on if @child is %NULL, either wraps @child inside of a
        /// maybe container or creates a Nothing instance for the given @type.
        /// </summary>
        /// <remarks>
        /// At least one of @child_type and @child must be non-%NULL.
        /// If @child_type is non-%NULL then it must be a definite type.
        /// If they are both non-%NULL then @child_type must be the type
        /// of @child.
        /// 
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="childType">
        /// the #GVariantType of the child, or %NULL
        /// </param>
        /// <param name="child">
        /// the child value, or %NULL
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant maybe instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( GISharp.GLib.VariantType childType,  GISharp.GLib.Variant child) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_maybe(childType, child);
        }

        /// <summary>
        /// Creates a D-Bus object path #GVariant with the contents of @string.
        /// @string must be a valid D-Bus object path.  Use
        /// g_variant_is_object_path() if you're not sure.
        /// </summary>
        /// <param name="objectPath">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new object path #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_object_path( System.IntPtr objectPath);

        /// <summary>
        /// Constructs an array of object paths #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// Each string must be a valid #GVariant object path; see
        /// g_variant_is_object_path().
        /// 
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_objv( System.IntPtr strv,  System.Int64 length);

        /// <summary>
        /// Parses @format and returns the result.
        /// </summary>
        /// <remarks>
        /// This is the version of g_variant_new_parsed() intended to be used
        /// from libraries.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance.  In the case that @format simply specified the collection
        /// of a #GVariant pointer (eg: @format was "%*") then the collected
        /// #GVariant pointer will be returned unmodified, without adding any
        /// additional references.
        /// 
        /// Note that the arguments in @app must be of the correct width for their types
        /// specified in @format when collected into the #va_list. See
        /// the [GVariant varargs documentation][gvariant-varargs].
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="format">
        /// a text format #GVariant
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_parsed_va( System.IntPtr format,  System.IntPtr app);

        /// <summary>
        /// Parses @format and returns the result.
        /// </summary>
        /// <remarks>
        /// This is the version of g_variant_new_parsed() intended to be used
        /// from libraries.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance.  In the case that @format simply specified the collection
        /// of a #GVariant pointer (eg: @format was "%*") then the collected
        /// #GVariant pointer will be returned unmodified, without adding any
        /// additional references.
        /// 
        /// Note that the arguments in @app must be of the correct width for their types
        /// specified in @format when collected into the #va_list. See
        /// the [GVariant varargs documentation][gvariant-varargs].
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="format">
        /// a text format #GVariant
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        public Variant( System.String format,  System.Object[] app) : base(IntPtr.Zero)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            var ret = g_variant_new_parsed_va(format, app);
        }

        /// <summary>
        /// Creates a D-Bus type signature #GVariant with the contents of
        /// @string.  @string must be a valid D-Bus type signature.  Use
        /// g_variant_is_signature() if you're not sure.
        /// </summary>
        /// <param name="signature">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new signature #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_signature( System.IntPtr signature);

        /// <summary>
        /// Constructs an array of strings #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_strv( System.IntPtr[] strv,  System.Int64 length);

        /// <summary>
        /// Constructs an array of strings #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.String[] strv) : base(IntPtr.Zero)
        {
            if (strv == null)
            {
                throw new ArgumentNullException("strv");
            }
            var length = (System.Int64)strv.Length;
            var ret = g_variant_new_strv(strv, length);
        }

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid utf8.
        /// 
        /// This function consumes @string.  g_free() will be called on @string
        /// when it is no longer required.
        /// 
        /// You must not modify or access @string in any other way after passing
        /// it to this function.  It is even possible that @string is immediately
        /// freed.
        /// </remarks>
        /// <param name="string">
        /// a normal utf8 nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new string
        ///   #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_take_string( System.IntPtr @string);

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid utf8.
        /// 
        /// This function consumes @string.  g_free() will be called on @string
        /// when it is no longer required.
        /// 
        /// You must not modify or access @string in any other way after passing
        /// it to this function.  It is even possible that @string is immediately
        /// freed.
        /// </remarks>
        /// <param name="string">
        /// a normal utf8 nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new string
        ///   #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.38")]
        public Variant( System.String @string) : base(IntPtr.Zero)
        {
            if (@string == null)
            {
                throw new ArgumentNullException("@string");
            }
            var ret = g_variant_new_take_string(@string);
        }

        /// <summary>
        /// Creates a new tuple #GVariant out of the items in @children.  The
        /// type is determined from the types of @children.  No entry in the
        /// @children array may be %NULL.
        /// </summary>
        /// <remarks>
        /// If @n_children is 0 then the unit tuple is constructed.
        /// 
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="children">
        /// the items to make the tuple out of
        /// </param>
        /// <param name="nChildren">
        /// the length of @children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant tuple
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_tuple( System.IntPtr[] children,  System.UInt64 nChildren);

        /// <summary>
        /// Creates a new tuple #GVariant out of the items in @children.  The
        /// type is determined from the types of @children.  No entry in the
        /// @children array may be %NULL.
        /// </summary>
        /// <remarks>
        /// If @n_children is 0 then the unit tuple is constructed.
        /// 
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="children">
        /// the items to make the tuple out of
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant tuple
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( GISharp.GLib.Variant[] children) : base(IntPtr.Zero)
        {
            if (children == null)
            {
                throw new ArgumentNullException("children");
            }
            var nChildren = (System.UInt64)children.Length;
            var ret = g_variant_new_tuple(children, nChildren);
        }

        /// <summary>
        /// Creates a new uint16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint16 #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_uint16( System.UInt16 value);

        /// <summary>
        /// Creates a new uint16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint16 #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.UInt16 value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_uint16(value);
        }

        /// <summary>
        /// Creates a new uint32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint32 #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_uint32( System.UInt32 value);

        /// <summary>
        /// Creates a new uint32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint32 #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.UInt32 value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_uint32(value);
        }

        /// <summary>
        /// Creates a new uint64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint64 #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_uint64( System.UInt64 value);

        /// <summary>
        /// Creates a new uint64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint64 #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.UInt64 value) : base(IntPtr.Zero)
        {
            var ret = g_variant_new_uint64(value);
        }

        /// <summary>
        /// This function is intended to be used by libraries based on
        /// #GVariant that want to provide g_variant_new()-like functionality
        /// to their users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_new() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// needs to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// Note that the arguments in @app must be of the correct width for their
        /// types specified in @format_string when collected into the #va_list.
        /// See the [GVariant varargs documentation][gvariant-varargs.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance (for example, if the format string was "(ii)").  In the case
        /// that the format_string was '*', '?', 'r', or a format starting with
        /// '@' then the collected #GVariant pointer will be returned unmodified,
        /// without adding any additional references.
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_va( System.IntPtr formatString,  System.IntPtr endptr,  System.IntPtr app);

        /// <summary>
        /// This function is intended to be used by libraries based on
        /// #GVariant that want to provide g_variant_new()-like functionality
        /// to their users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_new() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// needs to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// Note that the arguments in @app must be of the correct width for their
        /// types specified in @format_string when collected into the #va_list.
        /// See the [GVariant varargs documentation][gvariant-varargs.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// The return value will be floating if it was a newly created GVariant
        /// instance (for example, if the format string was "(ii)").  In the case
        /// that the format_string was '*', '?', 'r', or a format starting with
        /// '@' then the collected #GVariant pointer will be returned unmodified,
        /// without adding any additional references.
        /// 
        /// In order to behave correctly in all cases it is necessary for the
        /// calling function to g_variant_ref_sink() the return result before
        /// returning control to the user that originally provided the pointer.
        /// At this point, the caller will have their own full reference to the
        /// result.  This can also be done by adding the result to a container,
        /// or by passing it to another g_variant_new() call.
        /// </remarks>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        /// <returns>
        /// a new, usually floating, #GVariant
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( System.String formatString,  System.String endptr,  System.Object[] app) : base(IntPtr.Zero)
        {
            if (formatString == null)
            {
                throw new ArgumentNullException("formatString");
            }
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            var ret = g_variant_new_va(formatString, endptr, app);
        }

        /// <summary>
        /// Boxes @value.  The result is a #GVariant instance representing a
        /// variant containing the original value.
        /// </summary>
        /// <remarks>
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// a floating reference to a new variant #GVariant instance
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_new_variant( System.IntPtr value);

        /// <summary>
        /// Boxes @value.  The result is a #GVariant instance representing a
        /// variant containing the original value.
        /// </summary>
        /// <remarks>
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// a floating reference to a new variant #GVariant instance
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public Variant( GISharp.GLib.Variant value) : base(IntPtr.Zero)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_variant_new_variant(value);
        }

        /// <summary>
        /// Performs a byteswapping operation on the contents of @value.  The
        /// result is that all multi-byte numeric data contained in @value is
        /// byteswapped.  That includes 16, 32, and 64bit signed and unsigned
        /// integers as well as file handles and double precision floating point
        /// values.
        /// </summary>
        /// <remarks>
        /// This function is an identity mapping on any value that does not
        /// contain multi-byte numeric data.  That include strings, booleans,
        /// bytes and containers containing only these things (recursively).
        /// 
        /// The returned value is always in normal form and is marked as trusted.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the byteswapped form of @value
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_byteswap( System.IntPtr value);

        /// <summary>
        /// Performs a byteswapping operation on the contents of @value.  The
        /// result is that all multi-byte numeric data contained in @value is
        /// byteswapped.  That includes 16, 32, and 64bit signed and unsigned
        /// integers as well as file handles and double precision floating point
        /// values.
        /// </summary>
        /// <remarks>
        /// This function is an identity mapping on any value that does not
        /// contain multi-byte numeric data.  That include strings, booleans,
        /// bytes and containers containing only these things (recursively).
        /// 
        /// The returned value is always in normal form and is marked as trusted.
        /// </remarks>
        /// <returns>
        /// the byteswapped form of @value
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.Variant Byteswap()
        {
            var ret = g_variant_byteswap(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Checks if calling g_variant_get() with @format_string on @value would
        /// be valid from a type-compatibility standpoint.  @format_string is
        /// assumed to be a valid format string (from a syntactic standpoint).
        /// </summary>
        /// <remarks>
        /// If @copy_only is %TRUE then this function additionally checks that it
        /// would be safe to call g_variant_unref() on @value immediately after
        /// the call to g_variant_get() without invalidating the result.  This is
        /// only possible if deep copies are made (ie: there are no pointers to
        /// the data inside of the soon-to-be-freed #GVariant instance).  If this
        /// check fails then a g_critical() is printed and %FALSE is returned.
        /// 
        /// This function is meant to be used by functions that wish to provide
        /// varargs accessors to #GVariant values of uncertain values (eg:
        /// g_variant_lookup() or g_menu_model_get_item_attribute()).
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="formatString">
        /// a valid #GVariant format string
        /// </param>
        /// <param name="copyOnly">
        /// %TRUE to ensure the format string makes deep copies
        /// </param>
        /// <returns>
        /// %TRUE if @format_string is safe to use
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_check_format_string( System.IntPtr value,  System.IntPtr formatString,  System.Boolean copyOnly);

        /// <summary>
        /// Checks if calling g_variant_get() with @format_string on @value would
        /// be valid from a type-compatibility standpoint.  @format_string is
        /// assumed to be a valid format string (from a syntactic standpoint).
        /// </summary>
        /// <remarks>
        /// If @copy_only is %TRUE then this function additionally checks that it
        /// would be safe to call g_variant_unref() on @value immediately after
        /// the call to g_variant_get() without invalidating the result.  This is
        /// only possible if deep copies are made (ie: there are no pointers to
        /// the data inside of the soon-to-be-freed #GVariant instance).  If this
        /// check fails then a g_critical() is printed and %FALSE is returned.
        /// 
        /// This function is meant to be used by functions that wish to provide
        /// varargs accessors to #GVariant values of uncertain values (eg:
        /// g_variant_lookup() or g_menu_model_get_item_attribute()).
        /// </remarks>
        /// <param name="formatString">
        /// a valid #GVariant format string
        /// </param>
        /// <param name="copyOnly">
        /// %TRUE to ensure the format string makes deep copies
        /// </param>
        /// <returns>
        /// %TRUE if @format_string is safe to use
        /// </returns>
        [GISharp.Core.Since("2.34")]
        public System.Boolean CheckFormatString( System.String formatString,  System.Boolean copyOnly)
        {
            if (formatString == null)
            {
                throw new ArgumentNullException("formatString");
            }
            var ret = g_variant_check_format_string(Handle, formatString, copyOnly);
            return default(System.Boolean);
        }

        /// <summary>
        /// Classifies @value according to its top-level type.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the #GVariantClass of @value
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_classify( System.IntPtr value);

        /// <summary>
        /// Classifies @value according to its top-level type.
        /// </summary>
        /// <returns>
        /// the #GVariantClass of @value
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.VariantClass Classify()
        {
            var ret = g_variant_classify(Handle);
            return default(GISharp.GLib.VariantClass);
        }

        /// <summary>
        /// Compares @one and @two.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GTree, #GPtrArray, etc.  They must each be a
        /// #GVariant.
        /// 
        /// Comparison is only defined for basic types (ie: booleans, numbers,
        /// strings).  For booleans, %FALSE is less than %TRUE.  Numbers are
        /// ordered in the usual way.  Strings are in ASCII lexographical order.
        /// 
        /// It is a programmer error to attempt to compare container values or
        /// two values that have types that are not exactly equal.  For example,
        /// you cannot compare a 32-bit signed integer with a 32-bit unsigned
        /// integer.  Also note that this function is not particularly
        /// well-behaved when it comes to comparison of doubles; in particular,
        /// the handling of incomparable values (ie: NaN) is undefined.
        /// 
        /// If you only require an equality comparison, g_variant_equal() is more
        /// general.
        /// </remarks>
        /// <param name="one">
        /// a basic-typed #GVariant instance
        /// </param>
        /// <param name="two">
        /// a #GVariant instance of the same type
        /// </param>
        /// <returns>
        /// negative value if a &lt; b;
        ///          zero if a = b;
        ///          positive value if a &gt; b.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_variant_compare( System.IntPtr one,  System.IntPtr two);

        /// <summary>
        /// Compares @one and @two.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GTree, #GPtrArray, etc.  They must each be a
        /// #GVariant.
        /// 
        /// Comparison is only defined for basic types (ie: booleans, numbers,
        /// strings).  For booleans, %FALSE is less than %TRUE.  Numbers are
        /// ordered in the usual way.  Strings are in ASCII lexographical order.
        /// 
        /// It is a programmer error to attempt to compare container values or
        /// two values that have types that are not exactly equal.  For example,
        /// you cannot compare a 32-bit signed integer with a 32-bit unsigned
        /// integer.  Also note that this function is not particularly
        /// well-behaved when it comes to comparison of doubles; in particular,
        /// the handling of incomparable values (ie: NaN) is undefined.
        /// 
        /// If you only require an equality comparison, g_variant_equal() is more
        /// general.
        /// </remarks>
        /// <param name="two">
        /// a #GVariant instance of the same type
        /// </param>
        /// <returns>
        /// negative value if a &lt; b;
        ///          zero if a = b;
        ///          positive value if a &gt; b.
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Int32 CompareTo( GISharp.GLib.Variant two)
        {
            if (two == null)
            {
                throw new ArgumentNullException("two");
            }
            var ret = g_variant_compare(Handle, two);
            return default(System.Int32);
        }

        public static bool operator <(Variant one, Variant two)
        {
            return one.CompareTo(two) < 0;
        }

        public static bool operator <=(Variant one, Variant two)
        {
            return one.CompareTo(two) <= 0;
        }

        public static bool operator >=(Variant one, Variant two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator >(Variant one, Variant two)
        {
            return one.CompareTo(two) > 0;
        }

        /// <summary>
        /// Checks if @one and @two have the same type and value.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GHashTable.  They must each be a #GVariant.
        /// </remarks>
        /// <param name="one">
        /// a #GVariant instance
        /// </param>
        /// <param name="two">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @one and @two are equal
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_equal( System.IntPtr one,  System.IntPtr two);

        /// <summary>
        /// Checks if @one and @two have the same type and value.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GHashTable.  They must each be a #GVariant.
        /// </remarks>
        /// <param name="two">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @one and @two are equal
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Boolean Equals( GISharp.GLib.Variant two)
        {
            if (two == null)
            {
                throw new ArgumentNullException("two");
            }
            var ret = g_variant_equal(Handle, two);
            return default(System.Boolean);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Variant);
        }

        public override int GetHashCode()
        {
            return (int)Hash();
        }

        public static bool operator ==(Variant one, Variant two)
        {
            if ((object)one == null)
            {
                return (object)two == null;
            }
            return one.Equals(two);
        }

        public static bool operator !=(Variant one, Variant two)
        {
            return !(one == two);
        }

        /// <summary>
        /// Returns the boolean value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BOOLEAN.
        /// </remarks>
        /// <param name="value">
        /// a boolean #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE or %FALSE
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_get_boolean( System.IntPtr value);

        /// <summary>
        /// Returns the boolean value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BOOLEAN.
        /// </remarks>
        /// <returns>
        /// %TRUE or %FALSE
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Boolean get_Boolean()
        {
            var ret = g_variant_get_boolean(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the byte value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BYTE.
        /// </remarks>
        /// <param name="value">
        /// a byte #GVariant instance
        /// </param>
        /// <returns>
        /// a #guchar
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Byte g_variant_get_byte( System.IntPtr value);

        /// <summary>
        /// Returns the byte value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BYTE.
        /// </remarks>
        /// <returns>
        /// a #guchar
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Byte get_Byte()
        {
            var ret = g_variant_get_byte(Handle);
            return default(System.Byte);
        }

        /// <summary>
        /// Returns the string value of a #GVariant instance with an
        /// array-of-bytes type.  The string has no particular encoding.
        /// </summary>
        /// <remarks>
        /// If the array does not end with a nul terminator character, the empty
        /// string is returned.  For this reason, you can always trust that a
        /// non-%NULL nul-terminated string will be returned by this function.
        /// 
        /// If the array contains a nul terminator character somewhere other than
        /// the last byte then the returned string is the string, up to the first
        /// such nul character.
        /// 
        /// It is an error to call this function with a @value that is not an
        /// array of bytes.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="value">
        /// an array-of-bytes #GVariant instance
        /// </param>
        /// <returns>
        /// 
        ///          the constant string
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Byte[] g_variant_get_bytestring( System.IntPtr value);

        /// <summary>
        /// Returns the string value of a #GVariant instance with an
        /// array-of-bytes type.  The string has no particular encoding.
        /// </summary>
        /// <remarks>
        /// If the array does not end with a nul terminator character, the empty
        /// string is returned.  For this reason, you can always trust that a
        /// non-%NULL nul-terminated string will be returned by this function.
        /// 
        /// If the array contains a nul terminator character somewhere other than
        /// the last byte then the returned string is the string, up to the first
        /// such nul character.
        /// 
        /// It is an error to call this function with a @value that is not an
        /// array of bytes.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <returns>
        /// 
        ///          the constant string
        /// </returns>
        [GISharp.Core.Since("2.26")]
        public System.Byte[] get_Bytestring()
        {
            var ret = g_variant_get_bytestring(Handle);
            return default(System.Byte[]);
        }

        /// <summary>
        /// Gets the contents of an array of array of bytes #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result is
        /// stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of array of bytes #GVariant ('aay')
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        static extern System.IntPtr g_variant_get_bytestring_array( System.IntPtr value, out System.UInt64 length);

        /// <summary>
        /// Reads a child item out of a container #GVariant instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// It is an error if @index_ is greater than the number of child items
        /// in the container.  See g_variant_n_children().
        /// 
        /// The returned value is never floating.  You should free it with
        /// g_variant_unref() when you're done with it.
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <param name="index">
        /// the index of the child to fetch
        /// </param>
        /// <returns>
        /// the child at the specified index
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_child_value( System.IntPtr value,  System.UInt64 index);

        /// <summary>
        /// Reads a child item out of a container #GVariant instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// It is an error if @index_ is greater than the number of child items
        /// in the container.  See g_variant_n_children().
        /// 
        /// The returned value is never floating.  You should free it with
        /// g_variant_unref() when you're done with it.
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <param name="index">
        /// the index of the child to fetch
        /// </param>
        /// <returns>
        /// the child at the specified index
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.Variant GetChildValue( System.UInt64 index)
        {
            var ret = g_variant_get_child_value(Handle, index);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The returned data may not be in fully-normalised form if read from an
        /// untrusted source.  The returned data must not be freed; it remains
        /// valid for as long as @value exists.
        /// </summary>
        /// <remarks>
        /// If @value is a fixed-sized value that was deserialised from a
        /// corrupted serialised container then %NULL may be returned.  In this
        /// case, the proper thing to do is typically to use the appropriate
        /// number of nul bytes in place of @value.  If @value is not fixed-sized
        /// then %NULL is never returned.
        /// 
        /// In the case that @value is already in serialised form, this function
        /// is O(1).  If the value is not already in serialised form,
        /// serialisation occurs implicitly and is approximately O(n) in the size
        /// of the result.
        /// 
        /// To deserialise the data returned by this function, in addition to the
        /// serialised data, you must know the type of the #GVariant, and (if the
        /// machine might be different) the endianness of the machine that stored
        /// it. As a result, file formats or network messages that incorporate
        /// serialised #GVariants must include this information either
        /// implicitly (for instance "the file always contains a
        /// %G_VARIANT_TYPE_VARIANT and it is always in little-endian order") or
        /// explicitly (by storing the type and/or endianness in addition to the
        /// serialised data).
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// the serialised form of @value, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_data( System.IntPtr value);

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The returned data may not be in fully-normalised form if read from an
        /// untrusted source.  The returned data must not be freed; it remains
        /// valid for as long as @value exists.
        /// </summary>
        /// <remarks>
        /// If @value is a fixed-sized value that was deserialised from a
        /// corrupted serialised container then %NULL may be returned.  In this
        /// case, the proper thing to do is typically to use the appropriate
        /// number of nul bytes in place of @value.  If @value is not fixed-sized
        /// then %NULL is never returned.
        /// 
        /// In the case that @value is already in serialised form, this function
        /// is O(1).  If the value is not already in serialised form,
        /// serialisation occurs implicitly and is approximately O(n) in the size
        /// of the result.
        /// 
        /// To deserialise the data returned by this function, in addition to the
        /// serialised data, you must know the type of the #GVariant, and (if the
        /// machine might be different) the endianness of the machine that stored
        /// it. As a result, file formats or network messages that incorporate
        /// serialised #GVariants must include this information either
        /// implicitly (for instance "the file always contains a
        /// %G_VARIANT_TYPE_VARIANT and it is always in little-endian order") or
        /// explicitly (by storing the type and/or endianness in addition to the
        /// serialised data).
        /// </remarks>
        /// <returns>
        /// the serialised form of @value, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.IntPtr get_Data()
        {
            var ret = g_variant_get_data(Handle);
            return default(System.IntPtr);
        }

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The semantics of this function are exactly the same as
        /// g_variant_get_data(), except that the returned #GBytes holds
        /// a reference to the variant data.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// A new #GBytes representing the variant data
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_data_as_bytes( System.IntPtr value);

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The semantics of this function are exactly the same as
        /// g_variant_get_data(), except that the returned #GBytes holds
        /// a reference to the variant data.
        /// </summary>
        /// <returns>
        /// A new #GBytes representing the variant data
        /// </returns>
        [GISharp.Core.Since("2.36")]
        public GISharp.GLib.Bytes get_DataAsBytes()
        {
            var ret = g_variant_get_data_as_bytes(Handle);
            return default(GISharp.GLib.Bytes);
        }

        /// <summary>
        /// Returns the double precision floating point value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_DOUBLE.
        /// </remarks>
        /// <param name="value">
        /// a double #GVariant instance
        /// </param>
        /// <returns>
        /// a #gdouble
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Double g_variant_get_double( System.IntPtr value);

        /// <summary>
        /// Returns the double precision floating point value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_DOUBLE.
        /// </remarks>
        /// <returns>
        /// a #gdouble
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Double get_Double()
        {
            var ret = g_variant_get_double(Handle);
            return default(System.Double);
        }

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size, as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array,
        /// as given by the section on
        /// [serialized data memory][gvariant-serialised-data-memory].
        /// 
        /// In particular, arrays of these fixed-sized types can be interpreted
        /// as an array of the given C type, with @element_size set to the size
        /// the appropriate type:
        /// - %G_VARIANT_TYPE_INT16 (etc.): #gint16 (etc.)
        /// - %G_VARIANT_TYPE_BOOLEAN: #guchar (not #gboolean!)
        /// - %G_VARIANT_TYPE_BYTE: #guchar
        /// - %G_VARIANT_TYPE_HANDLE: #guint32
        /// - %G_VARIANT_TYPE_DOUBLE: #gdouble
        /// 
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant array with fixed-sized elements
        /// </param>
        /// <param name="nElements">
        /// a pointer to the location to store the number of items
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a pointer to
        ///     the fixed array
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        static extern System.IntPtr[] g_variant_get_fixed_array( System.IntPtr value, out System.UInt64 nElements,  System.UInt64 elementSize);

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size, as are tuples containing only other fixed-sized types.
        /// 
        /// @element_size must be the size of a single element in the array,
        /// as given by the section on
        /// [serialized data memory][gvariant-serialised-data-memory].
        /// 
        /// In particular, arrays of these fixed-sized types can be interpreted
        /// as an array of the given C type, with @element_size set to the size
        /// the appropriate type:
        /// - %G_VARIANT_TYPE_INT16 (etc.): #gint16 (etc.)
        /// - %G_VARIANT_TYPE_BOOLEAN: #guchar (not #gboolean!)
        /// - %G_VARIANT_TYPE_BYTE: #guchar
        /// - %G_VARIANT_TYPE_HANDLE: #guint32
        /// - %G_VARIANT_TYPE_DOUBLE: #gdouble
        /// 
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        /// 
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a pointer to
        ///     the fixed array
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.IntPtr[] GetFixedArray( System.UInt64 elementSize)
        {
            var ret = g_variant_get_fixed_array(Handle, nElements, elementSize);
            return default(System.IntPtr[]);
        }

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type other
        /// than %G_VARIANT_TYPE_HANDLE.
        /// 
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <param name="value">
        /// a handle #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint32
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_variant_get_handle( System.IntPtr value);

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type other
        /// than %G_VARIANT_TYPE_HANDLE.
        /// 
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <returns>
        /// a #gint32
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Int32 get_DBusHandle()
        {
            var ret = g_variant_get_handle(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Returns the 16-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT16.
        /// </remarks>
        /// <param name="value">
        /// a int16 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint16
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int16 g_variant_get_int16( System.IntPtr value);

        /// <summary>
        /// Returns the 16-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT16.
        /// </remarks>
        /// <returns>
        /// a #gint16
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Int16 get_Int16()
        {
            var ret = g_variant_get_int16(Handle);
            return default(System.Int16);
        }

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT32.
        /// </remarks>
        /// <param name="value">
        /// a int32 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint32
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int32 g_variant_get_int32( System.IntPtr value);

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT32.
        /// </remarks>
        /// <returns>
        /// a #gint32
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Int32 get_Int32()
        {
            var ret = g_variant_get_int32(Handle);
            return default(System.Int32);
        }

        /// <summary>
        /// Returns the 64-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT64.
        /// </remarks>
        /// <param name="value">
        /// a int64 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint64
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Int64 g_variant_get_int64( System.IntPtr value);

        /// <summary>
        /// Returns the 64-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT64.
        /// </remarks>
        /// <returns>
        /// a #gint64
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Int64 get_Int64()
        {
            var ret = g_variant_get_int64(Handle);
            return default(System.Int64);
        }

        /// <summary>
        /// Given a maybe-typed #GVariant instance, extract its value.  If the
        /// value is Nothing, then this function returns %NULL.
        /// </summary>
        /// <param name="value">
        /// a maybe-typed value
        /// </param>
        /// <returns>
        /// the contents of @value, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_maybe( System.IntPtr value);

        /// <summary>
        /// Given a maybe-typed #GVariant instance, extract its value.  If the
        /// value is Nothing, then this function returns %NULL.
        /// </summary>
        /// <returns>
        /// the contents of @value, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.Variant get_Maybe()
        {
            var ret = g_variant_get_maybe(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Gets a #GVariant instance that has the same value as @value and is
        /// trusted to be in normal form.
        /// </summary>
        /// <remarks>
        /// If @value is already trusted to be in normal form then a new
        /// reference to @value is returned.
        /// 
        /// If @value is not already trusted, then it is scanned to check if it
        /// is in normal form.  If it is found to be in normal form then it is
        /// marked as trusted and a new reference to it is returned.
        /// 
        /// If @value is found not to be in normal form then a new trusted
        /// #GVariant is created with the same value as @value.
        /// 
        /// It makes sense to call this function if you've received #GVariant
        /// data from untrusted sources and you want to ensure your serialised
        /// output is definitely in normal form.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// a trusted #GVariant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_normal_form( System.IntPtr value);

        /// <summary>
        /// Gets a #GVariant instance that has the same value as @value and is
        /// trusted to be in normal form.
        /// </summary>
        /// <remarks>
        /// If @value is already trusted to be in normal form then a new
        /// reference to @value is returned.
        /// 
        /// If @value is not already trusted, then it is scanned to check if it
        /// is in normal form.  If it is found to be in normal form then it is
        /// marked as trusted and a new reference to it is returned.
        /// 
        /// If @value is found not to be in normal form then a new trusted
        /// #GVariant is created with the same value as @value.
        /// 
        /// It makes sense to call this function if you've received #GVariant
        /// data from untrusted sources and you want to ensure your serialised
        /// output is definitely in normal form.
        /// </remarks>
        /// <returns>
        /// a trusted #GVariant
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.Variant get_NormalForm()
        {
            var ret = g_variant_get_normal_form(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Gets the contents of an array of object paths #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of object paths #GVariant
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        static extern System.IntPtr g_variant_get_objv( System.IntPtr value, out System.UInt64 length);

        /// <summary>
        /// Determines the number of bytes that would be required to store @value
        /// with g_variant_store().
        /// </summary>
        /// <remarks>
        /// If @value has a fixed-sized type then this function always returned
        /// that fixed size.
        /// 
        /// In the case that @value is already in serialised form or the size has
        /// already been calculated (ie: this function has been called before)
        /// then this function is O(1).  Otherwise, the size is calculated, an
        /// operation which is approximately O(n) in the number of values
        /// involved.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// the serialised size of @value
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_get_size( System.IntPtr value);

        /// <summary>
        /// Determines the number of bytes that would be required to store @value
        /// with g_variant_store().
        /// </summary>
        /// <remarks>
        /// If @value has a fixed-sized type then this function always returned
        /// that fixed size.
        /// 
        /// In the case that @value is already in serialised form or the size has
        /// already been calculated (ie: this function has been called before)
        /// then this function is O(1).  Otherwise, the size is calculated, an
        /// operation which is approximately O(n) in the number of values
        /// involved.
        /// </remarks>
        /// <returns>
        /// the serialised size of @value
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.UInt64 get_Size()
        {
            var ret = g_variant_get_size(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Returns the string value of a #GVariant instance with a string
        /// type.  This includes the types %G_VARIANT_TYPE_STRING,
        /// %G_VARIANT_TYPE_OBJECT_PATH and %G_VARIANT_TYPE_SIGNATURE.
        /// </summary>
        /// <remarks>
        /// The string will always be utf8 encoded.
        /// 
        /// If @length is non-%NULL then the length of the string (in bytes) is
        /// returned there.  For trusted values, this information is already
        /// known.  For untrusted values, a strlen() will be performed.
        /// 
        /// It is an error to call this function with a @value of any type
        /// other than those three.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="value">
        /// a string #GVariant instance
        /// </param>
        /// <param name="length">
        /// a pointer to a #gsize,
        ///          to store the length
        /// </param>
        /// <returns>
        /// the constant string, utf8 encoded
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_string( System.IntPtr value, out System.UInt64 length);

        /// <summary>
        /// Returns the string value of a #GVariant instance with a string
        /// type.  This includes the types %G_VARIANT_TYPE_STRING,
        /// %G_VARIANT_TYPE_OBJECT_PATH and %G_VARIANT_TYPE_SIGNATURE.
        /// </summary>
        /// <remarks>
        /// The string will always be utf8 encoded.
        /// 
        /// If @length is non-%NULL then the length of the string (in bytes) is
        /// returned there.  For trusted values, this information is already
        /// known.  For untrusted values, a strlen() will be performed.
        /// 
        /// It is an error to call this function with a @value of any type
        /// other than those three.
        /// 
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="length">
        /// a pointer to a #gsize,
        ///          to store the length
        /// </param>
        /// <returns>
        /// the constant string, utf8 encoded
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.String GetString(out System.UInt64 length)
        {
            var ret = g_variant_get_string(Handle, length);
            return default(System.String);
        }

        /// <summary>
        /// Gets the contents of an array of strings #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of strings #GVariant
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        static extern System.IntPtr g_variant_get_strv( System.IntPtr value, out System.UInt64 length);

        /// <summary>
        /// Gets the contents of an array of strings #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        /// 
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.String[] get_Strv()
        {
            var ret = g_variant_get_strv(Handle, length);
            return default(System.String[]);
        }

        /// <summary>
        /// Determines the type of @value.
        /// </summary>
        /// <remarks>
        /// The return value is valid for the lifetime of @value and must not
        /// be freed.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// a #GVariantType
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_type( System.IntPtr value);

        /// <summary>
        /// Determines the type of @value.
        /// </summary>
        /// <remarks>
        /// The return value is valid for the lifetime of @value and must not
        /// be freed.
        /// </remarks>
        /// <returns>
        /// a #GVariantType
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.VariantType get_VariantType()
        {
            var ret = g_variant_get_type(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Returns the type string of @value.  Unlike the result of calling
        /// g_variant_type_peek_string(), this string is nul-terminated.  This
        /// string belongs to #GVariant and must not be freed.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the type string for the type of @value
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_type_string( System.IntPtr value);

        /// <summary>
        /// Returns the type string of @value.  Unlike the result of calling
        /// g_variant_type_peek_string(), this string is nul-terminated.  This
        /// string belongs to #GVariant and must not be freed.
        /// </summary>
        /// <returns>
        /// the type string for the type of @value
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.String get_TypeString()
        {
            var ret = g_variant_get_type_string(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Returns the 16-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT16.
        /// </remarks>
        /// <param name="value">
        /// a uint16 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint16
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt16 g_variant_get_uint16( System.IntPtr value);

        /// <summary>
        /// Returns the 16-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT16.
        /// </remarks>
        /// <returns>
        /// a #guint16
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.UInt16 get_Uint16()
        {
            var ret = g_variant_get_uint16(Handle);
            return default(System.UInt16);
        }

        /// <summary>
        /// Returns the 32-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT32.
        /// </remarks>
        /// <param name="value">
        /// a uint32 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint32
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_variant_get_uint32( System.IntPtr value);

        /// <summary>
        /// Returns the 32-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT32.
        /// </remarks>
        /// <returns>
        /// a #guint32
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.UInt32 get_Uint32()
        {
            var ret = g_variant_get_uint32(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Returns the 64-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT64.
        /// </remarks>
        /// <param name="value">
        /// a uint64 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint64
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_get_uint64( System.IntPtr value);

        /// <summary>
        /// Returns the 64-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT64.
        /// </remarks>
        /// <returns>
        /// a #guint64
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.UInt64 get_Uint64()
        {
            var ret = g_variant_get_uint64(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// This function is intended to be used by libraries based on #GVariant
        /// that want to provide g_variant_get()-like functionality to their
        /// users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_get() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// need to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// @format_string determines the C types that are used for unpacking
        /// the values and also determines if the values are copied or borrowed,
        /// see the section on
        /// [GVariant format strings][gvariant-format-strings-pointers].
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_get_va( System.IntPtr value,  System.IntPtr formatString,  System.IntPtr endptr,  System.IntPtr app);

        /// <summary>
        /// This function is intended to be used by libraries based on #GVariant
        /// that want to provide g_variant_get()-like functionality to their
        /// users.
        /// </summary>
        /// <remarks>
        /// The API is more general than g_variant_get() to allow a wider range
        /// of possible uses.
        /// 
        /// @format_string must still point to a valid format string, but it only
        /// need to be nul-terminated if @endptr is %NULL.  If @endptr is
        /// non-%NULL then it is updated to point to the first character past the
        /// end of the format string.
        /// 
        /// @app is a pointer to a #va_list.  The arguments, according to
        /// @format_string, are collected from this #va_list and the list is left
        /// pointing to the argument following the last.
        /// 
        /// These two generalisations allow mixing of multiple calls to
        /// g_variant_new_va() and g_variant_get_va() within a single actual
        /// varargs call by the user.
        /// 
        /// @format_string determines the C types that are used for unpacking
        /// the values and also determines if the values are copied or borrowed,
        /// see the section on
        /// [GVariant format strings][gvariant-format-strings-pointers].
        /// </remarks>
        /// <param name="formatString">
        /// a string that is prefixed with a format string
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer,
        ///          or %NULL
        /// </param>
        /// <param name="app">
        /// a pointer to a #va_list
        /// </param>
        [GISharp.Core.Since("2.24")]
        public System.Void GetVa( System.String formatString,  System.String endptr,  System.Object[] app)
        {
            if (formatString == null)
            {
                throw new ArgumentNullException("formatString");
            }
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            var ret = g_variant_get_va(Handle, formatString, endptr, app);
            return default(System.Void);
        }

        /// <summary>
        /// Unboxes @value.  The result is the #GVariant instance that was
        /// contained in @value.
        /// </summary>
        /// <param name="value">
        /// a variant #GVariant instance
        /// </param>
        /// <returns>
        /// the item contained in the variant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_get_variant( System.IntPtr value);

        /// <summary>
        /// Unboxes @value.  The result is the #GVariant instance that was
        /// contained in @value.
        /// </summary>
        /// <returns>
        /// the item contained in the variant
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.Variant get_BoxedVariant()
        {
            var ret = g_variant_get_variant(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Generates a hash value for a #GVariant instance.
        /// </summary>
        /// <remarks>
        /// The output of this function is guaranteed to be the same for a given
        /// value only per-process.  It may change between different processor
        /// architectures or even different versions of GLib.  Do not use this
        /// function as a basis for building protocols or file formats.
        /// 
        /// The type of @value is #gconstpointer only to allow use of this
        /// function with #GHashTable.  @value must be a #GVariant.
        /// </remarks>
        /// <param name="value">
        /// a basic #GVariant value as a #gconstpointer
        /// </param>
        /// <returns>
        /// a hash value corresponding to @value
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_variant_hash( System.IntPtr value);

        /// <summary>
        /// Generates a hash value for a #GVariant instance.
        /// </summary>
        /// <remarks>
        /// The output of this function is guaranteed to be the same for a given
        /// value only per-process.  It may change between different processor
        /// architectures or even different versions of GLib.  Do not use this
        /// function as a basis for building protocols or file formats.
        /// 
        /// The type of @value is #gconstpointer only to allow use of this
        /// function with #GHashTable.  @value must be a #GVariant.
        /// </remarks>
        /// <returns>
        /// a hash value corresponding to @value
        /// </returns>
        [GISharp.Core.Since("2.24")]
        protected System.UInt32 Hash()
        {
            var ret = g_variant_hash(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Checks if @value is a container.
        /// </summary>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @value is a container
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_container( System.IntPtr value);

        /// <summary>
        /// Checks if @value is a container.
        /// </summary>
        /// <returns>
        /// %TRUE if @value is a container
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Boolean get_IsContainer()
        {
            var ret = g_variant_is_container(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Checks if @value is in normal form.
        /// </summary>
        /// <remarks>
        /// The main reason to do this is to detect if a given chunk of
        /// serialised data is in normal form: load the data into a #GVariant
        /// using g_variant_new_from_data() and then use this function to
        /// check.
        /// 
        /// If @value is found to be in normal form then it will be marked as
        /// being trusted.  If the value was already marked as being trusted then
        /// this function will immediately return %TRUE.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @value is in normal form
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_normal_form( System.IntPtr value);

        /// <summary>
        /// Checks if @value is in normal form.
        /// </summary>
        /// <remarks>
        /// The main reason to do this is to detect if a given chunk of
        /// serialised data is in normal form: load the data into a #GVariant
        /// using g_variant_new_from_data() and then use this function to
        /// check.
        /// 
        /// If @value is found to be in normal form then it will be marked as
        /// being trusted.  If the value was already marked as being trusted then
        /// this function will immediately return %TRUE.
        /// </remarks>
        /// <returns>
        /// %TRUE if @value is in normal form
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Boolean get_IsNormalForm()
        {
            var ret = g_variant_is_normal_form(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Checks if a value has a type matching the provided type.
        /// </summary>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if the type of @value matches @type
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_of_type( System.IntPtr value,  System.IntPtr type);

        /// <summary>
        /// Checks if a value has a type matching the provided type.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if the type of @value matches @type
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.Boolean IsOfType( GISharp.GLib.VariantType type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            var ret = g_variant_is_of_type(Handle, type);
            return default(System.Boolean);
        }

        /// <summary>
        /// Creates a heap-allocated #GVariantIter for iterating over the items
        /// in @value.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to @value and will be released only when
        /// g_variant_iter_free() is called.
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_iter_new( System.IntPtr value);

        /// <summary>
        /// Creates a heap-allocated #GVariantIter for iterating over the items
        /// in @value.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to @value and will be released only when
        /// g_variant_iter_free() is called.
        /// </remarks>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.VariantIter IterNew()
        {
            var ret = g_variant_iter_new(Handle);
            return default(GISharp.GLib.VariantIter);
        }

        /// <summary>
        /// Looks up a value in a dictionary #GVariant.
        /// </summary>
        /// <remarks>
        /// This function works with dictionaries of the type a{s*} (and equally
        /// well with type a{o*}, but we only further discuss the string case
        /// for sake of clarity).
        /// 
        /// In the event that @dictionary has the type a{sv}, the @expected_type
        /// string specifies what type of value is expected to be inside of the
        /// variant. If the value inside the variant has a different type then
        /// %NULL is returned. In the event that @dictionary has a value type other
        /// than v then @expected_type must directly match the key type and it is
        /// used to unpack the value directly or an error occurs.
        /// 
        /// In either case, if @key is not found in @dictionary, %NULL is returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// 
        /// This function is currently implemented with a linear scan.  If you
        /// plan to do many lookups then #GVariantDict may be more efficient.
        /// </remarks>
        /// <param name="dictionary">
        /// a dictionary #GVariant
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_lookup_value( System.IntPtr dictionary,  System.IntPtr key,  System.IntPtr expectedType);

        /// <summary>
        /// Looks up a value in a dictionary #GVariant.
        /// </summary>
        /// <remarks>
        /// This function works with dictionaries of the type a{s*} (and equally
        /// well with type a{o*}, but we only further discuss the string case
        /// for sake of clarity).
        /// 
        /// In the event that @dictionary has the type a{sv}, the @expected_type
        /// string specifies what type of value is expected to be inside of the
        /// variant. If the value inside the variant has a different type then
        /// %NULL is returned. In the event that @dictionary has a value type other
        /// than v then @expected_type must directly match the key type and it is
        /// used to unpack the value directly or an error occurs.
        /// 
        /// In either case, if @key is not found in @dictionary, %NULL is returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// 
        /// This function is currently implemented with a linear scan.  If you
        /// plan to do many lookups then #GVariantDict may be more efficient.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.28")]
        public GISharp.GLib.Variant LookupValue( System.String key,  GISharp.GLib.VariantType expectedType)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_variant_lookup_value(Handle, key, expectedType);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Determines the number of children in a container #GVariant instance.
        /// This includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// For variants, the return value is always 1.  For values with maybe
        /// types, it is always zero or one.  For arrays, it is the length of the
        /// array.  For tuples it is the number of tuple items (which depends
        /// only on the type).  For dictionary entries, it is always 2
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_n_children( System.IntPtr value);

        /// <summary>
        /// Determines the number of children in a container #GVariant instance.
        /// This includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// For variants, the return value is always 1.  For values with maybe
        /// types, it is always zero or one.  For arrays, it is the length of the
        /// array.  For tuples it is the number of tuple items (which depends
        /// only on the type).  For dictionary entries, it is always 2
        /// 
        /// This function is O(1).
        /// </remarks>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.UInt64 NChildren()
        {
            var ret = g_variant_n_children(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Pretty-prints @value in the format understood by g_variant_parse().
        /// </summary>
        /// <remarks>
        /// The format is described [here][gvariant-text].
        /// 
        /// If @type_annotate is %TRUE, then type information is included in
        /// the output.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="typeAnnotate">
        /// %TRUE if type information should be included in
        ///                 the output
        /// </param>
        /// <returns>
        /// a newly-allocated string holding the result.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_print( System.IntPtr value,  System.Boolean typeAnnotate);

        /// <summary>
        /// Pretty-prints @value in the format understood by g_variant_parse().
        /// </summary>
        /// <remarks>
        /// The format is described [here][gvariant-text].
        /// 
        /// If @type_annotate is %TRUE, then type information is included in
        /// the output.
        /// </remarks>
        /// <param name="typeAnnotate">
        /// %TRUE if type information should be included in
        ///                 the output
        /// </param>
        /// <returns>
        /// a newly-allocated string holding the result.
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.String Print( System.Boolean typeAnnotate)
        {
            var ret = g_variant_print(Handle, typeAnnotate);
            return default(System.String);
        }

        /// <summary>
        /// #GVariant uses a floating reference count system.  All functions with
        /// names starting with `g_variant_new_` return floating
        /// references.
        /// </summary>
        /// <remarks>
        /// Calling g_variant_ref_sink() on a #GVariant with a floating reference
        /// will convert the floating reference into a full reference.  Calling
        /// g_variant_ref_sink() on a non-floating #GVariant results in an
        /// additional normal reference being added.
        /// 
        /// In other words, if the @value is floating, then this call "assumes
        /// ownership" of the floating reference, converting it to a normal
        /// reference.  If the @value is not floating, then this call adds a
        /// new normal reference increasing the reference count by one.
        /// 
        /// All calls that result in a #GVariant instance being inserted into a
        /// container will call g_variant_ref_sink() on the instance.  This means
        /// that if the value was just created (and has only its floating
        /// reference) then the container will assume sole ownership of the value
        /// at that point and the caller will not need to unreference it.  This
        /// makes certain common styles of programming much easier while still
        /// maintaining normal refcounting semantics in situations where values
        /// are not floating.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the same @value
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_ref_sink( System.IntPtr value);

        /// <summary>
        /// #GVariant uses a floating reference count system.  All functions with
        /// names starting with `g_variant_new_` return floating
        /// references.
        /// </summary>
        /// <remarks>
        /// Calling g_variant_ref_sink() on a #GVariant with a floating reference
        /// will convert the floating reference into a full reference.  Calling
        /// g_variant_ref_sink() on a non-floating #GVariant results in an
        /// additional normal reference being added.
        /// 
        /// In other words, if the @value is floating, then this call "assumes
        /// ownership" of the floating reference, converting it to a normal
        /// reference.  If the @value is not floating, then this call adds a
        /// new normal reference increasing the reference count by one.
        /// 
        /// All calls that result in a #GVariant instance being inserted into a
        /// container will call g_variant_ref_sink() on the instance.  This means
        /// that if the value was just created (and has only its floating
        /// reference) then the container will assume sole ownership of the value
        /// at that point and the caller will not need to unreference it.  This
        /// makes certain common styles of programming much easier while still
        /// maintaining normal refcounting semantics in situations where values
        /// are not floating.
        /// </remarks>
        /// <returns>
        /// the same @value
        /// </returns>
        [GISharp.Core.Since("2.24")]
        protected override void Ref()
        {
            var ret = g_variant_ref_sink(Handle);
        }

        /// <summary>
        /// Stores the serialised form of @value at @data.  @data should be
        /// large enough.  See g_variant_get_size().
        /// </summary>
        /// <remarks>
        /// The stored data is in machine native byte order but may not be in
        /// fully-normalised form if read from an untrusted source.  See
        /// g_variant_get_normal_form() for a solution.
        /// 
        /// As with g_variant_get_data(), to be able to deserialise the
        /// serialised variant successfully, its type and (if the destination
        /// machine might be different) its endianness must also be available.
        /// 
        /// This function is approximately O(n) in the size of @data.
        /// </remarks>
        /// <param name="value">
        /// the #GVariant to store
        /// </param>
        /// <param name="data">
        /// the location to store the serialised data at
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_store( System.IntPtr value,  System.IntPtr data);

        /// <summary>
        /// Stores the serialised form of @value at @data.  @data should be
        /// large enough.  See g_variant_get_size().
        /// </summary>
        /// <remarks>
        /// The stored data is in machine native byte order but may not be in
        /// fully-normalised form if read from an untrusted source.  See
        /// g_variant_get_normal_form() for a solution.
        /// 
        /// As with g_variant_get_data(), to be able to deserialise the
        /// serialised variant successfully, its type and (if the destination
        /// machine might be different) its endianness must also be available.
        /// 
        /// This function is approximately O(n) in the size of @data.
        /// </remarks>
        /// <param name="data">
        /// the location to store the serialised data at
        /// </param>
        [GISharp.Core.Since("2.24")]
        public System.Void Store( System.IntPtr data)
        {
            var ret = g_variant_store(Handle, data);
            return default(System.Void);
        }

        /// <summary>
        /// Decreases the reference count of @value.  When its reference count
        /// drops to 0, the memory used by the variant is freed.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_unref( System.IntPtr value);

        /// <summary>
        /// Decreases the reference count of @value.  When its reference count
        /// drops to 0, the memory used by the variant is freed.
        /// </summary>
        [GISharp.Core.Since("2.24")]
        protected override System.Void Unref()
        {
            var ret = g_variant_unref(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Determines if a given string is a valid D-Bus object path.  You
        /// should ensure that a string is a valid D-Bus object path before
        /// passing it to g_variant_new_object_path().
        /// </summary>
        /// <remarks>
        /// A valid object path starts with '/' followed by zero or more
        /// sequences of characters separated by '/' characters.  Each sequence
        /// must contain only the characters "[A-Z][a-z][0-9]_".  No sequence
        /// (including the one following the final '/' character) may be empty.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus object path
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_object_path( System.IntPtr @string);

        /// <summary>
        /// Determines if a given string is a valid D-Bus object path.  You
        /// should ensure that a string is a valid D-Bus object path before
        /// passing it to g_variant_new_object_path().
        /// </summary>
        /// <remarks>
        /// A valid object path starts with '/' followed by zero or more
        /// sequences of characters separated by '/' characters.  Each sequence
        /// must contain only the characters "[A-Z][a-z][0-9]_".  No sequence
        /// (including the one following the final '/' character) may be empty.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus object path
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public static System.Boolean IsObjectPath( System.String @string)
        {
            if (@string == null)
            {
                throw new ArgumentNullException("@string");
            }
            var ret = g_variant_is_object_path(@string);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if a given string is a valid D-Bus type signature.  You
        /// should ensure that a string is a valid D-Bus type signature before
        /// passing it to g_variant_new_signature().
        /// </summary>
        /// <remarks>
        /// D-Bus type signatures consist of zero or more definite #GVariantType
        /// strings in sequence.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus type signature
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_is_signature( System.IntPtr @string);

        /// <summary>
        /// Determines if a given string is a valid D-Bus type signature.  You
        /// should ensure that a string is a valid D-Bus type signature before
        /// passing it to g_variant_new_signature().
        /// </summary>
        /// <remarks>
        /// D-Bus type signatures consist of zero or more definite #GVariantType
        /// strings in sequence.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus type signature
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public static System.Boolean IsSignature( System.String @string)
        {
            if (@string == null)
            {
                throw new ArgumentNullException("@string");
            }
            var ret = g_variant_is_signature(@string);
            return default(System.Boolean);
        }

        /// <summary>
        /// Parses a #GVariant from a text representation.
        /// </summary>
        /// <remarks>
        /// A single #GVariant is parsed from the content of @text.
        /// 
        /// The format is described [here][gvariant-text].
        /// 
        /// The memory at @limit will never be accessed and the parser behaves as
        /// if the character at @limit is the nul terminator.  This has the
        /// effect of bounding @text.
        /// 
        /// If @endptr is non-%NULL then @text is permitted to contain data
        /// following the value that this function parses and @endptr will be
        /// updated to point to the first character past the end of the text
        /// parsed by this function.  If @endptr is %NULL and there is extra data
        /// then an error is returned.
        /// 
        /// If @type is non-%NULL then the value will be parsed to have that
        /// type.  This may result in additional parse errors (in the case that
        /// the parsed value doesn't fit the type) but may also result in fewer
        /// errors (in the case that the type would have been ambiguous, such as
        /// with empty arrays).
        /// 
        /// In the event that the parsing is successful, the resulting #GVariant
        /// is returned.
        /// 
        /// In case of any error, %NULL will be returned.  If @error is non-%NULL
        /// then it will be set to reflect the error that occurred.
        /// 
        /// Officially, the language understood by the parser is "any string
        /// produced by g_variant_print()".
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <param name="text">
        /// a string containing a GVariant in text form
        /// </param>
        /// <param name="limit">
        /// a pointer to the end of @text, or %NULL
        /// </param>
        /// <param name="endptr">
        /// a location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// a reference to a #GVariant, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_parse( System.IntPtr type,  System.IntPtr text,  System.IntPtr limit,  System.IntPtr endptr);

        /// <summary>
        /// Parses a #GVariant from a text representation.
        /// </summary>
        /// <remarks>
        /// A single #GVariant is parsed from the content of @text.
        /// 
        /// The format is described [here][gvariant-text].
        /// 
        /// The memory at @limit will never be accessed and the parser behaves as
        /// if the character at @limit is the nul terminator.  This has the
        /// effect of bounding @text.
        /// 
        /// If @endptr is non-%NULL then @text is permitted to contain data
        /// following the value that this function parses and @endptr will be
        /// updated to point to the first character past the end of the text
        /// parsed by this function.  If @endptr is %NULL and there is extra data
        /// then an error is returned.
        /// 
        /// If @type is non-%NULL then the value will be parsed to have that
        /// type.  This may result in additional parse errors (in the case that
        /// the parsed value doesn't fit the type) but may also result in fewer
        /// errors (in the case that the type would have been ambiguous, such as
        /// with empty arrays).
        /// 
        /// In the event that the parsing is successful, the resulting #GVariant
        /// is returned.
        /// 
        /// In case of any error, %NULL will be returned.  If @error is non-%NULL
        /// then it will be set to reflect the error that occurred.
        /// 
        /// Officially, the language understood by the parser is "any string
        /// produced by g_variant_print()".
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <param name="text">
        /// a string containing a GVariant in text form
        /// </param>
        /// <param name="limit">
        /// a pointer to the end of @text, or %NULL
        /// </param>
        /// <param name="endptr">
        /// a location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// a reference to a #GVariant, or %NULL
        /// </returns>
        public static GISharp.GLib.Variant Parse( GISharp.GLib.VariantType type,  System.String text,  System.String limit,  System.String endptr)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            var ret = g_variant_parse(type, text, limit, endptr);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Pretty-prints a message showing the context of a #GVariant parse
        /// error within the string for which parsing was attempted.
        /// </summary>
        /// <remarks>
        /// The resulting string is suitable for output to the console or other
        /// monospace media where newlines are treated in the usual way.
        /// 
        /// The message will typically look something like one of the following:
        /// 
        /// |[
        /// unterminated string constant:
        ///   (1, 2, 3, 'abc
        ///             ^^^^
        /// ]|
        /// 
        /// or
        /// 
        /// |[
        /// unable to find a common type:
        ///   [1, 2, 3, 'str']
        ///    ^        ^^^^^
        /// ]|
        /// 
        /// The format of the message may change in a future version.
        /// 
        /// @error must have come from a failed attempt to g_variant_parse() and
        /// @source_str must be exactly the same string that caused the error.
        /// If @source_str was not nul-terminated when you passed it to
        /// g_variant_parse() then you must add nul termination before using this
        /// function.
        /// </remarks>
        /// <param name="error">
        /// a #GError from the #GVariantParseError domain
        /// </param>
        /// <param name="sourceStr">
        /// the string that was given to the parser
        /// </param>
        /// <returns>
        /// the printed message
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_parse_error_print_context( System.IntPtr error,  System.IntPtr sourceStr);

        /// <summary>
        /// Pretty-prints a message showing the context of a #GVariant parse
        /// error within the string for which parsing was attempted.
        /// </summary>
        /// <remarks>
        /// The resulting string is suitable for output to the console or other
        /// monospace media where newlines are treated in the usual way.
        /// 
        /// The message will typically look something like one of the following:
        /// 
        /// |[
        /// unterminated string constant:
        ///   (1, 2, 3, 'abc
        ///             ^^^^
        /// ]|
        /// 
        /// or
        /// 
        /// |[
        /// unable to find a common type:
        ///   [1, 2, 3, 'str']
        ///    ^        ^^^^^
        /// ]|
        /// 
        /// The format of the message may change in a future version.
        /// 
        /// @error must have come from a failed attempt to g_variant_parse() and
        /// @source_str must be exactly the same string that caused the error.
        /// If @source_str was not nul-terminated when you passed it to
        /// g_variant_parse() then you must add nul termination before using this
        /// function.
        /// </remarks>
        /// <param name="error">
        /// a #GError from the #GVariantParseError domain
        /// </param>
        /// <param name="sourceStr">
        /// the string that was given to the parser
        /// </param>
        /// <returns>
        /// the printed message
        /// </returns>
        [GISharp.Core.Since("2.40")]
        public static System.String ParseErrorPrintContext( GISharp.GLib.Error error,  System.String sourceStr)
        {
            if (error == null)
            {
                throw new ArgumentNullException("error");
            }
            if (sourceStr == null)
            {
                throw new ArgumentNullException("sourceStr");
            }
            var ret = g_variant_parse_error_print_context(error, sourceStr);
            return default(System.String);
        }

        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_parse_error_quark();

        public static GISharp.GLib.Quark ParseErrorQuark()
        {
            var ret = g_variant_parse_error_quark();
            return default(GISharp.GLib.Quark);
        }

        /// <summary>
        /// Same as g_variant_error_quark().
        /// </summary>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_parser_get_error_quark();

        /// <summary>
        /// Same as g_variant_error_quark().
        /// </summary>
        [Obsolete("Use g_variant_parse_error_quark() instead.")]
        public static GISharp.GLib.Quark ParserGetErrorQuark()
        {
            var ret = g_variant_parser_get_error_quark();
            return default(GISharp.GLib.Quark);
        }
    }

    /// <summary>
    /// A utility type for constructing container-type #GVariant instances.
    /// </summary>
    /// <remarks>
    /// This is an opaque structure and may only be accessed using the
    /// following functions.
    /// 
    /// #GVariantBuilder is not threadsafe in any way.  Do not attempt to
    /// access it from more than one thread.
    /// </remarks>
    public partial class VariantBuilder : GISharp.Core.ReferenceCountedOpaque<VariantBuilder>
    {
        public VariantBuilder(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_builder_new( System.IntPtr type);

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public VariantBuilder( GISharp.GLib.VariantType type) : base(IntPtr.Zero)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            var ret = g_variant_builder_new(type);
        }

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_builder_add_value( System.IntPtr builder,  System.IntPtr value);

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Core.Since("2.24")]
        public System.Void AddValue( GISharp.GLib.Variant value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_variant_builder_add_value(Handle, value);
            return default(System.Void);
        }

        /// <summary>
        /// Releases all memory associated with a #GVariantBuilder without
        /// freeing the #GVariantBuilder structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantBuilder if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_builder_end() and it also doesn't need to be called on
        /// builders allocated with g_variant_builder_new (see
        /// g_variant_builder_unref() for that).
        /// 
        /// This function leaves the #GVariantBuilder structure set to all-zeros.
        /// It is valid to call this function on either an initialised
        /// #GVariantBuilder or one that is set to all-zeros but it is not valid
        /// to call this function on uninitialised memory.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_builder_clear( System.IntPtr builder);

        /// <summary>
        /// Releases all memory associated with a #GVariantBuilder without
        /// freeing the #GVariantBuilder structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantBuilder if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_builder_end() and it also doesn't need to be called on
        /// builders allocated with g_variant_builder_new (see
        /// g_variant_builder_unref() for that).
        /// 
        /// This function leaves the #GVariantBuilder structure set to all-zeros.
        /// It is valid to call this function on either an initialised
        /// #GVariantBuilder or one that is set to all-zeros but it is not valid
        /// to call this function on uninitialised memory.
        /// </remarks>
        [GISharp.Core.Since("2.24")]
        public System.Void Clear()
        {
            var ret = g_variant_builder_clear(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_builder_close( System.IntPtr builder);

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        [GISharp.Core.Since("2.24")]
        public System.Void Close()
        {
            var ret = g_variant_builder_close(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated).
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_builder_end( System.IntPtr builder);

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated).
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.Variant End()
        {
            var ret = g_variant_builder_end(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Initialises a #GVariantBuilder structure.
        /// </summary>
        /// <remarks>
        /// @type must be non-%NULL.  It specifies the type of container to
        /// construct.  It can be an indefinite type such as
        /// %G_VARIANT_TYPE_ARRAY or a definite type such as "as" or "(ii)".
        /// Maybe, array, tuple, dictionary entry and variant-typed values may be
        /// constructed.
        /// 
        /// After the builder is initialised, values are added using
        /// g_variant_builder_add_value() or g_variant_builder_add().
        /// 
        /// After all the child values are added, g_variant_builder_end() frees
        /// the memory associated with the builder and returns the #GVariant that
        /// was created.
        /// 
        /// This function completely ignores the previous contents of @builder.
        /// On one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantBuilder you need to
        /// first call g_variant_builder_clear() in order to avoid leaking
        /// memory.
        /// 
        /// You must not call g_variant_builder_ref() or
        /// g_variant_builder_unref() on a #GVariantBuilder that was initialised
        /// with this function.  If you ever pass a reference to a
        /// #GVariantBuilder outside of the control of your own code then you
        /// should assume that the person receiving that reference may try to use
        /// reference counting; you should use g_variant_builder_new() instead of
        /// this function.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// a container type
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_builder_init( System.IntPtr builder,  System.IntPtr type);

        /// <summary>
        /// Initialises a #GVariantBuilder structure.
        /// </summary>
        /// <remarks>
        /// @type must be non-%NULL.  It specifies the type of container to
        /// construct.  It can be an indefinite type such as
        /// %G_VARIANT_TYPE_ARRAY or a definite type such as "as" or "(ii)".
        /// Maybe, array, tuple, dictionary entry and variant-typed values may be
        /// constructed.
        /// 
        /// After the builder is initialised, values are added using
        /// g_variant_builder_add_value() or g_variant_builder_add().
        /// 
        /// After all the child values are added, g_variant_builder_end() frees
        /// the memory associated with the builder and returns the #GVariant that
        /// was created.
        /// 
        /// This function completely ignores the previous contents of @builder.
        /// On one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantBuilder you need to
        /// first call g_variant_builder_clear() in order to avoid leaking
        /// memory.
        /// 
        /// You must not call g_variant_builder_ref() or
        /// g_variant_builder_unref() on a #GVariantBuilder that was initialised
        /// with this function.  If you ever pass a reference to a
        /// #GVariantBuilder outside of the control of your own code then you
        /// should assume that the person receiving that reference may try to use
        /// reference counting; you should use g_variant_builder_new() instead of
        /// this function.
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        [GISharp.Core.Since("2.24")]
        public System.Void Init( GISharp.GLib.VariantType type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            var ret = g_variant_builder_init(Handle, type);
            return default(System.Void);
        }

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_builder_open( System.IntPtr builder,  System.IntPtr type);

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        [GISharp.Core.Since("2.24")]
        public System.Void Open( GISharp.GLib.VariantType type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            var ret = g_variant_builder_open(Handle, type);
            return default(System.Void);
        }

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        /// <returns>
        /// a new reference to @builder
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_builder_ref( System.IntPtr builder);

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <returns>
        /// a new reference to @builder
        /// </returns>
        [GISharp.Core.Since("2.24")]
        protected override void Ref()
        {
            var ret = g_variant_builder_ref(Handle);
        }

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// 
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_builder_unref( System.IntPtr builder);

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// 
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        [GISharp.Core.Since("2.24")]
        protected override System.Void Unref()
        {
            var ret = g_variant_builder_unref(Handle);
            return default(System.Void);
        }
    }

    /// <summary>
    /// #GVariantDict is a mutable interface to #GVariant dictionaries.
    /// </summary>
    /// <remarks>
    /// It can be used for doing a sequence of dictionary lookups in an
    /// efficient way on an existing #GVariant dictionary or it can be used
    /// to construct new dictionaries with a hashtable-like interface.  It
    /// can also be used for taking existing dictionaries and modifying them
    /// in order to create new ones.
    /// 
    /// #GVariantDict can only be used with %G_VARIANT_TYPE_VARDICT
    /// dictionaries.
    /// 
    /// It is possible to use #GVariantDict allocated on the stack or on the
    /// heap.  When using a stack-allocated #GVariantDict, you begin with a
    /// call to g_variant_dict_init() and free the resources with a call to
    /// g_variant_dict_clear().
    /// 
    /// Heap-allocated #GVariantDict follows normal refcounting rules: you
    /// allocate it with g_variant_dict_new() and use g_variant_dict_ref()
    /// and g_variant_dict_unref().
    /// 
    /// g_variant_dict_end() is used to convert the #GVariantDict back into a
    /// dictionary-type #GVariant.  When used with stack-allocated instances,
    /// this also implicitly frees all associated memory, but for
    /// heap-allocated instances, you must still call g_variant_dict_unref()
    /// afterwards.
    /// 
    /// You will typically want to use a heap-allocated #GVariantDict when
    /// you expose it as part of an API.  For most other uses, the
    /// stack-allocated form will be more convenient.
    /// 
    /// Consider the following two examples that do the same thing in each
    /// style: take an existing dictionary and look up the "count" uint32
    /// key, adding 1 to it if it is found, or returning an error if the
    /// key is not found.  Each returns the new dictionary as a floating
    /// #GVariant.
    /// 
    /// ## Using a stack-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict dict;
    ///     guint32 count;
    /// 
    ///     g_variant_dict_init (&amp;dict, orig);
    ///     if (!g_variant_dict_lookup (&amp;dict, "count", "u", &amp;count))
    ///       {
    ///         g_set_error (...);
    ///         g_variant_dict_clear (&amp;dict);
    ///         return NULL;
    ///       }
    /// 
    ///     g_variant_dict_insert (&amp;dict, "count", "u", count + 1);
    /// 
    ///     return g_variant_dict_end (&amp;dict);
    ///   }
    /// ]|
    /// 
    /// ## Using heap-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict *dict;
    ///     GVariant *result;
    ///     guint32 count;
    /// 
    ///     dict = g_variant_dict_new (orig);
    /// 
    ///     if (g_variant_dict_lookup (dict, "count", "u", &amp;count))
    ///       {
    ///         g_variant_dict_insert (dict, "count", "u", count + 1);
    ///         result = g_variant_dict_end (dict);
    ///       }
    ///     else
    ///       {
    ///         g_set_error (...);
    ///         result = NULL;
    ///       }
    /// 
    ///     g_variant_dict_unref (dict);
    /// 
    ///     return result;
    ///   }
    /// ]|
    /// </remarks>
    [GISharp.Core.Since("2.40")]
    public partial class VariantDict : GISharp.Core.ReferenceCountedOpaque<VariantDict>
    {
        public VariantDict(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_new( System.IntPtr fromAsv);

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Core.Since("2.40")]
        public VariantDict( GISharp.GLib.Variant fromAsv) : base(IntPtr.Zero)
        {
            var ret = g_variant_dict_new(fromAsv);
        }

        /// <summary>
        /// Releases all memory associated with a #GVariantDict without freeing
        /// the #GVariantDict structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantDict if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_dict_end() and it also doesn't need to be called on dicts
        /// allocated with g_variant_dict_new (see g_variant_dict_unref() for
        /// that).
        /// 
        /// It is valid to call this function on either an initialised
        /// #GVariantDict or one that was previously cleared by an earlier call
        /// to g_variant_dict_clear() but it is not valid to call this function
        /// on uninitialised memory.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_dict_clear( System.IntPtr dict);

        /// <summary>
        /// Releases all memory associated with a #GVariantDict without freeing
        /// the #GVariantDict structure itself.
        /// </summary>
        /// <remarks>
        /// It typically only makes sense to do this on a stack-allocated
        /// #GVariantDict if you want to abort building the value part-way
        /// through.  This function need not be called if you call
        /// g_variant_dict_end() and it also doesn't need to be called on dicts
        /// allocated with g_variant_dict_new (see g_variant_dict_unref() for
        /// that).
        /// 
        /// It is valid to call this function on either an initialised
        /// #GVariantDict or one that was previously cleared by an earlier call
        /// to g_variant_dict_clear() but it is not valid to call this function
        /// on uninitialised memory.
        /// </remarks>
        [GISharp.Core.Since("2.40")]
        public System.Void Clear()
        {
            var ret = g_variant_dict_clear(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_dict_contains( System.IntPtr dict,  System.IntPtr key);

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Core.Since("2.40")]
        public System.Boolean Contains( System.String key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_variant_dict_contains(Handle, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_end( System.IntPtr dict);

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Core.Since("2.40")]
        public GISharp.GLib.Variant End()
        {
            var ret = g_variant_dict_end(Handle);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Initialises a #GVariantDict structure.
        /// </summary>
        /// <remarks>
        /// If @from_asv is given, it is used to initialise the dictionary.
        /// 
        /// This function completely ignores the previous contents of @dict.  On
        /// one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantDict you need to first
        /// call g_variant_dict_clear() in order to avoid leaking memory.
        /// 
        /// You must not call g_variant_dict_ref() or g_variant_dict_unref() on a
        /// #GVariantDict that was initialised with this function.  If you ever
        /// pass a reference to a #GVariantDict outside of the control of your
        /// own code then you should assume that the person receiving that
        /// reference may try to use reference counting; you should use
        /// g_variant_dict_new() instead of this function.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="fromAsv">
        /// the initial value for @dict
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_dict_init( System.IntPtr dict,  System.IntPtr fromAsv);

        /// <summary>
        /// Initialises a #GVariantDict structure.
        /// </summary>
        /// <remarks>
        /// If @from_asv is given, it is used to initialise the dictionary.
        /// 
        /// This function completely ignores the previous contents of @dict.  On
        /// one hand this means that it is valid to pass in completely
        /// uninitialised memory.  On the other hand, this means that if you are
        /// initialising over top of an existing #GVariantDict you need to first
        /// call g_variant_dict_clear() in order to avoid leaking memory.
        /// 
        /// You must not call g_variant_dict_ref() or g_variant_dict_unref() on a
        /// #GVariantDict that was initialised with this function.  If you ever
        /// pass a reference to a #GVariantDict outside of the control of your
        /// own code then you should assume that the person receiving that
        /// reference may try to use reference counting; you should use
        /// g_variant_dict_new() instead of this function.
        /// </remarks>
        /// <param name="fromAsv">
        /// the initial value for @dict
        /// </param>
        [GISharp.Core.Since("2.40")]
        public System.Void Init( GISharp.GLib.Variant fromAsv)
        {
            var ret = g_variant_dict_init(Handle, fromAsv);
            return default(System.Void);
        }

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_dict_insert_value( System.IntPtr dict,  System.IntPtr key,  System.IntPtr value);

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Core.Since("2.40")]
        public System.Void InsertValue( System.String key,  GISharp.GLib.Variant value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_variant_dict_insert_value(Handle, key, value);
            return default(System.Void);
        }

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_lookup_value( System.IntPtr dict,  System.IntPtr key,  System.IntPtr expectedType);

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.40")]
        public GISharp.GLib.Variant LookupValue( System.String key,  GISharp.GLib.VariantType expectedType)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_variant_dict_lookup_value(Handle, key, expectedType);
            return default(GISharp.GLib.Variant);
        }

        /// <summary>
        /// Increases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        /// <returns>
        /// a new reference to @dict
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_dict_ref( System.IntPtr dict);

        /// <summary>
        /// Increases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <returns>
        /// a new reference to @dict
        /// </returns>
        [GISharp.Core.Since("2.40")]
        protected override void Ref()
        {
            var ret = g_variant_dict_ref(Handle);
        }

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_dict_remove( System.IntPtr dict,  System.IntPtr key);

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [GISharp.Core.Since("2.40")]
        public System.Boolean Remove( System.String key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            var ret = g_variant_dict_remove(Handle, key);
            return default(System.Boolean);
        }

        /// <summary>
        /// Decreases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantDict.
        /// 
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_dict_unref( System.IntPtr dict);

        /// <summary>
        /// Decreases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantDict.
        /// 
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        [GISharp.Core.Since("2.40")]
        protected override System.Void Unref()
        {
            var ret = g_variant_dict_unref(Handle);
            return default(System.Void);
        }
    }

    /// <summary>
    /// #GVariantIter is an opaque data structure and can only be accessed
    /// using the following functions.
    /// </summary>
    public partial class VariantIter : GISharp.Core.OwnedOpaque<VariantIter>
    {
        public VariantIter(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new heap-allocated #GVariantIter to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to the container that @iter is iterating over
        /// and will be releated only when g_variant_iter_free() is called.
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_iter_copy( System.IntPtr iter);

        /// <summary>
        /// Creates a new heap-allocated #GVariantIter to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// 
        /// A reference is taken to the container that @iter is iterating over
        /// and will be releated only when g_variant_iter_free() is called.
        /// </remarks>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public override GISharp.GLib.VariantIter Copy()
        {
            var ret = g_variant_iter_copy(Handle);
            return default(GISharp.GLib.VariantIter);
        }

        /// <summary>
        /// Frees a heap-allocated #GVariantIter.  Only call this function on
        /// iterators that were returned by g_variant_iter_new() or
        /// g_variant_iter_copy().
        /// </summary>
        /// <param name="iter">
        /// a heap-allocated #GVariantIter
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_iter_free( System.IntPtr iter);

        /// <summary>
        /// Frees a heap-allocated #GVariantIter.  Only call this function on
        /// iterators that were returned by g_variant_iter_new() or
        /// g_variant_iter_copy().
        /// </summary>
        [GISharp.Core.Since("2.24")]
        protected override System.Void Free()
        {
            var ret = g_variant_iter_free(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Initialises (without allocating) a #GVariantIter.  @iter may be
        /// completely uninitialised prior to this call; its old value is
        /// ignored.
        /// </summary>
        /// <remarks>
        /// The iterator remains valid for as long as @value exists, and need not
        /// be freed in any way.
        /// </remarks>
        /// <param name="iter">
        /// a pointer to a #GVariantIter
        /// </param>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of items in @value
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_iter_init( System.IntPtr iter,  System.IntPtr value);

        /// <summary>
        /// Initialises (without allocating) a #GVariantIter.  @iter may be
        /// completely uninitialised prior to this call; its old value is
        /// ignored.
        /// </summary>
        /// <remarks>
        /// The iterator remains valid for as long as @value exists, and need not
        /// be freed in any way.
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of items in @value
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.UInt64 Init( GISharp.GLib.Variant value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_variant_iter_init(Handle, value);
            return default(System.UInt64);
        }

        /// <summary>
        /// Queries the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// This function might be useful for preallocation of arrays.
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_iter_n_children( System.IntPtr iter);

        /// <summary>
        /// Queries the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// This function might be useful for preallocation of arrays.
        /// </remarks>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public System.UInt64 NChildren()
        {
            var ret = g_variant_iter_n_children(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Gets the next item in the container.  If no more items remain then
        /// %NULL is returned.
        /// </summary>
        /// <remarks>
        /// Use g_variant_unref() to drop your reference on the return value when
        /// you no longer need it.
        /// 
        /// Here is an example for iterating with g_variant_iter_next_value():
        /// |[&lt;!-- language="C" --&gt;
        ///   // recursively iterate a container
        ///   void
        ///   iterate_container_recursive (GVariant *container)
        ///   {
        ///     GVariantIter iter;
        ///     GVariant *child;
        /// 
        ///     g_variant_iter_init (&amp;iter, container);
        ///     while ((child = g_variant_iter_next_value (&amp;iter)))
        ///       {
        ///         g_print ("type '%s'\n", g_variant_get_type_string (child));
        /// 
        ///         if (g_variant_is_container (child))
        ///           iterate_container_recursive (child);
        /// 
        ///         g_variant_unref (child);
        ///       }
        ///   }
        /// ]|
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a #GVariant, or %NULL
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_iter_next_value( System.IntPtr iter);

        /// <summary>
        /// Gets the next item in the container.  If no more items remain then
        /// %NULL is returned.
        /// </summary>
        /// <remarks>
        /// Use g_variant_unref() to drop your reference on the return value when
        /// you no longer need it.
        /// 
        /// Here is an example for iterating with g_variant_iter_next_value():
        /// |[&lt;!-- language="C" --&gt;
        ///   // recursively iterate a container
        ///   void
        ///   iterate_container_recursive (GVariant *container)
        ///   {
        ///     GVariantIter iter;
        ///     GVariant *child;
        /// 
        ///     g_variant_iter_init (&amp;iter, container);
        ///     while ((child = g_variant_iter_next_value (&amp;iter)))
        ///       {
        ///         g_print ("type '%s'\n", g_variant_get_type_string (child));
        /// 
        ///         if (g_variant_is_container (child))
        ///           iterate_container_recursive (child);
        /// 
        ///         g_variant_unref (child);
        ///       }
        ///   }
        /// ]|
        /// </remarks>
        /// <returns>
        /// a #GVariant, or %NULL
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public GISharp.GLib.Variant NextValue()
        {
            var ret = g_variant_iter_next_value(Handle);
            return default(GISharp.GLib.Variant);
        }
    }

    /// <summary>
    /// This section introduces the GVariant type system. It is based, in
    /// large part, on the D-Bus type system, with two major changes and
    /// some minor lifting of restrictions. The
    /// [D-Bus specification](http://dbus.freedesktop.org/doc/dbus-specification.html),
    /// therefore, provides a significant amount of
    /// information that is useful when working with GVariant.
    /// </summary>
    /// <remarks>
    /// The first major change with respect to the D-Bus type system is the
    /// introduction of maybe (or "nullable") types.  Any type in GVariant can be
    /// converted to a maybe type, in which case, "nothing" (or "null") becomes a
    /// valid value.  Maybe types have been added by introducing the
    /// character "m" to type strings.
    /// 
    /// The second major change is that the GVariant type system supports the
    /// concept of "indefinite types" -- types that are less specific than
    /// the normal types found in D-Bus.  For example, it is possible to speak
    /// of "an array of any type" in GVariant, where the D-Bus type system
    /// would require you to speak of "an array of integers" or "an array of
    /// strings".  Indefinite types have been added by introducing the
    /// characters "*", "?" and "r" to type strings.
    /// 
    /// Finally, all arbitrary restrictions relating to the complexity of
    /// types are lifted along with the restriction that dictionary entries
    /// may only appear nested inside of arrays.
    /// 
    /// Just as in D-Bus, GVariant types are described with strings ("type
    /// strings").  Subject to the differences mentioned above, these strings
    /// are of the same form as those found in DBus.  Note, however: D-Bus
    /// always works in terms of messages and therefore individual type
    /// strings appear nowhere in its interface.  Instead, "signatures"
    /// are a concatenation of the strings of the type of each argument in a
    /// message.  GVariant deals with single values directly so GVariant type
    /// strings always describe the type of exactly one value.  This means
    /// that a D-Bus signature string is generally not a valid GVariant type
    /// string -- except in the case that it is the signature of a message
    /// containing exactly one argument.
    /// 
    /// An indefinite type is similar in spirit to what may be called an
    /// abstract type in other type systems.  No value can exist that has an
    /// indefinite type as its type, but values can exist that have types
    /// that are subtypes of indefinite types.  That is to say,
    /// g_variant_get_type() will never return an indefinite type, but
    /// calling g_variant_is_of_type() with an indefinite type may return
    /// %TRUE.  For example, you cannot have a value that represents "an
    /// array of no particular type", but you can have an "array of integers"
    /// which certainly matches the type of "an array of no particular type",
    /// since "array of integers" is a subtype of "array of no particular
    /// type".
    /// 
    /// This is similar to how instances of abstract classes may not
    /// directly exist in other type systems, but instances of their
    /// non-abstract subtypes may.  For example, in GTK, no object that has
    /// the type of #GtkBin can exist (since #GtkBin is an abstract class),
    /// but a #GtkWindow can certainly be instantiated, and you would say
    /// that the #GtkWindow is a #GtkBin (since #GtkWindow is a subclass of
    /// #GtkBin).
    /// 
    /// ## GVariant Type Strings
    /// 
    /// A GVariant type string can be any of the following:
    /// 
    /// - any basic type string (listed below)
    /// 
    /// - "v", "r" or "*"
    /// 
    /// - one of the characters 'a' or 'm', followed by another type string
    /// 
    /// - the character '(', followed by a concatenation of zero or more other
    ///   type strings, followed by the character ')'
    /// 
    /// - the character '{', followed by a basic type string (see below),
    ///   followed by another type string, followed by the character '}'
    /// 
    /// A basic type string describes a basic type (as per
    /// g_variant_type_is_basic()) and is always a single character in length.
    /// The valid basic type strings are "b", "y", "n", "q", "i", "u", "x", "t",
    /// "h", "d", "s", "o", "g" and "?".
    /// 
    /// The above definition is recursive to arbitrary depth. "aaaaai" and
    /// "(ui(nq((y)))s)" are both valid type strings, as is
    /// "a(aa(ui)(qna{ya(yd)}))".
    /// 
    /// The meaning of each of the characters is as follows:
    /// - `b`: the type string of %G_VARIANT_TYPE_BOOLEAN; a boolean value.
    /// - `y`: the type string of %G_VARIANT_TYPE_BYTE; a byte.
    /// - `n`: the type string of %G_VARIANT_TYPE_INT16; a signed 16 bit integer.
    /// - `q`: the type string of %G_VARIANT_TYPE_UINT16; an unsigned 16 bit integer.
    /// - `i`: the type string of %G_VARIANT_TYPE_INT32; a signed 32 bit integer.
    /// - `u`: the type string of %G_VARIANT_TYPE_UINT32; an unsigned 32 bit integer.
    /// - `x`: the type string of %G_VARIANT_TYPE_INT64; a signed 64 bit integer.
    /// - `t`: the type string of %G_VARIANT_TYPE_UINT64; an unsigned 64 bit integer.
    /// - `h`: the type string of %G_VARIANT_TYPE_HANDLE; a signed 32 bit value
    ///   that, by convention, is used as an index into an array of file
    ///   descriptors that are sent alongside a D-Bus message.
    /// - `d`: the type string of %G_VARIANT_TYPE_DOUBLE; a double precision
    ///   floating point value.
    /// - `s`: the type string of %G_VARIANT_TYPE_STRING; a string.
    /// - `o`: the type string of %G_VARIANT_TYPE_OBJECT_PATH; a string in the form
    ///   of a D-Bus object path.
    /// - `g`: the type string of %G_VARIANT_TYPE_STRING; a string in the form of
    ///   a D-Bus type signature.
    /// - `?`: the type string of %G_VARIANT_TYPE_BASIC; an indefinite type that
    ///   is a supertype of any of the basic types.
    /// - `v`: the type string of %G_VARIANT_TYPE_VARIANT; a container type that
    ///   contain any other type of value.
    /// - `a`: used as a prefix on another type string to mean an array of that
    ///   type; the type string "ai", for example, is the type of an array of
    ///   signed 32-bit integers.
    /// - `m`: used as a prefix on another type string to mean a "maybe", or
    ///   "nullable", version of that type; the type string "ms", for example,
    ///   is the type of a value that maybe contains a string, or maybe contains
    ///   nothing.
    /// - `()`: used to enclose zero or more other concatenated type strings to
    ///   create a tuple type; the type string "(is)", for example, is the type of
    ///   a pair of an integer and a string.
    /// - `r`: the type string of %G_VARIANT_TYPE_TUPLE; an indefinite type that is
    ///   a supertype of any tuple type, regardless of the number of items.
    /// - `{}`: used to enclose a basic type string concatenated with another type
    ///   string to create a dictionary entry type, which usually appears inside of
    ///   an array to form a dictionary; the type string "a{sd}", for example, is
    ///   the type of a dictionary that maps strings to double precision floating
    ///   point values.
    /// 
    ///   The first type (the basic type) is the key type and the second type is
    ///   the value type. The reason that the first type is restricted to being a
    ///   basic type is so that it can easily be hashed.
    /// - `*`: the type string of %G_VARIANT_TYPE_ANY; the indefinite type that is
    ///   a supertype of all types.  Note that, as with all type strings, this
    ///   character represents exactly one type. It cannot be used inside of tuples
    ///   to mean "any number of items".
    /// 
    /// Any type string of a container that contains an indefinite type is,
    /// itself, an indefinite type. For example, the type string "a*"
    /// (corresponding to %G_VARIANT_TYPE_ARRAY) is an indefinite type
    /// that is a supertype of every array type. "(*s)" is a supertype
    /// of all tuples that contain exactly two items where the second
    /// item is a string.
    /// 
    /// "a{?*}" is an indefinite type that is a supertype of all arrays
    /// containing dictionary entries where the key is any basic type and
    /// the value is any type at all.  This is, by definition, a dictionary,
    /// so this type string corresponds to %G_VARIANT_TYPE_DICTIONARY. Note
    /// that, due to the restriction that the key of a dictionary entry must
    /// be a basic type, "{**}" is not a valid type string.
    /// </remarks>
    public partial class VariantType : GISharp.Core.OwnedOpaque<VariantType>
    {
        public VariantType(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Creates a new #GVariantType corresponding to the type string given
        /// by @type_string.  It is appropriate to call g_variant_type_free() on
        /// the return value.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to call this function with an invalid type
        /// string.  Use g_variant_type_string_is_valid() if you are unsure.
        /// </remarks>
        /// <param name="typeString">
        /// a valid GVariant type string
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new( System.IntPtr typeString);

        /// <summary>
        /// Creates a new #GVariantType corresponding to the type string given
        /// by @type_string.  It is appropriate to call g_variant_type_free() on
        /// the return value.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to call this function with an invalid type
        /// string.  Use g_variant_type_string_is_valid() if you are unsure.
        /// </remarks>
        /// <param name="typeString">
        /// a valid GVariant type string
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public VariantType( System.String typeString) : base(IntPtr.Zero)
        {
            if (typeString == null)
            {
                throw new ArgumentNullException("typeString");
            }
            var ret = g_variant_type_new(typeString);
        }

        /// <summary>
        /// Makes a copy of a #GVariantType.  It is appropriate to call
        /// g_variant_type_free() on the return value.  @type may not be %NULL.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_copy( System.IntPtr type);

        /// <summary>
        /// Makes a copy of a #GVariantType.  It is appropriate to call
        /// g_variant_type_free() on the return value.  @type may not be %NULL.
        /// </summary>
        /// <returns>
        /// a new #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public override GISharp.GLib.VariantType Copy()
        {
            var ret = g_variant_type_copy(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Returns a newly-allocated copy of the type string corresponding to
        /// @type.  The returned string is nul-terminated.  It is appropriate to
        /// call g_free() on the return value.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_dup_string( System.IntPtr type);

        /// <summary>
        /// Returns a newly-allocated copy of the type string corresponding to
        /// @type.  The returned string is nul-terminated.  It is appropriate to
        /// call g_free() on the return value.
        /// </summary>
        /// <returns>
        /// the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        public override System.String ToString()
        {
            var ret = g_variant_type_dup_string(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Determines the element type of an array or maybe type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with array or maybe types.
        /// </remarks>
        /// <param name="type">
        /// an array or maybe #GVariantType
        /// </param>
        /// <returns>
        /// the element type of @type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_element( System.IntPtr type);

        /// <summary>
        /// Determines the element type of an array or maybe type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with array or maybe types.
        /// </remarks>
        /// <returns>
        /// the element type of @type
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Element()
        {
            var ret = g_variant_type_element(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Compares @type1 and @type2 for equality.
        /// </summary>
        /// <remarks>
        /// Only returns %TRUE if the types are exactly equal.  Even if one type
        /// is an indefinite type and the other is a subtype of it, %FALSE will
        /// be returned if they are not exactly equal.  If you want to check for
        /// subtypes, use g_variant_type_is_subtype_of().
        /// 
        /// The argument types of @type1 and @type2 are only #gconstpointer to
        /// allow use with #GHashTable without function pointer casting.  For
        /// both arguments, a valid #GVariantType must be provided.
        /// </remarks>
        /// <param name="type1">
        /// a #GVariantType
        /// </param>
        /// <param name="type2">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type1 and @type2 are exactly equal
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_equal( System.IntPtr type1,  System.IntPtr type2);

        /// <summary>
        /// Compares @type1 and @type2 for equality.
        /// </summary>
        /// <remarks>
        /// Only returns %TRUE if the types are exactly equal.  Even if one type
        /// is an indefinite type and the other is a subtype of it, %FALSE will
        /// be returned if they are not exactly equal.  If you want to check for
        /// subtypes, use g_variant_type_is_subtype_of().
        /// 
        /// The argument types of @type1 and @type2 are only #gconstpointer to
        /// allow use with #GHashTable without function pointer casting.  For
        /// both arguments, a valid #GVariantType must be provided.
        /// </remarks>
        /// <param name="type2">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type1 and @type2 are exactly equal
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean Equals( GISharp.GLib.VariantType type2)
        {
            if (type2 == null)
            {
                throw new ArgumentNullException("type2");
            }
            var ret = g_variant_type_equal(Handle, type2);
            return default(System.Boolean);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as VariantType);
        }

        public override int GetHashCode()
        {
            return (int)Hash();
        }

        public static bool operator ==(VariantType one, VariantType two)
        {
            if ((object)one == null)
            {
                return (object)two == null;
            }
            return one.Equals(two);
        }

        public static bool operator !=(VariantType one, VariantType two)
        {
            return !(one == two);
        }

        /// <summary>
        /// Determines the first item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this returns the type of
        /// the key.
        /// 
        /// %NULL is returned in case of @type being %G_VARIANT_TYPE_UNIT.
        /// 
        /// This call, together with g_variant_type_next() provides an iterator
        /// interface over tuple and dictionary entry types.
        /// </remarks>
        /// <param name="type">
        /// a tuple or dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the first item type of @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_first( System.IntPtr type);

        /// <summary>
        /// Determines the first item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this returns the type of
        /// the key.
        /// 
        /// %NULL is returned in case of @type being %G_VARIANT_TYPE_UNIT.
        /// 
        /// This call, together with g_variant_type_next() provides an iterator
        /// interface over tuple and dictionary entry types.
        /// </remarks>
        /// <returns>
        /// the first item type of @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType First()
        {
            var ret = g_variant_type_first(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Frees a #GVariantType that was allocated with
        /// g_variant_type_copy(), g_variant_type_new() or one of the container
        /// type constructor functions.
        /// </summary>
        /// <remarks>
        /// In the case that @type is %NULL, this function does nothing.
        /// 
        /// Since 2.24
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType, or %NULL
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_variant_type_free( System.IntPtr type);

        /// <summary>
        /// Frees a #GVariantType that was allocated with
        /// g_variant_type_copy(), g_variant_type_new() or one of the container
        /// type constructor functions.
        /// </summary>
        /// <remarks>
        /// In the case that @type is %NULL, this function does nothing.
        /// 
        /// Since 2.24
        /// </remarks>
        protected override System.Void Free()
        {
            var ret = g_variant_type_free(Handle);
            return default(System.Void);
        }

        /// <summary>
        /// Returns the length of the type string corresponding to the given
        /// @type.  This function must be used to determine the valid extent of
        /// the memory region returned by g_variant_type_peek_string().
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the length of the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_type_get_string_length( System.IntPtr type);

        /// <summary>
        /// Returns the length of the type string corresponding to the given
        /// @type.  This function must be used to determine the valid extent of
        /// the memory region returned by g_variant_type_peek_string().
        /// </summary>
        /// <returns>
        /// the length of the corresponding type string
        /// 
        /// Since 2.24
        /// </returns>
        public System.UInt64 get_StringLength()
        {
            var ret = g_variant_type_get_string_length(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Hashes @type.
        /// </summary>
        /// <remarks>
        /// The argument type of @type is only #gconstpointer to allow use with
        /// #GHashTable without function pointer casting.  A valid
        /// #GVariantType must be provided.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the hash value
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_variant_type_hash( System.IntPtr type);

        /// <summary>
        /// Hashes @type.
        /// </summary>
        /// <remarks>
        /// The argument type of @type is only #gconstpointer to allow use with
        /// #GHashTable without function pointer casting.  A valid
        /// #GVariantType must be provided.
        /// </remarks>
        /// <returns>
        /// the hash value
        /// 
        /// Since 2.24
        /// </returns>
        protected System.UInt32 Hash()
        {
            var ret = g_variant_type_hash(Handle);
            return default(System.UInt32);
        }

        /// <summary>
        /// Determines if the given @type is an array type.  This is true if the
        /// type string for @type starts with an 'a'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is an array type -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is an array type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_array( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is an array type.  This is true if the
        /// type string for @type starts with an 'a'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is an array type -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is an array type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsArray()
        {
            var ret = g_variant_type_is_array(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is a basic type.
        /// </summary>
        /// <remarks>
        /// Basic types are booleans, bytes, integers, doubles, strings, object
        /// paths and signatures.
        /// 
        /// Only a basic type may be used as the key of a dictionary entry.
        /// 
        /// This function returns %FALSE for all indefinite types except
        /// %G_VARIANT_TYPE_BASIC.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a basic type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_basic( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is a basic type.
        /// </summary>
        /// <remarks>
        /// Basic types are booleans, bytes, integers, doubles, strings, object
        /// paths and signatures.
        /// 
        /// Only a basic type may be used as the key of a dictionary entry.
        /// 
        /// This function returns %FALSE for all indefinite types except
        /// %G_VARIANT_TYPE_BASIC.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a basic type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsBasic()
        {
            var ret = g_variant_type_is_basic(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is a container type.
        /// </summary>
        /// <remarks>
        /// Container types are any array, maybe, tuple, or dictionary
        /// entry types plus the variant type.
        /// 
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a container -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a container type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_container( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is a container type.
        /// </summary>
        /// <remarks>
        /// Container types are any array, maybe, tuple, or dictionary
        /// entry types plus the variant type.
        /// 
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a container -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a container type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsContainer()
        {
            var ret = g_variant_type_is_container(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is definite (ie: not indefinite).
        /// </summary>
        /// <remarks>
        /// A type is definite if its type string does not contain any indefinite
        /// type characters ('*', '?', or 'r').
        /// 
        /// A #GVariant instance may not have an indefinite type, so calling
        /// this function on the result of g_variant_get_type() will always
        /// result in %TRUE being returned.  Calling this function on an
        /// indefinite type like %G_VARIANT_TYPE_ARRAY, however, will result in
        /// %FALSE being returned.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is definite
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_definite( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is definite (ie: not indefinite).
        /// </summary>
        /// <remarks>
        /// A type is definite if its type string does not contain any indefinite
        /// type characters ('*', '?', or 'r').
        /// 
        /// A #GVariant instance may not have an indefinite type, so calling
        /// this function on the result of g_variant_get_type() will always
        /// result in %TRUE being returned.  Calling this function on an
        /// indefinite type like %G_VARIANT_TYPE_ARRAY, however, will result in
        /// %FALSE being returned.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is definite
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsDefinite()
        {
            var ret = g_variant_type_is_definite(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is a dictionary entry type.  This is
        /// true if the type string for @type starts with a '{'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a dictionary entry type --
        /// %G_VARIANT_TYPE_DICT_ENTRY, for example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a dictionary entry type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_dict_entry( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is a dictionary entry type.  This is
        /// true if the type string for @type starts with a '{'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a dictionary entry type --
        /// %G_VARIANT_TYPE_DICT_ENTRY, for example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a dictionary entry type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsDictEntry()
        {
            var ret = g_variant_type_is_dict_entry(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is a maybe type.  This is true if the
        /// type string for @type starts with an 'm'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a maybe type -- %G_VARIANT_TYPE_MAYBE, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a maybe type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_maybe( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is a maybe type.  This is true if the
        /// type string for @type starts with an 'm'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a maybe type -- %G_VARIANT_TYPE_MAYBE, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a maybe type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsMaybe()
        {
            var ret = g_variant_type_is_maybe(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Checks if @type is a subtype of @supertype.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE if @type is a subtype of @supertype.  All
        /// types are considered to be subtypes of themselves.  Aside from that,
        /// only indefinite types can have subtypes.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <param name="supertype">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a subtype of @supertype
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_subtype_of( System.IntPtr type,  System.IntPtr supertype);

        /// <summary>
        /// Checks if @type is a subtype of @supertype.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE if @type is a subtype of @supertype.  All
        /// types are considered to be subtypes of themselves.  Aside from that,
        /// only indefinite types can have subtypes.
        /// </remarks>
        /// <param name="supertype">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a subtype of @supertype
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean IsSubtypeOf( GISharp.GLib.VariantType supertype)
        {
            if (supertype == null)
            {
                throw new ArgumentNullException("supertype");
            }
            var ret = g_variant_type_is_subtype_of(Handle, supertype);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is a tuple type.  This is true if the
        /// type string for @type starts with a '(' or if @type is
        /// %G_VARIANT_TYPE_TUPLE.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a tuple type -- %G_VARIANT_TYPE_TUPLE, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a tuple type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_tuple( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is a tuple type.  This is true if the
        /// type string for @type starts with a '(' or if @type is
        /// %G_VARIANT_TYPE_TUPLE.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a tuple type -- %G_VARIANT_TYPE_TUPLE, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a tuple type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsTuple()
        {
            var ret = g_variant_type_is_tuple(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines if the given @type is the variant type.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is the variant type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_is_variant( System.IntPtr type);

        /// <summary>
        /// Determines if the given @type is the variant type.
        /// </summary>
        /// <returns>
        /// %TRUE if @type is the variant type
        /// 
        /// Since 2.24
        /// </returns>
        public System.Boolean get_IsVariant()
        {
            var ret = g_variant_type_is_variant(Handle);
            return default(System.Boolean);
        }

        /// <summary>
        /// Determines the key type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.  Other
        /// than the additional restriction, this call is equivalent to
        /// g_variant_type_first().
        /// </remarks>
        /// <param name="type">
        /// a dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the key type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_key( System.IntPtr type);

        /// <summary>
        /// Determines the key type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.  Other
        /// than the additional restriction, this call is equivalent to
        /// g_variant_type_first().
        /// </remarks>
        /// <returns>
        /// the key type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Key()
        {
            var ret = g_variant_type_key(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Determines the number of items contained in a tuple or
        /// dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this function will always
        /// return 2.
        /// </remarks>
        /// <param name="type">
        /// a tuple or dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the number of items in @type
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt64 g_variant_type_n_items( System.IntPtr type);

        /// <summary>
        /// Determines the number of items contained in a tuple or
        /// dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        /// 
        /// In the case of a dictionary entry type, this function will always
        /// return 2.
        /// </remarks>
        /// <returns>
        /// the number of items in @type
        /// 
        /// Since 2.24
        /// </returns>
        public System.UInt64 NItems()
        {
            var ret = g_variant_type_n_items(Handle);
            return default(System.UInt64);
        }

        /// <summary>
        /// Determines the next item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// @type must be the result of a previous call to
        /// g_variant_type_first() or g_variant_type_next().
        /// 
        /// If called on the key type of a dictionary entry then this call
        /// returns the value type.  If called on the value type of a dictionary
        /// entry then this call returns %NULL.
        /// 
        /// For tuples, %NULL is returned when @type is the last item in a tuple.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType from a previous call
        /// </param>
        /// <returns>
        /// the next #GVariantType after @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_next( System.IntPtr type);

        /// <summary>
        /// Determines the next item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// @type must be the result of a previous call to
        /// g_variant_type_first() or g_variant_type_next().
        /// 
        /// If called on the key type of a dictionary entry then this call
        /// returns the value type.  If called on the value type of a dictionary
        /// entry then this call returns %NULL.
        /// 
        /// For tuples, %NULL is returned when @type is the last item in a tuple.
        /// </remarks>
        /// <returns>
        /// the next #GVariantType after @type, or %NULL
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Next()
        {
            var ret = g_variant_type_next(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Returns the type string corresponding to the given @type.  The
        /// result is not nul-terminated; in order to determine its length you
        /// must call g_variant_type_get_string_length().
        /// </summary>
        /// <remarks>
        /// To get a nul-terminated string, see g_variant_type_dup_string().
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the corresponding type string (not nul-terminated)
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_peek_string( System.IntPtr type);

        /// <summary>
        /// Returns the type string corresponding to the given @type.  The
        /// result is not nul-terminated; in order to determine its length you
        /// must call g_variant_type_get_string_length().
        /// </summary>
        /// <remarks>
        /// To get a nul-terminated string, see g_variant_type_dup_string().
        /// </remarks>
        /// <returns>
        /// the corresponding type string (not nul-terminated)
        /// 
        /// Since 2.24
        /// </returns>
        public System.String PeekString()
        {
            var ret = g_variant_type_peek_string(Handle);
            return default(System.String);
        }

        /// <summary>
        /// Determines the value type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.
        /// </remarks>
        /// <param name="type">
        /// a dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the value type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_value( System.IntPtr type);

        /// <summary>
        /// Determines the value type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.
        /// </remarks>
        /// <returns>
        /// the value type of the dictionary entry
        /// 
        /// Since 2.24
        /// </returns>
        public GISharp.GLib.VariantType Value()
        {
            var ret = g_variant_type_value(Handle);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Constructs the type corresponding to an array of elements of the
        /// type @type.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new array #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_array( System.IntPtr element);

        /// <summary>
        /// Constructs the type corresponding to an array of elements of the
        /// type @type.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new array #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewArray( GISharp.GLib.VariantType element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            var ret = g_variant_type_new_array(element);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Constructs the type corresponding to a dictionary entry with a key
        /// of type @key and a value of type @value.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariantType
        /// </param>
        /// <param name="value">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new dictionary entry #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_dict_entry( System.IntPtr key,  System.IntPtr value);

        /// <summary>
        /// Constructs the type corresponding to a dictionary entry with a key
        /// of type @key and a value of type @value.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariantType
        /// </param>
        /// <param name="value">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new dictionary entry #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewDictEntry( GISharp.GLib.VariantType key,  GISharp.GLib.VariantType value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var ret = g_variant_type_new_dict_entry(key, value);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Constructs the type corresponding to a maybe instance containing
        /// type @type or Nothing.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new maybe #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_maybe( System.IntPtr element);

        /// <summary>
        /// Constructs the type corresponding to a maybe instance containing
        /// type @type or Nothing.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new maybe #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewMaybe( GISharp.GLib.VariantType element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            var ret = g_variant_type_new_maybe(element);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Constructs a new tuple type, from @items.
        /// </summary>
        /// <remarks>
        /// @length is the number of items in @items, or -1 to indicate that
        /// @items is %NULL-terminated.
        /// 
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="items">
        /// an array of #GVariantTypes, one for each item
        /// </param>
        /// <param name="length">
        /// the length of @items, or -1
        /// </param>
        /// <returns>
        /// a new tuple #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_new_tuple( System.IntPtr[] items,  System.Int32 length);

        /// <summary>
        /// Constructs a new tuple type, from @items.
        /// </summary>
        /// <remarks>
        /// @length is the number of items in @items, or -1 to indicate that
        /// @items is %NULL-terminated.
        /// 
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="items">
        /// an array of #GVariantTypes, one for each item
        /// </param>
        /// <returns>
        /// a new tuple #GVariantType
        /// 
        /// Since 2.24
        /// </returns>
        public static GISharp.GLib.VariantType NewTuple( GISharp.GLib.VariantType[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            var length = (System.Int32)items.Length;
            var ret = g_variant_type_new_tuple(items, length);
            return default(GISharp.GLib.VariantType);
        }

        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_variant_type_checked_( System.IntPtr arg0);

        public static GISharp.GLib.VariantType Checked( System.String arg0)
        {
            if (arg0 == null)
            {
                throw new ArgumentNullException("arg0");
            }
            var ret = g_variant_type_checked_(arg0);
            return default(GISharp.GLib.VariantType);
        }

        /// <summary>
        /// Checks if @type_string is a valid GVariant type string.  This call is
        /// equivalent to calling g_variant_type_string_scan() and confirming
        /// that the following character is a nul terminator.
        /// </summary>
        /// <param name="typeString">
        /// a pointer to any string
        /// </param>
        /// <returns>
        /// %TRUE if @type_string is exactly one valid type string
        /// 
        /// Since 2.24
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_string_is_valid( System.IntPtr typeString);

        /// <summary>
        /// Checks if @type_string is a valid GVariant type string.  This call is
        /// equivalent to calling g_variant_type_string_scan() and confirming
        /// that the following character is a nul terminator.
        /// </summary>
        /// <param name="typeString">
        /// a pointer to any string
        /// </param>
        /// <returns>
        /// %TRUE if @type_string is exactly one valid type string
        /// 
        /// Since 2.24
        /// </returns>
        public static System.Boolean StringIsValid( System.String typeString)
        {
            if (typeString == null)
            {
                throw new ArgumentNullException("typeString");
            }
            var ret = g_variant_type_string_is_valid(typeString);
            return default(System.Boolean);
        }

        /// <summary>
        /// Scan for a single complete and valid GVariant type string in @string.
        /// The memory pointed to by @limit (or bytes beyond it) is never
        /// accessed.
        /// </summary>
        /// <remarks>
        /// If a valid type string is found, @endptr is updated to point to the
        /// first character past the end of the string that was found and %TRUE
        /// is returned.
        /// 
        /// If there is no valid type string starting at @string, or if the type
        /// string does not end before @limit then %FALSE is returned.
        /// 
        /// For the simple case of checking if a string is a valid type string,
        /// see g_variant_type_string_is_valid().
        /// </remarks>
        /// <param name="string">
        /// a pointer to any string
        /// </param>
        /// <param name="limit">
        /// the end of @string, or %NULL
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if a valid type string was found
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_variant_type_string_scan( System.IntPtr @string,  System.IntPtr limit, out System.IntPtr endptr);

        /// <summary>
        /// Scan for a single complete and valid GVariant type string in @string.
        /// The memory pointed to by @limit (or bytes beyond it) is never
        /// accessed.
        /// </summary>
        /// <remarks>
        /// If a valid type string is found, @endptr is updated to point to the
        /// first character past the end of the string that was found and %TRUE
        /// is returned.
        /// 
        /// If there is no valid type string starting at @string, or if the type
        /// string does not end before @limit then %FALSE is returned.
        /// 
        /// For the simple case of checking if a string is a valid type string,
        /// see g_variant_type_string_is_valid().
        /// </remarks>
        /// <param name="string">
        /// a pointer to any string
        /// </param>
        /// <param name="limit">
        /// the end of @string, or %NULL
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if a valid type string was found
        /// </returns>
        [GISharp.Core.Since("2.24")]
        public static System.Boolean StringScan( System.String @string,  System.String limit, out System.String endptr)
        {
            if (@string == null)
            {
                throw new ArgumentNullException("@string");
            }
            var ret = g_variant_type_string_scan(@string, limit, endptr);
            return default(System.Boolean);
        }
    }

    public static partial class Idle
    {
        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns %FALSE it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// This internally creates a main loop source using g_idle_source_new()
        /// and attaches it to the main loop context using g_source_attach().
        /// You can do these steps manually if you need greater control.
        /// </remarks>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        ///            range between #G_PRIORITY_DEFAULT_IDLE and #G_PRIORITY_HIGH_IDLE.
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the idle is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_idle_add_full( System.Int32 priority,  System.IntPtr function,  System.IntPtr data,  System.IntPtr notify);

        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns %FALSE it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// This internally creates a main loop source using g_idle_source_new()
        /// and attaches it to the main loop context using g_source_attach().
        /// You can do these steps manually if you need greater control.
        /// </remarks>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        ///            range between #G_PRIORITY_DEFAULT_IDLE and #G_PRIORITY_HIGH_IDLE.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        public static System.UInt32 Add( GISharp.GLib.SourceFunc function,  System.Int32 priority = Priority.Default)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }
            var ret = g_idle_add_full(priority, function, data, notify);
            return default(System.UInt32);
        }

        /// <summary>
        /// Removes the idle function with the given data.
        /// </summary>
        /// <param name="data">
        /// the data for the idle source's callback.
        /// </param>
        /// <returns>
        /// %TRUE if an idle source was found and removed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Boolean g_idle_remove_by_data( System.IntPtr data);

        /// <summary>
        /// Removes the idle function with the given data.
        /// </summary>
        /// <param name="data">
        /// the data for the idle source's callback.
        /// </param>
        /// <returns>
        /// %TRUE if an idle source was found and removed.
        /// </returns>
        public static System.Boolean RemoveByData( System.IntPtr data)
        {
            var ret = g_idle_remove_by_data(data);
            return default(System.Boolean);
        }

        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed. Note that the default priority for idle sources is
        /// %G_PRIORITY_DEFAULT_IDLE, as compared to other sources which
        /// have a default priority of %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <returns>
        /// the newly-created idle source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_idle_source_new();

        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed. Note that the default priority for idle sources is
        /// %G_PRIORITY_DEFAULT_IDLE, as compared to other sources which
        /// have a default priority of %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <returns>
        /// the newly-created idle source
        /// </returns>
        public static GISharp.GLib.Source SourceNew()
        {
            var ret = g_idle_source_new();
            return default(GISharp.GLib.Source);
        }
    }

    public static partial class Log
    {
        /// <summary>
        /// Defines the log domain.
        /// </summary>
        /// <remarks>
        /// For applications, this is typically left as the default %NULL
        /// (or "") domain. Libraries should define this so that any messages
        /// which they log can be differentiated from messages from other
        /// libraries and application code. But be careful not to define
        /// it in any public header files.
        /// 
        /// For example, GTK+ uses this in its Makefile.am:
        /// |[
        /// INCLUDES = -DG_LOG_DOMAIN=\"Gtk\"
        /// ]|
        /// </remarks>
        public const System.SByte Domain = 0;

        /// <summary>
        /// GLib log levels that are considered fatal by default.
        /// </summary>
        public const System.Int32 FatalMask = 0;

        /// <summary>
        /// Log levels below 1&lt;&lt;G_LOG_LEVEL_USER_SHIFT are used by GLib.
        /// Higher bits can be used for user-defined log levels.
        /// </summary>
        public const System.Int32 LevelUserShift = 8;

        /// <summary>
        /// The default log handler set up by GLib; g_log_set_default_handler()
        /// allows to install an alternate default log handler.
        /// This is used if no log handler has been set for the particular log
        /// domain and log level combination. It outputs the message to stderr
        /// or stdout and if the log level is fatal it calls abort(). It automatically
        /// prints a new-line character after the message, so one does not need to be
        /// manually included in @message.
        /// </summary>
        /// <remarks>
        /// The behavior of this log handler can be influenced by a number of
        /// environment variables:
        /// 
        /// - `G_MESSAGES_PREFIXED`: A :-separated list of log levels for which
        ///   messages should be prefixed by the program name and PID of the
        ///   aplication.
        /// 
        /// - `G_MESSAGES_DEBUG`: A space-separated list of log domains for
        ///   which debug and informational messages are printed. By default
        ///   these messages are not printed.
        /// 
        /// stderr is used for levels %G_LOG_LEVEL_ERROR, %G_LOG_LEVEL_CRITICAL,
        /// %G_LOG_LEVEL_WARNING and %G_LOG_LEVEL_MESSAGE. stdout is used for
        /// the rest.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain of the message
        /// </param>
        /// <param name="logLevel">
        /// the level of the message
        /// </param>
        /// <param name="message">
        /// the message
        /// </param>
        /// <param name="unusedData">
        /// data passed from g_log() which is unused
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_log_default_handler( System.IntPtr logDomain,  System.IntPtr logLevel,  System.IntPtr message,  System.IntPtr unusedData);

        /// <summary>
        /// The default log handler set up by GLib; g_log_set_default_handler()
        /// allows to install an alternate default log handler.
        /// This is used if no log handler has been set for the particular log
        /// domain and log level combination. It outputs the message to stderr
        /// or stdout and if the log level is fatal it calls abort(). It automatically
        /// prints a new-line character after the message, so one does not need to be
        /// manually included in @message.
        /// </summary>
        /// <remarks>
        /// The behavior of this log handler can be influenced by a number of
        /// environment variables:
        /// 
        /// - `G_MESSAGES_PREFIXED`: A :-separated list of log levels for which
        ///   messages should be prefixed by the program name and PID of the
        ///   aplication.
        /// 
        /// - `G_MESSAGES_DEBUG`: A space-separated list of log domains for
        ///   which debug and informational messages are printed. By default
        ///   these messages are not printed.
        /// 
        /// stderr is used for levels %G_LOG_LEVEL_ERROR, %G_LOG_LEVEL_CRITICAL,
        /// %G_LOG_LEVEL_WARNING and %G_LOG_LEVEL_MESSAGE. stdout is used for
        /// the rest.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain of the message
        /// </param>
        /// <param name="logLevel">
        /// the level of the message
        /// </param>
        /// <param name="message">
        /// the message
        /// </param>
        /// <param name="unusedData">
        /// data passed from g_log() which is unused
        /// </param>
        public static System.Void DefaultHandler( System.String logDomain,  GISharp.GLib.LogLevelFlags logLevel,  System.String message,  System.IntPtr unusedData)
        {
            if (logDomain == null)
            {
                throw new ArgumentNullException("logDomain");
            }
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            var ret = g_log_default_handler(logDomain, logLevel, message, unusedData);
            return default(System.Void);
        }

        /// <summary>
        /// Removes the log handler.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="handlerId">
        /// the id of the handler, which was returned
        ///     in g_log_set_handler()
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_log_remove_handler( System.IntPtr logDomain,  System.UInt32 handlerId);

        /// <summary>
        /// Removes the log handler.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="handlerId">
        /// the id of the handler, which was returned
        ///     in g_log_set_handler()
        /// </param>
        public static System.Void RemoveHandler( System.String logDomain,  System.UInt32 handlerId)
        {
            if (logDomain == null)
            {
                throw new ArgumentNullException("logDomain");
            }
            var ret = g_log_remove_handler(logDomain, handlerId);
            return default(System.Void);
        }

        /// <summary>
        /// Sets the message levels which are always fatal, in any log domain.
        /// When a message with any of these levels is logged the program terminates.
        /// You can only set the levels defined by GLib to be fatal.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// You can also make some message levels fatal at runtime by setting
        /// the `G_DEBUG` environment variable (see
        /// [Running GLib Applications](glib-running.html)).
        /// </remarks>
        /// <param name="fatalMask">
        /// the mask containing bits set for each level
        ///     of error which is to be fatal
        /// </param>
        /// <returns>
        /// the old fatal mask
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_log_set_always_fatal( System.IntPtr fatalMask);

        /// <summary>
        /// Sets the message levels which are always fatal, in any log domain.
        /// When a message with any of these levels is logged the program terminates.
        /// You can only set the levels defined by GLib to be fatal.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// You can also make some message levels fatal at runtime by setting
        /// the `G_DEBUG` environment variable (see
        /// [Running GLib Applications](glib-running.html)).
        /// </remarks>
        /// <param name="fatalMask">
        /// the mask containing bits set for each level
        ///     of error which is to be fatal
        /// </param>
        /// <returns>
        /// the old fatal mask
        /// </returns>
        public static GISharp.GLib.LogLevelFlags SetAlwaysFatal( GISharp.GLib.LogLevelFlags fatalMask)
        {
            var ret = g_log_set_always_fatal(fatalMask);
            return default(GISharp.GLib.LogLevelFlags);
        }

        /// <summary>
        /// Installs a default log handler which is used if no
        /// log handler has been set for the particular log domain
        /// and log level combination. By default, GLib uses
        /// g_log_default_handler() as default log handler.
        /// </summary>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <param name="userData">
        /// data passed to the log handler
        /// </param>
        /// <returns>
        /// the previous default log handler
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_log_set_default_handler( System.IntPtr logFunc,  System.IntPtr userData);

        /// <summary>
        /// Installs a default log handler which is used if no
        /// log handler has been set for the particular log domain
        /// and log level combination. By default, GLib uses
        /// g_log_default_handler() as default log handler.
        /// </summary>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <returns>
        /// the previous default log handler
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public static GISharp.GLib.LogFunc SetDefaultHandler( GISharp.GLib.LogFunc logFunc)
        {
            if (logFunc == null)
            {
                throw new ArgumentNullException("logFunc");
            }
            var ret = g_log_set_default_handler(logFunc, userData);
            return default(GISharp.GLib.LogFunc);
        }

        /// <summary>
        /// Sets the log levels which are fatal in the given domain.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="fatalMask">
        /// the new fatal mask
        /// </param>
        /// <returns>
        /// the old fatal mask for the log domain
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_log_set_fatal_mask( System.IntPtr logDomain,  System.IntPtr fatalMask);

        /// <summary>
        /// Sets the log levels which are fatal in the given domain.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="fatalMask">
        /// the new fatal mask
        /// </param>
        /// <returns>
        /// the old fatal mask for the log domain
        /// </returns>
        public static GISharp.GLib.LogLevelFlags SetFatalMask( System.String logDomain,  GISharp.GLib.LogLevelFlags fatalMask)
        {
            if (logDomain == null)
            {
                throw new ArgumentNullException("logDomain");
            }
            var ret = g_log_set_fatal_mask(logDomain, fatalMask);
            return default(GISharp.GLib.LogLevelFlags);
        }

        /// <summary>
        /// Sets the log handler for a domain and a set of log levels.
        /// To handle fatal and recursive messages the @log_levels parameter
        /// must be combined with the #G_LOG_FLAG_FATAL and #G_LOG_FLAG_RECURSION
        /// bit flags.
        /// </summary>
        /// <remarks>
        /// Note that since the #G_LOG_LEVEL_ERROR log level is always fatal, if
        /// you want to set a handler for this log level you must combine it with
        /// #G_LOG_FLAG_FATAL.
        /// 
        /// Here is an example for adding a log handler for all warning messages
        /// in the default domain:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler (NULL, G_LOG_LEVEL_WARNING | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all critical messages from GTK+:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("Gtk", G_LOG_LEVEL_CRITICAL | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all messages from GLib:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("GLib", G_LOG_LEVEL_MASK | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain, or %NULL for the default ""
        ///     application domain
        /// </param>
        /// <param name="logLevels">
        /// the log levels to apply the log handler for.
        ///     To handle fatal and recursive messages as well, combine
        ///     the log levels with the #G_LOG_FLAG_FATAL and
        ///     #G_LOG_FLAG_RECURSION bit flags.
        /// </param>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <param name="userData">
        /// data passed to the log handler
        /// </param>
        /// <returns>
        /// the id of the new handler
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_log_set_handler( System.IntPtr logDomain,  System.IntPtr logLevels,  System.IntPtr logFunc,  System.IntPtr userData);

        /// <summary>
        /// Sets the log handler for a domain and a set of log levels.
        /// To handle fatal and recursive messages the @log_levels parameter
        /// must be combined with the #G_LOG_FLAG_FATAL and #G_LOG_FLAG_RECURSION
        /// bit flags.
        /// </summary>
        /// <remarks>
        /// Note that since the #G_LOG_LEVEL_ERROR log level is always fatal, if
        /// you want to set a handler for this log level you must combine it with
        /// #G_LOG_FLAG_FATAL.
        /// 
        /// Here is an example for adding a log handler for all warning messages
        /// in the default domain:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler (NULL, G_LOG_LEVEL_WARNING | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all critical messages from GTK+:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("Gtk", G_LOG_LEVEL_CRITICAL | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all messages from GLib:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("GLib", G_LOG_LEVEL_MASK | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain, or %NULL for the default ""
        ///     application domain
        /// </param>
        /// <param name="logLevels">
        /// the log levels to apply the log handler for.
        ///     To handle fatal and recursive messages as well, combine
        ///     the log levels with the #G_LOG_FLAG_FATAL and
        ///     #G_LOG_FLAG_RECURSION bit flags.
        /// </param>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <returns>
        /// the id of the new handler
        /// </returns>
        public static System.UInt32 SetHandler( System.String logDomain,  GISharp.GLib.LogLevelFlags logLevels,  GISharp.GLib.LogFunc logFunc)
        {
            if (logFunc == null)
            {
                throw new ArgumentNullException("logFunc");
            }
            var ret = g_log_set_handler(logDomain, logLevels, logFunc, userData);
            return default(System.UInt32);
        }

        /// <summary>
        /// Logs an error or debugging message.
        /// </summary>
        /// <remarks>
        /// If the log level has been set as fatal, the abort()
        /// function is called to terminate the program.
        /// 
        /// If g_log_default_handler() is used as the log handler function, a new-line
        /// character will automatically be appended to @..., and need not be entered
        /// manually.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="logLevel">
        /// the log level
        /// </param>
        /// <param name="format">
        /// the message format. See the printf() documentation
        /// </param>
        /// <param name="args">
        /// the parameters to insert into the format string
        /// </param>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.Void g_logv( System.IntPtr logDomain,  System.IntPtr logLevel,  System.IntPtr format,  System.IntPtr args);

        /// <summary>
        /// Logs an error or debugging message.
        /// </summary>
        /// <remarks>
        /// If the log level has been set as fatal, the abort()
        /// function is called to terminate the program.
        /// 
        /// If g_log_default_handler() is used as the log handler function, a new-line
        /// character will automatically be appended to @..., and need not be entered
        /// manually.
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="logLevel">
        /// the log level
        /// </param>
        /// <param name="format">
        /// the message format. See the printf() documentation
        /// </param>
        /// <param name="args">
        /// the parameters to insert into the format string
        /// </param>
        public static System.Void Logv( System.String logDomain,  GISharp.GLib.LogLevelFlags logLevel,  System.String format,  System.Object[] args)
        {
            if (logDomain == null)
            {
                throw new ArgumentNullException("logDomain");
            }
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }
            var ret = g_logv(logDomain, logLevel, format, args);
            return default(System.Void);
        }
    }

    public static partial class Priority
    {
        /// <summary>
        /// Use this for default priority event sources.
        /// </summary>
        /// <remarks>
        /// In GLib this priority is used when adding timeout functions
        /// with g_timeout_add(). In GDK this priority is used for events
        /// from the X server.
        /// </remarks>
        public const System.Int32 Default = 0;

        /// <summary>
        /// Use this for default priority idle functions.
        /// </summary>
        /// <remarks>
        /// In GLib this priority is used when adding idle functions with
        /// g_idle_add().
        /// </remarks>
        public const System.Int32 DefaultIdle = 200;

        /// <summary>
        /// Use this for high priority event sources.
        /// </summary>
        /// <remarks>
        /// It is not used within GLib or GTK+.
        /// </remarks>
        public const System.Int32 High = -100;

        /// <summary>
        /// Use this for high priority idle functions.
        /// </summary>
        /// <remarks>
        /// GTK+ uses #G_PRIORITY_HIGH_IDLE + 10 for resizing operations,
        /// and #G_PRIORITY_HIGH_IDLE + 20 for redrawing operations. (This is
        /// done to ensure that any pending resizes are processed before any
        /// pending redraws, so that widgets are not redrawn twice unnecessarily.)
        /// </remarks>
        public const System.Int32 HighIdle = 100;

        /// <summary>
        /// Use this for very low priority background tasks.
        /// </summary>
        /// <remarks>
        /// It is not used within GLib or GTK+.
        /// </remarks>
        public const System.Int32 Low = 300;
    }

    public static partial class Timeout
    {
        /// <summary>
        /// Sets a function to be called at regular intervals, with the given
        /// priority.  The function is called repeatedly until it returns
        /// %FALSE, at which point the timeout is automatically destroyed and
        /// the function will not be called again.  The @notify function is
        /// called when the timeout is destroyed.  The first call to the
        /// function will be at the end of the first @interval.
        /// </summary>
        /// <remarks>
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given interval
        /// (it does not try to 'catch up' time lost in delays).
        /// 
        /// This internally creates a main loop source using g_timeout_source_new()
        /// and attaches it to the main loop context using g_source_attach(). You can
        /// do these steps manually if you need greater control.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="interval">
        /// the time between calls to the function, in milliseconds
        ///             (1/1000ths of a second)
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the timeout is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_timeout_add_full( System.Int32 priority,  System.UInt32 interval,  System.IntPtr function,  System.IntPtr data,  System.IntPtr notify);

        /// <summary>
        /// Sets a function to be called at regular intervals, with the given
        /// priority.  The function is called repeatedly until it returns
        /// %FALSE, at which point the timeout is automatically destroyed and
        /// the function will not be called again.  The @notify function is
        /// called when the timeout is destroyed.  The first call to the
        /// function will be at the end of the first @interval.
        /// </summary>
        /// <remarks>
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given interval
        /// (it does not try to 'catch up' time lost in delays).
        /// 
        /// This internally creates a main loop source using g_timeout_source_new()
        /// and attaches it to the main loop context using g_source_attach(). You can
        /// do these steps manually if you need greater control.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the time between calls to the function, in milliseconds
        ///             (1/1000ths of a second)
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        public static System.UInt32 Add( System.UInt32 interval,  GISharp.GLib.SourceFunc function,  System.Int32 priority = Priority.Default)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }
            var ret = g_timeout_add_full(priority, interval, function, data, notify);
            return default(System.UInt32);
        }

        /// <summary>
        /// Sets a function to be called at regular intervals, with @priority.
        /// The function is called repeatedly until it returns %FALSE, at which
        /// point the timeout is automatically destroyed and the function will
        /// not be called again.
        /// </summary>
        /// <remarks>
        /// Unlike g_timeout_add(), this function operates at whole second granularity.
        /// The initial starting point of the timer is determined by the implementation
        /// and the implementation is expected to group multiple timers together so that
        /// they fire all at the same time.
        /// To allow this grouping, the @interval to the first timer is rounded
        /// and can deviate up to one second from the specified interval.
        /// Subsequent timer iterations will generally run at the specified interval.
        /// 
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given @interval
        /// 
        /// If you want timing more precise than whole seconds, use g_timeout_add()
        /// instead.
        /// 
        /// The grouping of timers to fire at the same time results in a more power
        /// and CPU efficient behavior so if your timer is in multiples of seconds
        /// and you don't require the first timer exactly one second from now, the
        /// use of g_timeout_add_seconds() is preferred over g_timeout_add().
        /// 
        /// This internally creates a main loop source using
        /// g_timeout_source_new_seconds() and attaches it to the main loop context
        /// using g_source_attach(). You can do these steps manually if you need
        /// greater control.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="interval">
        /// the time between calls to the function, in seconds
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the timeout is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_timeout_add_seconds_full( System.Int32 priority,  System.UInt32 interval,  System.IntPtr function,  System.IntPtr data,  System.IntPtr notify);

        /// <summary>
        /// Sets a function to be called at regular intervals, with @priority.
        /// The function is called repeatedly until it returns %FALSE, at which
        /// point the timeout is automatically destroyed and the function will
        /// not be called again.
        /// </summary>
        /// <remarks>
        /// Unlike g_timeout_add(), this function operates at whole second granularity.
        /// The initial starting point of the timer is determined by the implementation
        /// and the implementation is expected to group multiple timers together so that
        /// they fire all at the same time.
        /// To allow this grouping, the @interval to the first timer is rounded
        /// and can deviate up to one second from the specified interval.
        /// Subsequent timer iterations will generally run at the specified interval.
        /// 
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given @interval
        /// 
        /// If you want timing more precise than whole seconds, use g_timeout_add()
        /// instead.
        /// 
        /// The grouping of timers to fire at the same time results in a more power
        /// and CPU efficient behavior so if your timer is in multiples of seconds
        /// and you don't require the first timer exactly one second from now, the
        /// use of g_timeout_add_seconds() is preferred over g_timeout_add().
        /// 
        /// This internally creates a main loop source using
        /// g_timeout_source_new_seconds() and attaches it to the main loop context
        /// using g_source_attach(). You can do these steps manually if you need
        /// greater control.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the time between calls to the function, in seconds
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public static System.UInt32 AddSeconds( System.UInt32 interval,  GISharp.GLib.SourceFunc function,  System.Int32 priority = Priority.Default)
        {
            if (function == null)
            {
                throw new ArgumentNullException("function");
            }
            var ret = g_timeout_add_seconds_full(priority, interval, function, data, notify);
            return default(System.UInt32);
        }

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in milliseconds.
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_timeout_source_new( System.UInt32 interval);

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in milliseconds.
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        public static GISharp.GLib.Source SourceNew( System.UInt32 interval)
        {
            var ret = g_timeout_source_new(interval);
            return default(GISharp.GLib.Source);
        }

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The scheduling granularity/accuracy of this timeout source will be
        /// in seconds.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in seconds
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_timeout_source_new_seconds( System.UInt32 interval);

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The scheduling granularity/accuracy of this timeout source will be
        /// in seconds.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in seconds
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [GISharp.Core.Since("2.14")]
        public static GISharp.GLib.Source SourceNewSeconds( System.UInt32 interval)
        {
            var ret = g_timeout_source_new_seconds(interval);
            return default(GISharp.GLib.Source);
        }
    }

    public static partial class UnixSignal
    {
        /// <summary>
        /// A convenience function for g_unix_signal_source_new(), which
        /// attaches to the default #GMainContext.  You can remove the watch
        /// using g_source_remove().
        /// </summary>
        /// <param name="priority">
        /// the priority of the signal source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="signum">
        /// Signal number
        /// </param>
        /// <param name="handler">
        /// Callback
        /// </param>
        /// <param name="userData">
        /// Data for @handler
        /// </param>
        /// <param name="notify">
        /// #GDestroyNotify for @handler
        /// </param>
        /// <returns>
        /// An ID (greater than 0) for the event source
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.UInt32 g_unix_signal_add_full( System.Int32 priority,  System.Int32 signum,  System.IntPtr handler,  System.IntPtr userData,  System.IntPtr notify);

        /// <summary>
        /// A convenience function for g_unix_signal_source_new(), which
        /// attaches to the default #GMainContext.  You can remove the watch
        /// using g_source_remove().
        /// </summary>
        /// <param name="priority">
        /// the priority of the signal source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="signum">
        /// Signal number
        /// </param>
        /// <param name="handler">
        /// Callback
        /// </param>
        /// <returns>
        /// An ID (greater than 0) for the event source
        /// </returns>
        [GISharp.Core.Since("2.30")]
        public static System.UInt32 Add( System.Int32 priority,  System.Int32 signum,  GISharp.GLib.SourceFunc handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }
            var ret = g_unix_signal_add_full(priority, signum, handler, userData, notify);
            return default(System.UInt32);
        }

        /// <summary>
        /// Create a #GSource that will be dispatched upon delivery of the UNIX
        /// signal @signum.  In GLib versions before 2.36, only `SIGHUP`, `SIGINT`,
        /// `SIGTERM` can be monitored.  In GLib 2.36, `SIGUSR1` and `SIGUSR2`
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked g_unix_signal_source_new().
        /// 
        /// For example, an effective use of this function is to handle `SIGTERM`
        /// cleanly; flushing any outstanding files, and then calling
        /// g_main_loop_quit ().  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created #GSource
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr g_unix_signal_source_new( System.Int32 signum);

        /// <summary>
        /// Create a #GSource that will be dispatched upon delivery of the UNIX
        /// signal @signum.  In GLib versions before 2.36, only `SIGHUP`, `SIGINT`,
        /// `SIGTERM` can be monitored.  In GLib 2.36, `SIGUSR1` and `SIGUSR2`
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked g_unix_signal_source_new().
        /// 
        /// For example, an effective use of this function is to handle `SIGTERM`
        /// cleanly; flushing any outstanding files, and then calling
        /// g_main_loop_quit ().  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created #GSource
        /// </returns>
        [GISharp.Core.Since("2.30")]
        public static GISharp.GLib.Source SourceNew( System.Int32 signum)
        {
            var ret = g_unix_signal_source_new(signum);
            return default(GISharp.GLib.Source);
        }
    }

    public static partial class Version
    {
        /// <summary>
        /// The major version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #glib_major_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        public const System.Int32 Major = 2;

        /// <summary>
        /// The micro version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_micro_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        public const System.Int32 Micro = 1;

        /// <summary>
        /// The minor version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_minor_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        public const System.Int32 Minor = 42;

        /// <summary>
        /// A macro that should be defined by the user prior to including
        /// the glib.h header.
        /// The definition should be one of the predefined GLib version
        /// macros: %GLIB_VERSION_2_26, %GLIB_VERSION_2_28,...
        /// </summary>
        /// <remarks>
        /// This macro defines the earliest version of GLib that the package is
        /// required to be able to compile against.
        /// 
        /// If the compiler is configured to warn about the use of deprecated
        /// functions, then using functions that were deprecated in version
        /// %GLIB_VERSION_MIN_REQUIRED or earlier will cause warnings (but
        /// using functions deprecated in later releases will not).
        /// </remarks>
        [GISharp.Core.Since("2.32")]
        public const System.Int32 MinRequired = 2;

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [DllImport(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]
        static extern System.IntPtr glib_check_version( System.UInt32 requiredMajor,  System.UInt32 requiredMinor,  System.UInt32 requiredMicro);

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Core.Since("2.6")]
        public static System.String Check( System.UInt32 requiredMajor,  System.UInt32 requiredMinor,  System.UInt32 requiredMicro)
        {
            var ret = glib_check_version(requiredMajor, requiredMinor, requiredMicro);
            return default(System.String);
        }
    }
}