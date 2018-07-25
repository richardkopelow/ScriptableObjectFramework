using UnityEditor;
using UnityEngine;

public abstract class BaseValueDrawer<T, Y, Z> : PropertyDrawer
    where Y : BaseVariable<T>
    where Z : BaseValue<T, Y>
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        SerializedProperty useNormal = property.FindPropertyRelative("UseNormal");

        var buttonStyle = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).FindStyle("SimplePopup");
        if (EditorGUI.DropdownButton(
            new Rect(position.x, position.y, 10, position.height),
            GUIContent.none,
            FocusType.Passive,
            buttonStyle))
        {
            
            useNormal.boolValue = !useNormal.boolValue;
        }


        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        
        var valueRect = new Rect(position.x + 10, position.y, position.width - 10, position.height);
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative(useNormal.boolValue?"NormalValue":"SOValue"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(IntValue))]
public class IntValueDrawer : BaseValueDrawer<int, IntVariable, IntValue> { }
[CustomPropertyDrawer(typeof(FloatValue))]
public class FloatValueDrawer : BaseValueDrawer<float, FloatVariable, FloatValue> { }
[CustomPropertyDrawer(typeof(BoolValue))]
public class BoolValueDrawer : BaseValueDrawer<bool, BoolVariable, BoolValue> { }
[CustomPropertyDrawer(typeof(StringValue))]
public class StringValueDrawer : BaseValueDrawer<string, StringVariable, StringValue> { }
[CustomPropertyDrawer(typeof(Vector3Value))]
public class Vector3ValueDrawer : BaseValueDrawer<Vector3, Vector3Variable, Vector3Value> { }
[CustomPropertyDrawer(typeof(GameObjectValue))]
public class GameObjectValueDrawer : BaseValueDrawer<GameObject, GameObjectVariable, GameObjectValue> { }