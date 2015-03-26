using System;
using System.Collections.Generic;

namespace GI
{
  public partial class ObjectInfo : IMethodContainer
  {
    InfoCollection<ConstantInfo> constants;
    public InfoCollection<ConstantInfo> Constants {
      get {
        if (constants == null) {
          constants = new InfoCollection<ConstantInfo> (() => NConstants, GetConstant);
        }
        return constants;
      }
    }

    InfoCollection<FieldInfo> fields;
    public InfoCollection<FieldInfo> Fields {
      get {
        if (fields == null) {
          fields = new InfoCollection<FieldInfo> (() => NFields, GetField);
        }
        return fields;
      }
    }

    InfoCollection<InterfaceInfo> interfaces;
    public InfoCollection<InterfaceInfo> Interfaces {
      get {
        if (interfaces == null) {
          interfaces = new InfoCollection<InterfaceInfo> (() => NInterfaces, GetInterface);
        }
        return interfaces;
      }
    }

    InfoCollection<FunctionInfo> methods;
    public InfoCollection<FunctionInfo> Methods {
      get {
        if (methods == null) {
          methods = new InfoCollection<FunctionInfo> (() => NMethods, GetMethod);
        }
        return methods;
      }
    }

    InfoCollection<PropertyInfo> properties;
    public InfoCollection<PropertyInfo> Properties {
      get {
        if (properties == null) {
          properties = new InfoCollection<PropertyInfo> (() => NProperties, GetProperty);
        }
        return properties;
      }
    }

    InfoCollection<SignalInfo> signals;
    public InfoCollection<SignalInfo> Signals {
      get {
        if (signals == null) {
          signals = new InfoCollection<SignalInfo> (() => NSignals, GetSignal);
        }
        return signals;
      }
    }

    InfoCollection<VFuncInfo> vFuncs;
    public InfoCollection<VFuncInfo> VFuncs {
      get {
        if (vFuncs == null) {
          vFuncs = new InfoCollection<VFuncInfo> (() => NVfuncs, GetVFunc);
        }
        return vFuncs;
      }
    }
  }
}

