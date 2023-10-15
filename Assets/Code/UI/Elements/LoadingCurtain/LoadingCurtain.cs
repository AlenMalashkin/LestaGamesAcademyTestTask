using System;
using System.Collections;
using UnityEngine;

namespace Code.UI.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(DoFadeOut());
        }

        private IEnumerator DoFadeOut()
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= 0.01f;
                yield return new WaitForSeconds(0.03f);
            }
            
            gameObject.SetActive(false);
        }
    }
}