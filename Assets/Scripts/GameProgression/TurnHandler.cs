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
        private bool _isXTurn;

        public event Action<Symbol> OnTurnEndedWithoutPlay;

        void Awake()
        {
            _timer = GetComponentInChildren<Timer>();
        }

        void OnEnable()
        {
            _timer.OnTimerFinished += HandleTimerFinished;
        }

        public void SetPlayers(IPlayer playerX, IPlayer playerO)
        {
            _playerX = playerX;
            _playerO = playerO;

            StartFirstTurn();
        }

        public void StartFirstTurn()
        {
            _isXTurn = true; // X starts first
            _timer.StartTimer();
            NotifyPlayers();
        }

        public void ChangeTurns()
        {
            _isXTurn = !_isXTurn;
            _timer.ResetTimer();
            NotifyPlayers();
        }

        private void HandleTimerFinished()
        {
            OnTurnEndedWithoutPlay?.Invoke(_isXTurn ? Symbol.X : Symbol.O);
        }

        private void NotifyPlayers()
        {
            Symbol currentPlayingSymbol = _isXTurn ? Symbol.X : Symbol.O;

            _playerX.ReceiveTurnInformation(currentPlayingSymbol);
            _playerX.ReceiveTurnInformation(currentPlayingSymbol);
        }

        void OnDisable()
        {
            _timer.OnTimerFinished -= HandleTimerFinished;
        }
    }
}

