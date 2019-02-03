using ScriptableObjectFramework.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Conditions
{
    [Flags]
    public enum ComparableComparison
    {
        GreaterThan = 1,
        LessThan = 2,
        EqualTo = 4,
        NotEqualTo = 8,
        GreaterOrEqualTo = 5,
        LessOrEqualTo = 6,
        None = 0
    }

    /// <summary>
    /// A condition that compares IComparables.
    /// </summary>
    /// <typeparam name="T">The type to compare</typeparam>
    /// <typeparam name="Y">The Value type to compare against</typeparam>
    /// <typeparam name="Z">The event type to trigger</typeparam>
    public class ComparableCondition<T, Y, Z> : Condition<T>
        where T : IComparable
        where Y : IValue<T>
        where Z : IEvent<T>
    {
        public ComparableComparison Condition;
        public Y Argument;
        public Z Event;

        private ComparableComparison lastState;

        public override void Evaluate(T value)
        {
            ComparableComparison currentState = ComparableComparison.None;
            int comparison = value.CompareTo(Argument.Value);
            if (comparison == 0)
            {
                currentState = ComparableComparison.EqualTo;
            }
            else
            {
                if (comparison > 0)
                {
                    currentState = ComparableComparison.GreaterThan | ComparableComparison.NotEqualTo;
                }
                else
                {
                    currentState = ComparableComparison.LessThan | ComparableComparison.NotEqualTo;
                }
            }

            //If we only want to trigger when crossing the threshold, get the dif between the current state and the last
            ComparableComparison stateDif = ExecutionMode == ConditionExecutionMode.OnThreshold 
                ? currentState & ~lastState 
                : currentState;
            if ((stateDif & Condition) != 0)
            {
                Event.Fire(value);
            }
            lastState = currentState;
        }
    }
}
