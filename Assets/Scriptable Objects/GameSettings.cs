using TicTacToe.Gameplay.Players;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    public GameMode GameMode;
}
