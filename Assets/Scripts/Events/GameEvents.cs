using System;

namespace TicTacToe.GameProgression
{
    public class GameEvents
    {
        public static GameEvents Instance;

        void Awake()
        {
            Instance = this;
        }

        public event Action onStartGame;
        public void StartGame()
        {
            onStartGame?.Invoke();
        }
    }
}

