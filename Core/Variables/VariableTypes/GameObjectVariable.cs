using UnityEngine;

namespace ScriptableObjectFramework.Variables
{
    [CreateAssetMenu(fileName = "NewGameObjectVariable", menuName = "Scriptable Objects/Variables/GameObject")]
    public class GameObjectVariable : BaseVariable<GameObject> { } 
}