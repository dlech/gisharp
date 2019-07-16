

using System;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.CodeGen.Reflection
{
    class GirRecordType : GirType
    {
        Record record;

        public GirRecordType(Record record) : base(record)
        {
            this.record = record;
        }

        public override System.Type BaseType => record.BaseType;
    }
}
