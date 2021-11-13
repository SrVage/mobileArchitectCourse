using UnityEngine;

namespace Code.Infrastructure
{
    public class GameRunner:MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _bootstrapperPrefab;

        private void Awake()
        {
            if (FindObjectOfType<GameBootstrapper>() == null)
                Instantiate(_bootstrapperPrefab);

        }
    }
}