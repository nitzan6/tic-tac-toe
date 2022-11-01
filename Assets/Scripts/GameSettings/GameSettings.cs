using UnityEngine;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameSetup
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public Gamemode Gamemode = new Gamemode(typeof(LocalPlayer), typeof(AI));
        public float MaxTimePerTurn;
    }
}

