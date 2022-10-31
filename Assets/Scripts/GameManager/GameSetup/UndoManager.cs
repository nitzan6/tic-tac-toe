using TicTacToe.GameManagement.Gamemodes;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _undoButton;
    public bool CanUndo { get; private set; }

    public void ApplyUndoSettings(Gamemode gamemode)
    {
        CanUndo = gamemode.IsGameModeVsComputer();
        _undoButton.SetActive(CanUndo);
    }
}
