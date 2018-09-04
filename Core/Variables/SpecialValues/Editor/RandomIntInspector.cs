using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Variables.Special.Editor
{
    [CustomEditor(typeof(RandomIntVariable))]
    public class RandomIntInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Min"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Max"));
        }
    }
}
