using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework
{
    public abstract class BaseVariable<T> : ScriptableObject
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

        public T Value
        {
            get
            {
                return saveInPlayMode ? value : currentValue;
            }
            set{
                currentValue = value;
                if (saveInPlayMode)
                {
                    this.value = value;
                }
            }
        }

        protected void OnEnable()
        {
            currentValue = value;
        }

        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }
    }
}
