using UnityEngine;
using TicTacToe.GameManagement.Players;
using TicTacToe.UI;

namespace TicTacToe.GameSetup
{
    public class UndoManager : MonoBehaviour
    {
        [SerializeField]
        private GameOperationsUIController _gameOperationsController;
        public bool CanUndo { get; private set; }

        public void ApplyUndoSettings(Gamemode gamemode)
        {
            //Undo will only be enabled if the game mode is Local player VS Computer
            CanUndo = IsOnlyOneOfPlayersComputer(gamemode);
            _gameOperationsController.ToggleUndoButtonVisibility(CanUndo);
        }

        //Check if exactly one of the players is the computer
        private bool IsOnlyOneOfPlayersComputer(Gamemode gamemode)
        {
            return gamemode.Player1Type == typeof(AI) ^ gamemode.Player2Type == typeof(AI);
        }
    }

}
