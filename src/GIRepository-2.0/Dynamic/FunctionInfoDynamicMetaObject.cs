// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System.Dynamic;
using System.Linq.Expressions;

namespace GISharp.Lib.GIRepository.Dynamic
{
    class FunctionInfoDynamicMetaObject : DynamicMetaObject
    {
        readonly BindingRestrictions typeRestriction;

        FunctionInfo Info => (FunctionInfo)Value!;

        public FunctionInfoDynamicMetaObject(Expression parameter, FunctionInfo info)
            : base(parameter, BindingRestrictions.Empty, info)
        {
            typeRestriction = BindingRestrictions.GetTypeRestriction(Expression, typeof(FunctionInfo));
        }

        public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
        {
            var expression = Info.GetInvokeExpression(binder.CallInfo, binder.ReturnType, null, args);
            return new DynamicMetaObject(expression, typeRestriction);
        }
    }
}
