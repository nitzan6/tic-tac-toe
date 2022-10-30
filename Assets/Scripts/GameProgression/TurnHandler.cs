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

        public event Action OnTurnEndedWithoutPlay;
        public bool IsXTurn { get; private set; }

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

            SubscribeToPlayersEvents();
            StartFirstTurn();
        }

        public void StartFirstTurn()
        {
            IsXTurn = true; // X starts first
            _timer.StartTimer();
            NotifyPlayers();
        }
        
        private void HandleTimerFinished()
        {
            OnTurnEndedWithoutPlay?.Invoke();
        }

        private void NotifyPlayers()
        {
            if (IsXTurn)
            {
                _playerX.TurnStarts();
            }
            else
            {
                _playerO.TurnStarts();
            }
        }

        private void SubscribeToPlayersEvents()
        {
            _playerX.OnChooseMove += HandleMove;
            _playerO.OnChooseMove += HandleMove;
        }

        public void ChangeTurn()
        {
            IsXTurn = !IsXTurn;
        }

        private void HandleMove(Vector2Int position, Symbol symbol)
        {
            ChangeTurn();
        }

        void OnDisable()
        {
            _playerX.OnChooseMove -= HandleMove;
            _playerO.OnChooseMove -= HandleMove;

            _timer.OnTimerFinished -= HandleTimerFinished;
        }
    }
}

