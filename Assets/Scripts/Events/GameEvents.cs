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

        public event Action<GameState> onGameEnded;
        public void GameEnded(GameState gameResult)
        {
            onGameEnded?.Invoke(gameResult);
        }

        public event Action<Vector2Int, Symbol> onMadeMove;
        public void MadeMove(Vector2Int position, Symbol symbol)
        {
            onMadeMove?.Invoke(position, symbol);
        }

        public event Action<Vector2Int> onUndoLastMove;
        public void UndoLastMove(Vector2Int lastMove)
        {
            onUndoLastMove?.Invoke(lastMove);
        }
    }
}

