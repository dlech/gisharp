using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GISharp.GLib;
using GISharp.GModule;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// <see cref="ParamSpec"/> is an object structure that encapsulates the metadata
    /// required to specify parameters, such as e.g. <see cref="Object"/> properties.
    /// </summary>
    /// <remarks>
    /// Parameter names need to start with a letter (a-z or A-Z).
    /// Subsequent characters can be letters, numbers or a '-'.
    /// All other characters are replaced by a '-' during construction.
    /// The result of this replacement is called the canonical name of
    /// the parameter.
    /// </remarks>
    [GType ("GParam", IsProxyForUnmanagedType = true)]
    public class ParamSpec : TypeInstance
    {
        static readonly Quark managedProxyGCHandleQuark = Quark.FromString("gisharp-gobject-paramspec-managed-proxy-instance-quark");

        static readonly IntPtr flagsOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Flags));
        static readonly IntPtr valueTypeOffset = Marshal.OffsetOf<Struct> (nameof(Struct.ValueType));
        static readonly IntPtr ownerTypeOffset = Marshal.OffsetOf<Struct> (nameof(Struct.OwnerType));
        static readonly IntPtr refCountOffset = Marshal.OffsetOf<Struct> (nameof(Struct.RefCount));

        protected new struct Struct
        {
            #pragma warning disable CS0649
            /// <summary>
            /// private GTypeInstance portion
            /// </summary>
            public TypeInstance.Struct GTypeInstance;

            /// <summary>
            /// name of this parameter: always an interned string
            /// </summary>
            public IntPtr Name;

            /// <summary>
            /// GParamFlags flags for this parameter
            /// </summary>
            public ParamFlags Flags;

            /// <summary>
            /// the GValue type for this parameter
            /// </summary>
            public GType ValueType;

            /// <summary>
            /// GType type that uses (introduces) this parameter
            /// </summary>
            public GType OwnerType;

            #pragma warning disable CS0169
            IntPtr name;
            IntPtr blurb;
            IntPtr qdata;
            public uint RefCount;
            uint paramId;
            #pragma warning restore CS0169
            #pragma warning disable CS0649
        }

        /// <summary>
        /// <see cref="ParamFlags"/> flags for this parameter
        /// </summary>
        ParamFlags Flags => (ParamFlags)Marshal.ReadInt32(handle, (int)flagsOffset);

        /// <summary>
        /// The <see cref="Value"/> type for this parameter
        /// </summary>
        public GType ValueType => Marshal.PtrToStructure<GType>(handle + (int)valueTypeOffset);

        /// <summary>
        /// <see cref="GType"/> type that uses (introduces) this parameter
        /// </summary>
        GType OwnerType => Marshal.PtrToStructure<GType>(handle + (int)ownerTypeOffset);

        uint RefCount => Marshal.PtrToStructure<uint>(handle + (int)refCountOffset);

        public ParamSpec (IntPtr handle, Transfer ownership) : base (handle)
        {
            if (ownership == Transfer.None) {
                this.handle = g_param_spec_ref (handle);
            }
            g_param_spec_sink (this.handle);

            // attach this managed instance to the unmanaged instanace
            var data = (IntPtr)GCHandle.Alloc(this, GCHandleType.Weak);
            g_param_spec_set_qdata_full(this.handle, managedProxyGCHandleQuark, data, freeQDataDelegate);
        }

        protected override void Dispose (bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_param_spec_set_qdata(handle, managedProxyGCHandleQuark, IntPtr.Zero);
                g_param_spec_unref (handle);
            }
            base.Dispose (disposing);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_param_spec_ref (IntPtr pspec);

        internal IntPtr Ref()
        {
            return g_param_spec_ref(Handle);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_param_spec_sink (IntPtr pspec);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_param_spec_unref (IntPtr pspec);

        internal static readonly UnmanagedDestroyNotify UnrefDelegate = g_param_spec_unref;

        protected static GType[] paramSpecTypes;

        static ParamSpec ()
        {
            // Have to do some marshalling to get ParamSpec GTypes used by child
            // classes. These types don't have the usual *_get_type() functions.
            using (var lib = Module.Open (Module.BuildPath (null, "gobject-2.0", true), ModuleFlags.BindLazy)) {
                var ptr = Marshal.ReadIntPtr (lib.GetSymbol ("g_param_spec_types"));
                const int paramSpecTypeCount = 23;
                paramSpecTypes = new GType[paramSpecTypeCount];
                for (int i = 0; i < paramSpecTypeCount; i++) {
                    paramSpecTypes[i] = Marshal.PtrToStructure<GType> (ptr + i * Marshal.SizeOf<GType> ());
                }
            }
        }

        /// <summary>
        /// Get the short description of a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the short description of @pspec.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_blurb (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the short description of a <see cref="ParamSpec"/>.
        /// </summary>
        /// <returns>
        /// the short description of this instance.
        /// </returns>
        public Utf8 Blurb {
            get {
                var ret_ = g_param_spec_get_blurb(Handle);
                var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Gets the default value of @pspec as a pointer to a #GValue.
        /// </summary>
        /// <remarks>
        /// #GValue will remain value for the life of this ParamSpec.
        /// </remarks>
        /// <returns>
        /// a pointer to a #GValue which must not be modified
        /// </returns>
        [Since ("2.38")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_default_value (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr param);

        /// <summary>
        /// Gets the default value of this instance.
        /// </summary>
        /// <remarks>
        /// The <see cref="Value"/> will remain value for the life of this instance.
        /// </remarks>
        [Since ("2.38")]
        public Value DefaultValue {
            get {
                var ret_ = g_param_spec_get_default_value(Handle);
                var ret = Marshal.PtrToStructure<Value> (ret_);
                return ret;
            }
        }

        /// <summary>
        /// Get the name of a #GParamSpec.
        /// </summary>
        /// <remarks>
        /// The name is always an "interned" string (as per g_intern_string()).
        /// This allows for pointer-value comparisons.
        /// </remarks>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the name of @pspec.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_name (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the name of a <see cref="ParamSpec"/>.
        /// </summary>
        /// <returns>
        /// the name of this instance.
        /// </returns>
        public Utf8 Name {
            get {
                var ret_ = g_param_spec_get_name(Handle);
                var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Gets the GQuark for the name.
        /// </summary>
        /// <param name="param">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// the GQuark for @pspec-&gt;name.
        /// </returns>
        [Since ("2.46")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_param_spec_get_name_quark (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr param);

        /// <summary>
        /// Gets the <see cref="Quark"/> for the name.
        /// </summary>
        /// <returns>
        /// the <see cref="Quark"/> for <see cref="Name"/>.
        /// </returns>
        [Since ("2.46")]
        public Quark NameQuark {
            get {
                var ret = g_param_spec_get_name_quark(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Get the nickname of a #GParamSpec.
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <returns>
        /// the nickname of @pspec.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_nick (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Get the nickname of a <see cref="ParamSpec"/>.
        /// </summary>
        /// <returns>
        /// the nickname of this instance.
        /// </returns>
        public Utf8 Nick {
            get {
                var ret_ = g_param_spec_get_nick(Handle);
                var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Gets back user data pointers stored via g_param_spec_set_qdata().
        /// </summary>
        /// <param name="pspec">
        /// a valid #GParamSpec
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <returns>
        /// the user data pointer set, or %NULL
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_qdata (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark);

        /// <summary>
        /// If the paramspec redirects operations to another paramspec,
        /// returns that paramspec. Redirect is used typically for
        /// providing a new implementation of a property in a derived
        /// type while preserving all the properties from the parent
        /// type. Redirection is established by creating a property
        /// of type #GParamSpecOverride. See g_object_class_override_property()
        /// for an example of the use of this capability.
        /// </summary>
        /// <param name="pspec">
        /// a #GParamSpec
        /// </param>
        /// <returns>
        /// paramspec to which requests on this
        ///          paramspec should be redirected, or %NULL if none.
        /// </returns>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_param_spec_get_redirect_target (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// If the paramspec redirects operations to another paramspec,
        /// returns that paramspec. Redirect is used typically for
        /// providing a new implementation of a property in a derived
        /// type while preserving all the properties from the parent
        /// type. Redirection is established by creating a property
        /// of type <see cref="ParamSpecOverride"/>.
        /// </summary>
        /// <returns>
        /// paramspec to which requests on this
        /// paramspec should be redirected, or <c>null</c> if none.
        /// </returns>
        [Since ("2.4")]
        public ParamSpec RedirectTarget {
            get {
                var ret_ = g_param_spec_get_redirect_target(Handle);
                var ret = GetInstance(ret_, Transfer.None);
                return ret;
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_param_spec_set_qdata (
            IntPtr pspec,
            Quark quark,
            IntPtr data);

        /// <summary>
        /// This function works like g_param_spec_set_qdata(), but in addition,
        /// a `void (*destroy) (gpointer)` function may be
        /// specified which is called with @data as argument when the @pspec is
        /// finalized, or the data is being overwritten by a call to
        /// g_param_spec_set_qdata() with the same @quark.
        /// </summary>
        /// <param name="pspec">
        /// the #GParamSpec to set store a user data pointer
        /// </param>
        /// <param name="quark">
        /// a #GQuark, naming the user data pointer
        /// </param>
        /// <param name="data">
        /// an opaque user data pointer
        /// </param>
        /// <param name="destroy">
        /// function to invoke with @data as argument, when @data needs to
        ///  be freed
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_param_spec_set_qdata_full (
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data,
            /* <type name="GLib.DestroyNotify" type="GDestroyNotify" managed-name="GLib.DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            UnmanagedDestroyNotify destroy);

        /// <summary>
        /// Gets and sets arbitrary user data associated with this instance.
        /// </summary>
        /// <param name="quark">
        /// a <see cref="Quark"/>, naming the user data
        /// </param>
        public object this[Quark quark] {
            get {
                var ret = g_param_spec_get_qdata(Handle, quark);
                if (ret == IntPtr.Zero) {
                    return null;
                }
                var gcHandle = (GCHandle)ret;
                var data = gcHandle.Target;
                return data;
            }
            set {
                var this_ = Handle;
                if (value == null) {
                    g_param_spec_set_qdata(this_, quark, IntPtr.Zero);
                }
                else {
                    var data_ = (IntPtr)GCHandle.Alloc (value);
                    g_param_spec_set_qdata_full(this_, quark, data_, freeQDataDelegate);
                }
            }
        }

        static UnmanagedDestroyNotify freeQDataDelegate = FreeQData;

        static void FreeQData (IntPtr userData)
        {
            try {
                var gcHandle = (GCHandle)userData;
                gcHandle.Free ();
            }
            catch (Exception ex) {
                ex.LogUnhandledException ();
            }
        }

        /// <summary>
        /// Gets a managed proxy for a an unmanged GParamSpec.
        /// </summary>
        /// <param name="handle">
        /// The pointer to the unmanaged instance
        /// </param>
        /// <param name="ownership">
        /// Indicates if we already have a reference to the unmanged instance
        /// or not.
        /// </param>
        /// <returns>
        /// A managed proxy instance
        /// </returns>
        /// <remarks>
        /// This method tries to get an existing managed proxy instance by
        /// looking for a GC handle attached to the unmanaged instance (using
        /// QData). If one is found, it returns the existing managed instance,
        /// otherwise a new instance is created.
        /// </remarks>
        public static new T GetInstance<T>(IntPtr handle, Transfer ownership) where T : ParamSpec
        {
            if (handle == IntPtr.Zero) {
                return null;
            }

            // see if the unmanaged object has a managed GC handle
            var ptr = g_param_spec_get_qdata(handle, managedProxyGCHandleQuark);
            if (ptr != IntPtr.Zero) {
                var gcHandle = (GCHandle)ptr;
                if (gcHandle.IsAllocated) {
                    // the GC handle looks good, so we should have the managed
                    // proxy for the unmanged object here
                    var target = (ParamSpec)gcHandle.Target;
                    // make sure the managed object has not been disposed
                    if (target?.handle == handle) {
                        // release the extra reference, if there is one
                        if (ownership != Transfer.None) {
                            g_param_spec_unref(handle);
                        }
                        // return the existing managed proxy
                        return (T)(object)target;
                    }
                }
            }

            // if we get here, that means that there wasn't a viable existing
            // proxy, so we need to create a new managed instance

            // get the exact type of the object
            ptr = Marshal.ReadIntPtr(handle);
            var gtype = Marshal.PtrToStructure<GType>(ptr);
            var type = GType.TypeOf(gtype);

            return (T)Activator.CreateInstance(type, handle, ownership);
        }

        /// <summary>
        /// Gets a managed proxy for a an unmanged GParamSpec.
        /// </summary>
        /// <seealso cref="GetInstance{T}"/>
        public static ParamSpec GetInstance(IntPtr handle, Transfer ownership)
        {
            return GetInstance<ParamSpec>(handle, ownership);
        }
    }

    public sealed class ParamSpecArray : PtrArray, IList<ParamSpec>
    {
        public ParamSpecArray() : this(0)
        {
        }

        public ParamSpecArray(int reservedSize) : base(reservedSize, ParamSpec.UnrefDelegate)
        {
        }

        /// <summary>
        /// Adds a <see cref="ParamSpec"/> to the end of the array.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the <see cref="ParamSpec"/> to add
        /// </param>
        public void Add(ParamSpec data)
        {
            Add(data?.Ref() ?? throw new ArgumentNullException(nameof(data)));
        }

        /// <summary>
        /// Inserts an element into the <see cref="ParamSpec"/> array at the given index. The
        /// array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="index">
        /// the index to place the new element at, or -1 to append
        /// </param>
        /// <param name="data">
        /// the <see cref="ParamSpec"/> to add.
        /// </param>
        [Since ("2.40")]
        public void Insert(int index, ParamSpec data)
        {
            Insert(index, data?.Ref() ?? throw new ArgumentNullException(nameof(data)));
        }

        /// <summary>
        /// Removes the first occurrence of the given <see cref="ParamSpec"/> from the <see cref="ParamSpec"/>
        /// array. The following elements are moved down one place.
        /// </summary>
        /// <remarks>
        /// It returns <c>true</c> if the <see cref="ParamSpec"/> was removed, or <c>false</c> if the
        /// <see cref="ParamSpec"/> was not found.
        /// </remarks>
        /// <param name="data">
        /// the <see cref="ParamSpec"/> to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the <see cref="ParamSpec"/> is removed, <c>false</c> if the <see cref="ParamSpec"/>
        /// is not found in the array
        /// </returns>
        public bool Remove(ParamSpec data)
        {
            return Remove(data?.Handle ?? throw new ArgumentNullException(nameof(data)));
        }

        /// <summary>
        /// Removes the <see cref="ParamSpec"/> at the given index from the <see cref="ParamSpec"/> array.
        /// The following elements are moved down one place.
        /// </summary>
        /// <param name="index">
        /// the index of the <see cref="ParamSpec"/> to remove
        /// </param>
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        /// <summary>
        /// Removes the first occurrence of the given <see cref="ParamSpec"/> from the <see cref="ParamSpec"/>
        /// array. The last element in the array is used to fill in the space,
        /// so this function does not preserve the order of the array. But it
        /// is faster than <see cref="Remove"/>.
        /// </summary>
        /// <remarks>
        /// It returns <c>true</c> if the <see cref="ParamSpec"/> was removed, or <c>false</c> if the
        /// <see cref="ParamSpec"/> was not found.
        /// </remarks>
        /// <param name="data">
        /// the <see cref="ParamSpec"/> to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the <see cref="ParamSpec"/> was found in the array
        /// </returns>
        public bool RemoveFast(ParamSpec data)
        {
            return RemoveFast(data?.Handle ?? throw new ArgumentNullException(nameof(data)));
        }

        /// <summary>
        /// Removes the <see cref="ParamSpec"/> at the given index from the <see cref="ParamSpec"/> array.
        /// The last element in the array is used to fill in the space, so
        /// this function does not preserve the order of the array. But it
        /// is faster than <see cref="RemoveAt"/>.
        /// </summary>
        /// <param name="index">
        /// the index of the <see cref="ParamSpec"/> to remove
        /// </param>
        public new void RemoveAtFast(int index)
        {
            base.RemoveAtFast(index);
        }

        public ParamSpec this[int index] {
            get {
                if (index < 0 || index >= Count) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                var ret_ = Marshal.ReadIntPtr(Data, IntPtr.Size * index);
                var ret = GetInstance<ParamSpec>(ret_, Transfer.None);
                return ret;
            }
            set {
                // Doing some tricks to make this faster..
                // Add the value to the end
                Add(value);
                // Then this will remove the element at index and replace it
                // with the last element that we just added
                RemoveAtFast(index);
            }
        }

        bool ICollection<ParamSpec>.IsReadOnly => false;

        /// <summary>
        /// Returns the first index of <paramref name="data"/> in this array.
        /// </summary>
        /// <returns>The index or -1 if <paramref name="data"/> was not found.</returns>
        /// <param name="data">Data.</param>
        public int IndexOf(ParamSpec data)
        {
            // TODO: replace with base.Find() eventually
            for (int i = 0; i < Count; i++) {
                var ptr = data?.Handle ?? throw new ArgumentNullException(nameof(data));
                if (Marshal.ReadIntPtr(Data, IntPtr.Size * i) == ptr) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Removes all <see cref="ParamSpec"/>s from the array.
        /// </summary>
        public void Clear()
        {
            SetSize(0);
        }

        /// <summary>
        /// Checks if the array contains <paramref name="data"/>.
        /// </summary>
        /// <returns><c>true</c> if <paramref name="data"/> was found, otherwise
        /// <c>false</c>.</returns>
        /// <param name="data">The item to search for.</param>
        public bool Contains(ParamSpec data)
        {
            return IndexOf(data) >= 0;
        }

        void ICollection<ParamSpec>.CopyTo(ParamSpec[] array, int arrayIndex)
        {
            if (array == null) {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (Count > array.Length - arrayIndex) {
                throw new ArgumentException("Destination array is not long enough.");
            }
            for (int i = 0; i < Count; i++) {
                array[i + arrayIndex] = this[i];
            }
        }

        IEnumerator<ParamSpec> GetEnumerator()
        {
            for (int i = 0; i < Count; i++) {
                yield return this[i];
            }
        }

        IEnumerator<ParamSpec> IEnumerable<ParamSpec>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class ParamSpecArrayExtensions
    {
        public static ParamSpecArray ToParamSpecArray(this IEnumerable<ParamSpec> source)
        {
            var size = 0;
            if (source is ICollection<ParamSpec> collection) {
                size = collection.Count;
            }
            else if (source is IReadOnlyCollection<ParamSpec> readOnlyCollection) {
                size = readOnlyCollection.Count;
            }
            var array = new ParamSpecArray(size);
            foreach (var item in source) {
                array.Add(item);
            }
            return array;
        }
    }
}
