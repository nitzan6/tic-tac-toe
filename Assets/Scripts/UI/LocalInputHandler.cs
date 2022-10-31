using TicTacToe.GameManagement;
using TicTacToe.GameManagement.Players;
using UnityEngine;

namespace TicTacToe.UI
{
    public class LocalInputHandler : MonoBehaviour
    {
        private LocalPlayer[] _localPlayers;
        private bool _isRegisteringInput = false;

        void OnEnable()
        {
            GameEvents.Instance.onGameStart += EnableInput;
            GameEvents.Instance.onGameEnded += DisableInput;
        }

        void Start()
        {
            _localPlayers = FindObjectsOfType<LocalPlayer>();
        }

        private void EnableInput()
        {
            _isRegisteringInput = true;
        }

        private void DisableInput(enGameState _)
        {
            _isRegisteringInput = false;
        }

        public void OnCellClicked(Vector2Int cellPosition)
        {
            if (!_isRegisteringInput)
            {
                return;
            }

            foreach (LocalPlayer localPlayer in _localPlayers)
            {
                if (localPlayer.IsCanPlay)
                {
                    localPlayer.HandlePlayerInput(cellPosition);
                    break;     // if the first local player can play there's no need
                               // to check for the second player since only one can play at a time
                }
            }
        }

        void OnDisable()
        {
            GameEvents.Instance.onGameStart -= EnableInput;
            GameEvents.Instance.onGameEnded -= DisableInput;
        }
    }
}
