using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }


    /// <summary>
    /// 設定介面啟動時暫停遊戲，關閉時繼續遊戲
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// 關閉時繼續遊戲
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1;
        player.enabled = true;
    }
}
