using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework.Conditions
{
    [Serializable]
    public class IntComparableConditionCollection : ConditionCollection<int, IntComparableCondition> { }
    [Serializable]
    public class FloatComparableConditionCollection : ConditionCollection<float, FloatComparableCondition> { }
}
