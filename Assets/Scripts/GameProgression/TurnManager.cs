using TicTacToe.GameManagement.Players;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class TurnManager : MonoBehaviour
    {
        private GameBoardManager _gameBoardManager;
        private IPlayer Player1;
        private IPlayer Player2;

        private bool _isXTurn;

        void Awake()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            _gameBoardManager = GetComponent<GameBoardManager>();
        }

        private void PrepareTurnData()
        {
            SubscribeToPlayersEvents();
            StartFirstTurn();
            
        }

        private void StartFirstTurn()
        {
            _isXTurn = true;
        }

        private void SubscribeToPlayersEvents()
        {
            Player1.OnChooseCell += HandleMove;
            Player2.OnChooseCell += HandleMove;
        }

        private void HandleMove(object sender, PlayerInputEventArgs args)
        {
            IPlayer player = (IPlayer)sender;

            //Checking if the player who sent the move event is the one whose turn it is
            if (player.Role == Symbol.X && _isXTurn || player.Role == Symbol.O && !_isXTurn)
            {

            }
        }

        void OnDisable()
        {
            Player1.OnChooseCell -= HandleMove;
            Player2.OnChooseCell -= HandleMove;
        }
    }
}

