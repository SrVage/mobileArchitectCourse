using System;
using System.Collections;
using Code.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class GameBootstrapper:MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        [SerializeField] private Loading _loading;
        private void Awake()
        {
            _game = new Game(this, _loading);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }

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