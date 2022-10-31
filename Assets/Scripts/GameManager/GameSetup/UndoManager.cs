using TicTacToe.GameManagement;
using TicTacToe.GameManagement.Gamemodes;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _undoButton;
    public bool CanUndo { get; private set; }

    void OnEnable()
    {
        GameEvents.Instance.onGameStart += EnableUndoAbility;
        GameEvents.Instance.onGameEnded += DisableUndoAbility;
    }
    private void EnableUndoAbility()
    {
        CanUndo = true;
    }

    private void DisableUndoAbility(GameState _)
    {
        CanUndo = false;
    }

    public void ApplyUndoSettings(Gamemode gamemode)
    {
        CanUndo = gamemode.IsGameModeVsComputer();
        _undoButton.SetActive(CanUndo);
    }

    private void OnDisable()
    {
        GameEvents.Instance.onGameStart -= EnableUndoAbility;
        GameEvents.Instance.onGameEnded -= DisableUndoAbility;
    }
}
