using System;
using UnityEngine;
using TicTacToe.GameManagement.Players;
using TicTacToe.GameSetup;

namespace TicTacToe.GameProgression
{
    public class GameProgressionManager : MonoBehaviour
    {
        private GameBoardManager _gameBoardManager;
        private TurnHandler _turnHandler;
        private RoleAssigner _roleAssigner;
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
            _roleAssigner = new RoleAssigner();

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

        //Initialize all of the game components before starting the first turn
        public void StartGame()
        {
            _gameBoardManager.ResetBoard();

            _roleAssigner.AssignRolesForPlayers(_player1, _player2);
            SetBoardForPlayers();
            InitTurnHandler();

            _turnHandler.StartFirstTurn();
        }

        //Give each of the players a reference of the board.
        private void SetBoardForPlayers()
        {
            _player1.GameBoard = _gameBoardManager.Board;
            _player2.GameBoard = _gameBoardManager.Board;
        }

        //The turn handler shouldn't care about which is player 1 and which is player 2
        //It only cares about their respective symbol
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
            if (!_turnHandler.IsCurrentPlayingSymbol(symbol) || !_gameBoardManager.IsMoveValid(position))
            {
                return;
            }

            _gameBoardManager.MakeMove(position, symbol);

            if (GetIsGameEnd()) // Did the game end after a move was made?
            {
                HandleGameEnd(_gameState);
                return;
            }
            
            _turnHandler.ChangeTurns();
        }

        //Check if we can undo by asking undoManager
        public void UndoLastMove()
        {
            if (!_undoManager.CanUndo || _turnHandler.CheckForNoTurnsMade())
            {
                return;
            }
            
            if (!_turnHandler.IsFirstRound())
            {
                _gameBoardManager.UndoLastMove();
                _turnHandler.RevertToLastRound();
            }
        }

        //If the GameState is anything other than PLAYING, the game has ended
        private bool GetIsGameEnd()
        {
            _gameState = _gameBoardManager.GetGameState();

            if (_gameState != enGameState.PLAYING)
            {
                return true;
            }

            return false;
        }

        //if the player is out of time, the other player wins.
        private void HandlePlayerOutOfTime(enSymbol currentTurnSymbol)
        {
            _gameState = currentTurnSymbol == enSymbol.X ? enGameState.O_WIN : enGameState.X_WIN;
            HandleGameEnd(_gameState);
        }

        private void HandleGameEnd(enGameState gameState)
        {
            _turnHandler.EndTurnCycle();
            OnGameEnded?.Invoke(gameState); // Invoke OnGameEnded event
        }

        public IPlayer GetPlayerBySymbol(enSymbol symbol)
        {
            if (symbol == enSymbol.EMPTY)
            {
                throw new Exception("Cannot get player with symbol of Empty!");
            }

            if (_player1.Symbol == symbol)
            {
                return _player1;
            }
            else
            {
                return _player2;
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

