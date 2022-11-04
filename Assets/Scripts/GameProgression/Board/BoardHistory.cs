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

        //Removes the n last moves from history and returns them as a list. If the amount of moves requested to remove is greater than
        //The amount of moves stored, it will remove all of the moves stored
        public List<Vector2Int> GetAndRemoveLastMoves(int numberOfMoves)
        {
            List<Vector2Int> lastMoveCellPositions = new List<Vector2Int>();

            for (int i = 0; i < numberOfMoves; i++)
            {
                if (IsEmpty())
                {
                    return lastMoveCellPositions;
                }

                lastMoveCellPositions.Add(_moveHistory.Pop());
            }

            return lastMoveCellPositions;
        }

        public bool IsEmpty()
        {
            return _moveHistory.Count == 0;
        }
    }

}
