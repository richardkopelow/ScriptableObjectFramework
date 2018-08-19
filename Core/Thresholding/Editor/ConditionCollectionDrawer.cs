using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ScriptableObjectFramework
{
    [CustomPropertyDrawer(typeof(ConditionCollection), true)]
    public class ConditionCollectionDrawer : PropertyDrawer
    {
        ReorderableList listDrawer;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (listDrawer == null || listDrawer.serializedProperty.serializedObject != property.serializedObject)
            {
                listDrawer = new ReorderableList(property.serializedObject, property.FindPropertyRelative("conditions"));
                //listDrawer.drawElementCallback = DrawConditions;
                listDrawer.elementHeight = EditorGUIUtility.singleLineHeight;
            }
            listDrawer.DoList(position);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return listDrawer == null ? 0 : listDrawer.GetHeight();
        }

        void DrawConditions(Rect rect, int index, bool isactive, bool isfocused)
        {

        }
    }
}
