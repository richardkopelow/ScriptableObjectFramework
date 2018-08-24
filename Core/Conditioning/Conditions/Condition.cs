using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework.Conditions
{
    public enum ConditionExecutionMode
    {
        OnThreshold,
        OnChange
        //TODO: Add continuous mode
    }
    
    public abstract class Condition
    {
        public ConditionExecutionMode ExecutionMode;
    }
    
    public abstract class Condition<T> : Condition, ICondition<T>
    {
        public abstract void Evaluate(T value);
    }
}
