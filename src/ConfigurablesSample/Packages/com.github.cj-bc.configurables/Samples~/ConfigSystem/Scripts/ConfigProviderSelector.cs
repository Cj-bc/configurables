using System;
using UnityEngine;

namespace Configurables
{
    [Serializable]
    public class ConfigProviderSelector
    {
        [SerializeReference] private IConfigProvider rawObject;

        public IConfigProvider ConfigProvider
        {
            set {
                if (value is IConfigProvider provider)
                {
                    rawObject = value;
                    OnValueChanged?.Invoke(value);
                }
            }
            get => rawObject as IConfigProvider;
        }

        public event Action<IConfigProvider> OnValueChanged;
    }
}
