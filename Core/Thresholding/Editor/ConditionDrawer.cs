using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework
{
    [CustomPropertyDrawer(typeof(IntComparableCondition), true)]
    public class ConditionDrawer : PropertyDrawer
    {
        const float buffer = 5;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            float sectionSize = (position.width) / 3 - buffer;
            Rect conditionPosition = new Rect(position.x, position.y, sectionSize, position.height);
            Rect argumentPosition = new Rect(position.x+buffer+sectionSize, position.y, sectionSize, position.height);
            Rect eventPosition = new Rect(position.x+(buffer+sectionSize)*2, position.y, sectionSize, position.height);
            EditorGUI.PropertyField(conditionPosition, property.FindPropertyRelative("Condition"), GUIContent.none);
            EditorGUI.PropertyField(argumentPosition, property.FindPropertyRelative("Argument"), GUIContent.none);
            EditorGUI.PropertyField(eventPosition, property.FindPropertyRelative("Event"), GUIContent.none);
            EditorGUI.EndProperty();
        }
    }
}
