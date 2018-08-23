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
        private ReorderableList listDrawer;
        private GUIContent label;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            this.label = label;
            if (listDrawer == null || listDrawer.serializedProperty.serializedObject != property.serializedObject)
            {
                listDrawer = new ReorderableList(property.serializedObject, property.FindPropertyRelative("conditions"));
                listDrawer.drawElementCallback = DrawConditions;
                listDrawer.drawHeaderCallback = DrawHeader;
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
            var condition = listDrawer.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, condition);
        }

        protected virtual void DrawHeader(Rect headerRect)
        {
            headerRect.height = 16;
            GUI.Label(headerRect, label);
        }
    }
}
