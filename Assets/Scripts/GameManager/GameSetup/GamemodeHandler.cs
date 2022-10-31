using System;
using TicTacToe.GameManagement.Gamemodes;
using TicTacToe.GameManagment.Setup;
using UnityEngine;

namespace TicTacToe.GameManagement.Setup
{
    public class GamemodeHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player1;
        [SerializeField]
        private GameObject _player2;
        [SerializeField]
        private UndoManager _undoManager;

        private Gamemode _gamemode;

        public void ApplySelectedGamemode(Gamemode currentGamemode)
        {
            _gamemode = currentGamemode;

            ApplyToPlayers();
            _undoManager.ApplyUndoSettings(currentGamemode);
        }

        private void ApplyToPlayers()
        {
            // Get the types of the players
            Type[] playerTypes = PlayerFactory.GetPlayerTypesFromGamemode(_gamemode);

            //Add the components of the specified types to player1 and player2
            _player1.AddComponent(playerTypes[0]);
            _player2.AddComponent(playerTypes[1]);
        }
    }
}

