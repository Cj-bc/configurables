using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Configurables
{
    /// https://docs.unity3d.com/ja/2022.3/ScriptReference/TypeCache.GetTypesDerivedFrom.html
    /// https://light11.hatenadiary.com/entry/2021/04/26/202054

[CustomPropertyDrawer(typeof(ConfigProviderSelector))]
internal class ConfigProviderSelectorEditor : PropertyDrawer
{
    private static Dictionary<string, Type> providersCache = AppDomain.CurrentDomain
        .GetAssemblies().SelectMany(asm => asm.GetTypes())
        .Where(t => t.IsClass && t.GetInterfaces().Select(i => i.Name).Contains(typeof(IConfigProvider).Name))
        .ToDictionary(t => t.ToString());

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var rawObject = property.FindPropertyRelative("rawObject");
        var container = new VisualElement();

        var selector = new DropdownField("IConfigProvider", providersCache.Keys.Prepend("None").ToList(),
                                         rawObject.boxedValue is null ? "None" : rawObject.boxedValue.GetType().Name, a => a, a => a);
        selector.RegisterValueChangedCallback(ev =>
        {
            rawObject.boxedValue = providersCache.TryGetValue(ev.newValue, out Type t) ? Activator.CreateInstance(t) : null;
            property.serializedObject.ApplyModifiedProperties();
        });

        container.Add(selector);
        return container;
    }
}

}
