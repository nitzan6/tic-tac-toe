using TicTacToe.Utils;
using UnityEngine;


namespace TicTacToe.GameSetup
{
    public class TimeSettingsHandler : MonoBehaviour
    {
        [SerializeField]
        private Timer _timer;

        public void ApplyTimeSettings(float time)
        {
            _timer.TimeLimit = time;
        }
    }
}

