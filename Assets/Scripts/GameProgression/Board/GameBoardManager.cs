using UnityEngine;
using System.Collections.Generic;

namespace TicTacToe.GameProgression
{
    public class GameBoardManager : MonoBehaviour
    {
        private BoardHistory _boardHistory;
        private Referee _referee;
        public Board Board { get; private set; }

        //Reset board properties
        public void ResetBoard()
        {
            Board = new Board(Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT);
            _referee = new Referee();
            _boardHistory = new BoardHistory();
        }

        //Check if the move is valid in the specified position
        public bool IsMoveValid(Vector2Int position)
        {
            Vector2Int boardBounds = Board.GetBounds();

            //The bounds in the game are [3, 3] (pure length and not zero-indexed)
            // Players should not be able to pick a move outside of bounds
            if (position.x >= boardBounds.x || position.y >= boardBounds.y)
            {
                throw new System.Exception($"[GameBoardManager] - Invalid move attempt - position { position }  is outside of bounds");
            }

            return Board.IsCellEmpty(position);
        }

        public void MakeMove(Vector2Int position, enSymbol symbol)
        {
            if (!IsMoveValid(position))
            {
                return;
            }

            Board.InsertElement(position, symbol);
            _boardHistory.AddToHistory(position);

            GameEvents.Instance.MadeMove(position, symbol);
        }

        // Returns the current state of the game, if its still playing or a result has been reached
        public enGameState GetGameState()
        {
            enSymbol winner = _referee.GetWinner(Board.Cells);

            if (winner != enSymbol.EMPTY)
            {
                return winner == enSymbol.X ? enGameState.X_WIN : enGameState.O_WIN;
            }
            
            if (_referee.CheckDraw(Board.Cells))
            {
                return enGameState.DRAW;
            }

            return enGameState.PLAYING;
        }
        
        public void UndoLastMove()
        {
            if (_boardHistory.IsEmpty())
            {
                return;
            }

            List<Vector2Int> lastMovePositions = _boardHistory.GetAndRemoveLastMoves(2);

            foreach (Vector2Int position in lastMovePositions)
            {
                Board.ClearCell(position);
            }

            GameEvents.Instance.UndoLastMove(lastMovePositions);
        }

    }
}

