using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Variables.Special.Editor
{
    [CustomEditor(typeof(RandomFloatVariable))]
    public class RandomFloatInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Min"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Max"));
        }
    } 
}
