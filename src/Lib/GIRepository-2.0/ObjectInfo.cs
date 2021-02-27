// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    partial class ObjectInfo
    {
        IndexedCollection<ConstantInfo>? constants;

        /// <summary>
        /// Obtain object type constants.
        /// </summary>
        public IndexedCollection<ConstantInfo> Constants {
            get {
                if (constants is null) {
                    constants = new(GetNConstants, GetConstant);
                }
                return constants;
            }
        }

        IndexedCollection<FieldInfo>? fields;

        /// <summary>
        /// Obtain object type fields.
        /// </summary>
        public IndexedCollection<FieldInfo> Fields {
            get {
                if (fields is null) {
                    fields = new(GetNFields, GetField);
                }
                return fields;
            }
        }

        IndexedCollection<InterfaceInfo>? interfaces;

        /// <summary>
        /// Obtain object type interfaces.
        /// </summary>
        public IndexedCollection<InterfaceInfo> Interfaces {
            get {
                if (interfaces is null) {
                    interfaces = new(GetNInterfaces, GetInterface);
                }
                return interfaces;
            }
        }

        IndexedCollection<FunctionInfo>? methods;

        /// <summary>
        /// Obtain object type methods.
        /// </summary>
        public IndexedCollection<FunctionInfo> Methods {
            get {
                if (methods is null) {
                    methods = new(GetNMethods, GetMethod);
                }
                return methods;
            }
        }

        IndexedCollection<PropertyInfo>? properties;

        /// <summary>
        /// Obtain object type properties.
        /// </summary>
        public IndexedCollection<PropertyInfo> Properties {
            get {
                if (properties is null) {
                    properties = new(GetNProperties, GetProperty);
                }
                return properties;
            }
        }

        IndexedCollection<SignalInfo>? signals;

        /// <summary>
        /// Obtain object type signals.
        /// </summary>
        public IndexedCollection<SignalInfo> Signals {
            get {
                if (signals is null) {
                    signals = new(GetNSignals, GetSignal);
                }
                return signals;
            }
        }

        IndexedCollection<VFuncInfo>? vFuncs;

        /// <summary>
        /// Obtain object type vfuncs.
        /// </summary>
        public IndexedCollection<VFuncInfo> VFuncs {
            get {
                if (vFuncs is null) {
                    vFuncs = new(GetNVFuncs, GetVFunc);
                }
                return vFuncs;
            }
        }
    }
}
