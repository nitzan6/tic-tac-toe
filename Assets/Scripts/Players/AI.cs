using System;
using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class AI : MonoBehaviour, IPlayer
    {
        private TurnHandler _turnHandler;
        public Symbol Symbol { get; set; }
        public event Action<Vector2Int, Symbol> OnChooseMove;

        public void TurnStarts()
        {

        }
    }
}

