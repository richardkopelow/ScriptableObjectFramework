using ScriptableObjectFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework
{
    [Serializable]
    public class BaseEvent<T, Y, Z> : IEvent<T>
        where Y : BaseEventBacking<T>
        where Z : IEventHandler<T>
    {
        public bool UseHandler;
        public Y SOBacking;
        public Z Handler;

        public void Fire(T arg)
        {
            if (UseHandler)
            {
                Handler?.HandleEvent(arg);
            }
            else
            {
                SOBacking?.Fire(arg);
            }
        }
    }
}

[Serializable]
public class IntEvent : BaseEvent<int, IntEventBacking, IntEventHandler> { }
[Serializable]
public class FloatEvent : BaseEvent<float, FloatEventBacking, FloatEventHandler> { }
[Serializable]
public class BoolEvent : BaseEvent<bool, BoolEventBacking, BoolEventHandler> { }
[Serializable]
public class StringEvent : BaseEvent<string, StringEventBacking, StringEventHandler> { }
[Serializable]
public class Vector3Event : BaseEvent<Vector3, Vector3EventBacking, Vector3EventHandler> { }
[Serializable]
public class GameObjectEvent : BaseEvent<GameObject, GameObjectEventBacking, GameObjectEventHandler> { }
