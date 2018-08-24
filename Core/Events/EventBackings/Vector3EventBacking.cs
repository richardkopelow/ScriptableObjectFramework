using ScriptableObjectFramework.Events.UnityEvents;
using UnityEngine;

namespace ScriptableObjectFramework.Events
{
    [CreateAssetMenu(fileName = "NewVector3Event", menuName = "Scriptable Objects/Events/Vector3")]
    public class Vector3EventBacking : BaseEventBacking<Vector3, Vector3UnityEvent> { }
}