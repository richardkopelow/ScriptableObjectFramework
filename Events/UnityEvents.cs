using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework
{
    [Serializable]
    public class IntUnityEvent : UnityEvent<int> { }
    [Serializable]
    public class FloatUnityEvent : UnityEvent<float> { }
    [Serializable]
    public class StringUnityEvent : UnityEvent<string> { }
    [Serializable]
    public class BoolUnityEvent : UnityEvent<bool> { }
    [Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3> { }
    [Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject> { }
}
