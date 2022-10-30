using System;
using System.Collections;
using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class AI : MonoBehaviour, IPlayer
    {
        // a few second delay for the AI to wait before
        // choosing a move, to give the game a more realistic feel
        private float _delayInSeconds = 2f;
        private System.Random _random;

        public Symbol Symbol { get; set; }
        public Board GameBoard { get; set; }

        public event Action<Vector2Int, Symbol> OnChooseMove;

        void Start()
        {
            _random = new System.Random();
        }

        void OnEnable()
        {
            // This is done to prevent a situation where the coroutine for determining a move is
            // Still active after we finished the game
            GameEvents.Instance.onGameEnded += StopCoroutines;
        }

        public void ReceiveTurnInformation(Symbol currentTurnSymbol)
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

            Vector2Int chosenCellPosition = new Vector2Int(_random.Next(0, 3), _random.Next(0, 3));
            OnChooseMove?.Invoke(chosenCellPosition, Symbol);
        }

        void OnDisable()
        {
            GameEvents.Instance.onGameEnded -= StopCoroutines;
        }

        private void StopCoroutines()
        {
            StopAllCoroutines();
        }
    }
}

