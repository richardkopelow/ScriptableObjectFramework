using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework
{
    public interface IConditionCollection<T> : IEnumerable<ICondition<T>>
    {
    }
}
