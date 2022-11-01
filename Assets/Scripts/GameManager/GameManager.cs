using System.Collections;
using TicTacToe.GameManagement;
using TicTacToe.GameManagement.Players;
using TicTacToe.GameProgression;
using TicTacToe.GameSetup;
using UnityEngine;

namespace TicTacToe.GameManagment
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player1GameObject;
        [SerializeField]
        private GameObject _player2GameObject;

        private IPlayer _player1;
        private IPlayer _player2;
        private GameProgressionManager _gameProgressionManager;
        private GameResultHandler _gameResultHandler;

        void Awake()
        {
            _gameProgressionManager = GetComponentInChildren<GameProgressionManager>();
            _gameResultHandler = GetComponent<GameResultHandler>();
            _gameProgressionManager.OnGameEnded += HandleGameEnd;
        }

        // Initialize the player components, then start the game
        IEnumerator Start()
        {
            GetPlayersComponents();
            AssignNamesForPlayers();
            _gameProgressionManager.InitPlayers(_player1, _player2);

            yield return null; //Wait a frame to let everything initialize
            StartGame();
        }

        private void GetPlayersComponents()
        {
            _player1 = _player1GameObject.GetComponent<IPlayer>();
            _player2 = _player2GameObject.GetComponent<IPlayer>();
        }

        private void AssignNamesForPlayers()
        {
            _player1.Name = Consts.PLAYER_1_NAME;
            _player2.Name = Consts.PLAYER_2_NAME;
        }

        public void StartGame()
        {
            GameEvents.Instance.GameStart();
            _gameProgressionManager.StartGame();
        }

        private void HandleGameEnd(enGameState gameResult)
        {
            GameEvents.Instance.GameEnded(gameResult);
            IPlayer winner;

            switch (gameResult)
            {
                case enGameState.X_WIN:
                    winner = _gameProgressionManager.GetPlayerBySymbol(enSymbol.X);
                    _gameResultHandler.HandleWin(winner);
                    break;

                case enGameState.O_WIN:
                    winner = _gameProgressionManager.GetPlayerBySymbol(enSymbol.O);
                    _gameResultHandler.HandleWin(winner);
                    break;

                case enGameState.DRAW:
                    _gameResultHandler.HandleDraw();
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

