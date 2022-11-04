using System;
using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class LocalPlayer : MonoBehaviour, IPlayer
    {
        public enSymbol Symbol { get; set; }
        public Board GameBoard { get; set; }

        public event Action<Vector2Int, enSymbol> OnChooseMove;
        public bool IsCanPlay { get; private set; } = false;
        public string Name { get; set; }

        public void ReceiveCurrentTurnInfo(enSymbol currentTurnSymbol)
        {
            IsCanPlay = Symbol == currentTurnSymbol; //Is the current symbol my symbol?
        }

        public void HandlePlayerInput(Vector2Int cellPosition)
        {
            if (!GameBoard.IsCellEmpty(cellPosition))
            {
                return;
            }

            OnChooseMove?.Invoke(cellPosition, Symbol);
        }
    }

}
