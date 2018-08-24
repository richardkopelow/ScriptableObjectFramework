// Inspired by the folks lokinwai and BinaryCats on the Unity Forums
// See thread https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ModifiableProperty : PropertyAttribute
    {
        public List<PropertyModifier> Modifiers;

        public virtual void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
        }

        public virtual float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property,label);
        }
    }
}
