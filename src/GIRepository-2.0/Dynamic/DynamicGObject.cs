using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository.Dynamic
{
    public class DynamicGObject : IDynamicMetaObjectProvider, IDisposable
    {
        static readonly int pspecValueTypeOffset;

        static DynamicGObject ()
        {
            var pspecInfo = (ObjectInfo)Repository.Namespaces["GObject"].FindByName("ParamSpec")!;
            pspecValueTypeOffset = pspecInfo.Fields["value_type"].Offset;
        }

        public IntPtr Handle { get; private set; }

        public DynamicGObject (IntPtr handle)
        {
            Handle = g_object_ref (handle);
        }

        public DynamicMetaObject GetMetaObject (Expression parameter)
        {
            return new DynamicGObjectMetaObject (parameter, this);
        }

        ~DynamicGObject ()
        {
            Dispose (false);
        }

        public void Dispose ()
        {
            Dispose (true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            g_object_unref (Handle);
        }

        public void SetProperty(string name, object? value)
        {
            if (name is null) {
                throw new ArgumentNullException (nameof (name));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var objectClassPtr = Marshal.ReadIntPtr (Handle);
            var pspecPtr = g_object_class_find_property (objectClassPtr, namePtr);
            try {
                if (pspecPtr == IntPtr.Zero) {
                    var message = $"Could not find property named {name}";
                    throw new ArgumentException (message, nameof (name));
                }
                var valueType = Marshal.PtrToStructure<UIntPtr>(pspecPtr + pspecValueTypeOffset);
                var gvalue = new GValue(valueType);
                gvalue.Set(value);
                g_object_set_property(Handle, namePtr, in gvalue);
            } finally {
                GMarshal.Free (namePtr);
            }
        }

        public object? GetProperty(string name)
        {
            if (name is null) {
                throw new ArgumentNullException (nameof (name));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            g_object_get_property (Handle, namePtr, out var value);
            GMarshal.Free (namePtr);

            return value.Get ();
        }

        public ulong Connect(string signalSpec, System.Func<object?[], object?> callback, ConnectFlags flags = default)
        {
            using var closure = new GClosure(callback);
            return Connect(signalSpec, closure, flags);
        }

        public ulong Connect(string signalSpec, System.Func<object?> callback, ConnectFlags flags = default)
        {
            using var closure = new GClosure(callback);
            return Connect(signalSpec, closure, flags);
        }

        public ulong Connect(string signalSpec, Action<object?[]> callback, ConnectFlags flags = default)
        {
            using var closure = new GClosure(callback);
            return Connect(signalSpec, closure, flags);
        }

        public ulong Connect(string signalSpec, Action callback, ConnectFlags flags = default)
        {
            using var closure = new GClosure(callback);
            return Connect(signalSpec, closure, flags);
        }

        ulong Connect(string signalSpec, GClosure closure, ConnectFlags flags)
        {
            using var signalSpec_ = (Utf8)signalSpec;
            var ret = g_signal_connect_closure(Handle, signalSpec_.Handle, closure.Handle, flags);
            return ret;
        }

        public void Disconnect (ulong signalId)
        {
            g_signal_handler_disconnect(Handle, (CULong)signalId);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref (IntPtr obj);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref (IntPtr obj);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_set_property(IntPtr obj, IntPtr name, in GValue value);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_get_property(IntPtr obj, IntPtr name, out GValue value);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern CULong g_signal_connect_closure(IntPtr obj, IntPtr detailedSignal, IntPtr closure, ConnectFlags flags);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_signal_handler_disconnect(IntPtr obj, CULong id);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_class_find_property (IntPtr oclass, IntPtr name);
    }

    class DynamicGObjectMetaObject : DynamicMetaObject
    {
        readonly BindingRestrictions typeRestrictions;
        public readonly ObjectInfo Info;

        public DynamicGObject Object { get { return (DynamicGObject)Value; } }

        public DynamicGObjectMetaObject (Expression expression, DynamicGObject obj)
            : base (expression, BindingRestrictions.Empty, obj)
        {
            typeRestrictions = BindingRestrictions.GetTypeRestriction (Expression, typeof (DynamicGObject));

            var objectClassPtr = Marshal.ReadIntPtr (obj.Handle);
            var gtype = Marshal.PtrToStructure<GType> (objectClassPtr);
            Info = (ObjectInfo)Repository.FindByGType(gtype)!;
        }

        public override DynamicMetaObject BindInvokeMember (InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            var methodInfo = default (FunctionInfo);
            ObjectInfo? i = Info;
            while (i is not null) {
                methodInfo = i.FindMethod (binder.Name);
                if (methodInfo is not null) {
                    break;
                }
                i = i.Parent;
            }
            if (methodInfo is null) {
                foreach (var iface in Info.Interfaces) {
                    methodInfo = iface.FindMethod (binder.Name);
                    if (methodInfo is not null) {
                        break;
                    }
                }
            }
            if (methodInfo is not null) {
                var expression = methodInfo.GetInvokeExpression (binder.CallInfo, binder.ReturnType, Object, args);
                return new DynamicMetaObject (expression, typeRestrictions);
            }
            return base.BindInvokeMember (binder, args);
        }

        public override IEnumerable<string> GetDynamicMemberNames ()
        {
            return Info.Constants.Keys
                       .Concat (Info.Fields.Keys)
                       .Concat (Info.Methods.Keys)
                       .Concat (Info.Properties.Keys);
        }
    }
}
