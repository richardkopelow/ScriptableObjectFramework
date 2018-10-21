using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework.Editor
{
    [CustomPropertyDrawer(typeof(IntEvent))]
    [CustomPropertyDrawer(typeof(FloatEvent))]
    [CustomPropertyDrawer(typeof(BoolEvent))]
    [CustomPropertyDrawer(typeof(StringEvent))]
    [CustomPropertyDrawer(typeof(Vector3Event))]
    [CustomPropertyDrawer(typeof(GameObjectEvent))]
    public class EventDrawer : FlipDrawer
    {
        protected override string FlagField => "UseHandler";
        protected override string Backing1 => "SOBacking";
        protected override string Backing2 => "Emitter";
    }
}
