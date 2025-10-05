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
                rawObject = value;
                OnValueChanged?.Invoke(value);
            }
            get => rawObject;
        }

        public event Action<IConfigProvider> OnValueChanged;
    }
}
