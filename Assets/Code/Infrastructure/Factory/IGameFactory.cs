using System.Collections.Generic;
using Code.Services;
using Code.Services.PesistentProgress;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory:IService
    {
        GameObject CreateHero();
        void CreateHud();
        List<ISavedProgress> SavedProgressList { get; }
        List<ILoadProgress> LoadProgressList { get; }
        void ClenUp();
    }
}