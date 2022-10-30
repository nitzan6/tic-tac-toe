using System.Collections;
using TicTacToe.GameManagement;
using TicTacToe.GameProgression;
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

        void OnEnable()
        {
            GameEvents.Instance.onStartGame += () => Debug.Log("TEST");
        }

        IEnumerator Start()
        {
            yield return null;
            StartGame();
        }

        private void StartGame()
        {
            GameEvents.Instance.StartGame();
            _gameProgressionHandler.StartGame();
        }

        private void RestartGame()
        {

        }
    }
}

