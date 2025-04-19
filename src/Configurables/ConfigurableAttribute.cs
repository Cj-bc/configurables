namespace Configurables;

using System;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public sealed class ConfigurableAttribute : Attribute
{
    public ConfigurableAttribute() {}
}
