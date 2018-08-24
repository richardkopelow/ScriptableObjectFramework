using ScriptableObjectFramework.Attributes;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Editor
{
    [CustomPropertyDrawer(typeof(ModifiableProperty))]
    public class ModifiablePropertyDrawer : PropertyDrawer
    {
        public new ModifiableProperty attribute
        {
            get
            {
                var modifiable = (ModifiableProperty)base.attribute;
                if (modifiable.Modifiers == null)
                {
                    modifiable.Modifiers = fieldInfo.GetCustomAttributes(typeof(PropertyModifier), false)
                    .Cast<PropertyModifier>().OrderBy(s => s.order).ToList();
                }
                return modifiable;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ModifiableProperty att = attribute;

            bool visible = true;
            foreach (PropertyModifier mod in att.Modifiers)
            {
                mod.BeforeGUI(ref position, property, label, ref visible);
            }
            if (visible)
            {
                EditorGUI.BeginChangeCheck();
                att.OnGUI(position, property, label);
                if (EditorGUI.EndChangeCheck())
                {
                    property.serializedObject.ApplyModifiedProperties();
                    foreach (PropertyModifier mod in att.Modifiers)
                    {
                        mod.OnValueChanged(property, fieldInfo);
                    }
                }
            }
            foreach (PropertyModifier mod in att.Modifiers)
            {
                mod.AfterGUI(ref position, property, label, ref visible);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = attribute.GetPropertyHeight(property, label);
            foreach (PropertyModifier mod in attribute.Modifiers)
            {
                height = mod.GetPropertyHeight(property, label, height);
            }

            return height;
        }
    }
}
