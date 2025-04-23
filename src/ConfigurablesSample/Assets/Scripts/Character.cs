using UnityEngine;
using Configurables;

public partial class Character : MonoBehaviour
{
    [Configurable] public int m_MaxHealth;
    [Configurable] public float m_WalkSpeed;

    void Start()
    {
        Configure(new(10, 1.0f));
    }
}
