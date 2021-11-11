using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class LoadScene
    {
        private ICoroutineRunner _coroutineRunner;

        public LoadScene(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onComplete=null) => _coroutineRunner.StartCoroutine(LoadSceneAsync(name, onComplete));

        private IEnumerator LoadSceneAsync(string name, Action onComplete)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onComplete?.Invoke();
                yield break;
            }
            AsyncOperation waitScene = SceneManager.LoadSceneAsync(name);
            while (!waitScene.isDone)
                yield return null;
            onComplete?.Invoke();
        }
    }
}