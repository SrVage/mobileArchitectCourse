using System;
using Code.Camera;
using Code.Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Infrastructure
{
    public class LoadLevelState:IPayLoadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string HeroPath = "Hero/hero";
        private const string HUDPath = "Hud/HUD";
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadScene _sceneLoader;
        private readonly Loading _loading;

        public LoadLevelState(GameStateMachine gameStateMachine, LoadScene sceneLoader, Loading loading)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loading = loading;
        }

        public void Enter(string payLoad)
        {
            _loading.Show();
            _sceneLoader.Load(payLoad, OnLoaded);
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindWithTag(InitialPointTag).transform.position;
            GameObject hero = Instantiate(HeroPath, initialPoint);
            Instantiate(HUDPath);
            CameraFolow(hero);
            _gameStateMachine.Enter<GameLoopState>();
        }
        
        private static void CameraFolow(GameObject hero)
        {
            UnityEngine.Camera.main.GetComponent<CameraFollowing>().SetFollowing(hero.transform);
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }       
        private static GameObject Instantiate(string path, Vector3 initialPosition)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, initialPosition, Quaternion.identity);
        }

        public void Exit() => _loading.Hide();
    }
}