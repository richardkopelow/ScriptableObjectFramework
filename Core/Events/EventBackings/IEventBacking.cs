using ScriptableObjectFramework.Events.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework.Events
{
    public interface IEventBacking<T>
    {
        void Fire(T arg);
        void SelfFire();
        void Register(IEventHandler<T> handler);
        void Deregister(IEventHandler<T> handler);
    }
}
