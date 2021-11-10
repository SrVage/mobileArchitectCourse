using System;
using Code.Services.Input;
using UnityEngine;

namespace Code.Infrastructure
{
    public class BootstrapState:IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadScene _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, LoadScene sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
            CreateInput();
            _sceneLoader.Load(Initial, onComplete: EnterLoadLevel);
        }

        private void EnterLoadLevel() => _gameStateMachine.Enter<LoadLevelState, string>("Level1");


        private void CreateInput()
        {
            if (Application.isEditor)
                Game.InputService = new InputServiceStandalone();
            else
                Game.InputService = new InputServiceMobile();
        }

        public void Exit()
        {
            
        }
    }
}