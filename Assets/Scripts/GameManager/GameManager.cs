using System.Collections;
using TicTacToe.GameManagement;
using TicTacToe.GameProgression;
using UnityEngine;

namespace TicTacToe.GameManagment
{
    public class GameManager : MonoBehaviour
    {
        private GameProgressionManager _gameProgressionManager;

        void Awake()
        {
            _gameProgressionManager = GetComponentInChildren<GameProgressionManager>();
            _gameProgressionManager.OnGameEnded += HandleGameEnd;
        }

        IEnumerator Start()
        {
            yield return null;
            StartGame();
        }

        public void StartGame()
        {
            GameEvents.Instance.GameStart();
            _gameProgressionManager.StartGame();
        }

        private void HandleGameEnd(GameState gameResult)
        {
            GameEvents.Instance.GameEnded(gameResult);

            switch (gameResult)
            {
                case GameState.X_WIN:
                    Debug.Log("X WIN");
                    break;
                case GameState.O_WIN:
                    Debug.Log("O WIN");
                    break;
                case GameState.DRAW:
                    Debug.Log("DRAW");
                    break;
                default:
                    throw new System.Exception($"[GameManager] - Unhandled {gameResult.GetType()} {gameResult}");
            }
        }

        void OnDisable()
        {
            _gameProgressionManager.OnGameEnded -= HandleGameEnd;
        }
    }
}

