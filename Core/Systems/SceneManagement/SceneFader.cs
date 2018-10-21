using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectFramework.Systems.SceneManagement
{
    public class SceneFader : BaseSceneFader
    {
        public Image ColorBackground;
        public Image TransitionBackground;
        public Image ProgressFill;

        private Image[] images;

        public override void Init(Color fadeColor, Sprite transitionBackground, bool showProgressBar)
        {
            ColorBackground.color = fadeColor;
            if (transitionBackground == null)
            {
                TransitionBackground.gameObject.SetActive(false);
            }
            else
            {
                TransitionBackground.sprite = transitionBackground;
            }
            ProgressFill.gameObject.SetActive(showProgressBar);

            images = GetComponent<Transform>().GetComponentsInChildren<Image>();
            SetFadeAlpha(0);
        }

        public override void SetFadeAlpha(float alpha)
        {
            foreach (Image image in images)
            {
                Color color = image.color;
                color.a = alpha;
                image.color = color;
            }
        }

        public override void SetProgress(float progress)
        {
            ProgressFill.fillAmount = progress;
        }
    }
}
