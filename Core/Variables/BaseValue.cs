using System.ComponentModel;

namespace ScriptableObjectFramework
{
    public abstract class BaseValue<T, Y> : IValue<T>
        where Y : BaseVariable<T>
    {
        public T NormalValue;
        public Y SOValue;
        public bool UseNormal;

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