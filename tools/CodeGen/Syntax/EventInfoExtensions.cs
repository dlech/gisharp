using System;
using System.Reflection;
using GISharp.Runtime;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    static class EventInfoExtensions
    {
        // Gets an event declaration like:
        // public event SomethingChangedSignalHandler SomethingChangedSignal {
        //      add => somethingChangedSignalManager.Add(this, value);
        //      remove => somethingChangedSignalManager.Remove(value);
        // }
        internal static EventDeclarationSyntax GetEventDeclaration(this EventInfo info)
        {
            // TODO: would be better to use info.EventHandlerType, but this
            // needs to be implented in GirEventInfo
            var typeName = ParseTypeName($"{info.DeclaringType}.{info.Name}Handler");
            var signalManager = $"{info.Name.ToCamelCase()}SignalManager";

            var addExpression = ParseExpression($"{signalManager}.Add(this, value)");
            var addAccessor = AccessorDeclaration(AddAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(addExpression))
                .WithSemicolonToken(Token(SemicolonToken));

            var removeExpression = ParseExpression($"{signalManager}.Remove(value)");
            var removeAccessor = AccessorDeclaration(RemoveAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(removeExpression))
                .WithSemicolonToken(Token(SemicolonToken));

            return EventDeclaration(typeName, info.Name)
                .AddModifiers(Token(PublicKeyword)
                    // Can't add leading trivia to EventDeclaration, so have to
                    // attach it to public keyword.
                    // TODO: inheritdoc only makes sense when implementing an
                    // interface. If info is GirEventInfo, we should be able to
                    // get docs from the GIR XML
                    .WithLeadingTrivia(ParseLeadingTrivia("/// <inheritdoc />\n")))
                .AddAccessorListAccessors(addAccessor, removeAccessor);
        }

        // generates a field like:
        // readonly GSignalManager<SomethingChangedSignalHandler> somethingChangedSignalManager =
        //      new GSignalManager<SomethingChangedSignalHandler>("something-changed", _GType);
        internal static FieldDeclarationSyntax GetGSignalManagerFieldDeclaration(this EventInfo info)
        {
            // TODO: would be better to use info.EventHandlerType, but this
            // needs to be implented in GirEventInfo
            var typeName = ParseTypeName(info.DeclaringType.ToString());
            var managerType = typeof(GSignalManager<>).FullName;
            managerType = managerType.Substring(0, managerType.IndexOf('`'));
            managerType += $"<{typeName}.{info.Name}Handler>";
            var signalName = info.GetCustomAttribute<GSignalAttribute>().Name;
            var init = string.Format("new {0}(\"{1}\", _GType)",
                managerType,
                signalName);
            var signalManager = $"{info.Name.ToCamelCase()}SignalManager";
            var initExpression = ParseExpression(init);
            var idVariable = VariableDeclaration(ParseTypeName(managerType))
                .AddVariables(VariableDeclarator(signalManager)
                    .WithInitializer(EqualsValueClause(initExpression)));
            return FieldDeclaration(idVariable)
                .AddModifiers(Token(ReadOnlyKeyword));
        }
    }
}
