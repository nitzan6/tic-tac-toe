using System;
using UnityEngine;

namespace TicTacToe.GameManagement
{
    public class GameEvents : MonoBehaviour
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

