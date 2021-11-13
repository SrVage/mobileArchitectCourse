using System;
using Code.Camera;
using Code.Infrastructure.Factory;
using Code.Services;
using Code.Services.PesistentProgress;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class LoadLevelState:IPayLoadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadScene _sceneLoader;
        private readonly Loading _loading;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine gameStateMachine, LoadScene sceneLoader, Loading loading, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loading = loading;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string payLoad)
        {
            _loading.Show();
            _gameFactory.ClenUp();
            _sceneLoader.Load(payLoad, OnLoaded);
        }

        private void OnLoaded()
        {
            InitializeGameWorld();
            LoadProgressInform();
        }

        private void LoadProgressInform()
        {
            foreach (var loaders in _gameFactory.LoadProgressList)
            {
                loaders.LoadProgress(_progressService.PlayerData);
            }
        }

        private void InitializeGameWorld()
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