using UnityEngine;
using TicTacToe.GameManagement;
using System.Collections.Generic;

namespace TicTacToe.GameProgression
{
    public class GameBoardManager : MonoBehaviour
    {
        private Board _board;
        private BoardHistory _boardHistory;
        private Referee _referee;

        void Awake()
        {
            
        }

        void OnEnable()
        {
            GameEvents.Instance.onStartGame += ResetBoard;
        }

        private void ResetBoard()
        {
            _board = new Board(Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT);
        }

        public bool IsMoveValid(Vector2Int position)
        {
            return _board.IsCellEmpty(position);
        }

        public void MakeMove(Vector2Int position, Symbol symbol)
        {
            if (!IsMoveValid(position))
            {
                return;
            }

            _board.InsertElement(position, symbol);
            _boardHistory.AddToHistory(position);

            GameEvents.Instance.SymbolPlaced(position, symbol);

            _referee.CheckForWin(_board);
        }
        
        public void UndoLastMove()
        {
            if (_boardHistory.IsEmpty())
            {
                return;
            }


        }

    }
}

