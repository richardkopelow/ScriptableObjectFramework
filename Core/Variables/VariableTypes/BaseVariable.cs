using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using ScriptableObjectFramework.Attributes;

namespace ScriptableObjectFramework.Variables
{
    public abstract class BaseVariable : ScriptableObject
    {
        public abstract object GetValue();
    }

    public abstract class BaseVariable<T> : BaseVariable, INotifyPropertyChanged
    {
        [SerializeField]
        [PairedProperty("SaveInPlayMode")]
        [ModifiableProperty]
        private bool saveInPlayMode;
        public bool SaveInPlayMode
        {
            get
            {
                return saveInPlayMode;
            }
            set
            {
                saveInPlayMode = value;
                if (saveInPlayMode)
                {
                    this.value = currentValue;
                }
            }
        }

        [SerializeField]
        [ShowByPlayMode(PlayMode = false)]
        [PairedProperty("Value")]
        [ModifiableProperty]
        private T value;

        [SerializeField]
        [ShowByPlayMode]
        [PairedProperty("Value")]
        [ModifiableProperty]
        private T currentValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual T Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                if (saveInPlayMode)
                {
                    this.value = value;
                }
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }

        public override object GetValue()
        {
            return Value;
        }

        protected virtual void OnEnable()
        {
            currentValue = value;
        }

        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }
    }
}
