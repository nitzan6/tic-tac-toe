using System;
using TicTacToe.GameManagement.Players;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class TurnHandler : MonoBehaviour
    {
        private IPlayer _playerX;
        private IPlayer _playerO;
        private Timer _timer;
        private Symbol _currentTurnSymbol;
        private int _turnCount = 0;

        public event Action<Symbol> OnTurnEndedWithoutPlay;

        void Awake()
        {
            _timer = GetComponentInChildren<Timer>();
        }

        void OnEnable()
        {
            _timer.OnTimerFinished += HandleTimerFinished;
        }

        //Get the players and assign them to their corresponding symbol
        public void SetPlayers(IPlayer playerX, IPlayer playerO)
        {
            _playerX = playerX;
            _playerO = playerO;
        }

        //Start the turns cycle
        public void StartFirstTurn()
        {
            _currentTurnSymbol = Symbol.X; // X starts first
            _timer.StartTimer();
            NotifyPlayers();
        }

        public void ChangeTurns()
        {
            _turnCount++;
            _currentTurnSymbol = _currentTurnSymbol == Symbol.X ? Symbol.O : Symbol.X;
            _timer.ResetTimer();
            NotifyPlayers();
        }

        //In this context a round is 2 turns
        public void RevertToLastRound()
        {
            if (_turnCount < 2)
            {
                StartFirstTurn();
                _turnCount = 0;
                return;
            }

            _turnCount -= 2;
            ResetTurn();
        }

        public void EndTurnCycle()
        {
            _timer.StopTimer();
        }

        public void ResetTurn()
        {
            _timer.ResetTimer();
        }

        private void HandleTimerFinished()
        {
            OnTurnEndedWithoutPlay?.Invoke(_currentTurnSymbol);
        }

        //notify players of current turn information, so the players know 
        //if it's their turn or not
        private void NotifyPlayers()
        {
            _playerX.ReceiveCurrentTurnInfo(_currentTurnSymbol);
            _playerO.ReceiveCurrentTurnInfo(_currentTurnSymbol);
        }

        void OnDisable()
        {
            _timer.OnTimerFinished -= HandleTimerFinished;
        }
    }
}

