using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewIntEvent", menuName = "Scriptable Objects/Events/Int")]
    public class IntEventBacking : BaseEventBacking<int, IntUnityEvent> { }
}