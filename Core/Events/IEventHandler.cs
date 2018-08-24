using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptableObjectFramework.Events.Handlers
{
    public interface IEventHandler<T>
    {
        void HandleEvent(T arg);
    }
}
