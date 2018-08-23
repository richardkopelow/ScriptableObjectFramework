using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "Scriptable Objects/Variables/Int")]
    public class IntVariable : ConditionableVariable<int, IntComparableConditionCollection>
    {
        public void Add(int b)
        {
            Value += b;
        }

        public void Subtract(int b)
        {
            Value -= b;
        }

        public void Multiply(int b)
        {
            Value *= b;
        }

        public void Divide(int b)
        {
            Value /= b;
        }
    }
}