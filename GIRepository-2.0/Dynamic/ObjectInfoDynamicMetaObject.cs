﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace GISharp.Lib.GIRepository.Dynamic
{
    class ObjectInfoDynamicMetaObject : DynamicMetaObject
    {
        readonly BindingRestrictions typeRestriction;

        ObjectInfo Info { get { return (ObjectInfo)Value; } }

        public ObjectInfoDynamicMetaObject (Expression expression, ObjectInfo info)
            : base (expression, BindingRestrictions.Empty, info)
        {
            typeRestriction = BindingRestrictions.GetTypeRestriction (Expression, typeof (ObjectInfo));
        }

        public override DynamicMetaObject BindCreateInstance (CreateInstanceBinder binder, DynamicMetaObject[] args)
        {
            return base.BindCreateInstance (binder, args);
        }

        public override DynamicMetaObject BindInvokeMember (InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            var methodInfo = default (FunctionInfo);
            var i = Info;
            while (i != null) {
                methodInfo = i.FindMethod (binder.Name);
                if (methodInfo != null) {
                    break;
                }
                i = i.Parent;
            }
            if (methodInfo != null) {
                var expression = methodInfo.GetInvokeExpression (binder.CallInfo, binder.ReturnType, null, args);
                return new DynamicMetaObject (expression, typeRestriction);
            }
            return base.BindInvokeMember (binder, args);
        }

        public override IEnumerable<string> GetDynamicMemberNames ()
        {
            return Info.Constants.Keys
                       .Concat (Info.Fields.Keys)
                       .Concat (Info.Methods.Keys);
        }
    }
}
