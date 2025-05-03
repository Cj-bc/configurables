using System.IO;
using UnityEngine;
using Configurables;

public class JsonConfigProvider : IConfigProvider
{
    [SerializeField] private string m_Path;

    public ConfigSystem.Config GetConfig()
    {
        string raw = File.ReadAllText(m_Path);
        if (JsonUtility.FromJson<ConfigSystem.Config?>(raw) is ConfigSystem.Config parsed)
        {
            return parsed;
        }
        throw new System.Exception();
    }
}
