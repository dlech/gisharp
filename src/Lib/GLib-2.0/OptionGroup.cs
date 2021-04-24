// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using ArgFuncList = System.Collections.Generic.List<GISharp.Lib.GLib.UnmanagedOptionArgFunc>;
using ArgList = System.Collections.Generic.List<System.IntPtr>;
using CallbackList = System.Collections.Generic.List<System.Action>;
using StringList = System.Collections.Generic.List<GISharp.Lib.GLib.Utf8>;

namespace GISharp.Lib.GLib
{
    unsafe partial class OptionGroup
    {
        // FIXME: we will have problems with userData being null if an
        // OptionGroup is marshaled from unmanaged code
        readonly UserData userData = default!;

        class UserData
        {
            public StringList Strings { get; } = new();
            public ArgList Args { get; } = new();
            public CallbackList Callbacks { get; } = new();
            public ArgFuncList ArgFuncs { get; } = new();
        }

        static UnmanagedStruct* New(UnownedUtf8 name, UnownedUtf8 description, UnownedUtf8 helpDescription, out UserData userData)
        {
            var name_ = (byte*)name.UnsafeHandle;
            var description_ = (byte*)description.UnsafeHandle;
            var helpDescription_ = (byte*)helpDescription.UnsafeHandle;
            userData = new UserData();
            var userData_ = (IntPtr)GCHandle.Alloc(userData);
            var destroy_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&DestroyUserData;
            var ret_ = g_option_group_new(name_, description_, helpDescription_, userData_, destroy_);
            var postParseFunc_ = (delegate* unmanaged[Cdecl]<OptionContext.UnmanagedStruct*, UnmanagedStruct*, IntPtr, Error.UnmanagedStruct**, Runtime.Boolean>)&OnParsed;
            g_option_group_set_parse_hooks(ret_, null, postParseFunc_);
            GMarshal.PopUnhandledException();
            return ret_;
        }

        private OptionGroup(IntPtr handle, UserData userData) : base(handle)
        {
            this.userData = userData;
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
            : this((IntPtr)New(name, description, helpDescription, out var userData), userData)
        {
        }

        /// <summary>
        /// Allocates an unmanged string and returns the pointer. A managed
        /// proxy is saved in a list so that it can be freed later.
        /// </summary>
        byte* AllocString(string str)
        {
            var utf8 = (Utf8)str;
            userData.Strings.Add(utf8);
            return (byte*)(utf8?.UnsafeHandle ?? IntPtr.Zero);
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

        void AddEntry(OptionEntry entry)
        {
            var group_ = (UnmanagedStruct*)UnsafeHandle;
            using var array = new Array<OptionEntry>(true, false, 1) { entry };
            fixed (OptionEntry* entries_ = array.Data) {
                g_option_group_add_entries(group_, entries_);
                GMarshal.PopUnhandledException();
            }
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
            var arg_ = AllocArg(sizeof(Runtime.Boolean));

            userData.Callbacks.Add(() => {
                var arg = Marshal.PtrToStructure<Runtime.Boolean>(arg_);
                callback(arg.IsTrue());
            });

            AddEntry(new OptionEntry(
                longName_,
                shortName,
                flags,
                OptionArg.None,
                arg_,
                description_,
                null
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
            var this_ = UnsafeHandle;
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
            var this_ = UnsafeHandle;
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
        public void AddStringArray(string longName, char shortName, Action<Strv<Utf8>> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = UnsafeHandle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(IntPtr.Size);

            userData.Callbacks.Add(() => {
                var arg = Marshal.ReadIntPtr(arg_);
                var strv = new Strv<Utf8>(arg, -1, Transfer.Full);
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
        public void AddFilenameArray(string longName, char shortName, Action<Strv<Filename>> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = UnsafeHandle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription ?? throw new ArgumentNullException(nameof(argDescription)));
            var arg_ = AllocArg(IntPtr.Size);

            userData.Callbacks.Add(() => {
                var arg = Marshal.ReadIntPtr(arg_);
                var strv = new Strv<Filename>(arg, -1, Transfer.Full);
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
            var this_ = UnsafeHandle;
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
            var this_ = UnsafeHandle;
            if (callback is null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription);

            var wrappedCallback = new UnmanagedOptionArgFunc((optionName_, value_, data_, error_) => {
                try {
                    var optionName = new UnownedUtf8(optionName_);
                    var value = new UnownedUtf8(value_);
                    callback(optionName, value);
                    return Runtime.Boolean.True;
                }
                catch (GErrorException ex) {
                    GMarshal.PropagateError(error_, ex.Error);
                }
                catch (Exception ex) {
                    GMarshal.PushUnhandledException(ex);
                }

                return default;
            });

            var callback_ = Marshal.GetFunctionPointerForDelegate(wrappedCallback);
            userData.ArgFuncs.Add(wrappedCallback);

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

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
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
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static Runtime.Boolean OnParsed(OptionContext.UnmanagedStruct* context_, UnmanagedStruct* group_, IntPtr data_, Error.UnmanagedStruct** error_)
        {
            try {
                var userData = (UserData)GCHandle.FromIntPtr(data_).Target!;
                foreach (var callback in userData.Callbacks) {
                    callback();
                }
                return Runtime.Boolean.True;
            }
            catch (GErrorException ex) {
                GMarshal.PropagateError(error_, ex.Error);
            }
            catch (Exception ex) {
                // FIXME: marshal Exception to Error
                GMarshal.PushUnhandledException(ex);
            }
            return default;
        }
    }
}
