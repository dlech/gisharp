using System.Collections.Immutable;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using NUnit.Framework;
using static Microsoft.CodeAnalysis.DiagnosticSeverity;
using Verify = Microsoft.CodeAnalysis.CSharp.Testing.NUnit.AnalyzerVerifier<GISharp.Analyzers.RefStructNullability>;

namespace GISharp.Test.Analyzers
{
    public class Tests
    {
        static string SourceDirectory([CallerFilePath] string path = null)
        {
            return Path.GetDirectoryName(path);
        }

        static string NugetConfig =>
            Path.GetFullPath(Path.Combine(SourceDirectory(), "..", "nuget.config"));

        static readonly ReferenceAssemblies refAsm = ReferenceAssemblies.Net.Net50
            .AddPackages(ImmutableArray.Create(new PackageIdentity("GISharp.Runtime", "1.0.0")))
            .WithNuGetConfigFilePath(NugetConfig);

        [Test]
        public async Task Test0()
        {
            const string testCode =
                @"
#nullable enable
using System;
using System.Diagnostics.CodeAnalysis;

public static class Test
{
    public static void M1([DisallowNull] Span<byte> s)
    {
    }

    public static void M2()
    {
        byte[] b1 = null;
        byte[] b2 = new byte[] { 0 };

        M1(default); // warn
        M1(default(Span<byte>)); // warn
        M1(b1); // warn
        M1(b2); // ok
    }
}
";
            var expected1 = Verify.Diagnostic("GI0001").WithLocation(17, 12).WithSeverity(Warning);
            var expected2 = Verify.Diagnostic("GI0001").WithLocation(18, 12).WithSeverity(Warning);
            var expected3 = Verify.Diagnostic("GI0001").WithLocation(19, 12).WithSeverity(Warning);
            await Verify.VerifyAnalyzerAsync(testCode, expected1, expected2, expected3);
        }

        [Test]
        public async Task Test1()
        {
            const string testCode =
                @"
#nullable enable
using System.Diagnostics.CodeAnalysis;
using GISharp.Runtime;

public static class Test
{
    public static void M1([DisallowNull] UnownedUtf8 s)
    {
    }

    public static void M2()
    {
        var s1 = default(Utf8);
        var s2 = new Utf8(""test"");

        M1(default); // warn
        M1(default(UnownedUtf8)); // warn
        M1(s1); // warn
        M1(s2); // ok
    }
}
";
            var expected1 = Verify.Diagnostic("GI0001").WithLocation(17, 12).WithSeverity(Warning);
            var expected2 = Verify.Diagnostic("GI0001").WithLocation(18, 12).WithSeverity(Warning);
            var expected3 = Verify.Diagnostic("GI0001").WithLocation(19, 12).WithSeverity(Warning);
            await new CSharpAnalyzerTest<GISharp.Analyzers.RefStructNullability, NUnitVerifier>
            {
                TestCode = testCode,
                ExpectedDiagnostics = { expected1, expected2, expected3 },
                ReferenceAssemblies = refAsm
            }.RunAsync();
        }
    }
}
