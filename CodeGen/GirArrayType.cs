using System;
using System.Reflection;

namespace GISharp.CodeGen
{
    public class GirArrayType : Type
    {
        GirType type;

        public GirArrayType (GirType type)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof(type));
            }
            this.type = type;
        }

        public override Type MakeByRefType ()
        {
            return new GirByRefType (this);
        }

        #region implemented abstract members of MemberInfo

        public override bool IsDefined (Type attributeType, bool inherit)
        {
            throw new NotImplementedException ();
        }

        public override object[] GetCustomAttributes (bool inherit)
        {
            throw new NotImplementedException ();
        }

        public override object[] GetCustomAttributes (Type attributeType, bool inherit)
        {
            throw new NotImplementedException ();
        }

        public override string Name {
            get {
                return type.Name + "[]";
            }
        }

        #endregion

        #region implemented abstract members of Type

        public override Type GetInterface (string name, bool ignoreCase)
        {
            throw new NotImplementedException ();
        }

        public override Type[] GetInterfaces ()
        {
            throw new NotImplementedException ();
        }

        public override Type GetElementType ()
        {
            throw new NotImplementedException ();
        }

        public override EventInfo GetEvent (string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override EventInfo[] GetEvents (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override FieldInfo GetField (string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override FieldInfo[] GetFields (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override MemberInfo[] GetMembers (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        protected override MethodInfo GetMethodImpl (string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException ();
        }

        public override MethodInfo[] GetMethods (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override Type GetNestedType (string name, BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override Type[] GetNestedTypes (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override PropertyInfo[] GetProperties (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        protected override PropertyInfo GetPropertyImpl (string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException ();
        }

        protected override ConstructorInfo GetConstructorImpl (BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            throw new NotImplementedException ();
        }

        protected override TypeAttributes GetAttributeFlagsImpl ()
        {
            throw new NotImplementedException ();
        }

        protected override bool HasElementTypeImpl ()
        {
            return true;
        }

        protected override bool IsArrayImpl ()
        {
            return true;
        }

        protected override bool IsByRefImpl ()
        {
            return false;
        }

        protected override bool IsCOMObjectImpl ()
        {
            return false;
        }

        protected override bool IsPointerImpl ()
        {
            return false;
        }

        protected override bool IsPrimitiveImpl ()
        {
            return false;
        }

        public override ConstructorInfo[] GetConstructors (BindingFlags bindingAttr)
        {
            throw new NotImplementedException ();
        }

        public override object InvokeMember (string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
        {
            throw new NotImplementedException ();
        }

        public override Assembly Assembly {
            get {
                return Assembly.GetExecutingAssembly ();
            }
        }

        public override string AssemblyQualifiedName {
            get {
                throw new NotImplementedException ();
            }
        }

        public override Type BaseType {
            get {
                throw new NotImplementedException ();
            }
        }

        public override string FullName {
            get {
                return Namespace + "." + Name;
            }
        }

        public override Guid GUID {
            get {
                throw new NotImplementedException ();
            }
        }

        public override Module Module {
            get {
                throw new NotImplementedException ();
            }
        }

        public override string Namespace {
            get {
                return type.Namespace;
            }
        }

        public override Type UnderlyingSystemType {
            get {
                return type;
            }
        }

        #endregion
    }
}
