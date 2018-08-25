using ScriptableObjectFramework.Events.Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework.Events
{
    public abstract class BaseEventBacking : ScriptableObject
    {
        /// <summary>
        /// Fires the event internally based on the stored event parameter.
        /// </summary>
        public abstract void SelfFire();
    }

    /// <summary>
    /// The base type for creating Event Backings
    /// </summary>
    /// <typeparam name="T">The data type to be passed through the event.</typeparam>
    /// <typeparam name="Y">The Unity event to tie code to the event.</typeparam>
    public class BaseEventBacking<T,Y> : BaseEventBacking, IEventBacking<T>
        where Y: UnityEvent<T>
    {
        public T Value;

        public Y OnFire;

        private List<IEventHandler<T>> handlers = new List<IEventHandler<T>>();

        //Triggers the event.
        public void Fire(T arg)
        {
            Value = arg;
            SelfFire();
        }

        /// <summary>
        /// Fires the event internally based on the stored event parameter.
        /// </summary>
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

        /// <summary>
        /// Registers an IEventHangler of appropriate type to the event.
        /// </summary>
        /// <param name="handler">The handler to register.</param>
        public void Register(IEventHandler<T> handler)
        {
            handlers.Add(handler);
        }

        /// <summary>
        /// Registers an IEventHangler of appropriate type to the event.
        /// </summary>
        /// <param name="handler">The handler to register.</param>
        public void Deregister(IEventHandler<T> handler)
        {
            handlers.Remove(handler);
        }
    }
}
