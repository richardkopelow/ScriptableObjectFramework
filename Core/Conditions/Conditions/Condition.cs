using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework.Conditions
{
    /// <summary>
    /// When the condition should be evaluated.
    /// </summary>
    public enum ConditionExecutionMode
    {
        /// <summary>
        /// Only trigger the condition when the condition becomes true.
        /// </summary>
        OnThreshold,
        /// <summary>
        /// Trigger the condition any time either value on the condition changes so long as it's true.
        /// </summary>
        OnChange
        //TODO: Add continuous mode
    }
    
    public abstract class Condition
    {
        /// <summary>
        /// The execution mode.
        /// </summary>
        public ConditionExecutionMode ExecutionMode;
    }
    
    /// <summary>
    /// The base type for creating custom conditions.
    /// </summary>
    /// <typeparam name="T">The data type the condition should be executing on.</typeparam>
    public abstract class Condition<T> : Condition, ICondition<T>
    {
        /// <summary>
        /// Evaluates the condition.
        /// </summary>
        /// <param name="value">The value to compare against</param>
        public abstract void Evaluate(T value);
    }
}
