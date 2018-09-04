using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Variables.Special
{
    [CreateAssetMenu(fileName = "NewRandomFloat", menuName = "Scriptable Objects/Variables/Special Values/Random Float")]
    public class RandomFloatVariable : FloatVariable
    {
        public FloatValue Min;
        [Tooltip("Exclusive")]
        public FloatValue Max;

        public override float Value
        {
            get
            {
                return Random.Range(Min, Max);
            }
            set
            {
            }
        }
    } 
}
