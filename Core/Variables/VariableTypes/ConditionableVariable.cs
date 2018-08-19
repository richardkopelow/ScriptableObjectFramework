using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptableObjectFramework
{
    public class ConditionableVariable<T, Y> : BaseVariable<T>
        where Y : IConditionCollection<T>
    {
        public Y Conditions;

        protected override void OnEnable()
        {
            base.OnEnable();
            PropertyChanged += ConditionableVariable_PropertyChanged;
            ConditionableVariable_PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Value"));
        }

        private void ConditionableVariable_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
