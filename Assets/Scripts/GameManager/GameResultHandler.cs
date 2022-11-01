using TicTacToe.GameManagement.Players;
using TicTacToe.UI;
using UnityEngine;

namespace TicTacToe.GameManagement
{
    public class GameResultHandler : MonoBehaviour
    {
        [SerializeField]
        private EndGameMessageDisplayer _gameEndMessageDisplayer;

        void OnEnable()
        {
            GameEvents.Instance.onGameStart += DisableMessageDisplayer;
        }

        private void DisableMessageDisplayer()
        {
            _gameEndMessageDisplayer.ResetDisplay();
        }

        public void HandleWin(IPlayer winner)
        {
            _gameEndMessageDisplayer.DisplayWinner(winner.Name);
        }

        public void HandleDraw()
        {
            _gameEndMessageDisplayer.DisplayDraw();
        }

        void OnDisable()
        {
            GameEvents.Instance.onGameStart += DisableMessageDisplayer;
        }
    }
}
