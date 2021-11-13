using System;
using Code.Data;
using Code.Services.LoadSavedProgress;
using Code.Services.PesistentProgress;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private ISavedProgressLoader _saveLoader;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISavedProgressLoader saveLoader)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoader = saveLoader;
        }

        public void Enter()
        {
            LoadOrCreateProgress();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.PlayerData.PositionOnLevel.LevelName);
        }

        public void Exit()
        {
            
        }

        private void LoadOrCreateProgress()
        {
            _progressService.PlayerData = _saveLoader.LoadProgress() ?? new PlayerData("Level1");
        }
    }
}