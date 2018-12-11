using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectFramework.Systems.ApplicationManager
{
    [CreateAssetMenu(fileName = "NewApplicationManager", menuName = "Scriptable Objects/Systems/ApplicationManager")]
    public class ApplicationManager : ScriptableObject
    {
        public UnityEvent OnApplicationWantsToQuit;
        public UnityEvent OnApplicationQuitting;

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

        public bool CursorVisible
        {
            get
            {
                return Cursor.visible;
            }
            set
            {
                Cursor.visible = value;
            }
        }

        public CursorLockMode CursorLockMode
        {
            get
            {
                return Cursor.lockState;
            }
            set
            {
                Cursor.lockState = value;
            }
        }

        private void OnEnable()
        {
            Application.wantsToQuit += Application_wantsToQuit;
            Application.quitting += Application_quitting;
        }

        private bool Application_wantsToQuit()
        {
            OnApplicationWantsToQuit.Invoke();
            return false;
        }

        private void Application_quitting()
        {
            OnApplicationQuitting.Invoke();
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
