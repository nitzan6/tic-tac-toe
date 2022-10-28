using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagment
{
    public class GameManager : MonoBehaviour
    {
        private GameProgressionHandler _gameProgressionHandler;

        void Awake()
        {
            _gameProgressionHandler = GetComponentInChildren<GameProgressionHandler>();
        }

        void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            _gameProgressionHandler.HandleGameStart();
        }

        private void RestartGame()
        {

        }
    }
}

