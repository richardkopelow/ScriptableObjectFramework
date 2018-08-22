using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Scriptable Objects/Variables/Float")]
    public class FloatVariable : ConditionableVariable<float, FloatComparableConditionCollection> { }
}