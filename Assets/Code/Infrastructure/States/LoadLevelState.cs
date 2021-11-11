using Code.Camera;
using Code.Infrastructure.Factory;
using Code.Services;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class LoadLevelState:IPayLoadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadScene _sceneLoader;
        private readonly Loading _loading;
        private IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, LoadScene sceneLoader, Loading loading, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loading = loading;
            _gameFactory = gameFactory;
        }

        public void Enter(string payLoad)
        {
            _loading.Show();
            _sceneLoader.Load(payLoad, OnLoaded);
        }

        private void OnLoaded()
        {
            var hero = _gameFactory.CreateHero();
            _gameFactory.CreateHud();
            CameraFolow(hero);
            _gameStateMachine.Enter<GameLoopState>();
        }

        private static void CameraFolow(GameObject hero)
        {
            UnityEngine.Camera.main.GetComponent<CameraFollowing>().SetFollowing(hero.transform);
        }

        public void Exit() => _loading.Hide();
    }
}