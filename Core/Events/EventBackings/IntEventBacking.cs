using ScriptableObjectFramework.Events.UnityEvents;
using UnityEngine;

namespace ScriptableObjectFramework.Events
{
    [CreateAssetMenu(fileName = "NewIntEvent", menuName = "Scriptable Objects/Events/Int")]
    public class IntEventBacking : BaseEventBacking<int, IntUnityEvent> { }
}