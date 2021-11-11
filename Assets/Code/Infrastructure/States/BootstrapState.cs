using Code.Infrastructure.AssetProvider;
using Code.Infrastructure.Factory;
using Code.Services.Input;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class BootstrapState:IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadScene _sceneLoader;
        private AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, LoadScene sceneLoader, AllServices allServices)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = allServices;
            RegisterServices();
        }
        public void Enter()
        {
            _sceneLoader.Load(Initial, onComplete: EnterLoadLevel);
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(CreateInput());
            _services.RegisterSingle<IAssetsProvider>(new AssetsProvider());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssetsProvider>()));

        }

        private void EnterLoadLevel() => _gameStateMachine.Enter<LoadLevelState, string>("Level1");


        private IInputService CreateInput()
        {
            if (Application.isEditor)
                return new InputServiceStandalone();
            else
                return new InputServiceMobile();
        }

        public void Exit()
        {
            
        }
    }
}