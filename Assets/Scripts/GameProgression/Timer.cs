using System;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class Timer : MonoBehaviour
    {
        [HideInInspector]
        public float MaxTimePerTurn;

        private bool _isTimerActive = false;
        private float _countedTime = 0;
        public event Action OnTimerFinished;

        public void StartTimer()
        {
            _isTimerActive = true;
        }

        public void RestartTimer()
        {
            _countedTime = 0;
        }

        void Update()
        {
            CountTime();
        }

        private void CountTime()
        {
            if (_isTimerActive)
            {
                _countedTime += Time.deltaTime;

                if (_countedTime >= MaxTimePerTurn)
                {
                    RestartTimer();
                    _isTimerActive = false;

                    OnTimerFinished?.Invoke();
                }
            }
        }
    }

}
