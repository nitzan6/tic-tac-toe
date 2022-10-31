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
        private GameState _gameState;

        public event Action<GameState> OnGameEnded;

        void Start()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            _gameBoardManager = GetComponent<GameBoardManager>();
            _turnHandler = GetComponent<TurnHandler>();

            _player1 = GameObject.Find(Consts.PLAYER_1_NAME).GetComponent<IPlayer>();
            _player2 = GameObject.Find(Consts.PLAYER_2_NAME).GetComponent<IPlayer>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _player1.OnChooseMove += HandleMove;
            _player2.OnChooseMove += HandleMove;

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
            if (_player1.Symbol == Symbol.X)
            {
                _turnHandler.SetPlayers(_player1, _player2);
            }
            else
            {
                _turnHandler.SetPlayers(_player2, _player1);
            }
        }

        private void HandleMove(Vector2Int position, Symbol symbol)
        {
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

        private bool GetIsGameEnded()
        {
            _gameState = _gameBoardManager.GetGameState();

            if (_gameState != GameState.PLAYING)
            {
                return true;
            }

            return false;
        }

        private void HandlePlayerOutOfTime(Symbol currentTurnSymbol)
        {
            //if the player is out of time, the other wins.
            _gameState = currentTurnSymbol == Symbol.X ? GameState.O_WIN : GameState.X_WIN;
            HandleGameEnd(_gameState);
        }

        private void HandleGameEnd(GameState gameState)
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
                _player1.Symbol = Symbol.X;
                _player2.Symbol = Symbol.O;
                
            }
            else
            {
                _player1.Symbol = Symbol.O;
                _player2.Symbol = Symbol.X;
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

