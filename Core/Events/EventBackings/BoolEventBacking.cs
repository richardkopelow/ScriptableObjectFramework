using ScriptableObjectFramework.Events.UnityEvents;
using UnityEngine;

namespace ScriptableObjectFramework.Events
{
    [CreateAssetMenu(fileName = "NewBoolEvent", menuName = "Scriptable Objects/Events/Bool")]
    public class BoolEventBacking : BaseEventBacking<bool, BoolUnityEvent> { }
}