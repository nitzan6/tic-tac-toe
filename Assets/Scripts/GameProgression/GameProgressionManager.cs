using UnityEngine;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagement
{
    public class GameProgressionManager : MonoBehaviour
    {
        private IPlayer Player1;
        private IPlayer Player2;

        public void HandleGameStart()
        {
            Debug.Log("Game started");
        }
    }
}

