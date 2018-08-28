using ScriptableObjectFramework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework.Conditions
{
    public enum EqualityComparison
    {
        EqualTo,
        NotEqualTo
    }

    public class EqualityCondition<T, Y, Z> : Condition<T>
        where Y : IValue<T>
        where Z : IEvent<T>
    {
        public EqualityComparison Condition;
        public Y Argument;
        public Z Event;

        private EqualityComparison lastState;

        public override void Evaluate(T value)
        {
            EqualityComparison currentState = value.Equals(Argument.Value)
                ? EqualityComparison.EqualTo
                : EqualityComparison.NotEqualTo;
            if (currentState == Condition
                && (currentState != lastState || ExecutionMode != ConditionExecutionMode.OnThreshold))
            {
                Event.Fire(value);
            }


            lastState = currentState;
        }
    }
}
