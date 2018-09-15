using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectFramework.Systems.SceneManagement
{
    public abstract class BaseSceneFader : MonoBehaviour
    {
        public abstract void Init(Color fadeColor, Sprite transitionBackground, bool showProgressBar);

        public abstract void SetFadeAlpha(float alpha);

        public abstract void SetProgress(float progress);
    } 
}
