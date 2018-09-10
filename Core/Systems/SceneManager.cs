using ScriptableObjectFramework.Events.UnityEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjectFramework.Systems
{
    public class SceneManager : ScriptableObject
    {
        public SceneFader FaderPrefab;
        public BoolValue ShowProgressBar;
        public FloatValue FadeTime;
        public Color FadeColor;
        public Sprite TransitionBackground;
        public StringUnityEvent SceneLoaded_Name;
        public IntUnityEvent SceneLoaded_Index;

        public Scene CurrentScene
        {
            get
            {
                return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            }
        }

        private void OnEnable()
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        private void SceneManager_activeSceneChanged(Scene current, Scene next)
        {
            SceneLoaded_Name.Invoke(next.name);
            SceneLoaded_Index.Invoke(next.buildIndex);
        }

        public Coroutine LoadScene(string name)
        {
            SceneFader fader = Instantiate(FaderPrefab);
            fader.Init(FadeColor, TransitionBackground, ShowProgressBar);
            DontDestroyOnLoad(fader.gameObject);
            return fader.StartCoroutine(loadSceneAsync(name, fader));
        }

        private IEnumerator loadSceneAsync(string name, SceneFader fader)
        {
            var loadOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
            loadOp.allowSceneActivation = false;
            float passedTime = 0;
            //A progress of 0.9 indicates that the scene data is loaded into memory and ready to be switched to.
            while (loadOp.progress < 0.9f)
            {
                yield return null;
                passedTime += Time.deltaTime;
                fader.SetFadeAlpha(Mathf.Clamp(passedTime / FadeTime, 0, 1));
                fader.SetProgress(Mathf.Clamp(loadOp.progress / 0.9f, 0, 1));
            }
            loadOp.allowSceneActivation = true;

            yield return new WaitUntil(() => loadOp.isDone);

            Destroy(fader.gameObject);
        }
    }
}
