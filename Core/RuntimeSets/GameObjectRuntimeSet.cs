using ScriptableObjectFramework.Events.UnityEvents;
using UnityEngine;

namespace ScriptableObjectFramework.Sets
{
    [CreateAssetMenu(fileName = "NewGameObjectSet", menuName = "Scriptable Objects/Sets/Game Object")]
    public class GameObjectRuntimeSet : RuntimeSet<GameObject, GameObjectUnityEvent>
    {
    }
}
