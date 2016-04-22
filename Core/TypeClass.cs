using System;
using GISharp.Core;
using System.Runtime.InteropServices;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all classes.
    /// </summary>
    // TODO: this should be internal
    public class TypeClass : ReferenceCountedOpaque
    {
        internal struct TypeClass_
        {
            public GType GType;
        }

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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
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
#endif

        /// <summary>
        /// This function is essentially the same as g_type_class_ref(),
        /// except that the classes reference count isn't incremented.
        /// As a consequence, this function may return %NULL if the class
        /// of the type passed in does not currently exist (hasn't been
        /// referenced before).
        /// </summary>
        /// <param name="type">
        /// type ID of a classed type
        /// </param>
        /// <returns>
        /// the #GTypeClass
        ///     structure for the given type ID or %NULL if the class does not
        ///     currently exist
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_class_peek (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        public static T Get<T> (GType type) where T : TypeClass
        {
            var handle = g_type_class_peek (type);
            var ret =  Opaque.GetInstance<T> (handle, Transfer.None);
            return ret;
        }

#if THIS_CODE_IS_NOT_COMPILED
        /// <summary>
        /// A more efficient version of g_type_class_peek() which works only for
        /// static types.
        /// </summary>
        /// <param name="type">
        /// type ID of a classed type
        /// </param>
        /// <returns>
        /// the #GTypeClass
        ///     structure for the given type ID or %NULL if the class does not
        ///     currently exist or is dynamically loaded
        /// </returns>
        [SinceAttribute ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_class_peek_static (
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        GType type);

        /// <summary>
        /// A more efficient version of g_type_class_peek() which works only for
        /// static types.
        /// </summary>
        /// <param name="type">
        /// type ID of a classed type
        /// </param>
        /// <returns>
        /// the #GTypeClass
        ///     structure for the given type ID or %NULL if the class does not
        ///     currently exist or is dynamically loaded
        /// </returns>
        [SinceAttribute ("2.4")]
        public static TypeClass PeekStatic (GType type)
        {
        var ret_ = g_type_class_peek_static (type);
        var ret = Opaque.GetInstance<TypeClass> (ret_, Transfer.None);
        return ret;
        }
#endif

        /// <summary>
        /// Increments the reference count of the class structure belonging to
        /// @type. This function will demand-create the class if it doesn't
        /// exist already.
        /// </summary>
        /// <param name="type">
        /// type ID of a classed type
        /// </param>
        /// <returns>
        /// the #GTypeClass
        ///     structure for the given type ID
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_class_ref (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        internal protected override void Ref ()
        {
            var gtype = GType.FromClass (this);
            g_type_class_ref (gtype);
        }

#if THIS_CODE_IS_NOT_COMPILED
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
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
        AssertNotDisposed ();
        var ret = g_type_class_get_private (Handle, privateType);
        return ret;
        }

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
        /// the #GTypeClass structure to
        ///     retrieve the parent class for
        /// </param>
        /// <returns>
        /// the parent class
        ///     of @g_class
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_class_peek_parent (
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
        /* transfer-ownership:none */
        IntPtr gClass);

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
        /// <returns>
        /// the parent class
        ///     of @g_class
        /// </returns>
        public TypeClass PeekParent ()
        {
        AssertNotDisposed ();
        var ret_ = g_type_class_peek_parent (Handle);
        var ret = Opaque.GetInstance<TypeClass> (ret_, Transfer.None);
        return ret;
        }
#endif

        /// <summary>
        /// Decrements the reference count of the class structure being passed in.
        /// Once the last reference count of a class has been released, classes
        /// may be finalized by the type system, so further dereferencing of a
        /// class pointer after g_type_class_unref() are invalid.
        /// </summary>
        /// <param name="gClass">
        /// a #GTypeClass structure to unref
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_class_unref (
            /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass);

        /// <summary>
        /// Decrements the reference count of the class structure being passed in.
        /// Once the last reference count of a class has been released, classes
        /// may be finalized by the type system, so further dereferencing of a
        /// class pointer after g_type_class_unref() are invalid.
        /// </summary>
        protected internal override void Unref ()
        {
            AssertNotDisposed ();
            g_type_class_unref (Handle);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
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
            AssertNotDisposed ();
            g_type_class_unref_uncached (Handle);
        }

        protected TypeClass (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
