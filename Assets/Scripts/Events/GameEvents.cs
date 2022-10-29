using System;
using TicTacToe.GameProgression;
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

        public event Action<Vector2Int, Symbol> onSymbolPlaced;
        public void SymbolPlaced(Vector2Int position, Symbol symbol)
        {
            onSymbolPlaced?.Invoke(position, symbol);
        }

        public event Action onUndoLastMove;
        public void UndoLastMove()
        {
            onUndoLastMove?.Invoke();
        }
    }
}

