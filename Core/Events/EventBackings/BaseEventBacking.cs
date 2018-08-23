using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework
{
    public abstract class BaseEventBacking : ScriptableObject
    {
        public abstract void SelfFire();
    }

    public class BaseEventBacking<T,Y> : BaseEventBacking, IEventBacking<T>
        where Y: UnityEvent<T>
    {
        public T Value;

        public Y OnFire;

        private List<IEventHandler<T>> handlers = new List<IEventHandler<T>>();

        public void Fire(T arg)
        {
            Value = arg;
            SelfFire();
        }

        public override void SelfFire()
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log($"Event {name} was fired with value {Value}.");
            }
            OnFire.Invoke(Value);
            for (int i = handlers.Count - 1; i >= 0; i--)
            {
                handlers[i].HandleEvent(Value);
            }
        }

        public void Register(IEventHandler<T> handler)
        {
            handlers.Add(handler);
        }

        public void Deregister(IEventHandler<T> handler)
        {
            handlers.Remove(handler);
        }
    }
}
