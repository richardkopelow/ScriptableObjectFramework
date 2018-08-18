namespace ScriptableObjectFramework
{
    public abstract class BaseValue<T, Y>
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
            }
        }

        public static implicit operator T(BaseValue<T, Y> value)
        {
            return value.Value;
        }
    }
}