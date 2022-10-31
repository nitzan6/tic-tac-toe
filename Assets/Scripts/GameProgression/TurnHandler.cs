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
        }

        public void StartFirstTurn()
        {
            _isXTurn = true; // X starts first
            _timer.StartTimer();
            NotifyPlayersOfCurrentTurn();
        }

        public void ChangeTurns()
        {
            _isXTurn = !_isXTurn;
            _timer.ResetTimer();
            NotifyPlayersOfCurrentTurn();
        }

        public void EndTurnCycle()
        {
            _timer.StopTimer();
        }

        private void HandleTimerFinished()
        {
            OnTurnEndedWithoutPlay?.Invoke(_isXTurn ? Symbol.X : Symbol.O);
        }

        private void NotifyPlayersOfCurrentTurn()
        {
            Symbol currentPlayingSymbol = _isXTurn ? Symbol.X : Symbol.O;

            _playerX.ReceiveCurrentTurnInfo(currentPlayingSymbol);
            _playerO.ReceiveCurrentTurnInfo(currentPlayingSymbol);
        }

        void OnDisable()
        {
            _timer.OnTimerFinished -= HandleTimerFinished;
        }
    }
}

