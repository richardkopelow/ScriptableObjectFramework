using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectFramework
{
    public class BaseEventInspector<T> : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Fire"))
            {
                ((BaseEventBacking<T>)target).SelfFire();
            }
        }
    }

	[CustomEditor(typeof(IntEventBacking))]
    public class IntEventInspector : BaseEventInspector<int> { }

	[CustomEditor(typeof(FloatEventBacking))]
    public class FloatEventInspector : BaseEventInspector<float> { }

	[CustomEditor(typeof(BoolEventBacking))]
    public class BoolEventInspector : BaseEventInspector<bool> { }

	[CustomEditor(typeof(StringEventBacking))]
    public class StringEventInspector : BaseEventInspector<string> { }

	[CustomEditor(typeof(Vector3EventBacking))]
    public class Vector3EventInspector : BaseEventInspector<Vector3> { }

	[CustomEditor(typeof(GameObjectEventBacking))]
    public class GameObjectEventInspector : BaseEventInspector<GameObject> { }
}
