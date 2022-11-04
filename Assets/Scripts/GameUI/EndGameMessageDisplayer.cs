using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TicTacToe.UI
{
    public class EndGameMessageDisplayer : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private Image _winImage;

        public void ResetDisplay()
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }

        public void DisplayWinner(string winnerName)
        {
            _text.text = $"{winnerName.ToUpper()} WINS!";
            _winImage.gameObject.SetActive(true);
            gameObject.SetActive(true);
        }

        public void DisplayDraw()
        {
            _text.text = "DRAW!";
            gameObject.SetActive(true);
            _winImage.gameObject.SetActive(false);
        }
    }

}

