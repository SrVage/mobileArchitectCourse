using Code.Services;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory:IService
    {
        GameObject CreateHero();
        void CreateHud();
    }
}