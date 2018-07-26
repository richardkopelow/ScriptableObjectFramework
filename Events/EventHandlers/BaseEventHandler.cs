using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework
{
    public class BaseEventHandler<T, Y, Z> : MonoBehaviour, IEventHandler<T>
        where Y : BaseEventBacking<T>
        where Z : UnityEvent<T>
    {
        public Y Event;
        public Z OnTrigger;

        public void HandleEvent(T arg)
        {
            OnTrigger.Invoke(arg);
        }

        private void OnEnable()
        {
            if (Event != null)
            {
                Event.Register(this);
            }
        }

        private void OnDisable()
        {
            if (Event != null)
            {
                Event.Deregister(this);
            }
        }
    }
}
