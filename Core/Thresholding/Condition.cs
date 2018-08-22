using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework
{
    public enum ConditionExecutionMode
    {
        OnThreshold,
        OnChange
        //TODO: Add continuous mode
    }

    public abstract class Condition<T> : ICondition<T>
    {
        public ConditionExecutionMode ExecutionMode;

        public abstract void Evaluate(T value);
    }
}
