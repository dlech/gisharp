using System;
using System.Linq;
using System.Reflection;

namespace GISharp.CodeGen.Reflection
{
    class GirGenericType : Type
    {
        readonly GirType type;
        readonly Type[] parameters;

        internal GirGenericType(GirType type, params Type[] parameters)
        {
            if (type is null) {
                throw new ArgumentNullException(nameof(type));
            }
            if (parameters is null) {
                throw new ArgumentNullException(nameof(parameters));
            }
            this.type = type;
            this.parameters = parameters;
        }

        public override bool IsGenericType => true;

        public override bool IsConstructedGenericType => false;

        public override Type[] GenericTypeArguments => parameters;

        public override Type GetGenericTypeDefinition() => type;

        #region implemented abstract members of MemberInfo

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new InvalidOperationException();
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new InvalidOperationException();
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new InvalidOperationException();
        }

        public override string Name {
            get {
                return string.Format("{0}`{1}[{2}]", type.Name, parameters.Length, string.Join(",", parameters.Select(p => p.FullName)));
            }
        }

        #endregion

        #region implemented abstract members of Type

        public override Type GetInterface(string name, bool ignoreCase)
        {
            throw new InvalidOperationException();
        }

        public override Type[] GetInterfaces()
        {
            throw new InvalidOperationException();
        }

        public override Type GetElementType()
        {
            throw new InvalidOperationException();
        }

        public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override EventInfo[] GetEvents(BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override FieldInfo[] GetFields(BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new InvalidOperationException();
        }

        public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override Type GetNestedType(string name, BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override Type[] GetNestedTypes(BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            throw new InvalidOperationException();
        }

        protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new InvalidOperationException();
        }

        protected override TypeAttributes GetAttributeFlagsImpl()
        {
            throw new InvalidOperationException();
        }

        protected override bool HasElementTypeImpl() => true;

        protected override bool IsArrayImpl() => true;

        protected override bool IsByRefImpl() => false;

        protected override bool IsCOMObjectImpl() => false;

        protected override bool IsPointerImpl() => false;

        protected override bool IsPrimitiveImpl() => false;

        public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
        {
            throw new InvalidOperationException();
        }

        public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            throw new InvalidOperationException();
        }

        public override Assembly Assembly => Assembly.GetExecutingAssembly();

        public override string AssemblyQualifiedName => throw new InvalidOperationException();

        public override Type BaseType => type.BaseType;

        public override string FullName => Namespace + "." + Name;

        public override Guid GUID => throw new InvalidOperationException();

        public override Module Module => throw new InvalidOperationException();

        public override string Namespace => type.Namespace;

        public override Type UnderlyingSystemType => type;

        #endregion
    }
}
