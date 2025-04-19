using Microsoft.CodeAnalysis;

namespace Configurables;

[Generator(LanguageNames.CSharp)]
public partial class ConfigurablesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static context =>
        {
            context.AddSource("ConfigurableAttribute.cs", """
using System;

namespace Configurables
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ConfigurableAttribute : Attribute
    {
        public ConfigurableAttribute() {}
    }
}


""");
        });

        var source = context.SyntaxProvider.ForAttributeWithMetadataName(
            // target Attribute name
            "Configurables.ConfigurableAttribute",
            static (node, token) => true,
            static (context, token) => context)
            .Select(static (context, token) => {
                token.ThrowIfCancellationRequested();
                return context.TargetSymbol.ContainingType;
            })
            .Collect()
            .SelectMany(static (contexts, token) => {
                token.ThrowIfCancellationRequested();
                return contexts.Distinct(SymbolEqualityComparer.Default).Cast<INamedTypeSymbol>();
            });

        context.RegisterSourceOutput(source, Emit);

    }

    private static void Emit(SourceProductionContext context, INamedTypeSymbol symbol)
    {
        throw new NotImplementedException();
    }
}
