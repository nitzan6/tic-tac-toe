using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class BoardHistory
    {
        private Stack<Vector2Int> _moveHistory;

        public void AddToHistory(Vector2Int move)
        {
            _moveHistory.Push(move);
        }

        public Vector2Int RemoveLastMove()
        {
            return _moveHistory.Pop();
        }

        public bool IsEmpty()
        {
            return _moveHistory.Count == 0;
        }
    }

}
