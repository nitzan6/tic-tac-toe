using TicTacToe.GameManagement.Players;
using UnityEngine;

namespace TicTacToe.GameSetup
{
    public class UndoManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _undoButton;
        public bool CanUndo { get; private set; }

        void OnEnable()
        {
            GameEvents.Instance.onGameStart += EnableUndoAbility;
            GameEvents.Instance.onGameEnded += DisableUndoAbility;
        }
        private void EnableUndoAbility()
        {
            CanUndo = true;
        }

        private void DisableUndoAbility(enGameState _)
        {
            CanUndo = false;
        }

        public void ApplyUndoSettings(Gamemode gamemode)
        {
            CanUndo = IsOnlyOneOfPlayersComputer(gamemode);
            _undoButton.SetActive(CanUndo);
        }

        //Check if exactly one of the players is the computer
        private bool IsOnlyOneOfPlayersComputer(Gamemode gamemode)
        {
            return gamemode.Player1Type == typeof(AI) ^ gamemode.Player2Type == typeof(AI);
        }

        private void OnDisable()
        {
            GameEvents.Instance.onGameStart -= EnableUndoAbility;
            GameEvents.Instance.onGameEnded -= DisableUndoAbility;
        }
    }

}
