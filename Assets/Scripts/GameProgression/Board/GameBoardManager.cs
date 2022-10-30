using UnityEngine;
using TicTacToe.GameManagement;

namespace TicTacToe.GameProgression
{
    public class GameBoardManager : MonoBehaviour
    {
        private BoardHistory _boardHistory;
        private Referee _referee;
        public Board Board { get; private set; }

        public void ResetBoard()
        {
            Board = new Board(Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT);
        }

        //Check if the move is valid in the specified position
        public bool IsMoveValid(Vector2Int position)
        {
            return Board.IsCellEmpty(position);
        }

        public void MakeMove(Vector2Int position, Symbol symbol)
        {
            if (!IsMoveValid(position))
            {
                return;
            }

            Board.InsertElement(position, symbol);
            _boardHistory.AddToHistory(position);

            GameEvents.Instance.MadeMove(position, symbol);
        }

        public BoardState CheckBoardState()
        {
            return _referee.CheckBoard(Board);
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

