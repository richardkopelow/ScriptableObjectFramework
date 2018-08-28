using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Attributes
{
    /// <summary>
    /// Connects a field to a property so that when it is changed in editor, the property will be triggered as well.
    /// </summary>
    /// <remarks>
    /// This works by, on change, assigning the field to the property. Therefor checks to prevent the property from doing anything if the value is the same as the one already stored may interfere.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field)]
    public class PairedProperty : PropertyModifier
    {
#if UNITY_EDITOR
        public string PropertyName;
        public bool PlaymodeOnly;

        public PairedProperty(string propertyName, bool playmodeOnly = true)
        {
            PropertyName = propertyName;
            PlaymodeOnly = playmodeOnly;
        }

        public override void OnValueChanged(SerializedProperty property, FieldInfo fieldInfo)
        {
            property.serializedObject.ApplyModifiedProperties();
            if (EditorApplication.isPlaying || !PlaymodeOnly)
            {
                object target = property.serializedObject.targetObject;
                var targetType = target.GetType();
                var targetProperty = targetType.GetProperty(PropertyName);
                if (targetProperty != null)
                {
                    if (targetProperty.CanWrite)
                    {
                        object val = fieldInfo.GetValue(target);
                        targetProperty.SetValue(target, val);
                    }
                    else
                    {
                        Debug.LogError($"{target.GetType()}.{PropertyName} does not have a setter.");
                    }
                }
                else
                {
                    Debug.LogError($"{target.GetType()} does not have a property named {PropertyName}.");
                }
            }
        }
#endif
    }
}
