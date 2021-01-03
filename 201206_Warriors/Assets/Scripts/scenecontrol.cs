using UnityEngine.SceneManagement;
using UnityEngine;

public class scenecontrol : MonoBehaviour
{
    /// <summary>
    /// 遊戲開始
    /// </summary>
   public void StartGame()
    {
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 返回選單
    /// </summary>
   public void BackToMenu()
    {
        SceneManager.LoadScene("選單");
    }


    /// <summary>
    /// 離開遊戲
    /// </summary>
   public void QuitGame()
    {
        Application.Quit();
    }
}
