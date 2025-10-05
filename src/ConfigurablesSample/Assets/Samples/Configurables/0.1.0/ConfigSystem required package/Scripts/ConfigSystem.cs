using UnityEngine;

namespace Configurables
{
    public partial class ConfigSystem : MonoBehaviour {

        [SerializeField] private ConfigProviderSelector m_ConfigSelector;

        void Start()
        {
            m_ConfigSelector.OnValueChanged += p => m_ConfigProvider = p;
            m_ConfigProvider = m_ConfigSelector.ConfigProvider;
        }
    }
}
