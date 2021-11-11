using Code.Infrastructure.States;
using Code.Services;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, Loading loading)
        {
            StateMachine = new GameStateMachine(new LoadScene(coroutineRunner), loading, AllServices.Container);
        }
    }
}