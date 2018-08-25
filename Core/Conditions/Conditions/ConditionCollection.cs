using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Conditions
{
    //TODO: make this abstract
    [Serializable]
    public class ConditionCollection { }

    /// <summary>
    /// The base type for creating condition collections.
    /// </summary>
    /// <remarks>
    /// Using ConditionCollections ensures the collection of conditions will be drawn correctly. It also lets one easily inherit from ConditionableVariable.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Y"></typeparam>
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
