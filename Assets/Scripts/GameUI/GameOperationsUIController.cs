using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.UI
{
    //This component controlls the undo and reset buttons
    public class GameOperationsUIController : MonoBehaviour
    {
        [SerializeField]
        private Button _undoButton;
        [SerializeField]
        private Button _restartButton;

        void OnEnable()
        {
            GameEvents.Instance.onGameStart += EnableOperationButtonsInteractability;
            GameEvents.Instance.onGameEnded += DisableOperationButtonsInteractability;
        }

        private void EnableOperationButtonsInteractability()
        {
            ToggleButtonsInteractability(isInteractable: true);
        }

        private void DisableOperationButtonsInteractability(enGameState _)
        {
            ToggleButtonsInteractability(isInteractable: false);
        }

        //toggle visibility of undo button
        public void ToggleUndoButtonVisibility(bool isActive)
        {
            _undoButton.gameObject.SetActive(isActive);
        }

        //toggle interaction with both buttons
        private void ToggleButtonsInteractability(bool isInteractable)
        {
            _undoButton.interactable = isInteractable;
            _restartButton.interactable = isInteractable;
        }

        void OnDisable()
        {
            GameEvents.Instance.onGameStart -= EnableOperationButtonsInteractability;
            GameEvents.Instance.onGameEnded -= DisableOperationButtonsInteractability;
        }
    }

}
