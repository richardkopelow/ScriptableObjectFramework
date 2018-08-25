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

    /// <summary>
    /// The base type for creating new Variable types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseVariable<T> : BaseVariable, INotifyPropertyChanged
    {
        [SerializeField]
        [PairedProperty("SaveInPlayMode")]
        [ModifiableProperty]
        private bool saveInPlayMode;
        /// <summary>
        /// Toggles whether the changes should be saved in play mode
        /// </summary>
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

        [Tooltip("The stored value of the variable.")]
        [SerializeField]
        [ShowByPlayMode(PlayMode = false)]
        [ModifiableProperty]
        private T value;

        [Tooltip("The current value of the variable.")]
        [SerializeField]
        [ShowByPlayMode]
        [PairedProperty("Value")]
        [ModifiableProperty]
        private T currentValue;

        /// <summary>
        /// Fired when the Value property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The value of the variable.
        /// </summary>
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

        /// <summary>
        /// Gets the value of the variable.
        /// </summary>
        /// <returns>An object reference to the variable's value.</returns>
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
