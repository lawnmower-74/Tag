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

    // public void GameReStart()
    // {
    //     // TODO：ゲーム画面ではなく、タイトル画面からにする予定
    //     SceneManager.LoadScene("MainScene");
    // }
}
