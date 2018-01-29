
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
        readonly UnmanagedClosureMarshal value;

        public SignalCMarshaller (UnmanagedClosureMarshal value)
        {
            this.value = value;
        }

        public static implicit operator SignalCMarshaller (UnmanagedClosureMarshal value)
        {
            return new SignalCMarshaller (value);
        }

        public static implicit operator UnmanagedClosureMarshal (SignalCMarshaller value)
        {
            return value.value;
        }
    }
}
