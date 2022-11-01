using System;
using System.Collections;
using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class AI : MonoBehaviour, IPlayer
    {
        // a few second delay for the AI to wait before
        // choosing a move, to give the feeling as if playing against a real opponent
        private float _delayInSeconds = 0.5f;
        private System.Random _random;

        public enSymbol Symbol { get; set; }
        public Board GameBoard { get; set; }
        public string Name { get; set; }

        public event Action<Vector2Int, enSymbol> OnChooseMove;

        void Start()
        {
            _random = new System.Random();
        }

        void OnEnable()
        {
            // This is done to prevent a situation where the coroutine for determining a move is
            // Still active after we finished/restarted the game
            GameEvents.Instance.onGameStart += StopCoroutines;
        }

        public void ReceiveCurrentTurnInfo(enSymbol currentTurnSymbol)
        {
            if (Symbol != currentTurnSymbol) // Is it my turn to play or not?
            {
                return;
            }

            StartCoroutine(DetermineMove());
        }

        private IEnumerator DetermineMove()
        {
            //Wait for the amount specified in the delay
            yield return new WaitForSeconds(_delayInSeconds);

            bool isChosenValidCell = false;
            Vector2Int chosenCellPosition = new Vector2Int();

            while (!isChosenValidCell)
            {
                chosenCellPosition = new Vector2Int(_random.Next(0, Consts.BOARD_WIDTH), _random.Next(0, Consts.BOARD_HEIGHT));
                isChosenValidCell = GameBoard.IsCellEmpty(chosenCellPosition);
            }

            OnChooseMove?.Invoke(chosenCellPosition, Symbol);
        }

        private void StopCoroutines()
        {
            StopAllCoroutines();
        }

        void OnDisable()
        {
            GameEvents.Instance.onGameStart -= StopCoroutines;
        }
    }
}

