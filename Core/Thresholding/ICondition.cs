namespace ScriptableObjectFramework
{
    public interface ICondition<T>
    {
        void Evaluate(T value);
    }
}
