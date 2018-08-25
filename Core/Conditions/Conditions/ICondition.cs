namespace ScriptableObjectFramework.Conditions
{
    public interface ICondition<T>
    {
        /// <summary>
        /// Evaluates the condition.
        /// </summary>
        /// <param name="value">The value to compare against</param>
        void Evaluate(T value);
    }
}
