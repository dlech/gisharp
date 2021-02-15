// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    partial class InterfaceInfo
    {
        IndexedCollection<ConstantInfo>? constants;

        /// <summary>
        /// Obtain interface type constants.
        /// </summary>
        public IndexedCollection<ConstantInfo> Constants {
            get {
                if (constants is null) {
                    constants = new(GetNConstants, GetConstant);
                }
                return constants;
            }
        }

        IndexedCollection<FunctionInfo>? methods;

        /// <summary>
        /// Obtain interface type methods.
        /// </summary>
        public IndexedCollection<FunctionInfo> Methods {
            get {
                if (methods is null) {
                    methods = new(GetNMethods, GetMethod);
                }
                return methods;
            }
        }

        IndexedCollection<BaseInfo>? prerequisites;

        /// <summary>
        /// Obtain interface type prerequisites.
        /// </summary>
        public IndexedCollection<BaseInfo> Prerequisites {
            get {
                if (prerequisites is null) {
                    prerequisites = new(GetNPrerequisites, GetPrerequisite);
                }
                return prerequisites;
            }
        }

        IndexedCollection<PropertyInfo>? properties;

        /// <summary>
        /// Obtain interface type properties.
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
        /// Obtain interface type signals.
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
        /// Obtain interface type vfuncs.
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
