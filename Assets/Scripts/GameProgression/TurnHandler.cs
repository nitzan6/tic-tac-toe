using System;
using TicTacToe.GameManagement.Players;
using TicTacToe.Utils;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class TurnHandler : MonoBehaviour
    {
        private IPlayer _playerX;
        private IPlayer _playerO;
        private Timer _timer;
        private enSymbol CurrentTurnSymbol;
        private int _turnCount = 0;

        public event Action<enSymbol> OnTurnEndedWithoutPlay;

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
            CurrentTurnSymbol = enSymbol.X; // X starts first
            _timer.StartTimer();
            NotifyPlayers();
        }

        public void ChangeTurns()
        {
            _turnCount++;
            CurrentTurnSymbol = CurrentTurnSymbol == enSymbol.X ? enSymbol.O : enSymbol.X;
            _timer.ResetTimer();
            NotifyPlayers();
        }

        public bool IsCurrentPlayingSymbol(enSymbol symbol)
        {
            return symbol == CurrentTurnSymbol;
        }

        public bool CheckForNoTurnsMade()
        {
            return _turnCount == 0;
        }

        public bool IsFirstRound()
        {
            return _turnCount < 2;
        }

        //In this context a round is 2 turns
        public void RevertToLastRound()
        {
            _turnCount -= 2;
            ResetTurn();
        }

        public void EndTurnCycle()
        {
            _timer.StopTimer();
        }

        private void ResetTurn()
        {
            _timer.ResetTimer();
        }

        private void HandleTimerFinished()
        {
            OnTurnEndedWithoutPlay?.Invoke(CurrentTurnSymbol);
        }

        //notify players of current turn information, so the players know 
        //if it's their turn or not
        private void NotifyPlayers()
        {
            _playerX.ReceiveCurrentTurnInfo(CurrentTurnSymbol);
            _playerO.ReceiveCurrentTurnInfo(CurrentTurnSymbol);
        }

        void OnDisable()
        {
            _timer.OnTimerFinished -= HandleTimerFinished;
        }
    }
}

