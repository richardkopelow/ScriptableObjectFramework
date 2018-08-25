using ScriptableObjectFramework.Variables;
using System.ComponentModel;

namespace ScriptableObjectFramework
{
    /// <summary>
    /// The base type for creating Values.
    /// </summary>
    /// <typeparam name="T">The data type.</typeparam>
    /// <typeparam name="Y">The Variable type.</typeparam>
    public abstract class BaseValue<T, Y> : IValue<T>, INotifyPropertyChanged
        where Y : BaseVariable<T>
    {
        public T NormalValue;
        public Y SOValue;
        public bool UseNormal;

        /// <summary>
        /// The data value of the Value field;
        /// </summary>
        public T Value
        {
            get
            {
                if (UseNormal || SOValue == null)
                {
                    return NormalValue;
                }
                else
                {
                    return SOValue.Value;
                }
            }
            set
            {
                if (UseNormal || SOValue == null)
                {
                    NormalValue = value;
                }
                else
                {
                    SOValue.Value = value;
                }
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static implicit operator T(BaseValue<T, Y> value)
        {
            return value.Value;
        }
    }
}