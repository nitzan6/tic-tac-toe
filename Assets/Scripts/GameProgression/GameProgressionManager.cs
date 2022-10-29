using UnityEngine;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameProgression
{
    public class GameProgressionManager : MonoBehaviour
    {
        private TurnManager _turnHandler;
        private IPlayer _player1;
        private IPlayer _player2;

        void Start()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            _turnHandler = GetComponent<TurnManager>();

            _player1 = GameObject.Find(Consts.PLAYER_1_NAME).GetComponent<IPlayer>();
            _player2 = GameObject.Find(Consts.PLAYER_2_NAME).GetComponent<IPlayer>();
        }


        public void HandleGameStart()
        {
            
        }
    }
}

