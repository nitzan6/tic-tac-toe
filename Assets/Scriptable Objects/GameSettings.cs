using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    public GameMode GameMode = GameMode.LocalVsLocal;
    public float MaxTimePerTurn = 5f;
}
