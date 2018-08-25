using ScriptableObjectFramework;
using ScriptableObjectFramework.Variables;
using UnityEngine;

namespace ScriptableObjectFramework.Conditions.Watchers
{
    /// <summary>
    /// The base type for creating objects that exist in the scene and evaluate variable conditions.
    /// </summary>
    /// <typeparam name="T">The type to compare</typeparam>
    /// <typeparam name="Y">The Value type to compare against</typeparam>
    /// <typeparam name="Z">The condition collection type</typeparam>
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
