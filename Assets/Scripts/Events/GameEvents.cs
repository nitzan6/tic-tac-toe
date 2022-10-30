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

        public event Action onRestartGame;
        public void RestartGame()
        {
            onRestartGame?.Invoke();
        }

        public event Action onGameEnded;
        public void GameEnded()
        {
            onGameEnded?.Invoke();
        }

        public event Action<Vector2Int, Symbol> onMadeMove;
        public void MadeMove(Vector2Int position, Symbol symbol)
        {
            onMadeMove?.Invoke(position, symbol);
        }

        public event Action<Vector2Int> onCellClicked;
        public void CellClicked(Vector2Int position)
        {
            onCellClicked?.Invoke(position);
        }

        public event Action onUndoLastMove;
        public void UndoLastMove()
        {
            onUndoLastMove?.Invoke();
        }
    }
}

