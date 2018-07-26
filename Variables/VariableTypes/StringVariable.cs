using UnityEngine;

namespace ScriptableObjectFramework
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "Scriptable Objects/Variables/String")]
    public class StringVariable : BaseVariable<string> { } 
}