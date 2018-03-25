using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using Signal = GISharp.CodeGen.Gir.Signal;

namespace GISharp.CodeGen.Syntax
{
    public static class SignalExtensions
    {
        /// <summary>
        /// Gets the C# class members for implementing a GIR signal
        /// </summary>
        public static IEnumerable<MemberDeclarationSyntax> GetClassMembers(this Signal signal)
        {
            yield return signal.GetEventArgsClassDeclaration();
            yield return signal.GetGSignalManagerFieldDeclaration();
            yield return signal.GetEventDeclaration();
        }

        /// <summary>
        /// Gets the C# interface method declaration for a GIR signal
        /// </summary>
        public static EventFieldDeclarationSyntax GetInterfaceDeclaration(this Signal signal)
        {
            var declaringType = (GIRegisteredType)signal.ParentNode;
            var typeName = declaringType.ManagedName;
            if (declaringType is Interface) {
                // trim "I" prefix so that we end up with the extension class name
                typeName = typeName.Substring(1);
            }
            var eventArgsType = $"{typeName}.{signal.ManagedName}EventArgs";
            var type = $"System.EventHandler<{eventArgsType}>";
            var variable = VariableDeclaration(ParseTypeName(type))
                .AddVariables(VariableDeclarator(signal.ManagedName));
            return EventFieldDeclaration(variable)
                .WithAttributeLists(signal.GetCommonAttributeLists())
                .AddAttributeLists(signal.GetGSignalAttributeList())
                .WithSemicolonToken(Token(SemicolonToken))
                .WithLeadingTrivia(signal.Doc.GetDocCommentTrivia());
        }

        static AttributeListSyntax GetGSignalAttributeList(this Signal signal)
        {
            // create the attribute
            var attrName = ParseName(typeof(GSignalAttribute).FullName);
            var nameArg = ParseExpression($"\"{signal.GirName}\"");
            var attr = Attribute(attrName)
                .AddArgumentListArguments(AttributeArgument(nameArg));

            var whenExpression = $"{nameof(GSignalAttribute.When)} = {typeof(EmissionStage)}.{signal.When}";
            attr = attr.AddArgumentListArguments(AttributeArgument(ParseExpression(whenExpression)));


            // add optional arguments

            if (signal.IsNoRecurse) {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsNoRecurse)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            if (signal.IsDetailed) {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsDetailed)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            if (signal.IsAction) {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsAction)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            if (signal.IsNoHooks) {
                var expression = ParseExpression($"{nameof(GSignalAttribute.IsNoHooks)} = true");
                attr = attr.AddArgumentListArguments(AttributeArgument(expression));
            }

            return AttributeList().AddAttributes(attr);
        }

        public static ClassDeclarationSyntax GetEventArgsClassDeclaration(this Signal signal)
        {
            var name = $"{signal.ManagedName}EventArgs";
            var eventArgsType = ParseTypeName(typeof(GSignalEventArgs).FullName);
            return ClassDeclaration(name)
                .AddModifiers(Token(PublicKeyword), Token(SealedKeyword))
                .AddBaseListTypes(SimpleBaseType(eventArgsType))
                .WithMembers(List(signal.GetEventArgsMembers()));
        }

        // emits all of the members for an EventArgs declaration
        static IEnumerable<MemberDeclarationSyntax> GetEventArgsMembers(this Signal signal)
        {
            // emit a field like: readonly Value[] args;
            var argsType = ParseTypeName($"{typeof(Value)}[]");
            var argsVariable = VariableDeclarator("args");
            yield return FieldDeclaration(VariableDeclaration(argsType)
                    .AddVariables(argsVariable))
                .AddModifiers(Token(ReadOnlyKeyword));

            // each parameter becomes a readonly property
            foreach (var (arg, i) in signal.ManagedParameters.Select((p, i) => (p, i + 1))) {
                var propertyType = arg.Type.ManagedType.ToSyntax();
                var propertyName = arg.ManagedName.ToPascalCase();

                var valueExpression = ParseExpression($"({propertyType})args[{i}].Get()");

                yield return PropertyDeclaration(propertyType, propertyName)
                    .AddModifiers(Token(PublicKeyword))
                    .WithExpressionBody(ArrowExpressionClause(valueExpression))
                    .WithSemicolonToken(Token(SemicolonToken));
            }

            // the return parameter is a read/write property (if not void)
            if (signal.ReturnValue.Type.ManagedType != typeof(void)) {
                var propertyType = signal.ReturnValue.Type.ManagedType.ToSyntax();
                var propertyName = "ReturnValue";
                yield return PropertyDeclaration(propertyType, propertyName)
                    .AddModifiers(Token(PublicKeyword))
                    .AddAccessorListAccessors(AccessorDeclaration(GetAccessorDeclaration)
                            .WithSemicolonToken(Token(SemicolonToken)),
                        AccessorDeclaration(SetAccessorDeclaration)
                            .WithSemicolonToken(Token(SemicolonToken)));
            }

            // generate a constructor

            var constructorParams = ParseParameterList($"({argsType} args)");
            var initArgs = string.Format("this.args = args ?? throw new {0}(nameof(args));",
                typeof(ArgumentNullException));
            var initArgsStatement = ParseStatement(initArgs);
            var body = Block(initArgsStatement);

            yield return ConstructorDeclaration($"{signal.ManagedName}EventArgs")
                .AddModifiers(Token(PublicKeyword))
                .WithParameterList(constructorParams)
                .WithBody(body);
        }

        // Gets an event declaration like:
        // public event EventHandler<SomethingChangedEventArgs> SomethingChanged {
        //      add => somethingChangedSignalManager.Add(this, value);
        //      remove => somethingChangedSignalManager.Remove(value);
        // }
        static EventDeclarationSyntax GetEventDeclaration(this Signal signal)
        {
            var typeName = ParseTypeName($"{typeof(EventHandler)}<{signal.ManagedName}EventArgs>");
            var signalManager = $"{signal.ManagedName.ToCamelCase()}SignalManager";

            var addExpression = ParseExpression($"{signalManager}.Add(this, value)");
            var addAccessor = AccessorDeclaration(AddAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(addExpression))
                .WithSemicolonToken(Token(SemicolonToken));

            var removeExpression = ParseExpression($"{signalManager}.Remove(value)");
            var removeAccessor = AccessorDeclaration(RemoveAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(removeExpression))
                .WithSemicolonToken(Token(SemicolonToken));

            var accessorList = AccessorList().AddAccessors(addAccessor, removeAccessor);

            return EventDeclaration(typeName, signal.ManagedName)
                .WithAttributeLists(signal.GetCommonAttributeLists())
                .AddAttributeLists(signal.GetGSignalAttributeList())
                .AddModifiers(signal.GetAccessModifiers().ToArray())
                .WithAccessorList(accessorList)
                .WithLeadingTrivia(signal.Doc.GetDocCommentTrivia());
        }

        // generates a field like:
        // readonly GSignalManager<SomethingChangedEventArgs> somethingChangedSignalManager =
        //      new GSignalManager<SomethingChangedEventArgs>("something-changed", _GType);
        static FieldDeclarationSyntax GetGSignalManagerFieldDeclaration(this Signal signal)
        {
            var managerType = typeof(GSignalManager<>).FullName;
            managerType = managerType.Substring(0, managerType.IndexOf('`'));
            managerType += $"<{signal.ManagedName}EventArgs>";
            var init = string.Format("new {0}(\"{1}\", _GType)",
                managerType,
                signal.GirName);
            var signalManager = $"{signal.ManagedName.ToCamelCase()}SignalManager";
            var initExpression = ParseExpression(init);
            var idVariable = VariableDeclaration(ParseTypeName(managerType))
                .AddVariables(VariableDeclarator(signalManager)
                    .WithInitializer(EqualsValueClause(initExpression)));
            return FieldDeclaration(idVariable)
                .AddModifiers(Token(ReadOnlyKeyword));
        }
    }
}
