using Code.Infrastructure.AssetProvider;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string HeroPath = "Hero/hero";
        private const string InitialPointTag = "InitialPoint";
        private const string HUDPath = "Hud/HUD";
        private readonly IAssetsProvider _assetsProvider;

        public GameFactory(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public GameObject CreateHero()
        {
            GameObject hero = this._assetsProvider.Instantiate(HeroPath, GameObject.FindWithTag(InitialPointTag).transform.position);
            return hero;
        }

        public void CreateHud() => 
            _assetsProvider.Instantiate(HUDPath);
    }
}