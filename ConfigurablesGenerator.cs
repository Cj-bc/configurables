using Microsoft.CodeAnalysis;

namespace Configurables;

[Generator(LanguageNames.CSharp)]
public partial class ConfigurablesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
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
                return contexts.Distinct();
            });

        context.RegisterSourceOutput(source, Emit);

    }

    private static void Emit(SourceProductionContext context, INamedTypeSymbol symbol)
    {
        throw new NotImplementedException();
    }
}
