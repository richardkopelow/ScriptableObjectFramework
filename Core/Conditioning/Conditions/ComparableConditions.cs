using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework.Conditions
{
    [Serializable]
    public class IntComparableCondition : ComparableCondition<int, IntValue, IntEvent> { }
    [Serializable]
    public class FloatComparableCondition : ComparableCondition<float, FloatValue, FloatEvent> { }
}
