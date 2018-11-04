using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Systems.ApplicationManager
{
    [CreateAssetMenu(fileName = "NewApplicationManager", menuName = "Scriptable Objects/Systems/ApplicationManager")]
    public class ApplicationManager : ScriptableObject
    {
        public float TimeScale
        {
            get
            {
                return Time.timeScale;
            }
            set
            {
                Time.timeScale = value;
            }
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
