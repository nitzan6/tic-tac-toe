using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.GameSetup 
{
    //This class updates the slider values with the latest values kept in the GameSettings scriptable object
    public class SliderValueUpdater : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;
        [SerializeField]
        private Slider _maxTimePerTurnSlider;
        [SerializeField]
        private Slider _aiDelayTimeSlider;

        void Start()
        {
            UpdateSliderValues();
        }

        private void UpdateSliderValues()
        {
            _maxTimePerTurnSlider.value = _gameSettings.MaxTimePerTurn;
            _aiDelayTimeSlider.value = _gameSettings.AIDelayTime;
        }
    }

}
