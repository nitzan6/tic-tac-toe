using UnityEngine;
using TicTacToe.GameManagement;
using TicTacToe.GameManagement.Gamemodes;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagment
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public IGamemode<IPlayer, IPlayer> Gamemode;
        public float MaxTimePerTurn;
    }
}

