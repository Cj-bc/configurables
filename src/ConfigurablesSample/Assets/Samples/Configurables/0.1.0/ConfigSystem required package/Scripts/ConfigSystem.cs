using UnityEngine;

namespace Configurables
{
    public partial class ConfigSystem : MonoBehaviour {

        [SerializeField] private ConfigProviderSelector m_ConfigSelector;

        void Start()
        {
            m_ConfigProvider = new JsonConfigProvider();
        }
    }
}
