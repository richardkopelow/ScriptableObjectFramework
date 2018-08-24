using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PairedProperty : PropertyModifier
    {
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
    }
}
