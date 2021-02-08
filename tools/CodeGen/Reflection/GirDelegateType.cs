// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Globalization;
using System.Reflection;
using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    class GirDelegateType : System.Type
    {
        Callback callback;
        bool unmanaged;

        public GirDelegateType(Callback callback, bool unmanaged)
        {
            this.callback = callback ?? throw new ArgumentNullException(nameof(callback));
            this.unmanaged = unmanaged;
            Name = callback.ManagedName;
            if (unmanaged) {
                var index = Name.LastIndexOf('.') + 1;
                Name = Name.Substring(0, index) + "Unmanaged" + Name.Substring(index);
            }
            if (callback.ParentNode is Field field) {
                var delcaringType = (Record)field.ParentNode;
                Name = $"{delcaringType.GirName}+{Name}";
            }
        }

        public override Assembly Assembly =>
            throw new NotImplementedException("GirDelegateType.Assembly");

        public override string AssemblyQualifiedName =>
            throw new NotImplementedException("GirDelegateType.AssemblyQualifiedName");

        public override System.Type BaseType => typeof(Delegate);

        public override string FullName => $"{Namespace}.{Name}";

        public override Guid GUID =>
            throw new NotImplementedException("GirDelegateType.GUID");

        public override bool IsConstructedGenericType => false;

        public override Module Module =>
            throw new NotImplementedException("GirDelegateType.Module");

        public override string Namespace => $"GISharp.Lib.{callback.Namespace.Name}";

        public override System.Type UnderlyingSystemType =>
            throw new NotImplementedException("GirDelegateType.UnderlyingSystemType");

        public override string Name { get; }

        public override string ToString() => FullName;

        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetConstructors");
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotImplementedException("GirDelegateType.GetCustomAttributes");
        }

        public override object[] GetCustomAttributes(System.Type attributeType, bool inherit)
        {
            throw new NotImplementedException("GirDelegateType.GetCustomAttributes");
        }

        public override System.Type GetElementType()
        {
            throw new NotImplementedException("GirDelegateType.GetElementType");
        }

        public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetEvent");
        }

        public override EventInfo[] GetEvents(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetEvents");
        }

        public override FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetField");
        }

        public override FieldInfo[] GetFields(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetFields");
        }

        public override System.Type GetInterface(string name, bool ignoreCase)
        {
            throw new NotImplementedException("GirDelegateType.GetInterface");
        }

        public override System.Type[] GetInterfaces()
        {
            throw new NotImplementedException("GirDelegateType.GetInterfaces");
        }

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetMembers");
        }

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetMethods");
        }

        public override System.Type GetNestedType(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetNestedType");
        }

        public override System.Type[] GetNestedTypes(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetNestedTypes");
        }

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirDelegateType.GetProperties");
        }

        public override object InvokeMember(string name, BindingFlags invokeAttr,
            Binder binder, object target, object[] args, ParameterModifier[] modifiers,
            CultureInfo culture, string[] namedParameters)
        {
            throw new NotImplementedException("GirDelegateType.InvokeMember");
        }

        public override bool IsDefined(System.Type attributeType, bool inherit)
        {
            throw new NotImplementedException("GirDelegateType.IsDefined");
        }

        protected override TypeAttributes GetAttributeFlagsImpl() => default;

        protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, System.Type[] types,
            ParameterModifier[] modifiers)
        {
            throw new NotImplementedException("GirDelegateType.GetConstructorImpl");
        }

        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, System.Type[] types,
            ParameterModifier[] modifiers)
        {
            throw new NotImplementedException("GirDelegateType.GetMethodImpl");
        }

        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr,
            Binder binder, System.Type returnType, System.Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException("GirDelegateType.GetPropertyImpl");
        }

        protected override bool HasElementTypeImpl() => false;

        protected override bool IsArrayImpl() => false;

        protected override bool IsByRefImpl() => true;

        protected override bool IsCOMObjectImpl() => false;

        protected override bool IsPointerImpl() => false;

        protected override bool IsPrimitiveImpl() => false;
    }
}
