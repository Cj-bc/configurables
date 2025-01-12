namespace Configurables
{
    /// <summary>A class that uses <c>Config</c> instance to configure itself.</summary>
    public interface IConfigurable<Config>
    {
        /// <summary>Configures this class/struct with given config value.</summary>
        public void Configure(Config config);
    }
}
