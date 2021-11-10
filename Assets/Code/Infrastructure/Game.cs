using Code.Services;
using Code.Services.Input;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, Loading loading)
        {
            StateMachine = new GameStateMachine(new LoadScene(coroutineRunner), loading);
        }
    }
}