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

        public override Assembly Assembly => throw new NotSupportedException();

        public override string AssemblyQualifiedName => throw new NotSupportedException();

        public override System.Type BaseType => typeof(Delegate);

        public override string FullName => $"{Namespace}.{Name}";

        public override Guid GUID => throw new NotSupportedException();

        public override Module Module => throw new NotSupportedException();

        public override string Namespace => $"GISharp.Lib.{callback.Namespace.Name}";

        public override System.Type UnderlyingSystemType => throw new NotSupportedException();

        public override string Name { get; }

        public override string ToString() => FullName;

        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(System.Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override System.Type GetElementType()
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

        public override System.Type GetInterface(string name, bool ignoreCase)
        {
            throw new NotSupportedException();
        }

        public override System.Type[] GetInterfaces()
        {
            throw new NotSupportedException();
        }

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override System.Type GetNestedType(string name, BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override System.Type[] GetNestedTypes(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            throw new NotSupportedException();
        }

        public override object InvokeMember(string name, BindingFlags invokeAttr,
            Binder binder, object target, object[] args, ParameterModifier[] modifiers,
            CultureInfo culture, string[] namedParameters)
        {
            throw new NotSupportedException();
        }

        public override bool IsDefined(System.Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        protected override TypeAttributes GetAttributeFlagsImpl() => default(TypeAttributes);

        protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, System.Type[] types,
            ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr,
            Binder binder, CallingConventions callConvention, System.Type[] types,
            ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr,
            Binder binder, System.Type returnType, System.Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotSupportedException();
        }

        protected override bool HasElementTypeImpl() => false;

        protected override bool IsArrayImpl() => false;

        protected override bool IsByRefImpl() => true;

        protected override bool IsCOMObjectImpl() => false;

        protected override bool IsPointerImpl() => false;

        protected override bool IsPrimitiveImpl() => false;
    }
}