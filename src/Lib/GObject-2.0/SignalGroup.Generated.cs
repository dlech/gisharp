// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup']/*" />
    [GISharp.Runtime.SinceAttribute("2.72")]
    [GISharp.Runtime.GTypeAttribute("GSignalGroup", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class SignalGroup : GISharp.Lib.GObject.Object
    {
        private static readonly GISharp.Runtime.GType _GType = g_signal_group_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.Target']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        [GISharp.Runtime.GPropertyAttribute("target")]
        public GISharp.Lib.GObject.Object? Target { get => (GISharp.Lib.GObject.Object?)GetProperty("target")!; set => SetProperty("target", value); }

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.TargetType']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        [GISharp.Runtime.GPropertyAttribute("target-type", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Runtime.GType TargetType { get => (GISharp.Runtime.GType)GetProperty("target-type")!; set => SetProperty("target-type", value); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SignalGroup(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GSignalGroup for target instances of @target_type.
        /// </summary>
        /// <param name="targetType">
        /// the #GType of the target instance.
        /// </param>
        /// <returns>
        /// a new #GSignalGroup
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="SignalGroup" type="GSignalGroup*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* g_signal_group_new(
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.GType targetType);
        static partial void CheckNewArgs(GISharp.Runtime.GType targetType);

        [GISharp.Runtime.SinceAttribute("2.72")]
        static GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* New(GISharp.Runtime.GType targetType)
        {
            CheckNewArgs(targetType);
            var targetType_ = (GISharp.Runtime.GType)targetType;
            var ret_ = g_signal_group_new(targetType_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.SignalGroup(GISharp.Runtime.GType)']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public SignalGroup(GISharp.Runtime.GType targetType) : this((System.IntPtr)New(targetType), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='BindSignalHandler']/*" />
        public delegate void BindSignalHandler(GISharp.Lib.GObject.SignalGroup signalGroup, GISharp.Lib.GObject.Object instance);

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.BindSignal']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        [GISharp.Runtime.GSignalAttribute("bind", When = GISharp.Runtime.EmissionStage.Last)]
        public event BindSignalHandler BindSignal { add => AddEventSignalHandler("bind", value); remove => RemoveEventSignalHandler("bind", value); }

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void ManagedBindSignalHandler(GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* signalGroup_, GISharp.Lib.GObject.Object.UnmanagedStruct* instance_, System.IntPtr userData_)
        {
            try
            {
                var signalGroup = GISharp.Lib.GObject.SignalGroup.GetInstance<GISharp.Lib.GObject.SignalGroup>((System.IntPtr)signalGroup_, GISharp.Runtime.Transfer.None)!;
                var instance = GISharp.Lib.GObject.Object.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)instance_, GISharp.Runtime.Transfer.None)!;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (GISharp.Runtime.CClosureData)gcHandle.Target!;
                ((BindSignalHandler)userData.Callback)(signalGroup, instance);
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='UnbindSignalHandler']/*" />
        public delegate void UnbindSignalHandler(GISharp.Lib.GObject.SignalGroup signalGroup);

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.UnbindSignal']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        [GISharp.Runtime.GSignalAttribute("unbind", When = GISharp.Runtime.EmissionStage.Last)]
        public event UnbindSignalHandler UnbindSignal { add => AddEventSignalHandler("unbind", value); remove => RemoveEventSignalHandler("unbind", value); }

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void ManagedUnbindSignalHandler(GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* signalGroup_, System.IntPtr userData_)
        {
            try
            {
                var signalGroup = GISharp.Lib.GObject.SignalGroup.GetInstance<GISharp.Lib.GObject.SignalGroup>((System.IntPtr)signalGroup_, GISharp.Runtime.Transfer.None)!;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (GISharp.Runtime.CClosureData)gcHandle.Target!;
                ((UnbindSignalHandler)userData.Callback)(signalGroup);
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_signal_group_get_type();

        /// <summary>
        /// Blocks all signal handlers managed by @self so they will not
        /// be called during any signal emissions. Must be unblocked exactly
        /// the same number of times it has been blocked to become active again.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This blocked state will be kept across changes of the target instance.
        /// </para>
        /// </remarks>
        /// <param name="self">
        /// the #GSignalGroup
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_signal_group_block(
        /* <type name="SignalGroup" type="GSignalGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* self);
        partial void CheckBlockArgs();

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.Block()']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public void Block()
        {
            CheckBlockArgs();
            var self_ = (GISharp.Lib.GObject.SignalGroup.UnmanagedStruct*)UnsafeHandle;
            g_signal_group_block(self_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Connects @closure to the signal @detailed_signal on #GSignalGroup:target.
        /// </summary>
        /// <remarks>
        /// <para>
        /// You cannot connect a signal handler after #GSignalGroup:target has been set.
        /// </para>
        /// </remarks>
        /// <param name="self">
        /// a #GSignalGroup
        /// </param>
        /// <param name="detailedSignal">
        /// a string of the form `signal-name` with optional `::signal-detail`
        /// </param>
        /// <param name="closure">
        /// the closure to connect.
        /// </param>
        /// <param name="after">
        /// whether the handler should be called before or after the
        ///  default handler of the signal.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.74")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_signal_group_connect_closure(
        /* <type name="SignalGroup" type="GSignalGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* self,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* detailedSignal,
        /* <type name="Closure" type="GClosure*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* closure,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean after);
        partial void CheckConnectClosureArgs(GISharp.Runtime.UnownedUtf8 detailedSignal, GISharp.Lib.GObject.Closure closure, bool after);

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.ConnectClosure(GISharp.Runtime.UnownedUtf8,GISharp.Lib.GObject.Closure,bool)']/*" />
        [GISharp.Runtime.SinceAttribute("2.74")]
        public void ConnectClosure(GISharp.Runtime.UnownedUtf8 detailedSignal, GISharp.Lib.GObject.Closure closure, bool after)
        {
            CheckConnectClosureArgs(detailedSignal, closure, after);
            var self_ = (GISharp.Lib.GObject.SignalGroup.UnmanagedStruct*)UnsafeHandle;
            var detailedSignal_ = (byte*)detailedSignal.UnsafeHandle;
            var closure_ = (GISharp.Lib.GObject.Closure.UnmanagedStruct*)closure.UnsafeHandle;
            var after_ = GISharp.Runtime.BooleanExtensions.ToBoolean(after);
            g_signal_group_connect_closure(self_, detailedSignal_, closure_, after_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Gets the target instance used when connecting signals.
        /// </summary>
        /// <param name="self">
        /// the #GSignalGroup
        /// </param>
        /// <returns>
        /// The target instance
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern GISharp.Lib.GObject.Object.UnmanagedStruct* g_signal_group_dup_target(
        /* <type name="SignalGroup" type="GSignalGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* self);
        partial void CheckDupTargetArgs();

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.DupTarget()']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public GISharp.Lib.GObject.Object? DupTarget()
        {
            CheckDupTargetArgs();
            var self_ = (GISharp.Lib.GObject.SignalGroup.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_signal_group_dup_target(self_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GObject.Object.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Sets the target instance used when connecting signals. Any signal
        /// that has been registered with g_signal_group_connect_object() or
        /// similar functions will be connected to this object.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the target instance was previously set, signals will be
        /// disconnected from that object prior to connecting to @target.
        /// </para>
        /// </remarks>
        /// <param name="self">
        /// the #GSignalGroup.
        /// </param>
        /// <param name="target">
        /// The target instance used
        ///     when connecting signals.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_signal_group_set_target(
        /* <type name="SignalGroup" type="GSignalGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* self,
        /* <type name="Object" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GObject.Object.UnmanagedStruct* target);
        partial void CheckSetTargetArgs(GISharp.Lib.GObject.Object? target);

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.SetTarget(GISharp.Lib.GObject.Object?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public void SetTarget(GISharp.Lib.GObject.Object? target)
        {
            CheckSetTargetArgs(target);
            var self_ = (GISharp.Lib.GObject.SignalGroup.UnmanagedStruct*)UnsafeHandle;
            var target_ = (GISharp.Lib.GObject.Object.UnmanagedStruct*)(target?.UnsafeHandle ?? System.IntPtr.Zero);
            g_signal_group_set_target(self_, target_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Unblocks all signal handlers managed by @self so they will be
        /// called again during any signal emissions unless it is blocked
        /// again. Must be unblocked exactly the same number of times it
        /// has been blocked to become active again.
        /// </summary>
        /// <param name="self">
        /// the #GSignalGroup
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_signal_group_unblock(
        /* <type name="SignalGroup" type="GSignalGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.SignalGroup.UnmanagedStruct* self);
        partial void CheckUnblockArgs();

        /// <include file="SignalGroup.xmldoc" path="declaration/member[@name='SignalGroup.Unblock()']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public void Unblock()
        {
            CheckUnblockArgs();
            var self_ = (GISharp.Lib.GObject.SignalGroup.UnmanagedStruct*)UnsafeHandle;
            g_signal_group_unblock(self_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }
    }
}