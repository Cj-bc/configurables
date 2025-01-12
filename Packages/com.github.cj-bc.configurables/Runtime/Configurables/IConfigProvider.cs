using System;
using Cysharp.Threading.Tasks;

#nullable enable

namespace Configurables
{
    /// <summary>Knows how to retrive <c>Config</c></summary>
    public interface IConfigProvider<Config>
    {
        /// <summary>Get Config if possible, returns null when failed.</summary>
        public UniTask<Config?> GetConfig();
    }
}
