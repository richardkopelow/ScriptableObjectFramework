using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewBoolEvent", menuName = "Scriptable Objects/Events/Bool")]
    public class BoolEventBacking : BaseEventBacking<bool, BoolUnityEvent> { }
}