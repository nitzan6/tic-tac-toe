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
        private BoardState _boardState;

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

            _turnHandler.OnTurnEndedWithoutPlay += DeclareWinner;
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

            BoardState currentBoardState = _gameBoardManager.CheckBoardState();
            if (currentBoardState != BoardState.PLAYING)
            {
                HandleGameEnd(currentBoardState);
            }
            else
            {
                _turnHandler.ChangeTurns();
            }
        }

        private void HandleGameEnd(BoardState boardState) 
        {
            switch (boardState)
            {
                case BoardState.X_WIN:
                    DeclareWinner(Symbol.X);
                    break;
                case BoardState.O_WIN:
                    DeclareWinner(Symbol.O);
                    break;
                case BoardState.DRAW:
                    DeclareDraw();
                    break;
                default:
                    break;
            }
        }

        private void DeclareDraw()
        {
            Debug.Log("DRAW");
        }

        private void DeclareWinner(Symbol winner)
        {
            Debug.Log("The winner is " + winner);
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

            _turnHandler.OnTurnEndedWithoutPlay -= DeclareWinner;
        }
    }
}

