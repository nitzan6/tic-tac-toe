using System.Collections.Generic;
using TicTacToe.GameManagement.Players;
using UnityEngine;

namespace TicTacToe.GameSetup
{
    public class GamemodeSettingsHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player1GameObject;
        [SerializeField]
        private GameObject _player2GameObject;
        [SerializeField]
        private UndoManager _undoManager;

        public void ApplySelectedGamemode(Gamemode currentGamemode)
        {
            ApplyGamemodeSettingsToPlayers(currentGamemode);
            _undoManager.ApplyUndoSettings(currentGamemode);
        }

        // Add player components to player gameobjects by the specified types
        private void ApplyGamemodeSettingsToPlayers(Gamemode currentGamemode)
        {
            _player1GameObject.AddComponent(currentGamemode.Player1Type);
            _player2GameObject.AddComponent(currentGamemode.Player2Type);
        }
    }
}

