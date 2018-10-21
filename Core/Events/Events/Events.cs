using ScriptableObjectFramework;
using ScriptableObjectFramework.Events;
using ScriptableObjectFramework.Events.Handlers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Events
{
    [Serializable]
    public class BaseEvent<T, Y, Z> : IEvent<T>, IEventBacking<T>
        where Y : IEventBacking<T>
        where Z : IEventBacking<T>
    {
        public bool UseHandler;
        public Y SOBacking;
        public Z Emitter;

        private IEventBacking<T> activeBacking => UseHandler ? (IEventBacking<T>)Emitter : (IEventBacking<T>)SOBacking;

        public void Deregister(IEventHandler<T> handler)
        {
            activeBacking.Deregister(handler);
        }

        public void Fire(T arg)
        {
            activeBacking.Fire(arg);
        }

        public void Register(IEventHandler<T> handler)
        {
            activeBacking.Register(handler);
        }

        public void SelfFire()
        {
            activeBacking.SelfFire();
        }
    }
}

[Serializable]
public class IntEvent : BaseEvent<int, IntEventBacking, IntEventEmitter> { }
[Serializable]
public class FloatEvent : BaseEvent<float, FloatEventBacking, FloatEventEmitter> { }
[Serializable]
public class BoolEvent : BaseEvent<bool, BoolEventBacking, BoolEventEmitter> { }
[Serializable]
public class StringEvent : BaseEvent<string, StringEventBacking, StringEventEmitter> { }
[Serializable]
public class Vector3Event : BaseEvent<Vector3, Vector3EventBacking, Vector3EventEmitter> { }
[Serializable]
public class GameObjectEvent : BaseEvent<GameObject, GameObjectEventBacking, GameObjectEventEmitter> { }
