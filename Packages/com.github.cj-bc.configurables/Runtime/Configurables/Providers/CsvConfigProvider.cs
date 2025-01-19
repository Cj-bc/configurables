using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

#nullable enable

namespace Configurables
{
    [Serializable]
    public class CsvConfigProvider<Config> : IConfigProvider<Config>
        where Config : class, ICsvSerializable<Config>, new()
    {
        [SerializeField] private string m_FileName;

        private string ConfigPath => Path.Combine(Application.dataPath, m_FileName);

        public async UniTask<Config?> GetConfig()
        => new Config().Deserialize(File.ReadAllLines(ConfigPath).Select(line => line.Split())
                                    .Where(line => line.Count() >= 2)
                                    .Select(line => (line[0], line[1])));
    }
}
