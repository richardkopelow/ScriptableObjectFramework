using UnityEditor;
using UnityEngine;

public abstract class FlipDrawer : PropertyDrawer
{
    protected abstract string FlagField { get; }
    protected abstract string Backing1 { get; }
    protected abstract string Backing2 { get; }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        SerializedProperty useNormal = property.FindPropertyRelative(FlagField);

        var buttonStyle = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).FindStyle("Popup");
        if (EditorGUI.DropdownButton(
            new Rect(position.x, position.y, 20, position.height),
            GUIContent.none,
            FocusType.Passive,
            buttonStyle))
        {
            useNormal.boolValue = !useNormal.boolValue;
        }


        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var valueRect = new Rect(position.x + 20, position.y, position.width - 20, position.height);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative(useNormal.boolValue ? Backing2 : Backing1), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}