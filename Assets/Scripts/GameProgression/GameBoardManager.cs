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
            _board = new Board(Consts.BOARD_LENGTH, Consts.BOARD_WIDTH);
        }

        public bool CanPlaceSymbol(Vector2Int position)
        {
            return _board.IsCellEmpty(position);
        }

        public void MakeMove(Vector2Int position, Symbol symbol)
        {
            _board.InsertElement(position, symbol);
            // Board Updated event
            GameEvents.Instance.SymbolPlaced(position, symbol);
        }
        

    }
}

