using TicTacToe.GameManagement.Players;
using TicTacToe.UI;
using UnityEngine;

namespace TicTacToe.GameManagement
{
    public class GameResultUIController : MonoBehaviour
    {
        [SerializeField]
        private EndGameMessageDisplayer _gameEndMessage;

        void OnEnable()
        {
            GameEvents.Instance.onGameStart += DisableMessageDisplayer;
        }

        private void DisableMessageDisplayer()
        {
            _gameEndMessage.gameObject.SetActive(false);
        }

        public void HandleWin(IPlayer winner)
        {
            _gameEndMessage.DisplayWinner(winner.Name);
        }

        public void HandleDraw()
        {
            _gameEndMessage.DisplayDraw();
        }

        void OnDisable()
        {
            GameEvents.Instance.onGameStart += DisableMessageDisplayer;
        }
    }
}
