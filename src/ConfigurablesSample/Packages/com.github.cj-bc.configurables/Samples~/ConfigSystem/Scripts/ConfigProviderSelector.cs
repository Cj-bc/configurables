using System;
using UnityEngine;

namespace Configurables
{
    [Serializable]
    public class ConfigProviderSelector : ISerializationCallbackReceiver
    {
        private object rawObject;

        [SerializeField] private string __serializedRawObject;
        [SerializeField] private string __serializedRawObjectType;

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

        public void OnBeforeSerialize()
        {
            if (rawObject is null)
            {
                __serializedRawObjectType = "null";
                return;
            }

            __serializedRawObject = JsonUtility.ToJson(rawObject);
            __serializedRawObjectType = rawObject.GetType().AssemblyQualifiedName;
        }

        public void OnAfterDeserialize()
        {
            if (__serializedRawObjectType == "null")
            {
                rawObject = null;
                return;
            }

            rawObject = JsonUtility.FromJson(__serializedRawObject, Type.GetType(__serializedRawObjectType));
        }
    }
}
