using System.Collections.Generic;
using TicTacToe.GameManagement;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.UI
{
    public class BoardUIUpdater : MonoBehaviour
    {
        [SerializeField]
        private Sprite _xSprite;
        [SerializeField]
        private Sprite _oSprite;

        private Image[] _cellsImageComponents;

        void Awake()
        {
            _cellsImageComponents = GetComponentsInChildren<Image>();
        }

        void OnEnable()
        {
            GameEvents.Instance.onMadeMove += UpdateBoardUI;
            GameEvents.Instance.onGameStart += ClearBoardUI;
            GameEvents.Instance.onUndoLastMove += ClearCell;
        }

        private void UpdateBoardUI(Vector2Int position, enSymbol symbol)
        {
            if (symbol == enSymbol.X)
            {
                LoadSprite(position, _xSprite);
                return;
            }

            LoadSprite(position, _oSprite);
        }

        private void LoadSprite(Vector2Int position, Sprite sprite)
        {
            int index = GetArrayIndexFromPosition(position);
            PlaceSprite(_cellsImageComponents[index], sprite);
        }

        //Convert the 2D vector we use on the board to an index in the image components array
        private int GetArrayIndexFromPosition(Vector2Int position)
        {
            return position.y * Consts.BOARD_WIDTH + position.x;
        }

        private void ClearBoardUI()
        {
            foreach (Image imageComponent in _cellsImageComponents)
            {
                ClearSprite(imageComponent);
            }
        }

        private void ClearCell(List<Vector2Int> positions)
        {
            foreach (Vector2Int position in positions)
            {
                int arrayIndex = GetArrayIndexFromPosition(position);
                ClearSprite(_cellsImageComponents[arrayIndex]);
            }
        }

        private void PlaceSprite(Image image, Sprite sprite)
        {
            image.sprite = sprite;
            image.color = Color.white;
        }

        private void ClearSprite(Image image)
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0);
        }

        void OnDisable()
        {
            GameEvents.Instance.onMadeMove -= UpdateBoardUI;
            GameEvents.Instance.onGameStart -= ClearBoardUI;
        }
    }
}
