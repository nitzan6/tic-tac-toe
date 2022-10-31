using TicTacToe.GameManagement;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.UI
{
    public class UIEventListener : MonoBehaviour
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
            GameEvents.Instance.onGameRestart += ClearBoardUI;
        }

        private void UpdateBoardUI(Vector2Int position, Symbol symbol)
        {
            if (symbol == Symbol.X)
            {
                LoadSprite(position, _xSprite);
                return;
            }

            LoadSprite(position, _oSprite);

        }

        private void LoadSprite(Vector2Int position, Sprite sprite)
        {
            //Convert the 2D vector we use on the board to an index in the array we got
            int index = position.y * Consts.BOARD_WIDTH + position.x;

            _cellsImageComponents[index].sprite = sprite;
            _cellsImageComponents[index].color = Color.white;
        }

        private void ClearBoardUI()
        {
            foreach (Image imageComponent in _cellsImageComponents)
            {
                imageComponent.sprite = null;
            }
        }

        void OnDisable()
        {
            GameEvents.Instance.onMadeMove -= UpdateBoardUI;
            GameEvents.Instance.onGameRestart -= ClearBoardUI;
        }
    }
}
