using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe.GameManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadMenuScene()
        {
            SceneManager.LoadScene(Consts.MENU_SCENE);
        }

        public void LoadGameplayScene()
        {
            SceneManager.LoadScene(Consts.GAMEPLAY_SCENE);
        }
    }

}
