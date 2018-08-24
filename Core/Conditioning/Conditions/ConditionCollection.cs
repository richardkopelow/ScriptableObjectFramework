using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Conditions
{
    //TODO: make this abstract
    [Serializable]
    public class ConditionCollection { }

    public class ConditionCollection<T, Y> : ConditionCollection, IConditionCollection<T>
        where Y : ICondition<T>
    {
        [SerializeField]
        private List<Y> conditions = new List<Y>();

        public IEnumerator<ICondition<T>> GetEnumerator()
        {
            //For some reason, the compiler was having trouble with the type of Y so I can't just return conditions' Enumerator
            foreach (var condition in conditions)
            {
                yield return condition;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
