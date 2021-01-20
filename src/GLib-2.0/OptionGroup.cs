// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>


using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using StringList = System.Collections.Generic.List<GISharp.Lib.GLib.Utf8>;
using ArgList = System.Collections.Generic.List<System.IntPtr>;
using CallbackList = System.Collections.Generic.List<System.Action>;
using DestroyList = System.Collections.Generic.List<(System.IntPtr, System.IntPtr)>;

namespace GISharp.Lib.GLib
{
    partial class OptionGroup
    {
        static readonly unsafe UnmanagedOptionParseFunc postParseFunc_ = OnParsed;

        // FIXME: we will have problems with userData being null if an
        // OptionGroup is marshaled from unmanaged code
        readonly UserData userData = default!;

        class UserData
        {
            public StringList Strings { get; } = new();
            public ArgList Args { get; } = new();
            public CallbackList Callbacks { get; } = new();
            public DestroyList DestroyCallbacks { get; } = new();
        }

        static (IntPtr, UserData) New(UnownedUtf8 name, UnownedUtf8 description, UnownedUtf8 helpDescription)
        {
            var name_ = name.Handle;
            var description_ = description.Handle;
            var helpDescription_ = helpDescription.Handle;
            var userData = new UserData();
            var userData_ = (IntPtr)GCHandle.Alloc(userData);
            var ret = g_option_group_new(name_, description_, helpDescription_, userData_, destroy_);
            g_option_group_set_parse_hooks(ret, null, postParseFunc_);
            return (ret, userData);
        }

        OptionGroup(ValueTuple<IntPtr, UserData> handleAndUserData)
            : base(_GType, handleAndUserData.Item1, Transfer.Full)
        {
            userData = handleAndUserData.Item2;
        }

        /// <summary>
        /// Creates a new <see cref="OptionGroup"/>.
        /// </summary>
        /// <param name="name">
        /// the name for the option group, this is used to provide
        /// help for the options in this group with <c>--help-</c><paramref name="name"/>
        /// </param>
        /// <param name="description">
        /// a description for this group to be shown in
        /// <c>--help</c>. This string is translated using the translation
        /// domain or translation function of the group
        /// </param>
        /// <param name="helpDescription">
        /// a description for the <c>--help-</c><paramref name="name"/> option.
        /// This string is translated using the translation domain or translation function
        /// of the group
        /// </param>
        [Since("2.6")]
        public OptionGroup(UnownedUtf8 name, UnownedUtf8 description, UnownedUtf8 helpDescription)
            : this(New(name, description, helpDescription))
        {
        }

        /// <summary>
        /// Allocates an unmanged string and returns the pointer. A managed
        /// proxy is saved in a list so that it can be freed later.
        /// </summary>
        IntPtr AllocString(string str)
        {
            var utf8 = (Utf8)str;
            userData.Strings.Add(utf8);
            return utf8?.Handle ?? IntPtr.Zero;
        }

        /// <summary>
        /// Allocates variable of the specified size and returns the pointer to
        /// it. The pointer is also stored so that it can be freed later.
        /// </summary>
        IntPtr AllocArg(int size)
        {
            var ptr = GMarshal.Alloc0(size);
            userData.Args.Add(ptr);
            return ptr;
        }

        unsafe void AddEntry(OptionEntry entry)
        {
            using var array = new Array<OptionEntry>(true, false, 1) { entry };
            ref readonly var entries_ = ref MemoryMarshal.GetReference(array.Data);
            g_option_group_add_entries(Handle, entries_);
        }

        /// <summary>
        /// Adds a flag option
        /// </summary>
        public void AddFlag(string longName, char shortName, Action<bool> callback, string description, OptionFlags flags = OptionFlags.None)
        {
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var arg_ = AllocArg(sizeof(bool));

            userData.Callbacks.Add(() => {
                var arg = Marshal.PtrToStructure<bool>(arg_);
                callback(arg);
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.None,
                arg_,
                description_,
                IntPtr.Zero
            ));
        }

        /// <summary>
        /// Adds a string option
        /// </summary>
        public void AddString(string longName, char shortName, Action<Utf8> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(IntPtr.Size);

            userData.Callbacks.Add(() => {
                var arg = Marshal.ReadIntPtr(arg_);
                var str = new Utf8(arg, Transfer.Full);
                callback(str);
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.String,
                arg_,
                description_,
                argDescription_
            ));
        }

        /// <summary>
        /// Adds an integer option
        /// </summary>
        public void AddInt(string longName, char shortName, Action<int> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(sizeof(int));

            userData.Callbacks.Add(() => {
                var arg = Marshal.ReadInt32(arg_);
                callback(arg);
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.Int,
                arg_,
                description_,
                argDescription_
            ));
        }

        /// <summary>
        /// Adds a filename option
        /// </summary>
        public void AddFilename(string longName, char shortName, Action<Filename> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(IntPtr.Size);

            userData.Callbacks.Add(() => {
                var arg = Marshal.ReadIntPtr(arg_);
                var filename = new Filename(arg, Transfer.Full);
                callback(filename);
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.Filename,
                arg_,
                description_,
                argDescription_
            ));
        }

        /// <summary>
        /// Adds a string array option
        /// </summary>
        public void AddStringArray(string longName, char shortName, Action<Strv> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(IntPtr.Size);

            userData.Callbacks.Add(() => {
                var arg = Marshal.ReadIntPtr(arg_);
                var strv = new Strv(arg, Transfer.Full);
                callback(strv);
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.StringArray,
                arg_,
                description_,
                argDescription_
            ));
        }

        /// <summary>
        /// Adds a filename array option
        /// </summary>
        public void AddFilenameArray(string longName, char shortName, Action<FilenameArray> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(IntPtr.Size);

            userData.Callbacks.Add(() => {
                var arg = Marshal.ReadIntPtr(arg_);
                var strv = new FilenameArray(arg, Transfer.Full);
                callback(strv);
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.FilenameArray,
                arg_,
                description_,
                argDescription_
            ));
        }

        /// <summary>
        /// Adds a double option
        /// </summary>
        public void AddDouble(string longName, char shortName, Action<double> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(sizeof(double));

            userData.Callbacks.Add(() => {
                var arg = Marshal.PtrToStructure<double>(arg_);
                callback(arg);
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.Double,
                arg_,
                description_,
                argDescription_
            ));
        }

        /// <summary>
        /// Adds a callback option
        /// </summary>
        public void AddCallback(string longName, char shortName, OptionArgFunc callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription);
            var (callback_, destroy_, data_) = OptionArgFuncMarshal.ToUnmanagedFunctionPointer(callback, CallbackScope.Notified);
            userData.DestroyCallbacks.Add((destroy_, data_));

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.Callback,
                callback_,
                description_,
                argDescription_
            ));
        }

        static readonly UnmanagedDestroyNotify DestroyUserDataDelegate = DestroyUserData;
        static readonly IntPtr destroy_ = Marshal.GetFunctionPointerForDelegate(DestroyUserDataDelegate);
        static void DestroyUserData(IntPtr data_)
        {
            try {
                var gcHandle = (GCHandle)data_;
                var userData = (UserData)gcHandle.Target!;
                gcHandle.Free();

                foreach (var s in userData.Strings) {
                    s.Dispose();
                }
                foreach (var a in userData.Args) {
                    GMarshal.Free(a);
                }
                foreach (var d in userData.DestroyCallbacks) {
                    var destroy = Marshal.GetDelegateForFunctionPointer<UnmanagedDestroyNotify>(d.Item1);
                    destroy(d.Item2);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static unsafe Runtime.Boolean OnParsed(IntPtr context_, IntPtr group_, IntPtr data_, ref IntPtr error_)
        {
            try {
                var userData = (UserData)GCHandle.FromIntPtr(data_).Target!;
                foreach (var callback in userData.Callbacks) {
                    callback();
                }
                return Runtime.Boolean.True;
            }
            catch (GErrorException ex) {
                GMarshal.PropagateError(ref error_, ex.Error);
            }
            catch (Exception ex) {
                // FIXME: marshal Exception to Error
                ex.LogUnhandledException();
            }
            return default;
        }
    }
}
