using UnityEngine;

/// <summary>ゲームオーバー画面の表示</summary>
public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverWindow;
    public TimeCounter TimeCounter;
    private float _playTimeSeconds;

    void Update()
    {
        _playTimeSeconds = TimeCounter.PlayTimeSeconds;

        // 鬼に捕まったらアウト
        if (!Player && _playTimeSeconds > 0)
        {
            GameOverWindow.SetActive(true);
        }
    }
}
