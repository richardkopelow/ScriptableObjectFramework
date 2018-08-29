using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Sets
{
    public abstract class SetRegisterer<T, Y> : MonoBehaviour
        where Y : IRuntimeSet<T>
    {
        [Serializable]
        protected List<Y> Sets;

        protected abstract void OnEnable();

        protected abstract void OnDisable();
    }
}
