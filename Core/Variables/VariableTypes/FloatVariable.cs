using ScriptableObjectFramework.Conditions;
using UnityEngine;

namespace ScriptableObjectFramework.Variables
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Scriptable Objects/Variables/Float")]
    public class FloatVariable : ConditionableVariable<float, FloatComparableConditionCollection>
    {
        public void Add(float b)
        {
            Value += b;
        }

        public void Subtract(float b)
        {
            Value -= b;
        }

        public void Multiply(float b)
        {
            Value *= b;
        }

        public void Divide(float b)
        {
            Value /= b;
        }
    }
}