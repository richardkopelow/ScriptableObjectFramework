using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework.Sets
{
    public class RuntimeSet<T, Y> : ScriptableObject, IEnumerable<T>, IRuntimeSet<T> where Y : UnityEvent<T>
    {
        public Y OnAdd;
        public Y OnRemove;

        public T this[int index]
        {
            get
            {
                if (index >= set.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return set[index];
            }
        }
        public int Count => set.Count;

        private List<T> set = new List<T>();

        private void OnEnable()
        {
            set = new List<T>();
        }

        public void Add(T value)
        {
            if (!set.Contains(value))
            {
                set.Add(value);
                OnAdd?.Invoke(value);
            }
        }

        public void Remove(T value)
        {
            if (set.Contains(value))
            {
                set?.Remove(value);
                OnRemove.Invoke(value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    } 
}
