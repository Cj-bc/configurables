using UnityEngine;

public partial class ConfigSystem : MonoBehaviour {

    void Start()
    {
        m_ConfigProvider = new JsonConfigProvider();
    }
}
