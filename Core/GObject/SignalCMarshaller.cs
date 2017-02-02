
namespace GISharp.GObject
{
    /// <summary>
    /// This is the signature of marshaller functions, required to marshall
    /// arrays of parameter values to signal emissions into C language callback
    /// invocations. It is merely an alias to #GClosureMarshal since the #GClosure
    /// mechanism takes over responsibility of actual function invocation for the
    /// signal system.
    /// </summary>
    struct SignalCMarshaller
    {
        readonly NativeClosureMarshal value;

        public SignalCMarshaller (NativeClosureMarshal value)
        {
            this.value = value;
        }

        public static implicit operator SignalCMarshaller (NativeClosureMarshal value)
        {
            return new SignalCMarshaller (value);
        }

        public static implicit operator NativeClosureMarshal (SignalCMarshaller value)
        {
            return value.value;
        }
    }
}
