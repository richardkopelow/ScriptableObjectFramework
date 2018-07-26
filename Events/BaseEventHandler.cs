using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework
{
    public class BaseEventHandler<T, Y, Z> : MonoBehaviour, IEventHandler<T>
        where Y:BaseEventBacking<Y>
        where Z:UnityEvent<T>
    {
        public Y Event;
        public Z OnTrigger;

        public void HandleEvent(T arg)
        {
            OnTrigger.Invoke(arg);
        }
    }
}
