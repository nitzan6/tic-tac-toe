using TicTacToe.GameProgression;
using UnityEngine;


namespace TicTacToe.GameManagement.Setup
{
    public class TimeSettingsHandler : MonoBehaviour
    {
        [SerializeField]
        private Timer _timer;

        public void ApplyTimeSettings(float time)
        {
            _timer.MaxTimePerTurn = time;
        }
    }
}

