using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Variables.Special
{
    [CreateAssetMenu(fileName = "NewRandomInt", menuName = "Scriptable Objects/Variables/Special Values/Random Int")]
    public class RandomIntVariable : IntVariable
    {
        public IntValue Min;
        [Tooltip("Exclusive")]
        public IntValue Max;

        public override int Value
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
