using ScriptableObjectFramework.Conditions;
using UnityEngine;

namespace ScriptableObjectFramework.Variables
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "Scriptable Objects/Variables/Int")]
    public class IntVariable : ConditionableVariable<int, IntComparableConditionCollection>
    {
        /// <summary>
        /// Adds to the variable.
        /// </summary>
        /// <param name="b">The value to add.</param>
        public void Add(int b)
        {
            Value += b;
        }

        /// <summary>
        /// Subtracts from the variable.
        /// </summary>
        /// <param name="b">The value to subtract.</param>
        public void Subtract(int b)
        {
            Value -= b;
        }

        /// <summary>
        /// Multiplies the variable.
        /// </summary>
        /// <param name="b">The value to multiply by.</param>
        public void Multiply(int b)
        {
            Value *= b;
        }

        /// <summary>
        /// Divides the variable.
        /// </summary>
        /// <param name="b">THe value to divide by.</param>
        public void Divide(int b)
        {
            Value /= b;
        }
    }
}