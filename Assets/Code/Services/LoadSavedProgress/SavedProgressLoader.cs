using Code.Data;
using Code.Infrastructure.Factory;
using Code.Services.PesistentProgress;
using UnityEngine;

namespace Code.Services.LoadSavedProgress
{
    public class SavedProgressLoader : ISavedProgressLoader
    {
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgressService;
        private const string ProgressKey = "ProgressKey";

        public SavedProgressLoader(IGameFactory gameFactory,IPersistentProgressService persistentProgressService)
        {
            _gameFactory = gameFactory;
            _persistentProgressService = persistentProgressService;
        }

        public void SaveData()
        {
            foreach (var saver in _gameFactory.SavedProgressList)
            {
                saver.SavedProgress(_persistentProgressService.PlayerData);
            }
            PlayerPrefs.SetString(ProgressKey, _persistentProgressService.PlayerData.ConvertFromJson());
        }

        public PlayerData LoadProgress() => 
            PlayerPrefs.GetString(ProgressKey)?.ConvertJson<PlayerData>();
    }
}