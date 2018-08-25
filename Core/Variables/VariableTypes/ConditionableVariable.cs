using ScriptableObjectFramework.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework.Variables
{
    /// <summary>
    /// The base type for creating variables that support innate conditions.
    /// </summary>
    /// <typeparam name="T">The data type to store in the Variable.</typeparam>
    /// <typeparam name="Y">The ConditionCollection to store the desired conditions.</typeparam>
    public class ConditionableVariable<T, Y> : BaseVariable<T>
        where Y : IConditionCollection<T>
    {
        public Y Conditions;

        protected override void OnEnable()
        {
            base.OnEnable();
            PropertyChanged += OnValueChanged;
            OnValueChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Value"));
        }

        private void OnValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Conditions != null)
            {
                foreach (ICondition<T> condition in Conditions)
                {
                    condition.Evaluate(Value);
                }
            }
        }
    }
}
