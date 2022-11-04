using UnityEngine;

namespace TicTacToe.GameSetup
{
    //Here we apply all of the settings in the GameSettings scriptable object
    //There is a different class to handle each of the parameters in GameSettings
    public class GameSetup : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;

        private GamemodeSettingsHandler _gamemodeSettingsHandler;
        private TimeSettingsHandler _timeHandler;
        private AIDelaySettingsHandler _aiDelaySetter;
        
        void Awake()
        {
            _gamemodeSettingsHandler = GetComponent<GamemodeSettingsHandler>();
            _timeHandler = GetComponent<TimeSettingsHandler>();
            _aiDelaySetter = GetComponent<AIDelaySettingsHandler>();

            ApplySettings();
        }

        private void ApplySettings()
        {
            ApplyGamemodeSettings();
            ApplyTimeSettings();
            ApplyDelayToAIComponents();
        }

        private void ApplyGamemodeSettings()
        {
            _gamemodeSettingsHandler.ApplySelectedGamemode(_gameSettings.Gamemode);
        }

        private void ApplyTimeSettings()
        {
            _timeHandler.ApplyTimeSettings(_gameSettings.MaxTimePerTurn);
        }

        private void ApplyDelayToAIComponents()
        {
            _aiDelaySetter.ApplyDelay(_gameSettings.AIDelayTime);
        }
    }
}
