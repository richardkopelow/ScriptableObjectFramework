using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Editor
{
    [CustomPropertyDrawer(typeof(IntValue))]
    [CustomPropertyDrawer(typeof(FloatValue))]
    [CustomPropertyDrawer(typeof(BoolValue))]
    [CustomPropertyDrawer(typeof(StringValue))]
    [CustomPropertyDrawer(typeof(Vector3Value))]
    [CustomPropertyDrawer(typeof(GameObjectValue))]
    public class ValueDrawer : FlipDrawer
    {
        protected override string FlagField => "UseNormal";
        protected override string Backing1 => "SOValue";
        protected override string Backing2 => "NormalValue";
    }
}