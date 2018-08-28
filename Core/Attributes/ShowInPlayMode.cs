using System;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Attributes
{
    /// <summary>
    /// Shows property only in play mode if PlayMode is true. Only outside of play mode if PlayMode if false;
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ShowByPlayMode : PropertyModifier
    {
        public bool PlayMode = true;

#if UNITY_EDITOR
        public override void BeforeGUI(ref Rect position, SerializedProperty property, GUIContent label, ref bool visible)
        {
            visible = EditorApplication.isPlaying == PlayMode;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label, float height)
        {
            return EditorApplication.isPlaying == PlayMode ? height : 0;
        }
#endif
    }
}
