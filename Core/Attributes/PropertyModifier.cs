// Inspired by the folks lokinwai and BinaryCats on the Unity Forums
// See thread https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Attributes
{
    /// <summary>
    /// The base class for creating custom modifiers for ModifiableProperties
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class PropertyModifier : PropertyAttribute
    {
#if UNITY_EDITOR
        /// <summary>
        /// Handles all ground work before the property is drawn.
        /// </summary>
        /// <param name="position">Rect describing the space the property should be drawn in.</param>
        /// <param name="property">The SerializedProperty to be drawn.</param>
        /// <param name="label"> The GUIContent describing the label for the property.</param>
        /// <param name="visible">Is the property visible</param>
        public virtual void BeforeGUI(ref Rect position, SerializedProperty property, GUIContent label, ref bool visible)
        {
        }

        /// <summary>
        /// Handles cleanup after the property is drawn.
        /// </summary>
        /// <param name="position">Rect describing the space the property should be drawn in.</param>
        /// <param name="property">The SerializedProperty to be drawn.</param>
        /// <param name="label"> The GUIContent describing the label for the property.</param>
        /// <param name="visible">Is the property visible</param>
        public virtual void AfterGUI(ref Rect position, SerializedProperty property, GUIContent label, ref bool visible)
        {
        }

        /// <summary>
        /// Handles what should happen when the property is changed.
        /// </summary>
        /// <param name="property">The SerializedProperty to be drawn.</param>
        /// <param name="fieldInfo"></param>
        public virtual void OnValueChanged(SerializedProperty property, FieldInfo fieldInfo)
        {
        }

        /// <summary>
        /// Calculates the height of the property given the modifier.
        /// </summary>
        /// <param name="position">Rect describing the space the property should be drawn in.</param>
        /// <param name="property">The SerializedProperty to be drawn.</param>
        /// <param name="label"> The GUIContent describing the label for the property.</param>
        /// <returns>Returns the height of the property.</returns>
        public virtual float GetPropertyHeight(SerializedProperty property, GUIContent label, float height)
        {
            return height;
        }
#endif
    }
}
