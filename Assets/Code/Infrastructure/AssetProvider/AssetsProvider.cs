using UnityEngine;

namespace Code.Infrastructure.AssetProvider
{
    public class AssetsProvider : IAssetsProvider
    {
        public GameObject Instantiate(string path, Vector3 initialPosition)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, initialPosition, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}