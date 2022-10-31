using UnityEngine;
using TicTacToe.GameManagment;

namespace TicTacToe.GameManagement.Setup
{
    public class GameSetup : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;

        private GamemodeHandler _gamemodeHandler;
        private TimeSettingsHandler _timeHandler;
        
        void Awake()
        {
            _gamemodeHandler = GetComponent<GamemodeHandler>();
            _timeHandler = GetComponent<TimeSettingsHandler>();
            ApplySettings();
        }

        private void ApplySettings()
        {
            ApplyGamemodeSettings();
            ApplyTimeSettings();
        }

        private void ApplyGamemodeSettings()
        {
            _gamemodeHandler.ApplySelectedGamemode(_gameSettings.Gamemode);
        }

        private void ApplyTimeSettings()
        {
            _timeHandler.ApplyTimeSettings(_gameSettings.MaxTimePerTurn);
        }
    }
}
