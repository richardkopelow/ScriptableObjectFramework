using ScriptableObjectFramework.Variables;
using System.ComponentModel;
using UnityEngine;

namespace ScriptableObjectFramework
{
    /// <summary>
    /// The base type for creating Values.
    /// </summary>
    /// <typeparam name="T">The data type.</typeparam>
    /// <typeparam name="Y">The Variable type.</typeparam>
    public abstract class BaseValue<T, Y> : IValue<T>
        where Y : BaseVariable<T>
    {
        public T NormalValue;
        [SerializeField]
        private Y SOValue;
        public Y ScriptableObject
        {
            get
            {
                return SOValue;
            }
            set
            {
                if (SOValue != null)
                {
                    SOValue.PropertyChanged -= invokePropertyChanged;
                }
                SOValue = value;
                if (SOValue != null)
                {
                    SOValue.PropertyChanged += invokePropertyChanged;
                }
            }
        }
        public bool UseNormal = true;

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
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                    }
                }
                else
                {
                    SOValue.Value = value;
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void invokePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged(this, e);
        }

        public static implicit operator T(BaseValue<T, Y> value)
        {
            return value.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public void TieEvents()
        {
            if (SOValue != null)
            {
                SOValue.PropertyChanged += invokePropertyChanged;
            }
        }
    }
}