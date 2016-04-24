﻿using System;
using System.Runtime.InteropServices;

namespace GISharp.GObject
{
    /// <summary>
    /// A callback function used by the type system to do base initialization
    /// of the class structures of derived types. It is called as part of the
    /// initialization process of all derived classes and should reallocate
    /// or reset all dynamic class members copied over from the parent class.
    /// For example, class members (such as strings) that are not sufficiently
    /// handled by a plain memory copy of the parent class into the derived class
    /// have to be altered. See GClassInitFunc() for a discussion of the class
    /// intialization process.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeBaseInitFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass);

    /// <summary>
    /// A callback function used by the type system to finalize those portions
    /// of a derived types class structure that were setup from the corresponding
    /// GBaseInitFunc() function. Class finalization basically works the inverse
    /// way in which class intialization is performed.
    /// See GClassInitFunc() for a discussion of the class intialization process.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeBaseFinalizeFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass);

    /// <summary>
    /// A callback function used by the type system to initialize the class
    /// of a specific type. This function should initialize all static class
    /// members.
    /// </summary>
    /// <remarks>
    /// The initialization process of a class involves:
    ///
    /// - Copying common members from the parent class over to the
    ///   derived class structure.
    /// - Zero initialization of the remaining members not copied
    ///   over from the parent class.
    /// - Invocation of the GBaseInitFunc() initializers of all parent
    ///   types and the class' type.
    /// - Invocation of the class' GClassInitFunc() initializer.
    ///
    /// Since derived classes are partially initialized through a memory copy
    /// of the parent class, the general rule is that GBaseInitFunc() and
    /// GBaseFinalizeFunc() should take care of necessary reinitialization
    /// and release of those class members that were introduced by the type
    /// that specified these GBaseInitFunc()/GBaseFinalizeFunc().
    /// GClassInitFunc() should only care about initializing static
    /// class members, while dynamic class members (such as allocated strings
    /// or reference counted resources) are better handled by a GBaseInitFunc()
    /// for this type, so proper initialization of the dynamic class members
    /// is performed for class initialization of derived types as well.
    ///
    /// An example may help to correspond the intend of the different class
    /// initializers:
    ///
    /// |[&lt;!-- language="C" --&gt;
    /// typedef struct {
    ///   GObjectClass parent_class;
    ///   gint         static_integer;
    ///   gchar       *dynamic_string;
    /// } TypeAClass;
    /// static void
    /// type_a_base_class_init (TypeAClass *class)
    /// {
    ///   class-&gt;dynamic_string = g_strdup ("some string");
    /// }
    /// static void
    /// type_a_base_class_finalize (TypeAClass *class)
    /// {
    ///   g_free (class-&gt;dynamic_string);
    /// }
    /// static void
    /// type_a_class_init (TypeAClass *class)
    /// {
    ///   class-&gt;static_integer = 42;
    /// }
    ///
    /// typedef struct {
    ///   TypeAClass   parent_class;
    ///   gfloat       static_float;
    ///   GString     *dynamic_gstring;
    /// } TypeBClass;
    /// static void
    /// type_b_base_class_init (TypeBClass *class)
    /// {
    ///   class-&gt;dynamic_gstring = g_string_new ("some other string");
    /// }
    /// static void
    /// type_b_base_class_finalize (TypeBClass *class)
    /// {
    ///   g_string_free (class-&gt;dynamic_gstring);
    /// }
    /// static void
    /// type_b_class_init (TypeBClass *class)
    /// {
    ///   class-&gt;static_float = 3.14159265358979323846;
    /// }
    /// ]|
    /// Initialization of TypeBClass will first cause initialization of
    /// TypeAClass (derived classes reference their parent classes, see
    /// g_type_class_ref() on this).
    ///
    /// Initialization of TypeAClass roughly involves zero-initializing its fields,
    /// then calling its GBaseInitFunc() type_a_base_class_init() to allocate
    /// its dynamic members (dynamic_string), and finally calling its GClassInitFunc()
    /// type_a_class_init() to initialize its static members (static_integer).
    /// The first step in the initialization process of TypeBClass is then
    /// a plain memory copy of the contents of TypeAClass into TypeBClass and
    /// zero-initialization of the remaining fields in TypeBClass.
    /// The dynamic members of TypeAClass within TypeBClass now need
    /// reinitialization which is performed by calling type_a_base_class_init()
    /// with an argument of TypeBClass.
    ///
    /// After that, the GBaseInitFunc() of TypeBClass, type_b_base_class_init()
    /// is called to allocate the dynamic members of TypeBClass (dynamic_gstring),
    /// and finally the GClassInitFunc() of TypeBClass, type_b_class_init(),
    /// is called to complete the initialization process with the static members
    /// (static_float).
    ///
    /// Corresponding finalization counter parts to the GBaseInitFunc() functions
    /// have to be provided to release allocated resources at class finalization
    /// time.
    /// </remarks>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeClassInitFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr classData);

    /// <summary>
    /// A callback function used by the type system to finalize a class.
    /// This function is rarely needed, as dynamically allocated class resources
    /// should be handled by GBaseInitFunc() and GBaseFinalizeFunc().
    /// Also, specification of a GClassFinalizeFunc() in the #GTypeInfo
    /// structure of a static type is invalid, because classes of static types
    /// will never be finalized (they are artificially kept alive when their
    /// reference count drops to zero).
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeClassFinalizeFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr classData);

    /// <summary>
    /// A callback function used by the type system to initialize a new
    /// instance of a type. This function initializes all instance members and
    /// allocates any resources required by it.
    /// </summary>
    /// <remarks>
    /// Initialization of a derived instance involves calling all its parent
    /// types instance initializers, so the class member of the instance
    /// is altered during its initialization to always point to the class that
    /// belongs to the type the current initializer was introduced for.
    ///
    /// The extended members of @instance are guaranteed to have been filled with
    /// zeros before this function is called.
    /// </remarks>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeInstanceInitFunc (
        /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
        /* transfer-ownership:none */
        IntPtr instance,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass);

    /// <summary>
    /// A callback function used by the type system to finalize an interface.
    /// This function should destroy any internal data and release any resources
    /// allocated by the corresponding GInterfaceInitFunc() function.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeInterfaceFinalizeFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gIface,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr ifaceData);


    /// <summary>
    /// A simple function pointer to get invoked when the signal is emitted. This
    /// allows you to tie a hook to the signal type, so that it will trap all
    /// emissions of that signal, from any object.
    /// </summary>
    /// <remarks>
    /// You may not attach these to signals created with the #G_SIGNAL_NO_HOOKS flag.
    /// </remarks>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate bool NativeSignalEmissionHook (
        /* <type name="SignalInvocationHint" type="GSignalInvocationHint*" managed-name="SignalInvocationHint" /> */
        /* transfer-ownership:none */
        SignalInvocationHint ihint,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nParamValues,
        /* <array length="1" zero-terminated="0" type="GValue*">
            <type name="Value" type="GValue" managed-name="Value" />
            </array> */
        /* transfer-ownership:none */
        IntPtr paramValues,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data);

    /// <summary>
    /// The type used for callback functions in structure definitions and function
    /// signatures. This doesn't mean that all callback functions must take no
    /// parameters and return void. The required signature of a callback function
    /// is determined by the context in which is used (e.g. the signal to which it
    /// is connected). Use G_CALLBACK() to cast the callback function to a #GCallback.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeCallback ();

    /// <summary>
    /// The type used for the various notification callbacks which can be registered
    /// on closures.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeClosureNotify (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data,
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure);

    /// <summary>
    /// The signal accumulator is a special callback function that can be used
    /// to collect return values of the various callbacks that are called
    /// during a signal emission. The signal accumulator is specified at signal
    /// creation time, if it is left %NULL, no accumulation of callback return
    /// values is performed. The return value of signal emissions is then the
    /// value returned by the last callback.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate bool NativeSignalAccumulator (
        /* <type name="SignalInvocationHint" type="GSignalInvocationHint*" managed-name="SignalInvocationHint" /> */
        /* transfer-ownership:none */
        SignalInvocationHint ihint,
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        IntPtr returnAccu,
        /* <type name="Value" type="const GValue*" managed-name="Value" /> */
        /* transfer-ownership:none */
        IntPtr handlerReturn,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data);

    /// <summary>
    /// The type used for marshaller functions.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeClosureMarshal (
        /* <type name="Closure" type="GClosure*" managed-name="Closure" /> */
        /* transfer-ownership:none */
        IntPtr closure,
        /* <type name="Value" type="GValue*" managed-name="Value" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr returnValue,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nParamValues,
        /* <array length="2" zero-terminated="0" type="GValue*">
            <type name="Value" type="GValue" managed-name="Value" />
            </array> */
        /* transfer-ownership:none */
        IntPtr paramValues,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr invocationHint,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        IntPtr marshalData);
}
