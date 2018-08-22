using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace ScriptableObjectFramework
{
    public class BaseVariable : ScriptableObject
    {
        public virtual object GetValue()
        {
            return new object();
        }
    }

    public abstract class BaseVariable<T> : BaseVariable, INotifyPropertyChanged
    {
        [SerializeField]
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

        private T currentValue;

        [SerializeField]
        private T value;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual T Value
        {
            get
            {
                return saveInPlayMode ? value : currentValue;
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
    }
}
