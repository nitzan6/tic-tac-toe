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

        }

        void OnEnable()
        {
            _player1.OnChooseMove += HandleMove;
            _player2.OnChooseMove += HandleMove;

            _turnHandler.OnTurnEndedWithoutPlay += DeclareWinner;
        }

        private void HandleMove(Vector2Int position, Symbol symbol)
        {
            if (!_gameBoardManager.IsMoveValid(position))
            {
                return;
            }

            _gameBoardManager.MakeMove(position, symbol);
            _turnHandler.ChangeTurn();
        }

        private void DeclareWinner()
        {

        }

        public void HandleGameStart()
        {
            AssignRoles();
            _turnHandler.StartFirstTurn();



            /*
            if (_player1.Symbol == Symbol.X)
            {
                _turnHandler.SetPlayers(_player1, _player2);
            }
            else
            {
                _turnHandler.SetPlayers(_player2, _player1);
            }
            */
        }

        private void AssignRoles()
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
        }
    }
}

