using Code.Services.Input;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            if (Application.isEditor)
                InputService = new InputServiceStandalone();
            else
                InputService = new InputServiceMobile();
        }
    }
}