using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace GISharp.Lib.GIRepository.Dynamic
{
    public class DynamicStruct : IDynamicMetaObjectProvider
	{
		public IntPtr Handle { get; }

        public StructInfo Info { get; }

        public DynamicStruct (IntPtr handle, StructInfo info)
        {
            Handle = handle;
            Info = info;
        }

        public DynamicMetaObject GetMetaObject (Expression parameter)
        {
            return new DynamicStructMetaObject (parameter, this);
        }
	}

    class DynamicStructMetaObject : DynamicMetaObject
    {
        readonly BindingRestrictions typeRestrictions;

        public DynamicStruct Struct { get { return (DynamicStruct)Value!; } }

        public DynamicStructMetaObject (Expression expression, DynamicStruct obj)
            : base (expression, BindingRestrictions.Empty, obj)
        {
            typeRestrictions = BindingRestrictions.GetTypeRestriction (Expression, typeof (DynamicStruct));
        }

        public override DynamicMetaObject BindInvokeMember (InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            var methodInfo = Struct.Info.Methods.SingleOrDefault (m => m.Name == binder.Name);
            if (methodInfo is not null) {
                var expression = methodInfo.GetInvokeExpression (binder.CallInfo, binder.ReturnType, Struct, args);
                return new DynamicMetaObject (expression, typeRestrictions);
            }
            return base.BindInvokeMember (binder, args);
        }

        public override IEnumerable<string> GetDynamicMemberNames ()
        {
            return Struct.Info.Fields.Keys
                         .Concat (Struct.Info.Methods.Keys);
        }
    }
}
