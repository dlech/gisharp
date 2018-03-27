using System;
using System.Linq;
using System.Reflection;

namespace GISharp.CodeGen.Reflection
{
    class GirPointerType : Type
    {
        readonly GirType type;

        internal GirPointerType(GirType type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
        }

        #region implemented abstract members of MemberInfo

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override string Name => type.Name + "*";

        #endregion

        #region implemented abstract members of Type

        public override Type GetInterface(string name, bool ignoreCase)
        {
            throw new NotSupportedException();
        }

        public override Type[] GetInterfaces()
        {
            throw new NotSupportedException();
        }

        public override Type GetElementType()
        {
            throw new NotSupportedException();
        }

        public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override EventInfo[] GetEvents(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override FieldInfo[] GetFields(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override Type GetNestedType(string name, BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override Type[] GetNestedTypes(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr,
            Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        protected override ConstructorInfo GetConstructorImpl (BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        protected override TypeAttributes GetAttributeFlagsImpl()
        {
            throw new NotSupportedException();
        }

        protected override bool HasElementTypeImpl() => false;

        protected override bool IsArrayImpl() => false;

        protected override bool IsByRefImpl() => false;

        protected override bool IsCOMObjectImpl() => false;

        protected override bool IsPointerImpl() => true;

        protected override bool IsPrimitiveImpl() => false;

        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override object InvokeMember(string name, BindingFlags invokeAttr,
            Binder binder, object target, object[] args, ParameterModifier[] modifiers,
            System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            throw new NotSupportedException();
        }

        public override Assembly Assembly => Assembly.GetExecutingAssembly();

        public override string AssemblyQualifiedName => throw new NotSupportedException();

        public override Type BaseType => type.BaseType;

        public override string FullName => Namespace + "." + Name;

        public override Guid GUID => throw new NotSupportedException();

        public override Module Module => throw new NotSupportedException();

        public override string Namespace => type.Namespace;

        public override Type UnderlyingSystemType => type;

        #endregion
    }
}
