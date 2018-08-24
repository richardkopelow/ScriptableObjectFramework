using ScriptableObjectFramework.Events.UnityEvents;
using UnityEngine;

namespace ScriptableObjectFramework.Events
{
    [CreateAssetMenu(fileName = "NewStringEvent", menuName = "Scriptable Objects/Events/String")]
    public class StringEventBacking : BaseEventBacking<string, StringUnityEvent> { }
}