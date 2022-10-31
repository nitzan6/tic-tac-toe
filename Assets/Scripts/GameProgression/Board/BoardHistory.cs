using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class BoardHistory
    {
        private Stack<Vector2Int> _moveHistory;

        public BoardHistory()
        {
            _moveHistory = new Stack<Vector2Int>();
        }

        public void AddToHistory(Vector2Int move)
        {
            _moveHistory.Push(move);
        }

        public List<Vector2Int> RemoveLastMove()
        {
            List<Vector2Int> lastMoveCellPositions = new List<Vector2Int>();

            if (_moveHistory.Count == 1)
            {
                lastMoveCellPositions.Add(_moveHistory.Pop());
                return lastMoveCellPositions;
            }

            lastMoveCellPositions.Add(_moveHistory.Pop());
            lastMoveCellPositions.Add(_moveHistory.Pop());

            return lastMoveCellPositions;
        }

        public bool IsEmpty()
        {
            return _moveHistory.Count == 0;
        }
    }

}
