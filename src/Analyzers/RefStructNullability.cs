using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static Microsoft.CodeAnalysis.LanguageNames;

namespace GISharp.Analyzers
{
    [DiagnosticAnalyzer(CSharp)]
    public sealed class RefStructNullability : DiagnosticAnalyzer
    {
        static readonly DiagnosticDescriptor descriptor = new(
            "GI0001", "ref struct nullability", "message",
            "Nullability", DiagnosticSeverity.Warning, isEnabledByDefault: true
        );

        static readonly ImmutableArray<DiagnosticDescriptor> supported = ImmutableArray.Create(descriptor);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => supported;

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
            context.RegisterOperationAction(AnalyzeAssignment, OperationKind.SimpleAssignment);
        }

        private void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
        {
            var invocation = (InvocationExpressionSyntax)context.Node;

            if (context.SemanticModel.GetSymbolInfo(invocation, context.CancellationToken).Symbol is not IMethodSymbol symbol) {
                return;
            }

            var args = invocation.ArgumentList.Arguments;

            foreach (var arg in args) {
                var typeInfo = context.SemanticModel.GetTypeInfo(arg.Expression, context.CancellationToken);
                var type = typeInfo.Type;

                if (type is null) {
                    continue;
                }

                var param = arg.NameColon is null
                    ? symbol.Parameters[args.IndexOf(arg)]
                    : symbol.Parameters.Single(x => x.Name == arg.NameColon.Name.Identifier.Text);

                if (!param.Type.IsRefLikeType) {
                    continue;
                }

                if (!param.GetAttributes().Any(x => x.AttributeClass?.Name == "DisallowNullAttribute")) {
                    continue;
                }

                if (typeInfo.Nullability.FlowState == NullableFlowState.MaybeNull
                    || arg.Expression is LiteralExpressionSyntax literal && literal.IsKind(SyntaxKind.DefaultLiteralExpression)
                    || arg.Expression is DefaultExpressionSyntax
                ) {
                    context.ReportDiagnostic(Diagnostic.Create(descriptor, arg.GetLocation()));
                }
            }
        }

        private void AnalyzeAssignment(OperationAnalysisContext context)
        {
            var type = context.Operation.Type;
            if (type is null) {
                return;
            }
            if (type.IsRefLikeType) {
                if (context.Operation.Syntax is LiteralExpressionSyntax literal && literal.IsKind(SyntaxKind.DefaultLiteralExpression)) {
                    context.ReportDiagnostic(Diagnostic.Create(descriptor, context.Operation.Syntax.GetLocation()));
                }
            }
        }
    }
}
