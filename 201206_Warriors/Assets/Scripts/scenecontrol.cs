using UnityEngine.SceneManagement;
using UnityEngine;

public class scenecontrol : MonoBehaviour
{



    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundclick;

    /// <summary>
    /// 遊戲開始
    /// </summary>
   public void StartGame()
    {

        aud.PlayOneShot(soundclick, 1);
        Invoke("DelayStartGame", 1.5f);
    }


    /// <summary>
    /// 返回選單
    /// </summary>
   public void BackToMenu()
    {
        aud.PlayOneShot(soundclick, 1);
        Invoke("DelayBackToMenu", 1.5f);
    }


    /// <summary>
    /// 離開遊戲
    /// </summary>
   public void QuitGame()
    {
        aud.PlayOneShot(soundclick, 1);
        Invoke("DelayQuitGame",1.5F);
    }


    private void DelayStartGame()
    {
        SceneManager.LoadScene("遊戲場景");

    }

    private void DelayBackToMenu()
    {
        SceneManager.LoadScene("選單");

    }

    private void DelayQuitGame()
    {
        Application.Quit();
    }
}
