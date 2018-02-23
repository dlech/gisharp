

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GISharp.CodeGen.Syntax;
using GISharp.GObject;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Model
{
    public class SignalInfo : MethodInfo
    {
        /// <summary>
        /// Gets the emission state specified by the GIR XML
        /// </summary>
        public EmissionStage When { get; }

        /// <summary>
        /// Gets if the GIR XML has the "no-recurse" attribute set.
        /// </summary>
        public bool IsNoRecurse { get; }

        /// <summary>
        /// Gets if the GIR XML has the "detailed" attribute set.
        /// </summary>
        public bool IsDetailed { get; }

        /// <summary>
        /// Gets if the GIR XML has the "action" attribute set.
        /// </summary>
        public bool IsAction { get; }

        /// <summary>
        /// Gets if the GIR XML has the "no-hooks" attribute set.
        /// </summary>
        public bool IsNoHooks { get; }

        /// <summary>
        /// Gets the name of the event args class for this event.
        /// </summary>
        public string EventArgsClassName { get; }

        /// <summary>
        /// Gets the name of this event handler delagate type for the event.
        /// This is just the event name with 'EventHandler' suffix.
        /// </summary>
        public string EventHandlerDelegateName { get; }

        /// <summary>
        /// Gets the name of the private signal manager field
        /// </summary>
        public string SignalManagerFieldName { get; }

        /// <summary>
        /// Gets the syntax for the event args based on a signal's parameters
        /// </summary>
        public ClassDeclarationSyntax EventArgsClassDeclaration => _EventArgsClassDeclaration.Value;
        readonly Lazy<ClassDeclarationSyntax> _EventArgsClassDeclaration;

        /// <summary>
        /// Gets the syntax for a managed event based on a signal
        /// </summary>
        public EventDeclarationSyntax EventDeclaration => _EventDeclaration.Value;
        readonly Lazy<EventDeclarationSyntax> _EventDeclaration;

        /// <summary>
        /// Gets all of the declarations for a signal for implementing a managed proxy
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> ClassMemberDeclarations =>
             _ClassMemberDeclarations.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _ClassMemberDeclarations;

        /// <summary>
        /// Gets all of the declarations for a signal for implementing an interface
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> InterfaceMemberDeclarations =>
             _InterfaceMemberDeclarations.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _InterfaceMemberDeclarations;

        public SignalInfo(XElement element, MemberInfo declaringMember)
            : base(element, declaringMember)
        {
            if (element.Name != glib + "signal") {
                throw new ArgumentException("Requires <glib:signal> element", nameof(element));
            }
            var when = element.Attribute("when")?.Value;
            switch (when) {
                case "first":
                    When = EmissionStage.First;
                    break;
                case "last":
                    When = EmissionStage.Last;
                    break;
                case "cleanup":
                    When = EmissionStage.Cleanup;
                    break;
                default:
                    var message = $"Unknown 'when' attribute value '{when}'";
                    throw new ArgumentException(message, nameof(element));
            }
            IsNoRecurse = element.Attribute("no-recurse").AsBool();
            IsDetailed = element.Attribute("detailed").AsBool();
            IsAction = element.Attribute("action").AsBool();
            IsNoHooks = element.Attribute("no-hooks").AsBool();
            _EventArgsClassDeclaration = new Lazy<ClassDeclarationSyntax>(LazyGetEventArgsClassDeclaration);
            _EventDeclaration = new Lazy<EventDeclarationSyntax>(LazyGetEventDeclaration);
            EventArgsClassName = ManagedName + "EventArgs";
            EventHandlerDelegateName = ManagedName + "EventHandler";
            SignalManagerFieldName = ManagedName.ToCamelCase() + "SignalHandler";
            _ClassMemberDeclarations = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() =>
                List(LazyGetClassMemberDeclarations()));
            _InterfaceMemberDeclarations = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() =>
                List(LazyGetInterfaceMemberDeclarations()));
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists()
        {
            return base.GetAttributeLists().Concat(LazyGetEventAttributeLists());
        }

        // emits an attribute list like:
        // [GSignal("signal-name", When = EmissionState.Last)]
        IEnumerable<AttributeListSyntax> LazyGetEventAttributeLists()
        {
            var attributeType = ParseName(typeof(GSignalAttribute).FullName);

            // build the argument list
            var builder = new StringBuilder();
            builder.Append($"(\"{GirName}\"");
            builder.AppendFormat(", {0} = {1}.{2}", nameof(GSignalAttribute.When),
                typeof(EmissionStage).FullName, When);
            if (IsNoRecurse) {
                builder.AppendFormat(", {0} = true", nameof(GSignalAttribute.NoRecurse));
            }
            if (IsDetailed) {
                builder.AppendFormat(", {0} = true", nameof(GSignalAttribute.Detailed));
            }
            if (IsAction) {
                builder.AppendFormat(", {0} = true", nameof(GSignalAttribute.Action));
            }
            if (IsNoHooks) {
                builder.AppendFormat(", {0} = true", nameof(GSignalAttribute.NoHooks));
            }
            builder.Append(")");
            var argList = ParseAttributeArgumentList(builder.ToString());

            yield return AttributeList()
                .AddAttributes(Attribute(attributeType)
                    .WithArgumentList(argList));
        }

        ClassDeclarationSyntax LazyGetEventArgsClassDeclaration()
        {
            var eventArgsType = ParseTypeName(typeof(GSignalEventArgs).FullName);
            return ClassDeclaration(EventArgsClassName)
                .AddModifiers(Token(PublicKeyword), Token(SealedKeyword))
                .AddBaseListTypes(SimpleBaseType(eventArgsType))
                .WithMembers(List(LazyGetEventArgsMembers()));
        }

        // emits all of the members for an EventArgs declaration
        IEnumerable<MemberDeclarationSyntax> LazyGetEventArgsMembers()
        {
            // emit a field like: readonly Value[] args;
            var argsType = ParseTypeName($"{typeof(Value).FullName}[]");
            var argsVariable = VariableDeclarator("args");
            yield return FieldDeclaration(VariableDeclaration(argsType)
                    .AddVariables(argsVariable))
                .AddModifiers(Token(ReadOnlyKeyword));

            // each parameter becomes a readonly property
            foreach (var (parameter, i) in ManagedParameterInfos.Select((p, i) => (p, i + 1))) {
                var propertyType = parameter.TypeInfo.Type;
                var propertyName = parameter.ManagedName.ToPascalCase();

                var valueExpression = ParseExpression($"({propertyType})args[{i}].Get()");

                yield return PropertyDeclaration(propertyType, propertyName)
                    .AddModifiers(Token(PublicKeyword))
                    .WithExpressionBody(ArrowExpressionClause(valueExpression))
                    .WithSemicolonToken(Token(SemicolonToken));
            }

            // the return parameter is a read/write property (if not void)
            if (ManagedReturnParameterInfo.TypeInfo.Classification != TypeClassification.Void) {
                var propertyType = ManagedReturnParameterInfo.TypeInfo.Type;
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
                typeof(ArgumentNullException).FullName);
            var initArgsStatement = ParseStatement(initArgs);
            var body = Block(initArgsStatement);

            yield return ConstructorDeclaration(EventArgsClassName)
                .AddModifiers(Token(PublicKeyword))
                .WithParameterList(constructorParams)
                .WithBody(body);
        }

        // gets an event declaration like:
        // public event EventHandler<SomethingChangedEventArgs> SomethingChanged {
        //      add => somethingChangedSignalManager.Add(this, value);
        //      remove => somethingChangedSignalManager.Remove(value);
        // }
        EventDeclarationSyntax LazyGetEventDeclaration()
        {
            var typeName = ParseTypeName($"{typeof(EventHandler).FullName}<{EventArgsClassName}>");

            var addExpression = ParseExpression($"{SignalManagerFieldName}.Add(this, value)");
            var addAccessor = AccessorDeclaration(AddAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(addExpression))
                .WithSemicolonToken(Token(SemicolonToken));

            var removeExpression = ParseExpression($"{SignalManagerFieldName}.Remove(value)");
            var removeAccessor = AccessorDeclaration(RemoveAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(removeExpression))
                .WithSemicolonToken(Token(SemicolonToken));

            var accessorList = AccessorList().AddAccessors(addAccessor, removeAccessor);

            return EventDeclaration(typeName, ManagedName)
                .WithAttributeLists(AttributeLists)
                .WithModifiers(Modifiers)
                .WithAccessorList(accessorList);
        }

        IEnumerable<MemberDeclarationSyntax> LazyGetClassMemberDeclarations()
        {
            yield return EventArgsClassDeclaration;
            yield return LazyGetGSignalManagerFieldDeclaration();
            yield return EventDeclaration;
        }

        IEnumerable<MemberDeclarationSyntax> LazyGetInterfaceMemberDeclarations()
        {
            var iface = DeclaringMember as InterfaceInfo;
            if (iface == null) {
                throw new InvalidOperationException("event is not declared by an interface");
            }
            
            var eventArgsClassName = $"{iface.QualifiedName}.{EventArgsClassName}";
            var typeName = ParseTypeName($"{typeof(EventHandler).FullName}<{eventArgsClassName}>");

            var varDecl = VariableDeclaration(typeName)
                .AddVariables(VariableDeclarator(ManagedName));

            yield return EventFieldDeclaration(varDecl)
                .WithAttributeLists(AttributeLists);
        }

        // generates a field like:
        // readonly GSignalManager<SomethingChangedEventArgs> somethingChangedSignalManager =
        //      new GSignalManager<SomethingChangedEventArgs>("something-changed", _GType);
        FieldDeclarationSyntax LazyGetGSignalManagerFieldDeclaration()
        {
            var managerType = typeof(GSignalManager<>).FullName;
            managerType = managerType.Substring(0, managerType.IndexOf('`'));
            managerType += $"<{EventArgsClassName}>";
            var init = string.Format("new {0}(\"{1}\", _GType)",
                managerType,
                GirName);
            var initExpression = ParseExpression(init);
            var idVariable = VariableDeclaration(ParseTypeName(managerType))
                .AddVariables(VariableDeclarator(SignalManagerFieldName)
                    .WithInitializer(EqualsValueClause(initExpression)));
            return FieldDeclaration(idVariable)
                .AddModifiers(Token(ReadOnlyKeyword));
        }
    }
}
