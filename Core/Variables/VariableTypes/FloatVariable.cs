using ScriptableObjectFramework.Conditions;
using UnityEngine;

namespace ScriptableObjectFramework.Variables
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Scriptable Objects/Variables/Float")]
    public class FloatVariable : ConditionableVariable<float, FloatComparableConditionCollection>
    {
        /// <summary>
        /// Adds to the variable.
        /// </summary>
        /// <param name="b">The value to add.</param>
        public void Add(float b)
        {
            Value += b;
        }

        /// <summary>
        /// Subtracts from the variable.
        /// </summary>
        /// <param name="b">The value to subtract.</param>
        public void Subtract(float b)
        {
            Value -= b;
        }

        /// <summary>
        /// Multiplies the variable.
        /// </summary>
        /// <param name="b">The value to multiply by.</param>
        public void Multiply(float b)
        {
            Value *= b;
        }

        /// <summary>
        /// Divides the variable.
        /// </summary>
        /// <param name="b">THe value to divide by.</param>
        public void Divide(float b)
        {
            Value /= b;
        }
    }
}