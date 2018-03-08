using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GISharp.Lib.GIRepository.Dynamic
{
    class NamespaceDynamicMetaObject : DynamicMetaObject
    {
        readonly BindingRestrictions typeRestriction;

        Namespace Namespace { get { return (Namespace)Value; } }

        public NamespaceDynamicMetaObject (Expression expression, Namespace @namespace)
            : base (expression, BindingRestrictions.Empty, @namespace)
        {
            typeRestriction = BindingRestrictions.GetTypeRestriction (Expression, typeof (Namespace));
        }

        public override DynamicMetaObject BindInvokeMember (InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            var functionInfo = Namespace.FindByName (binder.Name) as FunctionInfo;
            if (functionInfo != null) {
                var expression = functionInfo.GetInvokeExpression (binder.CallInfo, binder.ReturnType, null, args);
                return new DynamicMetaObject (expression, typeRestriction);
            }
            return base.BindInvokeMember (binder, args);
        }

        public override DynamicMetaObject BindGetMember (GetMemberBinder binder)
        {
            var info = Namespace.FindByName (binder.Name);
            if (info != null) {
                var expression = Expression.Constant (info);
                return new DynamicMetaObject (expression, typeRestriction);
            }
            return base.BindGetMember (binder);
        }

        public override IEnumerable<string> GetDynamicMemberNames ()
        {
            return Namespace.Infos.Keys;
        }
    }
}
