using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TicTacToe.UI
{
    public class EndGameMessageDisplayer : MonoBehaviour
    {
        private TextMeshPro _text;
        private Image _image;

        void Awake()
        {
             _text = transform.Find(Consts.GAME_END_MESSAGE_COMPONENT).GetComponent<TextMeshPro>();
             _image = transform.Find(Consts.WINNER_IMAGE).GetComponent<Image>();
        }

        public void DisplayWinner(string winnerName)
        {

        }

        public void DisplayDraw()
        {

        }
    }

}

