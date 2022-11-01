using System.Collections.Generic;
using TicTacToe.GameManagement.Players;
using UnityEngine;

namespace TicTacToe.GameSetup
{
    public class GamemodeSetter : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;

        private List<Gamemode> _gamemodes;

        void Start()
        {
            InitGamemodes();
        }

        private void InitGamemodes()
        {
            _gamemodes = new List<Gamemode>()
        {
          new Gamemode(typeof(LocalPlayer), typeof(LocalPlayer)),
          new Gamemode(typeof(LocalPlayer), typeof(AI)),
          new Gamemode(typeof(AI), typeof(AI))
        };
        }

        public void ChangeGamemode()
        {

        }
    }

}
