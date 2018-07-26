using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework
{
    public class IntUnityEvent : UnityEvent<int> { }
    public class FloatUnityEvent : UnityEvent<float> { }
    public class StringUnityEvent : UnityEvent<string> { }
    public class BoolUnityEvent : UnityEvent<bool> { }
    public class Vector3UnityEvent : UnityEvent<Vector3> { }
    public class GameObjectUnityEvent : UnityEvent<GameObject> { }
}
