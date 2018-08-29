using System.Collections.Generic;

namespace ScriptableObjectFramework.Sets
{
    public interface IRuntimeSet<T>
    {
        T this[int index] { get; }

        int Count { get; }

        void Add(T value);
        IEnumerator<T> GetEnumerator();
        void Remove(T value);
    }
}