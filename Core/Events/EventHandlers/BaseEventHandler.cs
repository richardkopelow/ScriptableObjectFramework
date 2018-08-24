using ScriptableObjectFramework.Events.Handlers;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework.Events
{
    public class BaseEventHandler<T, Y, Z> : MonoBehaviour, IEventHandler<T>
        where Y : BaseEventBacking<T, Z>
        where Z : UnityEvent<T>
    {
        public Y Event;
        public Z OnTrigger;

        public void HandleEvent(T arg)
        {
            if (gameObject.activeInHierarchy)
            {
                if (Debug.isDebugBuild)
                {
                    Debug.Log($"{name} handled an event with value {arg}.");
                }
                OnTrigger.Invoke(arg);
            }
        }

        private void OnEnable()
        {
            Event?.Register(this);
        }

        private void OnDisable()
        {
            Event?.Deregister(this);
        }
    }
}
