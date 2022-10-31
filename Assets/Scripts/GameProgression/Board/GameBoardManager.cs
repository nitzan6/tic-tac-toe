using UnityEngine;
using TicTacToe.GameManagement;
using System.Collections.Generic;

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

        public GameState GetGameState()
        {
            Symbol? winner = _referee.CheckWinner(Board.Cells);

            if (winner != null)
            {
                return winner == Symbol.X ? GameState.X_WIN : GameState.O_WIN;
            }
            
            if (_referee.IsDraw(Board.Cells))
            {
                return GameState.DRAW;
            }

            return GameState.PLAYING;
        }
        
        public void UndoLastMove()
        {
            if (_boardHistory.IsEmpty())
            {
                return;
            }

            List<Vector2Int> lastMovePositions = _boardHistory.RemoveLastMove();

            foreach (Vector2Int position in lastMovePositions)
            {
                Board.ClearCell(position);
            }

            GameEvents.Instance.UndoLastMove(lastMovePositions);
        }

    }
}

