using System;
using UnityEngine;
using TicTacToe.GameManagment;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagement
{
    public class GameSetupHandler : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;
        [SerializeField]
        private GameObject _player1;
        [SerializeField]
        private GameObject _player2;
        
        void Awake()
        {
            ApplyGameSettings();
        }

        private void ApplyGameSettings()
        {
            ApplySelectedGamemode();
        }

        
        private void ApplySelectedGamemode()
        {
            // Get the types of the players
            Type[] playerTypes = GamemodeFactory.GetPlayersFromGamemode(_gameSettings.Gamemode);

            _player1.AddComponent(playerTypes[0]);
            _player2.AddComponent(playerTypes[1]);
        }
    }
}
