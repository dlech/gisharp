// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Reflection;

namespace GISharp.CodeGen.Reflection
{
    class GirPointerType : Type
    {
        readonly Type type;

        internal GirPointerType(Type type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public override string ToString() => FullName;

        public override Type MakePointerType() => new GirPointerType(this);

        #region implemented abstract members of MemberInfo

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotImplementedException("GirPointerType.IsDefined");
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotImplementedException("GirPointerType.GetCustomAttributes");
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotImplementedException("GirPointerType.GetCustomAttributes");
        }
        public override bool IsConstructedGenericType => false;

        public override string Name => type.Name + "*";

        #endregion

        #region implemented abstract members of Type

        public override Type GetInterface(string name, bool ignoreCase)
        {
            throw new NotImplementedException("GirPointerType.GetInterface");
        }

        public override Type[] GetInterfaces()
        {
            throw new NotImplementedException("GirPointerType.GetInterfaces");
        }

        public override Type GetElementType() => type;

        public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetEvent");
        }

        public override EventInfo[] GetEvents(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetEvents");
        }

        public override FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetField");
        }

        public override FieldInfo[] GetFields(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetFields");
        }

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetMembers");
        }

        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException("GirPointerType.GetMethodImpl");
        }

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetMethods");
        }

        public override Type GetNestedType(string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetNestedType");
        }

        public override Type[] GetNestedTypes(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetNestedTypes");
        }

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetProperties");
        }

        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr,
            Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException("GirPointerType.GetPropertyImpl");
        }

        protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException("GirPointerType.GetConstructorImpl");
        }

        protected override TypeAttributes GetAttributeFlagsImpl()
        {
            throw new NotImplementedException("GirPointerType.GetAttributeFlagsImpl");
        }

        protected override bool HasElementTypeImpl() => false;

        protected override bool IsArrayImpl() => false;

        protected override bool IsByRefImpl() => false;

        protected override bool IsCOMObjectImpl() => false;

        protected override bool IsPointerImpl() => true;

        protected override bool IsPrimitiveImpl() => false;

        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            throw new NotImplementedException("GirPointerType.GetConstructors");
        }

        public override object InvokeMember(string name, BindingFlags invokeAttr,
            Binder binder, object target, object[] args, ParameterModifier[] modifiers,
            System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            throw new NotImplementedException("GirPointerType.InvokeMember");
        }

        public override Assembly Assembly => Assembly.GetExecutingAssembly();

        public override string AssemblyQualifiedName =>
            throw new NotImplementedException("GirPointerType.AssemblyQualifiedName");

        public override Type BaseType => type.BaseType;

        public override string FullName => Namespace + "." + Name;

        public override Guid GUID =>
            throw new NotImplementedException("GirPointerType.GUID");

        public override Module Module =>
            throw new NotImplementedException("GirPointerType.Module");

        public override string Namespace => type.Namespace;

        public override Type UnderlyingSystemType => type;

        #endregion
    }
}
