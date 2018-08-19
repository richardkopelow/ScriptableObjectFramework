using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework
{
    public interface IEvent<T>
    {
        void Fire(T arg);
    }
}
