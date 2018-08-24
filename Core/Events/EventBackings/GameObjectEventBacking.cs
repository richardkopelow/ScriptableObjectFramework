using ScriptableObjectFramework.Events.UnityEvents;
using UnityEngine;

namespace ScriptableObjectFramework.Events
{
    [CreateAssetMenu(fileName = "NewGameObjectEvent", menuName = "Scriptable Objects/Events/GameObject")]
    public class GameObjectEventBacking : BaseEventBacking<GameObject, GameObjectUnityEvent> { }
}