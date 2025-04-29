using System;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

/// https://docs.unity3d.com/ja/2022.3/ScriptReference/TypeCache.GetTypesDerivedFrom.html
/// https://light11.hatenadiary.com/entry/2021/04/26/202054

[Serializable]
internal class ConfigProviderSelector
{}

[CustomPropertyDrawer(typeof(ConfigProviderSelector))]
internal class ConfigProviderSelectorEditor : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();
        return container;

    }
}
