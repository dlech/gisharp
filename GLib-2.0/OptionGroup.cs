
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using StringList = System.Collections.Generic.List<GISharp.Lib.GLib.Utf8>;
using ArgList = System.Collections.Generic.List<System.IntPtr>;
using CallbackList = System.Collections.Generic.List<System.Action>;
using DestroyList = System.Collections.Generic.List<System.ValueTuple<GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr>>;

namespace GISharp.Lib.GLib
{
    partial class OptionGroup
    {
        static readonly UnmanagedDestroyNotify destroy_ = DestroyUserData;
        static readonly unsafe UnmanagedOptionParseFunc postParseFunc_ = OnParsed;

        readonly UserData userData;

        class UserData
        {
            public StringList Strings { get; } = new StringList();
            public ArgList Args { get; } = new ArgList();
            public CallbackList Callbacks { get; } = new CallbackList();
            public DestroyList DestroyCallbacks { get; } = new DestroyList();
        }

        static (IntPtr, UserData) New(Utf8 name, Utf8 description, Utf8 helpDescription)
        {
            var name_ = name?.Handle ?? throw new ArgumentNullException(nameof(name));
            var description_ = description?.Handle ?? throw new ArgumentNullException(nameof(description));
            var helpDescription_ = helpDescription?.Handle ?? throw new ArgumentNullException(nameof(helpDescription));
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
        public OptionGroup(Utf8 name, Utf8 description, Utf8 helpDescription)
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
            var ptr = GMarshal.Alloc0(IntPtr.Size);
            userData.Args.Add(ptr);
            return ptr;
        }

        void AddEntry(OptionEntry entry)
        {
            using (var array = new Array<OptionEntry>(true, false, 1){ entry }) {
                g_option_group_add_entries(Handle, array.Data);
            }
        }

        public void AddFlag(string longName, char shortName, Action<bool> callback, string description, OptionFlags flags = OptionFlags.None)
        {
            if (callback == null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var arg_ = AllocArg(sizeof(bool));

            userData.Callbacks.Add(() => {
                var arg = Marshal.PtrToStructure<bool>(arg_);
                callback(arg);
            });

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.None,
                ArgData = arg_,
                Description = description_,
                ArgDescription = IntPtr.Zero
            });
        }

        public void AddString(string longName, char shortName, Action<Utf8> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            if (callback == null) {
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

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.String,
                ArgData = arg_,
                Description = description_,
                ArgDescription = argDescription_
            });
        }

        public void AddInt(string longName, char shortName, Action<int> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback == null) {
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

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.Int,
                ArgData = arg_,
                Description = description_,
                ArgDescription = argDescription_
            });
        }

        public void AddFilename(string longName, char shortName, Action<Filename> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback == null) {
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

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.Filename,
                ArgData = arg_,
                Description = description_,
                ArgDescription = argDescription_
            });
        }

        public void AddStringArray(string longName, char shortName, Action<Strv> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback == null) {
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

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.StringArray,
                ArgData = arg_,
                Description = description_,
                ArgDescription = argDescription_
            });
        }

        public void AddFilenameArray(string longName, char shortName, Action<FilenameArray> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback == null) {
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

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.FilenameArray,
                ArgData = arg_,
                Description = description_,
                ArgDescription = argDescription_
            });
        }

        public void AddDouble(string longName, char shortName, Action<double> callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback == null) {
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

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.Double,
                ArgData = arg_,
                Description = description_,
                ArgDescription = argDescription_
            });
        }

        public void AddCallback(string longName, char shortName, OptionArgFunc callback, string description, string argDescription, OptionFlags flags = OptionFlags.None)
        {
            var this_ = Handle;
            if (callback == null) {
                throw new ArgumentNullException(nameof(callback));
            }
            var longName_ = AllocString(longName ?? throw new ArgumentNullException(nameof(longName)));
            var description_ = AllocString(description ?? throw new ArgumentNullException(nameof(description)));
            var argDescription_ = AllocString(argDescription);
            var (callback_, destroy_, data_) = OptionArgFuncFactory.Create(callback, CallbackScope.Notified);
            var arg_ = Marshal.GetFunctionPointerForDelegate(callback_);
            userData.DestroyCallbacks.Add((destroy_, data_));

            AddEntry(new OptionEntry {
                LongName = longName_,
                ShortName = (sbyte)shortName,
                Flags = (int)flags,
                Arg = OptionArg.Callback,
                ArgData = arg_,
                Description = description_,
                ArgDescription = argDescription_
            });
        }

        static void DestroyUserData(IntPtr data)
        {
            try {
                var gcHandle = (GCHandle)data;
                var userData = (UserData)gcHandle.Target;
                gcHandle.Free();

                foreach (var s in userData.Strings) {
                    s.Dispose();
                }
                foreach (var a in userData.Args) {
                    GMarshal.Free(a);
                }
                foreach (var d in userData.DestroyCallbacks) {
                    d.Item1(d.Item2);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static unsafe bool OnParsed(IntPtr context_, IntPtr group_, IntPtr data_, IntPtr* error_)
        {
            try {
                var userData = (UserData)GCHandle.FromIntPtr(data_).Target;
                foreach (var callback in userData.Callbacks) {
                    callback();
                }
                return true;
            }
            catch (GErrorException ex) {
                GMarshal.PropagateError(error_, ex.Error);
            }
            catch (Exception ex) {
                // FIXME: marshal Exception to Error
                ex.LogUnhandledException();
            }
            return false;
        }
    }
}
