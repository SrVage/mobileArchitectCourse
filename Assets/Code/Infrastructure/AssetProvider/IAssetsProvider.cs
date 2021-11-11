using Code.Services;
using UnityEngine;

namespace Code.Infrastructure.AssetProvider
{
    public interface IAssetsProvider:IService
    {
        GameObject Instantiate(string path, Vector3 initialPosition);
        GameObject Instantiate(string path);
    }
}