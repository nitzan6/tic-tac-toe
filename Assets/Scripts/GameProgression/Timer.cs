using System;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class Timer : MonoBehaviour
    {
        [HideInInspector]
        public float MaxTimePerTurn;

        private bool _isTimerActive = false;
        private float _countedTime;
        public event Action OnTimerFinished;

        public void StartTimer()
        {
            _countedTime = 0;
            _isTimerActive = true;
        }

        public void StopTimer()
        {
            _isTimerActive = false;
        }

        public void ResetTimer()
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
                    ResetTimer();
                    _isTimerActive = false;

                    OnTimerFinished?.Invoke();
                }
            }
        }
    }

}
