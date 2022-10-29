using UnityEngine;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagement
{
    public class GameProgressionManager : MonoBehaviour
    {
        [SerializeField]
        private IPlayer Player1;
        [SerializeField]
        private IPlayer Player2;

        public void HandleGameStart()
        {
            Debug.Log("Game started");
        }
    }
}

