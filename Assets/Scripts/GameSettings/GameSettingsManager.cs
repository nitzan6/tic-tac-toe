using System.Collections.Generic;
using TicTacToe.GameManagement.Players;
using TicTacToe.GameSetup;
using UnityEngine;

namespace TicTacToe.GameSetup
{
    public class GameSettingsManager : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;

        private Dictionary<string, Gamemode> _gamemodes = new Dictionary<string, Gamemode>()
    {
        { Consts.LOCAL_MULTIPLAYER, new Gamemode(typeof(LocalPlayer), typeof(LocalPlayer)) },
        { Consts.LOCAL_VS_AI, new Gamemode(typeof(LocalPlayer), typeof(AI)) },
        { Consts.AI_VS_AI, new Gamemode(typeof(AI), typeof(AI)) }
    };

        public void SetLocalVsLocalGamemode()
        {
            _gameSettings.Gamemode = _gamemodes[Consts.LOCAL_MULTIPLAYER];
        }

        public void SetLocalVsAIGamemode()
        {
            _gameSettings.Gamemode = _gamemodes[Consts.LOCAL_VS_AI];
        }

        public void SetAIVsAIGamemode()
        {
            _gameSettings.Gamemode = _gamemodes[Consts.AI_VS_AI];
        }

        public void SetMaxTimePerTurn(float value)
        {
            _gameSettings.MaxTimePerTurn = value;
        }

        public void SetAIDelayTime(float value)
        {
            _gameSettings.AIDelayTime = value;
        }
    }
}