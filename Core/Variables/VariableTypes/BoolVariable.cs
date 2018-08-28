using ScriptableObjectFramework.Conditions;
using UnityEngine;

namespace ScriptableObjectFramework.Variables
{
    [CreateAssetMenu(fileName = "NewBoolVariable", menuName = "Scriptable Objects/Variables/Bool")]
    public class BoolVariable : ConditionableVariable<bool, BoolEqualityConditionCollection>
    {
        public void Toggle()
        {
            Value = !Value;
        }
    }
}