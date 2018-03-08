
using System.Reflection;
using NUnit.Framework;
using NUnitLite;

static class Program
{
    public static int Main(string[] args)
    {
        return new AutoRun(Assembly.GetAssembly(typeof(GISharp.Test.Core.Helpers))).Execute(args);
    }
}
