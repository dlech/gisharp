using System;
using GISharp.Runtime;
using System.Runtime.InteropServices;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all classes.
    /// </summary>
    public abstract class TypeClass : ReferenceCountedOpaque
    {
        internal struct Struct
        {
            #pragma warning disable CS0649
            public GType GType;
            #pragma warning restore CS0649
        }

        public GType GType {
            get {
                AssertNotDisposed ();
                var ret = Marshal.PtrToStructure<GType> (Handle);
                return ret;
            }
        }

        public TypeClass (IntPtr handle, Transfer ownership) : base (handle)
        {
            if (ownership == Transfer.None) {
                throw new NotSupportedException ();
            }
        }

        protected override void Dispose (bool disposing)
        {
            if (Handle != IntPtr.Zero) {
                g_type_class_unref (Handle);
            }
            base.Dispose (disposing);
        }

        protected override void Ref ()
        {
            AssertNotDisposed ();
            throw new NotSupportedException ();
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_type_class_unref (IntPtr gClass);

        protected override void Unref ()
        {
            AssertNotDisposed ();
            g_type_class_unref (Handle);
        }

        public abstract Type StructType { get; }


        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_type_class_ref (GType type);

        internal static T Get<T> (GType type) where T : TypeClass
        {
            if (!type.IsClassed) {
                throw new ArgumentException ("GType is not classed", nameof(type));
            }
            var handle = g_type_class_ref (type);
            var ret = Opaque.GetInstance<T> (handle, Transfer.Full);
            return ret;
        }

        public static TypeClass Get (GType type)
        {
            return Get<TypeClass> (type);
        }

        public abstract TypeInfo GetTypeInfo (Type type);

        /// <summary>
        /// This function is essentially the same as g_type_class_ref(), except
        /// that the classes reference count isn't incremented. As a consequence,
        /// this function may return NULL if the class of the type passed in does
        ///  not currently exist (hasn't been referenced before).
        /// </summary>
        /// <param name="type">
        /// type ID of a classed type
        /// </param>
        /// <returns>
        /// the GTypeClass structure for the given type ID or NULL if the class
        /// does not currently exist.
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
        /* transfer-ownership:none */
        internal static extern IntPtr g_type_class_peek (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// This is a convenience function often needed in class initializers.
        /// It returns the class structure of the immediate parent type of the
        /// class passed in.  Since derived classes hold a reference count on
        /// their parent classes as long as they are instantiated, the returned
        /// class will always exist.
        /// </summary>
        /// <remarks>
        /// This function is essentially equivalent to:
        /// g_type_class_peek (g_type_parent (G_TYPE_FROM_CLASS (g_class)))
        /// </remarks>
        /// <param name="gClass">
        /// the #GTypeClass structure to retrieve the parent class for
        /// </param>
        /// <returns>
        /// the parent class of @g_class
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
        /* transfer-ownership:none */
        internal static extern IntPtr g_type_class_peek_parent (
            /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass);
        
#if THIS_CODE_IS_NOT_COMPILED
        /// <summary>
        /// Registers a private structure for an instantiatable type.
        /// </summary>
        /// <remarks>
        /// When an object is allocated, the private structures for
        /// the type and all of its parent types are allocated
        /// sequentially in the same memory block as the public
        /// structures, and are zero-filled.
        ///
        /// Note that the accumulated size of the private structures of
        /// a type and all its parent types cannot exceed 64 KiB.
        ///
        /// This function should be called in the type's class_init() function.
        /// The private structure can be retrieved using the
        /// G_TYPE_INSTANCE_GET_PRIVATE() macro.
        ///
        /// The following example shows attaching a private structure
        /// MyObjectPrivate to an object MyObject defined in the standard
        /// GObject fashion in the type's class_init() function.
        ///
        /// Note the use of a structure member "priv" to avoid the overhead
        /// of repeatedly calling MY_OBJECT_GET_PRIVATE().
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// typedef struct _MyObject        MyObject;
        /// typedef struct _MyObjectPrivate MyObjectPrivate;
        ///
        /// struct _MyObject {
        ///  GObject parent;
        ///
        ///  MyObjectPrivate *priv;
        /// };
        ///
        /// struct _MyObjectPrivate {
        ///   int some_field;
        /// };
        ///
        /// static void
        /// my_object_class_init (MyObjectClass *klass)
        /// {
        ///   g_type_class_add_private (klass, sizeof (MyObjectPrivate));
        /// }
        ///
        /// static void
        /// my_object_init (MyObject *my_object)
        /// {
        ///   my_object-&gt;priv = G_TYPE_INSTANCE_GET_PRIVATE (my_object,
        ///                                                  MY_TYPE_OBJECT,
        ///                                                  MyObjectPrivate);
        ///   // my_object-&gt;priv-&gt;some_field will be automatically initialised to 0
        /// }
        ///
        /// static int
        /// my_object_get_some_field (MyObject *my_object)
        /// {
        ///   MyObjectPrivate *priv;
        ///
        ///   g_return_val_if_fail (MY_IS_OBJECT (my_object), 0);
        ///
        ///   priv = my_object-&gt;priv;
        ///
        ///   return priv-&gt;some_field;
        /// }
        /// ]|
        /// </remarks>
        /// <param name="gClass">
        /// class structure for an instantiatable type
        /// </param>
        /// <param name="privateSize">
        /// size of private structure
        /// </param>
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_class_add_private (
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gClass,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UInt64 privateSize);

        /// <summary>
        /// Registers a private structure for an instantiatable type.
        /// </summary>
        /// <remarks>
        /// When an object is allocated, the private structures for
        /// the type and all of its parent types are allocated
        /// sequentially in the same memory block as the public
        /// structures, and are zero-filled.
        ///
        /// Note that the accumulated size of the private structures of
        /// a type and all its parent types cannot exceed 64 KiB.
        ///
        /// This function should be called in the type's class_init() function.
        /// The private structure can be retrieved using the
        /// G_TYPE_INSTANCE_GET_PRIVATE() macro.
        ///
        /// The following example shows attaching a private structure
        /// MyObjectPrivate to an object MyObject defined in the standard
        /// GObject fashion in the type's class_init() function.
        ///
        /// Note the use of a structure member "priv" to avoid the overhead
        /// of repeatedly calling MY_OBJECT_GET_PRIVATE().
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// typedef struct _MyObject        MyObject;
        /// typedef struct _MyObjectPrivate MyObjectPrivate;
        ///
        /// struct _MyObject {
        ///  GObject parent;
        ///
        ///  MyObjectPrivate *priv;
        /// };
        ///
        /// struct _MyObjectPrivate {
        ///   int some_field;
        /// };
        ///
        /// static void
        /// my_object_class_init (MyObjectClass *klass)
        /// {
        ///   g_type_class_add_private (klass, sizeof (MyObjectPrivate));
        /// }
        ///
        /// static void
        /// my_object_init (MyObject *my_object)
        /// {
        ///   my_object-&gt;priv = G_TYPE_INSTANCE_GET_PRIVATE (my_object,
        ///                                                  MY_TYPE_OBJECT,
        ///                                                  MyObjectPrivate);
        ///   // my_object-&gt;priv-&gt;some_field will be automatically initialised to 0
        /// }
        ///
        /// static int
        /// my_object_get_some_field (MyObject *my_object)
        /// {
        ///   MyObjectPrivate *priv;
        ///
        ///   g_return_val_if_fail (MY_IS_OBJECT (my_object), 0);
        ///
        ///   priv = my_object-&gt;priv;
        ///
        ///   return priv-&gt;some_field;
        /// }
        /// ]|
        /// </remarks>
        /// <param name="gClass">
        /// class structure for an instantiatable type
        /// </param>
        /// <param name="privateSize">
        /// size of private structure
        /// </param>
        [SinceAttribute ("2.4")]
        public static void AddPrivate (IntPtr gClass, UInt64 privateSize)
        {
            g_type_class_add_private (gClass, privateSize);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_class_adjust_private_offset (
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gClass,
            /* <type name="gint" type="gint*" managed-name="Gint" /> */
            /* transfer-ownership:none */
            Int32 privateSizeOrOffset);

        public static void AdjustPrivateOffset (IntPtr gClass, Int32 privateSizeOrOffset)
        {
            g_type_class_adjust_private_offset (gClass, privateSizeOrOffset);
        }

        /// <summary>
        /// Gets the offset of the private data for instances of @g_class.
        /// </summary>
        /// <remarks>
        /// This is how many bytes you should add to the instance pointer of a
        /// class in order to get the private data for the type represented by
        /// @g_class.
        ///
        /// You can only call this function after you have registered a private
        /// data area for @g_class using g_type_class_add_private().
        /// </remarks>
        /// <param name="gClass">
        /// a #GTypeClass
        /// </param>
        /// <returns>
        /// the offset, in bytes
        /// </returns>
        [SinceAttribute ("2.38")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern Int32 g_type_class_get_instance_private_offset (
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gClass);

        /// <summary>
        /// Gets the offset of the private data for instances of @g_class.
        /// </summary>
        /// <remarks>
        /// This is how many bytes you should add to the instance pointer of a
        /// class in order to get the private data for the type represented by
        /// @g_class.
        ///
        /// You can only call this function after you have registered a private
        /// data area for @g_class using g_type_class_add_private().
        /// </remarks>
        /// <param name="gClass">
        /// a #GTypeClass
        /// </param>
        /// <returns>
        /// the offset, in bytes
        /// </returns>
        [SinceAttribute ("2.38")]
        public static Int32 GetInstancePrivateOffset (IntPtr gClass)
        {
            var ret = g_type_class_get_instance_private_offset (gClass);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* */
        static extern IntPtr g_type_class_get_private (
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr klass,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType privateType);

        public IntPtr GetPrivate (GType privateType)
        {
            var ret = g_type_class_get_private (Handle, privateType);
            return ret;
        }

        /// <summary>
        /// A variant of g_type_class_unref() for use in #GTypeClassCacheFunc
        /// implementations. It unreferences a class without consulting the chain
        /// of #GTypeClassCacheFuncs, avoiding the recursion which would occur
        /// otherwise.
        /// </summary>
        /// <param name="gClass">
        /// a #GTypeClass structure to unref
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_class_unref_uncached (
            /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass);

        /// <summary>
        /// A variant of g_type_class_unref() for use in #GTypeClassCacheFunc
        /// implementations. It unreferences a class without consulting the chain
        /// of #GTypeClassCacheFuncs, avoiding the recursion which would occur
        /// otherwise.
        /// </summary>
        public void UnrefUncached ()
        {
            g_type_class_unref_uncached (Handle);
        }
#endif
    }
}
