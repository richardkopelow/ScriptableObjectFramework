using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewFloatEvent", menuName = "Scriptable Objects/Events/Float")]
    public class FloatEventBacking : BaseEventBacking<float, FloatUnityEvent> { }
}