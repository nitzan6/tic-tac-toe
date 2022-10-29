using UnityEngine;
using TicTacToe.GameManagement.Gamemodes;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagment
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public Gamemode Gamemode = new Gamemode(typeof(LocalPlayer), typeof(LocalPlayer));
        public float MaxTimePerTurn;
    }
}

