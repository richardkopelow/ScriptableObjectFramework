// Inspired by the folks lokinwai and BinaryCats on the Unity Forums
// See thread https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class PropertyModifier : PropertyAttribute
    {
        public virtual void BeforeGUI(ref Rect position, SerializedProperty property, GUIContent label, ref bool visible)
        {
        }

        public virtual void AfterGUI(ref Rect position, SerializedProperty property, GUIContent label, ref bool visible)
        {
        }

        public virtual void OnValueChanged(SerializedProperty property, FieldInfo fieldInfo)
        {
        }

        public virtual float GetPropertyHeight(SerializedProperty property, GUIContent label, float height)
        {
            return height;
        }
    }
}
