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

        public event Action onGameStart;
        public void GameStart()
        {
            onGameStart?.Invoke();
        }

        public event Action onGameRestart;
        public void GameRestart()
        {
            onGameRestart?.Invoke();
        }

        public event Action<BoardState> onGameEnded;
        public void GameEnded(BoardState boardState)
        {
            onGameEnded?.Invoke(boardState);
        }

        public event Action<Vector2Int, Symbol> onMadeMove;
        public void MadeMove(Vector2Int position, Symbol symbol)
        {
            onMadeMove?.Invoke(position, symbol);
        }

        public event Action onUndoLastMove;
        public void UndoLastMove()
        {
            onUndoLastMove?.Invoke();
        }
    }
}

