using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework
{
    [Flags]
    public enum Condition
    {
        GreaterThan = 1,
        LessThan = 2,
        EqualTo = 4,
        NotEqualTo = 8,
        GreaterOrEqualTo = 5,
        LessOrEqualTo = 6,
        None = 0
    }
    
    public class ComparableCondition<T, Y, Z> : ICondition<T>
        where T : IComparable
        where Y : IValue<T>
        where Z : IEvent<T>
    {
        public Condition Condition;
        public Y Argument;
        public Z Event;

        private Condition lastState;

        public void Evaluate(T value)
        {
            Condition currentState = Condition.None;
            int comparison = value.CompareTo(Argument.Value);
            if (comparison == 0)
            {
                currentState = Condition.EqualTo;
            }
            else
            {
                if (comparison > 0)
                {
                    currentState = Condition.GreaterThan | Condition.NotEqualTo;
                }
                else
                {
                    currentState = Condition.LessOrEqualTo | Condition.NotEqualTo;
                }
            }

            Condition stateDif = currentState & ~lastState;
            if ((stateDif & Condition) != 0)
            {
                Event.Fire(value);
            }
            lastState = currentState;
        }
    }
}
