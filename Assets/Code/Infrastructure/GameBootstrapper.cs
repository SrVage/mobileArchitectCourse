using Code.Infrastructure.States;
using Code.Services;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper:MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        [SerializeField] private Loading _loadingPrefab;
        private void Awake()
        {
            _game = new Game(this, Instantiate(_loadingPrefab));
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this); 
        }
        
    }
}