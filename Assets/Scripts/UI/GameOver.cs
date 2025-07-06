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

    public void GameReStart()
    {
        // TODO：クリックできないのでできるように
        SceneManager.LoadScene("MainScene");
    }
}
