using System;
using UnityEngine;

namespace TicTacToe.GameManagement
{
    public class GameSetupHandler : MonoBehaviour
    {
        [SerializeField]
        private GameSettings _gameSettings;
        [SerializeField]
        private GameObject _player1;
        [SerializeField]
        private GameObject _player2;
        
        void Awake()
        {
            ApplyGameSettings();
        }

        private void ApplyGameSettings()
        {
            HandleSelectedGameMode();
        }

        private void HandleSelectedGameMode()
        {
            switch (_gameSettings.GameMode)
            {
                case GameMode.LocalVsAI:
                    SetLocalVsAIMode();
                    break;
                case GameMode.LocalVsLocal:
                    SetLocalVsLocalMode();
                    break;
                default:
                    throw new InvalidOperationException($"Gamemode {_gameSettings.GameMode} is not supported");
            }
        }

        private void SetLocalVsLocalMode()
        {
            _player1.AddComponent<LocalPlayer>();
            _player2.AddComponent<LocalPlayer>();
        }

        private void SetLocalVsAIMode()
        {
            _player1.AddComponent<LocalPlayer>();
            _player2.AddComponent<AI>();
        }
    }
}
