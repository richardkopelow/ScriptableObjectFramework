using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewGameObjectEvent", menuName = "Scriptable Objects/Events/GameObject")]
    public class GameObjectEventBacking : BaseEventBacking<GameObject, GameObjectUnityEvent> { }
}