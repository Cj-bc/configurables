using Microsoft.CodeAnalysis;

namespace Configurables;

[Generator(LanguageNames.CSharp)]
public partial class ConfigurablesGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var source = context.SyntaxProvider.ForAttributeWithMetadataName(
            // target Attribute name
            "Configurables.ConfigurableAttribtue",
            static (node, token) => true,
            static (context, token) => context);

        context.RegisterSourceOutput(source, Emit);

    }

    private static void Emit(SourceProductionContext context, GeneratorAttributeSyntaxContext source)
    {
        throw new NotImplementedException();
    }
}
