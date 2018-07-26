using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework
{
    public class BaseEventBacking<T> : ScriptableObject
    {
        private List<IEventHandler<T>> handlers = new List<IEventHandler<T>>();

        public void Raise(T arg)
        {
            for (int i = handlers.Count - 1; i >= 0; i--)
            {
                handlers[i].HandleEvent(arg);
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
