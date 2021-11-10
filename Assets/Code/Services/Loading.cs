using System;
using System.Collections;
using UnityEngine;

namespace Code.Services
{
    public class Loading:MonoBehaviour
    {
        public CanvasGroup _canvas;
        [SerializeField] private float _speed = 0.01f;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            _canvas.gameObject.SetActive(true);
            _canvas.alpha = 1;
        }

        public void Hide() => StartCoroutine(HideCoroutine());

        private IEnumerator HideCoroutine()
        {
            while (_canvas.alpha > 0)
            {
                _canvas.alpha -= _speed;
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}