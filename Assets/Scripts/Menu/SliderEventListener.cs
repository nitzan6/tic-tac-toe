using TMPro;
using UnityEngine;

namespace TicTacToe.UI
{
    public class SliderEventListener : MonoBehaviour
    {
        private TMP_Text _text;

        void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void SetTextDisplay(float value)
        {
            _text.text = value.ToString("0.00");
        }
    }
}

