using UnityEngine;
using TicTacToe.GameManagement;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Vector2Int positionInBoard;

    public void CellClicked()
    {
        Debug.Log("Clicked position " + positionInBoard);
        GameEvents.Instance.CellClicked(positionInBoard);
    }
}
