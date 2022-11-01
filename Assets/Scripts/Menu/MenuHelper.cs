using UnityEngine;

namespace TicTacToe.Utils
{
    public class MenuHelper : MonoBehaviour
    {
        public void ToggleGameObject(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}


