using TicTacToe.GameManagement;
using UnityEngine;

namespace TicTacToe.GameManagment
{
    public class GameManager : MonoBehaviour
    {
        private GameProgressionManager _gameProgressionHandler;

        void Awake()
        {
            _gameProgressionHandler = GetComponentInChildren<GameProgressionManager>();
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

