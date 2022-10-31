using System;
using UnityEngine;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameProgression
{
    public class GameProgressionManager : MonoBehaviour
    {
        private GameBoardManager _gameBoardManager;
        private TurnHandler _turnHandler;
        private IPlayer _player1;
        private IPlayer _player2;
        private enGameState _gameState;
        private UndoManager _undoManager;

        public event Action<enGameState> OnGameEnded;

        void Start()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            _gameBoardManager = GetComponent<GameBoardManager>();
            _turnHandler = GetComponent<TurnHandler>();
            _undoManager = FindObjectOfType<UndoManager>();

            SubscribeToTurnHandlerEvents();
        }

        public void InitPlayers(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;

            SubscribeToPlayerEvents();
        }

        private void SubscribeToPlayerEvents()
        {
            _player1.OnChooseMove += HandleMove;
            _player2.OnChooseMove += HandleMove;
        }

        private void SubscribeToTurnHandlerEvents()
        {
            _turnHandler.OnTurnEndedWithoutPlay += HandlePlayerOutOfTime;
        }

        public void StartGame()
        {
            _gameBoardManager.ResetBoard();

            AssignRolesForPlayers();
            SetBoardForPlayers();
            InitTurnHandler();

            _turnHandler.StartFirstTurn();
        }

        private void SetBoardForPlayers()
        {
            //Give each of the players a reference of the board.
            _player1.GameBoard = _gameBoardManager.Board;
            _player2.GameBoard = _gameBoardManager.Board;
        }

        private void InitTurnHandler()
        {
            if (_player1.Symbol == enSymbol.X)
            {
                _turnHandler.SetPlayers(_player1, _player2);
            }
            else
            {
                _turnHandler.SetPlayers(_player2, _player1);
            }
        }

        private void HandleMove(Vector2Int position, enSymbol symbol)
        {
            if (symbol != _turnHandler.CurrentTurnSymbol)
            {
                return;
            }

            if (!_gameBoardManager.IsMoveValid(position))
            {
                return;
            }

            _gameBoardManager.MakeMove(position, symbol);

            if (GetIsGameEnded())
            {
                HandleGameEnd(_gameState);
            }
            else
            {
                _turnHandler.ChangeTurns();
            }
        }

        public void UndoLastMove()
        {
            if (!_undoManager.CanUndo || _turnHandler.CheckForNoTurnsMade())
            {
                return;
            }
            
            _gameBoardManager.UndoLastMove();
            _turnHandler.RevertToLastRound();
        }

        private bool GetIsGameEnded()
        {
            _gameState = _gameBoardManager.GetGameState();

            if (_gameState != enGameState.PLAYING)
            {
                return true;
            }

            return false;
        }

        private void HandlePlayerOutOfTime(enSymbol currentTurnSymbol)
        {
            //if the player is out of time, the other wins.
            _gameState = currentTurnSymbol == enSymbol.X ? enGameState.O_WIN : enGameState.X_WIN;
            HandleGameEnd(_gameState);
        }

        private void HandleGameEnd(enGameState gameState)
        {
            _turnHandler.EndTurnCycle();
            OnGameEnded?.Invoke(gameState);
        }

        private void AssignRolesForPlayers()
        {
            System.Random random = new System.Random();

            //Generate a random number between 1 and 2
            int playerNumberForXSymbol = random.Next(1, 3);
            
            if (playerNumberForXSymbol == 1)
            {
                _player1.Symbol = enSymbol.X;
                _player2.Symbol = enSymbol.O;
            }
            else
            {
                _player1.Symbol = enSymbol.O;
                _player2.Symbol = enSymbol.X;
            }
        }

        void OnDisable()
        {
            _player1.OnChooseMove -= HandleMove;
            _player2.OnChooseMove -= HandleMove;

            _turnHandler.OnTurnEndedWithoutPlay -= HandlePlayerOutOfTime;
        }
    }
}

