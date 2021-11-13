using System.Collections.Generic;
using Code.Infrastructure.AssetProvider;
using Code.Services.PesistentProgress;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string HeroPath = "Hero/hero";
        private const string InitialPointTag = "InitialPoint";
        private const string HUDPath = "Hud/HUD";
        private readonly IAssetsProvider _assetsProvider;

        public List<ISavedProgress> SavedProgressList { get; } = new List<ISavedProgress>();
        public List<ILoadProgress> LoadProgressList { get; } = new List<ILoadProgress>();

        public GameFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public GameObject CreateHero()
        {
            GameObject hero = this._assetsProvider.Instantiate(HeroPath, GameObject.FindWithTag(InitialPointTag).transform.position);
            CheckGameObjectComponents(hero);
            return hero;
        }

        public void CreateHud()
        {
            _assetsProvider.Instantiate(HUDPath);
        }


        private void CheckGameObjectComponents(GameObject gameObject)
        {
            foreach (var loader in gameObject.GetComponentsInChildren<ILoadProgress>())
            {
                AddInList(loader);
            }
        }

        private void AddInList(ILoadProgress components)
        {
            if (components is ISavedProgress savedProgress)
                SavedProgressList.Add(savedProgress);
            LoadProgressList.Add(components);
        }

        public void ClenUp()
        {
            LoadProgressList.Clear();
            SavedProgressList.Clear();
        }
    }
}