using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework
{
    public interface IValue<T> : INotifyPropertyChanged
    {
        T Value { get; set; }
    }

}
