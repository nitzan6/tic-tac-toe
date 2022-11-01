using UnityEngine;
using TMPro;
using System.Collections;

namespace TicTacToe.UI
{
    public class FirstTurnAnnouncer : MonoBehaviour
    {
        private TMP_Text _text;

        [SerializeField]
        private float _displayTime;

        void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        void OnEnable()
        {
            GameEvents.Instance.onRolesAssigned += AnnounceFirstPlayer;
            GameEvents.Instance.onGameStart += StopRunningCoroutines;
        }

        //Here we announce through the UI who goes first
        private void AnnounceFirstPlayer(string firstPlayerName)
        {
            StartCoroutine(DisplayTextForSetTime(firstPlayerName));
        }

        private void StopRunningCoroutines()
        {
            StopAllCoroutines();
        }

        private IEnumerator DisplayTextForSetTime(string text)
        {
            _text.text = $"{text.ToUpper()} GOES FIRST";
            yield return new WaitForSeconds(_displayTime);

            _text.text = string.Empty;
        }

        void OnDisable()
        {
            GameEvents.Instance.onRolesAssigned -= AnnounceFirstPlayer;
            GameEvents.Instance.onGameStart -= StopRunningCoroutines;
        }
    }

}
