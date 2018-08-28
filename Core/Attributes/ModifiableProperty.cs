// Inspired by the folks lokinwai and BinaryCats on the Unity Forums
// See thread https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Attributes
{
    /// <summary>
    /// The base attribute type for creating property drawers that can take on PropertyModifier attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ModifiableProperty : PropertyAttribute
    {
#if UNITY_EDITOR
        /// <summary>
        /// Modifiers for the property drawer
        /// </summary>
        public List<PropertyModifier> Modifiers;

        /// <summary>
        /// Handles drawing the property.
        /// </summary>
        /// <param name="position">Rect describing the space the property should be drawn in.</param>
        /// <param name="property">The SerializedProperty to be drawn.</param>
        /// <param name="label"> The GUIContent describing the label for the property.</param>
        public virtual void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
        }

        /// <summary>
        /// Calculates the draw height of the property.
        /// </summary>
        /// <param name="property">The SerializedProperty to be drawn.</param>
        /// <param name="label"> The GUIContent describing the label for the property.</param>
        /// <returns>The height of the property.</returns>
        public virtual float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property,label);
        }
#endif
    }
}
