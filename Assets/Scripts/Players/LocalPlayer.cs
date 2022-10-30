using System;
using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class LocalPlayer : MonoBehaviour, IPlayer
    {
        public Symbol Symbol { get; set; }
        public Board GameBoard { get; set; }

        public event Action<Vector2Int, Symbol> OnChooseMove;
        private bool _canPlay = false;

        void OnEnable()
        {
            GameEvents.Instance.onCellClicked += HandlePlayerInput;
        }

        public void ReceiveTurnInformation(Symbol currentTurnSymbol)
        {
            _canPlay = Symbol == currentTurnSymbol; //Is the current symbol my symbol?
        }

        public void HandlePlayerInput(Vector2Int cellPosition)
        {
            if (!_canPlay)
            {
                return;
            }

            if (!GameBoard.IsCellEmpty(cellPosition))
            {
                return;
            }

            OnChooseMove?.Invoke(cellPosition, Symbol);
        }

        void OnDisable()
        {
            GameEvents.Instance.onCellClicked -= HandlePlayerInput;
        }
    }

}
