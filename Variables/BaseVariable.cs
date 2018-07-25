using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseVariable<T> : ScriptableObject
{
    public T Value;

    public static implicit operator T(BaseVariable<T> variable)
    {
        return variable.Value;
    }
}
