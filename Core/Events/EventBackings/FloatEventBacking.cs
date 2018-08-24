using ScriptableObjectFramework.Events.UnityEvents;
using UnityEngine;

namespace ScriptableObjectFramework.Events
{
    [CreateAssetMenu(fileName = "NewFloatEvent", menuName = "Scriptable Objects/Events/Float")]
    public class FloatEventBacking : BaseEventBacking<float, FloatUnityEvent> { }
}