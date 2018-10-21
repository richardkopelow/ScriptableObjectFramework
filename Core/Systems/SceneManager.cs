using ScriptableObjectFramework.Events.UnityEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjectFramework.Systems.SceneManagement
{
    [CreateAssetMenu(fileName = "NewSceneManager", menuName = "Scriptable Objects/Systems/SceneManager")]
    public class SceneManager : ScriptableObject
    {
        public BaseSceneFader FaderPrefab;
        public BoolValue ShowProgressBar;
        public FloatValue FadeTime;
        public Color FadeColor;
        public Sprite TransitionBackground;
        [SerializeField]
        private ThreadPriority _asyncLoadPriority = ThreadPriority.Normal;
        public ThreadPriority AsyncLoadPriority
        {
            get
            {
                return _asyncLoadPriority;
            }
            set
            {
                _asyncLoadPriority = value;
                Application.backgroundLoadingPriority = _asyncLoadPriority;
            }
        }

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
            AsyncLoadPriority = _asyncLoadPriority;
        }

        private void SceneManager_activeSceneChanged(Scene current, Scene next)
        {
            SceneLoaded_Name.Invoke(next.name);
            SceneLoaded_Index.Invoke(next.buildIndex);
        }

        public void LoadScene(int id)
        {
            Coroutine co;
            LoadScene(id, out co);
        }

        public void LoadScene(int id, out Coroutine coroutine)
        {
            BaseSceneFader fader = Instantiate(FaderPrefab);
            fader.Init(FadeColor, TransitionBackground, ShowProgressBar);
            DontDestroyOnLoad(fader.gameObject);
            coroutine = fader.StartCoroutine(loadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(id).name, fader));
        }

        public void LoadScene(string name)
        {
            Coroutine co;
            LoadScene(name, out co);
        }

        public void LoadScene(string name, out Coroutine coroutine)
        {
            BaseSceneFader fader = Instantiate(FaderPrefab);
            fader.Init(FadeColor, TransitionBackground, ShowProgressBar);
            DontDestroyOnLoad(fader.gameObject);
            coroutine = fader.StartCoroutine(loadSceneAsync(name, fader));
        }

        private IEnumerator loadSceneAsync(string name, BaseSceneFader fader)
        {
            var loadOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
            loadOp.allowSceneActivation = false;
            float passedTime = 0;
            //A progress of 0.9 indicates that the scene data is loaded into memory and ready to be switched to.
            while (loadOp.progress < 0.9f || passedTime < FadeTime)
            {
                yield return null;
                passedTime += Time.deltaTime;
                fader.SetFadeAlpha(Mathf.Clamp(passedTime / FadeTime, 0, 1));
                fader.SetProgress(Mathf.Clamp(loadOp.progress / 0.9f, 0, 1));
            }
            loadOp.allowSceneActivation = true;

            yield return new WaitUntil(() => loadOp.isDone);

            passedTime = 0;
            //A progress of 0.9 indicates that the scene data is loaded into memory and ready to be switched to.
            while (passedTime < FadeTime)
            {
                yield return null;
                passedTime += Time.deltaTime;
                fader.SetFadeAlpha(Mathf.Clamp(1 - passedTime / FadeTime, 0, 1));
            }

            Destroy(fader.gameObject);
        }

        public void ReloadCurrentScene()
        {
            Coroutine co;
            ReloadCurrentScene(out co);
        }

        public void ReloadCurrentScene(out Coroutine coroutine)
        {
            LoadScene(CurrentScene.name, out coroutine);
        }
    }
}
