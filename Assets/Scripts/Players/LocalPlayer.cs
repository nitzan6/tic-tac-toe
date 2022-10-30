using System;
using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class LocalPlayer : MonoBehaviour, IPlayer
    {
        private GameBoardManager _gameBoardManager;

        public Symbol Symbol { get; set; }
        public event Action<Vector2Int, Symbol> OnChooseMove;
        private bool _isMyTurn = false;

        void Awake()
        {
            _gameBoardManager = FindObjectOfType<GameBoardManager>();
        }

        void OnEnable()
        {
            GameEvents.Instance.onCellClicked += HandlePlayerInput;
        }

        public void TurnStarts()
        {

        }

        public void HandlePlayerInput(Vector2Int cell)
        {

        }

        void OnDisable()
        {
            GameEvents.Instance.onCellClicked -= HandlePlayerInput;
        }
    }

}
