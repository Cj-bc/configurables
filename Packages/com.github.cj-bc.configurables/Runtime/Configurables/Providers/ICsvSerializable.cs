using System.Collections.Generic;

#nullable enable

namespace Configurables
{
    /// <summary>Provides functionality to serialize/deserialize to/from csv file</summary>
    public interface ICsvSerializable<Self>
    {
        public Self? Deserialize(IEnumerable<(string Key, string Value)> pairs);
        public string[] Serialize();
    }
}
