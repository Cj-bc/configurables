using UnityEngine;
using Configurables;

public partial class Character : MonoBehaviour
{
    [Configurable] private int m_MaxHealth;
    [Configurable] private float m_WalkSpeed;

    void Start()
    {
        AddedLog();
    }
}
