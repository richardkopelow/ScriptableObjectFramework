using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Systems.ApplicationManager
{
    [CreateAssetMenu(fileName = "NewApplicationManager", menuName = "Scriptable Objects/Systems/ApplicationManager")]
    public class ApplicationManager : ScriptableObject
    {
        public void Quit()
        {
            Application.Quit();
        }
    } 
}
