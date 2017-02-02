using System;
using System.Reflection;
using NUnitLite;
using NUnit.Common;

namespace Core.Test
{
    public class Program
    {
        public int Main (string[] args)
        {
            return new AutoRun(typeof(Program).GetTypeInfo().Assembly)
                .Execute(args, new ExtendedTextWrapper(Console.Out), Console.In);
        }
    }
}
