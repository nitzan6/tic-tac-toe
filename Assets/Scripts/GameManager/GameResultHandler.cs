using TicTacToe.GameManagement.Players;
using TicTacToe.UI;
using UnityEngine;

namespace TicTacToe.GameManagement
{
    public class GameResultHandler : MonoBehaviour
    {
        [SerializeField]
        private EndGameMessageDisplayer _gameEndMessage;

        public void HandleWin(IPlayer winner)
        {
            _gameEndMessage.DisplayWinner(winner.Name);
        }

        public void HandleDraw()
        {

        }
    }
}
