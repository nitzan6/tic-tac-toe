using TicTacToe.GameManagement;
using TicTacToe.GameManagement.Players;
using UnityEngine;

public class BoardLocalInputHandler : MonoBehaviour
{
    private LocalPlayer[] _localPlayers;

    void Awake()
    {
        _localPlayers = FindObjectsOfType<LocalPlayer>();
    }

    void OnEnable()
    {
        
    }

    public void HandleLocalInput(int x)
    {
        foreach (LocalPlayer localPlayer in _localPlayers)
        {
            localPlayer.HandlePlayerInput(new Vector2Int());
        }
    }

}
