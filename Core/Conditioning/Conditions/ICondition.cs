namespace ScriptableObjectFramework.Conditions
{
    public interface ICondition<T>
    {
        void Evaluate(T value);
    }
}
