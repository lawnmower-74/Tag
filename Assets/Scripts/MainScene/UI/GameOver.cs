using UnityEngine;

/// <summary>ゲームオーバー時に実行</summary>
public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverWindow;
    public TimeCounter TimeCounter;

    void Update()
    {
        // 鬼に捕まったらアウト
        if (!Player && TimeCounter.PlayTimeSeconds > 0)
        {
            GameOverWindow.SetActive(true);
        }
    }
}
