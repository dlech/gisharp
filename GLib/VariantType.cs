using System;

namespace GISharp.GLib
{
    public partial class VariantType
    {
        // these static properties take the place of the G_VARIANT_TYPE_* macros

        static Lazy<VariantType> lazyBoolean = new Lazy<VariantType> (() => new VariantType ("b"));

        public static VariantType Boolean {
            get {
                return lazyBoolean.Value;
            }
        }

        static Lazy<VariantType> lazyByte = new Lazy<VariantType> (() => new VariantType ("y"));

        public static VariantType Byte {
            get {
                return lazyByte.Value;
            }
        }

        static Lazy<VariantType> lazyInt16 = new Lazy<VariantType> (() => new VariantType ("n"));

        public static VariantType Int16 {
            get {
                return lazyInt16.Value;
            }
        }

        static Lazy<VariantType> lazyUInt16 = new Lazy<VariantType> (() => new VariantType ("q"));

        public static VariantType UInt16 {
            get {
                return lazyUInt16.Value;
            }
        }

        static Lazy<VariantType> lazyInt32 = new Lazy<VariantType> (() => new VariantType ("i"));

        public static VariantType Int32 {
            get {
                return lazyInt32.Value;
            }
        }

        static Lazy<VariantType> lazyUInt32 = new Lazy<VariantType> (() => new VariantType ("u"));

        public static VariantType UInt32 {
            get {
                return lazyUInt32.Value;
            }
        }

        static Lazy<VariantType> lazyInt64 = new Lazy<VariantType> (() => new VariantType ("x"));

        public static VariantType Int64 {
            get {
                return lazyInt64.Value;
            }
        }

        static Lazy<VariantType> lazyUInt64 = new Lazy<VariantType> (() => new VariantType ("t"));

        public static VariantType UInt64 {
            get {
                return lazyUInt64.Value;
            }
        }

        static Lazy<VariantType> lazyDBusHandle = new Lazy<VariantType> (() => new VariantType ("h"));

        public static VariantType DBusHandle {
            get {
                return lazyDBusHandle.Value;
            }
        }

        static Lazy<VariantType> lazyDouble = new Lazy<VariantType> (() => new VariantType ("d"));

        public static VariantType Double {
            get {
                return lazyDouble.Value;
            }
        }

        static Lazy<VariantType> lazyString = new Lazy<VariantType> (() => new VariantType ("s"));

        public static VariantType String {
            get {
                return lazyString.Value;
            }
        }

        static Lazy<VariantType> lazyObjectPath = new Lazy<VariantType> (() => new VariantType ("o"));

        public static VariantType ObjectPath {
            get {
                return lazyObjectPath.Value;
            }
        }

        static Lazy<VariantType> lazyDBusSignature = new Lazy<VariantType> (() => new VariantType ("g"));

        public static VariantType DBusSignature {
            get {
                return lazyDBusSignature.Value;
            }
        }

        static Lazy<VariantType> lazyBoxedVariant = new Lazy<VariantType> (() => new VariantType ("v"));

        public static VariantType BoxedVariant {
            get {
                return lazyBoxedVariant.Value;
            }
        }

        static Lazy<VariantType> lazyAny = new Lazy<VariantType> (() => new VariantType ("*"));

        public static VariantType Any {
            get {
                return lazyAny.Value;
            }
        }

        static Lazy<VariantType> lazyBasic = new Lazy<VariantType> (() => new VariantType ("?"));

        public static VariantType Basic {
            get {
                return lazyBasic.Value;
            }
        }

        static Lazy<VariantType> lazyMaybe = new Lazy<VariantType> (() => new VariantType ("m*"));

        public static VariantType Maybe {
            get {
                return lazyMaybe.Value;
            }
        }

        static Lazy<VariantType> lazyArray = new Lazy<VariantType> (() => new VariantType ("a*"));

        public static VariantType Array {
            get {
                return lazyArray.Value;
            }
        }

        static Lazy<VariantType> lazyTuple = new Lazy<VariantType> (() => new VariantType ("r"));

        public static VariantType Tuple {
            get {
                return lazyTuple.Value;
            }
        }

        static Lazy<VariantType> lazyUnit = new Lazy<VariantType> (() => new VariantType ("()"));

        public static VariantType Unit {
            get {
                return lazyUnit.Value;
            }
        }

        static Lazy<VariantType> lazyDictEntry = new Lazy<VariantType> (() => new VariantType ("{?*}"));

        public static VariantType DictEntry {
            get {
                return lazyDictEntry.Value;
            }
        }

        static Lazy<VariantType> lazyDictionary = new Lazy<VariantType> (() => new VariantType ("a{?*}"));

        public static VariantType Dictionary {
            get {
                return lazyDictionary.Value;
            }
        }

        static Lazy<VariantType> lazyStringArray = new Lazy<VariantType> (() => new VariantType ("as"));

        public static VariantType StringArray {
            get {
                return lazyStringArray.Value;
            }
        }

        static Lazy<VariantType> lazyObjectPathArray = new Lazy<VariantType> (() => new VariantType ("ao"));

        public static VariantType ObjectPathArray {
            get {
                return lazyObjectPathArray.Value;
            }
        }

        static Lazy<VariantType> lazyByteString = new Lazy<VariantType> (() => new VariantType ("ay"));

        public static VariantType ByteString {
            get {
                return lazyByteString.Value;
            }
        }

        static Lazy<VariantType> lazyByteStringArray = new Lazy<VariantType> (() => new VariantType ("aay"));

        public static VariantType ByteStringArray {
            get {
                return lazyByteStringArray.Value;
            }
        }

        static Lazy<VariantType> lazyVarDict = new Lazy<VariantType> (() => new VariantType ("a{sv}"));

        public static VariantType VarDict {
            get {
                return lazyVarDict.Value;
            }
        }
    }
}
