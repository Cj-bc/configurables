using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Configurables
{
    public class ConfigSystem<Config>
    {
        private Config? _m_CurrentConfig;
        private Config? m_CurrentConfig
        {
            set
            {
                _m_CurrentConfig = value;
                HandleConfig();
            }
        }

        private List<IConfigurable<Config>> m_Targets = new();
        private IConfigProvider<Config> m_Provider;

        public async UniTask AddConfigurable(IConfigurable<Config> target)
        {
            m_Targets.Add(target);
            target.Configure(await GetCurrentConfig());
        }

        public void AddProvider(IConfigProvider<Config> provider)
        {
            m_Provider = provider;
        }

        public async UniTask Update(Func<Config, Config> updater)
        {
            m_CurrentConfig = updater(await GetCurrentConfig());
        }

        private async UniTask<Config?> GetCurrentConfigAsync()
        {
            if (_m_CurrentConfig is null)
            {
                m_CurrentConfig = await m_Provider.GetConfig();
            }

            return _m_CurrentConfig;
        }

        /// <summary>Handles new configuration</summary>
        private async UniTask HandleConfig() => HandleConfig(await GetCurrentConfig());

        private void HandleConfig(Config cfg)
        {
            foreach (var configurable in m_Targets)
            {
                configurable.Configure(cfg);
            }
        }

    }
}
