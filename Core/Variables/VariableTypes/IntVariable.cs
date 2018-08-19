using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "Scriptable Objects/Variables/Int")]
    public class IntVariable : ConditionableVariable<int, IntComparableConditionCollection> { } 
}