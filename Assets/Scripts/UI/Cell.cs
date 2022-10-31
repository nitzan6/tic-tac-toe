using UnityEngine;

namespace TicTacToe.UI
{
    public class Cell : MonoBehaviour
    {
        [SerializeField]
        private Vector2Int positionInBoard;
        private LocalInputHandler _localInputHandler;

        void Awake()
        {
            _localInputHandler = GetComponentInParent<LocalInputHandler>();
        }

        public void CellClicked()
        {
            _localInputHandler.OnCellClicked(positionInBoard);
        }
    }
}

