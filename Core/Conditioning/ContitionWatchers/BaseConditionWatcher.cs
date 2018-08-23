using ScriptableObjectFramework;
using UnityEngine;

namespace ScriptableObjectFramework
{
    public class BaseConditionWatcher<T, Y, Z> : MonoBehaviour
        where Y : BaseVariable<T>
        where Z : IConditionCollection<T>
    {
        public Y Variable;
        public Z Conditions;

        protected virtual void Start()
        {
            Variable.PropertyChanged += OnValueChanged;
            Variable.Value = Variable.Value;
        }

        protected virtual void OnDestroy()
        {
            Variable.PropertyChanged -= OnValueChanged;
        }

        protected virtual void OnValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Conditions != null)
            {
                foreach (ICondition<T> condition in Conditions)
                {
                    condition.Evaluate(Variable.Value);
                }
            }
        }
    }
}
