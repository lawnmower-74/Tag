using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>ゲームオーバー画面の表示・リスタート</summary>
public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverWindow;


    void Update()
    {
        if (!Player)
        {
            GameOverWindow.SetActive(true);
        }
    }

    // リスタートボタンクリック時に実行
    public void ReStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // TOPへボタンクリック時に実行
    public void ToTop()
    {
        SceneManager.LoadScene("TopScene");
    }
}
